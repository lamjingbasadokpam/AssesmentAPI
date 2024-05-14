using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using WebApplication2.Model;

namespace WebApplication2.Interface
{
    public class CandidateRepository:ICandidateRepository
    {
        private readonly CosmosClient cosmosClient;
        private readonly Container _candidateContainer;
        private readonly IConfiguration configuration;

        public CandidateRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.cosmosClient = cosmosClient;
            this.configuration = configuration;

            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            var containerName = "CandidateContainer";
            _candidateContainer = cosmosClient.GetContainer(databaseName, containerName);
        }
        public async Task<IEnumerable<CandidateModel>> GetCandidateAsync(string candidateId)
        {
            try
            {
                // Construct the LINQ query to retrieve the candidate by their ID
                var query = _candidateContainer.GetItemLinqQueryable<CandidateModel>()
                    .Where(t => t.CandidateId == candidateId)
                    .ToFeedIterator();

                var tasks = new List<CandidateModel>();
                // Execute the query asynchronously and retrieve the results
                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    tasks.AddRange(response);
                }
                return tasks;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine(ex.Message);
                return null; // Or throw the exception for the caller to handle
            }
        }

        public async Task<CandidateModel> CreateCandidateAsync(CandidateModel answer)
        {
            try
            {
                var response = await _candidateContainer.CreateItemAsync(answer);
                return response.Resource;
            }
            catch (Exception ex)
            {
                // Log the exception message
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
