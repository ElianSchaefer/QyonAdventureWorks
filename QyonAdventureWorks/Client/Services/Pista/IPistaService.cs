namespace QyonAdventureWorks.Client.Services.PistaService
{
    public interface IPistaService
    {
        List<PistaModel> Pista { get; set; }

        Task ListarPista();

        Task<PistaModel> ObterPistaById(int id);
        Task EditarPista(PistaModel pista);
        Task DeletarPista(int id);
        Task CriarPista(PistaModel pista);
    }
}
