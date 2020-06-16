using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DATA.Models
{
    public partial class TimeTableDetail : BaseEntity
    {
        [StringLength(50)]
        public string Day { get; set; }
        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }
        public Guid? TeacherId { get; set; }

        public Guid? TimeTableId { get; set; }

        public Guid? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Employee Employee { get; set; }


        public virtual TimeTable TimeTable { get; set; }
    }
}
