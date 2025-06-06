namespace ShopeeKorean.Shared.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public ProductParameters() => OrderBy = "StockQuantity";

        public string? SellerId { get; set; } = string.Empty;
        public string? CategoryId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public string Brand { get; set; } = string.Empty;
    }
}
