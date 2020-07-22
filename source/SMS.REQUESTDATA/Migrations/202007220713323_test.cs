namespace SMS.REQUESTDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.String(),
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
                "dbo.StudentAttendanceDetail",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AttendanceStatusId = c.Guid(),
                        StudentId = c.Guid(),
                        StudentAttendanceId = c.Guid(),
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
                .ForeignKey("dbo.AttendanceStatus", t => t.AttendanceStatusId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.StudentAttendance", t => t.StudentAttendanceId)
                .Index(t => t.AttendanceStatusId)
                .Index(t => t.StudentId)
                .Index(t => t.StudentAttendanceId);
            
            CreateTable(
                "dbo.StudentAttendance",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AttendanceDate = c.DateTime(nullable: false),
                        SchoolId = c.Guid(),
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
                .ForeignKey("dbo.Schools", t => t.SchoolId)
                .Index(t => t.SchoolId)
                .Index(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAttendanceDetail", "StudentAttendanceId", "dbo.StudentAttendance");
            DropForeignKey("dbo.StudentAttendance", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.StudentAttendance", "ClassId", "dbo.Class");
            DropForeignKey("dbo.StudentAttendanceDetail", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentAttendanceDetail", "AttendanceStatusId", "dbo.AttendanceStatus");
            DropIndex("dbo.StudentAttendance", new[] { "ClassId" });
            DropIndex("dbo.StudentAttendance", new[] { "SchoolId" });
            DropIndex("dbo.StudentAttendanceDetail", new[] { "StudentAttendanceId" });
            DropIndex("dbo.StudentAttendanceDetail", new[] { "StudentId" });
            DropIndex("dbo.StudentAttendanceDetail", new[] { "AttendanceStatusId" });
            DropTable("dbo.StudentAttendance");
            DropTable("dbo.StudentAttendanceDetail");
            DropTable("dbo.AttendanceStatus");
        }
    }
}
