<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GouCheCaparticular.aspx.cs" Inherits="CarManager_GouCheCaparticular" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <title>购车详细页面</title>
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
        </style>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
    
        <table class="style4">
            <tr>
               <td colspan="2" align="center" class="title1">
                <h3>购车申请单</h3>
                    </td>
            </tr>
            <tr>
                <td align="center">
    
        <table style="height: 430px">
            <tr>
                <td>
                    购买日期：<asp:TextBox ID="txtByDate" class="inputs" runat="server" 
                        Enabled="False">2010-05-06</asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 申请购车部门：<asp:TextBox ID="txtDepartment" class="inputs" runat="server">财务部</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6" >
                    车 辆 数：<asp:TextBox ID="txtCarNum" class="inputs" runat="server" 
                        Enabled="False">1</asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    所&nbsp; 需&nbsp; 资 金：<asp:TextBox ID="txtNeedMoney" class="inputs" 
                        runat="server" Enabled="False">500000</asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td align="left" class="style5">
                    车辆类型：<asp:RadioButton ID="RadioButton1" class="inputs" runat="server" 
                        Text="普通车辆" GroupName="a" Checked="True" />
                    <asp:RadioButton ID="RadioButton2" class="inputs" runat="server" Text="接待用车" 
                        GroupName="a" Enabled="False" />
                    <asp:RadioButton ID="RadioButton3" class="inputs" runat="server" Text="大型活动用车" 
                        GroupName="a" Enabled="False" />
                    <asp:RadioButton ID="RadioButton4" class="inputs" runat="server" Text="其它用车" 
                        GroupName="a" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td>
                    购车理由： <asp:TextBox ID="txtSake" 
                        class="inputs" runat="server" Height="113px" TextMode="MultiLine" 
                        Width="403px">部门却车啊！！！</asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtRemark" 
                        class="inputs" runat="server" Height="113px" TextMode="MultiLine" 
                        Width="403px" Enabled="False"></asp:TextBox>
                </td>
               
            </tr>
            
            <tr>
                <td align="center" class="style2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" class="BigButton" runat="server"  Text="返回" 
                        PostBackUrl="~/CarManager/MyGouCheApply.aspx" />
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

