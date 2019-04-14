<%@ Page Language="C#"  ValidateRequest="false" AutoEventWireup="true" CodeFile="byapply.aspx.cs" Inherits="CarManager_byapply"   %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用车申请页面</title>
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
            height: 428px;
        }
        .style2
        {
            height: 158px;
        }
        </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>用车申请单</h3></td>
            </tr>
            <tr>
<td align="center">
    
                            <table id="Table1"
            >
                                <tr>
                                    <td align="left">
                                        用车部门：<asp:TextBox ID="txtDept" class="inputs" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        用&nbsp; 车 人：<asp:TextBox ID="txtMan" class="inputs" runat="server" 
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        目&nbsp; 的 地：<asp:TextBox ID="txtByttion" class="inputs" runat="server" 
                                            MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtByttion"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        用车日期：<asp:TextBox ID="txtByData" runat="server" CssClass="inputs" 
                                            onclick="showcalendar(event, this);" ></asp:TextBox>
                                       
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                            ControlToValidate="txtByData" ErrorMessage="*"></asp:RequiredFieldValidator>
                                       
                                        
                                    </td>
                                    <td align="left">
                                        回车日期：<asp:TextBox ID="txtReData" runat="server" CssClass="inputs" 
                                            onclick="showcalendar(event, this);"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                            ControlToValidate="txtReData" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;</td>
                                    <td align="left">
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                            ControlToCompare="txtByData" ControlToValidate="txtReData" 
                                            ErrorMessage="回车日期必须大于或等于用车日期" Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        用车类型：&nbsp; 
                                        <asp:RadioButton ID="rdo1" class="inputs" runat="server" Text="普通车辆" 
                        GroupName="a" Checked="True" />
                                        <asp:RadioButton ID="rdo2" class="inputs" runat="server" Text="接待用车" 
                        GroupName="a" />
                                        <asp:RadioButton ID="rdo3" class="inputs" runat="server" Text="大型活动用车" 
                        GroupName="a" />
                                        <asp:RadioButton ID="rdo4" class="inputs" runat="server" Text="其它用车" 
                        GroupName="a" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2" colspan="2">
                                        用车事由：<asp:TextBox ID="txtByCause" runat="server" class="inputs" 
                        Height="126px" TextMode="MultiLine" 
                        Width="434px" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                        runat="server" ErrorMessage="*"
                                    ControlToValidate="txtByCause"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                             
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnSubmit"  class="BigButton" runat="server" Text="提   交" 
                        onclick="btnSubmit_Click" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnback" class="BigButton" 
                                            runat="server"   PostBackUrl="~/CarManager/shenlist.aspx"
                        Text="返   回" onclick="btnback_Click" CausesValidation="False" />
                                        &nbsp;
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
