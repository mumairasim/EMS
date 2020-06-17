using System;

namespace SMS.DTOs.DTOs
{
    public class Course : DtoBaseEntity
    {

        public string CourseCode { get; set; }

        public string CourseName { get; set; }
        public Guid? SchoolId { get; set; }

        public virtual School School { get; set; }
    }
}
