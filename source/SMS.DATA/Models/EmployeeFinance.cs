namespace SMS.DATA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeFinance
    {
        public int Id { get; set; }

        public int? EmployeeFinanceDetailsId { get; set; }

        public bool? SalaryTransfered { get; set; }

        public DateTime? SalaryTransferDate { get; set; }

        [StringLength(250)]
        public string SalaryMonth { get; set; }

        [StringLength(250)]
        public string SalaryYear { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public int? DeletedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual EmployeeFinanceDetail EmployeeFinanceDetail { get; set; }
    }
}
