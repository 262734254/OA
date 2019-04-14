<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectResource.aspx.cs" Inherits="ResourceManager_SelectResource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择资源</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 450px;
            background-color: #C6DAF3;
        }
        .style2
        {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center" class="style1">
        <table width="400px">
            <tr class="TableHeader">
                <th colspan="2" class="style2" align="left" style="color:Black">
                    添加资源
                </th>
            </tr>
            <tr class="TableContent">
                <td class="style2">
                    资源类型 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlResourceType" runat="server" AutoPostBack="True" DataSourceID="odsResourceType"
                        DataTextField="RTName" DataValueField="RTID" OnSelectedIndexChanged="ddlResourceType_SelectedIndexChanged"
                        Width="120px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="TableContent">
                <td class="style2">
                    资源名称 ：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlResourceName" runat="server" AutoPostBack="True" DataSourceID="odsResourceList"
                        DataTextField="RIName" DataValueField="RIID" OnSelectedIndexChanged="ddlResourceName_SelectedIndexChanged"
                        Width="120px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="TableContent">
                <td class="style2">
                    资源规格 ：
                </td>
                <td align="left">
                    <asp:Label ID="lblSpec" runat="server" Class="BigInput" CssClass="inputs" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr class="TableContent">
                <td class="style2">
                    数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 量：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNumber" class="inputs" runat="server" Width="120px" ValidationGroup="2"></asp:TextBox>
                    <asp:CompareValidator ID="cvNumber" runat="server" 
                        ControlToValidate="txtNumber" Display="Dynamic" ErrorMessage="请输入数字" 
                        Type="Integer">*</asp:CompareValidator>
                </td>
            </tr>
            <tr class="TableContent">
                <td class="style2">
                    单&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 价：
                </td>
                <td align="left">
                    <asp:Label ID="lblPrice" runat="server" CssClass="inputs" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr class="TableContent">
                <td class="style2">
                    供&nbsp; 应&nbsp; 商：
                </td>
                <td align="left">
                    <asp:Label ID="lblProvider" runat="server" CssClass="inputs" Width="120px"></asp:Label>
                </td>
            </tr>
            <tr class="TableContent">
                <td colspan="2" class="style2">
                    <asp:Button ID="btnAdd" runat="server" Text="添加" ValidationGroup="2" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="取消" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </div>
    <asp:ObjectDataSource ID="odsResourceList" runat="server" SelectMethod="GetAllResourceInfo"
        TypeName="BLL.Resource.ResourceInfoManager">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlResourceType" DefaultValue="1" Name="typeid"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsResourceType" runat="server" SelectMethod="GetAllResourceType"
        TypeName="BLL.Resource.ResourceTypeManager"></asp:ObjectDataSource>
    </form>
</body>
</html>
