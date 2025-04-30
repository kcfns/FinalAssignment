

using FinalAssignment.Shared.Enum;

namespace FinalAssignment.Shared.DTO
{
    public class ServiceRequestsDTO
    {
        public int Id { get; set; }
        public int BikeId { get; set; } //FK
        public DateTime RequestDate { get; set; }
        public ServiceTypeEnum ServiceType { get; set; }
        public Status Status { get; set; }
        public string? Remarks { get; set; }
        public DateTime? ServiceDate { get; set; }
    }
}
