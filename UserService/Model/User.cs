using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace UserService.Model
{
    public class User : Entity
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String City { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public UserType UserType { get; set;  }

}
}
