﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IssueManage.Pages.User;

namespace IssueManage
{
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 执行用户登出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/logout")]
        public async ValueTask<IActionResult> Logout([FromQuery]string callback)
        {
            var err = await userService.LogoutAsync(null, callback);

            if (string.IsNullOrWhiteSpace(err))
            {
                return Redirect(callback ?? "/");
            }
            return BadRequest(err);
        }

        /// <summary>
        /// 执行用户登出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/login")]
        public async ValueTask<IActionResult> Login([FromForm]UserModel user, [FromQuery]string callback)
        {
            var err = await userService.LoginAsync(null, user.Username, user.Password, callback);

            if (string.IsNullOrWhiteSpace(err))
            {
                return Redirect(callback ?? "/");
            }
            return BadRequest(err);
        }
    }
}
