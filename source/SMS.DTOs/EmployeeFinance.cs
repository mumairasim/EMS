using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.DTOs
{
    public class EmployeeFinance : DtoBaseEntity
    {
        public int? EmployeeFinanceDetailsId { get; set; }

        public bool? SalaryTransfered { get; set; }

        public DateTime? SalaryTransferDate { get; set; }

        [StringLength(250)]
        public string SalaryMonth { get; set; }

        [StringLength(250)]
        public string SalaryYear { get; set; }
    }
}
