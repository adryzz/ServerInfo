#pragma checksum "/home/adryzz/ServerInfo/Client/Pages/Network.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26b76d05d68f097b139ed1e13c55c25eb667e47e"
// <auto-generated/>
#pragma warning disable 1591
namespace ServerInfo.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/adryzz/ServerInfo/Client/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/adryzz/ServerInfo/Client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/adryzz/ServerInfo/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/adryzz/ServerInfo/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/adryzz/ServerInfo/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/adryzz/ServerInfo/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/adryzz/ServerInfo/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/adryzz/ServerInfo/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/adryzz/ServerInfo/Client/_Imports.razor"
using ServerInfo.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/adryzz/ServerInfo/Client/_Imports.razor"
using ServerInfo.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
using ServerInfo.Types;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
using System.Net.NetworkInformation;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/network")]
    public partial class Network : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Network info</h1>\n\n");
            __builder.AddMarkupContent(1, "<p>This component demonstrates fetching data from the server.</p>");
#nullable restore
#line 10 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
 if (interfaces == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(2, "<p><em>Loading...</em></p>");
#nullable restore
#line 13 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "table");
            __builder.AddAttribute(4, "class", "table");
            __builder.AddMarkupContent(5, @"<thead><tr><th>Name</th>
                <th>Status</th>
                <th>Speed</th>
                <th>Type</th>
                <th>Sent data</th>
                <th>Received data</th>
                <th>Transmit throughput</th>
                <th>Receive throughput</th></tr></thead>
        ");
            __builder.OpenElement(6, "tbody");
#nullable restore
#line 30 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
             foreach (var i in interfaces.Where(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback))
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(7, "tr");
            __builder.OpenElement(8, "td");
            __builder.AddContent(9, 
#nullable restore
#line 33 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
                         i.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\n                    ");
            __builder.OpenElement(11, "td");
            __builder.AddContent(12, 
#nullable restore
#line 34 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
                         i.OperationalStatus.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\n                    ");
            __builder.OpenElement(14, "td");
            __builder.AddContent(15, 
#nullable restore
#line 35 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
                         Utils.FromBitsToStringSpeed(i.Speed)

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\n                    ");
            __builder.OpenElement(17, "td");
            __builder.AddContent(18, 
#nullable restore
#line 36 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
                         i.NetworkInterfaceType.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\n                    ");
            __builder.OpenElement(20, "td");
            __builder.AddContent(21, 
#nullable restore
#line 37 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
                         Utils.FromBytesToString((long)i.SentBytes)

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\n                    ");
            __builder.OpenElement(23, "td");
            __builder.AddContent(24, 
#nullable restore
#line 38 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
                         Utils.FromBytesToString((long)i.ReceivedBytes)

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\n                    ");
            __builder.OpenElement(26, "td");
            __builder.AddContent(27, 
#nullable restore
#line 39 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
                         Utils.FromBitsToStringSpeed(i.TransmitSpeed)

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\n                    ");
            __builder.OpenElement(29, "td");
            __builder.AddContent(30, 
#nullable restore
#line 40 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
                         Utils.FromBitsToStringSpeed(i.ReceiveSpeed)

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 42 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 45 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 47 "/home/adryzz/ServerInfo/Client/Pages/Network.razor"
       
    private AdvancedNetworkInterface[] interfaces;

    protected override async Task OnInitializedAsync()
    {
        interfaces = await Http.GetFromJsonAsync<AdvancedNetworkInterface[]>("api/v1/networkinfo");
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
