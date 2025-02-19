using System;
using System.Net.Http;
using System.Threading.Tasks;
using ECommerce.BLL.DTOs;

namespace ECommerce.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };
            var apiClient = new ApiClient(httpClient);

            Console.WriteLine("E-Commerce Console App");
            Console.WriteLine("1. List all products");
            Console.WriteLine("2. Add a new product");
            Console.WriteLine("Choose an option:");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListAllProducts(apiClient);
                    break;
                case "2":
                    await AddNewProduct(apiClient);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

        private static async Task ListAllProducts(ApiClient apiClient)
        {
            var response = await apiClient.GetAllProductsAsync();
            foreach (var product in response.Products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
        }

        private static async Task AddNewProduct(ApiClient apiClient)
        {
            Console.WriteLine("Enter product name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter product description:");
            var description = Console.ReadLine();
            Console.WriteLine("Enter product price:");
            var price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter category ID:");
            var categoryId = int.Parse(Console.ReadLine());

            var request = new AddProductRequest
            {
                Name = name,
                Description = description,
                Price = price,
                CategoryId = categoryId
            };

            var response = await apiClient.AddProductAsync(request);
            if (response.Success)
            {
                Console.WriteLine("Product added successfully");
            }
            else
            {
                Console.WriteLine("Failed to add product");
            }
        }
    }
}