using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using DigitalBookstoreManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookstoreManagementSystem.Controllers.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReviewDto>>> GetReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(ReviewDTO reviewdto)
        {
            var createdReview = await _reviewService.AddReviewAsync(reviewdto);
            return CreatedAtAction("GetReview", new { id = createdReview.ReviewID }, createdReview);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, ReviewDTO reviewdto)
        {
            if (id != reviewdto.ReviewID)
            {
                return BadRequest();
            }
            try
            {
                await _reviewService.UpdateReviewAsync(id, reviewdto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                await _reviewService.DeleteReviewAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("average-rating")]
        public async Task<ActionResult> GetAverageRatingByBookId(int bookId)
        {
            var averageRating = await _reviewService.GetAverageRatingByBookIdAsync(bookId);
            if (averageRating == null)
            {
                return NotFound(new { message = "No reviews found for this book" });
            }

            return Ok(new { bookId, averageRating });
        }
        [HttpGet]
        [Route("CommentsForSpecificBook/")]
        //[Authorize(Roles = "User")]

        public IActionResult GetReviewComments(int bookId)
        {
            var comments = _reviewService.GetReviewComments(bookId);
            return Ok(comments);
        }


    }
}
