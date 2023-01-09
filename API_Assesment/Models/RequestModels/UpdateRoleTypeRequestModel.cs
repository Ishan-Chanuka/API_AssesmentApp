using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Models.RequestModels
{
    public class UpdateRoleTypeRequestModel
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public string Status { get; set; }
    }
}
