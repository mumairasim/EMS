
using System;

namespace SMS.DTOs.DTOs
{
    public class Employee : DtoBaseEntity
    {
        public Guid? PersonId { get; set; }

        public Guid? DesignationId { get; set; }

    }
}
