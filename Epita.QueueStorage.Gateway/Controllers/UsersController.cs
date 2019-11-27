using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epita.QueueStorage.Logic.Contracts;
using Epita.QueueStorage.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Epita.QueueStorage.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic userLogic;

        public UsersController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            IEnumerable<User> users = await userLogic.GetAsync().ConfigureAwait(false);

            if (users == null)
            {
                return Ok(Enumerable.Empty<User>());
            }

            return Ok(users);
        }
    }
}