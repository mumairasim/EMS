using System.Linq;
using SMS.DATA.Infrastructure;
using SMS.REQUESTDATA.Infrastructure;
using SMS.Services.Infrastructure;
using Student = SMS.DATA.Models.Student;
using RequestStudent = SMS.REQUESTDATA.RequestModels.Student;

namespace SMS.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        private readonly IRequestRepository<RequestStudent> _requestRepository;
        public StudentService(IRepository<Student> repository, IRequestRepository<RequestStudent> requestRepository)
        {
            _repository = repository;
            _requestRepository = requestRepository;
        }
        public string Get()
        {
            var studentList = _repository.Get().ToList();
            var studentRequestList = _requestRepository.Get().ToList();
            return "Hello World";
        }
    }
}
