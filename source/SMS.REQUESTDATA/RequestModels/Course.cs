using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    [Table("Course")]
    public partial class Course : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            CourseClasses = new HashSet<CourseClass>();
        }


        [Required]
        [StringLength(50)]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(250)]
        public string CourseName { get; set; }
        public Guid? SchoolId { get; set; }

        public virtual School School { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseClass> CourseClasses { get; set; }
    }
}
