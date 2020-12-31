using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Element;
using IssueManage.Services;

namespace IssueManage.Pages.Issues
{
    public class EditBase : BAdminPageBase
    {
        internal BForm form;

        [Inject]
        public IssueService IssueService { get; set; }

        [Inject]
        public IMapper mapper { get; set; }

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
            await JSRuntime.HideByIdAsync("el-tabs__nav-scroll");

            if (!firstRender) return;

            await RefreshAsync();
        }

        public async Task SubmitAsync()
        {
            if (!form.IsValid()) return;

            var model = form.GetValue<IssueEditModel>();
            await RefreshAsync();
        }
    }
}
