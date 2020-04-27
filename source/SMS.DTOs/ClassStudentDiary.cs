
using System;

namespace SMS.DTOs
{
    public class ClassStudentDiary : DtoBaseEntity
    {

        public Guid? StudentDiaryId { get; set; }

        public Guid? ClassId { get; set; }

    }
}
