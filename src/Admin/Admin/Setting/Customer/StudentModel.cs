﻿using Element;
using System;

namespace IssueManage.Pages.Setting.Customer
{
    public class StudentModel
    {
        public int Id { get; set; }

        [TableColumn(Text = "学生名称")]
        public string Name { get; set; }

        [TableColumn(Text = "类型")]
        public string DrugType { get; set; }

        [TableColumn(Text = "数量")]
        public int Amount { get; set; }

        [TableColumn(Text = "价格（￥）", Ignore = true)]
        public decimal Price { get; set; }

        [TableColumn(Text = "价格（￥）")]
        public string PriceString => Price.ToString();

        [TableColumn(Text = "创建时间")]
        public DateTime CreateTime { get; set; }

        [TableColumn(Text = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}
