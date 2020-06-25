#pragma checksum "E:\VS Working\.net core\ERestaurant\Views\TakeOut\Order.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3db34f9c81f7658c78792279269f277c6b76305b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TakeOut_Order), @"mvc.1.0.view", @"/Views/TakeOut/Order.cshtml")]
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
#nullable restore
#line 1 "E:\VS Working\.net core\ERestaurant\Views\_ViewImports.cshtml"
using ERestaurant;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\VS Working\.net core\ERestaurant\Views\_ViewImports.cshtml"
using ERestaurant.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3db34f9c81f7658c78792279269f277c6b76305b", @"/Views/TakeOut/Order.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8261dcff186f985aa957a0b7558f51356526b46e", @"/Views/_ViewImports.cshtml")]
    public class Views_TakeOut_Order : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\VS Working\.net core\ERestaurant\Views\TakeOut\Order.cshtml"
  
    ViewData["Title"] = "外卖订单";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div id=""app"" style=""margin-top: 50px;"" class=""row-fluid"">    
        <div class=""span12"">
            <div class=""well well_condition well-con"" style=""margin-top: 30px; margin-bottom: 13px;position: relative;"">
                <div class=""span6"">
                    <div class=""btn-group"">
                        <a class=""btn again-btn taps-p"">
                            <span class=""name-address"">订单列表</span>
                        </a>
                    </div> »
                    &nbsp;
                </div>

                <div class=""span6 order_person dropdown"" style=""text-align:right;"">
                    <div style=""text-align:left;padding-top: 5px; "">
                        <ul class=""tlist pull-right"">
                            <li id=""zonghe0""><a href=""http://www.leyu.net/jianli/search.php?areaid=0&amp;catid=0&amp;guzhubaozhang=0&amp;paixu=0"" class=""selected"">综合<i></i></a></li>
                            <li id=""yuyue0""><a href=""http://www.leyu.net/jianli/search.");
            WriteLiteral(@"php?areaid=0&amp;catid=0&amp;guzhubaozhang=0&amp;paixu=1"">预约量<i></i></a></li>
                            <li id=""jineng0""><a href=""http://www.leyu.net/jianli/search.php?areaid=0&amp;catid=0&amp;guzhubaozhang=0&amp;paixu=3"">技能经验<i></i></a></li>
                            <li id=""jiage0""><a href=""http://www.leyu.net/jianli/search.php?areaid=0&amp;catid=0&amp;guzhubaozhang=0&amp;paixu=5"">价格<i></i></a></li>
                            <li><input type=""checkbox"" id=""renzheng0"" onclick=""window.location.href='http://www.leyu.net/jianli/search.php?areaid=0&amp;catid=0&amp;guzhubaozhang=0&amp;paixu=0&amp;renzheng=1'"">个人认证</li>
                        </ul>
                    </div>

                    <div style=""clear:both;""></div>
                </div>
                <div style=""clear:both;""></div>
            </div>

            <div class=""well well_person"">
                <table class=""table table-responsive table-bordered table-hover"">
                    <tr>
                        <th>客户");
            WriteLiteral(@"</th>
                        <th>联系方式</th>
                        <th>送货地址</th>
                        <th>订单时间</th>
                        <th>订单详情</th>
                        <th>金额</th>
                        <th>状态</th>
                        <th>修改</th>
                    </tr>
                    <tr v-for=""data in dataList"">
                        <td>{{data.name}}</td>
                        <td>{{data.phone}}</td>
                        <td>{{data.address}}</td>
                        <td>{{data.createTime | dateFormat}}</td>
                        <td><span v-for=""food in data.foodDic"" style=""display: block"">{{food.item1}} x{{food.item2}}</span></td>
                        <td>{{data.price | formatCurrency}}</td>
                        <td>
                            <template v-if=""!data.isEdit"">
                                {{data.status}}
                            </template>
                            <template v-else>
                                <s");
            WriteLiteral("elect class=\"input-small\" v-model=\"data.status\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3db34f9c81f7658c78792279269f277c6b76305b6610", async() => {
                WriteLiteral("已付款");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3db34f9c81f7658c78792279269f277c6b76305b7601", async() => {
                WriteLiteral("已送餐");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3db34f9c81f7658c78792279269f277c6b76305b8592", async() => {
                WriteLiteral("已完成");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </select>
                            </template>
                        </td>
                        <td>
                            <template v-if=""!data.isEdit"">
                                <button class=""btn btn-primary"" ");
            WriteLiteral("@click=\"editStatus(data)\">修改状态</button>\r\n                            </template>\r\n                            <template v-else>\r\n                                <button class=\"btn btn-success\" ");
            WriteLiteral("@click=\"save(data)\">保存</button>\r\n                                <button class=\"btn btn-danger\" ");
            WriteLiteral("@click=\"cancel(data)\">取消</button>\r\n                            </template>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n\r\n                <pagination v-model=\"page\" :total=\"total\" :page-size=\"pageSize\" ");
            WriteLiteral(@"@input=""pageChange()""></pagination>
            </div>
        </div>
    </div>

<script>
    var app = new Vue({
        el: ""#app"",
        data: {          
            dataList: [],
        
            pageSize: 15,
            page: 1,
            total: 0,
          
            backup: """"          
        },
        mounted() {
            this.bindData();
        },

        methods: {
            bindData() {
                var params = `pageNo=${this.page}&pageSize=${this.pageSize}`
                axios.get(`/TakeOut/GetOrders?${params}`, {})
                    .then(res => {
                        if (res.data.status = true) {
                            res.data.data.filter(x => {
                            x.isEdit = false;
                            });

                            this.dataList = res.data.data;
                            this.total = res.data.total;
                        }
                        else {
                            ");
            WriteLiteral(@"alert(""获取数据失败！"");
                        }
                  })
                  .catch((e) => {
                    console.log('获取数据失败!');
                  });
            },

            editStatus(data) {
                data.isEdit = true;
                this.backup = data.status;
            },

            cancel(item) {
                item.isEdit = false;
                item.status = this.backup;
            },

            save(item) {
                if (item.status == this.backup) {
                    alert(""请修改状态后再提交！"");
                    return;
                }

                var parms = `id=${item.id}&status=${item.status}`
                axios.post(""/TakeOut/UpdateStatus?"" + parms).then(res => {
                    if (res.data.status == true) {
                        this.bindData();
                    }
                    else {
                        alert(""系统出错了！"");
                    }
                });
            },

            pag");
            WriteLiteral("eChange() {\r\n                this.bindData();\r\n            }\r\n        }\r\n    });\r\n</script>");
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
