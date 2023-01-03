namespace CrudOperationWithMongodb.Model
{
    public class GetRecordByIdResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public InsertRecordRequest data { get; set; }
    }
}
