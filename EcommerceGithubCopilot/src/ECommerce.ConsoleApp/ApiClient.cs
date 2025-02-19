using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ECommerce.BLL.DTOs;

namespace ECommerce.ConsoleApp
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetAllProductsResponse> GetAllProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<GetAllProductsResponse>("api/Product");
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Product", request);
            return await response.Content.ReadFromJsonAsync<AddProductResponse>();
        }

        // Aggiungi metodi per UpdateProduct, DeleteProduct, ecc.
    }
}