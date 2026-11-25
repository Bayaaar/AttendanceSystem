using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using AttendanceSystem.Models;

namespace AttendanceSystem.DAL
{
    public class AttendanceRepository
    {
        public List<Student> GetAllStudents()
        {
            var list = new List<Student>();
            try
            {
                using (var conn = MySqlDbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT id, student_code, full_name, group_name FROM students ORDER BY full_name";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Student
                            {
                                Id = reader.GetInt32("id"),
                                StudentCode = reader.GetString("student_code"),
                                FullName = reader.GetString("full_name"),
                                GroupName = reader.GetString("group_name")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Оюутны жагсаалт татахад алдаа гарлаа: " + ex.Message);
            }
            return list;
        }

        public void AddStudent(Student student)
        {
            try
            {
                using (var conn = MySqlDbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO students (student_code, full_name, group_name) VALUES (@code, @name, @grp)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@code", student.StudentCode);
                        cmd.Parameters.AddWithValue("@name", student.FullName);
                        cmd.Parameters.AddWithValue("@grp", student.GroupName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Оюутан нэмэхэд алдаа гарлаа: " + ex.Message);
            }
        }

        public List<AttendanceRecord> GetAttendance(string searchKeyword = "", string statusFilter = "Бүгд")
        {
            var list = new List<AttendanceRecord>();
            try
            {
                using (var conn = MySqlDbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT a.id, a.student_id, s.student_code, s.full_name, s.group_name,
                               a.attendance_date, a.status, a.late_minutes, a.is_excused, a.note
                        FROM attendance_records a
                        INNER JOIN students s ON a.student_id = s.id
                        WHERE (s.full_name LIKE @kw OR s.student_code LIKE @kw OR s.group_name LIKE @kw)";

                    if (!string.IsNullOrWhiteSpace(statusFilter) && statusFilter != "Бүгд")
                    {
                        query += " AND a.status = @status";
                    }

                    query += " ORDER BY a.attendance_date DESC, a.id DESC";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + searchKeyword.Trim() + "%");
                        if (!string.IsNullOrWhiteSpace(statusFilter) && statusFilter != "Бүгд")
                        {
                            cmd.Parameters.AddWithValue("@status", statusFilter);
                        }

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new AttendanceRecord
                                {
                                    Id = reader.GetInt32("id"),
                                    StudentId = reader.GetInt32("student_id"),
                                    StudentCode = reader.GetString("student_code"),
                                    StudentName = reader.GetString("full_name"),
                                    GroupName = reader.GetString("group_name"),
                                    AttendanceDate = reader.GetDateTime("attendance_date"),
                                    Status = reader.GetString("status"),
                                    LateMinutes = reader.IsDBNull(reader.GetOrdinal("late_minutes")) ? 0 : reader.GetInt32("late_minutes"),
                                    IsExcused = !reader.IsDBNull(reader.GetOrdinal("is_excused")) && reader.GetBoolean("is_excused"),
                                    Note = reader.IsDBNull(reader.GetOrdinal("note")) ? "" : reader.GetString("note")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ирцийн мэдээлэл уншихад алдаа гарлаа: " + ex.Message);
            }
            return list;
        }

        public void AddAttendance(AttendanceRecord record)
        {
            try
            {
                using (var conn = MySqlDbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO attendance_records 
                        (student_id, attendance_date, status, late_minutes, is_excused, note)
                        VALUES (@sid, @date, @status, @late, @excused, @note)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", record.StudentId);
                        cmd.Parameters.AddWithValue("@date", record.AttendanceDate.Date);
                        cmd.Parameters.AddWithValue("@status", record.Status);
                        cmd.Parameters.AddWithValue("@late", record.LateMinutes);
                        cmd.Parameters.AddWithValue("@excused", record.IsExcused ? 1 : 0);
                        cmd.Parameters.AddWithValue("@note", record.Note ?? "");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ирц бүртгэхэд алдаа гарлаа: " + ex.Message);
            }
        }

        public void UpdateAttendance(AttendanceRecord record)
        {
            try
            {
                using (var conn = MySqlDbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE attendance_records
                        SET student_id = @sid,
                            attendance_date = @date,
                            status = @status,
                            late_minutes = @late,
                            is_excused = @excused,
                            note = @note
                        WHERE id = @id";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", record.Id);
                        cmd.Parameters.AddWithValue("@sid", record.StudentId);
                        cmd.Parameters.AddWithValue("@date", record.AttendanceDate.Date);
                        cmd.Parameters.AddWithValue("@status", record.Status);
                        cmd.Parameters.AddWithValue("@late", record.LateMinutes);
                        cmd.Parameters.AddWithValue("@excused", record.IsExcused ? 1 : 0);
                        cmd.Parameters.AddWithValue("@note", record.Note ?? "");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ирц засахад алдаа гарлаа: " + ex.Message);
            }
        }

        public void DeleteAttendance(int id)
        {
            try
            {
                using (var conn = MySqlDbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM attendance_records WHERE id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ирц устгахад алдаа гарлаа: " + ex.Message);
            }
        }
    }
}