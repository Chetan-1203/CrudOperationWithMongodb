using CrudOperationWithMongodb.Model;

namespace CrudOperationWithMongodb.DataAccessLayer
{
    public interface ICrudOperationDL
    {
        public Task<GetAllRecordResponse> GetAllRecord();
        public Task<InsertRecordresponse>InsertRecord(InsertRecordRequest request);   

        public Task<GetRecordByIdResponse>GetRecordById(string id);

        public Task<UpdateRecordIdByResponse> UpdateRecordById(InsertRecordRequest request);
        public Task<DeleteRecordByIdResponse> DeleteRecordById(DeleteRecordByIdRequest request);
    }
}
