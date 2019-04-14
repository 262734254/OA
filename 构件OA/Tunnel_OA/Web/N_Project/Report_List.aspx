<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_List.aspx.cs" Inherits="N_Project_Report_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="98%" border="1" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC"
        bordercolorlight="#c8c8c8" bordercolordark="#FFFFFF" style="border-collapse: collapse;
        border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid; border-top: 1px #6f97b1 solid;
        border-bottom: 1px #6f97b1 solid;" align="center">
        <tr>
            <td width="50" height="30" align="center" bgcolor="#f6f6f6">
                <strong>选 择</strong>
            </td>
            <td width="200" style="border-top: 0px;" width="110" align="center" bgcolor="#f6f6f6">
                <strong>模版名称</strong>
            </td>
            <td width="100" style="border-top: 0px;" width="110" align="center" bgcolor="#f6f6f6">
                <strong>模版类别</strong>
            </td>
            <td width="500" style="border-top: 0px; border-right: 0px;" width="90" align="center" bgcolor="#f6f6f6">
                <strong>操作</strong>
            </td>
        </tr>
        <tr>
            <td  height="30" align="center" bgcolor="#ffffff">
                &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" /></td>
            <td align="center" bgcolor="#ffffff">
                &nbsp;</td>
            <td  align="center" bgcolor="#ffffff">
                &nbsp;</td>
            <td  align="center" bgcolor="#ffffff">
                &nbsp;设计 修改 删除 停用 填报权限 阅读权限 流程设计 提醒设置</td>
        </tr>
        <tr>
            <td height="30" colspan="4" align="left" bgcolor="#e6f7ff" 
                style="border: 0px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBox2" Text="全选" runat="server" /> 
                <asp:LinkButton ID="LinkButton1" runat="server">删除选中</asp:LinkButton></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
