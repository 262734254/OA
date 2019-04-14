<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchResourceStore.aspx.cs"
    Inherits="ResourceManager_ResourceStoreManager_SelectResourceStore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资料室列表</title>
    <link href="../../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../../css/6/style.css" type="text/css" rel="Stylesheet" />
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
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        资料室查询</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnNewStore" runat="server" class="BigButton" Text="新增资料室" 
                                    onclick="btnNewStore_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                资源室名称：<asp:TextBox ID="txtDept" class="inputs" runat="server"></asp:TextBox>
                                &nbsp;单位：<asp:DropDownList ID="DropDownList1" class="inputs" runat="server">
                                </asp:DropDownList>
                                &nbsp;使用类型：&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList2" class="inputs"
                                    runat="server">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2"
                                    runat="server" class="BigButton" Text="查   询" />
                                &nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" class="BigButton" Text="删   除" />
                            </td>
                        </tr>
                        s
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
                                            资源室名称
                                        </td>
                                        <td>
                                            部门名称</td>
                                        <td>
                                            库存</td>
                                        <td>
                                            管理员</td>
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
                                            数据绑定</td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceStoreDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResourceStore.aspx">修改</a>
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
                                            数据绑定</td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceStoreDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResourceStore.aspx">修改</a>
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
                                            数据绑定</td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceStoreDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResourceStore.aspx">修改</a>
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
                                            数据绑定</td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceStoreDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResourceStore.aspx">修改</a>
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
                                            数据绑定</td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceStoreDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResourceStore.aspx">修改</a>
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
                                            数据绑定</td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceStoreDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResourceStore.aspx">修改</a>
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
                                            数据绑定</td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceStoreDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResourceStore.aspx">修改</a>
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
                                            数据绑定</td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceStoreDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResourceStore.aspx">修改</a>
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
                                            数据绑定</td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <a href="ResourceStoreDetails.aspx">详情</a>
                                        </td>
                                        <td>
                                            <a href="UpdateResourceStore.aspx">修改</a>
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
