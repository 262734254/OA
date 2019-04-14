<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MessageList.aspx.cs" Inherits="MessageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
 <link href="css/Css.css" rel="stylesheet" type="text/css" />
    <script src="javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function tourl(m_id){
            $.get("javascript/updatemessage.ashx?mid=" + m_id,null,null);
            window.opener.location=document.getElementById("url").value;
            window.close();
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" id="listtable" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="border-top:1px #578daf solid" style="background: url(images/r_bg01.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="2%" align="left">
                                        <img src="images/listtableicon.gif" id="img1" width="20" height="26"/>
                                    </td>
                                    <td width="89%" align="left">
                                        待办事项(<asp:Label ID="Label1" ForeColor="Red" runat="server"></asp:Label>)
                                    </td>
                                    <td width="9%">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="190" valign="top" bgcolor="#FFFFFF">
                            <asp:Repeater ID="Repeater5" runat="server">
                                <ItemTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="daiban">
                                        <tr>
                                            <td width="4%" height="27">
                                                &nbsp;
                                                <img src="images/b_icon02.gif" width="9" height="9" />
                                            </td>
                                            <td width="96%" align="left">
                                                <a href="#" onclick="tourl('<%#Eval("m_id")%>','<%#Eval("m_url")%>')">
                                                    <%#Eval("m_title") %></a> (<%#Eval("m_time") %>)
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </table>
</asp:Content>

