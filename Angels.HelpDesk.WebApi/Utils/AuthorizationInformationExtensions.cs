using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace Angels.HelpDesk.WebApi.Utils
{
    public static class AuthorizationInformationExtensions
    {
        public static (string id, string email) GetUserEmailFromBearerTokenWithId(this HttpRequest req)
        {
            string jwtEncodedString = req.Headers[HeaderNames.Authorization];
            var jwt = new JwtSecurityToken(jwtEncodedString: jwtEncodedString[7..]);
            string email = jwt?.Claims?.FirstOrDefault(type => type.Type == "emails")?.Value;
            string id = jwt?.Claims?.FirstOrDefault(type => type.Type == JwtRegisteredClaimNames.Sub)?.Value;
            return (id, email);
        }
        public static (string name, string id) GetUserFromBearerToken(this HttpRequest req)
        {
            string jwtEncodedString = req.Headers[HeaderNames.Authorization];
            var jwt = new JwtSecurityToken(jwtEncodedString: jwtEncodedString[7..]);
            string name = jwt?.Claims?.FirstOrDefault(type => type.Type == JwtRegisteredClaimNames.Name)?.Value;
            string id = jwt?.Claims?.FirstOrDefault(type => type.Type == JwtRegisteredClaimNames.Sub)?.Value;
            return (name, id);
        }
        public static string GetUserIdFromBearerToken(this HttpRequest req)
        {
            string jwtEncodedString = req.Headers[HeaderNames.Authorization];
            var jwt = new JwtSecurityToken(jwtEncodedString: jwtEncodedString[7..]);
            string id = jwt?.Claims?.FirstOrDefault(type => type.Type == JwtRegisteredClaimNames.Sub)?.Value;
            return id;
        }
    }
}
