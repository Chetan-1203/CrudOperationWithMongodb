using CrudOperationWithMongodb.Model;
using MongoDB.Driver;

namespace CrudOperationWithMongodb.DataAccessLayer
{
    public class CrudOperationDL:ICrudOperationDL
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<InsertRecordRequest> _mongoCollection;
        public CrudOperationDL(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["Database:ConnectionString"]);
            var _MongoDatabase = _mongoClient.GetDatabase(_configuration["Database:DatabaseName"]);
            _mongoCollection = _MongoDatabase.GetCollection<InsertRecordRequest>(_configuration["Database:CollectionName"]);
        }

        public async Task<InsertRecordresponse> InsertRecord(InsertRecordRequest request)
        {    
              InsertRecordresponse response = new InsertRecordresponse();
              response.IsSuccess = true;
              response.Message = "Data successfully inserted";
            try
            {
                request.CreatedDate = DateTime.Now.ToString();
                request.UpdatedDate = String.Empty;
                await _mongoCollection.InsertOneAsync(request);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "exception occurs" + ex.Message;
            }

            return response;
        }
    }
}
