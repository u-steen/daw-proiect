using backend.Models;

namespace backend.Service.TokenService;

public interface ITokenService
{
   string CreateToken(AppUser user); 
}
