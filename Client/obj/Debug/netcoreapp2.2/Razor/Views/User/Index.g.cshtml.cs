#pragma checksum "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "190e05cac577513d59e704419f1a37bf2bb22a35"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Index.cshtml", typeof(AspNetCore.Views_User_Index))]
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
#line 1 "D:\Projects\chatRoubette\Client\Views\_ViewImports.cshtml"
using Client;

#line default
#line hidden
#line 2 "D:\Projects\chatRoubette\Client\Views\_ViewImports.cshtml"
using Client.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"190e05cac577513d59e704419f1a37bf2bb22a35", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3fd22fe3589ebdc381df8dd96b3beba49422a762", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "190e05cac577513d59e704419f1a37bf2bb22a353521", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(96, 63, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome ");
            EndContext();
            BeginContext(160, 14, false);
#line 6 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"
                             Write(Model.Username);

#line default
#line hidden
            EndContext();
            BeginContext(174, 42, true);
            WriteLiteral("</h1>\r\n</div>\r\n<div class=\"text-center\">\r\n");
            EndContext();
#line 9 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"
     using (Html.BeginForm("AddFriend", "User", FormMethod.Post))
    {
        

#line default
#line hidden
            BeginContext(299, 23, false);
#line 11 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(324, 141, true);
            WriteLiteral("        <input type=\"text\" name=\"friendName\" required />\r\n        <input type=\"submit\" value=\"Add Friend\" class=\"btn btn-success btn-lg\" />\r\n");
            EndContext();
#line 14 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(472, 12, true);
            WriteLiteral("    <br>\r\n\r\n");
            EndContext();
#line 17 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"
     using (Html.BeginForm("AddToConversation", "User", FormMethod.Post))
    {
        

#line default
#line hidden
            BeginContext(575, 23, false);
#line 19 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(600, 104, true);
            WriteLiteral("        <select style=\"width: 30%;\" name=\"friendId\" id=\"friendList\" multiple></select>\r\n        <br />\r\n");
            EndContext();
#line 22 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"
        //<input type="submit" value="Add Conversation" class="btn btn-success btn-lg" />

#line default
#line hidden
            BeginContext(795, 110, true);
            WriteLiteral("        <input type=\"button\" onclick=\"makeConv()\" value=\"Add Conversation\" class=\"btn btn-success btn-lg\" />\r\n");
            EndContext();
#line 24 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(912, 12, true);
            WriteLiteral("    <br>\r\n\r\n");
            EndContext();
#line 27 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"
     using (Html.BeginForm("StartConversation", "User", FormMethod.Post))
    {
        

#line default
#line hidden
            BeginContext(1015, 23, false);
#line 29 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(1040, 212, true);
            WriteLiteral("        <select style=\"width: 30%;\" name=\"conversationId\" id=\"convList\" ></select>\r\n        <br />\r\n        <input type=\"button\" onclick=\"openConv()\" value=\"Start Conversation\" class=\"btn btn-success btn-lg\" />\r\n");
            EndContext();
#line 33 "D:\Projects\chatRoubette\Client\Views\User\Index.cshtml"

    }

#line default
#line hidden
            BeginContext(1261, 3142, true);
            WriteLiteral(@"    <br>

</div>

<script>
    $(document).ready(function () {
        loadFriends();
        loadConversations();
    });

    function loadFriends() {
        $.ajax({
            contentType: ""application/json"",
            type: ""GET"",
            url: ""https://localhost:44385/api/Friends"",
            success: function (result) {
                var select = document.getElementById(""friendList"");
                select.innerHTML = """";
                for (var i = 0; i < result.length; i++) {
                    var option = document.createElement(""option"");
                    option.value = result[i][""id""][""value""];
                    option.text = result[i][""username""];
                    select.appendChild(option);
                }
                //setTimeout(function () {
                //    loadData();
                //},1000);
            },
            error: function (error) {
                console.log(error);
            }
        });

    }

    funct");
            WriteLiteral(@"ion loadConversations() {
        $.ajax({
            contentType: ""application/json"",
            type: ""GET"",
            url: ""https://localhost:44385/api/Conversations"",
            success: function (result) {
                var select = document.getElementById(""convList"");
                select.innerHTML = """";
                for (var i = 0; i < result.length; i++) {
                    var option = document.createElement(""option"");
                    option.value = result[i][""id""][""value""];
                    option.text = i;
                    select.appendChild(option);
                }
                //setTimeout(function () {
                //    loadData();
                //},1000);
            },
            error: function (error) {
                console.log(error.statusText);
            }
        });
    }

    function makeConv() {
        var userIds = $(""#friendList"").val();

        var ids = [];
        for (var i = 0; i < userIds.length; i++) {
  ");
            WriteLiteral(@"          ids.push(userIds[i]);
        }

        var model = {
            ""Ids"": ids 
        };

        
        $.ajax({
            contentType: 'application/json; charset=utf-8',
            type: 'POST',
            url: '/User/AddToConversation',
            data: JSON.stringify(model),
            dataType: ""json"",
            success: function () {
                window.location.href = ""/User"";
            },
            error: function (err) {
                console.log(err);
            }
        });

    }

    function openConv() {
        var convId = $(""#convList"").val();

        $.ajax({
            contentType: 'application/json; charset=utf-8',
            type: 'POST',
            url: '/Conversation/GetId',
            data: JSON.stringify(convId),
            success: function () {
                console.log(""success"");
                window.location.href = ""/Conversation"";
            },
            error: function (err) {
                cons");
            WriteLiteral("ole.log(err);\r\n            }\r\n        })\r\n    }\r\n</script>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
