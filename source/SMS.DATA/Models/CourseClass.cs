using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
{
    [Table("CourseClass")]
    public partial class CourseClass : BaseEntity
    {
        public int? CourseId { get; set; }

        public int? ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual Course Course { get; set; }
    }
}
