﻿using System;
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
    public class PostLogic
    {
        private IPost _post = new PostFunctions();

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
                return result;
            else
                return null;
        }

        public async Task<ICollection<Post>> GetAll()
        {
            var posts = await this._post.GetAll();
            if (posts.Count > 0)
                return posts;
            else
                return null;
        }

        public async Task<Post> GetById(int id)
        {
            var post = await this._post.GetById(id);
            if (post == null)
                return null;
            return post;
        }

        public async Task<Post> Edit(int id, PostDto dto)
        {
            var post = await this._post.GetById(id);
            if (post != null)
            {
                post.Title = dto.Title;
                post.Body = dto.Body;
                post.UserId = dto.UserId;
                var result = await this._post.Edit(post);
                return result;
            }
            return null;
        }

        public async Task Delete(int id)
        {
            var ad = await this._post.GetById(id);
            if (ad != null)
            {
                var res = await this._post.Delete(id);
            }
        }
        public async Task<List<Post>> GetByUserId(int userId)
        {
            var posts = await this._post.GetByUserId(userId);
            if (posts == null)
                return null;
            return posts;
        }


    }
}