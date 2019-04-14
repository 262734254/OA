<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeedBackDetails.aspx.cs" Inherits="OfficeHelp_LeaveMessage_FeedBackDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>反馈消息详情</title>
 <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />  
    <style type="text/css">
        .style1
        {
            width: 131px;
            height: 23px;
        }
        .style2
        {
            width: 131px;
            height: 9px;
        }
        .style3
        {
            height: 9px;
        }
        .style4
        {
            height: 23px;
        }
        .style6
        {
            height: 14px;
            width: 131px;
        }
        .style7
        {
            height: 24px;
            width: 131px;
        }
        .style8
        {
            width: 131px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div  style="background-color: #C6DAF3;text-align: center">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td width="80" class="title1">
                    <h3>反馈消息详情</h3>
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td style="height: 25px">
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 442px">
                    <table cellpadding="2" cellspacing="1" border="0" 
                        style="font: menu; width: 49%;">
                    
                        <tr>
                            <td align="right" class="style6">
                                标题：
                            </td>
                            <td align="left" style="height: 14px">
                               
                                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                                </td>
                        </tr>
                        
                        <tr>
                            <td align="right" class="style7">
                                反馈人：
                            </td>
                            <td align="left" style="height: 24px">
                                <asp:TextBox ID="txtSenderUser" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="right" class="style2">
                                                                时间：
                            </td>
                            <td align="left" class="style3">
                                <asp:TextBox ID="txtEndTime" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td align="right" class="style1">
                                是否同意开会：
                            </td>
                            <td align="left" class="style4">
                       
                                <asp:RadioButtonList ID="rdoAgree" runat="server" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:RadioButtonList>
                        </tr>
                        
                        <tr>
                            <td height="25" align="right" class="style8">
                                反馈意见：                             </td>
                            <td align="left">
                                &nbsp;<asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                                </td>
                        </tr>
                        
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnOK" runat="server" CssClass="textbox_show" Text="提   交" 
                                    Height="21px" Width="54px" onclick="btnOK_Click" />
                            &nbsp;&nbsp;
                                <asp:Button ID="btnExit" runat="server" CssClass="textbox_show" Text="返  回" />
                            
                            </td>
                        </tr>
                        
                    </table>
                    
                </td>
            </tr>
        </table>
    </div>
    <div>
    
    </div>
    </form>
</body>
</html>
