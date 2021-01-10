using Element;
using IssueManage.Pages.Abstract;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace IssueManage.Pages.Meetings
{
    public class BScoreEditBase : BAdminPageBase
    {
        internal BForm form;
        [Parameter]
        public ScoreModel Model { get; set; }

        [Inject]
        public IMeetingService MeetingService { get; set; }

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

            Model = form.GetValue<ScoreModel>();
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
