using Element;
using IssueManage.Pages.Abstract;
using IssueManage.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace IssueManage.Pages.Setting.Product
{
    public class BProductEditBase : BAdminPageBase
    {
        internal BForm form;
        [Parameter]
        public ProductModel Model { get; set; }

        [Inject]
        public ProductService ProductService { get; set; }

        [Parameter]
        public DialogOption Dialog { get; set; }
        private bool isCreate;
        protected override void OnInitialized()
        {
            base.OnInitialized();
            isCreate = Model == null;
        }

        public async Task SubmitAsync()
        {
            if (!form.IsValid()) return;

            Model = form.GetValue<ProductModel>();
            if (isCreate)
            {
                await ProductService.AddAsync(Model);
            }
            else
            {
                await ProductService.UpdateAsync(Model);
            }
            await DialogService.CloseDialogAsync(this, (object)null);
        }
    }
}
