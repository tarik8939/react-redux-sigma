using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Functions;
using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Logics
{
    public class CategoryService
    {
        private ICategory _category = new CategoryRepository();
        
        public async Task<ICollection<Category>> GetAll()
        {
            var categories = await this._category.GetAll();
            if (categories.Count > 0)
                return categories;
            else
                return null;
        }
        
        public Category GetById(int id)
        {
            var category = this._category.GetById(id);
            if (category != null)
                return category;
            else
                return null;
        }
    }
}