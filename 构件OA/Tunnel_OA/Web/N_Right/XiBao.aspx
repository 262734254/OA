<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="XiBao.aspx.cs" Inherits="N_Right_XiBao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
<title></title>
    <style type="text/css">
        .f
        {
            font-family: 微软雅黑;
            font-size: 12px;
        }
        .style4
        {
            height: 229px;
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
</asp:Content>

