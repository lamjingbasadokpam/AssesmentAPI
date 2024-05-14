using WebApplication2.Model;

namespace WebApplication2.Interface
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<CandidateModel>> GetCandidateAsync(string candidateId);
        Task<CandidateModel> CreateCandidateAsync(CandidateModel answer);
      
    }
}
