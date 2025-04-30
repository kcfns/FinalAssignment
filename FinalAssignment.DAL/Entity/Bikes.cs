using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssignment.Shared.Enum;

namespace FinalAssignment.DAL.Entity
{
    public class Bikes
    {
        public int Id { get; set; } 
        public int UserId { get; set; } //FK
        public string? BikeNumber { get; set; }
        public string? Model { get; set; }
        public string? ServiceHistory { get; set; }
        public Status Status { get; set; }

        //relation
        public Users? User { get; set; }
        public ICollection<ServiceRequests>? ServiceRequests { get; set; }

    }
}
