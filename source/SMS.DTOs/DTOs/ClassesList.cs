using System.Collections.Generic;

namespace SMS.DTOs.DTOs
{
    public class ClassesList
    {
        public List<Class> Classes { get; set; }
        public int classesCount { get; set; }
    }

    public class CoursesList
    {
        public List<Course> Courses { get; set; }
        public int Count { get; set; }
    }
}
