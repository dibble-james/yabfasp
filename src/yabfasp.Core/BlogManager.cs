// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlogManager.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dibble.Framework.Data;
    using Model;

    /// <summary>
    /// The default <see cref="IBlogManager"/> implementation.
    /// </summary>
    public class BlogManager : IBlogManager
    {
        private readonly IUnitOfWork persistence;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogManager"/> class.
        /// </summary>
        /// <param name="persistence">The persistence.</param>
        public BlogManager(IUnitOfWork persistence)
        {
            this.persistence = persistence;
        }

        /// <inheritdoc/>
        public async Task<Blog> CreateBlog(string name)
        {
            if (await this.persistence.GetRepository<Blog>().SingleAsync(blog => blog.Name == name) != null)
            {
                throw new InvalidOperationException($"Blog [{name}] already exists");
            }

            var newBlog = new Blog
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            this.persistence.GetRepository<Blog>().Add(newBlog);

            await this.persistence.CommitAsync();

            return newBlog;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            var blogs = await this.persistence.GetRepository<Blog>().GetAllAsync();

            return blogs;
        }
    }
}