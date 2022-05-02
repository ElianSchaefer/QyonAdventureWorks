using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QyonAdventureWorks.Shared.Model;

namespace QyonAdventureWorks.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PistaController : ControllerBase
    {
        private readonly DataContext _context;

        public PistaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PistaModel>>> ListarPistas()
        {
            var pistas = await _context.Pistas.ToListAsync();
            return Ok(pistas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PistaModel>> ObterPistaPorId(int id)
        {
            var pistas = await _context.Pistas
                .FirstOrDefaultAsync(x => x.Id == id);
            if (pistas == null)
            {
                return NotFound("Desculpe, Pista não encontrado!");
            }
            return Ok(pistas);
        }

         [HttpPost]
        public async Task<ActionResult<List<PistaModel>>> Criarpista(PistaModel pista)
        {

            _context.Pistas.Add(pista);
            await _context.SaveChangesAsync();


            return Ok(await GetDbPistas());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<PistaModel>>> EditarPista(PistaModel pista, int id)
        {
            var dbPista = await _context.Pistas
                .FirstOrDefaultAsync(x => x.Id == id);
            if (dbPista == null)
            {
                return NotFound("Descupe, Histótico não encontrado!");
            }

            dbPista.Descricao = pista.Descricao;
            
           
            await _context.SaveChangesAsync();

            return Ok(await GetDbPistas());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PistaModel>>> DeletarPista(int id)
        {
            var dbPista = await _context.Pistas
                .FirstOrDefaultAsync(x => x.Id == id);
            if (dbPista == null)
            {
                return NotFound("Descupe, histórico não encontrado!");
            }

            _context.Pistas.Remove(dbPista);

            await _context.SaveChangesAsync();

            return Ok(await GetDbPistas());
        }

        private async Task<List<HistoricoModel>> GetDbPistas()
        {
            return await _context.Historicos.Include(x => x.Id).ToListAsync();
        }
    }
}
