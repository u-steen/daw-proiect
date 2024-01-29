using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace backend.Models;

[Table("AppUsers")]
public class AppUser : IdentityUser
{

}
