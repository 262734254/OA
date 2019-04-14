<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TreeView1.ascx.cs" Inherits="N_UserContrl_TreeView" %>
<asp:TreeView ID="tvReportModel" runat="server" ImageSet="News" NodeIndent="10">
    <ParentNodeStyle Font-Bold="False" />
    <HoverNodeStyle Font-Underline="True" />
    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" 
        VerticalPadding="0px" />
    <ParentNodeStyle ImageUrl="~/image/dir.gif" />
    <NodeStyle Font-Names="Arial" Font-Size="10pt" ImageUrl="~/image/file.gif" ForeColor="Black" 
        HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
    
</asp:TreeView>
