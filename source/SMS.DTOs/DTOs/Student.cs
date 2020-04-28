using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DTOs.DTOs
{
    public class Student : DtoBaseEntity
    {
        [Required]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        public Guid? PersonId { get; set; }

        public Guid? ClassId { get; set; }
        public Guid? SchoolId { get; set; }
        public Person Person { get; set; }

        public Class Class { get; set; }
        public School School { get; set; }
    }
}
