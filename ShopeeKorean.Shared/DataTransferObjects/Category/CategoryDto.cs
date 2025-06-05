namespace ShopeeKorean.Shared.DataTransferObjects.Category
{
    public record CategoryDto : BaseDto<CategoryDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
