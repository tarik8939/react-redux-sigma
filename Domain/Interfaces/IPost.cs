using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPost
    {
        Task<Post> Create(Post post);
        Task<List<Post>> GetAll();
        Task<Post> GetById(int id);
        Task<Post> Edit(Post post);
        Task<Boolean> Delete(int id);
        Task<List<Post>> GetByUserId(int userId);
    }
}
