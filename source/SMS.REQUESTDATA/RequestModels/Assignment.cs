using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
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

        public Guid? InstructorId { get; set; }

        public Guid? SchoolId { get; set; }

        public Guid? RequestTypeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual School School { get; set; }
        public virtual RequestType RequestType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassAssignement> ClassAssignements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}
