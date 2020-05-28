using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.DATA.Models
{
    [Table("StudentAttendance")]
    public partial class StudentAttendance : BaseEntity
    {
        public Guid? SchoolId { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? AttendanceStatusId { get; set; }
        public Guid? StudentId { get; set; }
        public virtual AttendanceStatus AttendanceStatus { get; set; }
        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }
        public virtual School School { get; set; }

    }
}
