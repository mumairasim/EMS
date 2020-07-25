using SMS.DTOs.ReponseDTOs;
using System;
using System.Collections.Generic;
using SMS.DTOs.DTOs;
using DTOWorksheet = SMS.DTOs.DTOs.Worksheet;
namespace SMS.Services.Infrastructure
{
    public interface IRequestManagementService
    {
        IEnumerable<CommonRequestModel> GetAllRequests();
    }
}
