using System;

namespace SMS.DTOs
{
    public class Worksheet : DtoBaseEntity
    {
        public string Text { get; set; }

        public DateTime? ForDate { get; set; }

        public Guid? InstructorId { get; set; }
    }
}
