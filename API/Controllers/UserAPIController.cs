using API.Database;
using API.Services.UserService;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TiffinManagementService.API.Repository;
using TiffinManagementService.Common;

namespace API.Controllers
{
    [RoutePrefix("api")]
    public class UserAPIController : ApiController
    {
        IUserService _service;

        public UserAPIController()
        {
            _service = new UserService();
        }

        [HttpGet]
        [Route("GetUsersFromRepository")]
        public ApiResponse<UserModel> GetUsersFromRepository(int? userId = null)
        {
            return _service.GetUsersFromRepository(userId);
        }

        [HttpGet]
        [Route("GetUsersFromEdmx")]
        public ApiResponse<UserModel> GetUsersFromEdmx(int? userId = null)
        {
            return _service.GetUsersFromEdmx(userId);
        }

        [HttpPost]
        [Route("CreateNewUser")]
        public BaseApiResponse CreateNewUser(UserModel model)
        {
            return _service.CreateNewUser(model);
        }

    }
}
