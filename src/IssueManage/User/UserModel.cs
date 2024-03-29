﻿using Element;
using System.Collections.Generic;

namespace IssueManage.Pages.User
{
    public class UserModel
    {
        public string Id { get; set; }
        [TableColumn(Text = "用户名")]
        public string Username { get; set; }

        [TableColumn(Text = "邮箱")]
        public string Email { get; set; }
        public IList<string> RoleIds { get; set; } = new List<string>();
        public string Password { get; set; }
    }
}
