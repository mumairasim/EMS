using System;
using System.Collections.Generic;
using DTODesignation = SMS.DTOs.DTOs.Designation;
namespace SMS.Services.Infrastructure
{
    public interface IDesignationService
    {
        List<DTODesignation> Get();
        DTODesignation Get(Guid? id);
        Guid Create(DTODesignation dtoDesignation);
        void Update(DTODesignation dtoDesignation);
        void Delete(Guid? id);
    }
}
