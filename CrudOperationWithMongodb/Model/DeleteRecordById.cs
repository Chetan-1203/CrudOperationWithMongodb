using System.ComponentModel.DataAnnotations;

namespace CrudOperationWithMongodb.Model
{
    public class DeleteRecordByIdRequest
    {
        [Required]
        public string Id { get; set; }  

    }
    public class DeleteRecordByIdResponse
    {
       
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

    }
}
