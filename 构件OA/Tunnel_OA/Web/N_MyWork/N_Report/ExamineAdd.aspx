<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="ExamineAdd.aspx.cs" Inherits="SystemManage_KaoHe_Tunnel_CheckAdd" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">

    <script type="text/javascript">
        function yjhkk() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtUsers").value == "") {
                alert('请选择被考核人！');
                document.getElementById("ctl00_ContentPlaceHolder1_txtUsers").focus();
                return false;
            }
        }
        function SelectUserWeb() {
            window.open('SelectUser.aspx', '选择用户', 'height=400, width=300,toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no')
        }
    </script>
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td runat="server" width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="ExamineAdd.aspx" class="a" id="xinzengkaohe" runat="server">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增考核</div>
                </a>
            </td>
            <td runat="server" width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="ProjectDel.aspx" class="a" id="guanligongcheng" runat="server">
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
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid;
        border-top: none" bordercolordark="#FFFFFF">
        <tr>
            <td align="right" height="25" style="height: 30px; background-color: #f6f6f6">
                考核年月：
            </td>
            <td align="left" height="17" style="background-color: #f6f6f6">
                <asp:DropDownList ID="DropDownList2" runat="server" Width="108px" AutoPostBack="True"
                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList3" runat="server" Width="97px" AutoPostBack="True"
                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="height: 30px; background-color: #ffffff">
                考核项目：
            </td>
            <td align="left" height="17" style="background-color: #ffffff">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="208px">
                </asp:DropDownList>
                <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                    Text="新建工程" />
            </td>
        </tr>
        <tr>
            <td align="right" height="25" style="height: 30px; background-color: #f6f6f6">
                被考核人：
            </td>
            <td align="left" height="17" valign="bottom" style="background-color: #f6f6f6">
                <asp:TextBox ID="txtUsers" runat="server" ReadOnly="True" Height="101px" TextMode="MultiLine"
                    Width="274px"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="选择" OnClientClick="SelectUserWeb();" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
        </tr>
        <tr class="di">
            <td colspan="2" align="center" style="height: 31px">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="提交" OnClientClick="return yjhkk();"
                    OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
