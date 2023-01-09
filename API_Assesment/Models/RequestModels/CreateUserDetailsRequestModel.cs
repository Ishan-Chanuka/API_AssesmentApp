using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Models.RequestModels
{
    public class CreateUserDetailsRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateofBirth { get; set; }
        public string RoleType { get; set; }
        public string Status { get; set; }
    }
}
