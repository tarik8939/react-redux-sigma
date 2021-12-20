using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUser
    {
        Task<User> Create(User user);
        Task<User> GetByEmail(string email);
        Task<User> GetById(int id);
        Task<User> Edit(User user);
    }
}
