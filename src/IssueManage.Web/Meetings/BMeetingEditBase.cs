using Element;
using IssueManage.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace IssueManage
{
    public class BMeetingEditBase : BAdminPageBase
    {
        internal BForm form;
        [Parameter]
        public MeetingModel Model { get; set; }

        [Inject]
        public MeetingService MeetingService { get; set; }

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

            Model = form.GetValue<MeetingModel>();
            if (isCreate)
            {
                await MeetingService.AddAsync(Model);
            }
            else
            {
                await MeetingService.UpdateAsync(Model);
            }
            await DialogService.CloseDialogAsync(this, (object)null);
        }
    }
}
