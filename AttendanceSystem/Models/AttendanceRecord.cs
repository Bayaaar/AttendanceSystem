namespace AttendanceSystem.Models
{
    public class AttendanceRecord
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int LateMinutes { get; set; }
        public bool IsExcused { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}