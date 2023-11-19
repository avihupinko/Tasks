using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Interfaces;
using Tasks.Models;

namespace users_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="phone"></param>
        /// <param name="userId"></param>
        /// <param name="limit"></param>
        /// <param name="offeset"></param>
        /// <returns></returns>
        [HttpGet("~/api/Users")]
        public async Task<ActionResult<List<UserLogicModel>>> Get()
        {
            return Ok(await _usersService.Get());
        }
    }
}
