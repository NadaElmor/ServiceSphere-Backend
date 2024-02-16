using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceSphere.APIs.DTOs;
using ServiceSphere.APIs.Errors;
using ServiceSphere.APIs.Extensions;
using ServiceSphere.core.Entities.Identity;
using ServiceSphere.core.Entities.Users;
using ServiceSphere.core.Services.contract;
using System.Security.Claims;

namespace ServiceSphere.APIs.Controllers
{
    
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager, IAuthService authService,IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            var User = await _userManager.FindByEmailAsync(model.Email);
            if (User == null) { return Unauthorized(new ApiResponse(401)); }
            //takes user and password, checks pass to sign in if true
            var result = await _signInManager.CheckPasswordSignInAsync(User, model.Password, false);//false>> i don't want to lock acc if pass is false
            if (!result.Succeeded) { return Unauthorized(new ApiResponse(401)); }
            return Ok(new UserDto()
            {
                DisplayName = User.DisplayName,
                Email = User.Email,
                Token = await _authService.CreateTokenAsync(User, _userManager)
            }) ;;


        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto model) //recieves obj of registerDto, return obj of userDto
        {
            if (CheckEmailExists(model.Email).Result.Value) { return BadRequest(new ApiResponse(400, "this email already exists")); }

            var User = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                PhoneNumber = model.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(User, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }

            //roles
            var roleResult = await _userManager.AddToRoleAsync(User, model.Role); // Ensure `model` includes a Role property
            if (!roleResult.Succeeded)
            {
                return BadRequest(new ApiResponse(400, "Failed to assign user role"));
            }

            var ReturnedUser = new UserDto()
            {
                DisplayName = User.DisplayName,
                Email = User.Email,
                Token = await _authService.CreateTokenAsync(User, _userManager)
            };
            return Ok(ReturnedUser);
        }

        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>> CheckEmailExists(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        [HttpGet]
        [Route("freelancers")]
        public async Task<IActionResult> GetFreelancers()
        {
            var usersInFreelancerRole = await _userManager.GetUsersInRoleAsync("Freelancer");
            // Optionally, transform users to a DTO to avoid sending sensitive data
            return Ok(usersInFreelancerRole);
        }

        [HttpGet]
        [Route("clients")]
        public async Task<IActionResult> GetClients()
        {
            var usersInClientRole = await _userManager.GetUsersInRoleAsync("Client");
            // Optionally, transform users to a DTO to avoid sending sensitive data
            return Ok(usersInClientRole);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _authService.CreateTokenAsync(user, _userManager)
            });
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("Address")]
        public async Task<ActionResult<AddressDto>> UpdateAddress(AddressDto model)
        {
            var user = await _userManager.FindUserWithAddressAsync(User);
            model.Id = user.Address.Id;
            var mappedAddress = _mapper.Map<Address>(model);

            user.Address = mappedAddress;
            var Result = await _userManager.UpdateAsync(user);
            if (!Result.Succeeded) return BadRequest(new ApiResponse(400, "Failed to update the address"));

            return Ok(model);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var user = await _userManager.FindUserWithAddressAsync(User);
            var MappedAddress = _mapper.Map<AddressDto>(user.Address);
            if (MappedAddress is null) return NotFound(new ApiResponse(404, "Address is not found"));
            return MappedAddress;
        }
    }
}
