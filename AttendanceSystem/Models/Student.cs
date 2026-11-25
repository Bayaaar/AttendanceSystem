namespace AttendanceSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;

        // ComboBox дээр цэвэрхэн харагдахын тулд
        public string DisplayText => $"{StudentCode} - {FullName} ({GroupName})";
    }
}