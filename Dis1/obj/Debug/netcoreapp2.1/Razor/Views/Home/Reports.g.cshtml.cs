#pragma checksum "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\Home\Reports.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5aae368cbfe2244970aedbf7209f0efda2fa10a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Reports), @"mvc.1.0.view", @"/Views/Home/Reports.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Reports.cshtml", typeof(AspNetCore.Views_Home_Reports))]
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
#line 1 "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\_ViewImports.cshtml"
using Dis1;

#line default
#line hidden
#line 2 "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\_ViewImports.cshtml"
using Dis1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5aae368cbfe2244970aedbf7209f0efda2fa10a", @"/Views/Home/Reports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"910e7df384fbcf2942c634e7cc8326d1829eb4ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Reports : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Dis1.Models.Report>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:inline;padding:3px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Send_email", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Sendcmp", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetVirtualFile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\Home\Reports.cshtml"
  
    ViewBag.Title = "Все смартфоны";

#line default
#line hidden
            BeginContext(85, 451, true);
            WriteLiteral(@"<div class=""work"">
    <div class=""work-tittle"">
        <div class=""work-tittle title"">
            <p>Страница отчетов</p>
        </div>
        <div class=""work-tittle text"">
            <p>Стрианица для просмотра отчетов</p>
        </div>
    </div>
    <div class=""shablon-table"">
        <table class=""table-shablon"">
            <tr><td class=""table-1"">Наименование</td><td class=""table-2"">Дата</td><td class=""table-3""></td></tr>
");
            EndContext();
#line 17 "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\Home\Reports.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(593, 20, true);
            WriteLiteral("            <tr><td>");
            EndContext();
            BeginContext(614, 15, false);
#line 19 "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\Home\Reports.cshtml"
               Write(item.ReportName);

#line default
#line hidden
            EndContext();
            BeginContext(629, 9, true);
            WriteLiteral("</td><td>");
            EndContext();
            BeginContext(639, 15, false);
#line 19 "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\Home\Reports.cshtml"
                                        Write(item.ReportDate);

#line default
#line hidden
            EndContext();
            BeginContext(654, 39, true);
            WriteLiteral("</td><td style=\"display: inline-flex;\">");
            EndContext();
            BeginContext(693, 224, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5aae368cbfe2244970aedbf7209f0efda2fa10a6876", async() => {
                BeginContext(778, 28, true);
                WriteLiteral("<input type=\"type\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 806, "\"", 822, 1);
#line 19 "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\Home\Reports.cshtml"
WriteAttributeValue("", 814, item.Cr, 814, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(823, 87, true);
                WriteLiteral(" style=\"display:none\" /><input type=\"submit\" name=\"id\" class=\"btn-temp-del\" value=\"\" />");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(917, 229, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5aae368cbfe2244970aedbf7209f0efda2fa10a9235", async() => {
                BeginContext(1005, 28, true);
                WriteLiteral("<input type=\"type\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1033, "\"", 1049, 1);
#line 19 "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\Home\Reports.cshtml"
WriteAttributeValue("", 1041, item.Cr, 1041, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1050, 89, true);
                WriteLiteral(" style=\"display:none\" /><input type=\"submit\" name=\"id\" class=\"btn-temp-email\" value=\"\" />");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1146, 226, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5aae368cbfe2244970aedbf7209f0efda2fa10a11603", async() => {
                BeginContext(1231, 29, true);
                WriteLiteral("<input type=\"type\" name=\"id1\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1260, "\"", 1276, 1);
#line 19 "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\Home\Reports.cshtml"
WriteAttributeValue("", 1268, item.Cr, 1268, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1277, 88, true);
                WriteLiteral(" style=\"display:none\" /><input type=\"submit\" name=\"id\" class=\"btn-temp-send\" value=\"\" />");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1372, 233, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5aae368cbfe2244970aedbf7209f0efda2fa10a13972", async() => {
                BeginContext(1464, 29, true);
                WriteLiteral("<input type=\"type\" name=\"id1\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1493, "\"", 1509, 1);
#line 19 "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\Home\Reports.cshtml"
WriteAttributeValue("", 1501, item.Cr, 1501, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1510, 88, true);
                WriteLiteral(" style=\"display:none\" /><input type=\"submit\" name=\"id\" class=\"btn-temp-send\" value=\"\" />");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1605, 12, true);
            WriteLiteral("</td></tr>\r\n");
            EndContext();
#line 20 "C:\Users\aynur\Desktop\work\815а\newdoc\Test\Dis1\Views\Home\Reports.cshtml"
            }

#line default
#line hidden
            BeginContext(1632, 38, true);
            WriteLiteral("        </table>\r\n    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Dis1.Models.Report>> Html { get; private set; }
    }
}
#pragma warning restore 1591
