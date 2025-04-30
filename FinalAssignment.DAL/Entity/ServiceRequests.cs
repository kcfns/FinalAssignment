using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssignment.Shared.Enum;

namespace FinalAssignment.DAL.Entity
{
    public class ServiceRequests
    {
        public int Id { get; set; }
        public int BikeId { get; set; } //FK
        public DateTime RequestDate { get; set; }
        public ServiceTypeEnum ServiceType { get; set; }
        public Status Status { get; set; }
        public string? Remarks { get; set; }
        public DateTime? ServiceDate { get; set; }

        //relation
        public Bikes? Bike { get; set; }
    }
}
