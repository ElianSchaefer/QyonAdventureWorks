using Microsoft.AspNetCore.Components;

namespace QyonAdventureWorks.Client.Services.HistoricoService
{
    public class HistoricoService : IHistoricoService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public HistoricoService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }

        public List<HistoricoModel> Historico { get; set; } = new List<HistoricoModel>();

        public async Task CriarHistorico(HistoricoModel historico)
        {
            ValidarDataCorrida(historico.DataCorrida);
            var result = await _httpClient.PostAsJsonAsync("api/Historico", historico);
            await SetHistorico(result);

        }

        private void ValidarDataCorrida(DateTime dataCorrida)
        {
            if (dataCorrida > DateTime.Now)
                throw new Exception($"Corrida deve ter data inferio a {DateTime.Now}");
        }

       
        public async Task DeletarHistorico(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Historico/{id}");
            await SetHistorico(result);
        }

        public async Task EditarHistorico(HistoricoModel historico)
        {

            ValidarDataCorrida(historico.DataCorrida);
            var result = await _httpClient.PutAsJsonAsync($"api/Historico/{historico.Id}", historico);
            await SetHistorico(result);
        }


        public async Task ListarHistorico()
        {
            var result = await _httpClient.GetFromJsonAsync<List<HistoricoModel>>("api/Historico");
            if(result != null)
            {
               Historico = result;
            }
        }

        public async Task<HistoricoModel> ObterHistoricoById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<HistoricoModel>($"api/Historico/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Histórico não encontrado!");
        }
        private async Task SetHistorico(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<HistoricoModel>>();
            Historico = response;
            _navigationManager.NavigateTo("hitorico");
        }
    }
}
