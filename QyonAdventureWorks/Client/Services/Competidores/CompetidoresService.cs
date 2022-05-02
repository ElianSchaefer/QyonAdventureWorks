using Microsoft.AspNetCore.Components;

namespace QyonAdventureWorks.Client.Services.CompetidoresService
{
    public class CompetidoresService : ICompetidoresService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public CompetidoresService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }

        public List<CompetidorModel> Competidores { get; set; } = new List<CompetidorModel>();

        public async Task CriarCompetidor(CompetidorModel competidor)
        {
            ValidarTemperatura(competidor.TemperaturaCorporal);
            ValidarSexoCompetidor(competidor.Sexo);
            ValidarPesoEAltura(competidor.Peso, competidor.Altura);
            var result = await _httpClient.PostAsJsonAsync("api/Competidores", competidor);
            await SetCompetidor(result);

        }

        private void ValidarTemperatura(decimal temperaturaCompetidor)
        {
            if (temperaturaCompetidor < 36 || temperaturaCompetidor > 38)
                throw new Exception("Temperatura deve ser maior que 35.9º e menor que 39.1º ");
        }

        private void ValidarPesoEAltura(decimal pesoCompetidor, decimal alturaCompetidor)
        {
            if (pesoCompetidor <= 0)
                throw new Exception("Peso deve ser positivo!");
            if (alturaCompetidor <= 0)
                throw new Exception("Altura deve ser positiva!");

        }

        private void ValidarSexoCompetidor(char sexoCompetidor)
        {
            switch (sexoCompetidor)
            {
                case 'M':
                    break;
                case 'F':
                    break;
                case 'O':
                    break;
                default:
                    throw new Exception("Sexo Inválido!");
            }

        }

        public async Task DeletarCompetidor(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Competidores/{id}");
            await SetCompetidor(result);
        }

        public async Task EditarCompetidor(CompetidorModel competidor)
        {

            ValidarSexoCompetidor(competidor.Sexo);
            ValidarPesoEAltura(competidor.Peso, competidor.Altura);
            ValidarTemperatura(competidor.TemperaturaCorporal);
            var result = await _httpClient.PutAsJsonAsync($"api/Competidores/{competidor.Id}", competidor);
            await SetCompetidor(result);
        }

        public async Task ListarCompetidor()
        {
            var result = await _httpClient.GetFromJsonAsync<List<CompetidorModel>>("api/Competidores");
            if (result != null)
            {
                Competidores = result;
            }
        }

        public async Task<CompetidorModel> ObterCompetidorById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<CompetidorModel>($"api/Competidores/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Competidor não encontrado!");
        }
        private async Task SetCompetidor(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<CompetidorModel>>();
            Competidores = response;
            _navigationManager.NavigateTo("competidores");
        }
    }
}
