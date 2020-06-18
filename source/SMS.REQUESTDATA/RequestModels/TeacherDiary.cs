using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    [Table("TeacherDiary")]
    public partial class TeacherDiary : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TeacherDiary()
        {
            ClassTeacherDiaries = new HashSet<ClassTeacherDiary>();
        }
        public string DairyText { get; set; }
        public string Name { get; set; }

        public DateTime? DairyDate { get; set; }

        public Guid? InstructorId { get; set; }
        public Guid? SchoolId { get; set; }

        public virtual School School { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassTeacherDiary> ClassTeacherDiaries { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
