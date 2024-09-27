using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data {
    public static class typecontextSeed {
        public static void SeedData(IMongoCollection<ProductType> TypeCollection) {
            bool checkTypes = TypeCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "types.json");
            if (!checkTypes) {
                var typesData = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (types != null) {
                    foreach (ProductType type in types) {
                        TypeCollection.InsertOneAsync(type);
                    }
                }
            }
        }
    }
}