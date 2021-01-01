using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Element;

namespace IssueManage
{
    public class DetailBase : BAdminPageBase
    {
        internal BForm form;

        internal IssueEditModel Model;

        [Inject]
        public IssueService IssueService { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var entity = this.AdminDbContext.Issues.Find(Id);
            Model = mapper.Map<IssueEditModel>(entity);
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
            if (result.IsKeySet)
            {
                Toast("创建成功！");
                await JSRuntime.HrefBlankAsync($"/issue/detail?id={result.Entity.Id}");
            }
            else
            {
                Toast("创建失败！");
            }
            await RefreshAsync();
        }
    }
}
