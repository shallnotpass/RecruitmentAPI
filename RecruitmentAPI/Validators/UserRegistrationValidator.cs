using FluentValidation;
using RecruitmentAPI.Contracts;

namespace RecruitmentAPI.Validators
{
    public class UserRegistrationValidator : AbstractValidator<RegisterCandidateRequest>
    {
        public UserRegistrationValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
        }
    }
}
