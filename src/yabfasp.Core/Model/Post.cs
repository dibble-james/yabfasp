// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Post.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core.Model
{
    using System;
    using Dibble.Framework.Data;

    /// <summary>
    /// A data model representing a post on a <see cref="Blog"/>.
    /// </summary>
    public class Post : UniqueObject<Guid>
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the abstract.
        /// </summary>
        public string Abstract { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this post has been published is published.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is published; otherwise, <c>false</c>.
        /// </value>
        public bool IsPublished { get; set; }

        /// <summary>
        /// Gets or sets the date this <see cref="Post"/> was published.
        /// </summary>
        public DateTime Published { get; set; }
    }
}