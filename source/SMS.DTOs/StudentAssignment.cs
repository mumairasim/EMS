using System;

namespace SMS.DTOs
{
    public class StudentAssignment : DtoBaseEntity
    {
        public Guid? StudentId { get; set; }

        public Guid? AssignmentId { get; set; }

    }
}
