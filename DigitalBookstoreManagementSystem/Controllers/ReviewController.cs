using DigitalBookstoreManagementSystem.DTO;
using DigitalBookstoreManagementSystem.Models;
using DigitalBookstoreManagementSystem.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookstoreManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class ReviewController : ControllerBase
        {
            private readonly IReviewRepository _reviewService;

            public ReviewController(IReviewRepository reviewService)
            {
                _reviewService = reviewService;
            }

            // GET: api/Reviews
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
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
            var review = new Review
            {
                ReviewID = reviewdto.ReviewID,
                Rating = reviewdto.Rating,
                Comment = reviewdto.Comment,
                BookID = reviewdto.BookID,
                UserID = reviewdto.UserID,
            };
                var createdReview = await _reviewService.AddReviewAsync(review);
                return CreatedAtAction("GetReview", new { id = createdReview.ReviewID }, createdReview);
            }

            // PUT: api/Reviews/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutReview(int id, ReviewDTO reviewdto)
            {
            var review = new Review
            {
                ReviewID = reviewdto.ReviewID,
                Rating = reviewdto.Rating,
                Comment = reviewdto.Comment,
                BookID = reviewdto.BookID,
                UserID = reviewdto.UserID,
            };
            if (id != review.ReviewID)
                {
                    return BadRequest();
                }
                try
                {
                    await _reviewService.UpdateReviewAsync(id, review);
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
        }
}
