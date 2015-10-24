// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBlogBuilder.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core
{
    using Dibble.Framework.Data;

    /// <summary>
    /// Implementing classes define methods for fluidly creating a <see cref="IAmYetAnotherBlog"/>.
    /// </summary>
    public interface IBlogBuilder
    {
        /// <summary>
        /// Adds a <see cref="IUnitOfWork"/> to the <see cref="IAmYetAnotherBlog"/> blog instance.
        /// </summary>
        /// <param name="persistence">The persistence store to use.</param>
        /// <returns>The fluid builder instance.</returns>
        IBlogBuilder PersistedWith(IUnitOfWork persistence);

        /// <summary>
        /// Returns the <see cref="IAmYetAnotherBlog"/> instance that has been built.
        /// </summary>
        /// <returns>The <see cref="IAmYetAnotherBlog"/> instance that has been built.</returns>
        IAmYetAnotherBlog Finalize();
    }
}