using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model.dto
{
    public class LoginResponse

    {
        public string idToken { get; set; }
        public UserType userType { get; set; }
    }
}
