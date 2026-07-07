using DesafioCrudAPI.Entidade.Contato;
using DesafioCrudAPI.Service.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCrudAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        // POST: api/contato
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Contato contato)
        {
            try
            {
                await _contatoService.AdicionarContatoAsync(contato);
                return Ok("Contato cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/contato
        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var contatos = await _contatoService.ListarTodosAsync();
            return Ok(contatos);
        }

        // GET: api/contato/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var contato = await _contatoService.ObterPorIdAsync(id);
            if (contato == null)
                return NotFound("Contato não encontrado.");
            return Ok(contato);
        }

        // PUT: api/contato/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Contato contato)
        {
            if (id != contato.Id)
                return BadRequest("Id do contato não confere.");

            await _contatoService.AtualizarContatoAsync(contato);
            return Ok("Contato atualizado com sucesso!");
        }

        // DELETE: api/contato/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _contatoService.RemoverContatoAsync(id);
            return Ok("Contato removido com sucesso!");
        }
    }
}
