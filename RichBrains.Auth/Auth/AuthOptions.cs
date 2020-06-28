using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RichBrains.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "RichBrains";
        public const string AUDIENCE = "RichBrains";
        const string KEY = "mysupersecret_secretkey!123";   
        public const int LIFETIME = 10;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
