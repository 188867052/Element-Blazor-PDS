﻿using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Element;

namespace IssueManage
{
    public class EditBase : BAdminPageBase
    {
        internal BForm form;

        [Inject]
        public IssueService IssueService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task RefreshAsync()
        {
            RequireRender = true;
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            //await JSRuntime.HideByIdAsync("el-tabs__nav-scroll");

            if (!firstRender) return;

            await RefreshAsync();
        }

        public async Task SubmitAsync()
        {
            if (!form.IsValid()) return;

            var model = form.GetValue<IssueEditModel>();
            var entity = mapper.Map<IssueEditModel, Issue>(model);
            var result = await AdminDbContext.Issues.AddAsync(entity);
            await AdminDbContext.SaveChangesAsync();
            if (result.IsKeySet)
            {
                Toast("创建成功！");
                NavigationManager.NavigateTo($"/issue/detail?id={result.Entity.Id}");
            }
            else
            {
                Toast("创建失败！");
            }
            await RefreshAsync();
        }
    }
}
