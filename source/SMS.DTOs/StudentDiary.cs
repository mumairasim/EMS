using System;

namespace SMS.DTOs
{
    public class StudentDiary : DtoBaseEntity
    {
        public string DiaryText { get; set; }

        public DateTime? DairyDate { get; set; }

        public Guid? InstructorId { get; set; }
    }
}
