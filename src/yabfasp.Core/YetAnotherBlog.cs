// --------------------------------------------------------------------------------------------------------------------
// <copyright file="YetAnotherBlog.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core
{
    using System;
    using Dibble.Framework.Data;
    using FluentValidation;

    /// <summary>
    /// The Yet Another Blog API.
    /// </summary>
    internal class YetAnotherBlog : IAmYetAnotherBlog, IBlogBuilder
    {
        private readonly IValidator<YetAnotherBlog> validator;

        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="YetAnotherBlog"/> class.
        /// </summary>
        /// <param name="configurationValidator">
        /// An <see cref="IValidator{T}"/> for this instance to be used when calling
        /// <see cref="IBlogBuilder.Finalize"/>.
        /// </param>
        internal YetAnotherBlog(IValidator<YetAnotherBlog> configurationValidator)
        {
            this.validator = configurationValidator;

            this.isDisposed = false;
        }

        /// <summary>
        /// Gets the persistence.
        /// </summary>
        /// <value>
        /// The persistence.
        /// </value>
        internal IUnitOfWork Persistence { get; private set; }

        /// <summary>
        /// Returns the <see cref="IAmYetAnotherBlog" /> instance that has been built.
        /// </summary>
        /// <returns>
        /// The <see cref="IAmYetAnotherBlog" /> instance that has been built.
        /// </returns>
        /// <exception cref="ValidationException">Thrown if the configuration of this builder is invalid.</exception>
        public IAmYetAnotherBlog Finalize()
        {
            var validationResult = this.validator.Validate(this);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return this;
        }

        /// <summary>
        /// Adds a <see cref="IUnitOfWork" /> to the <see cref="IAmYetAnotherBlog" /> blog instance.
        /// </summary>
        /// <param name="persistence">The persistence store to use.</param>
        /// <returns>
        /// The fluid builder instance.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public IBlogBuilder PersistedWith(IUnitOfWork persistence)
        {
            this.Persistence = persistence;

            return this;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    this.Persistence.Dispose();
                }

                this.isDisposed = true;
            }
        }
    }
}