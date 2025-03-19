using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.Services.Interface
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task<Review> AddReviewAsync(ReviewDTO reviewdto);
        Task UpdateReviewAsync(int id, ReviewDTO reviewdto);
        Task DeleteReviewAsync(int id);
    }
}
