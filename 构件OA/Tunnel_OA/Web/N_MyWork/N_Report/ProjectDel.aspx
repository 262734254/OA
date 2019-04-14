<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="ProjectDel.aspx.cs" Inherits="SystemManage_KaoHe_DelAllCent" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">

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

    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td runat="server" width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="ExamineAdd.aspx" class="a" id=xinzengkaohe runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增考核</div>
                </a>
            </td>
            <td runat="server" width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="ProjectDel.aspx" class="a" id=guanligongcheng runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理工程</div>
                </a>
            </td>
            <td runat="server" width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="Rate.aspx" class="a" id=kaohedafen runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        考核打分</div>
                </a>
            </td>
            <td width="74" id="icon4" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="PK_ProjectManager.aspx" class="a" id=kaohepaihang runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        考核排行</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" border="1" align="center" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
        bordercolordark="#FFFFFF" style="border-bottom: 1px #6f97b1 solid; border-left: 1px #6f97b1 solid;
        height: 30px; border-right: 1px #6f97b1 solid">
        <tr style="background: #f6f6f6" height="30px">
            <td style="width: 10%" align="center">
                选中
            </td>
            <td style="width: 40%" align="center">
                工程项目
            </td>
            <td style="width: 20%" align="center">
                年
            </td>
            <td style="width: 20%" align="center">
                月
            </td>
            <td style="width: 10%" align="center">
                操作
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                    onmouseout="this.style.backgroundColor='';this.style.color='';" height="26px">
                    <td width="10%" align="center">
                        <asp:CheckBox ID="CheckBox1" runat="server" />&nbsp;
                    </td>
                    <td width="40%" align="left">
                        <%#Eval("i_name") %>
                    </td>
                    <td width="20%" align="center">
                        <%#Eval("year") %>
                    </td>
                    <td width="20%" align="center">
                        <%#Eval("moon") %>
                    </td>
                    <td width="10%" align="center">
                        <a href='?id=<%#Eval("i_id") %>' onclick="return confirm('是否删除此条记录？')">删除</a>&nbsp;
                    </td>
                    <td style="display: none" width="0%">
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("i_id") %>' Visible="false"></asp:TextBox>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td align="left" style="height: 31px" width="100%" colspan="5">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr class="di">
                        <td align="left">
                            <span onclick="selectall('cb1',0);" style="cursor: hand; color: Green;">全选</span>
                            <span>/</span> <span onclick="selectall('cb1',1);" style="cursor: hand; color: Green;">
                                反选</span> &nbsp;
                            <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                                <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                            </cc1:MTCPager>
                        </td>
                        <td align="right">
                            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="批量删除" OnClientClick="return confirm('是否删除此条记录？')"
                                OnClick="btnSave_Click" />
                            <br />
                            <font color="red">注意：如果删除项目，则删除所有该项目的考核记录和打分记录！</font>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
