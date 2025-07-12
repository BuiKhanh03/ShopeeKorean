namespace ShopeeKorean.Shared.DataTransferObjects.Review
{
    public class ReviewForUpdateDto
    {
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
