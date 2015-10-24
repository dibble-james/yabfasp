// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationValidator.cs" company="James Dibble">
// Copyright (c) James Dibble. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Yabfasp.Core
{
    using FluentValidation;
    using Properties;

    /// <summary>
    /// The definition of a valid <see cref="YetAnotherBlog"/> used when building an
    /// instance using the fluid factory.
    /// </summary>
    public class ConfigurationValidator : AbstractValidator<YetAnotherBlog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationValidator"/> class.
        /// </summary>
        public ConfigurationValidator()
        {
            this.RuleFor(yab => yab.Persistence).NotNull().WithLocalizedMessage(() => Resources.ValidationErrorNoPersistence);
        }
    }
}