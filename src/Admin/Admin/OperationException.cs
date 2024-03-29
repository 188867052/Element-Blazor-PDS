﻿using System;

namespace IssueManage.Pages
{
    /// <summary>
    /// 当用户操作引发业务异常时触发，异常消息将显示给用户
    /// </summary>
    public class OperationException : Exception
    {
        public OperationException(string message) : base(message)
        {

        }
    }
}
