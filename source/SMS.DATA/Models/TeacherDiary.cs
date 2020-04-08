using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
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

        public DateTime? DairyDate { get; set; }

        public int? InstructorId { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassTeacherDiary> ClassTeacherDiaries { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
