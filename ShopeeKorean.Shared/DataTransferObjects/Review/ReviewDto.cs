using ShopeeKorean.Shared.DataTransferObjects.User;

namespace ShopeeKorean.Shared.DataTransferObjects.Review
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public string UserName { get; set; }
        public string UserImageUrl { get; set; }
    }
}
