using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epita.QueueStorage.Model;
using Epita.QueueStorage.Services.Contracts;

namespace Epita.QueueStorage.Services
{
    public class UserService : IUserService
    {
        private readonly List<Tuple<User, string>> users;

        public UserService()
        {
            users = new List<Tuple<User, string>>
            {
                Tuple.Create(
                    new User
                    {
                        Id = "user1",
                        Email = "user1@epita.fr",
                        Firstname = "User1",
                        Lastname = "User1",
                        Age = 10,
                        Role = Role.User,
                        TeamIds = new List<Guid>()
                    },
                    "password1"),

                Tuple.Create(
                    new User
                    {
                        Id = "user2",
                        Email = "user2@epita.fr",
                        Firstname = "User2",
                        Lastname = "User2",
                        Age = 20,
                        Role = Role.User,
                        TeamIds = new List<Guid>()
                    },
                    "password2"),

                Tuple.Create(
                    new User
                    {
                        Id = "user3",
                        Email = "user3@epita.fr",
                        Firstname = "User3",
                        Lastname = "User3",
                        Age = 30,
                        Role = Role.User,
                        TeamIds = new List<Guid>()
                    },
                    "password3"),

                Tuple.Create(
                    new User
                    {
                        Id = "user4",
                        Email = "user4@epita.fr",
                        Firstname = "User4",
                        Lastname = "User4",
                        Age = 40,
                        Role = Role.User,
                        TeamIds = new List<Guid>()
                    },
                    "password4"),

                Tuple.Create(
                    new User
                    {
                        Id = "user5",
                        Email = "user5@epita.fr",
                        Firstname = "User5",
                        Lastname = "User5",
                        Age = 50,
                        Role = Role.User,
                        TeamIds = new List<Guid>()
                    },
                    "password5"),
                Tuple.Create(
                    new User
                    {
                        Id = "user6",
                        Email = "user6@epita.fr",
                        Firstname = "User6",
                        Lastname = "User6",
                        Age = 60,
                        Role = Role.User,
                        TeamIds = new List<Guid>()
                    },
                    "password6")
            };
        }

        public Task<string> LoginAsync(string login, string password)
        {
            Tuple<User, string> user = users.FirstOrDefault(t => t.Item1.Email == login);
            
            if (user == null)
            {
                return Task.FromResult((string) null);
            }

            return user.Item2 == password ? Task.FromResult(user.Item1.Id) : Task.FromResult((string)null);
        }

        public Task<IEnumerable<User>> GetAsync(Role? role = null)
        {
            IEnumerable<User> result = users.Select(t => t.Item1).Where(u => u.Role == (role ?? u.Role));

            return Task.FromResult(result);
        }

        public Task<User> GetByIdAsync(string userId)
        {
            return Task.FromResult(users.FirstOrDefault(t => t.Item1.Id == userId)?.Item1);
        }
    }
}