using API_Assesment.Models;
using API_Assesment.Models.RequestModels;
using API_Assesment.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assesment.Services.Interfaces
{
    public interface IConverterService
    {
        // user details convertions
        IEnumerable<UserDetailsResponseModel> UsersIntoResponse(IEnumerable<UserDetails> entity);
        UserDetails CreateUserReqIntoUser(CreateUserDetailsRequestModel entity);
        UserDetails UpdateUserReqIntoUser(UpdateUserDetailsRequestModel entity);

        // role type convertions
        IEnumerable<RoleTypeResponseModel> RoleTypeIntoResponse(IEnumerable<RoleType> entity);
        RoleType CreateRoleReqTypeIntoRole(CreateRoleTypeRequestModel entity);
        RoleType UpdateRoleTypeReqIntoRole(UpdateRoleTypeRequestModel entity);

        // status convertions
        IEnumerable<StatusResponseModel> StatusReqIntoResponse(IEnumerable<Status> entity);
        Status CreateStatusReqIntoStatus(CreateStatusRequestModel entity);
        Status UpdateStatusReqIntoStatus(UpdateStatusRequestModel entity);

        // password encryption
        string PasswordEncription(string password);
    }
}
