using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Element;
using IssueManage.Pages.Extension;
using IssueManage.Issues;

namespace IssueManage
{
    public class IssueListBase : BAdminPageBase
    {
        internal BForm form;
        protected IEnumerable<IssueGridModel> Models { get; private set; } = new List<IssueGridModel>();

        [Inject]
        public IssueService IssueService { get; set; }

        [Inject]
        public IMapper mapper { get; set; }

        protected BTable table;

        protected override async Task OnInitializedAsync()
        {
            var issues = await IssueService.GetAll();
            Models = mapper.Map<Issue, IssueGridModel>(issues).ToList();
            await base.OnInitializedAsync();
        }

        public async Task CreateAsync()
        {
            await JSRuntime.HrefBlankAsync("/issue/edit");
        }

        private async Task RefreshAsync()
        {
            if (table == null) return;

            var issues = await IssueService.GetAll();
            Models = mapper.Map<Issue, IssueGridModel>(issues).ToList();
            var model = form.GetValue<IssueSearchModel>();
            if (!string.IsNullOrEmpty(model.ChangeFrom))
            {
                Models = Models.Where(o => o.ChangeFrom.ToLower().Contains(model.ChangeFrom.ToLower()));
            }
            if (model.StartCreateTime.HasValue)
            {
                Models = Models.Where(o => o.CreateTime >= model.StartCreateTime);
            }
            if (model.EndCreateTime.HasValue)
            {
                Models = Models.Where(o => o.CreateTime <= model.EndCreateTime);
            }

            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        public async Task EditAsync(object model)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add(nameof(IssueEdit.Model), model);
            await DialogService.ShowDialogAsync<IssueEdit>("编辑问题", 800, parameters);
            await RefreshAsync();
        }

        public async Task SearchAsync()
        {
            if (!form.IsValid()) return;
            await RefreshAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!firstRender) return;

            await RefreshAsync();
        }

        public async Task Delete(object user)
        {
            if (await ConfirmAsync("确认删除该问题？") != MessageBoxResult.Ok) return;

            await IssueService.DeleteAsync(((IssueGridModel)user).Id);
            Toast("删除问题成功！");
            await RefreshAsync();
        }
    }
}
