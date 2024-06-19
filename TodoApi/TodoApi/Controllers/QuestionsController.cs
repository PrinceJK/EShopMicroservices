using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(QuestionDto questionDto)
        {
            var createdQuestion = await _questionService.CreateQuestionAsync(questionDto);
            return CreatedAtAction(nameof(GetQuestionById), new { id = createdQuestion.Id }, createdQuestion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(string id, QuestionDto questionDto)
        {
            var updatedQuestion = await _questionService.UpdateQuestionAsync(id, questionDto);
            if (updatedQuestion == null)
            {
                return NotFound();
            }
            return Ok(updatedQuestion);
        }

        // Implement other CRUD methods (GET, PUT, DELETE) as needed
    }

}
