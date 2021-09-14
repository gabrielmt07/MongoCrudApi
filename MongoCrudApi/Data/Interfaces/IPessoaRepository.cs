using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoCrudApi.Data.Interfaces
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> Get();
        Task<Pessoa> GetPessoaByName(string id);
        Task Inserir(Pessoa pessoa);
        Task Update(string nome, Pessoa pessoa);
        Task Delete(string id);
    }
}
