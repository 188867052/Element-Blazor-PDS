﻿using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using IssueManage.Pages.Abstract;
using IssueManage.Pages.Enum;
using IssueManage.Pages.Meetings;
using Element;
using Element.Admin;

namespace IssueManage.Pages.Meetings
{
    public class BMeetingManageBase : BAdminPageBase
    {
        protected List<MeetingModel> Models { get; private set; } = new List<MeetingModel>();
        internal bool CanCreate { get; private set; }
        internal bool CanUpdate { get; private set; }
        internal bool CanDelete { get; private set; }

        [Inject]
        public IMeetingService MeetingService { get; set; }

        protected BTable table;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CanCreate = IsCanAccessAny(AdminResources.CreateUser.ToString());
            CanUpdate = IsCanAccessAny(AdminResources.UpdateUser.ToString());
            CanDelete = IsCanAccessAny(AdminResources.DeleteUser.ToString());
        }

        public async Task CreateAsync()
        {
            await DialogService.ShowDialogAsync<BMeetingEdit>("创建会议", 800, new Dictionary<string, object>());
            await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            if (table == null) return;

            Models = (await MeetingService.GetAll()).Select(o => new MeetingModel
            {
                Id = o.Id,
                Topic = o.Topic,
                Content = o.Content,
                CreateTime = o.CreateTime,
                UpdateTime = o.UpdateTime,
            }).ToList();
            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        public async Task EditAsync(object user)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(nameof(BMeetingEdit.Model), user);
            await DialogService.ShowDialogAsync<BMeetingEdit>("编辑会议", 800, parameters);
            await RefreshAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!firstRender) return;

            await RefreshAsync();
        }

        public async Task Delete(object model)
        {
            var confirm = await ConfirmAsync("确认删除该客户？");
            if (confirm != MessageBoxResult.Ok) return;

            await MeetingService.DeleteAsync(((MeetingModel)model).Id);
            Toast("删除成功！");
            await RefreshAsync();
        }
    }
}
