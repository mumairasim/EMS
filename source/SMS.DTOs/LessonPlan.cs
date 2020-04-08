using System;

namespace SMS.DTOs
{
    public class LessonPlan : DtoBaseEntity
    {
        public string Text { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
