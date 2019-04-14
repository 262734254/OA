<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GouCheShenPi.aspx.cs" Inherits="CarManager_GouCheShenPi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">



<head id="Head1" runat="server">
    <title>购车申请页面</title>
   <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />     
    <link rel="Stylesheet" type="text/css" href="../js/calendar.js" />   
    <style type="text/css">
        .style4
        {
            width: 100%; background-color:#C6DAF3;
            height: 450px;
        }
        .style5
        {
            height: 43px;
        }
        .style6
        {
            height: 37px;
        }
        .style7
        {
            height: 86px;
        }
        .style8
        {
            height: 60px;
        }
        </style>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
    
        <table class="style4">
            <tr>
               <td colspan="2" align="center" class="title1">
                <h3>购车审批单</h3>
                    </td>
            </tr>
            <tr>
                <td align="center">
    
        <table style="height: 430px">
            <tr>
                <td>
                    购买日期：&nbsp;<asp:TextBox ID="TextBox1" runat="server" Enabled="False">2010-05-05</asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;申请购车部门：<asp:TextBox 
                        ID="txtDepartment" class="inputs" runat="server" Enabled="False" 
                        ReadOnly="True">财务部</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtDepartment"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style6" >
                    所&nbsp; 需&nbsp; 资 金：：<asp:TextBox ID="txtNeedMoney" class="inputs" 
                        runat="server" Enabled="False" ReadOnly="True">50000</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtNeedMoney"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td align="left" class="style5">
                    车辆类型：<asp:RadioButton ID="RadioButton1" class="inputs" runat="server" 
                        Text="普通车辆" GroupName="a" Checked="True" Enabled="False" />
                    <asp:RadioButton ID="RadioButton2" class="inputs" runat="server" Text="接待用车" 
                        GroupName="a" />
                    <asp:RadioButton ID="RadioButton3" class="inputs" runat="server" Text="大型活动用车" 
                        GroupName="a" />
                    <asp:RadioButton ID="RadioButton4" class="inputs" runat="server" Text="其它用车" 
                        GroupName="a" />
                </td>
            </tr>
            <tr>
                <td class="style7" valign="top">
                    购车理由： 
                    <asp:TextBox ID="txtSake" 
                        class="inputs" runat="server" Height="85px" TextMode="MultiLine" 
                        Width="403px" Enabled="False" ReadOnly="True">部门缺车！！！</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtSake"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                <td valign="top" class="style8">
                    备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtRemark" 
                        class="inputs" runat="server" Height="53px" TextMode="MultiLine" 
                        Width="403px" Enabled="False" ReadOnly="True">部门缺车</asp:TextBox>
                </td>
               
            </tr>
            
            <tr>
                <td>
                    审批人：<asp:TextBox ID="txtName" class="inputs" 
                        runat="server">王五</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                        runat="server" ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
               
            </tr>
            
            <tr>
                <td align="center" class="style2">
                    <asp:Button ID="Button1" class="BigButton" PostBackUrl="~/PedingMatter/Auditing.aspx"
                        runat="server" Text="审 批" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <input id="btnExit" type="button" value="返  回" onclick="history.go(-1);" class="BigButton" />
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
