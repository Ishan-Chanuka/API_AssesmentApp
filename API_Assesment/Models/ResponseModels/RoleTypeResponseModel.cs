using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Models.ResponseModels
{
    public class RoleTypeResponseModel
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
    }
}
