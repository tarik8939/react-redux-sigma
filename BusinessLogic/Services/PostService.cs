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
    public class PostService
    {
        private IPost _post = new PostRepository();
        private ICategory _category = new CategoryRepository();
        private readonly IDatabaseService _database;
        
        public PostService(IDatabaseService database)
        {
            _database = database;
        }
        
        public PostService()
        {
        }

        public async Task<Post> Create(PostDto dto)
        {
            var post = new Post
            {
                UserId = dto.UserId,
                Body = dto.Body,
                Title = dto.Title,
            };
            var result = await this._post.Create(post);
            if (result.PostId > 0)
            {
                var list = getCategories(dto.CategoryDtos, result.PostId);
                var categoryResult = _category.Create(list);
                if (categoryResult.Result == true)
                {
                   result.PostCategories = list; 
                }
                return result;
            }
            else
                return null;
        }

        public async Task<ICollection<Post>> GetAll2()
        {
            var posts = await this._post.GetAll();
            if (posts.Count > 0)
                return posts;
            else
                return null;
        }
        
        public async Task<ICollection<Post>> GetAll()
        {
            var posts = await this._database.Posts.GetAll();
            if (posts.Count > 0)
                return posts;
            else
                return null;
        }
        
        public async Task<Post> GetById(int id)
        {
            var post = await this._database.Posts.GetById(id);
            if (post == null) 
                throw new NullReferenceException("The selected post doesn't exist");;
            return post;
        }
        public async Task<Post> GetById2(int id)
        {
            var post = await this._post.GetById(id);
            if (post == null) 
                throw new NullReferenceException("The selected post doesn't exist");;
            return post;
        }
        
        public async Task<List<Post>> GetByUserId(int userId)
        {
            var posts = await this._post.GetByUserId(userId);
            if (posts.Count > 0)
                return posts;
            return null;
        }

        public async Task<Post> Edit(int id, PostDto dto)
        {
            var post = await this._post.GetById(id);
            if (post != null)
            {
                post.Title = dto.Title;
                post.Body = dto.Body;
                post.UserId = dto.UserId;
                var list = getCategories(dto.CategoryDtos, post.PostId);
                post.PostCategories = list;
                var result = await this._post.Edit(post);
                return result;
            }
            return null;
        }
        
        public async Task Delete(int id)
        {
            var post = await this._post.GetById(id);
            if (post != null)
            {
                var resultPost = await this._post.Delete(id);
                var resultCategory = await this._category.Delete(id);
            }
        }
        private List<PostCategory> getCategories(ICollection<CategoryDto> list, int postId)
        {
            return list
                .Select(x => new PostCategory()
                {
                    PostId = postId,
                    CategoryId = x.CategoryId,

                }).ToList();
        }
        
    }
}
