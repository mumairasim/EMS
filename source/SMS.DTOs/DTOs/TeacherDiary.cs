using System;

namespace SMS.DTOs.DTOs
{
    public class TeacherDiary : DtoBaseEntity
    {
        public string DairyText { get; set; }
        public DateTime? DairyDate { get; set; }
        public Guid? InstructorId { get; set; }
        public Guid? SchoolId { get; set; }
        public  Employee Employee { get; set; }
        public School School { get; set; }
    }
}
