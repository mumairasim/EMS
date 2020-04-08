using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
{
    [Table("Employee")]
    public partial class Employee : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Assignments = new HashSet<Assignment>();
            EmployeeFinanceDetails = new HashSet<EmployeeFinanceDetail>();
            StudentDiaries = new HashSet<StudentDiary>();
            TeacherDiaries = new HashSet<TeacherDiary>();
            TimeTableDetails = new HashSet<TimeTableDetail>();
            Worksheets = new HashSet<Worksheet>();
        }


        public int? PersonId { get; set; }

        public int? DesignationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual Designation Designation { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeFinanceDetail> EmployeeFinanceDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentDiary> StudentDiaries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherDiary> TeacherDiaries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeTableDetail> TimeTableDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Worksheet> Worksheets { get; set; }
    }
}
