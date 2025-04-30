using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment.DAL.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }   
        public bool IsStaff { get; set; }

        //reference
        public ICollection<Bikes>? Bikes { get; set; }
    }
}
