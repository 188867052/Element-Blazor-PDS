using Element.Admin.Setting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Element.Admin
{
    public class BCustomerManageBase : BAdminPageBase
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
            await DialogService.ShowDialogAsync<BCustomerEdit>("创建客户", 800, new Dictionary<string, object>());
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
            parameters.Add(nameof(BCustomerEdit.EditingUser), user);
            await DialogService.ShowDialogAsync<BCustomerEdit>("编辑客户", 800, parameters);
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
            var confirm = await ConfirmAsync("确认删除该客户？");
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
