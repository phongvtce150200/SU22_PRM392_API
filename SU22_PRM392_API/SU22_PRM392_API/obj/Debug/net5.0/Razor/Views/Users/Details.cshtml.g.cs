#pragma checksum "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27b21fdfeb2f6bb9d83ec0e4ff25efd77b794e0a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Details), @"mvc.1.0.view", @"/Views/Users/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27b21fdfeb2f6bb9d83ec0e4ff25efd77b794e0a", @"/Views/Users/Details.cshtml")]
    #nullable restore
    public class Views_Users_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SU22_PRM392_API.Models.User>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>User</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsAdmin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
       Write(Html.DisplayFor(model => model.IsAdmin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1903, "\"", 1927, 1);
#nullable restore
#line 64 "C:\Users\vthan\Downloads\SU22_PRM392_API-main_Update_Cart_V2.0_Ban_moi_nhat\SU22_PRM392_API-main\SU22_PRM392_API\SU22_PRM392_API\Views\Users\Details.cshtml"
WriteAttributeValue("", 1918, Model.Id, 1918, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SU22_PRM392_API.Models.User> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591