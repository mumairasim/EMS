using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    [Table("ClassAssignement")]
    public partial class ClassAssignement : BaseEntity
    {

        public Guid? ClassId { get; set; }

        public Guid? AssignmentId { get; set; }

        public virtual Assignment Assignment { get; set; }

        public virtual Class Class { get; set; }
    }
}
