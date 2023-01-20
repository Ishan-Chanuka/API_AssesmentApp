using API_Assesment.Models.RequestModels;
using API_Assesment.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Services.Interfaces
{
    public interface ILoginService
    {
        LoginResponseModel Login(LoginRequestModel entity);
    }
}
