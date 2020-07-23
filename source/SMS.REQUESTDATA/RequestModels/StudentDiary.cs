using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    [Table("StudentDiary")]
    public partial class StudentDiary : RequestBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentDiary()
        {
            ClassStudentDiaries = new HashSet<ClassStudentDiary>();
            StudentStudentDiaries = new HashSet<StudentStudentDiary>();
        }
        public string DiaryText { get; set; }

        public DateTime? DairyDate { get; set; }

        public Guid? InstructorId { get; set; }
        public Guid? SchoolId { get; set; }

        public virtual School School { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassStudentDiary> ClassStudentDiaries { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentStudentDiary> StudentStudentDiaries { get; set; }
    }
}
