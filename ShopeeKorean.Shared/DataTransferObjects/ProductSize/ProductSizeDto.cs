namespace ShopeeKorean.Shared.DataTransferObjects.ProductSize
{
    public record ProductSizeDto : BaseDto<ProductSizeDto>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Size { get; set; } = string.Empty;
    }
}
