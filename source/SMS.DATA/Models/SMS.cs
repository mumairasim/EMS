namespace SMS.DATA.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SMS : DbContext
    {
        public SMS()
            : base("name=SMS")
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassAssignement> ClassAssignements { get; set; }
        public virtual DbSet<ClassStudentDiary> ClassStudentDiaries { get; set; }
        public virtual DbSet<ClassTeacherDiary> ClassTeacherDiaries { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseClass> CourseClasses { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeFinanceDetail> EmployeeFinanceDetails { get; set; }
        public virtual DbSet<EmployeeFinance> EmployeeFinances { get; set; }
        public virtual DbSet<FinanceType> FinanceTypes { get; set; }
        public virtual DbSet<LessonPlan> LessonPlans { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Student_Finances> Student_Finances { get; set; }
        public virtual DbSet<StudentAssignment> StudentAssignments { get; set; }
        public virtual DbSet<StudentDiary> StudentDiaries { get; set; }
        public virtual DbSet<StudentFinanceDetail> StudentFinanceDetails { get; set; }
        public virtual DbSet<StudentStudentDiary> StudentStudentDiaries { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TeacherDiary> TeacherDiaries { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }
        public virtual DbSet<TimeTableDetail> TimeTableDetails { get; set; }
        public virtual DbSet<Worksheet> Worksheets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Assignments)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.InstructorId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.StudentDiaries)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.InstructorId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.TeacherDiaries)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.InstructorId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.TimeTableDetails)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.TeacherId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Worksheets)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.InstructorId);

            modelBuilder.Entity<EmployeeFinanceDetail>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EmployeeFinanceDetail>()
                .HasMany(e => e.EmployeeFinances)
                .WithOptional(e => e.EmployeeFinanceDetail)
                .HasForeignKey(e => e.EmployeeFinanceDetailsId);

            modelBuilder.Entity<StudentFinanceDetail>()
                .Property(e => e.Fee)
                .HasPrecision(19, 4);

            modelBuilder.Entity<StudentFinanceDetail>()
                .HasMany(e => e.Student_Finances)
                .WithOptional(e => e.StudentFinanceDetail)
                .HasForeignKey(e => e.StudentFinanceDetailsId);
        }
    }
}
