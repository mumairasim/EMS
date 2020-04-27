
using System;

namespace SMS.DTOs
{
    public class Employee : DtoBaseEntity
    {
        public Guid? PersonId { get; set; }

        public Guid? DesignationId { get; set; }

    }
}
