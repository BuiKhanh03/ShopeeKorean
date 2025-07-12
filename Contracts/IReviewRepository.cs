using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IReviewRepository
    {
        public Task CreateReview(Review review);
        public void UpdateReview(Review review);
        public void DeleteReview(Review review);
        public Task<Review?> GetReview(Guid reviewId, bool trackChanges, string? include = null);
    }
}
