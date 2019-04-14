<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OnLineUser.aspx.cs" Inherits="N_Chat_OnLineUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>在线人员</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function GetUser()
        {
            var cbk = document.getElementsByTagName("input");
            var strVal = "";
            for(var i=0;i<cbk.length;i++)
            {
                if (cbk[i].type=="checkbox")
                {
                    if (cbk[i].checked)
                        strVal += cbk[i].text+',';
                }
            }
            
            parent.dialogArguments.document.getElementsById('<%=Request.Params["control"] %>').innerHTML = strVal;
            window.close();
        }
    </script>
</head>
<body style="background-color:#e6f7ff">
    <form id="form1" runat="server" style="text-align:center">
    <table style="text-align:left; width:200; height:350;" border="1">
        <caption>在线人员</caption>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" Width="200" Height="300" ScrollBars="Auto" runat="server">
                    <asp:CheckBoxList ID="cbListUser" runat="server"></asp:CheckBoxList>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <input type="button" id="btnOK" name="btnOK" class="button" value="确定" onclick="GetUser();" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
