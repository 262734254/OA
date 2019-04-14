<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="zcgl.aspx.cs" Inherits="N_Index_czgl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <title></title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            font-size: 12px;
        }
        #listtable
        {
            border: 1px #578daf solid;
        }
        #listtable #listtablemenu
        {
            border-bottom: 1px #578daf solid;
            font-weight: bold;
            color: #0276a5;
        }
        #listtable #listtablebottom
        {
            border-top: 1px #578daf solid;
            font-weight: bold;
            color: #0276a5;
        }
        #daiban
        {
            background: url(../images/r_g_01.gif) repeat-x;
        }
        .STYLE1
        {
            color: #FF0000;
            font-weight: normal;
        }
    </style>

    <script type="text/javascript">
function show(obj,img){
	var objt=document.getElementById(obj);
	if(objt.style.display=='none'){
		img.src='../images/listtableicon-down.gif';
		objt.style.display='';
	}else{
		img.src='../images/listtableicon.gif';
		objt.style.display='none';
	}
}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="50%" align="center" valign="top">
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;一周安排
                                    </td>
                                    <td width="40">
                                        <a style="color:#0276a5;" href="DataTypeList.aspx?typeId=36&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=36&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="50%" align="center">
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;资产信息
                                    </td>
                                    <td width="40">
                                        <a style="color:#0276a5;" href="DataTypeList.aspx?typeId=12&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=12&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;资产管理
                                    </td>
                                    <td width="40">
                                        <a style="color:#0276a5;" href="DataTypeList.aspx?typeId=13&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                               <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource3">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=13&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" rowspan="2" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="476" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" colspan="2" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;参考资料
                                    </td>
                                    <td width="40">
                                        <a style="color:#0276a5;" href="DataTypeList.aspx?typeId=14&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td  colspan="2" height="450" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater4" runat="server" DataSourceID="SqlDataSource4">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=14&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;项经部租费
                                    </td>
                                    <td width="40">
                                        <a style="color:#0276a5;" href="DataTypeList.aspx?typeId=25&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater5" runat="server" DataSourceID="SqlDataSource5">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="76%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=25&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"),36)%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="20%">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
                <SelectParameters>
                    <asp:Parameter DefaultValue="36" Name="typeId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
                <SelectParameters>
                    <asp:Parameter DefaultValue="12" Name="typeId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
                <SelectParameters>
                    <asp:Parameter DefaultValue="13" Name="typeId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                SelectCommand="SELECT top 18 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
                <SelectParameters>
                    <asp:Parameter DefaultValue="14" Name="typeId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
                <SelectParameters>
                    <asp:Parameter DefaultValue="25" Name="typeId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
</asp:Content>
