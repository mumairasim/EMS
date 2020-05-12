using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    [Table("ClassTeacherDiary")]
    public partial class ClassTeacherDiary : BaseEntity
    {
        public Guid? TeacherDiaryId { get; set; }

        public Guid? ClassId { get; set; }

        public virtual Class Class { get; set; }

        public virtual TeacherDiary TeacherDiary { get; set; }
    }
}
