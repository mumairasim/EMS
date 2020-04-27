
using System;

namespace SMS.DTOs
{
    public class CourseClass : DtoBaseEntity
    {
        public Guid? CourseId { get; set; }

        public Guid? ClassId { get; set; }

    }
}
