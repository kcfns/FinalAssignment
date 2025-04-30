using FinalAssignment.Shared.Enum;

namespace FinalAssignment.Shared.DTO
{
    public class BikesDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; } //FK
        public string? BikeNumber { get; set; }
        public string? Model { get; set; }
        public string? ServiceHistory { get; set; }
        public Status Status { get; set; }
    }
}
