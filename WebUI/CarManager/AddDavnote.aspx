<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDavnote.aspx.cs" Inherits="CarManager_AddDavnote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>出车添加</title>
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
        .style3
        {
            width: 162px;
        }
    </style>
  
</head>
<body>
<div>
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td align="center" class="title1">
                    <h3>出车添加</h3></td>
        </tr>
        <tr>
            <td align="center">
    
    
            <table style="height: 435px; width: 573px;">
                            <tr>
                                <td>
                                    车&nbsp; 牌&nbsp;号：<asp:DropDownList ID="dllMark" runat="server" 
                                        DataSourceID="odsMark" DataTextField="CarMark" DataValueField="CarMark">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsMark" runat="server" 
                                        SelectMethod="SelectCarMarkState" TypeName="BLL.Car.CarsManager">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="未出车" Name="State" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td colspan="2" align="left">
                                    出车部门：<asp:DropDownList 
                        ID="drpDept" class="inputs" runat="server" 
                        ontextchanged="drpDept_TextChanged" 
                        ondatabound="drpDept_DataBound" AppendDataBoundItems="True" AutoPostBack="True" 
                                        DataSourceID="odsDept" DataTextField="departmentName" DataValueField="Id">
                                       
                                    </asp:DropDownList>
                                    出&nbsp; 车&nbsp;人：<asp:DropDownList ID="drpMan" runat="server" 
                                        AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsDept" runat="server" 
                                        SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    起始地点：<asp:TextBox ID="txtStartAddr" class="inputs" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtStartAddr"></asp:RequiredFieldValidator>
                                </td>
                                <td colspan="2" align="left">
                                    驾&nbsp; 驶&nbsp;员：<asp:DropDownList ID="drpDriver" runat="server" 
                                        AppendDataBoundItems="True" DataSourceID="odsDriver" 
                                        DataTextField="UserName" DataValueField="UserId">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsDriver" runat="server" 
                                        SelectMethod="usp_CarUserNameState" TypeName="BLL.Car.CarUserInfoManager">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="未出车" Name="State" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    出车日期：<asp:TextBox ID="txtOutData" class="inputs" runat="server"
                     onClick="showcalendar(event, this);"
                    ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtOutData"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;起始里程：<asp:TextBox ID="txtLiCheng" class="inputs" runat="server"></asp:TextBox>
                                </td>
                                <td class="style3">
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
                                    返回日期：<asp:TextBox ID="txtReturnDate" class="inputs" runat="server"
                     onClick="showcalendar(event, this);"
                    ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtReturnDate"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    目&nbsp; 的 地：<asp:TextBox ID="txtDirection" class="inputs" runat="server"></asp:TextBox>
                                </td>
                                <td align="left" class="style3">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtDirection"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3">
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                    车辆类型：<asp:RadioButton ID="rdo1" class="inputs" runat="server" 
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
                        TextMode="MultiLine" Width="450px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSubmit"  class="BigButton" runat="server" Text="提   交" 
                        onclick="btnSubmit_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;<asp:Button ID="btnback" class="BigButton" runat="server" 
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