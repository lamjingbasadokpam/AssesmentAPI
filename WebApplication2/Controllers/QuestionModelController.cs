using WebApplication2.Interface;
using WebApplication2.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class QuestionModelController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionModelController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet("user/{userId}/Question")]
        public async Task<ActionResult<IEnumerable<QuestionModel>>> GetQuestion(string userId)
        {
            var tasks = await _questionRepository.GetQuestionAsync(userId);
            if (tasks == null)// || !tasks.Any())
            {
                return NotFound();
            }

            return Ok(tasks);
        }
        [HttpGet("api/Question")]
        public async Task<ActionResult<IEnumerable<QuestionModel>>> GetAllQuestion()
        {
            var tasks = await _questionRepository.GetAllQuestionAsync();
            if (tasks == null)
            {
                return NotFound();
            }

            return Ok(tasks);
        }
        [HttpPost("create/Question")]
        public async Task<ActionResult<QuestionModel>> CreateTask(QuestionModel question)
        {
            // Set any additional properties if required
            question.Id = Guid.NewGuid().ToString();
            var createdQuestion = await _questionRepository.CreateQuestionAsync(question);
            return CreatedAtAction(nameof(GetQuestion), new {  userId = createdQuestion.UserId }, createdQuestion);
        }

        [HttpPut("{UserId}")]
        public async Task<ActionResult<QuestionModel>> UpdateTask(string UserId, QuestionModel question)
        {
            var existingTask = await _questionRepository.GetTaskByIdAsync(UserId);
            if (existingTask == null)
            {
                return NotFound();
            }

            question.Id = existingTask.Id; 

            var updatedTask = await _questionRepository.UpdateQuestionAsync(question);
            return Ok(updatedTask);
        }
    }
}
