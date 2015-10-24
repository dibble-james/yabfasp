// --------------------------------------------------------------------------------------------------------------------
// <copyright file="YetAnotherBlog.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Yet Another Blog API.
    /// </summary>
    public class YetAnotherBlog : IAmYetAnotherBlog, IBlogBuilder
    {
        /// <summary>
        /// Returns the <see cref="IAmYetAnotherBlog" /> instance that has been built.
        /// </summary>
        /// <returns>
        /// The <see cref="IAmYetAnotherBlog" /> instance that has been built.
        /// </returns>
        public IAmYetAnotherBlog Finalize()
        {
            throw new NotImplementedException();
        }
    }
}