using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Model.dto
{
    public class ResponseLog
    {
       public string token { get; set; }

       public UserType role { get; set; }
    }
}
