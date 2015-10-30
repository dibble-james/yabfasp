// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Blog.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core.Model
{
    using System;
    using Dibble.Framework.Data;

    /// <summary>
    /// A data model of a blog.
    /// </summary>
    public class Blog : UniqueObject<Guid>
    {
        /// <summary>
        /// Gets or sets the name of this <see cref="Blog"/>.
        /// </summary>
        public string Name { get; set; }
    }
}