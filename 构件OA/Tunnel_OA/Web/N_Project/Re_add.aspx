<%@ Page Language="C#" MasterPageFile="~/Project.master" AutoEventWireup="true" CodeFile="Re_add.aspx.cs" Inherits="N_Project_Re_add" Title="无标题页" %>
<%@ Register src="../N_UserContrl/TreeView.ascx" tagname="TreeView" tagprefix="uc1" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellspacing="0" cellpadding="0" style="border:1px #6f97b1 solid">
<tr>
<td valign="top" style=" border-right:1px #6f97b1 solid">
    <uc1:TreeView ID="TreeView1" runat="server" />
    </td>
<td valign="top">
<table id="title" width="100%" border="0" cellspacing="0" cellpadding="0" >
     <tr>
      <td>
	    <table width="100%" border="0" cellspacing="0" cellpadding="0" >
  <tr>
    <td><table width="100%" border="0" cellpadding="0" cellspacing="0" >
      <tr>
        <td height="30" width="80"  bgcolor="#f6f6f6" align="center" >排 序 号：</td>
        <td bgcolor="#f6f6f6">
            <asp:TextBox ID="txtNum" runat="server" Width="44px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvNum" runat="server" 
                ControlToValidate="txtNum" ErrorMessage="请输入排序号"></asp:RequiredFieldValidator>
                                                                                    </td>
      </tr>
      <tr>
        <td height="30" align="center" >分类名称：</td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                ControlToValidate="txtName" ErrorMessage="请输入分类名称"></asp:RequiredFieldValidator>
                                                                                    </td>
      </tr>
      <tr>
        <td height="30"  bgcolor="#f6f6f6" align="center" >上级分类：</td>
        <td bgcolor="#f6f6f6">
            <asp:DropDownList ID="ddlType" runat="server" Width="206px"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td height="30"  bgcolor="#ffffff" align="center" >所属部门：</td>
        <td bgcolor="#ffffff">
            <asp:DropDownList ID="ddlType0" runat="server" Width="206px"></asp:DropDownList>
          </td>
      </tr>
      </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid; border-left:0px #6f97b1 solid; border-right:0px #6f97b1 solid">
      <tr>
        <td width="68" height="30" align="center" bgcolor="#e6f7ff" >&nbsp;</td>
        <td width="796" height="30" align="center" bgcolor="#e6f7ff" >
            <asp:Button ID="btnAdd" runat="server" Text="提 交" CssClass="button" 
                onclick="btnAdd_Click" Height="23px" 
                />
          &nbsp;<asp:Button ID="btnReset" runat="server" Text="重 置" CssClass="button" 
                onclick="btnAdd_Click" Height="23px" 
                />
         </td>
      </tr>
    </table></td>
  </tr>
</table>
	  </td>
    </tr>
</table>

</td>
</tr>
</table>
</asp:Content>

