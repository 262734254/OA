<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProviderList.aspx.cs" Inherits="ResourceManager_ProviderManager_ProviderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>供应商列表</title>
    <link href="../../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../../js/calendar.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            width: 99%;
            height: 318px;
            background-color: #C6DAF3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        供应商信息查询</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Button ID="Button3" runat="server" class="BigButton" Text="新增供应商" 
                                    onclick="Button3_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                供应商名称：<asp:TextBox ID="txtDept" class="inputs" runat="server"></asp:TextBox>
                                &nbsp;单位地址：<asp:TextBox ID="txtDept0" class="inputs" runat="server"></asp:TextBox>
                                联系人：<asp:TextBox ID="txtDept1" class="inputs" runat="server"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2"
                                    runat="server" class="BigButton" Text="查   询" />
                                &nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" class="BigButton" Text="删   除" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="style1" cellpadding="0" cellspacing="0">
                                    <tr align="center" class="TableHeader">
                                        <td>
                                            <input id="Checkbox1" type="checkbox" />全选
                                        </td>
                                        <td>
                                            序号
                                        </td>
                                        <td>
                                            资源名称
                                        </td>
                                        <td>
                                            资源类型
                                        </td>
                                        <td>
                                            资源数量
                                        </td>
                                        <td>
                                            购买时间
                                        </td>
                                        <td>
                                            资源状态
                                        </td>
                                        <td>
                                            资源规格
                                        </td>
                                        <td>
                                            详情
                                        </td>
                                        <td>
                                            修改
                                        </td>
                                        <td>
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
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResource.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除</td>
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
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResource.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除</td>
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
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResource.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除</td>
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
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResource.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除</td>
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
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResource.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除</td>
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
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="ResourceDetails.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除</td>
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
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="ResourceDetails.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除</td>
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
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResource.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除</td>
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
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResource.aspx">修改</a>
                                        </td>
                                        <td>
                                            删除</td>
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
