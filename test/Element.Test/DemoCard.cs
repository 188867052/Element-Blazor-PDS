﻿using PuppeteerSharp;

namespace IssueManage.Test
{
    public class DemoCard
    {
        public string Title { get; set; }
        public ElementHandle Body { get; set; }

        public Page Page { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
