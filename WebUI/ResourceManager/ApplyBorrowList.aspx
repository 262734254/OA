<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyBorrowList.aspx.cs"
    Inherits="ResourceManager_ApplyBorrowList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>借用申请记录列表</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 344px;
            background-color: #C6DAF3;
        }
        .style4
        {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        借用申请记录列表</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnNewApplyBrrow" runat="server" class="BigButton" Text="新增借用申请" OnClick="btnNewApplyBrrow_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                申请单号：<asp:TextBox ID="txtDept" class="inputs" runat="server"></asp:TextBox>
                                &nbsp; 借用资源：<asp:TextBox ID="txtDept0" class="inputs" runat="server"></asp:TextBox>
                                &nbsp; 借用类型：<asp:DropDownList ID="DropDownList5" runat="server">
                                    <asp:ListItem>数据绑定</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;借用时间：<input type="text" onclick="showcalendar(event, this);" id="txtStartTime"
                                    runat="server" style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid; width:120px;" />
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" class="BigButton"
                                    Text="查   询" />
                                &nbsp;<asp:Button ID="Button1" runat="server" class="BigButton" Text="删   除" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="style1" cellpadding="0" cellspacing="0">
                                    <tr align="center" class="TableHeader">
                                        <td>
                                            <input id="Checkbox1" type="checkbox" />全选
                                        </td>
                                        <td class="style4">
                                            申请单号
                                        </td>
                                        <td class="style4">
                                            借用人
                                        </td>
                                        <td class="style4">
                                            借用时间
                                        </td>
                                        <td class="style4">
                                            申请类型
                                        </td>
                                        <td class="style4">
                                            紧急程度
                                        </td>
                                        <td class="style4">
                                            详情
                                        </td>
                                        <td class="style4">
                                            修改
                                        </td>
                                        <td class="style4">
                                            删除
                                        </td>
                                    </tr>
                                    <tr align="center" class="TableContent">
                                        <td>
                                            <input id="Checkbox2" type="checkbox" />
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ApplyBorrowInfo.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateApplyBorrow.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除
                                        </td>
                                    </tr>
                                    <tr align="center" class="TableContent">
                                        <td>
                                            <input id="Checkbox10" type="checkbox" />
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ApplyBorrowInfo.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateApplyBorrow.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除
                                        </td>
                                    </tr>
                                    <tr align="center" class="TableContent">
                                        <td>
                                            <input id="Checkbox3" type="checkbox" />
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ApplyBorrowInfo.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateApplyBorrow.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除
                                        </td>
                                    </tr>
                                    <tr align="center" class="TableContent">
                                        <td>
                                            <input id="Checkbox4" type="checkbox" />
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ApplyBorrowInfo.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateApplyBorrow.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除
                                        </td>
                                    </tr>
                                    <tr align="center" class="TableContent">
                                        <td>
                                            <input id="Checkbox5" type="checkbox" />
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ApplyBorrowInfo.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateApplyBorrow.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除
                                        </td>
                                    </tr>
                                    <tr align="center" class="TableContent">
                                        <td>
                                            <input id="Checkbox6" type="checkbox" />
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ApplyBorrowInfo.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateApplyBorrow.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除
                                        </td>
                                    </tr>
                                    <tr align="center" class="TableContent">
                                        <td>
                                            <input id="Checkbox7" type="checkbox" />
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ApplyBorrowInfo.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateApplyBorrow.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除
                                        </td>
                                    </tr>
                                    <tr align="center" class="TableContent">
                                        <td>
                                            <input id="Checkbox8" type="checkbox" />
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ApplyBorrowInfo.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateApplyBorrow.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除
                                        </td>
                                    </tr>
                                    <tr align="center" class="TableContent">
                                        <td>
                                            <input id="Checkbox9" type="checkbox" />
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ApplyBorrowInfo.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateApplyBorrow.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
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
</body>
</html>
