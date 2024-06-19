namespace TodoApi
{
    public interface IQuestionService
    {
        public interface IQuestionService
        {
            Task<QuestionDto> CreateQuestionAsync(QuestionDto questionDto);
            Task<QuestionDto> UpdateQuestionAsync(string id, QuestionDto questionDto);
            // Other methods for CRUD operations
        }

    }
}
