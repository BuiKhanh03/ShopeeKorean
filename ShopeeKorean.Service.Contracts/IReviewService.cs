using ShopeeKorean.Shared.DataTransferObjects.Review;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service.Contracts
{
    public interface IReviewService
    {
        public Task<Result> UpdateReview(ReviewForUpdateDto cartItemDto, Guid cartItemId, bool trackChanges, string? include = default);
        public Task<Result<ReviewDto>> CreateReview(ReviewForCreationDto cartItemDto, Guid userId, bool trackChanges, string? include = default);
        public Task<Result> DeleteReview(Guid reviewId, bool trackChanges);
    }
}
