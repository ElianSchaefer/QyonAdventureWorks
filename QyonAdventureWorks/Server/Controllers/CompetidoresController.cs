using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace QyonAdventureWorks.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetidoresController : ControllerBase
    {
        private readonly DataContext _context;

        public CompetidoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompetidorModel>>> ObterCompetidores()
        {
            var competidores = await _context.Competidores.ToListAsync();
            return Ok(competidores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompetidorModel>> ObterCompetidorPorId(int id)
        {
            var competidor = await _context.Competidores
                .FirstOrDefaultAsync(x => x.Id == id);
            if (competidor == null)
            {
                return NotFound("Desculpe, Competidor não encontrado!");
            }
            return Ok(competidor);
        }


        [HttpPost]
        public async Task<ActionResult<List<CompetidorModel>>> CriarCompetidor(CompetidorModel competidor)
        {

            _context.Competidores.Add(competidor);
            await _context.SaveChangesAsync();


            return Ok(await GetDbCompetidores());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<CompetidorModel>>> EditarCompetidor(CompetidorModel competidor, int id)
        {
            var dbCompetidor = await _context.Competidores
                .FirstOrDefaultAsync(x => x.Id == id);
            if (dbCompetidor == null)
            {
                return NotFound("Descupe, competidor não encontrado!");
            }

            dbCompetidor.Nome = competidor.Nome;
            dbCompetidor.Sexo = competidor.Sexo;
            dbCompetidor.TemperaturaCorporal = competidor.TemperaturaCorporal;
            dbCompetidor.Peso = competidor.Peso;
            dbCompetidor.Altura = competidor.Altura;

            await _context.SaveChangesAsync();

            return Ok(await GetDbCompetidores());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CompetidorModel>>> DeletarCompetidor(int id)
        {
            var dbCompetidor = await _context.Competidores
                .FirstOrDefaultAsync(x => x.Id == id);
            if (dbCompetidor == null)
            {
                return NotFound("Descupe, competidor não encontrado!");
            }

            _context.Competidores.Remove(dbCompetidor);

            await _context.SaveChangesAsync();

            return Ok(await GetDbCompetidores());
        }

        private async Task<List<CompetidorModel>> GetDbCompetidores()
        {
            return await _context.Competidores.Include(x => x.Id).ToListAsync();
        }
    }
}
