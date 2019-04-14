<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Document_FlowView.aspx.cs" Inherits="Workflow_Tunnel_FlowView" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<script type="text/javascript" src="../../javascript/Calendarform.js"></script>
<script type="text/javascript" src="../../javascript/utility.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.3.2.min.js"></script>
<title>流程图</title>
    <link href="../../Css/Css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF" bordercolorlight="#DBDBDB" style="width: 100%">
    <tr>
        <td align="left">
        <br/>
       <table border="1" align="center" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF" bordercolorlight="#DBDBDB" style="width: 85%">
    <tr>
        <td align="left" colspan="3" rowspan="1" style="height: 30px; background-color: #e8e8e8; font-weight: bold; width: 662px;">
            &nbsp;流程图</td>
    </tr><%i = 1;%>
            <%=toptb%> 
           <asp:Repeater ID="Repeater1" runat="server">
           <ItemTemplate>
           <tr>
                <td align="center" style="height: 30px; width: 10%;">第<font color=red><%=(++i) %></font>步</td>
                <td align="left" style="height: 30px; width: 30%">&nbsp;&nbsp;<%#getNum(Eval("e_bid").ToString(),Eval("e_nextbid").ToString()) %><%#getname(Eval("e_bid").ToString()) %></td>
                <td align="left" style="height: 50%">&nbsp;&nbsp;<strong style="color:Red"><%#getUname(Eval("e_user").ToString()) %> 主办</strong> [<%#getNum(Eval("e_bid").ToString(),Eval("e_nextbid").ToString(),1) %>]
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始于：<%#Eval("e_time") %>
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;结束于：<%#Eval("e_endtime") %>
                </td>
            </tr> 
            </ItemTemplate>
           </asp:Repeater>
           <%=nextb%> 
       <%if (isend)
         { %>
       <tr>
        <td align="left" colspan="3" rowspan="1" style="height: 30px; background-color: #e8e8e8; font-weight: bold; width: 662px;">
            &nbsp;流程结束</td>
    </tr>
    <% }%>
    </table><br/>
</td>
</tr>
</table>
    </div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td align="center">
                    <input id="Button1" class="butt" type="button" value="关 闭" onclick="window.close();" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
