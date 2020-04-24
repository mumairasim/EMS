using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    public partial class EmployeeFinanceDetail:BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmployeeFinanceDetail()
        {
            EmployeeFinances = new HashSet<EmployeeFinance>();
        }

        public int? EmployeeId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Salary { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeFinance> EmployeeFinances { get; set; }
    }
}
