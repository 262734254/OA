<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageReply.aspx.cs" Inherits="OfficeHelp_LeaveMessage_MessageReply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>回复留言</title>
   <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />  
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #C6DAF3">
    
                    <table cellpadding="2" cellspacing="1" border="0" 
                        style="font: menu; width: 83%;">
                        <tr>
                            <td colspan="2" class="title1">
                            <h3>留言详细信息</h3>
                            </td>
                        </tr>
                        <br />
                        <br />
                        <br />
                        <tr>
                            <td align="right" style="height: 14px; width: 93px;">
                                标&nbsp;&nbsp;&nbsp;&nbsp;题：
                            </td>
                            <td align="left" style="height: 14px">
                                <asp:TextBox ID="txtTitle" runat="server" Style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="right" style="width: 93px; height: 24px">
                                发送时间：
                            </td>
                            <td align="left" style="height: 24px">
                                <input id="txtStartTime" name="txFDate1" type="text" value="" onfocus="setday(this)"
                                    style="width: 180px; height: 17px; border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;"
                                    runat="server" size="20" />
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="right" style="width: 93px; height: 2px">
                                发 件 人：
                            </td>
                            <td align="left" style="height: 2px">
                                <asp:TextBox ID="txtSenderUser" Text="李程" ReadOnly="true" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                            &nbsp;
                        </tr>
                        
                        <tr>
                            <td height="25" align="right" style="width: 93px">
                                内&nbsp;&nbsp;&nbsp;&nbsp;容：
                            </td>
                            <td align="left">
                                <textarea name="txDes" rows="2" cols="20" id="txDes" style="height: 100px;
                                    width: 450px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" runat="server"></textarea>
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="2" style="height: 25px" align="center">
                                &nbsp;<input id="Button1" type="button" value="保  存" 
                                    class="BigButton" onclick="javascript:window.location.href='../LeaveMessage/ShowMessage.aspx'"
                                  />
                                &nbsp;&nbsp;
                                <input id="btnExit" type="button" value="返  回" onclick="javascript:window.location.href='../LeaveMessage/ShowMessage.aspx'"
                                    class="BigButton" />
                            </td>
                        </tr>
                        
                    </table>
                    
    </div>
    </form>
</body>
</html>
