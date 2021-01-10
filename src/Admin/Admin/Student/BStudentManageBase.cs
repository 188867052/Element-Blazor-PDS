using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using IssueManage.Pages.Abstract;
using Element;
using IssueManage.Pages.Student;

namespace IssueManage.Pages
{
    public class BStudentManageBase : BAdminPageBase
    {
        protected List<StudentModel> Models { get; private set; } = new List<StudentModel>();

        [Inject]
        public IStudentService CustomerService { get; set; }

        protected BTable table;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        public async Task CreateAsync()
        {
            await DialogService.ShowDialogAsync<BStudentEdit>("创建学生信息", 800, new Dictionary<string, object>());
            await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            if (table == null) return;

            Models = (await CustomerService.GetAll()).Select(o => new StudentModel
            {
                Id = o.Id,
                Number = o.Number,
                //Price = o.Price,
                Name = o.Name,
                Sex = o.Sex,
                CreateTime = o.CreateTime,
                UpdateTime = o.UpdateTime,
            }).ToList();
            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        public async Task EditAsync(object user)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(nameof(BStudentEdit.Model), user);
            await DialogService.ShowDialogAsync<BStudentEdit>("编辑药品", 800, parameters);
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
            var confirm = await ConfirmAsync("确认删除？");
            if (confirm != MessageBoxResult.Ok) return;

            await CustomerService.DeleteAsync(((StudentModel)model).Id);
            Toast("删除成功！");
            await RefreshAsync();
        }
    }
}
