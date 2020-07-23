namespace SMS.REQUESTDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AssignmentText = c.String(),
                        LastDateOfSubmission = c.DateTime(),
                        InstructorId = c.Guid(),
                        SchoolId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.InstructorId)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.InstructorId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.ClassAssignement",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClassId = c.Guid(),
                        AssignmentId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assignment", t => t.AssignmentId)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .Index(t => t.ClassId)
                .Index(t => t.AssignmentId);
            
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClassName = c.String(nullable: false, maxLength: 50),
                        SchoolId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.ClassStudentDiary",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentDiaryId = c.Guid(),
                        ClassId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.StudentDiary", t => t.StudentDiaryId)
                .Index(t => t.StudentDiaryId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.StudentDiary",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DiaryText = c.String(),
                        DairyDate = c.DateTime(),
                        InstructorId = c.Guid(),
                        SchoolId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.InstructorId)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.InstructorId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployeeNumber = c.Int(nullable: false, identity: true),
                        PersonId = c.Guid(),
                        DesignationId = c.Guid(),
                        SchoolId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designation", t => t.DesignationId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.PersonId)
                .Index(t => t.DesignationId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        SchoolId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Location = c.String(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeFinanceDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployeeId = c.Guid(),
                        Salary = c.Decimal(storeType: "money"),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeFinances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployeeFinanceDetailsId = c.Guid(),
                        SalaryTransfered = c.Boolean(),
                        SalaryTransferDate = c.DateTime(),
                        SalaryMonth = c.String(maxLength: 250),
                        SalaryYear = c.String(maxLength: 250),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeFinanceDetails", t => t.EmployeeFinanceDetailsId)
                .Index(t => t.EmployeeFinanceDetailsId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AspNetUserId = c.Guid(),
                        Age = c.Int(),
                        FirstName = c.String(maxLength: 250),
                        LastName = c.String(maxLength: 250),
                        ParentName = c.String(),
                        Cnic = c.String(maxLength: 50),
                        ParentCnic = c.String(),
                        DOB = c.DateTime(),
                        Nationality = c.String(maxLength: 250),
                        Religion = c.String(maxLength: 250),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                        ParentOccupation = c.String(),
                        ParentRelation = c.String(),
                        ParentHighestEducation = c.String(),
                        ParentNationality = c.String(),
                        ParentEmail = c.String(),
                        ParentOfficeAddress = c.String(),
                        ParentCity = c.String(),
                        ParentMobile1 = c.String(),
                        ParentMobile2 = c.String(),
                        ParentEmergencyName = c.String(),
                        ParentEmergencyRelation = c.String(),
                        ParentEmergencyMobile = c.String(),
                        ImageId = c.Guid(),
                        Phone = c.String(maxLength: 50),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Path = c.String(),
                        Size = c.Int(nullable: false),
                        Extension = c.String(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RegistrationNumber = c.Int(nullable: false, identity: true),
                        PersonId = c.Guid(),
                        ClassId = c.Guid(),
                        ImageId = c.Guid(),
                        SchoolId = c.Guid(),
                        PreviousSchoolName = c.String(),
                        ReasonForLeaving = c.String(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.Files", t => t.ImageId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.PersonId)
                .Index(t => t.ClassId)
                .Index(t => t.ImageId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.StudentAssignment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(),
                        AssignmentId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assignment", t => t.AssignmentId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.AssignmentId);
            
            CreateTable(
                "dbo.StudentFinanceDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentId = c.Guid(),
                        Fee = c.Decimal(storeType: "money"),
                        FinanceTypeId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FinanceTypes", t => t.FinanceTypeId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.FinanceTypeId);
            
            CreateTable(
                "dbo.FinanceTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(maxLength: 500),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student_Finances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentFinanceDetailsId = c.Guid(),
                        FeeSubmitted = c.Boolean(),
                        FeeSubmissionDate = c.DateTime(),
                        FeeMonth = c.String(maxLength: 250),
                        FeeYear = c.String(maxLength: 250),
                        LastDateSubmission = c.DateTime(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentFinanceDetails", t => t.StudentFinanceDetailsId)
                .Index(t => t.StudentFinanceDetailsId);
            
            CreateTable(
                "dbo.StudentStudentDiary",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StudentDiaryId = c.Guid(),
                        StudentId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.StudentDiary", t => t.StudentDiaryId)
                .Index(t => t.StudentDiaryId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.TeacherDiary",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DairyText = c.String(),
                        Name = c.String(),
                        DairyDate = c.DateTime(),
                        InstructorId = c.Guid(),
                        SchoolId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .ForeignKey("dbo.Employee", t => t.InstructorId)
                .Index(t => t.InstructorId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.ClassTeacherDiary",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TeacherDiaryId = c.Guid(),
                        ClassId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.TeacherDiary", t => t.TeacherDiaryId)
                .Index(t => t.TeacherDiaryId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.TimeTableDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Day = c.String(maxLength: 50),
                        ClassId = c.Guid(),
                        PeriodId = c.Guid(),
                        TeacherId = c.Guid(),
                        TimeTableId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.Period", t => t.PeriodId)
                .ForeignKey("dbo.TimeTable", t => t.TimeTableId)
                .ForeignKey("dbo.Employee", t => t.TeacherId)
                .Index(t => t.ClassId)
                .Index(t => t.PeriodId)
                .Index(t => t.TeacherId)
                .Index(t => t.TimeTableId);
            
            CreateTable(
                "dbo.Period",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PeriodNumber = c.String(maxLength: 50),
                        FromTime = c.Time(precision: 7),
                        ToTime = c.Time(precision: 7),
                        SchoolId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.TimeTable",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TimeTableName = c.String(maxLength: 500),
                        SchoolId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Worksheet",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(),
                        ForDate = c.DateTime(),
                        InstructorId = c.Guid(),
                        SchoolId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .ForeignKey("dbo.Employee", t => t.InstructorId)
                .Index(t => t.InstructorId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.CourseClass",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourseId = c.Guid(),
                        ClassId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CourseCode = c.String(nullable: false, maxLength: 50),
                        CourseName = c.String(nullable: false, maxLength: 250),
                        SchoolId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.LessonPlan",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(),
                        Name = c.String(),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        SchoolId = c.Guid(),
                        RequestStatusId = c.Guid(),
                        RequestTypeId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.RequestStatuses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Guid(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Guid(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Guid(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonPlan", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Assignment", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Class", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Course", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.CourseClass", "CourseId", "dbo.Course");
            DropForeignKey("dbo.CourseClass", "ClassId", "dbo.Class");
            DropForeignKey("dbo.StudentDiary", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Worksheet", "InstructorId", "dbo.Employee");
            DropForeignKey("dbo.Worksheet", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.TimeTableDetails", "TeacherId", "dbo.Employee");
            DropForeignKey("dbo.TimeTableDetails", "TimeTableId", "dbo.TimeTable");
            DropForeignKey("dbo.TimeTable", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.TimeTableDetails", "PeriodId", "dbo.Period");
            DropForeignKey("dbo.Period", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.TimeTableDetails", "ClassId", "dbo.Class");
            DropForeignKey("dbo.TeacherDiary", "InstructorId", "dbo.Employee");
            DropForeignKey("dbo.TeacherDiary", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.ClassTeacherDiary", "TeacherDiaryId", "dbo.TeacherDiary");
            DropForeignKey("dbo.ClassTeacherDiary", "ClassId", "dbo.Class");
            DropForeignKey("dbo.StudentDiary", "InstructorId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.StudentStudentDiary", "StudentDiaryId", "dbo.StudentDiary");
            DropForeignKey("dbo.StudentStudentDiary", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student_Finances", "StudentFinanceDetailsId", "dbo.StudentFinanceDetails");
            DropForeignKey("dbo.StudentFinanceDetails", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentFinanceDetails", "FinanceTypeId", "dbo.FinanceTypes");
            DropForeignKey("dbo.StudentAssignment", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentAssignment", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.Student", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Student", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Student", "ImageId", "dbo.Files");
            DropForeignKey("dbo.Student", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Person", "ImageId", "dbo.Files");
            DropForeignKey("dbo.Employee", "PersonId", "dbo.Person");
            DropForeignKey("dbo.EmployeeFinances", "EmployeeFinanceDetailsId", "dbo.EmployeeFinanceDetails");
            DropForeignKey("dbo.EmployeeFinanceDetails", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Designation", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Employee", "DesignationId", "dbo.Designation");
            DropForeignKey("dbo.Assignment", "InstructorId", "dbo.Employee");
            DropForeignKey("dbo.ClassStudentDiary", "StudentDiaryId", "dbo.StudentDiary");
            DropForeignKey("dbo.ClassStudentDiary", "ClassId", "dbo.Class");
            DropForeignKey("dbo.ClassAssignement", "ClassId", "dbo.Class");
            DropForeignKey("dbo.ClassAssignement", "AssignmentId", "dbo.Assignment");
            DropIndex("dbo.LessonPlan", new[] { "SchoolId" });
            DropIndex("dbo.Course", new[] { "SchoolId" });
            DropIndex("dbo.CourseClass", new[] { "ClassId" });
            DropIndex("dbo.CourseClass", new[] { "CourseId" });
            DropIndex("dbo.Worksheet", new[] { "SchoolId" });
            DropIndex("dbo.Worksheet", new[] { "InstructorId" });
            DropIndex("dbo.TimeTable", new[] { "SchoolId" });
            DropIndex("dbo.Period", new[] { "SchoolId" });
            DropIndex("dbo.TimeTableDetails", new[] { "TimeTableId" });
            DropIndex("dbo.TimeTableDetails", new[] { "TeacherId" });
            DropIndex("dbo.TimeTableDetails", new[] { "PeriodId" });
            DropIndex("dbo.TimeTableDetails", new[] { "ClassId" });
            DropIndex("dbo.ClassTeacherDiary", new[] { "ClassId" });
            DropIndex("dbo.ClassTeacherDiary", new[] { "TeacherDiaryId" });
            DropIndex("dbo.TeacherDiary", new[] { "SchoolId" });
            DropIndex("dbo.TeacherDiary", new[] { "InstructorId" });
            DropIndex("dbo.StudentStudentDiary", new[] { "StudentId" });
            DropIndex("dbo.StudentStudentDiary", new[] { "StudentDiaryId" });
            DropIndex("dbo.Student_Finances", new[] { "StudentFinanceDetailsId" });
            DropIndex("dbo.StudentFinanceDetails", new[] { "FinanceTypeId" });
            DropIndex("dbo.StudentFinanceDetails", new[] { "StudentId" });
            DropIndex("dbo.StudentAssignment", new[] { "AssignmentId" });
            DropIndex("dbo.StudentAssignment", new[] { "StudentId" });
            DropIndex("dbo.Student", new[] { "SchoolId" });
            DropIndex("dbo.Student", new[] { "ImageId" });
            DropIndex("dbo.Student", new[] { "ClassId" });
            DropIndex("dbo.Student", new[] { "PersonId" });
            DropIndex("dbo.Person", new[] { "ImageId" });
            DropIndex("dbo.EmployeeFinances", new[] { "EmployeeFinanceDetailsId" });
            DropIndex("dbo.EmployeeFinanceDetails", new[] { "EmployeeId" });
            DropIndex("dbo.Designation", new[] { "SchoolId" });
            DropIndex("dbo.Employee", new[] { "SchoolId" });
            DropIndex("dbo.Employee", new[] { "DesignationId" });
            DropIndex("dbo.Employee", new[] { "PersonId" });
            DropIndex("dbo.StudentDiary", new[] { "SchoolId" });
            DropIndex("dbo.StudentDiary", new[] { "InstructorId" });
            DropIndex("dbo.ClassStudentDiary", new[] { "ClassId" });
            DropIndex("dbo.ClassStudentDiary", new[] { "StudentDiaryId" });
            DropIndex("dbo.Class", new[] { "SchoolId" });
            DropIndex("dbo.ClassAssignement", new[] { "AssignmentId" });
            DropIndex("dbo.ClassAssignement", new[] { "ClassId" });
            DropIndex("dbo.Assignment", new[] { "SchoolId" });
            DropIndex("dbo.Assignment", new[] { "InstructorId" });
            DropTable("dbo.RequestType");
            DropTable("dbo.RequestStatuses");
            DropTable("dbo.LessonPlan");
            DropTable("dbo.Course");
            DropTable("dbo.CourseClass");
            DropTable("dbo.Worksheet");
            DropTable("dbo.TimeTable");
            DropTable("dbo.Period");
            DropTable("dbo.TimeTableDetails");
            DropTable("dbo.ClassTeacherDiary");
            DropTable("dbo.TeacherDiary");
            DropTable("dbo.StudentStudentDiary");
            DropTable("dbo.Student_Finances");
            DropTable("dbo.FinanceTypes");
            DropTable("dbo.StudentFinanceDetails");
            DropTable("dbo.StudentAssignment");
            DropTable("dbo.Student");
            DropTable("dbo.Files");
            DropTable("dbo.Person");
            DropTable("dbo.EmployeeFinances");
            DropTable("dbo.EmployeeFinanceDetails");
            DropTable("dbo.Schools");
            DropTable("dbo.Designation");
            DropTable("dbo.Employee");
            DropTable("dbo.StudentDiary");
            DropTable("dbo.ClassStudentDiary");
            DropTable("dbo.Class");
            DropTable("dbo.ClassAssignement");
            DropTable("dbo.Assignment");
        }
    }
}
