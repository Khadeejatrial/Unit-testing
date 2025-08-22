using Microsoft.AspNetCore.Mvc;
using Unit_testing.trial.Contracts;
using Unit_testing.trial.Models;

namespace Unit_testing.trial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EligibilityController : ControllerBase
    {
        private readonly IEligibilityServices _eligibility;
        private readonly IQualification _qualification;

        
        public EligibilityController(IEligibilityServices eligibility, IQualification qualification)
        {
            _eligibility = eligibility;
            _qualification = qualification;
        }

        [HttpPost("check")]
        public IActionResult CheckApplicant([FromBody] Applicant applicant)
        {
            try
            {
                _eligibility.NameException(applicant.Name);
                _eligibility.CheckEligibility(applicant.Age);
                _qualification.CheckQualification(applicant.Qualification);

                return Ok($"Applicant {applicant.Name} is eligible.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("status")]
        public IActionResult GetStatus([FromQuery] string name)
        {
            
            return Ok($"Status of applicant {name}: Eligible (sample response)");
        }
    }
}
