<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PowerUserControl.ascx.cs" Inherits="PowerControl" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 97px;
    }
    .style3
    {
        width: 119px;
    }
</style>
<asp:HiddenField ID="hidParentMenu" runat="server" />
<asp:HiddenField ID="hidRoleId" runat="server" />
<br />
<table class="style1">
    <tr>
        <td class="style2">
            <asp:Label ID="lblParentName" runat="server"></asp:Label>
        </td>
        <td class="style3">
<asp:CheckBox ID="chkPararentMenu" runat="server"   onclick="CheckAll(this.id)" 
                Font-Bold="False" />
        </td>
        <td>
<asp:CheckBoxList ID="chklstChildMenu" runat="server"  
    onclick="CheckOnly(this.id)" CellPadding="0" CellSpacing="0" RepeatColumns="5" 
    RepeatDirection="Horizontal" style="margin-left: 0px" >
</asp:CheckBoxList>
        </td>
    </tr>
</table>
<hr  style="color:#66ccff"/>
