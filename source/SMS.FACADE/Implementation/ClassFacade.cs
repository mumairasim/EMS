using System;
using System.Collections.Generic;
using DTOClass = SMS.DTOs.DTOs.Class;
using SMS.FACADE.Infrastructure;
using SMS.Services.Infrastructure;
using SMS.Services.Implementation;

namespace SMS.FACADE.Implementation
{
    public class ClassFacade : IClassFacade
    {
        public IClassService ClassService;
        public ClassFacade(IClassService classService)
        {
            ClassService = classService;
        }
        public List<DTOClass> Get()
        {
            return ClassService.Get();
        }
        public DTOClass Get(Guid id)
        {
            return ClassService.Get(id);
        }

        public void Create(DTOClass dtoClass)
        {
            ClassService.Create(dtoClass);
        }
        public void Update(DTOClass dtoClass)
        {
            ClassService.Update(dtoClass);
        }

        public void Delete(Guid? id)
        {
            ClassService.Delete(id);
        }

        public DTOClass Get(Guid? id)
        {
          return  ClassService.Get(id);
        }
    }
}
