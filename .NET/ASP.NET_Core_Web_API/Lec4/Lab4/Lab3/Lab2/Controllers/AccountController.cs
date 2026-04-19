using Lab4.DTO.AccountDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lab4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // UserManager is provided by Identity to handle user operations (create, delete, find, etc.)
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration; // To read appsettings.json

        // Inject both UserManager and IConfiguration
        public AccountController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            // 1. Check if the incoming data is valid according to DTO validation rules
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // 2. Create a new IdentityUser object mapped from the DTO
            IdentityUser user = new IdentityUser
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email
            };
            // 3. Attempt to create the user in the database
            // The CreateAsync method automatically hashes the password!
            IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);

            // 4. Check if the creation was successful
            if (result.Succeeded)
            {
                return Ok(new { message = "User registered successfully!" });
            }
            // 5. If it failed (e.g., password too weak, username taken), return the errors
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            // 1. Check if user exists
            IdentityUser? user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if(user == null)
            {
                return Unauthorized("Invalid Username or Password");
            }

            // 2. Check if password is correct
            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!isPasswordValid)
            {
                return Unauthorized("Invalid Username or Password");
            }

            // 3. User is valid! Let's build the Token's Payload (Claims)
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            // If you have roles, you can add them to claims here
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // 4. Get the Secret Key and create the Signature
            string? KeyString = _configuration["Jwt:Key"];
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KeyString));

            // Choose the encryption algorithm
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // 5. Generate the actual Token object
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2), // Token is valid for 2 hours
                signingCredentials: signingCredentials
            );

            // 6. Convert the Token object to a string and return it
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new
            {
                Token = tokenString,
                Expiration = tokenOptions.ValidTo
            });
        }
    }
}
