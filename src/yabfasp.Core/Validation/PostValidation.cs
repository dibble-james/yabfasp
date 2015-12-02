// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostValidation.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core.Validation
{
    using FluentValidation;
    using Model;
    using Properties;

    /// <summary>
    /// A validator for complete <see cref="Post"/> instances.
    /// </summary>
    public class PostValidation : AbstractValidator<Post>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostValidation"/> class.
        /// </summary>
        public PostValidation()
        {
            this.RuleFor(p => p.Content).NotEmpty().WithLocalizedMessage(() => Resources.ValidationErrorPostNoContent);
        }
    }
}