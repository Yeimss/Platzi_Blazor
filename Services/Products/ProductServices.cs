using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Platzi_Blazor;
public class ProductServices : IProductServices
{
    public readonly HttpClient _httpClient;
    public readonly JsonSerializerOptions _options;
    public ProductServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
    public async Task<List<Product>?> Get()
    {
        var response = await _httpClient.GetAsync("v1/products");
        var content = await response.Content.ReadAsStringAsync();

        if(!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<List<Product>>(content, _options);
    }
    public async Task Create(Product producto)
    {
        var response = await _httpClient.PostAsync("/v1/products", JsonContent.Create(producto));
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }
    public async Task Update(Product producto)
    {
        var response = await _httpClient.PutAsync("/v1/products", JsonContent.Create(producto));

    }
    public async Task Delete(int productId)
    {
        var response = await _httpClient.DeleteAsync($"v1/products/{productId}");
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }
}

public interface IProductServices
{
    Task<List<Product>?> Get();
    Task Create(Product producto);
    Task Delete(int productId);
}