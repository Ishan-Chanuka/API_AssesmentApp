using API_Assesment.Models;
using API_Assesment.Models.RequestModels;
using API_Assesment.Models.ResponseModels;
using API_Assesment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API_Assesment.Services
{
    public class ConverterService : IConverterService
    {
        // user details convertions

        public IEnumerable<UserDetailsResponseModel> UsersIntoResponse(IEnumerable<UserDetails> entity)
        {
            var response = new List<UserDetailsResponseModel>();
            var errors = new List<string>();

            foreach (var item in entity)
            {

                try
                {
                    response.Add(new UserDetailsResponseModel
                    {
                        UserID = item.UserID.ToString(),
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Password = item.Password,
                        DateofBirth = item.DateofBirth,
                        RoleType = item.RoleType.ToString(),
                        Status = item.Status.ToString(),
                        CreatedAt = item.CreatedAt.ToString(),
                        ModifiedAt = item.ModifiedAt.ToString()
                    });
                }
                catch (Exception ex)
                {
                    errors.Add($"Error:{ex.Message}");
                }

            }

            return response;
        }

        public UserDetails CreateUserReqIntoUser(CreateUserDetailsRequestModel entity)
        {
            UserDetails response = new UserDetails();
            var errors = new List<string>();

            try
            {
                response.FirstName = entity.FirstName;
                response.LastName = entity.LastName;
                response.Email = entity.Email;
                response.Password = PasswordEncription(entity.Password);
                response.DateofBirth = entity.DateofBirth;
                response.RoleType = int.Parse(entity.RoleType);
                response.Status = int.Parse(entity.Status);
                response.CreatedAt = DateTime.Now;
                response.ModifiedAt = DateTime.Now;
            }
            catch (Exception ex)
            {
                errors.Add($"Error:{ex.Message}");
            }

            return response;
        }

        public UserDetails UpdateUserReqIntoUser(UpdateUserDetailsRequestModel entity)
        {
            UserDetails response = new UserDetails();
            var errors = new List<string>();

            try
            {
                response.UserID = int.Parse(entity.UserID);
                response.FirstName = entity.FirstName;
                response.LastName = entity.LastName;
                response.Email = entity.Email;
                response.Password = entity.Password;
                response.DateofBirth = entity.DateofBirth;
                response.RoleType = int.Parse(entity.RoleType);
                response.Status = int.Parse(entity.Status);
                response.ModifiedAt = DateTime.Now;

            }
            catch (Exception ex)
            {
                errors.Add($"Error:{ex.Message}");
            }


            return response;
        }

        public string PasswordEncription(string password)
        {
            string hashedPassword;

            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                hashedPassword = Convert.ToBase64String(hash);
            }

            return hashedPassword;
        }

        // role type convertions

        public IEnumerable<RoleTypeResponseModel> RoleTypeIntoResponse(IEnumerable<RoleType> entity)
        {
            var response = new List<RoleTypeResponseModel>();
            var errors = new List<string>();

            foreach (var item in entity)
            {
                try
                {
                    response.Add(new RoleTypeResponseModel
                    {
                        RoleID = item.RoleID.ToString(),
                        RoleName = item.RoleName,
                        Status = item.Status.ToString(),
                        CreatedAt = item.CreatedAt.ToString(),
                        ModifiedAt = item.ModifiedAt.ToString()
                    });

                }
                catch (Exception ex)
                {
                    errors.Add($"Error:{ex.Message}");
                }
            }

            return response;
        }

        public RoleType CreateRoleReqTypeIntoRole(CreateRoleTypeRequestModel entity)
        {
            RoleType response = new RoleType();
            var errors = new List<string>();

            try
            {
                response.RoleName = entity.RoleName;
                response.Status = int.Parse(entity.Status);
                response.CreatedAt = DateTime.Now;
                response.ModifiedAt = DateTime.Now;

            }
            catch (Exception ex)
            {
                errors.Add($"Error: {ex.Message}");
            }

            return response;
        }

        public RoleType UpdateRoleTypeReqIntoRole(UpdateRoleTypeRequestModel entity)
        {
            RoleType response = new RoleType();
            var errors = new List<string>();

            try
            {
                response.RoleID = int.Parse(entity.RoleID);
                response.RoleName = entity.RoleName;
                response.Status = int.Parse(entity.Status);
                response.ModifiedAt = DateTime.Now;
            }
            catch (Exception ex)
            {
                errors.Add($"Error: {ex.Message}");
            }
            

            return response;
        }

        // status convertions

        public IEnumerable<StatusResponseModel> StatusReqIntoResponse(IEnumerable<Status> entity)
        {
            var response = new List<StatusResponseModel>();
            var errors = new List<string>();

            foreach (var item in entity)
            {
                try
                {
                    response.Add(new StatusResponseModel
                    {
                        StatusID = item.StatusID.ToString(),
                        StatusName = item.StatusName,
                        CreatedAt = item.CreatedAt.ToString(),
                        ModifiedAt = item.ModifiedAt.ToString()
                    });
                }
                catch(Exception ex)
                {
                    errors.Add($"Error: {ex.Message}");
                }
            }

            return response;
        }

        public Status CreateStatusReqIntoStatus(CreateStatusRequestModel entity)
        {
            Status response = new Status();
            var errors = new List<string>();

            try
            {
                response.StatusName = entity.StatusName;
                response.CreatedAt = DateTime.Now;
                response.ModifiedAt = DateTime.Now;
            }
            catch(Exception ex)
            {
                errors.Add($"Error: {ex.Message}");
            }

            return response;
        }

        public Status UpdateStatusReqIntoStatus(UpdateStatusRequestModel entity)
        {
            Status response = new Status();
            var errors = new List<string>();

            try
            {
                response.StatusID = int.Parse(entity.StatusID);
                response.StatusName = entity.StatusName;
                response.ModifiedAt = DateTime.Now;
            }
            catch(Exception ex)
            {
                errors.Add($"Error: {ex.Message}");
            }

            return response;
        }
    }
}
