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
using AutoFixture;
using AutoFixture.Xunit2;

namespace UnitTests
{
    public class PostServiceTests
    {
        private Fixture fixture { get; set; }
        private int amountOfPosts { get; set; }

        private List<Post> Posts;

        private List<Post> getPosts(int amountOfPosts)
        {
            var posts = new List<Post>();
            var fixture = new Fixture();

            for (int i = 1; i <= amountOfPosts; i++)
            {
                var post = fixture.Build<Post>()
                    .With(x=>x.PostId, i)
                    .Without(x => x.Document)
                    .Without(x => x.PostCategories)
                    .Without(x => x.User)
                    .Create<Post>();
                posts.Add(post);
            }
            return posts;
        }
        
        public PostServiceTests()
        {
            fixture = new Fixture();
            amountOfPosts = fixture.Create<int>();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(1, amountOfPosts));
            Posts = getPosts(amountOfPosts);

        }

        [Fact]
        public void GetExisingPost()
        {
            var inputId = fixture.Create<int>();
            var existingPost = Posts.First(x => x.PostId == inputId);

            var dbSrviceMock = new Mock<IDatabaseService>();
            var repositoryMock = new Mock<IPost>();

            repositoryMock
                .Setup(dbPost => dbPost.GetById(inputId).Result)
                .Returns(existingPost);
            dbSrviceMock
                .Setup(service => service.Posts)
                .Returns(repositoryMock.Object);

            var postService = new PostService(dbSrviceMock.Object); 
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
            var inputId = fixture.Create<int>();
            var dbSrviceMock = new Mock<IDatabaseService>();
            var repositoryMock = new Mock<IPost>();
        
            repositoryMock
                .Setup(dbPost => dbPost.GetById(inputId).Result)
                .Returns(null as Post);
            dbSrviceMock
                .Setup(service => service.Posts)
                .Returns(repositoryMock.Object);
        
            var postService = new PostService(dbSrviceMock.Object); 
            var ex = await Assert.ThrowsAsync<NullReferenceException>(() => postService.GetById(inputId));
            ex.Message.Contains("The selected post doesn't exist");
        }
        
        [Fact]
        public async Task GetPostsByUserId()
        {
            var post = Posts.FirstOrDefault(x=>x.PostId == fixture.Create<int>());
            var userId = post.UserId;
            var dbSrviceMock = new Mock<IDatabaseService>();
            var repositoryMock = new Mock<IPost>();
        
            repositoryMock
                .Setup(dbPost => dbPost.GetByUserId(userId).Result)
                .Returns(Posts);
            dbSrviceMock
                .Setup(service => service.Posts)
                .Returns(repositoryMock.Object);
        
            var postService = new PostService(dbSrviceMock.Object); 
            var result = postService.GetByUserId(userId).Result;
            result.Equals(Posts);
        }
    }
}