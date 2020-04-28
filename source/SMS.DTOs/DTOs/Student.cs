using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DTOs.DTOs
{
    public class Student : DtoBaseEntity
    {
        [StringLength(250)]
        public string FirstName { get; set; }

        [StringLength(250)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Cnic { get; set; }

        [StringLength(250)]
        public string Nationality { get; set; }

        [StringLength(250)]
        public string Religion { get; set; }

        public string PresentAddress { get; set; }

        public string PermanentAddress { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        public Guid? PersonId { get; set; }

        public Guid? ClassId { get; set; }
        public Guid? SchoolId { get; set; }
    }
}
