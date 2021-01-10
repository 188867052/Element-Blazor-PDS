using Element;
using IssueManage.Pages.Abstract;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;

namespace IssueManage.Pages
{
    public class BScoreEditBase : BAdminPageBase
    {
        internal BForm form;
        [Parameter]
        public ScoreModel Model { get; set; }

        [Inject]
        public IScoreService ScoreService { get; set; }

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

            Model = form.GetValue<ScoreModel>();

            var student = (await StudentService.GetAll()).FirstOrDefault(o => o.Name == Model.Name);
            if (student == null)
            {
                Toast($"学生{Model.Name}不存在!");
                return;
            }
            Model.StudentId = student.Id;
            if (isCreate)
            {
                await ScoreService.AddAsync(Model);
            }
            else
            {
                await ScoreService.UpdateAsync(Model);
            }
            await DialogService.CloseDialogAsync(this, (object)null);
        }
    }
}
