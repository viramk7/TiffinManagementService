using Common.WebClient;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TiffinManagementService.Common;

namespace App.Controllers
{
    public class UserController : Controller
    {
        WebClientHelper _client;

        public UserController()
        {
            _client = WebClientHelper.Instance;
        }

        public async Task<ActionResult> Index()
        {
            var userList = new List<UserModel>();

            var url = "api/GetUsersFromRepository";
            var result = await _client.GetRequest(new ApiResponse<UserModel>(), url);
            if (result.Success)
            {
                userList = result.Data.ToList();
            }

            return View(userList);
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var userObj = new UserModel();

            var url = "api/GetUsersFromRepository?userId=" + id;
            var result = await _client.GetRequest(new ApiResponse<UserModel>(), url);
            if (result.Success)
            {
                userObj = result.Data.FirstOrDefault();
            }

            return View(userObj);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public async Task<ActionResult> Create(UserModel userModel)
        {
            try
            {
                var url = "api/CreateNewUser";
                var result = new BaseApiResponse();
                result = await _client.PostRequest<BaseApiResponse, UserModel>(userModel, url);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
