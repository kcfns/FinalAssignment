
using FinalAssignment.DAL.Entity;
using FinalAssignment.Shared.DTO;

namespace FinalAssignment.BAL.Mapper
{
    public static class ServicePartsMapper
    {
        //ServiceParts to ServicePartsDTO
        public static ServicePartsDTO ToDTO(this ServiceParts servicePart)
        {
            return new ServicePartsDTO
            {
                Id = servicePart.Id,
                PartName = servicePart.PartName,
                PartNumber = servicePart.PartNumber,
                Quantity = servicePart.Quantity,
            };
        }

        //ServicePartsDTO to ServiceParts
        public static ServiceParts ToEntity(this ServicePartsDTO servicePartDTO)
        {
            return new ServiceParts
            {
                Id= servicePartDTO.Id,
                PartName= servicePartDTO.PartName,
                PartNumber= servicePartDTO.PartNumber,
                Quantity= servicePartDTO.Quantity,
            };
        }
    }
}
