<%@ Page Title="" Language="C#" MasterPageFile="~/Project.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="N_Project_Index" %>
<%@ Register src="../N_UserContrl/TreeView1.ascx" tagname="TreeView" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10%" valign="top" style="border-right:1px #000000 solid;border-bottom:1px #000000 solid">
        <uc1:TreeView ID="TreeView1" runat="server" />
      </td>
    <td width="90%" valign="top"><iframe frameborder="0" src="ProjectList.aspx" height="1100" width="100%"></iframe></td>
  </tr>
</table> 
</asp:Content>

