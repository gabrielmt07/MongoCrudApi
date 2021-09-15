using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;


        public PessoaController(IPessoaRepository pessoaRepository, ILogger<PessoaController> logger)
        {
            _pessoaRepository = pessoaRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPessoas()
        {
            var listaPessoas = await _pessoaRepository.Get();
            _logger.LogInformation("Lista de pessoas retornado");
            return Ok(listaPessoas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaPorNome(string id)
        {
            var pessoa = await _pessoaRepository.GetPessoaByName(id);
            _logger.LogInformation("Cadastro encontrado");
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult> InserirPessoa(Pessoa pessoa)
        {
            await _pessoaRepository.Inserir(pessoa);
            _logger.LogInformation("Pessoa inserida");

            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarPessoa(string id, Pessoa pessoa)
        {
            await _pessoaRepository.Update(id, pessoa);
            _logger.LogInformation("Cadastro atualizado");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarPessoa(string id)
        {
            await _pessoaRepository.Delete(id);
            _logger.LogInformation("Cadastro deletado");

            return Ok();
        }
    }
}
