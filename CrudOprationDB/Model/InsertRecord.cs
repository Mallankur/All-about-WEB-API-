using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CrudOprationDB.Model
{
    public class InsertRecordRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public String? CreateDate { get; set; }

        public  String? UpdateDate { get; set; }

        [Required]
        [BsonElement("Name")]
        public string Name { get; set; }
        [Required]
        public String lastName { get; set; }
        [Required]
        public int age  { get; set; }

        [Required]
        public string ContectNumber{ get; set; }
        
        public int Salery { get; set; }



    }
    public class InsertRecordResponse
    {
        public bool  isSuucceses { get; set; }
        public  string  Massege { get; set; }
    }
}
