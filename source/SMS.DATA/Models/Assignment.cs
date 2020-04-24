using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
{

    [Table("Assignment")]
    public partial class Assignment : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignment()
        {
            ClassAssignements = new HashSet<ClassAssignement>();
            StudentAssignments = new HashSet<StudentAssignment>();
        }

        public string AssignmentText { get; set; }

        public DateTime? LastDateOfSubmission { get; set; }

        public int? InstructorId { get; set; }
        public int? SchoolId { get; set; }

        public virtual School School { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassAssignement> ClassAssignements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}
