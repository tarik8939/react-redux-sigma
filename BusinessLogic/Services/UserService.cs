using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs;
using Domain.Functions;
using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Logics
{
    public class UserService
    {
        private IUser _user = new UserRepository();

        public async Task<User> Register(UserDto dto)
        {
            var user = new User
            {
                Email = dto.Email,
            };

            var check = await this._user.GetByEmail(dto.Email);
            if (check == null)
            {
                await this._user.Create(user);
                var result = await this.GetByEmail(dto.Email);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await this._user.GetByEmail(email);

            if (user == null)
                return null;
            return user;
        }

        public async Task<User> GetById(int id)
        {
            var user = await this._user.GetById(id);

            if (user == null)
                return null;
            return user;
        }
    }
}
