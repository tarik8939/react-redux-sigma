using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Functions
{
    public class UserRepository : IUser
    {

        private readonly HouseDbContext _context;

        public UserRepository()
        {
            _context = new HouseDbContext(HouseDbContext.ops.dbOptions);
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users
                .Include(x=>x.Posts)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users
                .Include(x=>x.Posts)
                .ThenInclude(x=>x.PostCategories)
                .FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<User> Edit(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
