using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    [Table("ClassTeacherDiary")]
    public partial class ClassTeacherDiary:BaseEntity
    {
        public int? TeacherDiaryId { get; set; }

        public int? ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual TeacherDiary TeacherDiary { get; set; }
    }
}
