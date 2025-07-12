using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.Constant.Cart;
using ShopeeKorean.Shared.DataTransferObjects.Cart;
using ShopeeKorean.Shared.DataTransferObjects.Review;
using ShopeeKorean.Shared.Extension;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public ReviewService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<ReviewDto>> CreateReview(ReviewForCreationDto reviewDto, Guid userId, bool trackChanges, string? include = null)
        {
            var reviewEntity = _mapper.Map<Review>(reviewDto);
            reviewEntity.UserId = userId;
            reviewEntity.CreateAt = DateTime.UtcNow;
            await _repositoryManager.ReviewRepository.CreateReview(reviewEntity);
            await _repositoryManager.SaveAsync();
            var reviewReturned = _mapper.Map<ReviewDto>(reviewEntity);
            return Result<ReviewDto>.Ok(reviewReturned);
        }

        public async Task<Result> DeleteReview(Guid reviewId, bool trackChanges)
        {
            var reviewResult = await this.GetAndCheckReview(reviewId, trackChanges);
            if (!reviewResult.IsSuccess) return Result.BadRequest(reviewResult.Errors!);
            _repositoryManager.ReviewRepository.DeleteReview(reviewResult.GetValue<Review>());
            await _repositoryManager.SaveAsync();
            return Result.NoContent();
        }

        public async Task<Result> UpdateReview(ReviewForUpdateDto reviewDto, Guid cartItemId, bool trackChanges, string? include = null)
        {
            var reviewResult = await this.GetAndCheckReview(cartItemId, trackChanges);
            if (!reviewResult.IsSuccess) return Result.BadRequest(reviewResult.Errors!);
            var reviewEntity = reviewResult.GetValue<Review>();
            var review = _mapper.Map(reviewDto, reviewEntity);
            _repositoryManager.ReviewRepository.UpdateReview(review);
            await _repositoryManager.SaveAsync();
            return Result.NoContent();
        }

        private async Task<Result<Review>> GetAndCheckReview(Guid reviewId, bool trackChanges, string? include = default)
        {
            var review = await _repositoryManager.ReviewRepository.GetReview(reviewId, trackChanges, include);
            if(review == null) return Result<Review>.BadRequest([CartErrors.GetCartItemNotFoundWithId(reviewId)]);
            return Result<Review>.Ok(review);
        }
    }
}
