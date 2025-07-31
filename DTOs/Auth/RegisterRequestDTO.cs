using System.ComponentModel.DataAnnotations;

namespace ApiDelfin.DTOs.Auth
{
    public class RegisterRequestDTO
    {
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Dni { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public bool IsAdmin { get; set; } = false;
    }
}
