<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPower.aspx.cs" Inherits="Default6" %>

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
                <h3>����Ȩ��</h3>
                    
            </td>
        </tr>
        <tr>
        <td align="center" valign="top">
       
    <table style="height: 206px">
       
            <tr>
                <td  align="right">
                    ҳ�����ƣ�</td>
                <td align="left">
                    <asp:TextBox ID="txtRoleName" runat="server" Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>&nbsp;
                </td>
            </tr>
       
            <tr>
                <td  align="right">
                    ҳ��·����</td>
                <td align="left">
                    <asp:TextBox ID="txtPageURL" runat="server" 
                        
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                </td>
            </tr>
       
            <tr>
                <td  align="right">
                    ����ģ�飺</td>
                <td align="left">
                    <asp:DropDownList ID="ddlTypes" runat="server" CssClass="BigSelect" 
                        Height="16px" Width="125px">
                        <asp:ListItem Value="4">�������</asp:ListItem>
                        <asp:ListItem Value="5">��������</asp:ListItem>
                        <asp:ListItem Value="6">��Դ����</asp:ListItem>
                        <asp:ListItem Value="9">��������</asp:ListItem>
                        <asp:ListItem Value="10">�ص��������</asp:ListItem>
                        <asp:ListItem Value="11">�칫����</asp:ListItem>
                        <asp:ListItem Value="12">Ȩ�޹���</asp:ListItem>
                        <asp:ListItem Value="13">��ر����ӡ</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td  align="right">
                    ��&nbsp;&nbsp;&nbsp;ע��</td>
                <td  align="left">
                    <asp:TextBox ID="txtRemark" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                        TextMode="MultiLine" Height="98px" Width="317px"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <td  colspan="2" align="center">
               
                <asp:Button ID="btnAddPower" class="BigButton" runat="server" Text="ȷ   ��" 
                    onclick="btnAddPower_Click1"/>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnBack" class="BigButton" runat="server" Text="��   ��" 
                    CausesValidation="False" PostBackUrl="~/PowerManager/Role/RoleList.aspx" 
                    onclick="btnBack_Click" />
            </td>
        
    </table>
       
        </td>
        </tr>
    </table>
    </div>
    </form>
    </body>
</html>

