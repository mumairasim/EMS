using System.ComponentModel.DataAnnotations;

namespace SMS.DTOs
{
    public class Class : DtoBaseEntity
    {
        [Required]
        [StringLength(50)]
        public string ClassName { get; set; }
    }
}
