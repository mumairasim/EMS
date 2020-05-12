using System.ComponentModel.DataAnnotations;

namespace SMS.DTOs.DTOs
{
    public class Course : DtoBaseEntity
    {

        [Required]
        [StringLength(50)]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(250)]
        public string CourseName { get; set; }
    }
}
