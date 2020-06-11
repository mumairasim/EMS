using System;

namespace SMS.DTOs.DTOs
{
    public class LessonPlan : DtoBaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
        public Guid? SchoolId { get; set; }
       
        public School School { get; set; }

    }
}
