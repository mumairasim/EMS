namespace SMS.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schoolentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedBy = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Assignment", "SchoolId", c => c.Int());
            AddColumn("dbo.Class", "SchoolId", c => c.Int());
            AddColumn("dbo.Employee", "SchoolId", c => c.Int());
            AddColumn("dbo.Designation", "SchoolId", c => c.Int());
            AddColumn("dbo.Student", "SchoolId", c => c.Int());
            AddColumn("dbo.Period", "SchoolId", c => c.Int());
            AddColumn("dbo.TimeTable", "SchoolId", c => c.Int());
            AddColumn("dbo.Worksheet", "SchoolId", c => c.Int());
            AddColumn("dbo.Course", "SchoolId", c => c.Int());
            AddColumn("dbo.LessonPlan", "SchoolId", c => c.Int());
            CreateIndex("dbo.Assignment", "SchoolId");
            CreateIndex("dbo.Class", "SchoolId");
            CreateIndex("dbo.Employee", "SchoolId");
            CreateIndex("dbo.Designation", "SchoolId");
            CreateIndex("dbo.Student", "SchoolId");
            CreateIndex("dbo.Period", "SchoolId");
            CreateIndex("dbo.TimeTable", "SchoolId");
            CreateIndex("dbo.Worksheet", "SchoolId");
            CreateIndex("dbo.Course", "SchoolId");
            CreateIndex("dbo.LessonPlan", "SchoolId");
            AddForeignKey("dbo.Designation", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.Student", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.Employee", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.Period", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.TimeTable", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.Worksheet", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.Course", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.Class", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.Assignment", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.LessonPlan", "SchoolId", "dbo.Schools", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonPlan", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Assignment", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Class", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Course", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Worksheet", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.TimeTable", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Period", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Employee", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Student", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Designation", "SchoolId", "dbo.Schools");
            DropIndex("dbo.LessonPlan", new[] { "SchoolId" });
            DropIndex("dbo.Course", new[] { "SchoolId" });
            DropIndex("dbo.Worksheet", new[] { "SchoolId" });
            DropIndex("dbo.TimeTable", new[] { "SchoolId" });
            DropIndex("dbo.Period", new[] { "SchoolId" });
            DropIndex("dbo.Student", new[] { "SchoolId" });
            DropIndex("dbo.Designation", new[] { "SchoolId" });
            DropIndex("dbo.Employee", new[] { "SchoolId" });
            DropIndex("dbo.Class", new[] { "SchoolId" });
            DropIndex("dbo.Assignment", new[] { "SchoolId" });
            DropColumn("dbo.LessonPlan", "SchoolId");
            DropColumn("dbo.Course", "SchoolId");
            DropColumn("dbo.Worksheet", "SchoolId");
            DropColumn("dbo.TimeTable", "SchoolId");
            DropColumn("dbo.Period", "SchoolId");
            DropColumn("dbo.Student", "SchoolId");
            DropColumn("dbo.Designation", "SchoolId");
            DropColumn("dbo.Employee", "SchoolId");
            DropColumn("dbo.Class", "SchoolId");
            DropColumn("dbo.Assignment", "SchoolId");
            DropTable("dbo.Schools");
        }
    }
}
