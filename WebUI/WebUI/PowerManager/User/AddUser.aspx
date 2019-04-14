<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="User" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加用户</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height:450px;
            background-color:#C6DAF3;
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
        .style4
        {
            height: 29px;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="../../css/6/style.css" />
</head>
<body class="bodycolor">
    <form id="form1" runat="server">
   <div>
        <table class="style1">
            <tr>
                <td  align="center" class="title1">
      <h3>添加用户</h3>
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
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    身份证号码：</td>
                <td>
                    <asp:TextBox ID="txtIDcard" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtIDcard" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
          <tr  align="left">
                <td>
                    用户密码：</td>
                <td>
                    <asp:TextBox ID="txtpass" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtpass" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    确 认 密码：</td>
                <td>
                    <asp:TextBox ID="txtpassword" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtpassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtpass" ControlToValidate="txtpassword" 
                        ErrorMessage="CompareValidator"></asp:CompareValidator>
                </td>
            </tr>
              <tr  align="left">
                <td>
                    用户性别：</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                                </td>
                <td>
                    用 户 年龄：</td>
                <td>
                    <asp:TextBox ID="txtAge" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                                </td>
            </tr>
              <tr  align="left">
                <td>
                    手机号码：</td>
                <td>
                    <asp:TextBox ID="txtphone" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                  </td>
                <td>
                    座 机 号码：</td>
                <td>
                    <asp:TextBox ID="txtseat" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                                </td>
            </tr>
              <tr  align="left">
                <td>
                                        地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 址：</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" Height="22px" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                  </td>
                <td>
                    Q&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Q：</td>
                <td>
                    <asp:TextBox ID="txtQQ" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                                </td>
            </tr>
              <tr  align="left">
                <td>Email：</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                  </td>
                <td>
                    MSN：</td>
                <td>
                    <asp:TextBox ID="txtMSN" runat="server" 
                        Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                                </td>
            </tr>
              <tr  align="left">
                <td class="style4">
                    所属部门：</td>
                <td class="style4" colspan="3">
                    <asp:HiddenField ID="HiddenField1" runat="server" Value="在职" />
                    <asp:DropDownList ID="DropDownList2" runat="server" 
                        DataSourceID="objDepartment" DataTextField="Departmentname" DataValueField="Id">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="objDepartment" runat="server" 
                        SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
                    </asp:ObjectDataSource>
                  </td>
            </tr>
              <tr  align="left">
                <td>
                    用户头像：</td>
                <td class="style2" colspan="3">
                    <input id="fileUpload" runat="server" onchange="checkInput(this)" type="file" /></td>
            </tr>
              <tr  align="left">
                <td>
                    备注：</td>
                <td class="style2" colspan="3">
                    <asp:TextBox ID="TextBox14" runat="server" Height="91px" TextMode="MultiLine"  Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                        Width="456px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="TextBox14" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
            </tr>
               <tr align="center">
                <td class="style3" colspan="4">
                    <asp:Button ID="Button1" runat="server" class="BigButton" Text="添   加" 
                        onclick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" class="BigButton" Text="取消" 
                        CausesValidation="False" PostBackUrl="~/PowerManager/User/UserList.aspx" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
