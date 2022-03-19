using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Functions
{
    public class CategoryRepository : ICategory
    {
        private readonly HouseDbContext _context;
        
        public CategoryRepository()
        {
            _context = new HouseDbContext(HouseDbContext.ops.dbOptions);
        }
        
        public async Task<bool> Create(List<PostCategory> list)
        {
            list.ForEach(x=>_context.PostCategories.Add(x));
            // list.ForEach(x =>
            // {
            //     _context.PostCategories.Add(x);
            // });
            await _context.SaveChangesAsync();
            return true;
           
        }

        public async Task<bool> Delete(int postId)
        {
            var categoryList = _context.PostCategories
                .Where(item => item.PostId == postId).ToList();
            foreach (var item in categoryList)
            {
                _context.PostCategories.Remove(item);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Category
                .ToListAsync();
        }

        public Category GetById(int id)
        {
            var a = _context.Category.FirstOrDefault(x => x.CategoryId == id);
            return a;
        }
    }
}