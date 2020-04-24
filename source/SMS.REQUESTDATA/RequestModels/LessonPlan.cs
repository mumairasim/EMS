using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.REQUESTDATA.RequestModels
{
    [Table("LessonPlan")]
    public partial class LessonPlan:BaseEntity
    {
        public string Text { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int? SchoolId { get; set; }

        public int? RequestTypeId { get; set; }

        public virtual RequestType RequestType { get; set; }
        public virtual School School { get; set; }
    }
}
