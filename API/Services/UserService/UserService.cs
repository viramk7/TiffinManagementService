using API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiffinManagementService.API.Repository;
using Entities;
using TiffinManagementService.Common;
using System.Data.SqlClient;

namespace API.Services.UserService
{
    public class UserService : IUserService
    {
        #region Initialiazations

        IRepository _repository;
        TiffinManagementServiceEntities _edmx;

        public UserService()
        {
            _repository = new Repository();
            _edmx = new TiffinManagementServiceEntities();
        }
        
        #endregion

        #region methods

        public ApiResponse<UserModel> GetUsersFromRepository(int? userId)
        {
            var response = new ApiResponse<UserModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("UserId",(object)userId ?? DBNull.Value),
                };

                var result = _repository.ExecuteSql<UserModel>("usp_UserMaster_GetUsersFromRepository", paramList).ToList();
                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public ApiResponse<UserModel> GetUsersFromEdmx(int? userId = null)
        {
            var response = new ApiResponse<UserModel>();

            try
            {
                var result = _edmx.UserMasters.Where(w => w.UserId == userId || userId == null)
                    .Select(s=> new UserModel
                    {
                        UserId = s.UserId,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Contact = s.Contact,
                        DefaultTiffinTypeId = s.DefaultTiffinTypeId,
                        Email = s.Email,
                        IsActive = s.IsActive,
                        IsAdmin = s.IsAdmin,
                        IsRegularBM = s.IsRegularBM,
                        UserName = s.UserName
                    }).ToList();

                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message.Add(ex.Message);
            }

            return response;
        }

        #endregion
    }
}