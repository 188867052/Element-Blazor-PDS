using Element;
using IssueManage.Pages.Abstract;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace IssueManage.Pages
{
    public class BStudentEditBase : BAdminPageBase
    {
        internal BForm form;
        [Parameter]
        public StudentModel Model { get; set; }

        [Inject]
        public IStudentService StudentService { get; set; }

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

            Model = form.GetValue<StudentModel>();
            if (isCreate)
            {
                await StudentService.AddAsync(Model);
            }
            else
            {
                await StudentService.UpdateAsync(Model);
            }
            await DialogService.CloseDialogAsync(this, (object)null);
        }
    }
}
