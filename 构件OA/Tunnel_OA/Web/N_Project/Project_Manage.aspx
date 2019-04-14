<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Project_Manage.aspx.cs" Inherits="N_Project_Project_Manage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
<script type="text/javascript">
    function ShowProJect(pro_id) {
        window.open('Project_View.aspx?ProJectId='+pro_id,"计划","toolbar=no,scrollbars=no ,resizable=no,top=300,left=100,Width=500,Height=500");
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top: 1px #6f97b1 solid;
        border-bottom: 1px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="Project_Add.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新建项目</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="Project_Manage.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理项目</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" height="30" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;
        border-bottom: 0px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
        <tr>
            <td style="width: 400px" align="right" bgcolor="#f6f6f6">
                标题关键字：&nbsp;<asp:TextBox ID="TextBox1" Width="300" runat="server"></asp:TextBox>
            </td>
            <td align="left" bgcolor="#f6f6f6">
                &nbsp;<asp:Button ID="BtnSearch" runat="server" CssClass="searchbutton" OnClick="BtnSearch_Click" />
            </td>
        </tr>
    </table>
    <table width="100%" border="1" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC"
        bordercolorlight="#c8c8c8" bordercolordark="#FFFFFF" style="border-collapse: collapse;
        border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid; border-top: 1px #6f97b1 solid;
        border-bottom: 1px #6f97b1 solid;">
        <tr>
            <td style="border-top: 0px; border-left: 0px" height="30" align="center" bgcolor="#f6f6f6">
                <strong>项目名称</strong>
            </td>
            <td style="border-top: 0px;" width="110" align="center" bgcolor="#f6f6f6">
                <strong>启动时间</strong>
            </td>
            <td style="border-top: 0px;" width="110" align="center" bgcolor="#f6f6f6">
                <strong>结束时间</strong>
            </td>
            <td style="border-top: 0px;" width="80" align="center" bgcolor="#f6f6f6">
                <strong>状态</strong>
            </td>
            <td style="border-top: 0px; border-right: 0px;" width="90" align="center" bgcolor="#f6f6f6">
                <strong>操作</strong>
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr bgcolor="#FFFFFF" height="26">
                    <td style="border-left: 0px;" bgcolor="#FFFFFF" align="left" height="26">
                        &nbsp;<a href="#ShowProJect" onclick="ShowProJect(<%#Eval("Pro_id") %>)"><%#Eval("Pro_Title")%></a>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#Eval("Pro_StartDate")%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#Eval("Pro_EndDate")%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        <%#GetStatus(Eval("Pro_Status").ToString())%>
                    </td>
                    <td style="border-right: 0px;" bgcolor="#FFFFFF" align="center" height="26">
                        <%#GetMenu(Eval("Pro_Status").ToString(),Eval("Pro_id").ToString())%> <a href="?DeleteId=<%#Eval("Pro_id") %>" onclick="return confirm('确认删除<%#Eval("Pro_Name")%>?');">删除</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td height="30" colspan="5" align="center" bgcolor="#e6f7ff" style="border: 0px">
                                             <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                                    NextPageText="下一页" PrevPageText="上一页" OnPageChanging="AspNetPager1_PageChanging"
                                    PageSize="33">
                                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
</asp:Content>
