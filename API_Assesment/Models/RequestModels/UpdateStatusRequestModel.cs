using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Models.RequestModels
{
    public class UpdateStatusRequestModel
    {
        public string StatusID { get; set; }
        public string StatusName { get; set; }
    }
}
