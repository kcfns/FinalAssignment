using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssignment.DAL.Entity;
using FinalAssignment.Shared.DTO;

namespace FinalAssignment.BAL.Mapper
{
    public static class ServiceRequestsMapper
    {
        //ServiceRequests to ServiceRequestsDTO
        public static ServiceRequestsDTO ToDTO(this ServiceRequests servicePart)
        {
            return new ServiceRequestsDTO
            {
                Id = servicePart.Id,
                BikeId = servicePart.BikeId,
                RequestDate = servicePart.RequestDate,
                ServiceType = servicePart.ServiceType,
                Status = servicePart.Status,
                Remarks = servicePart.Remarks,
                ServiceDate = servicePart.ServiceDate,
            };
        }

        //ServiceRequestsDTO to ServiceRequests
        public static ServiceRequests ToEntity(this ServiceRequestsDTO servicePartDTO)
        {
            return new ServiceRequests
            {
                Id = servicePartDTO.Id,
                BikeId = servicePartDTO.BikeId,
                RequestDate = servicePartDTO.RequestDate,
                ServiceType = servicePartDTO.ServiceType,
                Status = servicePartDTO.Status,
                Remarks = servicePartDTO.Remarks,
                ServiceDate = servicePartDTO.ServiceDate,
            };
        }
    }
}
