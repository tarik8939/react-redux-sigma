using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Domain.Functions
{
    public class PostFunctions : IPost
    {

        private readonly HouseDbContext _context;

        public PostFunctions()
        {
            _context = new HouseDbContext(HouseDbContext.ops.dbOptions);
        }


        public async Task<Post> Create(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.Posts
                .Include(x => x.User)
                .Include(x=>x.PostCategories)
                .ThenInclude(x=>x.Category)
                .ToListAsync();

        }

        public async Task<Post> GetById(int id)
        {
            return await _context.Posts
                .Include(x => x.User)
                .Include(x=>x.PostCategories)
                .ThenInclude(x=>x.Category)
                .FirstOrDefaultAsync(x => x.PostId == id);
        }

        public async Task<Post> Edit(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return false;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Post>> GetByUserId(int userId)
        {
            return await _context.Posts
                .Include(x => x.User)
                .Include(x=>x.PostCategories)
                .ThenInclude(x=>x.Category)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
