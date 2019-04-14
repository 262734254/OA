<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourceInfo.aspx.cs" Inherits="ResourceManager_ResourceInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>资源信息录入</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 450px;
            background-color: #C6DAF3;
        }
        .style3
        {
            height: 153px;
        }
        .style4
        {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            text-align: center;
            background-image: url(  '../css/6/images/tablehdbg1.gif' ); /* 表格背景图           */
            font-size: 9pt; /* 字体大小             */ /*font-weight: bold;                                          字体粗               */
            width: 808px; /* 表格宽度             */
            height: 30px; /* 表格高度  图＋2      */ /* 表格边框宽度         */
            color: #264A7E;
            background-repeat: repeat-x; /* 表格背景颜色         */
        }
        .style5
        {
            width: 808px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td align="center" class="style4">
                    <h3>
                        资源信息录入</h3>
                </td>
            </tr>
            <tr>
                <td align="center" class="style5">
                    <table style="height: 422px; width: 537px;">
                        <tr align="left">
                            <td>
                                资源名称：<asp:TextBox ID="txtRIName" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRIName" runat="server" Display="Dynamic" ErrorMessage="请输入名称"
                                    ControlToValidate="txtRIName">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                资源数量：<asp:TextBox ID="txtNumber" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNumber" runat="server" ControlToValidate="txtNumber"
                                    ErrorMessage="请输入数量">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNumber" runat="server" Display="Dynamic" ErrorMessage="请输入数字"
                                    ValidationExpression="^[0-9]*[1-9][0-9]*$" ControlToValidate="txtNumber">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                资源单价：<asp:TextBox ID="txtPrice" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
                                    ErrorMessage="请输入单价">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice"
                                    Display="Dynamic" ErrorMessage="您输入的格式不正确" ValidationExpression="\d+(\.\d\d)?">*</asp:RegularExpressionValidator>
                            </td>
                            <td>
                                购买时间：<input type="text" onclick="showcalendar(event, this);" id="txtInTime" runat="server"
                                    style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    border-bottom: #99ccff 1px solid; width: 120px;" readonly="readonly" /><asp:RequiredFieldValidator
                                        ID="rfvInTime" runat="server" ErrorMessage="*" ControlToValidate="txtInTime"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                供 应 商：<asp:DropDownList ID="ddlProvider" runat="server" class="inputs" Width="120px"
                                    DataSourceID="odsProvider" DataTextField="PName" DataValueField="PID">
                                </asp:DropDownList>
                            </td>
                            <td>
                                资源类型：<asp:DropDownList ID="ddlResourceType" class="inputs" runat="server" Width="120px"
                                    DataSourceID="odsResourceType" DataTextField="RTName" DataValueField="RTID">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                资源规格：<asp:TextBox ID="txtRISpec" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRISpec" runat="server" ControlToValidate="txtRISpec"
                                    Display="Dynamic" ErrorMessage="请输入规格">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                资 料 室：<asp:DropDownList ID="ddlResourceStore" class="inputs" runat="server" Width="120px"
                                    DataSourceID="odsResourceStore" DataTextField="RSName" DataValueField="RSID">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" class="style3">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtRIRemark" class="inputs"
                                    runat="server" Height="108px" TextMode="MultiLine" Width="416px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="提   交" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="取   消" CausesValidation="False"
                                    OnClick="btnReset_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:ValidationSummary ID="vsResource" runat="server" ShowMessageBox="True" ShowSummary="False" />
        <asp:ObjectDataSource ID="odsProvider" runat="server" SelectMethod="GetAllProvider"
            TypeName="BLL.Resource.ProviderInfoManager"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsResourceType" runat="server" SelectMethod="GetAllResourceType"
            TypeName="BLL.Resource.ResourceTypeManager"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsResourceStore" runat="server" SelectMethod="GetAllResourceStore"
            TypeName="BLL.Resource.ResourceStoreManager"></asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
