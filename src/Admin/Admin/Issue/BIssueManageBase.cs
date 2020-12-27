using Element.Admin.Issue;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Element.Admin
{
    public class BIssueManageBase : BAdminPageBase
    {
        protected List<UserModel> Users { get; private set; } = new List<UserModel>();
        internal bool CanCreate { get; private set; }
        internal bool CanUpdate { get; private set; }
        internal bool CanDelete { get; private set; }

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
            if (table == null)
            {
                return;
            }
            Users = await UserService.GetUsersAsync();
            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        public async Task EditAsync(object user)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(nameof(BIssueEdit.EditingUser), user);
            await DialogService.ShowDialogAsync<BIssueEdit>("编辑问题", 800, parameters);
            await RefreshAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!firstRender)
            {
                return;
            }
            await RefreshAsync();
        }

        public async Task Del(object user)
        {
            var confirm = await ConfirmAsync("确认删除该用户？");
            if (confirm != MessageBoxResult.Ok)
            {
                return;
            }
            var result = await UserService.DeleteUsersAsync(((UserModel)user).Id);
            if (string.IsNullOrWhiteSpace(result))
            {
                return;
            }
            await RefreshAsync();
        }
    }
}
