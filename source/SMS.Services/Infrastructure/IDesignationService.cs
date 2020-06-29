using System;
using System.Collections.Generic;
using DTODesignation = SMS.DTOs.DTOs.Designation;
namespace SMS.Services.Infrastructure
{
    public interface IDesignationService
    {
        #region SMS Section
        List<DTODesignation> Get();
        DTODesignation Get(Guid? id);
        Guid Create(DTODesignation dtoDesignation);
        void Update(DTODesignation dtoDesignation);
        void Delete(Guid? id);
        #endregion

        #region SMS Request Section
        List<DTODesignation> RequestGet();
        DTODesignation RequestGet(Guid? id);
        Guid RequestCreate(DTODesignation dtoDesignation);
        void RequestUpdate(DTODesignation dtoDesignation);
        void RequestDelete(Guid? id);
        #endregion
    }
}
