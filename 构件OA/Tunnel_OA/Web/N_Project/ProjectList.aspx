<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectList.aspx.cs" Inherits="N_Project_View" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid">
  <tr>
    <td width="15%" align="right" bgcolor="#f6f6f6">按姓名搜索：</td>
    <td width="20%" bgcolor="#f6f6f6"><input type="text" name="textfield3" id="txtName" runat="server" /></td>
    <td width="65%" align="left" bgcolor="#f6f6f6">
        <asp:ImageButton ID="imbSearch" ImageUrl="~/images/search.gif" runat="server" 
            onclick="imbSearch_Click" /></td>
  </tr>
</table>
<table id="title" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid">
     <tr>
      <td>
	    <table id="content" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabler">
  <tr>
    <td height="30" align="right"><table width="100%" height="235" border="0" cellpadding="0" cellspacing="1" bgcolor="#999999">
      
      <tr>
        <td height="25" colspan="9" align="center" bgcolor="#FFFFFF">项经部违章违纪人员名单&nbsp;</td>
        </tr>
      <tr >
        <td width="9%" height="25" align="center" bgcolor="#FFFFFF">序号&nbsp;</td>
        <td width="9%" align="center" bgcolor="#FFFFFF">姓名&nbsp;</td>
        <td width="9%" align="center" bgcolor="#FFFFFF">性别&nbsp;</td>
        <td width="9%" align="center" bgcolor="#FFFFFF">年龄&nbsp;</td>
        <td width="12%" align="center" bgcolor="#FFFFFF">身份证&nbsp;</td>
        <td width="9%" align="center" bgcolor="#FFFFFF">工种&nbsp;</td>
        <td width="12%" align="center" bgcolor="#FFFFFF">原工地&nbsp;</td>
        <td width="19%" align="center" bgcolor="#FFFFFF">形成原因&nbsp;</td>
        <td width="12%" align="center" bgcolor="#FFFFFF">操作</td>
      </tr>
       <asp:Repeater ID="Repeater1" runat="server" >
        <ItemTemplate>
      <tr>
        
        <td align="center" bgcolor="#FFFFFF">
       <%-- <%# this.rpMember.Items.Count + 1%>--%>
        <%=i++%>
        <%--<%# Eval("Vio_Id") %>--%></td>
        <td align="center" bgcolor="#FFFFFF"><%#Eval("Vio_Name")%></td>
        <td align="center" bgcolor="#FFFFFF"><%#Eval("Vio_Sex")%></td>
        <td align="center" bgcolor="#FFFFFF"><%#Eval("Vio_Age")%></td>
        <td align="center" bgcolor="#FFFFFF"><%#Eval("Vio_Idcrad")%></td>
        <td align="center" bgcolor="#FFFFFF"><%#Eval("Vio_Class")%></td>
        <td align="center" bgcolor="#FFFFFF"><%#Eval("Vio_ClassAddr")%></td>
         <td height="25" align="center" bgcolor="#FFFFFF"><%# Eval("Vio_Reason")%></td>
        <td align="center" bgcolor="#FFFFFF">
            <asp:LinkButton ID="lbUp" CommandName="up" CommandArgument='<%# Eval("Vio_Id") %>' runat="server">修改</asp:LinkButton> <asp:LinkButton
                ID="lbDel" runat="server" CommandName="del" CommandArgument='<%# Eval("Vio_Id") %>' ToolTip='<%# Eval("Vio_Delete") %>'  OnClientClick="return confirm('确定要删除吗？')">删除</asp:LinkButton>

                 </td>
      </tr>
      </ItemTemplate>
      </asp:Repeater>
      
    </table></td>
    </tr>
  <tr>
    <td height="25" align="center" style="background-color:#e6f7ff;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" 
            LastPageText="末页" NextPageText="下一页" PageIndexBoxType="TextBox" PageSize="33" 
            PrevPageText="上一页" 
            onpagechanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
      </td>
    </tr>
</table>

	  </td>
    </tr>
</table>
    </div>
    </form>
</body>
</html>
