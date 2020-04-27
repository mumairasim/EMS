using System;

namespace SMS.DTOs
{
    public class StudentStudentDiary : DtoBaseEntity
    {
        public Guid? StudentDiaryId { get; set; }

        public Guid? StudentId { get; set; }
        
    }
}
