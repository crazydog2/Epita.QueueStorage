using System.ComponentModel.DataAnnotations;

namespace Epita.QueueStorage.Gateway.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}