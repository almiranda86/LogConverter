using CandidateTest.AndreLuisMiranda.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.AndreLuisMiranda.Validator
{
    public class ContentFileValidator : AbstractValidator<RequestHandlerModel>
    {
        public ContentFileValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .Must(CheckStartsWithNumber);
        }

        bool CheckStartsWithNumber(string Content)
        {
            if (string.IsNullOrEmpty(Content))
                return false;
            return char.IsDigit(Content[0]);
        }
    }
}
