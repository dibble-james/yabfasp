// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostManagerTests.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTests.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Dibble.Framework.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Yabfasp.Core;
    using Yabfasp.Core.Model;

    [TestClass]
    public class PostManagerTests
    {
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ConstructorValidatesDependencies()
        {
            new PostManager(null);
        }

        [TestMethod]
        public async Task CreateMakesNewPost()
        {
            var fakeRepository = new Mock<IRepository<Post>>();

            var fakePersistence = new Mock<IUnitOfWork>();
            fakePersistence.Setup(p => p.GetRepository<Post>()).Returns(fakeRepository.Object);

            var target = new PostManager(fakePersistence.Object);

            var actual = await target.CreatePost();

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.Id == default(Guid));
        }

        [TestMethod]
        public async Task GetAllReturnsPosts()
        {
            var posts = new List<Post>
            {
                new Post(),
                new Post()
            };

            var fakeRepository = new Mock<IRepository<Post>>();
            fakeRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(posts);

            var fakePersistence = new Mock<IUnitOfWork>();
            fakePersistence.Setup(p => p.GetRepository<Post>()).Returns(fakeRepository.Object);

            var target = new PostManager(fakePersistence.Object);

            var actual = await target.GetAllPosts();

            Assert.AreEqual(posts, actual);
        }

        [TestMethod]
        public async Task GetPostNullReturnedFromPersistence()
        {
            var fakeRepository = new Mock<IRepository<Post>>();
            fakeRepository.Setup(r => r.FirstAsync(It.IsAny<Expression<Func<Post, bool>>>())).ReturnsAsync(null);

            var fakePersistence = new Mock<IUnitOfWork>();
            fakePersistence.Setup(p => p.GetRepository<Post>()).Returns(fakeRepository.Object);

            var target = new PostManager(fakePersistence.Object);

            var actual = await target.GetPost(Guid.NewGuid());

            Assert.IsNull(actual);
        }

        [TestMethod]
        public async Task GetPost()
        {
            var expectedPost = new Post();

            var fakeRepository = new Mock<IRepository<Post>>();
            fakeRepository.Setup(r => r.FirstAsync(It.IsAny<Expression<Func<Post, bool>>>())).ReturnsAsync(expectedPost);

            var fakePersistence = new Mock<IUnitOfWork>();
            fakePersistence.Setup(p => p.GetRepository<Post>()).Returns(fakeRepository.Object);

            var target = new PostManager(fakePersistence.Object);

            var actual = await target.GetPost(Guid.NewGuid());

            Assert.AreEqual(expectedPost, actual);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public async Task PublishPostPostNotFound()
        {
            var expectedPost = new Post { Id = Guid.NewGuid() };

            var fakeRepository = new Mock<IRepository<Post>>();
            fakeRepository.Setup(r => r.SingleAsync(It.IsAny<Expression<Func<Post, bool>>>())).ReturnsAsync(null);

            var fakePersistence = new Mock<IUnitOfWork>();
            fakePersistence.Setup(p => p.GetRepository<Post>()).Returns(fakeRepository.Object);

            var target = new PostManager(fakePersistence.Object);

            await target.PublishPost(Guid.NewGuid());
        }

        [TestMethod]
        public async Task PublishPost()
        {
            var expectedPost = new Post { Id = Guid.NewGuid() };

            var fakeRepository = new Mock<IRepository<Post>>();
            fakeRepository.Setup(r => r.SingleAsync(It.IsAny<Expression<Func<Post, bool>>>())).ReturnsAsync(expectedPost);
            fakeRepository.Setup(r => r.UpdateAsync(It.IsAny<Post>(), It.IsAny<Expression<Func<Post, bool>>>()))
                          .Callback<Post, Expression<Func<Post, bool>>>((p, x) =>
                          {
                              Assert.IsTrue(p.IsPublished);
                              Assert.AreNotEqual(default(DateTime), p.Published);
                          })
                          .ReturnsAsync(expectedPost);

            var fakePersistence = new Mock<IUnitOfWork>();
            fakePersistence.Setup(p => p.GetRepository<Post>()).Returns(fakeRepository.Object);

            var target = new PostManager(fakePersistence.Object);

            await target.PublishPost(Guid.NewGuid());
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public async Task UpdatePostPassedNull()
        {
            var fakePersistence = new Mock<IUnitOfWork>();

            var target = new PostManager(fakePersistence.Object);

            await target.UpdatePost(null);
        }

        [TestMethod]
        public async Task UpdatePost()
        {
            var expectedPost = new Post { Id = Guid.NewGuid() };

            var fakeRepository = new Mock<IRepository<Post>>();
            fakeRepository.Setup(r => r.UpdateAsync(It.IsAny<Post>(), It.IsAny<Expression<Func<Post, bool>>>()))
                          .ReturnsAsync(expectedPost);

            var fakePersistence = new Mock<IUnitOfWork>();
            fakePersistence.Setup(p => p.GetRepository<Post>()).Returns(fakeRepository.Object);

            var target = new PostManager(fakePersistence.Object);

            await target.UpdatePost(expectedPost);
        }
    }
}