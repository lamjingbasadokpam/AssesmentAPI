using Microsoft.AspNetCore.Mvc;
using WebApplication2.Interface;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    public class CandidateModelController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateModelController( ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        [HttpGet("candidate/{candidateId}/Answer")]
        public async Task<ActionResult<IEnumerable<CandidateModel>>> GetAnswer(string candidateId)
        {
            var tasks = await _candidateRepository.GetCandidateAsync(candidateId);
            if (tasks == null)// || !tasks.Any())
            {
                return NotFound();
            }

            return Ok(tasks);
        }
        [HttpPost("create/Answer")]
        public async Task<ActionResult<CandidateModel>> CreateAnswer(CandidateModel answer)
        {
            // Generate a unique ID for the candidate
            answer.Id = Guid.NewGuid().ToString();

            // Call the repository method to create the candidate
            var createdCandidate = await _candidateRepository.CreateCandidateAsync(answer);

            // Return the created candidate in the response
            return CreatedAtAction(nameof(GetAnswer), new { candidateId = createdCandidate.CandidateId }, createdCandidate);
        }

    }
}
