using Microsoft.Extensions.Configuration;
using MongoCrudApi.Data.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoCrudApi.Data.Imp
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly MongoClient _client;
        private readonly IConfiguration _configuration;
        private const string PESSOA_COLLECTION = "PessoaCollection";
        private const string DATABASE = "MongoCrud";
        private readonly IMongoCollection<Pessoa> _pessoaCollection;
        private readonly IMongoDatabase _database;

        public PessoaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MongoClient(_configuration.GetConnectionString("Mongo2FAConnectionString").ToString());
            _database = _client.GetDatabase(DATABASE);
            _pessoaCollection = _database.GetCollection<Pessoa>(PESSOA_COLLECTION);
        }

        public async Task<IEnumerable<Pessoa>> Get()
        {
            var pessoas = await _pessoaCollection.FindAsync(pessoas => true);
            return pessoas.ToList();
        }

        public async Task<Pessoa> GetPessoaByName(string nome)
        {
            var pessoa = await _pessoaCollection.FindAsync(x => x.Nome == nome);
            return pessoa.FirstOrDefault();
        }

        public async Task Inserir(Pessoa pessoa)
        {
            await _pessoaCollection.InsertOneAsync(pessoa);
        }

        public async Task Update(string nome, Pessoa pessoa)
        {
            await _pessoaCollection.FindOneAndReplaceAsync<Pessoa>(
                x => x.Nome == nome, pessoa);
        }

        public async Task Delete(string nome)
        {
            var pessoa = await _pessoaCollection.DeleteOneAsync(x => x.Nome == nome);
        }
    }
}
