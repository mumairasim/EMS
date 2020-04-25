using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    public partial class StudentFinanceDetail:BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentFinanceDetail()
        {
            Student_Finances = new HashSet<Student_Finances>();
        }

        public int? StudentId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Fee { get; set; }

        public int? FinanceTypeId { get; set; }

        public virtual FinanceType FinanceType { get; set; }

        public virtual Student Student { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Finances> Student_Finances { get; set; }
    }
}
