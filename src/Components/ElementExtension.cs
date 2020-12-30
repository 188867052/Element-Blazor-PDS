using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Element
{
    public static class JSRuntimeExtension
    {
        public static ElementHelper Dom(this ElementReference elementReference, IJSRuntime jSRuntime)
        {
            return new ElementHelper(elementReference, jSRuntime);
        }

        public static async Task<IJSRuntime> AlertAsync(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeAsync<object>("alert", message);
            return jSRuntime;
        }
        public static async Task<IJSRuntime> AlertAsync(this IJSRuntime jSRuntime, int message)
        {
            await jSRuntime.InvokeAsync<object>("alert", message.ToString());
            return jSRuntime;
        }

        public static async Task<IJSRuntime> HrefBlankAsync(this IJSRuntime jSRuntime, string url)
        {
            await jSRuntime.InvokeAsync<object>("window.open", url, "_blank");
            return jSRuntime;
        }

        public static async Task<IJSRuntime> HideByIdAsync(this IJSRuntime jSRuntime, string id)
        {
            await jSRuntime.InvokeAsync<object>($"hideById", id);
            return jSRuntime;
        } 
    }
}
