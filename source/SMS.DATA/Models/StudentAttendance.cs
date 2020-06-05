using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
{
    [Table("StudentAttendance")]
    public partial class StudentAttendance : BaseEntity
    {
        public DateTime AttendanceDate { get; set; }
        public Guid? SchoolId { get; set; }
        public Guid? ClassId { get; set; }
        public virtual Class Class { get; set; }
        public virtual School School { get; set; }

    }
}
