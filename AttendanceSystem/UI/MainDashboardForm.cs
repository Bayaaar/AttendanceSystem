using System.ComponentModel;
using System.Globalization;
using System.Text;
using AttendanceSystem.DAL;
using AttendanceSystem.Models;

namespace AttendanceSystem.UI
{
    public partial class MainDashboardForm : Form
    {
        private readonly AttendanceRepository _attendanceRepository = new();
        private readonly User _loggedInUser;
        private List<AttendanceRecord> _visibleRecords = new();
        private int _presentCount;
        private int _lateCount;
        private int _absentCount;

        public MainDashboardForm() : this(new User())
        {
        }

        public MainDashboardForm(User loggedInUser)
        {
            _loggedInUser = loggedInUser ?? throw new ArgumentNullException(nameof(loggedInUser));
            InitializeComponent();

            cmbStatus.Items.AddRange(new object[] { "Ирсэн", "Хоцорсон", "Тасалсан" });
            cmbStatus.SelectedIndex = 0;
            cmbFilterStatus.Items.AddRange(new object[] { "Бүгд", "Ирсэн", "Хоцорсон", "Тасалсан" });
            cmbFilterStatus.SelectedIndex = 0;
            lblWelcome.Text = string.IsNullOrWhiteSpace(_loggedInUser.FullName)
                ? "Ирцийн хяналтын самбар"
                : $"Сайн байна уу, {_loggedInUser.FullName}";
            Load += MainDashboardForm_Load;
        }

        private void MainDashboardForm_Load(object? sender, EventArgs e)
        {
            LoadStudents();
            LoadAttendance();
        }

