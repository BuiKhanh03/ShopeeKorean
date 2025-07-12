using Microsoft.EntityFrameworkCore;
using Repository;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Repository.Contracts;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Repository
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(RepositoryContext repository) : base(repository)
        {

        }

        public async Task CreateReview(Review review)
       => await CreateAsync(review);

        public void DeleteReview(Review review)
       => Delete(review);

        public async Task<Review?> GetReview(Guid reviewId, bool trackChanges, string? include = null)
        {
            var review = await FindByCondition(r => r.Id.Equals(reviewId), trackChanges).SingleOrDefaultAsync();
            return review;
        }

        public void UpdateReview(Review review)
        => Update(review);

      
    }
}
