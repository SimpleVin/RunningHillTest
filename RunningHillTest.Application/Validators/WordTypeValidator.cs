using FluentValidation;
using RunningHillTest.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Application.Validators
{
    public class WordTypeValidator : AbstractValidator<WordTypeDto>
    {
        public WordTypeValidator()
        { 
            RuleFor(x=> x.Text).NotNull().NotEmpty().Matches(@"^[a-zA-Z0-9]*$").WithMessage(x=> "Text contains invalid characters");
        }
    }
}
