using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICategory
    {
        Task<bool> Create(List<PostCategory> list);
        Task<bool> Delete(int postId);
        Task<List<Category>> GetAll();
        Category GetById(int id);
    }
}