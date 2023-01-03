using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CrudOperationWithMongodb.Model
{
    public class InsertRecordRequest
    {
#pragma warning disable CS8618
        [BsonId ,BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        
        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set; }

        [Required]
        [BsonElement("firstname")]
        public string FirstName { get; set; }


        [Required]
        [BsonElement("lastname")]
        public string LastName { get; set; }


        [Required]
        [BsonElement("age")]
        public int Age { get; set; }


        [Required]
        [BsonElement("salary")]
        public double Salary { get; set; }


    }

    public class InsertRecordresponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
#pragma warning restore CS8618
    }
}

