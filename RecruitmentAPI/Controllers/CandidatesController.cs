using Application;
using Domain.Models;
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
        private readonly ICandidatesService _candidatesService;
        public CandidatesController(IValidator<RegisterCandidateRequest> validator, ICandidatesService candidatesService) 
        {
            _registrationValidator = validator;
            _candidatesService = candidatesService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBalance(Guid id)
        {
            var candidate = await _candidatesService.FindCandidate(id.ToString());

            if (candidate == null)
            {
                var errorMessage = "The candidate id does not exsists.";
                return NotFound(errorMessage);
            }

            return Ok(candidate);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> FailCandidate(Guid id)
        {
            var candidate = await _candidatesService.FailCandidate(id.ToString());

            if (candidate == null)
            {
                var errorMessage = "The candidate id does not exsists.";
                return NotFound(errorMessage);
            }

            return Ok("Failed successfuly.");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCandidateRequest request)
        {
            var validationResult = _registrationValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var candidate = await _candidatesService.AddCandidate
                (new Candidate
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    SecondName = request.Name,
                    Patronymic = request.Patronymic,
                    
                });

            if (candidate == null)
            {
                return BadRequest("Email field is empty.");
            }

            return Ok(candidate.Id);
        }
    }
}
