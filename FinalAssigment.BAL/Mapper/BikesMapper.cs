using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssignment.DAL.Entity;
using FinalAssignment.Shared.DTO;

namespace FinalAssignment.BAL.Mapper
{
    public static class BikesMapper
    {
        //Bikes to BikeDTO
        public static BikesDTO ToDTO(this Bikes bikes)
        {
            return new BikesDTO
            {
                Id = bikes.Id,
                UserId = bikes.UserId,
                BikeNumber = bikes.BikeNumber,
                Model = bikes.Model,
                ServiceHistory = bikes.ServiceHistory,
                Status = bikes.Status,
            };
        }

        //BikesDTO to Bikes
        public static Bikes ToEntity(this BikesDTO bikesDTO)
        {
            return new Bikes
            {
                Id = bikesDTO.Id,
                UserId = bikesDTO.UserId,
                BikeNumber = bikesDTO.BikeNumber,
                Model = bikesDTO.Model,
                ServiceHistory = bikesDTO.ServiceHistory,
                Status = bikesDTO.Status,
            };
        }
    }
}
