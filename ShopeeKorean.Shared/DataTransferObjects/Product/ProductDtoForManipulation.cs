namespace ShopeeKorean.Shared.DataTransferObjects.Product
{
    public record ProductDtoForManipulation
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Brand { get; set; } = string.Empty;
    }
}
