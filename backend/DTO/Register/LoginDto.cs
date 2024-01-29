using System.ComponentModel.DataAnnotations;

namespace backend.DTO.Register;

public class LoginDto
{
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
}

