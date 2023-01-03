using System.ComponentModel.DataAnnotations;

namespace CrudOperationWithMongodb.Model
{
    
    public class UpdateRecordIdByResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
