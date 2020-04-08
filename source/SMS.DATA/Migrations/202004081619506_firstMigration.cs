namespace SMS.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignmentText = c.String(),
                        LastDateOfSubmission = c.DateTime(),
                        InstructorId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.ClassAssignement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(),
                        AssignmentId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
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
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassStudentDiary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentDiaryId = c.Int(),
                        ClassId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
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
                        Id = c.Int(nullable: false, identity: true),
                        DiaryText = c.String(),
                        DairyDate = c.DateTime(),
                        InstructorId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(),
                        DesignationId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designation", t => t.DesignationId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeFinanceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(),
                        Salary = c.Decimal(storeType: "money"),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeFinances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeFinanceDetailsId = c.Int(),
                        SalaryTransfered = c.Boolean(),
                        SalaryTransferDate = c.DateTime(),
                        SalaryMonth = c.String(maxLength: 250),
                        SalaryYear = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeFinanceDetails", t => t.EmployeeFinanceDetailsId)
                .Index(t => t.EmployeeFinanceDetailsId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 250),
                        LastName = c.String(maxLength: 250),
                        Cnic = c.String(maxLength: 50),
                        Nationality = c.String(maxLength: 250),
                        Religion = c.String(maxLength: 250),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                        Phone = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationNumber = c.String(nullable: false, maxLength: 50),
                        PersonId = c.Int(),
                        ClassId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Class", t => t.ClassId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.StudentAssignment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(),
                        AssignmentId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
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
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(),
                        Fee = c.Decimal(storeType: "money"),
                        FinanceTypeId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
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
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student_Finances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentFinanceDetailsId = c.Int(),
                        FeeSubmitted = c.Boolean(),
                        FeeSubmissionDate = c.DateTime(),
                        FeeMonth = c.String(maxLength: 250),
                        FeeYear = c.String(maxLength: 250),
                        LastDateSubmission = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentFinanceDetails", t => t.StudentFinanceDetailsId)
                .Index(t => t.StudentFinanceDetailsId);
            
            CreateTable(
                "dbo.StudentStudentDiary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentDiaryId = c.Int(),
                        StudentId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
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
                        Id = c.Int(nullable: false, identity: true),
                        DairyText = c.String(),
                        DairyDate = c.DateTime(),
                        InstructorId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.ClassTeacherDiary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherDiaryId = c.Int(),
                        ClassId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
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
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.String(maxLength: 50),
                        ClassId = c.Int(),
                        PeriodId = c.Int(),
                        TeacherId = c.Int(),
                        TimeTableId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
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
                        Id = c.Int(nullable: false, identity: true),
                        PeriodNumber = c.String(maxLength: 50),
                        FromTime = c.Time(precision: 7),
                        ToTime = c.Time(precision: 7),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeTableName = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Worksheet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ForDate = c.DateTime(),
                        InstructorId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.CourseClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(),
                        ClassId = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
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
                        Id = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false, maxLength: 50),
                        CourseName = c.String(nullable: false, maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LessonPlan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseClass", "CourseId", "dbo.Course");
            DropForeignKey("dbo.CourseClass", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Worksheet", "InstructorId", "dbo.Employee");
            DropForeignKey("dbo.TimeTableDetails", "TeacherId", "dbo.Employee");
            DropForeignKey("dbo.TimeTableDetails", "TimeTableId", "dbo.TimeTable");
            DropForeignKey("dbo.TimeTableDetails", "PeriodId", "dbo.Period");
            DropForeignKey("dbo.TimeTableDetails", "ClassId", "dbo.Class");
            DropForeignKey("dbo.TeacherDiary", "InstructorId", "dbo.Employee");
            DropForeignKey("dbo.ClassTeacherDiary", "TeacherDiaryId", "dbo.TeacherDiary");
            DropForeignKey("dbo.ClassTeacherDiary", "ClassId", "dbo.Class");
            DropForeignKey("dbo.StudentDiary", "InstructorId", "dbo.Employee");
            DropForeignKey("dbo.StudentStudentDiary", "StudentDiaryId", "dbo.StudentDiary");
            DropForeignKey("dbo.StudentStudentDiary", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student_Finances", "StudentFinanceDetailsId", "dbo.StudentFinanceDetails");
            DropForeignKey("dbo.StudentFinanceDetails", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentFinanceDetails", "FinanceTypeId", "dbo.FinanceTypes");
            DropForeignKey("dbo.StudentAssignment", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentAssignment", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.Student", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Student", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Employee", "PersonId", "dbo.Person");
            DropForeignKey("dbo.EmployeeFinances", "EmployeeFinanceDetailsId", "dbo.EmployeeFinanceDetails");
            DropForeignKey("dbo.EmployeeFinanceDetails", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "DesignationId", "dbo.Designation");
            DropForeignKey("dbo.Assignment", "InstructorId", "dbo.Employee");
            DropForeignKey("dbo.ClassStudentDiary", "StudentDiaryId", "dbo.StudentDiary");
            DropForeignKey("dbo.ClassStudentDiary", "ClassId", "dbo.Class");
            DropForeignKey("dbo.ClassAssignement", "ClassId", "dbo.Class");
            DropForeignKey("dbo.ClassAssignement", "AssignmentId", "dbo.Assignment");
            DropIndex("dbo.CourseClass", new[] { "ClassId" });
            DropIndex("dbo.CourseClass", new[] { "CourseId" });
            DropIndex("dbo.Worksheet", new[] { "InstructorId" });
            DropIndex("dbo.TimeTableDetails", new[] { "TimeTableId" });
            DropIndex("dbo.TimeTableDetails", new[] { "TeacherId" });
            DropIndex("dbo.TimeTableDetails", new[] { "PeriodId" });
            DropIndex("dbo.TimeTableDetails", new[] { "ClassId" });
            DropIndex("dbo.ClassTeacherDiary", new[] { "ClassId" });
            DropIndex("dbo.ClassTeacherDiary", new[] { "TeacherDiaryId" });
            DropIndex("dbo.TeacherDiary", new[] { "InstructorId" });
            DropIndex("dbo.StudentStudentDiary", new[] { "StudentId" });
            DropIndex("dbo.StudentStudentDiary", new[] { "StudentDiaryId" });
            DropIndex("dbo.Student_Finances", new[] { "StudentFinanceDetailsId" });
            DropIndex("dbo.StudentFinanceDetails", new[] { "FinanceTypeId" });
            DropIndex("dbo.StudentFinanceDetails", new[] { "StudentId" });
            DropIndex("dbo.StudentAssignment", new[] { "AssignmentId" });
            DropIndex("dbo.StudentAssignment", new[] { "StudentId" });
            DropIndex("dbo.Student", new[] { "ClassId" });
            DropIndex("dbo.Student", new[] { "PersonId" });
            DropIndex("dbo.EmployeeFinances", new[] { "EmployeeFinanceDetailsId" });
            DropIndex("dbo.EmployeeFinanceDetails", new[] { "EmployeeId" });
            DropIndex("dbo.Employee", new[] { "DesignationId" });
            DropIndex("dbo.Employee", new[] { "PersonId" });
            DropIndex("dbo.StudentDiary", new[] { "InstructorId" });
            DropIndex("dbo.ClassStudentDiary", new[] { "ClassId" });
            DropIndex("dbo.ClassStudentDiary", new[] { "StudentDiaryId" });
            DropIndex("dbo.ClassAssignement", new[] { "AssignmentId" });
            DropIndex("dbo.ClassAssignement", new[] { "ClassId" });
            DropIndex("dbo.Assignment", new[] { "InstructorId" });
            DropTable("dbo.sysdiagrams");
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
            DropTable("dbo.Person");
            DropTable("dbo.EmployeeFinances");
            DropTable("dbo.EmployeeFinanceDetails");
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
