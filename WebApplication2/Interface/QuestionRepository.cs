using WebApplication2.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interface
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly CosmosClient cosmosClient;
        private readonly Container _questionContainer;
        private readonly IConfiguration configuration;

        public QuestionRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.cosmosClient = cosmosClient;
            this.configuration = configuration;

            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            var containerName = "AssessmentContainer";
            _questionContainer = cosmosClient.GetContainer(databaseName, containerName);
        }
        public async Task<IEnumerable<QuestionModel>> GetQuestionAsync(string userId)
        {
            try
            {
                var query = _questionContainer.GetItemLinqQueryable<QuestionModel>()
                 .Where(t => t.UserId == userId)
                 .ToFeedIterator();

                var tasks = new List<QuestionModel>();
                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    tasks.AddRange(response);
                }

                return tasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
           
        }
        public async Task<IEnumerable<QuestionModel>> GetAllQuestionAsync()
        {
            try
            {
                var query = _questionContainer.GetItemLinqQueryable<QuestionModel>()
                 .ToFeedIterator();

                var tasks = new List<QuestionModel>();
                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    tasks.AddRange(response);
                }

                return tasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
           
        }
        public async Task<QuestionModel> CreateQuestionAsync(QuestionModel question)
        {
            try
            {
                var response = await _questionContainer.CreateItemAsync(question);
                return response.Resource;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
           
        }
        public async Task<QuestionModel> UpdateQuestionAsync(QuestionModel question)
        {
            try
            {
                var response = await _questionContainer.ReplaceItemAsync(question, question.Id);
                return response.Resource;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }

          
        }
        public async Task<QuestionModel> GetTaskByIdAsync( string userId)
        {
            try
            {
                var query = _questionContainer.GetItemLinqQueryable<QuestionModel>()
            .Where(t => t.UserId == userId)
            .Take(1)
            .ToQueryDefinition();

                var sqlQuery = query.QueryText; // Retrieve the SQL query

                var response = await _questionContainer.GetItemQueryIterator<QuestionModel>(query).ReadNextAsync();
                return response.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }            //var query = _taskContainer.GetItemLinqQueryable<TasksDocument>()
            //    .Where(t => t.Id == taskId && t.UserId == userId)
            //    .Take(1)
            //    .ToFeedIterator();

            //var response = await query.ReadNextAsync();
            //return response.FirstOrDefault();

           
        }
    }
}
