// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Chat_Reenbet_brazor.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Chat_Reenbet_brazor.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Chat_Reenbet_brazor.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Chat_Reenbet_brazor.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using System.Collections;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Chat_Reenbet_brazor.Client.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\_Imports.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/chatpage")]
    public partial class ChatPage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 5 "D:\Projects\Chat-Reenbet-brazor\Chat-Reenbet-brazor\Client\Pages\ChatPage.razor"
 
    private HubConnection hubConnection;

   private async Task Connect()
   {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(navigationManager.ToAbsoluteUri("/chathub"))
            .Build();

        //hubConnection.ConnectionId;
   }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
    }
}
#pragma warning restore 1591
