namespace ShopeeKorean.Shared.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public ProductParameters() => OrderBy = "StockQuantity";

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
