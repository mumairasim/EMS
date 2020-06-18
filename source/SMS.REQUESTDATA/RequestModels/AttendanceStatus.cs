using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    [Table("AttendanceStatus")]
    public partial class AttendanceStatus : BaseEntity
    {
        public string Status { get; set; }
    }
}
