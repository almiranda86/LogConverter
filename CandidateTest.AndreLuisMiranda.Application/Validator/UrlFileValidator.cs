using CandidateTest.AndreLuisMiranda.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.AndreLuisMiranda.Validator
{
    public class UrlFileValidator : AbstractValidator<string>
    {
        public UrlFileValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .NotNull();
                //.Must(BeURLValid);
        }

        private static bool BeURLValid(string source) => Uri.TryCreate(source, UriKind.Absolute, out Uri uriResult) && uriResult.Scheme == Uri.UriSchemeHttps;
    }
}
