using Platzi_Blazor.Models.Products;
using System.Net.Http.Json;
using System.Text.Json;
namespace Platzi_Blazor;
public class CategoryService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;
    public CategoryService(HttpClient httpClient, JsonSerializerOptions options)
    {
        _httpClient = httpClient;
        _options = options;
    }
    public async Task<List<Category>?> Get()
    {
        var result = await _httpClient.GetAsync("/v1/categories");
        return await JsonSerializer.DeserializeAsync<List<Category>>(await result.Content.ReadAsStreamAsync());
    }
    public async Task Create(Category category)
    {
        var result = await _httpClient.PostAsync("/v1/categories", JsonContent.Create(category));
        var content = await result.Content.ReadAsStringAsync();
        if(!result.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }
}