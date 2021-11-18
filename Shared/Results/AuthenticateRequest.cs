using System.ComponentModel.DataAnnotations;

namespace Shared.Results
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password {  get; set; }
    }
}
