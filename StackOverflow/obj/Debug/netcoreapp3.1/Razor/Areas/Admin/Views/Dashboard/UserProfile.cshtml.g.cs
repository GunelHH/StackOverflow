#pragma checksum "/Users/gunelhesenova/Desktop/Projects/StackOverflow/StackOverflow/Areas/Admin/Views/Dashboard/UserProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f513fbd7be29ff3299336ec74ca6f5b897b1f6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(StackOverflow.Areas.Admin.Views.Dashboard.Areas_Admin_Views_Dashboard_UserProfile), @"mvc.1.0.view", @"/Areas/Admin/Views/Dashboard/UserProfile.cshtml")]
namespace StackOverflow.Areas.Admin.Views.Dashboard
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 4 "/Users/gunelhesenova/Desktop/Projects/StackOverflow/StackOverflow/Areas/Admin/Views/_ViewImports.cshtml"
using StackOverflow.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/gunelhesenova/Desktop/Projects/StackOverflow/StackOverflow/Areas/Admin/Views/_ViewImports.cshtml"
using StackOverflow.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f513fbd7be29ff3299336ec74ca6f5b897b1f6a", @"/Areas/Admin/Views/Dashboard/UserProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"938d77a7db97ee08d1af9af6a23bff6056d1cc88", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Dashboard_UserProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("avatar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/img/emilyz.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""content"">
    <div class=""row"">
        <div class=""col-md-8"">
            <div class=""card"">
                <div class=""card-header"">
                    <h5 class=""title"">Edit Profile</h5>
                </div>
                <div class=""card-body"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f513fbd7be29ff3299336ec74ca6f5b897b1f6a4925", async() => {
                WriteLiteral(@"
                        <div class=""row"">
                            <div class=""col-md-5 pr-md-1"">
                                <div class=""form-group"">
                                    <label>Company (disabled)</label>
                                    <input type=""text"" class=""form-control""");
                BeginWriteAttribute("disabled", " disabled=\"", 597, "\"", 608, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Company"" value=""Creative Code Inc."">
                                </div>
                            </div>
                            <div class=""col-md-3 px-md-1"">
                                <div class=""form-group"">
                                    <label>Username</label>
                                    <input type=""text"" class=""form-control"" placeholder=""Username"" value=""michael23"">
                                </div>
                            </div>
                            <div class=""col-md-4 pl-md-1"">
                                <div class=""form-group"">
                                    <label for=""exampleInputEmail1"">Email address</label>
                                    <input type=""email"" class=""form-control"" placeholder=""mike@email.com"">
                                </div>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-md-6 pr-md-1"">
            ");
                WriteLiteral(@"                    <div class=""form-group"">
                                    <label>First Name</label>
                                    <input type=""text"" class=""form-control"" placeholder=""Company"" value=""Mike"">
                                </div>
                            </div>
                            <div class=""col-md-6 pl-md-1"">
                                <div class=""form-group"">
                                    <label>Last Name</label>
                                    <input type=""text"" class=""form-control"" placeholder=""Last Name"" value=""Andrew"">
                                </div>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-md-12"">
                                <div class=""form-group"">
                                    <label>Address</label>
                                    <input type=""text"" class=""form-control"" placeholder=""Home Address"" value=""Bld Mihail Ko");
                WriteLiteral(@"galniceanu, nr. 8 Bl 1, Sc 1, Ap 09"">
                                </div>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-md-4 pr-md-1"">
                                <div class=""form-group"">
                                    <label>City</label>
                                    <input type=""text"" class=""form-control"" placeholder=""City"" value=""Mike"">
                                </div>
                            </div>
                            <div class=""col-md-4 px-md-1"">
                                <div class=""form-group"">
                                    <label>Country</label>
                                    <input type=""text"" class=""form-control"" placeholder=""Country"" value=""Andrew"">
                                </div>
                            </div>
                            <div class=""col-md-4 pl-md-1"">
                                <div class=""form-group"">
     ");
                WriteLiteral(@"                               <label>Postal Code</label>
                                    <input type=""number"" class=""form-control"" placeholder=""ZIP Code"">
                                </div>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-md-8"">
                                <div class=""form-group"">
                                    <label>About Me</label>
                                    <textarea rows=""4"" cols=""80"" class=""form-control"" placeholder=""Here can be your description"" value=""Mike"">Lamborghini Mercy, Your chick she so thirsty, I'm in that two seat Lambo.</textarea>
                                </div>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <div class=""card-footer"">
                    <button type=""submit"" class=""btn btn-fill btn-primary"">Save</button>
                </div>
            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""card card-user"">
                <div class=""card-body"">
                    <p class=""card-text"">
                        <div class=""author"">
                            <div class=""block block-one""></div>
                            <div class=""block block-two""></div>
                            <div class=""block block-three""></div>
                            <div class=""block block-four""></div>
                            <a href=""javascript:void(0)"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8f513fbd7be29ff3299336ec74ca6f5b897b1f6a11514", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                <h5 class=""title"">Mike Andrew</h5>
                            </a>
                            <p class=""description"">
                                Ceo/Co-Founder
                            </p>
                        </div>
                    </p>
                    <div class=""card-description"">
                        Do not be scared of the truth because we need to restart the human foundation in truth And I love you like Kanye loves Kanye I love Rick Owens’ bed design but the back is...
                    </div>
                </div>
                <div class=""card-footer"">
                    <div class=""button-container"">
                        <button href=""javascript:void(0)"" class=""btn btn-icon btn-round btn-facebook"">
                            <i class=""fab fa-facebook""></i>
                        </button>
                        <button href=""javascript:void(0)"" class=""btn btn-icon btn-round btn-twitter"">
                            <i class=""fab fa");
            WriteLiteral(@"-twitter""></i>
                        </button>
                        <button href=""javascript:void(0)"" class=""btn btn-icon btn-round btn-google"">
                            <i class=""fab fa-google-plus""></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
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
