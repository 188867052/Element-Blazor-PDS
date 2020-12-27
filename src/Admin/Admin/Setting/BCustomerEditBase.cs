﻿using Element.Admin.Abstract;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Element.Admin
{
    public class BCustomerEditBase : BAdminPageBase
    {
        internal BForm form;
        [Parameter]
        public CustomerModel Model { get; set; }

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

            Model = form.GetValue<CustomerModel>();
            if (isCreate)
            {
                CustomerService.Add(Model);
            }
            else
            {
                CustomerService.Update(Model);
            }
            await DialogService.CloseDialogAsync(this, (object)null);
        }
    }
}
