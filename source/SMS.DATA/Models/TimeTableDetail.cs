using System.ComponentModel.DataAnnotations;

namespace SMS.DATA.Models
{
    public partial class TimeTableDetail : BaseEntity
    {
        [StringLength(50)]
        public string Day { get; set; }

        public int? ClassId { get; set; }

        public int? PeriodId { get; set; }

        public int? TeacherId { get; set; }

        public int? TimeTableId { get; set; }

        public virtual Class Class { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Period Period { get; set; }

        public virtual TimeTable TimeTable { get; set; }
    }
}
