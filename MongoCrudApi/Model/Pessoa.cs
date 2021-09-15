using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoCrudApi
{
    [BsonIgnoreExtraElements]
    public class Pessoa
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cidade { get; set; }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}