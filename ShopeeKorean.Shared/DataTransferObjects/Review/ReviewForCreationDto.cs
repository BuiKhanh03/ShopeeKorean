namespace ShopeeKorean.Shared.DataTransferObjects.Review
{
    public class ReviewForCreationDto
    {
        public Guid ProductId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
