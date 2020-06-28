using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RichBrains.Web.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "RichBrains";
        public const string AUDIENCE = "RichBrains";
        const string KEY = "mysupersecret_secretkey!123";   
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
