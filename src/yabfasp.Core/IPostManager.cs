// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPostManager.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    /// <summary>
    /// Implementing classes define methods for managing <see cref="Post"/>'s.
    /// </summary>
    public interface IPostManager
    {
        /// <summary>
        /// Provisions a new <see cref="Post"/> in the persistence store.
        /// </summary>
        /// <returns>The new <see cref="Post"/>.</returns>
        Task<Post> CreatePost();

        /// <summary>
        /// Commits the changes to the given <paramref name="post"/> to the persistence store.
        /// </summary>
        /// <param name="post">The <see cref="Post"/> to update.</param>
        /// <returns>The updated <see cref="Post"/>.</returns>
        Task<Post> UpdatePost(Post post);

        /// <summary>
        /// Publishes the <see cref="Post"/> with the specified <paramref name="postId"/>.
        /// </summary>
        /// <param name="postId">The post identifier.</param>
        /// <returns>An awaitable object.</returns>
        Task PublishPost(Guid postId);

        /// <summary>
        /// Retrieve a <see cref="Post"/> with the given <paramref name="postId"/>.
        /// </summary>
        /// <param name="postId">The <see cref="Post"/> identifier.</param>
        /// <returns>
        /// The <see cref="Post"/> with the given <paramref name="postId"/> or null if it could
        /// not be found.
        /// </returns>
        Task<Post> GetPost(Guid postId);

        /// <summary>
        /// Gets all <see cref="Post"/>s in the persistence store.
        /// </summary>
        /// <returns>All persisted <see cref="Post"/>s.</returns>
        Task<IEnumerable<Post>> GetAllPosts();
    }
}