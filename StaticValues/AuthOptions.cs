using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ShopTemplateAPI
{
    public class AuthOptions
    {
        const string KEY = "iamalongasskeyyoustupididiotswillnevercrackmelmao2";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
