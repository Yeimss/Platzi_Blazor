using System.Net.Http.Json;
using System.Text.Json;
namespace Platzi_Blazor;
public class ProductServices
{
    public readonly HttpClient _httpClient;
    public readonly JsonSerializerOptions _options;
    public ProductServices(HttpClient httpClient, JsonSerializerOptions options)
    {
        _httpClient = httpClient;
        _options = options;
    }
    public async Task<List<Products>?> Get()
    {
        var response = await _httpClient.GetAsync("/v1/products");
        return await JsonSerializer.DeserializeAsync<List<Products>>(await response.Content.ReadAsStreamAsync());
    }
    public async Task Create(Products producto)
    {
        var response = await _httpClient.PostAsync("/v1/products", JsonContent.Create(producto));
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }
}
