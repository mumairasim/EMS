using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    [Table("StudentAssignment")]
    public partial class StudentAssignment : BaseEntity
    {
        public int? StudentId { get; set; }

        public int? AssignmentId { get; set; }

        public virtual Assignment Assignment { get; set; }

        public virtual Student Student { get; set; }
    }
}
