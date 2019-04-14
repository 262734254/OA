<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateRole.aspx.cs" Inherits="Default7" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>角色编辑</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <link rel="stylesheet" type="text/css" href="../../css/6/style.css" />
    <style type="text/css">
        .style1
        {
            width: 100%; background-color:#C6DAF3;
            height: 450px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server" method="post" name="form1">
       <div>
       
           <table class="style1">
               <tr>
                   <td align="center" class="title1">
                     <h3>修改角色信息</h3></td>
               </tr>
               <tr>
                   <td align="center" valign="top">
        <table style="height: 222px; width: 368px">
            <tr align="left">
                <td>
                    角色编号：</td>
                <td >
                    <asp:Label ID="lblRoleId" runat="server"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr align="left">
                <td>
                    角色名称：</td>
                <td>
                    <asp:TextBox ID="txtRoleName" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                        MaxLength="10">会议管理</asp:TextBox></td>
            </tr>
            <tr align="left">
                <td style="height: 36px">
                    备 &nbsp; &nbsp; 注：</td>
                <td style="height: 36px">
                    <asp:TextBox ID="txtRemark" runat="server" Style="border: #99ccff 1px solid;" 
                        TextMode="MultiLine" Height="74px" Width="275px" MaxLength="48">天天向上</asp:TextBox></td>
            </tr>
            <td colspan="2" align="center">
               <asp:Button ID="btnSure" class="BigButton" runat="server" Text="确   定" 
                    onclick="btnSure_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBack" class="BigButton" runat="server" Text="返   回" 
                    CausesValidation="False" PostBackUrl="~/PowerManager/Role/RoleList.aspx" 
                    onclick="btnBack_Click" />
                <asp:HiddenField ID="hidepartId" runat="server" />
            </td>
        </table>
                   </td>
               </tr>
           </table>
       
       </div>
    </form>
</body>
</html>
