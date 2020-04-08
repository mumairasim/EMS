using System.ComponentModel.DataAnnotations;

namespace SMS.DTOs
{
    public class TimeTableDetail : DtoBaseEntity
    {
        [StringLength(50)]
        public string Day { get; set; }

        public int? ClassId { get; set; }

        public int? PeriodId { get; set; }

        public int? TeacherId { get; set; }

        public int? TimeTableId { get; set; }
    }
}
