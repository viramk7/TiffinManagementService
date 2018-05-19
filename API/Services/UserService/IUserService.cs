using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiffinManagementService.Common;

namespace API.Services.UserService
{
    public interface IUserService
    {
        ApiResponse<UserModel> GetUsersFromRepository(int? userId);

        ApiResponse<UserModel> GetUsersFromEdmx(int? userId = null);
    }
}
