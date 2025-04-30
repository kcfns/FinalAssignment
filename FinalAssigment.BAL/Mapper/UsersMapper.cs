using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssignment.DAL.Entity;
using FinalAssignment.Shared.DTO;

namespace FinalAssignment.BAL.Mapper
{
    public static class UsersMapper
    {
        public static UsersDTO ToDTO (this Users users)
        {
            return new UsersDTO
            {
                Id = users.Id,
                Email = users.Email,
                Password = users.Password,
                IsStaff = users.IsStaff,
            };
        }

        public static Users ToEntity (this UsersDTO usersDTO)
        {
            return new Users
            {
                Id = usersDTO.Id,
                Email = usersDTO.Email,
                Password = usersDTO.Password,
                IsStaff = usersDTO.IsStaff,
            };
        }
    }
}
