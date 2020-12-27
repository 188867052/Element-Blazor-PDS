using AutoMapper;
using Element.Admin.Abstract;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Element.Admin.Extension;
using Element.Admin.Issues;

namespace Element.Admin
{
    public class IssueManageBase : BAdminPageBase
    {
        protected List<IssueModel> Models { get; private set; } = new List<IssueModel>();
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
            Models = mapper.Map<Entity.Issue, IssueModel>(issues).ToList();

            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        public async Task EditAsync(object model)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(nameof(IssueEdit.Model), model);
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

            await IssueService.DeleteAsync(((IssueModel)user).Id);
            Toast("删除问题成功！");
            await RefreshAsync();
        }
    }
}
