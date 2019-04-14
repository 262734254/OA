<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndexVote.aspx.cs" Inherits="Vote_IndexVote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 547px;
        }
    </style>
    <link href="../../css/group.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        var checkednum = 0;
        function check(obj) {
            $("input[type=radio]").attr("checked", false);
            obj.checked = true;
        }
        function checkmax(obj) {
            var maxvalue = document.getElementById("max").value;
            if (!obj.checked)
                checkednum--;
            else
                checkednum++;
            if (checkednum > maxvalue) {
                alert("该投票主题不能大于" + maxvalue); return false;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table class="style1" border="0">
        <tr style="background-image: url(../image/DINNERtitle.jpg)" width="555px">
            <td align="center" class="tou3">
                <img src="../../image/kong_com.gif" /><%=voteTitle %>
            </td>
        </tr>
        <tr>
            <td style="font-size:15px">
                <%=voteMark %>
            </td>
        </tr>
        <tr>
            <td align="center">
                <img src="../../image/usertou.gif" />发布人:<%=voteUserName %>
                发布日期:<%=voteDate %>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="100%" align="center" style="font-size:14px">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                            <td width=50px>&nbsp;</td>
                                <td width="20px" align="center">
                                    <asp:RadioButton ID="RadioButton1" onclick="check(this)" name="radio" runat="server"
                                        ToolTip='<%#Eval("ivote_Id") %>' />
                                    <asp:CheckBox ID="CheckBox1" onclick="return checkmax(this)" runat="server" ToolTip='<%#Eval("ivote_Id") %>' />
                                </td>
                                <td align="center">
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
                &nbsp;<asp:Button ID="Button1" CssClass="button" runat="server" Text="投票" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" class="button" value="关闭" onclick="window.close();">
                <input id="max" type="hidden" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
