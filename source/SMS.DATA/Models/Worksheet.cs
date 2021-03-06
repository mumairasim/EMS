using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
{
    [Table("Worksheet")]
    public partial class Worksheet : BaseEntity
    {
        public string Text { get; set; }

        public DateTime? ForDate { get; set; }

        public Guid? InstructorId { get; set; }
        public Guid? SchoolId { get; set; }

        public virtual School School { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
