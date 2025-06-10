namespace ShopeeKorean.Shared.DataTransferObjects.ProductImage
{
    public record ProductDtoForManipulation
    {
        public Guid ProductId { get; set; }
        public string? ImageLink { get; set; } = "N/A";
        public string? ImageId { get; set; } = "N/A";
        public bool IsMain { get; set; }
    }
}
