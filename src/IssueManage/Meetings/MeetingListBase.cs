using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Element;
using IssueManage.Meetings;

namespace IssueManage
{
    public class MeetingListBase : BAdminPageBase
    {
        protected List<MeetingGridModel> Models { get; private set; } = new List<MeetingGridModel>();

        [Inject]
        public MeetingService MeetingService { get; set; }

        protected BTable table;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        public async Task CreateAsync()
        {
            await JSRuntime.HrefBlankAsync("/meeting/create");
        }

        private async Task RefreshAsync()
        {
            if (table == null) return;

            Models = (await MeetingService.GetAll()).Select(o => new MeetingGridModel
            {
                Id = o.Id,
                Topic = o.Topic,
                Content = o.Content,
            }).ToList();
            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        public async Task EditAsync(object user)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(nameof(BMeetingEdit.Model), user);
            await DialogService.ShowDialogAsync<BMeetingEdit>("编辑会议", 800, parameters);
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
            var confirm = await ConfirmAsync("确认删除该客户？");
            if (confirm != MessageBoxResult.Ok) return;

            await MeetingService.DeleteAsync(((MeetingModel)model).Id);
            Toast("删除成功！");
            await RefreshAsync();
        }
    }
}
