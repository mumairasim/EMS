using System;

namespace SMS.DTOs.DTOs
{
    public class StudentAttendance : DtoBaseEntity
    {
        public Guid? SchoolId { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? AttendanceStatusId { get; set; }
        public Guid? StudentId { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
        public Student Student { get; set; }
        public Class Class { get; set; }
        public School School { get; set; }
    }
}
