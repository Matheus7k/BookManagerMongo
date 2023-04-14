using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Edition")]
        public string Edition { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }

        [BsonElement("ISBN")]
        public string ISBN { get; set; }

        public override string ToString()
        {
            return $"Nome: {Name}\nEdição: {Edition}\nAutor(es): {Author}\nISBN: {ISBN}\n";
        }
    }
}