﻿using System;

namespace SMS.DATA.Models.NonDbContextModels
{
    public class StudentFinanceInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string SchoolName { get; set; }
        public string ClassName { get; set; }
        public string FeeMonth { get; set; }
        public string FeeYear { get; set; }
        public bool FeeSubmitted { get; set; }
        public Guid StudentId { get; set; }
        public Guid? StudentFinanceDetailsId { get; set; }
    }
}