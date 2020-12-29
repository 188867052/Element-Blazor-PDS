using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using IssueManage.Pages.Abstract;
using Element;

namespace IssueManage.Pages.Issues
{
    public class CreateBase : BAdminPageBase
    {
        internal BForm form;

        [Inject]
        public IIssueService IssueService { get; set; }

        [Inject]
        public IMapper mapper { get; set; }

        protected BTable table;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task RefreshAsync()
        {
            if (table == null) return;

            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!firstRender) return;

            await RefreshAsync();
        }

        public async Task SubmitAsync()
        {
            if (await ConfirmAsync("确认删除该问题？") != MessageBoxResult.Ok) return;

            Toast("删除问题成功！");
            await RefreshAsync();
        }
    }
}
