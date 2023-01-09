using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Models.ResponseModels
{
    public class StatusResponseModel
    {
        public string StatusID { get; set; }
        public string StatusName { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
    }
}
