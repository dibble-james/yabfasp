// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBlogBuilder.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core
{
    /// <summary>
    /// Implementing classes define methods for fluidly creating a <see cref="IAmYetAnotherBlog"/>.
    /// </summary>
    public interface IBlogBuilder
    {
        /// <summary>
        /// Returns the <see cref="IAmYetAnotherBlog"/> instance that has been built.
        /// </summary>
        /// <returns>The <see cref="IAmYetAnotherBlog"/> instance that has been built.</returns>
        IAmYetAnotherBlog Finalize();
    }
}