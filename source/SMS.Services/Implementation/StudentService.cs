using System.Collections.Generic;
using System.Linq;
using SMS.DATA.Infrastructure;
using SMS.DATA.Models;
using SMS.Services.Infrastructure;

namespace SMS.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public string Get()
        {
            var studentList = _repository.Get().ToList();
            return "Hello World";
        }
    }
}
