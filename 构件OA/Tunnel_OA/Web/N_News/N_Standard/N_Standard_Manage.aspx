<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_Standard_Manage.aspx.cs" Inherits="N_News_N_Standard_N_Standard_Manage" %>
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
  <title>规范管理</title>
    <link href="../../Css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
    function SelectUser(str)
    {
        window.open ('SelectUser.aspx?fileId='+str+'', '选择用户', 'height=400, width=300,toolbar=no, menubar=no, scrollbars=yes, resizable=no, location=no, status=no')
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border-top: 1px #6f97b1 solid;
        border-bottom: 0px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
        <tr align="left">
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="N_StandardAdd.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新建规范</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="N_Standard_Manage.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        规范管理</div>
                </a>
            </td>           
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>      
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr>
    <td height="30" colspan="6" align="center" bgcolor="#f6f6f6"><table width="100%" border="0" cellspacing="0" cellpadding="3">
      <tr>
      <td width="54"><label></label>
          &nbsp;</td>
        <td width="80" align="left">&nbsp;</td>
        <td width="84"><label></label>
          &nbsp;搜索关键字：</td>
        <td width="150"><label>
            <asp:TextBox ID="txtTitle" runat="server" Width="247px"></asp:TextBox>
        </label></td>
        <td align="left">
            <asp:ImageButton ID="imgSelect" runat="server" 
                ImageUrl="../../images/search.gif" onclick="ImgSelect_Click" /></td>
      </tr>
    </table></td>
  </tr>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" style="border-collapse:collapse;border-right: 1px #6f97b1 solid;
        border-top: 1px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-bottom: 1px #6f97b1 solid;"
        bordercolorlight="#c8c8c8" bordercolordark="#FFFFFF" bgcolor="#CCCCCC">
        <tr height="20">
            <td style="border-top: 0px; border-left: 0px" width="" align="center" bgcolor="#f6f6f6"
                width="240">
                <strong>文件名称</strong>
            </td>
            <td style="border-top: 0px;" width="60" align="center" bgcolor="#f6f6f6" width="240">
                <strong>上传用户</strong>
            </td>
            <td style="border-top: 0px;" width="70" align="center" bgcolor="#f6f6f6" height="30">
                <strong>上传时间</strong>
            </td>
          
            <td style="border-top: 0px;" width="70" align="center" bgcolor="#f6f6f6" height="30">
                <strong>文件类型</strong>
            </td>
            <td style="border-top: 0px;" width="130" align="center" bgcolor="#f6f6f6" height="30">
                <strong>文件下载</strong>
            </td>
            <td style="border-top: 0px; border-right: 0px" width="130" align="center" bgcolor="#f6f6f6"
                height="30">
                <strong>操作</strong>
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <tr height="26" onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                    onmouseout="this.style.backgroundColor='';this.style.color='';">
                    <td style="border-left: 0px;" align="left" height="26" bgcolor="#FFFFFF">
                        &nbsp;<%#Eval("S_Title")%>
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        &nbsp;<%#ShowUserName(Eval("CreateUser").ToString())%>
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        &nbsp;<%#Eval("CreateDate", "{0:yyyy-MM-dd}")%>
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        &nbsp;<%#FileTypeName(System.IO.Path.GetExtension(Eval("S_File").ToString()))%>
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        &nbsp;<a href='../../<%#Eval("S_File")%>' title="点击下载"><%#System.IO.Path.GetFileName(Eval("S_File").ToString())%></a>
                    </td>
                    <td style="border-right: 0px;" align="center" height="26" bgcolor="#FFFFFF">
             
                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("Id")%>' CommandName='<%#Eval("S_File")%>'
                            runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此文件?');">删除</asp:LinkButton>
                    </td>
                </tr>                                                                              
            </ItemTemplate>
        </asp:Repeater>
          <tr>
            <td colspan="7" align="center" bgcolor="#e6f7ff" style="border:0px">
                <table style="border-collapse:collapse;" width="100%" border="0" align="center" cellpadding="6" cellspacing="0">
                    <tr>
                        <td height="20" >
                            <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                                <PageJump DDLVisiable="False" CurrentPageVisiable="False" PageJumpType="TextBox" />
                            </cc1:MTCPager>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
      
    </table>
</asp:Content>

