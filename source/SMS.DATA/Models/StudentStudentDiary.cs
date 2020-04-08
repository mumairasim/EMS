using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
{
    [Table("StudentStudentDiary")]
    public partial class StudentStudentDiary : BaseEntity
    {
        public int? StudentDiaryId { get; set; }

        public int? StudentId { get; set; }

        public virtual Student Student { get; set; }

        public virtual StudentDiary StudentDiary { get; set; }
    }
}
