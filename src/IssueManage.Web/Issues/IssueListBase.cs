using AutoMapper;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueManage.Pages.Entity;
using Element;
using IssueManage.Pages.Extension;
using IssueManage.Web.Issues;
using IssueManage.Pages;
using IssueManage.Pages.Issues;

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
            await JSRuntime.HrefBlankAsync("/issue/create");
        }

        private async Task RefreshAsync()
        {
            if (table == null) return;

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

            var model = form.GetValue<IssueSearchModel>();
            if (!string.IsNullOrEmpty(model.Description))
            {
                Models = Models.Where(o => o.Description.ToLower().Contains(model.Description.ToLower()));
            }
            if (model.Status.HasValue)
            {
                Models = Models.Where(o => o.Status == model.Status);
            }
            if (model.StartCreateTime.HasValue)
            {
                Models = Models.Where(o => o.CreateTime >= model.StartCreateTime);
            }
            if (model.EndCreateTime.HasValue)
            {
                Models = Models.Where(o => o.CreateTime <= model.EndCreateTime);
            }
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
