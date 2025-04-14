using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem.Services.Service.CRUDService
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _reviewRepository.GetAllReviewsAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _reviewRepository.GetReviewByIdAsync(id);
        }

        public async Task<Review> AddReviewAsync(ReviewDTO reviewdto)
        {
            var review = new Review
            {
                ReviewID = reviewdto.ReviewID,
                Rating = reviewdto.Rating,
                Comment = reviewdto.Comment,
                BookID = reviewdto.BookID,
                UserID = reviewdto.UserID,
            };
            return await _reviewRepository.AddReviewAsync(review);
        }

        public async Task UpdateReviewAsync(int id, ReviewDTO reviewdto)
        {
            var review = new Review
            {
                ReviewID = reviewdto.ReviewID,
                Rating = reviewdto.Rating,
                Comment = reviewdto.Comment,
                BookID = reviewdto.BookID,
                UserID = reviewdto.UserID,
            };
            await _reviewRepository.UpdateReviewAsync(id, review);
        }

        public async Task DeleteReviewAsync(int id)
        {
            await _reviewRepository.DeleteReviewAsync(id);
        }

        public async Task<double?> GetAverageRatingByBookIdAsync(int BookID)
        {
            var reviews = await _reviewRepository.GetReviewsByBookIdAsync(BookID);
            if (reviews == null || !reviews.Any())
            {
                return null; // No reviews found
            }

            double averageRating = reviews.Average(r => r.Rating);
            return averageRating;
        }

        public ICollection<string> GetReviewComments(int BookID)
        {
            // Fetch all Comments in var comments
            var comments = _reviewRepository.GetReviewCommentsBybookId(BookID);
            return comments;
        }
    }
}

