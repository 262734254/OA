<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QingJia.aspx.cs" Inherits="N_News_OutMessage_QingJia" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
<title></title>
    <style type="text/css">
        .f
        {
            font-family: 微软雅黑;
            font-size: 12px;
        }
        .style5
        {
            height: 26px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table  border="1" cellpadding="0" cellspacing="0"  bordercolorlight="#c1c1c1"
                bordercolordark="#FFFFFF" style="width: 663px; height: 345px; margin-bottom: 0px;" class="f">
                <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
        <tr>
            <td height="47" colspan="2">
               <center> <font color="red" size="4" >
                  &nbsp;外出留言</font></center>
            </td>
            
        </tr>
      <tr>
       <td style="border-left:0px;border-right:0px;" colspan="2" align="left" style="padding: 10px" valign="top" height="300">
        <%#Eval("MesContent")%></td>
      </tr>
          <tr>
            <td style="text-align:right;margin-right:100px" class="style5">
                留言时间：<font color="red">
                   <%#Eval("MesDate", "{0:yyyy-MM-dd HH:mm:ss}")%>
                    </font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 请假人:<font color="red"><%#ShowUserName(Eval("MesUser").ToString())%> </font>       
                    </td>
        </tr>
        </ItemTemplate>
       </asp:Repeater>
    </table>
</asp:Content>

