using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Commands.UpdateCustomer
{
  public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
  {

    public UpdateCustomerCommandValidator()
    {
      RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{UserName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters.");

      RuleFor(p => p.Email)
         .NotEmpty().WithMessage("{EmailAddress} is required.");

      RuleFor(p => p.Phone)
          .NotEmpty().WithMessage("{Phone} is required.");
    }
  }
}
