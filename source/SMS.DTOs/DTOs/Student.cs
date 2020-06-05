using System;

namespace SMS.DTOs.DTOs
{
    public class Student : DtoBaseEntity
    {
        public int? RegistrationNumber { get; set; }

        public Guid? PersonId { get; set; }
        public Guid? ImageId { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? SchoolId { get; set; }
        public Person Person { get; set; }
        public File Image { get; set; }
        public Class Class { get; set; }
        public School School { get; set; }
        public string PreviousSchoolName { get; set; }
        public string ReasonForLeaving { get; set; }

        
    }
}
