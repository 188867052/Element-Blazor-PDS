using Element;
using IssueManage.Pages.Abstract;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace IssueManage.Pages.Setting.Customer
{
    public class BCustomerEditBase : BAdminPageBase
    {
        internal BForm form;
        [Parameter]
        public DrugModel Model { get; set; }

        [Inject]
        public ICustomerService CustomerService { get; set; }

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

            Model = form.GetValue<DrugModel>();
            if (isCreate)
            {
                await CustomerService.AddAsync(Model);
            }
            else
            {
                await CustomerService.UpdateAsync(Model);
            }
            await DialogService.CloseDialogAsync(this, (object)null);
        }
    }
}
