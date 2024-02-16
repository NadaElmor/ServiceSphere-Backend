using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.APIs.DTOs;
using ServiceSphere.APIs.Errors;
using ServiceSphere.core.Entities.Identity;
using ServiceSphere.core.Entities.Posting;
using ServiceSphere.core.Entities.Services;
using ServiceSphere.core.Entities.Users;
using ServiceSphere.core.Repositeries.contract;
using ServiceSphere.core.Specifications;
using ServiceSphere.repositery.Data;
using System.Security.Claims;

namespace ServiceSphere.APIs.Controllers
{
    public class PostingController : BaseController
    {
        
        private readonly UserManager<AppUser> _userManager;
        private readonly IGenericRepositery<ServicePosting> _servicePostingRepo;
        private readonly IGenericRepositery<ProjectPosting> _projectPostingRepo;
        private readonly IMapper _mapper;
        private readonly ServiceSphereContext _ServiceSphereContext;
        public PostingController(ServiceSphereContext serviceSphereContext, UserManager<AppUser>userManager, IGenericRepositery <ServicePosting> ServicePostingRepo, IGenericRepositery<ProjectPosting> ProjectPostingRepo,IMapper mapper)
        {
            
            _userManager = userManager;
            _servicePostingRepo = ServicePostingRepo;
            _projectPostingRepo = ProjectPostingRepo;
            _mapper = mapper;
            _ServiceSphereContext = serviceSphereContext;
            
        }

        [HttpPost("ServicePosting")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> PostJob([FromBody] ServicePostingDto model)
        {
            // Validate input
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // Get current user
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                  return NotFound(new ApiResponse(404, "Target user not found."));
            }
            // Check if the user exists
            var userExists = await _userManager.FindByIdAsync(model.UserId) != null;
            if (!userExists)
            {
                return NotFound($"User with ID {model.UserId} not found.");
            }

            // Create new service posting
            var servicePosting = new ServicePosting
            {
                Title = model.Title,
                Description = model.Description,
                CategoryId = model.CategoryId,
                userID = model.UserId// Assuming UserId is a foreign key to the ApplicationUser table
            };
            _ServiceSphereContext.ServicePostings.Add(servicePosting);

            // Save changes
            try
            {
                await _ServiceSphereContext.SaveChangesAsync();
                return Ok("Service posted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

       

        [HttpGet("GetAllServicePostings")]
        public async Task<ActionResult<IEnumerable<ServicePostingDto>>> GetServicePostings([FromQuery] PostsSpecParams? @params)
        {
            var spec = new ServicePostingWithCategorySpec(@params);//hycall first ctor create obj of criteria, includes
            var ServicePostings = await _servicePostingRepo.GetAllWithSpecAsync(spec);
            // Retrieve all service postings from the database

            /*var servicePostings = await _ServiceSphereContext.ServicePostings
                .Include(sp => sp.Category) // Include category if needed
                .ToListAsync();*/

            // Map the retrieved service postings to DTOs
            var servicePostingsDto = ServicePostings.Select(sp => new ServicePostingDto
            {
                Title = sp.Title,
                Description = sp.Description,
                CategoryId = sp.CategoryId,
                UserId = sp.userID
                // Map other properties as needed
            });


            return Ok(servicePostingsDto);
        }

        [HttpPost("ProjectPosting")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<ProjectPosting>> PostProject([FromBody] ProjectPostingDto model)
        {
            // Validate input
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get current user
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound(new ApiResponse(404, "Target user not found."));
            }

            // Check if the user exists
            var userExists = await _userManager.FindByIdAsync(model.UserId) != null;
            if (!userExists)
            {
                return NotFound($"User with ID {model.UserId} not found.");
            }

            // Create new project posting
            //var projectPosting = new ProjectPosting
            //{
            //    Title = model.Title,
            //    Description = model.Description,
            //    CategoryId = model.CategoryId,
            //    userID = model.UserId,
            //};

            //map project posting
            var projectPosting= _mapper.Map<ProjectPosting>(model);

            // Retrieve selected subcategories from the database
            var selectedSubCategories = await _ServiceSphereContext.SubCategories
                .Where(sc => model.SelectedSubCategoryIds.Contains(sc.Id))
                .ToListAsync();

            // Associate selected subcategories with the project posting
            projectPosting.SubCategories = selectedSubCategories;

            // Remove assignment of identity column value
            projectPosting.Id = 0; // Assuming 'Id' is the identity column

            // Add the project posting to the context
            _ServiceSphereContext.ProjectPostings.Add(projectPosting);

            // Save changes
            try
            {
                await _ServiceSphereContext.SaveChangesAsync();
               // var MappedProjectPosting=_mapper.Map<ProjectPostingDto>(projectPosting);
                return Ok(projectPosting);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while saving the project: {ex.Message}");
            }
        }

        [HttpGet("ProjectPostings")]
        public async Task<ActionResult<IEnumerable<ProjectPostingDto>>> GetAllProjectPostings([FromQuery] PostsSpecParams? @params)
        {
            try
            {
                // Retrieve all project postings from the main database context
                //  var projectPostings = await _mainDbContext.ProjectPostings.ToListAsync();
                var spec = new ProjectPostingWithCategorySpec(@params);
                var projectPostings=await _projectPostingRepo.GetAllWithSpecAsync(spec);
                var mappedProjectPosts=_mapper.Map<IEnumerable<ProjectPostingDto>>(projectPostings);
                return Ok(mappedProjectPosts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving project postings: {ex.Message}");
            }
        }



        /*[HttpGet("GetAllProjectPostings")]
        public async Task<ActionResult<IEnumerable<ProjectPostingDto>>> GetProjectPostings([FromQuery] PostsSpecParams? @params)
        {
            var spec = new ProjectPostingWithCategorySpec(@params);
            var projectPostings = await _projectPostingRepo.GetAllWithSpecAsync(spec);

            var projectPostingsDto = projectPostings.Select(sp => new ProjectPostingDto
            {
                Title = sp.Title,
                Description = sp.Description,
                CategoryId = sp.CategoryId,
                UserId = sp.userID,
                // Map other properties as needed
                SelectedSubCategoryIds = sp.SubCategories.Select(sc => sc.Id).ToList(),
                SelectedSubCategories = sp.SubCategories.Select(sc => new SubCategoryDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    //CategoryId = sc.CategoryId
                    // Map other properties as needed
                }).ToList()
            });

            return Ok(projectPostingsDto);
        }
        */

    }
}

