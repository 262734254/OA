<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourceTypeList.aspx.cs"
    Inherits="ResourceManager_ResourceTypeManager_ResourceTypeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资源类型列表</title>
    <link href="../../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../../js/calendar.js" type="text/javascript"> </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            background-color: #C6DAF3;
        }
        .style3
        {
            width: 600px;
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
                        资源类型列表</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table class="style3">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnResourceType" runat="server" class="BigButton" Text="新增类型" onclick="btnResourceType_Click" 
                                    />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="style1" cellpadding="0" cellspacing="0">
                                    <tr align="center" class="TableHeader">
                                        <td style="width:70px;">
                                            <input id="Checkbox1" type="checkbox" />全选
                                        </td>
                                        <td class="style4" style="width:70px;">
                                            序号
                                        </td>
                                        <td class="style4" style="width:100px;">
                                            类型名称
                                        </td>
                                        <td class="style4">
                                            备注</td>
                                        <td class="style4" style="width:50px;">
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
