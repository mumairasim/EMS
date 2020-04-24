using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.REQUESTDATA.RequestModels
{
    public partial class Student_Finances:BaseEntity
    {
        public int? StudentFinanceDetailsId { get; set; }

        public bool? FeeSubmitted { get; set; }

        public DateTime? FeeSubmissionDate { get; set; }

        [StringLength(250)]
        public string FeeMonth { get; set; }

        [StringLength(250)]
        public string FeeYear { get; set; }

        public DateTime? LastDateSubmission { get; set; }

        public virtual StudentFinanceDetail StudentFinanceDetail { get; set; }
    }
}
