using Platzi_Blazor.Models.Products;
using System.Net.Http.Json;
using System.Text.Json;
namespace Platzi_Blazor;
public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;
    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
    public async Task<List<Category>?> Get()
    {
        var result = await _httpClient.GetAsync("v1/categories");
        var content = await result.Content.ReadAsStringAsync();
        if(!result.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return JsonSerializer.Deserialize<List<Category>>(content, _options);
    }
    public async Task Create(Category category)
    {
        var result = await _httpClient.PostAsync("v1/categories", JsonContent.Create(category));
        var content = await result.Content.ReadAsStringAsync();
        if(!result.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
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

public interface ICategoryService
{
    Task<List<Category>?> Get();
    Task Create(Category category);
}