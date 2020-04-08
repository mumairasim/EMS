using System.ComponentModel.DataAnnotations;

namespace SMS.DTOs
{
    public class Student : DtoBaseEntity
    {
        [Required]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        public int? PersonId { get; set; }

        public int? ClassId { get; set; }
    }
}
