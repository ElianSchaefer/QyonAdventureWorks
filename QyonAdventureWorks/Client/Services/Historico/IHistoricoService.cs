namespace QyonAdventureWorks.Client.Services.HistoricoService
{
    public interface IHistoricoService
    {
        List<HistoricoModel> Historico { get; set; }

        Task ListarHistorico();

        Task<HistoricoModel> ObterHistoricoById(int id);
        Task EditarHistorico(HistoricoModel historico);
        Task DeletarHistorico(int id);
        Task CriarHistorico(HistoricoModel historico);
    }
}
