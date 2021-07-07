using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        //token kullanıcı kitlesi
        public string Audience { get; set; }
        //imzalayan
        public string Issuer { get; set; }
        //dk cinsinden
        public int AccessTokenExpiration { get; set; }
        
        public string SecurityKey { get; set; }
    }
}
