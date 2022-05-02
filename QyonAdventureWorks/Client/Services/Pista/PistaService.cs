using Microsoft.AspNetCore.Components;

namespace QyonAdventureWorks.Client.Services.PistaService
{
    public class PistaService : IPistaService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public PistaService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }

        public List<PistaModel> Pista { get; set; } = new List<PistaModel>();

        public async Task CriarPista(PistaModel pista)
        {
            
            var result = await _httpClient.PostAsJsonAsync("api/Pista", pista);
            await SetPista(result);

        }
        public async Task DeletarPista(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Pista/{id}");
            await SetPista(result);
        }

        public async Task EditarPista(PistaModel pista)
        {

            var result = await _httpClient.PutAsJsonAsync($"api/Pista/{pista.Id}", pista);
            await SetPista(result);
        }


        public async Task ListarPista()
        {
            var result = await _httpClient.GetFromJsonAsync<List<PistaModel>>("api/Pista");
            if (result != null)
            {
                Pista = result;
            }
        }

        public async Task<PistaModel> ObterPistaById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PistaModel>($"api/Pista/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Pista não encontrada!");
        }

        private async Task SetPista(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<PistaModel>>();
            Pista = response;
            _navigationManager.NavigateTo("Pista");
        }
    }
}
