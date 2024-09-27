using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data {
    internal class CatalogContextSeed {
        public static void SeedData(IMongoCollection<Product> productCollection) {
            bool checkProducts = productCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "products.json");
            if (!checkProducts) {
                var productsData = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products != null) {
                    foreach (Product product in products) {
                        productCollection.InsertOneAsync(product);
                    }
                }
            }
        }
    }
}
