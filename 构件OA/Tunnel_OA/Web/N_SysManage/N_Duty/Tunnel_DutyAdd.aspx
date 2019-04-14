<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Tunnel_DutyAdd.aspx.cs" Inherits="SystemManage_Tunnel_DutyAdd" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header"></asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">

    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid;">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="Tunnel_DutyAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                       新增职务</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="Tunnel_DutyList.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        职务管理</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
        <table width="100%" border="1" align="center" cellpadding="0" cellspacing="1" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF">
            <tr>
                <td height="25" align="right" style="height: 30px; background-color: #f6f6f6">
                    职务名称：
                </td>
                <td height="17" align="left" style="height: 30px; background-color: #f6f6f6">
                    <asp:TextBox ID="txtName" runat="server" CssClass="inputtext" onkeyup="javascrip:checkWord(100,event,'lbl')"
                        Width="211px"></asp:TextBox>
                    <asp:Label ID="lbl" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/100"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" style="height: 30px; ">
                    描述：
                </td>
                <td align="left" height="17">
                    <asp:TextBox ID="txtName2" runat="server" TextMode="MultiLine" CssClass="inputtext"
                        Height="118px" Width="210px" 
                        onkeyup="javascrip:checkWord(1000,event,'lbl0')"></asp:TextBox>
                    <asp:Label ID="lbl0" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/1000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" style="height: 30px; background-color: #f6f6f6">
                    部门：
                </td>
                <td align="left" height="17" style="height: 30px; background-color: #f6f6f6">
                    <asp:DropDownList ID="DropDownList1" runat="server"  Width="208px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 31px" class=di>
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="提交" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>

</asp:Content>
