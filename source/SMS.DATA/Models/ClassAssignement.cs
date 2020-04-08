using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
{

    [Table("ClassAssignement")]
    public partial class ClassAssignement : BaseEntity
    {

        public int? ClassId { get; set; }

        public int? AssignmentId { get; set; }

        public virtual Assignment Assignment { get; set; }

        public virtual Class Class { get; set; }
    }
}
