﻿<%@ Page Language="C#"  ValidateRequest="false" AutoEventWireup="true" CodeFile="Enter.aspx.cs" Inherits="CarManager_Enter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>回车列表</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />   
    <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
    <style type="text/css">
        .style1
        {
           width: 100%; background-color:#C6DAF3;
            height: 450px;
        }
        .style2
        {
            height: 153px;
        }
    </style>
  
</head>
<body>
<div>
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td align="center" class="title1">
                
                    <h3>回车登记</h3></td>
        </tr>
        <tr>
            <td align="center">
    
    
        <table style="height: 435px; width: 573px;">
                            <tr>
                                <td>
                                    &nbsp;车&nbsp; 牌&nbsp;号：&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtMark" class="inputs" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtMark"></asp:RequiredFieldValidator>
                                </td lign="left">
                                <td>
                                 出车部门：<asp:DropDownList ID="ddlDepartment" runat="server" DataSourceID="odsDept" 
                                        DataTextField="departmentName" DataValueField="Id" Enabled="False">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsDept" runat="server" 
                                        SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
                                    </asp:ObjectDataSource>
                                </td>
                                <td >
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    起始地点：&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtStartAddr" class="inputs" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtStartAddr"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left">
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 出车人:<asp:TextBox ID="txtMan" class="inputs" runat="server" 
                                        Enabled="False"></asp:TextBox>
                                </td>
                                <td >
                                   
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    出车日期：&nbsp;&nbsp;&nbsp; &nbsp;<input type="text" ID="txtOutDate" 
                                        runat="server" class="inputs" readonly="readonly" visible="True" 
                         /><asp:RequiredFieldValidator ID="RequiredFieldValidator12" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtOutDate"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;起始里程：<asp:TextBox ID="txtLiCheng" class="inputs" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtLiCheng"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtLiCheng" ErrorMessage="请输入正确的里程数！" 
                        Type="Double" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    预计返回日期: 
                                    <input type="text" ID="txtReturnDate" runat="server" class="inputs" readonly="readonly" 
                         /><asp:RequiredFieldValidator ID="RequiredFieldValidator15" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtReturnDate"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    目&nbsp; 的 地：<asp:TextBox ID="txtDirection" runat="server" CssClass="inputs"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtDirection"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    实际返回日期：<asp:TextBox ID="txtShiJireturnDate" class="inputs" runat="server"
                     onClick="showcalendar(event, this);"
                    ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                        ControlToValidate="txtShiJireturnDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    回车里程：<asp:TextBox ID="txtHuiCheLiCheng" class="inputs" runat="server" 
                                        MaxLength="6"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                        ErrorMessage="*" ControlToValidate="txtHuiCheLiCheng"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToValidate="txtHuiCheLiCheng" ErrorMessage="请输入正确的里程数！" 
                        Type="Double" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    驾&nbsp; 驶&nbsp;员：<asp:TextBox ID="txtDriver" runat="server" CssClass="inputs" 
                                        Enabled="False"></asp:TextBox>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3">
                                    &nbsp;&nbsp;车辆类型：<asp:RadioButton ID="rdo1" class="inputs" runat="server" 
                        Text="普通车辆" GroupName="a" Checked="True" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdo2" class="inputs" runat="server" Text="接待用车" 
                        GroupName="a" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdo3" class="inputs" runat="server" Text="大型活动用车" 
                        GroupName="a" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdo4" class="inputs" runat="server" Text="其它用车" 
                        GroupName="a" />
                                </td>
                            </tr>
                           <tr>
                                <td class="style2" colspan="3">
                                    备注：<asp:TextBox ID="txtReMark" runat="server" Height="100px" 
                        TextMode="MultiLine" Width="450px" MaxLength="100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btnHuiChe" runat="server" CssClass="BigButton" 
                                        onclick="btnHuiChe_Click1" Text="回 车" />
                                    &nbsp;<asp:Button ID="btnback" class="BigButton" runat="server" 
                        Text="返   回" CausesValidation="False" 
                        PostBackUrl="~/CarManager/Davnotelist.aspx" onclick="btnback_Click" />
                                    &nbsp;&nbsp;&nbsp;
                                    </td>
                            </tr>
                        </table>
    
   
            </td>
        </tr>
    </table>
    
    </form>
     </div>
</body>
</html>