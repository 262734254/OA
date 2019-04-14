<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StarManage.aspx.cs" Inherits="N_MyWork_N_Star_StarManage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" runat="server"     contentplaceholderid="ContentPlaceHolder1">


  <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript">
    function selectall(id, select) {
        var form = document.getElementsByTagName("INPUT");
        var checkbox = new Array();
        var num1 = 0;
        for (var i = 0; i < form.length; i++) {
            if (form[i].type == "checkbox") {
                checkbox[num1] = form[i];
                num1++;
            }
        }
        var num = 0;
        if (select == 0) {
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked)
                    num++;
                else
                    checkbox[i].checked = true;
            }
            if (checkbox.length == num) {
                for (var i = 0; i < checkbox.length; i++) {
                    checkbox[i].checked = false;
                }
            }
        }
        else {
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked)
                    checkbox[i].checked = false;
                else
                    checkbox[i].checked = true;
            }
        }

    }
</script>
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="StarAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        发布喜报</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="StarManage.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理喜报</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
<div>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC"
        style="border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
        <tr>
            <td width="15%" height="30" align="center" bgcolor="#f6f6f6">
                选中
            </td>
            <td width="33%" align="center" bgcolor="#f6f6f6">
                标题
            </td>
            <td width="14%" align="center" bgcolor="#f6f6f6">
                年
            </td>
            <td width="14%" align="center" bgcolor="#f6f6f6">
                月
            </td>
            <td width="19%" align="center" bgcolor="#f6f6f6">
                操作
            </td>
        </tr>
        <asp:repeater id="Repeater1" runat="server">
                <ItemTemplate>
                    <tr onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                        onmouseout="this.style.backgroundColor='';this.style.color='';" height="26px">
                        <td align="center" bgcolor="#FFFFFF">
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </td>
                        <td align="center" bgcolor="#FFFFFF">
                      <%#Eval("Title") %>     
                        </td>
                        <td align="center" bgcolor="#FFFFFF">
                            <%#Eval("m_year") %>
                        </td>
                        <td align="center" bgcolor="#FFFFFF">
                            <%#Eval("m_moon") %>
                        </td>
                        <td align="center" bgcolor="#FFFFFF">
                            <a href="StarUpd.aspx?id=<%#Eval("m_id") %>">修改</a><a href="?id=<%#Eval("m_id") %>" onClick="return confirm('是否删除此条记录？')">
                                删除</a>
                        </td>
                        <td style="display:none" align="center" bgcolor="#FFFFFF" width="0">
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("m_id")%>' Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:repeater>
    </table>
</div>
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC"
    style="border-bottom: 1px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
    <tr class="di" align="justify">
        <td>
            <table>
                <tr>
                    <td>
                        <span onclick="selectall('cb1',0);" style="cursor: hand; color: Green;">全选</span>
                        <span>/</span> <span onclick="selectall('cb1',1);" style="cursor: hand; color: Green;">
                            反选</span>
                    </td>
                    <td>
                        <asp:button id="Button1" runat="server" cssclass="button" text="批量删除" onclick="Button1_Click"
                            onclientclick="return confirm('是否删除此条记录？')" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>


</asp:Content>


