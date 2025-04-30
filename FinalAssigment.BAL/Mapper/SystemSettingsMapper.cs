using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssignment.DAL.Entity;
using FinalAssignment.Shared.DTO;

namespace FinalAssignment.BAL.Mapper
{
    public static class SystemSettingsMapper
    {
        //ServiceRequests to ServiceRequestsDTO
        public static SystemSettingsDTO ToDTO(this SystemSettings systemSettings)
        {
            return new SystemSettingsDTO
            {
                Id = systemSettings.Id,
                ServiceFee = systemSettings.ServiceFee,
            };
        }

        //ServiceRequestsDTO to ServiceRequests
        public static SystemSettings ToEntity(this SystemSettingsDTO systemSettingsDTO)
        {
            return new SystemSettings
            {
                Id = systemSettingsDTO.Id,
                ServiceFee = systemSettingsDTO.ServiceFee,
            };
        }
    }
}
