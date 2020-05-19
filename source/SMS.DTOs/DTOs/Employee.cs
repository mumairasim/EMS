
using System;

namespace SMS.DTOs.DTOs
{
    public class Employee : DtoBaseEntity
    {
        public Guid? SchoolId { get; set; }

        public School School { get; set; }

        public Guid? PersonId { get; set; }

        public Guid? DesignationId { get; set; }

        public Person Person { get; set; }

        public Designation Designation  { get; set; }

    }
}
