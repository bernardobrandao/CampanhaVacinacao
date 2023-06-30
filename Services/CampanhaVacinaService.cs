using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class CampanhaVacinaService
{
    private readonly HttpClient _httpClient;

    public CampanhaVacinaService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Basic aW11bml6YWNfYnJvd3NlcjpxbHRvNXQmN3JfQCsrVHlsc3RpZ2k=");
    }

    public async Task<int> GetQuantidadeVacinadosPfizerNoRJ(DateTime data)
    {
        string url = $"https://imunizacao-es.saude.gov.br/_search?fabricante_vacina=pfizer&estado=RJ&data_aplicacao={data:yyyy-MM-dd}";

        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var responseObject = JsonDocument.Parse(result);

            int quantidadeVacinados = responseObject.RootElement.GetProperty("hits").GetProperty("total").GetInt32();

            return quantidadeVacinados;
        }

        return 0;
    }
}
