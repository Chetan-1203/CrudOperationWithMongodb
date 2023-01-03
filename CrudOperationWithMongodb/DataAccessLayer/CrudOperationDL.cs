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

        public async Task<GetAllRecordResponse> GetAllRecord()
        {
            GetAllRecordResponse response = new GetAllRecordResponse();
            response.IsSuccess = true;
            response.Message = "Data fetch successfully ";
          
            try
            {
                response.data = new List<InsertRecordRequest>();
                response.data = await _mongoCollection.Find(req => true).ToListAsync();
                if (response.data.Count == 0)
                {
                    response.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "exception occurs" + ex.Message;
            }

            return response;    
        }

        public async Task<GetRecordByIdResponse> GetRecordById(string id)
        {
            GetRecordByIdResponse response = new GetRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Data fetch successfully ";
            try
            {
                response.data = await  _mongoCollection.Find(req => req.Id == id).FirstOrDefaultAsync();
                if (response.data is null)
                {
                    response.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "exception occurs" + ex.Message;
            }

            return response;
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

        public async Task<UpdateRecordIdByResponse> UpdateRecordById(InsertRecordRequest request)
        {
            UpdateRecordIdByResponse response = new UpdateRecordIdByResponse();
            response.IsSuccess = true;
            response.Message = "Data updated successfully ";
            try
            {
                GetRecordByIdResponse record = await  GetRecordById(request.Id);
                
                
                    request.CreatedDate = record.data.CreatedDate;
                    request.UpdatedDate = DateTime.Now.ToString();
                    var result = await _mongoCollection.ReplaceOneAsync(req => req.Id == request.Id, request);

                    if (!result.IsAcknowledged)
                    {
                        response.Message = "Input Id not found";
                    }
                

               

                
            }


            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "exception occurs" + ex.Message;
            }

            return response;
        }

        public async  Task<DeleteRecordByIdResponse> DeleteRecordById(DeleteRecordByIdRequest request)
        {
           DeleteRecordByIdResponse response = new DeleteRecordByIdResponse();
            response.IsSuccess = true;
            response.Message = "Delete record successfully ";
            try
            {

               var result = await _mongoCollection.DeleteOneAsync(req => req.Id == request.Id);
                if (!result.IsAcknowledged)
                {
                    response.Message = "Input Id not found";
                }

            }


            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "exception occurs" + ex.Message;
            }

            return response;
        }
    }
}
