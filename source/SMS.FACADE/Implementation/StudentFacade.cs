using System;
using System.Collections.Generic;
using DTOStudent = SMS.DTOs.DTOs.Student;
using SMS.FACADE.Infrastructure;
using SMS.Services.Infrastructure;


namespace SMS.FACADE.Implementation
{
    public class StudentFacade : IStudentFacade
    {
        public IStudentService StudentService;
        public StudentFacade(IStudentService studentService)
        {
            StudentService = studentService;
        }
        public List<DTOStudent> Get()
        {
            return StudentService.Get();
        }
        public DTOStudent Get(Guid id)
        {
            return StudentService.Get(id);
        }

        public void Create(DTOStudent dtoStudent)
        {
            StudentService.Create(dtoStudent);
        }
        public void Update(DTOStudent dtoStudent)
        {
            StudentService.Update(dtoStudent);
        }

        public void Delete(Guid? id, string DeletedBy)
        {
            StudentService.Delete(id,DeletedBy);
        }
    }
}