        private void LoadStudents()
        {
            try
            {
                cmbStudent.DataSource = _attendanceRepository.GetAllStudents();
                cmbStudent.DisplayMember = nameof(Student.DisplayText);
                cmbStudent.ValueMember = nameof(Student.Id);
                cmbStudent.SelectedIndex = cmbStudent.Items.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Оюутны мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAttendance()
        {
            try
            {
                string status = cmbFilterStatus.SelectedItem?.ToString() ?? "Бүгд";
                _visibleRecords = _attendanceRepository.GetAttendance(txtSearch.Text.Trim(), status);
                dgvAttendance.DataSource = null;
                dgvAttendance.DataSource = new BindingList<AttendanceRecord>(_visibleRecords);
                ConfigureAttendanceColumns();
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ирцийн мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureAttendanceColumns()
        {
            SetColumn("Id", "Дугаар", false);
            SetColumn("StudentId", "Оюутны ID", false);
            SetColumn("StudentCode", "Оюутны код");
            SetColumn("StudentName", "Оюутны нэр");
            SetColumn("GroupName", "Бүлэг");
            SetColumn("AttendanceDate", "Огноо");
            SetColumn("Status", "Төлөв");
            SetColumn("LateMinutes", "Хоцорсон (мин)");
            SetColumn("IsExcused", "Шалтгаантай");
            SetColumn("Note", "Тэмдэглэл");

            if (dgvAttendance.Columns[nameof(AttendanceRecord.AttendanceDate)] is { } dateColumn)
            {
                dateColumn.DefaultCellStyle.Format = "yyyy-MM-dd";
            }
        }

        private void SetColumn(string name, string headerText, bool visible = true)
        {
            if (dgvAttendance.Columns[name] is { } column)
            {
                column.HeaderText = headerText;
                column.Visible = visible;
            }
        }

        private void UpdateStatistics()
        {
            _presentCount = _visibleRecords.Count(record => record.Status == "Ирсэн");
            _lateCount = _visibleRecords.Count(record => record.Status == "Хоцорсон");
            _absentCount = _visibleRecords.Count(record => record.Status == "Тасалсан");
            int unexcusedAbsences = _visibleRecords.Count(record => record.Status == "Тасалсан" && !record.IsExcused);
            int seriousLateness = _visibleRecords.Count(record => record.Status == "Хоцорсон" && record.LateMinutes >= 15);

            lblStats.Text = $"Нийт: {_visibleRecords.Count} | Ирсэн: {_presentCount} | " +
                $"Хоцорсон: {_lateCount} | Тасалсан: {_absentCount}{Environment.NewLine}" +
                $"Шалтгаангүй таслалт: {unexcusedAbsences} | 15+ минут хоцролт: {seriousLateness}";
            chartPanel.Invalidate();
        }

        private void btnAddStudent_Click(object? sender, EventArgs e)
        {
            string code = txtStudentCode.Text.Trim();
            string name = txtStudentName.Text.Trim();
            string group = txtGroupName.Text.Trim();
            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(group))
            {
                MessageBox.Show("Оюутны код, нэр, бүлгийг бүрэн оруулна уу.", "Шалгах", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _attendanceRepository.AddStudent(new Student { StudentCode = code, FullName = name, GroupName = group });
                txtStudentCode.Clear();
                txtStudentName.Clear();
                txtGroupName.Clear();
                LoadStudents();
                MessageBox.Show("Оюутан амжилттай нэмэгдлээ.", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Оюутан нэмэх", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (cmbStudent.SelectedItem is not Student student)
            {
                MessageBox.Show("Эхлээд оюутан сонгоно уу.", "Шалгах", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _attendanceRepository.AddAttendance(CreateAttendanceRecord(student));
                LoadAttendance();
                ClearAttendanceFields();
                MessageBox.Show("Ирц амжилттай бүртгэгдлээ.", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ирц бүртгэх", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (GetSelectedRecord() is not { } selected || cmbStudent.SelectedItem is not Student student)
            {
                MessageBox.Show("Засах мөр болон оюутныг сонгоно уу.", "Шалгах", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                AttendanceRecord record = CreateAttendanceRecord(student);
                record.Id = selected.Id;
                _attendanceRepository.UpdateAttendance(record);
                LoadAttendance();
                ClearAttendanceFields();
                MessageBox.Show("Ирцийн мэдээлэл шинэчлэгдлээ.", "Амжилттай", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ирц засах", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (GetSelectedRecord() is not { } selected)
            {
                MessageBox.Show("Устгах ирцийн мөрөө сонгоно уу.", "Шалгах", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Сонгосон ирцийн бүртгэлийг устгах уу?", "Баталгаажуулах",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _attendanceRepository.DeleteAttendance(selected.Id);
                LoadAttendance();
                ClearAttendanceFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ирц устгах", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearAttendanceFields();
        }

        private void ClearAttendanceFields()
        {
            if (cmbStudent.Items.Count > 0)
            {
                cmbStudent.SelectedIndex = 0;
            }

            dtpAttendanceDate.Value = DateTime.Today;
            cmbStatus.SelectedIndex = 0;
            numLateMinutes.Value = 0;
            chkIsExcused.Checked = false;
            txtNote.Clear();
            dgvAttendance.ClearSelection();
        }

        private AttendanceRecord CreateAttendanceRecord(Student student)
        {
            return new AttendanceRecord
            {
                StudentId = student.Id,
                StudentCode = student.StudentCode,
                StudentName = student.FullName,
                GroupName = student.GroupName,
                AttendanceDate = dtpAttendanceDate.Value.Date,
                Status = cmbStatus.SelectedItem?.ToString() ?? "Ирсэн",
                LateMinutes = (int)numLateMinutes.Value,
                IsExcused = chkIsExcused.Checked,
                Note = txtNote.Text.Trim()
            };
        }

        private AttendanceRecord? GetSelectedRecord()
        {
            return dgvAttendance.CurrentRow?.DataBoundItem as AttendanceRecord;
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            LoadAttendance();
        }

        private void cmbFilterStatus_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadAttendance();
        }

        private void dgvAttendance_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvAttendance.Rows[e.RowIndex].DataBoundItem is not AttendanceRecord record)
            {
                return;
            }

            cmbStudent.SelectedValue = record.StudentId;
            dtpAttendanceDate.Value = record.AttendanceDate;
            cmbStatus.SelectedItem = record.Status;
            numLateMinutes.Value = Math.Clamp(record.LateMinutes, (int)numLateMinutes.Minimum, (int)numLateMinutes.Maximum);
            chkIsExcused.Checked = record.IsExcused;
            txtNote.Text = record.Note;
        }

        private void dgvAttendance_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvAttendance.Rows[e.RowIndex].DataBoundItem is not AttendanceRecord record)
            {
                return;
            }

            if (record.Status == "Тасалсан" && !record.IsExcused)
            {
                dgvAttendance.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.MistyRose;
                dgvAttendance.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed;
            }
            else if (record.Status == "Хоцорсон" && record.LateMinutes >= 15)
            {
                dgvAttendance.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;
                dgvAttendance.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.DarkGoldenrod;
            }
            else
            {
                dgvAttendance.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgvAttendance.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(35, 45, 55);
            }
        }

        private void btnExportCsv_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog dialog = new()
            {
                Filter = "CSV файл (*.csv)|*.csv",
                DefaultExt = "csv",
                AddExtension = true,
                FileName = $"attendance_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                Title = "Ирцийн мэдээллийг CSV болгон хадгалах"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                StringBuilder csv = new();
                csv.AppendLine("Оюутны код,Оюутны нэр,Бүлэг,Огноо,Төлөв,Хоцорсон минут,Хүндэтгэх шалтгаантай,Тэмдэглэл");
                foreach (AttendanceRecord record in _visibleRecords)
                {
                    csv.AppendLine(string.Join(",", new[]
                    {
                        EscapeCsv(record.StudentCode),
                        EscapeCsv(record.StudentName),
                        EscapeCsv(record.GroupName),
                        EscapeCsv(record.AttendanceDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)),
                        EscapeCsv(record.Status),
                        EscapeCsv(record.LateMinutes.ToString(CultureInfo.InvariantCulture)),
                        EscapeCsv(record.IsExcused ? "Тийм" : "Үгүй"),
                        EscapeCsv(record.Note)
                    }));
                }

                File.WriteAllText(dialog.FileName, csv.ToString(), new UTF8Encoding(true));
                MessageBox.Show("CSV файл амжилттай хадгалагдлаа.", "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CSV файл хадгалахад алдаа гарлаа: {ex.Message}", "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string EscapeCsv(string? value)
        {
            string escaped = (value ?? string.Empty).Replace("\"", "\"\"");
            return $"\"{escaped}\"";
        }

        private void chartPanel_Paint(object? sender, PaintEventArgs e)
        {
            int maxCount = Math.Max(1, Math.Max(_presentCount, Math.Max(_lateCount, _absentCount)));
            int barWidth = Math.Max(0, chartPanel.ClientSize.Width - 210);
            int[] counts = { _presentCount, _lateCount, _absentCount };
            string[] labels = { "Ирсэн", "Хоцорсон", "Тасалсан" };
            System.Drawing.Color[] colors =
            {
                System.Drawing.Color.FromArgb(55, 139, 99),
                System.Drawing.Color.FromArgb(225, 169, 45),
                System.Drawing.Color.FromArgb(194, 73, 73)
            };

            using System.Drawing.Font font = new("Segoe UI", 9F);
            for (int i = 0; i < counts.Length; i++)
            {
                int y = 12 + i * 30;
                e.Graphics.DrawString(labels[i], font, System.Drawing.Brushes.Black, 8, y);
                int width = (int)(barWidth * counts[i] / (double)maxCount);
                using System.Drawing.SolidBrush brush = new(colors[i]);
                e.Graphics.FillRectangle(brush, 84, y + 3, width, 16);
                e.Graphics.DrawString(counts[i].ToString(CultureInfo.InvariantCulture), font,
                    System.Drawing.Brushes.Black, 92 + width, y);
            }
        }
    }
}