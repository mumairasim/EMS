namespace SMS.REQUESTDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requestRelationshipcreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentDiary", "SchoolId", c => c.Int());
            AddColumn("dbo.StudentDiary", "RequestTypeId", c => c.Int());
            AddColumn("dbo.TeacherDiary", "SchoolId", c => c.Int());
            AddColumn("dbo.TeacherDiary", "RequestTypeId", c => c.Int());
            CreateIndex("dbo.Assignment", "RequestTypeId");
            CreateIndex("dbo.Class", "RequestTypeId");
            CreateIndex("dbo.StudentDiary", "SchoolId");
            CreateIndex("dbo.StudentDiary", "RequestTypeId");
            CreateIndex("dbo.Employee", "RequestTypeId");
            CreateIndex("dbo.Designation", "RequestTypeId");
            CreateIndex("dbo.Course", "RequestTypeId");
            CreateIndex("dbo.LessonPlan", "RequestTypeId");
            CreateIndex("dbo.Period", "RequestTypeId");
            CreateIndex("dbo.TimeTable", "RequestTypeId");
            CreateIndex("dbo.Student", "RequestTypeId");
            CreateIndex("dbo.Worksheet", "RequestTypeId");
            CreateIndex("dbo.TeacherDiary", "SchoolId");
            CreateIndex("dbo.TeacherDiary", "RequestTypeId");
            AddForeignKey("dbo.Designation", "RequestTypeId", "dbo.RequestType", "Id");
            AddForeignKey("dbo.Course", "RequestTypeId", "dbo.RequestType", "Id");
            AddForeignKey("dbo.LessonPlan", "RequestTypeId", "dbo.RequestType", "Id");
            AddForeignKey("dbo.Period", "RequestTypeId", "dbo.RequestType", "Id");
            AddForeignKey("dbo.TimeTable", "RequestTypeId", "dbo.RequestType", "Id");
            AddForeignKey("dbo.Student", "RequestTypeId", "dbo.RequestType", "Id");
            AddForeignKey("dbo.Worksheet", "RequestTypeId", "dbo.RequestType", "Id");
            AddForeignKey("dbo.Employee", "RequestTypeId", "dbo.RequestType", "Id");
            AddForeignKey("dbo.TeacherDiary", "RequestTypeId", "dbo.RequestType", "Id");
            AddForeignKey("dbo.TeacherDiary", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.StudentDiary", "RequestTypeId", "dbo.RequestType", "Id");
            AddForeignKey("dbo.StudentDiary", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.Class", "RequestTypeId", "dbo.RequestType", "Id");
            AddForeignKey("dbo.Assignment", "RequestTypeId", "dbo.RequestType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignment", "RequestTypeId", "dbo.RequestType");
            DropForeignKey("dbo.Class", "RequestTypeId", "dbo.RequestType");
            DropForeignKey("dbo.StudentDiary", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.StudentDiary", "RequestTypeId", "dbo.RequestType");
            DropForeignKey("dbo.TeacherDiary", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.TeacherDiary", "RequestTypeId", "dbo.RequestType");
            DropForeignKey("dbo.Employee", "RequestTypeId", "dbo.RequestType");
            DropForeignKey("dbo.Worksheet", "RequestTypeId", "dbo.RequestType");
            DropForeignKey("dbo.Student", "RequestTypeId", "dbo.RequestType");
            DropForeignKey("dbo.TimeTable", "RequestTypeId", "dbo.RequestType");
            DropForeignKey("dbo.Period", "RequestTypeId", "dbo.RequestType");
            DropForeignKey("dbo.LessonPlan", "RequestTypeId", "dbo.RequestType");
            DropForeignKey("dbo.Course", "RequestTypeId", "dbo.RequestType");
            DropForeignKey("dbo.Designation", "RequestTypeId", "dbo.RequestType");
            DropIndex("dbo.TeacherDiary", new[] { "RequestTypeId" });
            DropIndex("dbo.TeacherDiary", new[] { "SchoolId" });
            DropIndex("dbo.Worksheet", new[] { "RequestTypeId" });
            DropIndex("dbo.Student", new[] { "RequestTypeId" });
            DropIndex("dbo.TimeTable", new[] { "RequestTypeId" });
            DropIndex("dbo.Period", new[] { "RequestTypeId" });
            DropIndex("dbo.LessonPlan", new[] { "RequestTypeId" });
            DropIndex("dbo.Course", new[] { "RequestTypeId" });
            DropIndex("dbo.Designation", new[] { "RequestTypeId" });
            DropIndex("dbo.Employee", new[] { "RequestTypeId" });
            DropIndex("dbo.StudentDiary", new[] { "RequestTypeId" });
            DropIndex("dbo.StudentDiary", new[] { "SchoolId" });
            DropIndex("dbo.Class", new[] { "RequestTypeId" });
            DropIndex("dbo.Assignment", new[] { "RequestTypeId" });
            DropColumn("dbo.TeacherDiary", "RequestTypeId");
            DropColumn("dbo.TeacherDiary", "SchoolId");
            DropColumn("dbo.StudentDiary", "RequestTypeId");
            DropColumn("dbo.StudentDiary", "SchoolId");
        }
    }
}
