<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MeetingInform.aspx.cs" Inherits="OfficeHelp_LeaveMessage_MeetingInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会议通知详情</title>
 <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />  
<script language="javascript" type="text/javascript">
</script>
    <style type="text/css">
        .style2
        {
            height: 2px;
        }
        .style3
        {
            height: 16px;
        }
        .style4
        {
            height: 14px;
            width: 65px;
        }
        .style5
        {
            height: 24px;
            width: 65px;
        }
        .style6
        {
            height: 2px;
            width: 65px;
        }
        .style7
        {
            width: 65px;
        }
        .style8
        {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            text-align: center;
            background-image: url('../css/6/images/tablehdbg1.gif') ;          /* 表格背景图           */
            font-size: 9pt; /* 字体大小             */ /*font-weight: bold;                                          字体粗               */;
            width: 100%; /* 表格宽度             */;
            height: 31px;                                              /* 表格高度  图＋2      */
/* 表格边框宽度         */    COLOR: #264A7E;
            background-repeat: repeat-x;                                          /* 表格背景颜色         */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #C6DAF3">
    
                <table cellpadding="2" cellspacing="1" border="0" class="" 
                    style="font: menu; width: 90%;">
                     <tr>
                        <td align="left" colspan="2" class="style8">
                            <h3>会议通知详情</h3>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style4">标题：
                        </td>
                        <td align="left" style="height: 14px">
                            <asp:TextBox ID="txtTitle" runat="server" readonly="true"
                                Style="border-right: #99ccff 1px solid;
                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                Width="346px">我的地盘我做主</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style5">
                            开始时间：
                        </td>
                        <td align="left" style="height: 24px">
                            <asp:TextBox ID="txtStartTime" runat="server" readonly="true" 
                                Style="border-right: #99ccff 1px solid;
                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                Width="346px">2009-02-01 10:00:00</asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td align="right" class="style6">
                            会议地点：
                        </td>
                        <td align="left" style="height: 2px">
                            <asp:TextBox ID="txtMeetingAddr" runat="server" readonly="true"
                                Style="border-right: #99ccff 1px solid;
                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                Width="346px">情人坡</asp:TextBox>
                            </tr>
                    <tr>
                        <td align="right" class="style6">
                            参与者：
                        </td>
                        <td align="left" class="style2">
                            <asp:TextBox ID="txtReceiverUser" runat="server" ReadOnly="True" Width="345px"></asp:TextBox>
                             </td>
                    </tr>
                    <tr>
                        <td align="right" class="style6">
                            &nbsp;主持人：
                        </td>
                        <td align="left" style="height: 2px">
                            &nbsp;<asp:TextBox ID="txtChargeMan" runat="server" readonly="true"
                                Style="border-right: #99ccff 1px solid;
                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                Width="342px">情人坡</asp:TextBox>
                             </td>
                    </tr>
                    <tr>
                        <td align="right" class="style6">
                            紧急情况：
                        </td>
                        <td align="left" style="height: 2px">
                            <asp:DropDownList ID="dropMeetingType" runat="server">
                                <asp:ListItem>紧急</asp:ListItem>
                                <asp:ListItem>一般</asp:ListItem>
                            </asp:DropDownList>
                             </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" class="style7">
                            备注：
                        </td>
                        <td align="left">
                            &nbsp;<asp:TextBox ID="txtRemark" runat="server" ReadOnly="True" 
                                TextMode="MultiLine" Height="118px" Width="345px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" class="style3">
                           
                            <asp:Button ID="btnFeedback" runat="server" CssClass="TableLine1" Text="反馈会议" 
                                onclick="btnFeedback_Click" />
                           &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnExit" runat="server" Text="返  回" CssClass="TableLine1" 
                                PostBackUrl="~/LeaveMessage/ShowMessage.aspx" />
                           
                        </td>
                    </tr>
                </table>
    
    <div>
    
    </div>
    </form>
</body>
</html>
