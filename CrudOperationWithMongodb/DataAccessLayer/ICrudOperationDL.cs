using CrudOperationWithMongodb.Model;

namespace CrudOperationWithMongodb.DataAccessLayer
{
    public interface ICrudOperationDL
    {
        public Task<InsertRecordresponse>InsertRecord(InsertRecordRequest request);   
    }
}
