using System.Collections.Generic;
using System.Threading.Tasks;
using AntDesign.Charts;
using System;

namespace IssueManage.Pages.Index
{
    public class BIndexBase : BAdminPageBase
    {
        public List<object> data = new List<object>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        public ColumnConfig config = new ColumnConfig
        {
            Title = new Title
            {
                Visible = true,
                Text = "问题数统计"
            },
            ForceFit = true,
            Padding = "auto",
            XField = "type",
            YField = "sales",
            Meta = new
            {
                Type = new
                {
                    Alias = "月份"
                },
                Sales = new
                {
                    Alias = "问题数"
                }
            },
            Label = new ColumnViewConfigLabel
            {
                Visible = true,
                Style = new TextStyle
                {
                    FontSize = 12,
                    FontWeight = 600,
                    Opacity = 0.6,
                }
            }
        };

        private async Task RefreshAsync()
        {
            var random = new Random();
            for (int i = 1; i <= 12; i++)
            {
                data.Add(new { type = $"{i}月", sales = random.Next(1, 30) });
            }
            RequireRender = true;
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!firstRender) return;

            await RefreshAsync();
        }
    }
}
