<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateResource.aspx.cs" Inherits="ResourceManager_UpdateResource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>资源修改</title>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        资源修改</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table style="height: 422px; width: 537px;">
                        <tr align="left">
                            <td>
                                资源名称：<asp:TextBox ID="txtResourceName" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvResourceName" runat="server" ErrorMessage="请输入资源名称"
                                    ControlToValidate="txtResourceName">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                资源数量：<asp:TextBox ID="txtNumber" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNumber" runat="server" ErrorMessage="请输入资源数量"
                                    ControlToValidate="txtNumber">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revNumber" runat="server" Display="Dynamic" ErrorMessage="请输入数字"
                                    ValidationExpression="^[0-9]*[1-9][0-9]*$" ControlToValidate="txtNumber">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                资源单价：<asp:TextBox ID="txtPrice" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice"
                                    Display="Dynamic" ErrorMessage="您输入的格式不正确" ValidationExpression="\d+(\.\d\d)?">*</asp:RegularExpressionValidator>
                            </td>
                            <td>
                                购买时间：<input id="txtTime" name="txtInTime" type="text" style="width: 120px; height: 17px;
                                    border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    border-bottom: #99ccff 1px solid;" runat="server" onclick="showcalendar(event, this);"
                                    readonly="readonly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请选择时间"
                                    ControlToValidate="txtTime">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                供 货 商：<asp:DropDownList ID="ddlProvider" runat="server" Width="120px" DataSourceID="odsProvider"
                                    DataTextField="PName" DataValueField="PID">
                                </asp:DropDownList>
                            </td>
                            <td>
                                资源类型：<asp:DropDownList ID="ddlType" class="inputs" runat="server" Width="120px" DataSourceID="odsType"
                                    DataTextField="RTName" DataValueField="RTID">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                资源规格：<asp:TextBox ID="txtRISpec" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRISpec" runat="server" ErrorMessage="请输入资源规格"
                                    ControlToValidate="txtRISpec">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                资源状态：<asp:DropDownList ID="ddlState" class="inputs" runat="server" Width="120px">
                                    <asp:ListItem Selected="True" Value="0">--请选择--</asp:ListItem>
                                    <asp:ListItem Value="1">可用</asp:ListItem>
                                    <asp:ListItem Value="2">禁用</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" class="style3">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtRemark" class="inputs"
                                    runat="server" Height="108px" TextMode="MultiLine" Width="416px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="保   存" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="返   回" OnClick="btnReset_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:ValidationSummary ID="vsEditResource" runat="server" ShowMessageBox="True" ShowSummary="False" />
    <asp:ObjectDataSource ID="odsType" runat="server" SelectMethod="GetAllResourceType"
        TypeName="BLL.Resource.ResourceTypeManager"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsProvider" runat="server" SelectMethod="GetAllProvider"
        TypeName="BLL.Resource.ProviderInfoManager"></asp:ObjectDataSource>
    </form>
</body>
</html>
