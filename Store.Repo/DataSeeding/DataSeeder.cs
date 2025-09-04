using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Models;
using Store.Domain.Models.Order_Models;
namespace Store.Repo.DataSeeding
{
    public class DataSeeder
    {
        private readonly StoreContext _context;
        private readonly string _webRootPath;

        public DataSeeder(StoreContext context, string webRootPath)
        {
            _context = context;
            _webRootPath = webRootPath;
        }

        public async Task SeedAsync()
        {

            if (!_context.Category.Any())
            {
                await SeedCategoriesFromJson();
                // repeated this code to avoide the issue of conflicting between images and products

            }




            if (!_context.Product.Any())
            {
                await SeedProductsFromJson();

            }



            if (!_context.Images.Any())
            {
                await SeedProductImagesFromFolders();

            }


            if (!_context.DeliveryMethods.Any())
            {
                await SeedDeliveryMethodsFromJson();

            }

            await _context.SaveChangesAsync();
        }




        private async Task SeedProductsFromJson()
        {
            var path = Path.Combine(_webRootPath, "Products_Data", "Data.json");

            if (!File.Exists(path)) return;

            var jsonData = await File.ReadAllTextAsync(path);

            var products = JsonSerializer.Deserialize<List<Product>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (products != null)
            {
                await _context.Product.AddRangeAsync(products);
            }
        }



        private async Task SeedProductImagesFromFolders()
        {
            var path = Path.Combine(_webRootPath, "Products_Data", "product_images.json");

            if (!File.Exists(path)) return;

            var jsonData = await File.ReadAllTextAsync(path);

            var images = JsonSerializer.Deserialize<List<Images>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (images != null)
            {
                await _context.Images.AddRangeAsync(images);
            }

        }




        private async Task SeedCategoriesFromJson()
        {
            var path = Path.Combine(_webRootPath, "Products_Data", "Categories.json");

            if (!File.Exists(path)) return;

            var jsonData = await File.ReadAllTextAsync(path);

            var categories = JsonSerializer.Deserialize<List<Category>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (categories != null)
            {
                await _context.Category.AddRangeAsync(categories);
            }
        }

        private async Task SeedDeliveryMethodsFromJson()
        {
            var path = Path.Combine(_webRootPath, "Products_Data", "delivery.json");
            if (!File.Exists(path)) return;

            var jsonData = await File.ReadAllTextAsync(path);

            var DeliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (DeliveryMethods != null)
            {
                await _context.DeliveryMethods.AddRangeAsync(DeliveryMethods);
            }
        }
    }
}
