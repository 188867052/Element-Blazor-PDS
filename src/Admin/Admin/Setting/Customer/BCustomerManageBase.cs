using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using IssueManage.Pages.Abstract;
using Element;

namespace IssueManage.Pages.Setting.Customer
{
    public class BCustomerManageBase : BAdminPageBase
    {
        protected List<DrugModel> Models { get; private set; } = new List<DrugModel>();

        [Inject]
        public ICustomerService CustomerService { get; set; }

        protected BTable table;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        public async Task CreateAsync()
        {
            await DialogService.ShowDialogAsync<BCustomerEdit>("创建药品", 800, new Dictionary<string, object>());
            await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            if (table == null) return;

            Models = (await CustomerService.GetAll()).Select(o => new DrugModel
            {
                Id = o.Id,
                Amount = o.Amount,
                Price = o.Price,
                Name = o.Name,
                Description = o.Description,
                CreateTime = o.CreateTime,
                UpdateTime = o.UpdateTime,
            }).ToList();
            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        public async Task EditAsync(object user)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(nameof(BCustomerEdit.Model), user);
            await DialogService.ShowDialogAsync<BCustomerEdit>("编辑药品", 800, parameters);
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
            var confirm = await ConfirmAsync("确认删除？");
            if (confirm != MessageBoxResult.Ok) return;

            await CustomerService.DeleteAsync(((DrugModel)model).Id);
            Toast("删除成功！");
            await RefreshAsync();
        }
    }
}
