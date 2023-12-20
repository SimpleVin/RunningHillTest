using FluentValidation;
using RunningHillTest.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningHillTest.Application.Validators
{
    public class WordValidator : AbstractValidator<WordDto>
    {
        public WordValidator()
        { 
        RuleFor(x=> x.WordTypeId).NotNull().NotEmpty();
            RuleFor(x=> x.Text).NotNull().NotEmpty().Matches(@"^[a-zA-Z ]*$").WithMessage(x=> "Text contains invalid characters");
        }
    }
}
