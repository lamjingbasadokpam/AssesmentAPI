using WebApplication2.Model;

namespace WebApplication2.Interface
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<QuestionModel>> GetQuestionAsync(string userId);
        Task<IEnumerable<QuestionModel>> GetAllQuestionAsync();
        Task<QuestionModel> CreateQuestionAsync(QuestionModel question);
        Task<QuestionModel> UpdateQuestionAsync(QuestionModel question);
        Task<QuestionModel> GetTaskByIdAsync(string userId);
    }
}
