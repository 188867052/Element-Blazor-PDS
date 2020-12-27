﻿using Element.Admin.Abstract;
using Element.Admin.Issue;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Element.Admin
{
    public class BIssueManageBase : BAdminPageBase
    {
        protected List<IssueModel> Models { get; private set; } = new List<IssueModel>();
        internal bool CanCreate { get; private set; }
        internal bool CanUpdate { get; private set; }
        internal bool CanDelete { get; private set; }

        [Inject]
        public IIssueService IssueService { get; set; }

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
            await DialogService.ShowDialogAsync<BIssueEdit>("创建问题", 800, new Dictionary<string, object>());
            await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            if (table == null) return;

            Models = (await IssueService.GetAll()).Select(o => new IssueModel
            {
                Id = o.Id,
                Name = o.Name,
                Status = o.Status,
                Description = o.Description,
                UpdateTime = o.UpdateTime,
                CreateTime = o.CreateTime,
            }).ToList();
            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        public async Task EditAsync(object model)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(nameof(BIssueEdit.Model), model);
            await DialogService.ShowDialogAsync<BIssueEdit>("编辑问题", 800, parameters);
            await RefreshAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!firstRender) return;

            await RefreshAsync();
        }

        public async Task Delete(object user)
        {
            if (await ConfirmAsync("确认删除该问题？") != MessageBoxResult.Ok) return;

            await IssueService.DeleteAsync(((IssueModel)user).Id);
            Toast("删除问题成功！");
            await RefreshAsync();
        }
    }
}
