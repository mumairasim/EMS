using System;

namespace SMS.DTOs
{
    public class ClassTeacherDiary : DtoBaseEntity
    {

        public Guid? TeacherDiaryId { get; set; }

        public Guid? ClassId { get; set; }

    }
}
