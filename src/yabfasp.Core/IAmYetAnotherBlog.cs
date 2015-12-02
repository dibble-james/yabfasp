// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAmYetAnotherBlog.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core
{
    using System;

    /// <summary>
    /// Implementing classes define methods for interacting with a Yet Another Blog instance.
    /// </summary>
    public interface IAmYetAnotherBlog : IDisposable
    {
        /// <summary>
        /// Gets access to the <see cref="IBlogManager"/>.
        /// </summary>
        /// <value>
        /// The <see cref="IBlogManager"/>.
        /// </value>
        IBlogManager Blogs { get; }

        /// <summary>
        /// Gets access to the <see cref="IPostManager"/>.
        /// </summary>
        /// <value>
        /// The <see cref="IPostManager"/>
        /// </value>
        IPostManager Posts { get; }
    }
}