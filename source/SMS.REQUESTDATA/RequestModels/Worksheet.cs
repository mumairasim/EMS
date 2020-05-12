using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    [Table("Worksheet")]
    public partial class Worksheet : BaseEntity
    {
        public string Text { get; set; }

        public DateTime? ForDate { get; set; }

        public Guid? InstructorId { get; set; }

        public Guid? SchoolId { get; set; }

        public Guid? RequestTypeId { get; set; }

        public virtual RequestType RequestType { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual School School { get; set; }
    }
}
