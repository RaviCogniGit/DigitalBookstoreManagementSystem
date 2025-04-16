using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalBookstoreManagementSystem.Repositories.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DigitalBookstoreManagementSystemDBContext _context;

        public ReviewRepository(DigitalBookstoreManagementSystemDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserReviewDto>> GetAllReviewsAsync()
        {
            return await _context.Reviews

                .Include(b => b.Book)

                .Select(b => new UserReviewDto
                {
                    BookID = b.BookID,
                    Title = b.Book.Title,
                    Rating = b.Rating,
                    Comment = b.Comment,
                    UserID = b.UserID,
                    ReviewID = b.ReviewID,
                })
                 .ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task UpdateReviewAsync(int id, Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Review>> GetReviewsByBookIdAsync(int BookID)
        {
            return await _context.Reviews.Where(r => r.BookID == BookID).ToListAsync();


        }
        public ICollection<string> GetReviewCommentsBybookId(int BookID)
        {
            // Filter by event ID and non-empty comments, then select the Comments property
            var comments = _context.Reviews
                .Where(f => f.BookID == BookID && !string.IsNullOrEmpty(f.Comment))
                .Select(f => f.Comment) // Select only the Comments field
                .ToList(); // Convert to a List<string>
            return comments;
        }
    }
}

