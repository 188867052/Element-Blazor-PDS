using Element;
using IssueManage.Pages.Abstract;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace IssueManage.Pages.Issues
{
    public class IssueEditBase : BAdminPageBase
    {
        internal BForm form;
        private bool isCreate = false;

        [Parameter]
        public IssueGridModel Model { get; set; }

        [Parameter]
        public DialogOption Dialog { get; set; }

        [Inject]
        public IIssueService IssueService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            isCreate = Model == null;
        }

        public async Task SubmitAsync()
        {
            if (!form.IsValid()) return;

            Model = form.GetValue<IssueGridModel>();
            if (isCreate)
            {
                await IssueService.AddAsync(Model);
                Toast("创建问题成功！");
            }
            else
            {
                await IssueService.UpdateAsync(Model);
                Toast("更新问题成功！");
            }

            await DialogService.CloseDialogAsync(this, (object)null);
        }
    }
}
