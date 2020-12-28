﻿using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueManage.Pages.Framework.Extension;
using IssueManage.Pages.Abstract;
using IssueManage.Pages.Entity;
using Element;
using IssueManage.Pages.Enums;

namespace IssueManage.Pages.Issues
{
    public class IssueListBase : BAdminPageBase
    {
        protected List<IssueListModel> Models { get; private set; } = new List<IssueListModel>();
        internal bool CanCreate { get; private set; }
        internal bool CanUpdate { get; private set; }
        internal bool CanDelete { get; private set; }

        [Inject]
        public IIssueService IssueService { get; set; }

        [Inject]
        public IMapper mapper { get; set; }

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
            await DialogService.ShowDialogAsync<IssueEdit>("创建问题", 800, new Dictionary<string, object>());
            await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            if (table == null) return;

            var issues = await IssueService.GetAll();
            Models = mapper.Map<Issue, IssueListModel>(issues).ToList();

            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        public async Task EditAsync(int id)
        {
            var parameters = new Dictionary<string, object>();

            var model = (await IssueService.GetAll()).FirstOrDefault(o => o.Id == id);
            parameters.Add(nameof(IssueEdit.Model), new IssueEditModel
            {
                Id = model.Id,
                Description = model.Description,
                ImplementTime = model.ImplementTime,
            });
            await DialogService.ShowDialogAsync<IssueEdit>("编辑问题", 800, parameters);
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

            await IssueService.DeleteAsync(((IssueListModel)user).Id);
            Toast("删除问题成功！");
            await RefreshAsync();
        }
    }
}
