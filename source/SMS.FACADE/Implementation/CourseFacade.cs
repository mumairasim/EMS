using SMS.FACADE.Infrastructure;
using SMS.Services.Infrastructure;

namespace SMS.FACADE.Implementation
{
    public class CourseFacade : ICourseFacade
    {
        public ICourseService _courseService;
        public CourseFacade(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public string Test()
        {
            return _courseService.Get();
        }
    }
}