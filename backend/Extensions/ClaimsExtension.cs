using System.Security.Claims;

namespace backend.Extensions;
public static class ClaimsExtension
{
    public static string GetUsername(this ClaimsPrincipal user){
        var givenNameClaim = user?.Claims?.SingleOrDefault(x => x.Type
        .Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"));
        return givenNameClaim?.Value ?? string.Empty;
    }
}