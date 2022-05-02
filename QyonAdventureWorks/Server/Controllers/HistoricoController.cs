using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace QyonAdventureWorks.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        private readonly DataContext _context;

        public HistoricoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HistoricoModel>>> ObterHistorico()
        {
            var historicos = await _context.Historicos.ToListAsync();
            return Ok(historicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoModel>> ObterHistoricoPorId(int id)
        {
            var historico = await _context.Historicos.FirstOrDefaultAsync(x => x.Id == id);
            if (historico == null)
            {
                return NotFound("Desculpe, Histórico não encontrado!");
            }
            return Ok(historico);
        }

        [HttpPost]
        public async Task<ActionResult<List<HistoricoModel>>> CriarHistorico(HistoricoModel historico)
        {

            _context.Historicos.Add(historico);
            await _context.SaveChangesAsync();


            return Ok(await GetDbHistoricos());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<HistoricoModel>>> EditarHistorico(HistoricoModel historico, int id)
        {
            var dbHistorico = await _context.Historicos
                .FirstOrDefaultAsync(x => x.Id == id);
            if (dbHistorico == null)
            {
                return NotFound("Descupe, Histótico não encontrado!");
            }

            dbHistorico.CompetidorId = historico.CompetidorId;
            dbHistorico.PistaId = historico.PistaId;
            dbHistorico.DataCorrida = historico.DataCorrida;
            dbHistorico.TempoGasto = historico.TempoGasto;
           
            await _context.SaveChangesAsync();

            return Ok(await GetDbHistoricos());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CompetidorModel>>> DeletarHistorico(int id)
        {
            var dbHistorico = await _context.Historicos
                .FirstOrDefaultAsync(x => x.Id == id);
            if (dbHistorico == null)
            {
                return NotFound("Descupe, histórico não encontrado!");
            }

            _context.Historicos.Remove(dbHistorico);

            await _context.SaveChangesAsync();

            return Ok(await GetDbHistoricos());
        }

        private async Task<List<HistoricoModel>> GetDbHistoricos()
        {
            return await _context.Historicos.Include(x => x.Id).ToListAsync();
        }
    }
}

