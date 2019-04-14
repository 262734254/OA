<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Vote.aspx.cs" Inherits="Vote_Vote" %>

    <asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header"> </asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../../css/group.css" rel="stylesheet" type="text/css" />
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var checkednum = 0;
        function check(obj) {
            $("input[type=radio]").attr("checked", false);
            obj.checked = true;
        }
        function checkmax(obj) {
            var maxvalue = document.getElementById("ctl00_ContentPlaceHolder1_max").value;
            if (!obj.checked)
                checkednum--;
            else
                checkednum++;
            if (checkednum > maxvalue) {
                alert("该投票主题不能大于" + maxvalue); return false;
            }
        }
    </script>

    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="VoteList.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        投票列表</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
        <table width="100%" border=0>
            <tr style="background-image:url(../../image/etitle.jpg) ; background-repeat:no-repeat">
                <td class="tou">
                    <img src="../../image/kong_com.gif" /><font color="white"><%=voteTitle %></font> 
                    </td>
            </tr>
            <tr>
                <td>
                    <%=voteMark %>
                </td>
            </tr>
            <tr>
                <td >
                   <img src="../../image/usertou.gif" />发布人:<%=voteUserName %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发布日期:<%=voteDate %>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table width="100%" align="left">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                <td>&nbsp;</td>
                                    <td width=20px align="left">
                                        <asp:RadioButton ID="RadioButton1" onclick="check(this)" name="radio" runat="server"
                                            ToolTip='<%#Eval("ivote_Id") %>' />
                                            <asp:CheckBox ID="CheckBox1" onclick="return checkmax(this)" runat="server" ToolTip='<%#Eval("ivote_Id") %>' />
                                    </td>
                                    <td align="left">
                                       <%#Eval("iVote_Title") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;<asp:Button ID="Button1" CssClass="button" runat="server" Text="投票" 
                        OnClick="Button1_Click"  />
                    &nbsp;<input id="max" type="hidden" runat="server" /></td>
            </tr>
        </table>
</asp:Content>
