using System.ComponentModel.DataAnnotations;
using System;
namespace SMS.DTOs.DTOs
{
    public class Class : DtoBaseEntity
    {
        [Required]
        [StringLength(50)]
        
        public string ClassName { get; set; }
        public Guid? SchoolId { get; set; }
        public School School { get; set; }
    }
}
