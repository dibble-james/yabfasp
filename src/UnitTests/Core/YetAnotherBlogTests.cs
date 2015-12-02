// --------------------------------------------------------------------------------------------------------------------
// <copyright file="YetAnotherBlogTests.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTests.Core
{
    using System.Collections.Generic;
    using Dibble.Framework.Data;
    using FluentValidation;
    using FluentValidation.Results;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Yabfasp.Core;

    [TestClass]
    public class YetAnotherBlogTests
    {
        [TestMethod]
        public void PersistedWith()
        {
            var fakeValidation = new Mock<IValidator<YetAnotherBlog>>();

            var target = new YetAnotherBlog(fakeValidation.Object);

            var fakePersistence = new Mock<IUnitOfWork>().Object;

            target.PersistedWith(fakePersistence);

            Assert.AreEqual(fakePersistence, target.Persistence);
        }

        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void FinalizeValidatorFailsExceptionFallsThrough()
        {
            var fakeValidation = new Mock<IValidator<YetAnotherBlog>>();
            fakeValidation.Setup(a => a.Validate(It.IsAny<YetAnotherBlog>()))
                .Returns(new ValidationResult(new List<ValidationFailure> { new ValidationFailure(string.Empty, string.Empty) }));

            var target = new YetAnotherBlog(fakeValidation.Object);

            target.Finalize();
        }

        [TestMethod]
        public void FinalizeValidator()
        {
            var fakeValidation = new Mock<IValidator<YetAnotherBlog>>();
            fakeValidation.Setup(a => a.Validate(It.IsAny<YetAnotherBlog>()))
                .Returns(new ValidationResult());

            var target = new YetAnotherBlog(fakeValidation.Object);

            var actual = target.Finalize();

            Assert.AreEqual(target, actual);
        }

        [TestMethod]
        public void WithDefaultBlogManager()
        {
            var fakeValidation = new Mock<IValidator<YetAnotherBlog>>();

            var target = new YetAnotherBlog(fakeValidation.Object);

            target.WithDefaultBlogManager();

            Assert.IsNotNull(target.Blogs);
            Assert.IsInstanceOfType(target.Blogs, typeof(BlogManager));
        }

        [TestMethod]
        public void WithDefaultPosrManager()
        {
            var fakeValidation = new Mock<IValidator<YetAnotherBlog>>();

            var target = new YetAnotherBlog(fakeValidation.Object);

            target.WithDefaultPostManager();

            Assert.IsNotNull(target.Posts);
            Assert.IsInstanceOfType(target.Posts, typeof(PostManager));
        }
    }
}