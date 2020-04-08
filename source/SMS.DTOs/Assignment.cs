using System;
using System.Collections.Generic;

namespace SMS.DTOs
{

    public class Assignment : DtoBaseEntity
    {

        public string AssignmentText { get; set; }

        public DateTime? LastDateOfSubmission { get; set; }

        public int? InstructorId { get; set; }

    }
}
