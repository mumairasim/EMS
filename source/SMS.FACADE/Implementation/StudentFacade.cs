using SMS.FACADE.Infrastructure;
using SMS.Services.Infrastructure;

namespace SMS.FACADE.Implementation
{
    public class StudentFacade : IStudentFacade
    {
        public IStudentService _studentService;
        public StudentFacade(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public string Test()
        {
            return _studentService.Get();
        }
    }
}
