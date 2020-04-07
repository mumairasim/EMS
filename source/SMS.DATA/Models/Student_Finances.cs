namespace SMS.DATA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student_Finances
    {
        public int Id { get; set; }

        public int? StudentFinanceDetailsId { get; set; }

        public bool? FeeSubmitted { get; set; }

        public DateTime? FeeSubmissionDate { get; set; }

        [StringLength(250)]
        public string FeeMonth { get; set; }

        [StringLength(250)]
        public string FeeYear { get; set; }

        public DateTime? LastDateSubmission { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public int? DeletedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual StudentFinanceDetail StudentFinanceDetail { get; set; }
    }
}
