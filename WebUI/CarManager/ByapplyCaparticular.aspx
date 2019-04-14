<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ByapplyCaparticular.aspx.cs" Inherits="CarManager_ByapplyCaparticular" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
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
                    <h3>用车申请详细信息</h3></td>
            </tr>
            <tr>
                <td >
    
       <table id="Table1" align="center"
            >
             <tr>
                <td>
                    用车部门：
                
                    <asp:TextBox ID="txtDept" class="inputs" runat="server" Enabled="False">销售部</asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    用&nbsp; 车 人：<asp:TextBox ID="txtByMan" class="inputs" runat="server" 
                        Enabled="False">李四</asp:TextBox>
                </td>
                          
            </tr>
            <tr>
                <td>
                    &nbsp;用车日期：
                
                    <asp:TextBox ID="txtByData" class="inputs" runat="server"
                     onClick="showcalendar(event, this);" Enabled="False"
                    >2005-05-05</asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 回车日期：<asp:TextBox 
                        ID="txtReData" class="inputs" runat="server" 
                        onClick="showcalendar(event, this);" Enabled="False">2005-05-06</asp:TextBox>
                                &nbsp;</td>
            </tr>
            <tr>
                <td align="left">
                    用车类型：
                
                    <asp:TextBox ID="txtType" class="inputs" runat="server"
                     onClick="showcalendar(event, this);" Enabled="False"
                    >其他用车</asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   目&nbsp; 的 地：<asp:TextBox ID="txtByttion" class="inputs" runat="server" Enabled="False">上海</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    用车事由：
                
                    <asp:TextBox ID="txtByCause" runat="server" class="inputs" Height="138px" TextMode="MultiLine" 
                        Width="394px" Enabled="False">急于用车开会</asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" class="BigButton" Text="审批" 
                                            PostBackUrl="~/CarManager/carshenpi.aspx" />
                     &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Button2" runat="server" class="BigButton" Text="取   消" CausesValidation="False" 
                                            PostBackUrl="~/CarManager/shenlist.aspx" />
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
