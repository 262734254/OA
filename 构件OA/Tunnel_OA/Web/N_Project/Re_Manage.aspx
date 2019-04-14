<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Re_Manage.aspx.cs" Inherits="N_Project_Re_Manage" Title="无标题页" %>

<%@ Register assembly="Tunnel.BLL" namespace="OurControl" tagprefix="cc1" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <style type="text/css">
#title td{background-color:#FFFFFF;}
        
      </style>

<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid">
  <tr>
    <td bgcolor="#f6f6f6" width="3" >&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
    <div style="width:73; height:27px; cursor:pointer;"><a href="Re_add.aspx" class="a" target="_self">添加</a></div>
    </td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
    <div style="width:73; height:27px;cursor:pointer;"><a href="Re_Manage.aspx" class="a" target="_self" >管理 </a></div>
   </td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table id="title" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid">
     <tr>
      <td>
      <table width="400px"   border="0" cellpadding="0" cellspacing="0" >
  <tr>
    <td  bgcolor="#f6f6f6" >模版分类：</td>
    <td align="left" bgcolor="#f6f6f6" >
        <asp:DropDownList ID="ddlType" runat="server">
        </asp:DropDownList>
    </td>
    <td  bgcolor="#f6f6f6"  >名称：</td>
    <td bgcolor="#f6f6f6"><input type="text" id="txtName" runat="server"  /></td>
    <td  align="left" bgcolor="#f6f6f6"><asp:ImageButton ID="imbSearch" 
            ImageUrl="~/images/search.gif" runat="server" onclick="imbSearch_Click" /></td>
  </tr>
</table>
<table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid">
     <tr>
      <td>
	    <table id="content" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabler">
  <tr>
    <td height="30" align="right"><table width="100%" height="235" border="0" cellpadding="0" cellspacing="1" bgcolor="#999999">
      
      <tr>
        <td height="25" colspan="5" align="center" bgcolor="#FFFFFF">报表模版记录</td>
        </tr>
      <tr>
        <td width="5%" align="center" bgcolor="#FFFFFF"><strong>选择</strong></td>
        <td width="7%" height="25" align="center" bgcolor="#FFFFFF"><strong>序号&nbsp;</strong></td>
        <td width="24%" align="center" bgcolor="#FFFFFF"><strong>模版名称&nbsp;</strong></td>
        <td width="16%" align="center" bgcolor="#FFFFFF"><strong>模版类别&nbsp;</strong></td>
        <td width="48%" align="center" bgcolor="#FFFFFF"><strong>操作</strong></td>
      </tr>
       <asp:Repeater ID="rpModelType" runat="server" 
            onitemcommand="rpModelType_ItemCommand"  >
        <ItemTemplate>
      <tr>
        <td align="center" bgcolor="#FFFFFF"><input type="checkbox" name="checkbox" id="checkbox" value='<%# Eval("Re_Id") %>' /></td>
        <td height="25" align="center" bgcolor="#FFFFFF"><%=++i %></td>
        <td align="center" bgcolor="#FFFFFF"><%# Eval("Re_Name") %></td>
        <td align="center" bgcolor="#FFFFFF"><%# Eval("Re_Name")%></td>
        <td align="center" bgcolor="#FFFFFF">
        设计 停用 流程 权限 <a href="#">提醒设置</a>
        <asp:LinkButton ID="lbUpdate" CommandName="Up" CommandArgument='<%# Eval("Re_Id") %>' runat="server" >修改</asp:LinkButton>
            <asp:LinkButton ID="lbDel" CommandName="De" CommandArgument='<%# Eval("Re_Id") %>' runat="server" OnClientClick="return confirm('确定要删除吗？')">删除</asp:LinkButton>
        </td>
      </tr>
      
      </ItemTemplate>
      </asp:Repeater>
      
    </table></td>
    </tr>
  <tr>
    <td height="25" align="center" style="background-color:#e6f7ff;">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                                    NextPageText="下一页" PrevPageText="上一页" OnPageChanging="AspNetPager1_PageChanging"
                                    PageSize="5">
                                </webdiyer:AspNetPager>
      </td>
    </tr>
</table>

	  </td>
    </tr>
</table>
      
	   </td>
  </tr>
</table>
	  </td>
    </tr>
</table>
</asp:Content>
