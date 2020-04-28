using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DTOs.DTOs
{
    public class TimeTableDetail : DtoBaseEntity
    {
        [StringLength(50)]
        public string Day { get; set; }

        public Guid? ClassId { get; set; }

        public Guid? PeriodId { get; set; }

        public Guid? TeacherId { get; set; }

        public Guid? TimeTableId { get; set; }
    }
}
