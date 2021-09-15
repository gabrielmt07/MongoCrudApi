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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaPorNome(string id)
        {
            var pessoa = await _pessoaRepository.GetPessoaByName(id);
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult> InserirPessoa(Pessoa pessoa)
        {
            await _pessoaRepository.Inserir(pessoa);

            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarPessoa(string id, Pessoa pessoa)
        {
            await _pessoaRepository.Update(id, pessoa);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarPessoa(string id)
        {
            await _pessoaRepository.Delete(id);

            return Ok();
        }
    }
}
