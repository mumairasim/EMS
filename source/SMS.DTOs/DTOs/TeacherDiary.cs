using System;

namespace SMS.DTOs.DTOs
{
    public class TeacherDiary : DtoBaseEntity
    {
        public string DairyText { get; set; }

        public DateTime? DairyDate { get; set; }

        public int? InstructorId { get; set; }

    }
}
