namespace ApiDelfin.DTOs.Auth
{
    public class UpdateUserRequestDTO
    {
        public string Dni { get; set; } = null!;
        public string? Name { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
