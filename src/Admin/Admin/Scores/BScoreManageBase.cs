using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using IssueManage.Pages.Abstract;
using Element;
using IssueManage.Pages.Enums;
using IssueManage.Pages.Scores;

namespace IssueManage.Pages
{
    public class BScoreManageBase : BAdminPageBase
    {
        protected List<ScoreModel> Models { get; private set; } = new List<ScoreModel>();
        internal bool CanCreate { get; private set; }
        internal bool CanUpdate { get; private set; }
        internal bool CanDelete { get; private set; }

        [Inject]
        public IScoreService MeetingService { get; set; }

        protected BTable table;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CanCreate = IsCanAccessAny(AdminResources.CreateUser.ToString());
            CanUpdate = IsCanAccessAny(AdminResources.UpdateUser.ToString());
            CanDelete = IsCanAccessAny(AdminResources.DeleteUser.ToString());
        }

        public async Task CreateAsync()
        {
            await DialogService.ShowDialogAsync<BScoreEdit>("添加学分信息", 800, new Dictionary<string, object>());
            await RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            if (table == null) return;

            Models = (await MeetingService.GetAll()).Select(o => new ScoreModel
            {
                Id = o.Id,
                Name = o.Name,
                ScoreNumber = o.ScoreNumber,
                Remark = o.Remark,
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
            parameters.Add(nameof(BScoreEdit.Model), user);
            await DialogService.ShowDialogAsync<BScoreEdit>("编辑科室", 800, parameters);
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
            var confirm = await ConfirmAsync("确认删除该科室？");
            if (confirm != MessageBoxResult.Ok) return;

            await MeetingService.DeleteAsync(((ScoreModel)model).Id);
            Toast("删除成功！");
            await RefreshAsync();
        }
    }
}
