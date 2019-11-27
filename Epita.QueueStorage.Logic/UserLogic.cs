using System.Collections.Generic;
using System.Threading.Tasks;
using Epita.QueueStorage.Logic.Contracts;
using Epita.QueueStorage.Model;
using Epita.QueueStorage.Services.Contracts;

namespace Epita.QueueStorage.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserService userService;
        
        public UserLogic(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<User> LoginAsync(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            string userId = await userService.LoginAsync(login, password).ConfigureAwait(false);

            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }

            return await userService.GetByIdAsync(userId).ConfigureAwait(false);
        }

        public Task<IEnumerable<User>> GetAsync(Role? role = null) => userService.GetAsync(role);

        public Task<User> GetByIdAsync(string userId) => userService.GetByIdAsync(userId);
    }
}