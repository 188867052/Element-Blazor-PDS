using Microsoft.AspNetCore.Components;

namespace Element
{
    public partial class BTableTemplateColumn : BTableColumn
    {
        [Parameter]
        public override RenderFragment<object> ChildContent { get; set; }
    }
}
