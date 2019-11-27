using System.Collections.Generic;
using System.Threading.Tasks;
using Epita.QueueStorage.Model;

namespace Epita.QueueStorage.Logic.Contracts
{
    public interface IUserLogic
    {
        /// <summary>
        /// Return the id of the User
        /// </summary>
        /// <param name="login">the email of the user</param>
        /// <param name="password">the password of the user</param>
        /// <returns>The User</returns>
        Task<User> LoginAsync(string login, string password);

        /// <summary>
        /// Retrieve All the users
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAsync(Role? role = null);

        /// <summary>
        /// Get a User by its id
        /// </summary>
        /// <param name="userId">The id of the User</param>
        /// <returns>The User</returns>
        Task<User> GetByIdAsync(string userId);
    }
}