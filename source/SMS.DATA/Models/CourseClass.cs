using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
{
    [Table("CourseClass")]
    public partial class CourseClass : BaseEntity
    {
        public Guid? CourseId { get; set; }

        public Guid? ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual Course Course { get; set; }
    }
}
