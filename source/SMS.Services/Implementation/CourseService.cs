using System.Linq;
using SMS.DATA.Infrastructure;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using Course = SMS.DATA.Models.Course;
using RequestCourse = SMS.REQUESTDATA.RequestModels.Course;

namespace SMS.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _repository;
        private readonly IRequestRepository<RequestCourse> _requestRepository;
        public CourseService(IRepository<Course> repository, IRequestRepository<RequestCourse> requestRepository)
        {
            _repository = repository;
            _requestRepository = requestRepository;
        }
        public string Get()
        {
            var courseList = _repository.Get().ToList();
            var courseRequestList = _requestRepository.Get().ToList();
            return "Hello World";
        }
    }
}