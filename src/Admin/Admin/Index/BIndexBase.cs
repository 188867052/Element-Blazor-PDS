using Element.Admin.Abstract;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AntDesign.Charts;

namespace Element.Admin
{
    public class BIndexBase : BAdminPageBase
    {
        protected List<ProductModel> Models { get; private set; } = new List<ProductModel>();
        internal bool CanCreate { get; private set; }
        internal bool CanUpdate { get; private set; }
        internal bool CanDelete { get; private set; }

        [Inject]
        public IProductService ProductService { get; set; }

        protected BTable table;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CanCreate = IsCanAccessAny(AdminResources.CreateUser.ToString());
            CanUpdate = IsCanAccessAny(AdminResources.UpdateUser.ToString());
            CanDelete = IsCanAccessAny(AdminResources.DeleteUser.ToString());
        }

      public  object[] data2 =
    {
        new
        {
            type = "家具家电",
            sales = 38
        },
        new
        {
            type = "粮油副食",
            sales = 52
        },
        new
        {
            type = "生鲜水果",
            sales = 61
        },
        new
        {
            type = "美容洗护",
            sales = 145
        },
        new
        {
            type = "母婴用品",
            sales = 48
        },
        new
        {
            type = "进口食品",
            sales = 38
        },
        new
        {
            type = "食品饮料",
            sales = 38
        },
        new
        {
            type = "家庭清洁",
            sales = 38
        }
    };

        public ColumnConfig config2 = new ColumnConfig
        {
            Title = new Title
            {
                Visible = true,
                Text = "基础柱状图-图形标签"
            },
            Description = new Description
            {
                Visible = true,
                Text = "基础柱状图图形标签默认位置在柱形上部。",
            },
            ForceFit = true,
            Padding = "auto",
            XField = "type",
            YField = "sales",
            Meta = new
            {
                Type = new
                {
                    Alias = "类别"
                },
                Sales = new
                {
                    Alias = "销售额(万)"
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
            if (table == null) return;

            Models = (await ProductService.GetAll()).Select(o => new ProductModel
            {
                Id = o.Id,
                Description = o.Description,
                Name = o.Name,
                CreateTime = o.CreateTime,
            }).ToList();
            table.MarkAsRequireRender();
            RequireRender = true;
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (!firstRender) return;

            await RefreshAsync();
        }

        public async Task Delete(object model)
        {
            var confirm = await ConfirmAsync("确认删除该产品？");
            if (confirm != MessageBoxResult.Ok) return;

            await ProductService.DeleteAsync(((ProductModel)model).Id);
            Toast("删除成功！");
            await RefreshAsync();
        }
    }
}
