<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageDetails.aspx.cs" Inherits="OfficeHelp_LeaveMessage_MessageDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>留言详细信息</title>
   <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />  
    <script language="javascript" type="text/javascript"> 
         function reply()
         {
             window.location.href="MessageReply.aspx";
         }
    </script>
    <style type="text/css">
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
            height: 511px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style4">
    
        <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td style="height: 25px" class="title1">
                <h3>消息详情</h3>
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 442px">
                    <table width="80%" cellpadding="2" cellspacing="1" border="0" style="font: menu">
                    
                        <tr>
                            <td align="right" style="height: 14px; width: 93px;">
                                标题：
                            </td>
                            <td align="left" style="height: 14px">
                                <asp:TextBox ID="txtTitle" ReadOnly="true" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                    Width="150px">下午开会</asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="right" style="width: 93px; height: 24px">
                                发送者：                             </td>
                            <td align="left" style="height: 24px">
                                <asp:TextBox ID="txtStartTime" runat="server" 
                                    
                                    Style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                    Width="150px">肯德罗夫斯基</asp:TextBox>
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td align="right" style="width: 93px; height: 2px">
                                发发送时间：
                            </td>
                            <td align="left" style="height: 2px">
                                <asp:TextBox ID="txtEndTime" runat="server" 
                                    
                                    Style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                    Width="150px">2010-01-09 11：00：00</asp:TextBox>
                                </td>
                        </tr>
                        
                        <tr>
                            <td height="25" align="right" style="width: 93px">
                                内容：
                            </td>
                            <td align="left">
                                <textarea name="txDes" rows="2" cols="20" id="txDes" class="TxCss" style="height: 100px;
                                    width: 450px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" runat="server">按时地方撒大法师的方式</textarea>
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="2" style="height: 25px" align="center">
                                &nbsp;<input id="Button1" type="button" value="回  复" onclick="reply()" class="BigButton" />
                                &nbsp;&nbsp;
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
