using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DTOs
{
    public class Student : DtoBaseEntity
    {
        [Required]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        public Guid? PersonId { get; set; }

        public Guid? ClassId { get; set; }
    }
}
