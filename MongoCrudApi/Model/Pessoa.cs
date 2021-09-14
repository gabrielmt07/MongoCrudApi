using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoCrudApi
{
    [BsonIgnoreExtraElements]
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cidade { get; set; }
    }
}