using System.Threading.Tasks;
using Epita.QueueStorage.Gateway.Requests;
using Epita.QueueStorage.Gateway.Security;
using Epita.QueueStorage.Logic.Contracts;
using Epita.QueueStorage.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Epita.QueueStorage.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly SecurityManager securityManager;
        private readonly IUserLogic userLogic;

        public LoginController(
            SecurityManager securityManager,
            IUserLogic userLogic)
        {
            this.securityManager = securityManager;
            this.userLogic = userLogic;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = await userLogic.LoginAsync(loginRequest.Email, loginRequest.Password).ConfigureAwait(false);

            if (user == null)
            {
                return NotFound();
            }

            await securityManager.SignInAsync(user).ConfigureAwait(false);

            return Ok();
        }
    }
}