using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
{
    [Table("AttendanceStatus")]
    public partial class AttendanceStatus : BaseEntity
    {
        public string Status { get; set; }
    }
}
