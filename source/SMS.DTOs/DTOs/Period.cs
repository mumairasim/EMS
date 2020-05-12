using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DTOs.DTOs
{
    public class Period : DtoBaseEntity
    {
        [StringLength(50)]
        public string PeriodNumber { get; set; }

        public TimeSpan? FromTime { get; set; }

        public TimeSpan? ToTime { get; set; }
    }
}
