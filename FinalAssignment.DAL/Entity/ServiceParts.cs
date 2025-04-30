using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment.DAL.Entity
{
    public class ServiceParts
    {
        
        public int Id { get; set; }
        public string? PartName {  get; set; }
        public string? PartNumber { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
