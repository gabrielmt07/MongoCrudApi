using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoCrudApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoCrudApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPessoas()
        {
            var listaPessoas = await _pessoaRepository.Get();
            return Ok(listaPessoas);
        }

        [HttpGet("{nome}")]
        public async Task<IActionResult> GetPessoaPorNome(string nome)
        {
            var pessoa = await _pessoaRepository.GetPessoaByName(nome);
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult> InserirPessoa(Pessoa pessoa)
        {
            await _pessoaRepository.Inserir(pessoa);

            return Ok(pessoa);
        }

        [HttpPut("{nome}")]
        public async Task<ActionResult> AtualizarPessoa(string nome, Pessoa pessoa)
        {
            await _pessoaRepository.Update(nome, pessoa);

            return Ok();
        }

        [HttpDelete("{nome}")]
        public async Task<ActionResult> ApagarPessoa(string nome)
        {
            await _pessoaRepository.Delete(nome);

            return Ok();
        }
    }
}
