namespace SMS.DATA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TimeTableDetail
    {
        public int Id { get; set; }

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
