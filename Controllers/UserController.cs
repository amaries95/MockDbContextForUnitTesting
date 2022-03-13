using Microsoft.AspNetCore.Mvc;
using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Domain.Entities;
using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Domain.Repositories;

namespace MockDbContextForUnitTesting.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var response = _userRepository.GetUserById(id);

            return Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> Add(User user)
        {
            _userRepository.AddNewUser(user);

            return Ok();
        }
    }
}
