using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Element;
using IssueManage.Pages.Enums;
using IssueManage.Pages;
using IssueManage.Web.Setting.Customer;

namespace IssueManage
{
    public class BCustomerManageBase : BAdminPageBase
    {
        protected List<CustomerModel> Models { get; private set; } = new List<CustomerModel>();
        internal bool CanCreate { get; private set; }
        internal bool CanUpdate { get; private set; }
        internal bool CanDelete { get; private set; }

        [Inject]
        public CustomerService CustomerService { get; set; }

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
            if (table == null) return;

            Models = (await CustomerService.GetAll()).Select(o => new CustomerModel
            {
                Id = o.Id,
                ContactPerson = o.ContactPersion,
                Name = o.Name,
                CreateTime = o.CreateTime,
            }).ToList();
            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        public async Task EditAsync(object user)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(nameof(BCustomerEdit.Model), user);
            await DialogService.ShowDialogAsync<BCustomerEdit>("编辑客户", 800, parameters);
            await RefreshAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!firstRender) return;

            await RefreshAsync();
        }

        public async Task Delete(object model)
        {
            var confirm = await ConfirmAsync("确认删除该客户？");
            if (confirm != MessageBoxResult.Ok) return;

            await CustomerService.DeleteAsync(((CustomerModel)model).Id);
            Toast("删除成功！");
            await RefreshAsync();
        }
    }
}
