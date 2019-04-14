<%@ Page Title="" Language="C#" MasterPageFile="~/Project.master" AutoEventWireup="true" CodeFile="RePort_Index.aspx.cs" Inherits="N_Project_RePort_Index" %>
<%@ Register src="../N_UserContrl/TreeView1.ascx" tagname="TreeView" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" height="30" align="center" style="border-bottom:1px #6f97b1 solid">
    <input type="button" onclick="mainframe.location='Report_add.aspx'" value="新建模版" /></td>
    <td width="90%" valign="top" rowspan="2"><iframe frameborder="0" id="mainframe" src="Report_List.aspx" height="1100" width="100%"></iframe></td>
  </tr>
  <tr>
    <td width="10%" valign="top" style="border-right:1px #000000 solid;border-bottom:1px #000000 solid">
        <uc1:TreeView ID="TreeView1" runat="server" />
      </td>
  </tr>
</table> 
</asp:Content>
