<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRole.aspx.cs" Inherits="Default6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>��ӽ�ɫ</title>
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
            <td class="title1" align="center">
                <h3>�½���ɫ</h3>
                    
            </td>
        </tr>
        <tr>
        <td align="center" valign="top">
       
    <table style="height: 206px">
       
            <tr>
                <td  align="right">
                    �������ţ�</td>
                <td align="left">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>�г���</asp:ListItem>
                        <asp:ListItem>����</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
       
            <tr>
                <td  align="right">
                    ��ɫ���ƣ�</td>
                <td align="left">
                    <asp:TextBox ID="txtRoleName" runat="server" Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td  align="right">
                    ��&nbsp;&nbsp;&nbsp;ע��</td>
                <td  align="left">
                    <asp:TextBox ID="txtDecription" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                        TextMode="MultiLine" Height="98px" Width="317px"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <td  colspan="2" align="center">
               
                <asp:Button ID="btnAddNewRole" class="BigButton" runat="server" Text="ȷ   ��"  
                    PostBackUrl="~/PowerManager/Role/RoleList.aspx" 
                    onclick="btnAddNewRole_Click"/>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="Button2" class="BigButton" runat="server" Text="��   ��" 
                    CausesValidation="False" PostBackUrl="~/PowerManager/Role/RoleList.aspx" />
            </td>
        
    </table>
       
        </td>
        </tr>
    </table>
    </div>
    </form>
    </body>
</html>

