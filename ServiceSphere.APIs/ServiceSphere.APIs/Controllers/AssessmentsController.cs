using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.APIs.DTOs;
using ServiceSphere.APIs.Errors;
using ServiceSphere.core.Entities.Assessments;
using ServiceSphere.core.Entities.Identity;
using ServiceSphere.core.Entities.Users;
using ServiceSphere.repositery.Data;
using ServiceSphere.services;
using System.Security.Claims;


namespace ServiceSphere.APIs.Controllers
{

    public class AssessmentsController : BaseController
    {
        private readonly NotificationService _notificationService;
        private readonly ServiceSphereContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AssessmentsController(NotificationService notificationService, ServiceSphereContext context, UserManager<AppUser>userManager)
        {
            _notificationService = notificationService;
            _context = context;
            _userManager = userManager;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost ("SendNotification")]
        public async Task<IActionResult> Post([FromBody] CreateNotificationRequest request)
        {
            var targetUser = await _userManager.FindByIdAsync(request.UserId);
            if (targetUser == null)
            {
                return NotFound(new ApiResponse(404, "Target user not found."));
                //return NotFound("Target user not found.");

            }
            await _notificationService.CreateNotificationAsync(request.UserId, request.Message);
            return Ok();
        }

        [HttpPost("PostReview")]
        public async Task<IActionResult> PostReview([FromBody] ReviewDto reviewDto)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the current user's ID
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);

            var targetUser = await _userManager.FindByIdAsync(reviewDto.TargetUserId);
            if (targetUser == null)
            {
                return NotFound(new ApiResponse(404,"Target user not found.")); 
                //return NotFound("Target user not found.");

            }
            var review = new Review
            {
                Description = reviewDto.Description,
                TargetUserId = reviewDto.TargetUserId,
                Rating = reviewDto.Rating,
                ReviewerId = user.Id, // The current user is the reviewer
                Date = DateTime.UtcNow
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Review submitted successfully" });
        }

        [HttpGet("GetReviewsForUser/{userId}")]
        public async Task<IActionResult> GetReviewsForUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is required.");
            }

            // Check if the user exists
            var userExists = await _userManager.FindByIdAsync(userId) != null;
            if (!userExists)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            // Retrieve all reviews for the specified user
            var reviews = await _context.Reviews
                .Where(r => r.TargetUserId == userId)
                .ToListAsync();

            if (reviews == null || reviews.Count == 0)
            {
                return NotFound($"No reviews found for user with ID {userId}.");
            }

            return Ok(reviews);
        }

    }

    public class CreateNotificationRequest
    {
        public string UserId { get; set; }
        public string Message { get; set; }
    }

    

}
