using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using BusinessLogic.Logics;
using Domain.Functions;
using Domain.Interfaces;
using Domain.Models;
using Moq;

namespace UnitTests
{
    public class PostServiceTests
    {
        private List<Post> GetFakePosts()
        {
            var posts = new List<Post>()
            {
                new Post
                {
                    PostId = 1,
                    UserId = 1,
                    Title = "Test title",
                    Body = "Test body",
                    Document = new Document(){PostId = 1,DocumentId = 1},
                    User = new User()
                    {
                        UserId = 1,
                        Email = "adasd",
                        Posts = new List<Post>()
                    },
                    PostCategories = new List<PostCategory>(){}
                },
                new Post
                {
                    PostId = 2,
                    UserId = 1,
                    Title = "Test title2",
                    Body = "Test body2",
                    Document = new Document(){PostId = 2,DocumentId = 2},
                    User = new User()
                    {
                        UserId = 1,
                        Email = "adasd",
                        Posts = new List<Post>()
                    },
                    PostCategories = new List<PostCategory>(){}
                },
                new Post
                {
                    PostId = 3,
                    UserId = 1,
                    Title = "Test title3",
                    Body = "Test body3",
                    Document = new Document(){PostId = 3,DocumentId = 3},
                    User = new User()
                    {
                        UserId = 1,
                        Email = "adasd",
                        Posts = new List<Post>()
                    },
                    PostCategories = new List<PostCategory>(){}
                },
            };
            return posts;
        }

        [Fact]
        public void GetExisingPost()
        {
            var inputId = 1;
            var PostsCollection = GetFakePosts();
            var existingPost = PostsCollection.First(x => x.PostId == inputId);

            var dbSrviceMock = new Mock<IDatabaseService>();
            var repositoryMock = new Mock<IPost>();

            repositoryMock
                .Setup(dbPost => dbPost.GetById(inputId).Result)
                .Returns(existingPost);
            dbSrviceMock
                .Setup(service => service.Posts)
                .Returns(repositoryMock.Object);

            var postService = new PostService(dbSrviceMock.Object); ///!!
            var result = postService.GetById(inputId).Result;
            
            Assert.Equal(existingPost.PostId, result.PostId);
            Assert.Equal(existingPost.UserId, result.UserId);
            Assert.Equal(existingPost.Body, result.Body);
            Assert.Equal(existingPost.Title, result.Title);
            Assert.Equal(existingPost.Document, result.Document);
            Assert.Equal(existingPost.User, result.User);
        }
        
        [Fact]
        public async Task GetNotExisingPost()
        {
            var inputId = 10;
            var dbSrviceMock = new Mock<IDatabaseService>();
            var repositoryMock = new Mock<IPost>();
        
            repositoryMock
                .Setup(dbPost => dbPost.GetById(inputId).Result)
                .Returns(null as Post);
            dbSrviceMock
                .Setup(service => service.Posts)
                .Returns(repositoryMock.Object);
        
            var postService = new PostService(dbSrviceMock.Object); ///!!
            var ex = await Assert.ThrowsAsync<NullReferenceException>(() => postService.GetById2(inputId));
            ex.Message.Contains("The selected post doesn't exist");
        }
        
        [Fact]
        public async Task GetPostsByUserId()
        {
            var userId = 1;
            
            var dbSrviceMock = new Mock<IDatabaseService>();
            var repositoryMock = new Mock<IPost>();
        
            repositoryMock
                .Setup(dbPost => dbPost.GetAll().Result)
                .Returns(GetFakePosts());
            dbSrviceMock
                .Setup(service => service.Posts)
                .Returns(repositoryMock.Object);
        
            var postService = new PostService(dbSrviceMock.Object); ///!!
            var result = postService.GetAll().Result;
            result.Equals(GetFakePosts());
        }
        
        
    }
}