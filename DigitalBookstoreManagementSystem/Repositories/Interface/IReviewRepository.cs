using DigitalBookstoreManagementSystem.Models;

namespace DigitalBookstoreManagementSystem.Repositories.Interface
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task<Review> AddReviewAsync(Review review);
        Task UpdateReviewAsync(int id, Review review);
        Task DeleteReviewAsync(int id);
        Task<IEnumerable<Review>> GetReviewsByBookIdAsync(int BookID);
        ICollection<String> GetReviewCommentsBybookId(int BookID);


    }
}
