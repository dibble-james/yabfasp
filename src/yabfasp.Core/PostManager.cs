// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostManager.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Dibble.Framework.Data;
    using FluentValidation;
    using Model;
    using Properties;

    /// <summary>
    /// The default implementation of <see cref="IPostManager"/>.
    /// </summary>
    public class PostManager : IPostManager
    {
        private readonly IUnitOfWork persistence;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostManager"/> class.
        /// </summary>
        /// <param name="persistence">The persistence.</param>
        public PostManager(IUnitOfWork persistence)
        {
            Argument.CannotBeNull(persistence, nameof(persistence));

            this.persistence = persistence;
        }

        /// <inheritdoc/>
        public async Task<Post> CreatePost()
        {
            var post = new Post
            {
                Id = Guid.NewGuid()
            };

            await this.persistence.GetRepository<Post>().AddAsync(post);

            await this.persistence.CommitAsync();

            return post;
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Post>> GetAllPosts()
        {
            var posts = this.persistence.GetRepository<Post>().GetAllAsync();

            return posts;
        }

        /// <inheritdoc/>
        public Task<Post> GetPost(Guid postId)
        {
            var post = this.persistence.GetRepository<Post>().FirstAsync(p => p.Id == postId);

            return post;
        }

        /// <inheritdoc/>
        public async Task PublishPost(Guid postId)
        {
            var post = await this.persistence.GetRepository<Post>().SingleAsync(p => p.Id == postId);

            if (post == null)
            {
                throw new InvalidOperationException(Resources.CouldNotFindPostToPublishException);
            }

            post.IsPublished = true;
            post.Published = DateTime.UtcNow;

            await this.persistence.GetRepository<Post>().UpdateAsync(post, p => p.Id == postId);
            await this.persistence.CommitAsync();
        }

        /// <inheritdoc/>
        public async Task<Post> UpdatePost(Post post)
        {
            Argument.CannotBeNull(post, nameof(post), Resources.PostToUpdateNullException);

            await this.persistence.GetRepository<Post>().UpdateAsync(post, p => p.Id == post.Id);
            await this.persistence.CommitAsync();

            return post;
        }
    }
}