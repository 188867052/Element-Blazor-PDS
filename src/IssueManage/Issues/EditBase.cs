using Microsoft.AspNetCore.Components;
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
                NavigationManager.NavigateTo($"/issue/detail/{result.Entity.Id}");
            }

            await RefreshAsync();
        }
    }
}
