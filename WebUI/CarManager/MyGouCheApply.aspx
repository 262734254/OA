<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyGouCheApply.aspx.cs" Inherits="CarManager_MyGouCheApply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>购车申请信息</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
     <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
    <style type="text/css">
        .style2
        {
           width: 100%; background-color:#C6DAF3;
           height: 450px;
        }
        .style1
        {
            width: 750px;
            height: 300px;
        }
        .style3
        {
            height: 13px;
        }
        .style4
        {
            width: 130px;
        }
        .style5
        {
            height: 13px;
            width: 130px;
        }
        .style6
        {
            width: 170px;
        }
        .style7
        {
            height: 13px;
            width: 170px;
        }
    </style>
    <script type="text/javascript">
        function selAll(obj)
        {
            var items=document.getElementsByTagName("input");
            for(var i=0;i<items.length;i++)
            {
                if(items[i]!=null&&items[i].type=="checkbox")
                {
                    items[i].checked=obj.checked;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table class="style2">
             <tr>
                 <td class="title1">
                     <h3>我的申请</h3></td>
             </tr>
             <tr>
                 <td valign="top">
         <table>
         <tr>
         <td style=" height:50px;">
          请选择购车申请的流程：<asp:DropDownList ID="DropDownList1" class="inputs" runat="server">
                    <asp:ListItem>未审批</asp:ListItem>
                    <asp:ListItem>已审批</asp:ListItem>
                </asp:DropDownList>
         </td>
         </tr>
            <tr >
                <td  align="center">
                    <table class="style1" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="6" style=" text-align:left;">
                                <input type="button" value="删  除" onclick="return confirm('确认删除吗？')" class="BigButton" /></td>
                        </tr>
                        <tr align="center" class="TableHeader">
                            <td class="style4">
                                <input id="Checkbox1" type="checkbox" onclick="selAll(this)" />全选
                            </td>
                            <td class="style6">
                                购买日期
                            </td>
                            <td>
                                车辆类型
                            </td>
                            <td>
                                所需资金
                            </td>
                            <td>
                                状态</td>
                            <td>
                                详细</td>
                        </tr>
                        <tr align="center" class="TableContent">
                            <td class="style5">
                                <input id="Checkbox2" type="checkbox" />数据绑定
                            </td>
                            <td class="style7">
                                2010-05-06</td>
                            <td class="style3">
                                其他用车</td>
                            <td class="style3">
                                67677￥
                            </td>
                            <td class="style3">
                                待审批</td>
                            <td class="style3">
                               <a href="GouCheCaparticular.aspx">详细</a></td>
                        </tr>
                         <tr align="center" class="TableContent">
                            <td class="style4">
                                <input id="Checkbox3" type="checkbox" />数据绑定
                            </td>
                            <td class="style6">
                                2010-05-06</td>
                            <td>
                                接待用车</td>
                            <td>
                                44344￥</td>
                            <td>
                                待审批</td>
                            <td>
                                <a href="GouCheCaparticular.aspx">详细</a></td>
                        </tr>
                         <tr align="center" class="TableContent">
                            <td class="style4">
                                <input id="Checkbox4" type="checkbox" />数据绑定
                            </td>
                            <td class="style6">
                                2010-05-06</td>
                            <td>
                                接待用车</td>
                            <td>
                                555534￥</td>
                            <td>
                                待审批<td>
                                                 <a href="GouCheCaparticular.aspx">详细</a></td>
                        </tr>
                         <tr align="center" class="TableContent">
                            <td class="style4">
                                <input id="Checkbox5" type="checkbox" />数据绑定
                            </td>
                            <td class="style6">
                                2010-05-06</td>
                            <td>
                                其他用车</td>
                            <td>
                                123234￥</td>
                            <td>
                                待审批</td>
                            <td>
                                <a href="GouCheCaparticular.aspx">详细</a></td>
                        </tr>
                         <tr align="center" class="TableContent">
                            <td class="style4">
                                <input id="Checkbox6" type="checkbox" />数据绑定
                            </td>
                            <td class="style6">
                                2010-05-06</td>
                            <td>
                                接待用车</td>
                            <td>
                                123213￥ </td>
                            <td>
                                已审批</td>
                            <td>
                                <a href="GouCheCaparticular.aspx">详细</a></td>
                        </tr>
                        <tr align="center" class="TableContent">
                            <td class="style4">
                                <input id="Checkbox7" type="checkbox" />数据绑定
                            </td>
                            <td class="style6">
                                2010-05-06</td>
                            <td>
                                其他用车
                            </td>
                            <td>
                                434234￥</td>
                            <td>
                                已审批</td>
                            <td>
                                <a href="GouCheCaparticular.aspx">详细</a></td>
                        </tr>
                        <tr align="center" class="TableContent">
                            <td class="style4">
                                <input id="Checkbox8" type="checkbox" />数据绑定
                            </td>
                            <td class="style6">
                                2010-05-06</td>
                            <td>
                                其他用车</td>
                            <td>
                                453455￥</td>
                            <td>
                                已审批</td>
                            <td>
                                <a href="GouCheCaparticular.aspx">详细</a></td>
                        </tr>
                        <tr align="center" class="TableContent">
                            <td class="style4">
                                <input id="Checkbox9" type="checkbox" />数据绑定
                            </td>
                            <td class="style6">
                                2010-05-06</td>
                            <td>
                                其他用车</td>
                            <td>
                                6756765￥</td>
                            <td>
                                已审批</td>
                            <td>
                                <a href="GouCheCaparticular.aspx">详细</a></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    共有<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    记录&nbsp;&nbsp; |&nbsp;&nbsp; 共有<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    页&nbsp; |&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkfirst" runat="server">首页</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lnkprev" runat="server">上一页</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lnknext" runat="server">下一页</asp:LinkButton>
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="lnklast" runat="server">尾页</asp:LinkButton>
                </td>
            </tr>
        </table>
                 </td>
             </tr>
         </table>
    </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>

