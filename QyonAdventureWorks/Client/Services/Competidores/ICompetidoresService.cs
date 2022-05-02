namespace QyonAdventureWorks.Client.Services.CompetidoresService
{
    public interface ICompetidoresService
    {
        List<CompetidorModel> Competidores { get; set; }

        Task ListarCompetidor();

        Task<CompetidorModel> ObterCompetidorById(int id);

        Task CriarCompetidor(CompetidorModel competidor);
        Task EditarCompetidor(CompetidorModel competidor);
        Task DeletarCompetidor(int id);
    }
}

