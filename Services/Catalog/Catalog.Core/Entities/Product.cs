using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities {
    public class Product : BaseEntity {
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public ProductBrand Brand { get; set; }
        public ProductType Types { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public string Price { get; set; }

    }
}
