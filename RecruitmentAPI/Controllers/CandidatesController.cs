using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentAPI.Contracts;

namespace RecruitmentAPI.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidatesController : Controller
    {
        private readonly IValidator<RegisterCandidateRequest> _registrationValidator;
        public CandidatesController(IValidator<RegisterCandidateRequest> validator) 
        {
            _registrationValidator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCandidateRequest request)
        {
            var validationResult = _registrationValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            //var user = await _walletService.CreateWallet(request);

            //if (user == null)
            //{
            //    return BadRequest("Email field is empty");
            //}

            //return Ok(
            //    new
            //    {
            //        userId = user.Id,
            //        email = user.Email,
            //        balance = user.Balance
            //    });
            return Ok();
        }
    }
}
