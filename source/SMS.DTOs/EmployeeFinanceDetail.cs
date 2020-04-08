using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DTOs
{
    public class EmployeeFinanceDetail : DtoBaseEntity
    {
        public int? EmployeeId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Salary { get; set; }
    }
}
