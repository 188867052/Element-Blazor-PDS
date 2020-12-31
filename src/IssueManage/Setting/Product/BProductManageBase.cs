using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Element;
using IssueManage.Pages.Enums;
using IssueManage.Pages;
using IssueManage.Setting.Product;

namespace IssueManage
{
    public class BProductManageBase : BAdminPageBase
    {
        protected List<ProductModel> Models { get; private set; } = new List<ProductModel>();
        internal bool CanCreate { get; private set; }
        internal bool CanUpdate { get; private set; }
        internal bool CanDelete { get; private set; }

        [Inject]
        public ProductService ProductService { get; set; }

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
            await DialogService.ShowDialogAsync<BProductEdit>("创建产品", 800, new Dictionary<string, object>());
            await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            if (table == null) return;

            Models = (await ProductService.GetAll()).Select(o => new ProductModel
            {
                Id = o.Id,
                Description = o.Description,
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
            parameters.Add(nameof(BProductEdit.Model), user);
            await DialogService.ShowDialogAsync<BProductEdit>("编辑产品", 800, parameters);
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
            var confirm = await ConfirmAsync("确认删除该产品？");
            if (confirm != MessageBoxResult.Ok) return;

            await ProductService.DeleteAsync(((ProductModel)model).Id);
            Toast("删除成功！");
            await RefreshAsync();
        }
    }
}
