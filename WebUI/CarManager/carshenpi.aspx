<%@ Page Language="C#" AutoEventWireup="true" CodeFile="carshenpi.aspx.cs" Inherits="carshenpi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用车审批页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet"/>
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />   
   <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
   
    <style type="text/css">
        .style1
        {
            width: 100%; background-color:#C6DAF3;
           height: 450px;
        }
        #Table1
        {
            height: 430px;
        }
        .style2
        {
            height: 142px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td >
                    <h3 align="center">用车审批单</h3></td>
            </tr>
            <tr>
                <td align="center">
    
       <table id="Table1"
            >
             <tr>
                <td>
                    用车部门：
                
                    <asp:TextBox ID="txtDept" class="inputs" runat="server" ReadOnly="True">销售部</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtDept"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    用&nbsp; 车 人：<asp:TextBox ID="txtByMan" class="inputs" runat="server" 
                        Enabled="False" ReadOnly="True">张三</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtByMan"></asp:RequiredFieldValidator>
                </td>
                          
            </tr>
            <tr>
                <td>
                    用车日期：
                
                    <asp:TextBox ID="txtByData" class="inputs" runat="server" 
                        onClick="showcalendar(event, this);" Enabled="False" ReadOnly="True">2010-05-05</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtByData"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   回车日期：<asp:TextBox ID="txtReData" class="inputs" runat="server" 
                        onClick="showcalendar(event, this);" Enabled="False" ReadOnly="True">2010-05-06</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtReData"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left">
                    用车类型：
                
                    <asp:RadioButton ID="RadioButton1" class="inputs" runat="server" Text="普通车辆" 
                        GroupName="a" Checked="True" Enabled="False" />
                    <asp:RadioButton ID="RadioButton2" class="inputs" runat="server" Text="接待用车" 
                        GroupName="a" />
                    <asp:RadioButton ID="RadioButton3" class="inputs" runat="server" Text="大型活动用车" 
                        GroupName="a" />
                    <asp:RadioButton ID="RadioButton4" class="inputs" runat="server" Text="其它用车" 
                        GroupName="a" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    用车事由：
                
                    <asp:TextBox ID="txtByCause" runat="server" class="inputs" Height="138px" TextMode="MultiLine" 
                        Width="394px" Enabled="False" ReadOnly="True">用车用车</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtByCause"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="left"> &nbsp;&nbsp;目&nbsp; 的 地：<asp:TextBox ID="txtByttion" 
                        class="inputs" runat="server" Enabled="False">长沙</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtByttion"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
            <tr>
                <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" class="BigButton" Text="审 批" 
                                            PostBackUrl="~/PedingMatter/Auditing.aspx"/>
                     &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Button2" runat="server" class="BigButton"  CausesValidation="False" 
                                            PostBackUrl="~/CarManager/shenlist.aspx" Text="返   回" />
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
