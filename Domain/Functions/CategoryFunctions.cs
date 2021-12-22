using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Functions
{
    public class CategoryFunctions : ICategory
    {
        private readonly HouseDbContext _context;
        
        public CategoryFunctions()
        {
            _context = new HouseDbContext(HouseDbContext.ops.dbOptions);
        }
        
        public async Task<bool> Create(List<PostCategory> list)
        {
            list.ForEach(x=>_context.PostCategories.Add(x));
            var res=await _context.SaveChangesAsync();
            if (res != null)
                return true;
            else 
                return false;
        }
    }
}