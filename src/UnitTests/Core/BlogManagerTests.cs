// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlogManagerTests.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTests.Core
{
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Dibble.Framework.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Yabfasp.Core;
    using Yabfasp.Core.Model;

    [TestClass]
    public class BlogManagerTests
    {
        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public async Task CreateBlogAlreadyExistsThrowsException()
        {
            var fakeRepository = new Mock<IRepository<Blog>>();
            fakeRepository
                .Setup(p => p.SingleAsync(It.IsAny<Expression<Func<Blog, bool>>>()))
                .ReturnsAsync(new Blog());

            var fakePersistence = new Mock<IUnitOfWork>();
            fakePersistence.Setup(p => p.GetRepository<Blog>()).Returns(fakeRepository.Object);

            var target = new BlogManager(fakePersistence.Object);

            await target.CreateBlog("New Blog");
        }

        [TestMethod]
        public async Task CreateBlogReturnsBlog()
        {
            const string expected = "New Blog";

            var fakeRepository = new Mock<IRepository<Blog>>();
            fakeRepository
                .Setup(p => p.SingleAsync(It.IsAny<Expression<Func<Blog, bool>>>()))
                .ReturnsAsync(null);

            var fakePersistence = new Mock<IUnitOfWork>();
            fakePersistence.Setup(p => p.GetRepository<Blog>()).Returns(fakeRepository.Object);

            var target = new BlogManager(fakePersistence.Object);

            var actual = await target.CreateBlog(expected);

            Assert.AreEqual(expected, actual.Name);
            Assert.AreNotEqual(Guid.Empty, actual.Id);
        }

        [TestMethod]
        public async Task GetBlogsReturnsAllBlogs()
        {
            var expected = new Blog[] { new Blog { } };

            var fakeRepository = new Mock<IRepository<Blog>>();
            fakeRepository.Setup(p => p.GetAllAsync()).ReturnsAsync(expected);

            var fakePersistence = new Mock<IUnitOfWork>();
            fakePersistence.Setup(p => p.GetRepository<Blog>()).Returns(fakeRepository.Object);

            var target = new BlogManager(fakePersistence.Object);

            var actual = await target.GetBlogs();

            Assert.AreEqual(expected, actual);
        }
    }
}