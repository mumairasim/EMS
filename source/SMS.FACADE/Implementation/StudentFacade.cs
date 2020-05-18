using System;
using System.Collections.Generic;
using SMS.DTOs.DTOs;
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
        public StudentsList Get(int pageNumber, int pageSize)
        {
            return StudentService.Get(pageNumber, pageSize);
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
            StudentService.Delete(id, DeletedBy);
        }
    }
}
