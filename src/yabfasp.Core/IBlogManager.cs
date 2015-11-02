// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBlogManager.cs" company="James Dibble">
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
    /// Implementing classes define methods for managing <see cref="Blog"/>s.
    /// </summary>
    public interface IBlogManager
    {
        /// <summary>
        /// Creates a new <see cref="Blog"/>.
        /// </summary>
        /// <param name="name">The name of the new <see cref="Blog"/>.</param>
        /// <returns>The newly created <see cref="Blog"/> object.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if a <see cref="Blog"/> with the same <paramref name="name"/> already exists.
        /// </exception>
        Task<Blog> CreateBlog(string name);

        /// <summary>
        /// Get all known <see cref="Blog"/> objects.
        /// </summary>
        /// <returns>All known <see cref="Blog"/> objects.</returns>
        Task<IEnumerable<Blog>> GetBlogs();
    }
}