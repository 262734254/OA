<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateUser.aspx.cs" Inherits="PowerManager_User_UpdateUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改用户</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height:450px;
            background-color:#C6DAF3;
        }
        .style4
        {
            height: 29px;
        }
        .style2
        {
            height: 90px;
        }
        .style3
        {
            width: 100%;
            height: 27px;
            background-color: #C6DAF3;
        }
        </style>
    <link rel="stylesheet" type="text/css" href="../../css/6/style.css" />
</head>
<body class="bodycolor">
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        修改用户</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table style="height: 523px; width: 605px">
                        <tr align="left">
                            <td>
                                用户姓名：</td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">海潮</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                身份证号码：</td>
                            <td>
                                <asp:TextBox ID="txtIDcard" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">430921199009257075</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtIDcard" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                用户性别：</td>
                            <td>
                                <asp:RadioButtonList ID="rdoSex" runat="server" RepeatDirection="Horizontal" 
                                    Width="108px">
                                    <asp:ListItem Value="男">男</asp:ListItem>
                                    <asp:ListItem Value="女">女</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                用 户 年龄：</td>
                            <td>
                                <asp:TextBox ID="txtAge" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">20</asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                手机号码：</td>
                            <td>
                                <asp:TextBox ID="txtphone" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">15873097627</asp:TextBox>
                            </td>
                            <td>
                                座 机 号码：</td>
                            <td>
                                <asp:TextBox ID="txtseat" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">8617602</asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 址：</td>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server" Height="22px" 
                                    Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">五里牌</asp:TextBox>
                            </td>
                            <td>
                                Q&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Q：</td>
                            <td>
                                <asp:TextBox ID="txtQQ" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">624197002</asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                Email：</td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">lubentao@tom.com</asp:TextBox>
                            </td>
                            <td>
                                MSN：</td>
                            <td>
                                <asp:TextBox ID="txtMSN" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">123456</asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td class="style4">
                                所属部门：</td>
                            <td class="style4" colspan="3">
                                <asp:DropDownList ID="DropDownList2" runat="server" 
                                    DataSourceID="ObjDepartemnt" DataTextField="departmentName" DataValueField="Id">
                                    <asp:ListItem>会议部门</asp:ListItem>
                                    <asp:ListItem>车辆管理部门</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjDepartemnt" runat="server" 
                                    SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                用户头像：</td>
                            <td class="style2" colspan="3">
                                <asp:Image ID="Image1" runat="server" Height="139px" 
                                    Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                    Width="180px" />
                                <input id="fileUpload" runat="server" type="file" /></td>
                        </tr>
                        <tr align="left">
                            <td>
                                备注：</td>
                            <td class="style2" colspan="3">
                                <asp:TextBox ID="TextBox14" runat="server" Height="91px" 
                                    Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                    TextMode="MultiLine" Width="456px">很好很强大</asp:TextBox>
                                *</td>
                        </tr>
                        <tr align="center">
                            <td class="style3" colspan="4">
                                <asp:Button ID="Button1" runat="server" class="BigButton" 
                                    onclick="Button1_Click" Text="保   存" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button2" runat="server" CausesValidation="False" 
                                    class="BigButton" PostBackUrl="~/PowerManager/User/UserList.aspx" Text="取消" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
