<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XiBaoView.aspx.cs" Inherits="N_Right_XiBaoView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公司喜报</title>
</head>
<body style="text-align:center">

    <form id="form1" runat="server">
     <table  border="1" cellpadding="0" cellspacing="0"  bordercolorlight="#c1c1c1"
                bordercolordark="#FFFFFF" style= "width: 663px; height: 345px; margin-bottom: 0px;" class="f" >
        <tr>
            <td height="47" colspan="2">
               <center> <font color="red" size="4" >
                  &nbsp;<%=title%></font></center>
            </td>
            
        </tr>
        <tr>
            <td valign="top" style="padding-left: 20px" class="style4" colspan="2">
            <asp:Panel runat="server" Width="99%" ID="panel1" ScrollBars="Vertical">
            <asp:Label runat="server" ID="lblcontent"  Width="96%" 
                    Style="word-break:break-all;word-wrap:break-word" 
                    Height="214px" ></asp:Label>
                </asp:Panel>              
            </td>
        </tr>
          <tr>
            <td style="text-align:right;margin-right:100px" class="style5">
                <font color="red">
                    <%=year %></font><font color="black">年</font><font color="red"><%=moon %></font>
                    <font color="black">月</font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 发布人:<font color="red"><%=name %> </font>       
                    </td>
        </tr>
       
    </table>
    </form>
</body>
</html>
