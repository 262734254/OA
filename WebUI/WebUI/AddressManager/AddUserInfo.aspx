<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUserInfo.aspx.cs" Inherits="AddressManager_UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户信息录入页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet"/>
      <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .style1
        {
             width: 100%; background-color:#C6DAF3;
            height: 450px;
        }
        .style2
        {
            height: 127px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
               <td align="center" class="title1">
                  <h3>用户信息录入</h3></td>
            </tr>
            <tr>
                <td align="center">
    
        <table style="height: 401px">
             <tr>
                <td>
                    姓&nbsp;&nbsp; 名：<asp:TextBox ID="txtName" class="inputs" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <td>
                    年&nbsp;&nbsp;&nbsp; 龄 ：<asp:TextBox ID="txtAge" class="inputs" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtAge" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    QQ 号：<asp:TextBox ID="txtQQ" class="inputs" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtQQ" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <td>
                    性别：<asp:RadioButton ID="rdoboy" runat="server" Text="男" GroupName="a" />
                    <asp:RadioButton ID="rdogirl" runat="server" Text="女" GroupName="a" />
                &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    手机号：<asp:TextBox ID="txtPhone" class="inputs" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtPhone" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <td>
                    座 机 号 ：<asp:TextBox ID="txtSeat" class="inputs" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Email ：<asp:TextBox ID="txtEmail" class="inputs" runat="server"></asp:TextBox>
                </td>
                <td>
                    身份证号：<asp:TextBox ID="txtIDcard" class="inputs" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    M S N：<asp:TextBox ID="txtMSN" class="inputs" runat="server"></asp:TextBox>
                </td>
                <td>
                    所属部门：<asp:DropDownList ID="drobrach" class="inputs" runat="server">
                        <asp:ListItem>员工部</asp:ListItem>
                        <asp:ListItem>项目部</asp:ListItem>
                    </asp:DropDownList>
                &nbsp; 选择组：<asp:DropDownList ID="droGroup" class="inputs" runat="server">
                        <asp:ListItem>个人</asp:ListItem>
                        <asp:ListItem>公司</asp:ListItem>
                        <asp:ListItem>客户</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    地&nbsp; 址 ：<asp:TextBox ID="txtAddress" class="inputs" runat="server" 
                        Width="424px"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td colspan="2" class="style2">
                    备注：<asp:TextBox ID="txtRemark" runat="server" class="inputs" Height="100px" 
                        TextMode="MultiLine" Width="438px"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="Button1" runat="server" class="BigButton" 
                        PostBackUrl="~/AddressManager/Userlist.aspx" Text="保   存" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" class="BigButton" 
                        PostBackUrl="~/AddressManager/Userlist.aspx" Text="取   消" 
                        CausesValidation="False" />
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
