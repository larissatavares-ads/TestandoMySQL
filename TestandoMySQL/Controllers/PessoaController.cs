using Microsoft.AspNetCore.Mvc;
using TestandoMySQL.Models;
using TestandoMySQL.Repository;

namespace TestandoMySQL.Controllers
{
    [ApiController]
    [Route("Pessoa")]
    public class PessoaController : ControllerBase
    {
        private IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository repo)
        {
            _pessoaRepository = repo;
        }
        [HttpPost]
        public async Task<IActionResult> CriarPessoa(Pessoa pessoa)
        {
            await _pessoaRepository.CriarPessoa(pessoa);
            return Ok(pessoa);
        }
        [HttpGet]
        public async Task<IActionResult> RecuperarPessoas()
        {
            var lista = await _pessoaRepository.RecuperarPessoas();
            return Ok(lista); 
        }
    }
}
