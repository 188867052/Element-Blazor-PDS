﻿using Element;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace IssueManage
{
    public class BCustomerEditBase : BAdminPageBase
    {
        internal BForm form;
        [Parameter]
        public CustomerModel Model { get; set; }

        [Inject]
        public CustomerService CustomerService { get; set; }

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

            Model = form.GetValue<CustomerModel>();
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
