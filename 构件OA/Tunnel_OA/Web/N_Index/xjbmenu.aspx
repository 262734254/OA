<%@ Page Language="C#" MasterPageFile="~/IndexPage.master" AutoEventWireup="true"
    CodeFile="xjbmenu.aspx.cs" Inherits="N_Index_xjb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
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
    <style type="text/css">
        #tablelist
        {
        }
        #tablelist .tds
        {
            border: 1px #578daf solid;
            border-bottom: none;
            border-left: none;
            background: #f6f6f6;
            cursor: pointer;
        }
        #tablelist .selecttd
        {
            border: 1px #578daf solid;
            border-bottom: none;
            border-right: none;
            border-left: none;
            cursor: pointer;
            color: #0276a5;
        }
        #tablelist .toptd
        {
            border-top: none;
        }
        #tablelist .tas
        {
            display: none;
        }
        #tablelist .taselected
        {
            display: block;
        }
    </style>

    <script type="text/javascript">
        function show(obj, img) {
            var objt = document.getElementById(obj);
            if (objt.style.display == 'none') {
                img.src = '../images/listtableicon-down.gif';
                objt.style.display = '';
            } else {
                img.src = '../images/listtableicon.gif';
                objt.style.display = 'none';
            }
        }
    </script>

    <script src="../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function showclasst(obj, num, name, sum) {
            for (var i = 1; i <= sum; i++) {
                if (num == i) {
                    $(obj).attr("class", "selecttd");
                    $("#tab" + i.toString() + name.toString()).attr("class", "taselected");
                } else {
                    $("#td" + i.toString() + name.toString()).attr("class", "tds");
                    $("#tab" + i.toString() + name.toString()).attr("class", "tas");
                }
            }
            $("#td1" + name).addClass("toptd");
        }
        function getheight(obj, counts) {
            var hei = document.getElementById(counts).value
          //  hei = hei + 1;
            hei = hei * 25;
            hei = 206 - hei;
            var obj = document.getElementById(obj);
            obj.style.height = hei;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" height="200px">
            </td>
        </tr>
        <tr>
            <td valign="top" width="50%" align="center" valign="top">
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="Repeater1_ItemCommand"
                    OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="26" colspan="2" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="left">
                                                &nbsp;<%#Eval("TypeName") %>
                                            </td>
                                            <td width="40">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="206" valign="top" bgcolor="#FFFFFF">
                                    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" id="tablelist">
                                        <tr>
                                            <td width="86" height="100%">
                                                <input runat="server" id="parentid" type="hidden" value='<%#Eval("id") %>' />
                                                <input runat="server" id="typeid" type="hidden" value='<%#Eval("typeid") %>' />
                                                <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td height="" id='td<%#Eval("row") %><%#Eval("parentid") %>' class="<%#Eval("css") %>"
                                                                    onmouseover="showclasst(this,<%#Eval("row") %>,'<%#Eval("parentid") %>',<%#Eval("count") %>)">
                                                                    <%#Eval("TypeName") %>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                                        SelectCommand="select *,case row when 1 then 'toptd' else 'tds' end as css from (select ROW_NUMBER()Over(ORDER BY id) as row,*,(select count(*) from tunnel_xjbtype  where typeid=@typeid and parentid=@parentid) as [count] from tunnel_xjbtype  where typeid=@typeid and parentid=@parentid) as tunnel_xjbtype">
                                                        <SelectParameters>
                                                            <asp:ControlParameter PropertyName="value" ControlID="parentid" Name="parentid" Type="Int32" />
                                                            <asp:QueryStringParameter Name="typeid" Type="Int32" QueryStringField="typeid" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                </table>
                                            </td>
                                            <td valign="left" align="left">
                                                <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource3">
                                                    <ItemTemplate>
                                                        <table class="<%#Eval("css") %>" id="tab<%#Eval("row") %><%#Eval("parentid") %>"
                                                            width="100%" height="206" border="0" cellspacing="0" cellpadding="0">
                                                            <input runat="server" id="sectype" type="hidden" value='<%#Eval("id") %>' />
                                                            <asp:Repeater ID="Repeater4" runat="server" DataSourceID="SqlDataSource4">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td width="8" height="25">
                                                                            &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                                                        </td>
                                                                        <td width="" align="left">
                                                                            <a href="ViewXJB.aspx?id=<%#Eval("Id")%>&TypeId=<%=Request.QueryString["typeid"].ToString()%>&lanmuId=1&bum_id=<%=Request.QueryString["bum_id"].ToString()%>"
                                                                                title="<%#Eval("Title")%>">
                                                                                <%#title(Eval("Title"))%></a> <font color="red">
                                                                                    <%#shownew(Eval("setdate"))%></font>
                                                                        </td>
                                                                        <td width="40">
                                                                            <%#Eval("setdate", "{0:MM-dd}")%>
                                                                            <input id="hei<%#Eval("row") %><%#Eval("sectype") %>" type="hidden" value='<%#Eval("counts") %>' />
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                                                SelectCommand="SELECT top 7 ROW_NUMBER()Over(ORDER BY id) as row,*,(select top 7 count(*) FROM [Tunnel_InfoXJB] WHERE ([typeId] = @typeid) and del=0 and (bum_bz=@bum_bz) and sectype=@sectype) as counts FROM [Tunnel_InfoXJB] WHERE ([typeId] = @typeid) and del=0 and (bum_bz=@bum_bz) and sectype=@sectype ORDER BY [setDate] DESC">
                                                                <SelectParameters>
                                                                    <asp:QueryStringParameter Name="typeid" Type="Int32" QueryStringField="typeid" />
                                                                    <asp:QueryStringParameter Name="bum_bz" QueryStringField="bum_id" Type="Int32" />
                                                                    <asp:ControlParameter Name="sectype" Type="Int32" ControlID="sectype" PropertyName="value" />
                                                                </SelectParameters>
                                                            </asp:SqlDataSource>
                                                            <tr>
                                                                <td colspan="3" id="mor1<%#Eval("id") %>" align="right" valign="bottom">
                                                                    <script type="text/javascript">
                                                                        getheight('mor1<%#Eval("id")%>', 'hei1<%#Eval("id") %>'); 
                                                                    </script>
                                                                    <a style="color: #0276a5;" href="DataTypeListXJB.aspx?typeId=<%#Eval("TypeID") %>&lanmuId=1&bum_id=<%=Request.QueryString["bum_id"].ToString()%>&sectype=<%#Eval("id") %>">
                                                                        [更多]</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                                    SelectCommand="select *,case row when 1 then 'taselected' else 'tas' end as css from (select ROW_NUMBER()Over(ORDER BY id) as row,*,(select count(*) from tunnel_xjbtype  where typeid=@typeid and parentid=@parentid) as [count] from tunnel_xjbtype  where typeid=@typeid and parentid=@parentid) as tunnel_xjbtype">
                                                    <SelectParameters>
                                                        <asp:ControlParameter PropertyName="value" ControlID="parentid" Name="parentid" Type="Int32" />
                                                        <asp:QueryStringParameter Name="typeid" Type="Int32" QueryStringField="typeid" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="height: 8px">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                    SelectCommand="select * from (select ROW_NUMBER()Over(ORDER BY id) as row,* from tunnel_xjbtype where parentid=0 and typeid=@typeid) as aa where row%2=1">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="typeid" QueryStringField="typeid" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td valign="top" align="center">
                <asp:Repeater ID="Repeater5" runat="server" DataSourceID="SqlDataSource5" OnItemCommand="Repeater1_ItemCommand"
                    OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="26" colspan="2" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="left">
                                                &nbsp;<%#Eval("TypeName") %>
                                            </td>
                                            <td width="40">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="206" valign="top" bgcolor="#FFFFFF">
                                    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" id="tablelist">
                                        <tr>
                                            <td width="86" height="100%">
                                                <input runat="server" id="parentid" type="hidden" value='<%#Eval("id") %>' />
                                                <input runat="server" id="typeid" type="hidden" value='<%#Eval("typeid") %>' />
                                                <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td height="" id='td<%#Eval("row") %><%#Eval("parentid") %>' class="<%#Eval("css") %>"
                                                                    onmouseover="showclasst(this,<%#Eval("row") %>,'<%#Eval("parentid") %>',<%#Eval("count") %>)">
                                                                    <%#Eval("TypeName") %>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                                        SelectCommand="select *,case row when 1 then 'toptd' else 'tds' end as css from (select ROW_NUMBER()Over(ORDER BY id) as row,*,(select count(*) from tunnel_xjbtype  where typeid=95 and parentid=25) as [count] from tunnel_xjbtype  where typeid=@typeid and parentid=@parentid) as tunnel_xjbtype">
                                                        <SelectParameters>
                                                            <asp:ControlParameter PropertyName="value" ControlID="parentid" Name="parentid" Type="Int32" />
                                                            <asp:QueryStringParameter Name="typeid" Type="Int32" QueryStringField="typeid" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                </table>
                                            </td>
                                            <td valign="left" align="left">
                                                <asp:Repeater ID="Repeater3" runat="server" DataSourceID="SqlDataSource3">
                                                    <ItemTemplate>
                                                        <table class="<%#Eval("css") %>" id="tab<%#Eval("row") %><%#Eval("parentid") %>"
                                                            width="100%" height="206" border="0" cellspacing="0" cellpadding="0">
                                                            <input runat="server" id="sectype" type="hidden" value='<%#Eval("id") %>' />
                                                            <asp:Repeater ID="Repeater4" runat="server" DataSourceID="SqlDataSource4">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td width="8" height="25">
                                                                            &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                                                        </td>
                                                                        <td width="" align="left">
                                                                            <a href="ViewXJB.aspx?id=<%#Eval("Id")%>&TypeId=<%=Request.QueryString["typeid"].ToString()%>&lanmuId=1&bum_id=<%=Request.QueryString["bum_id"].ToString()%>"
                                                                                title="<%#Eval("Title")%>">
                                                                                <%#title(Eval("Title"))%></a> <font color="red">
                                                                                    <%#shownew(Eval("setdate"))%></font>
                                                                        </td>
                                                                        <td width="40">
                                                                            <%#Eval("setdate", "{0:MM-dd}")%>
                                                                            <input id="hei<%#Eval("row") %><%#Eval("sectype") %>" type="hidden" value='<%#Eval("counts") %>' />
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                                                SelectCommand="SELECT top 7 ROW_NUMBER()Over(ORDER BY id) as row,*,(select top 7 count(*) FROM [Tunnel_InfoXJB] WHERE ([typeId] = @typeid) and del=0 and (bum_bz=@bum_bz) and sectype=@sectype) as counts FROM [Tunnel_InfoXJB] WHERE ([typeId] = @typeid) and del=0 and (bum_bz=@bum_bz) and sectype=@sectype ORDER BY [setDate] DESC">
                                                                <SelectParameters>
                                                                    <asp:QueryStringParameter Name="typeid" Type="Int32" QueryStringField="typeid" />
                                                                    <asp:QueryStringParameter Name="bum_bz" QueryStringField="bum_id" Type="Int32" />
                                                                    <asp:ControlParameter Name="sectype" Type="Int32" ControlID="sectype" PropertyName="value" />
                                                                </SelectParameters>
                                                            </asp:SqlDataSource>
                                                            <tr>
                                                                <td colspan="3" id="mor1<%#Eval("id") %>" align="right" valign="bottom">
                                                                    <script type="text/javascript">
                                                                        getheight('mor1<%#Eval("id")%>', 'hei1<%#Eval("id") %>'); 
                                                                    </script>
                                                                    <a style="color: #0276a5;" href="DataTypeListXJB.aspx?typeId=<%#Eval("TypeID") %>&lanmuId=1&bum_id=<%=Request.QueryString["bum_id"].ToString()%>&sectype=<%#Eval("id") %>">
                                                                        [更多]</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                                    SelectCommand="select *,case row when 1 then 'taselected' else 'tas' end as css from (select ROW_NUMBER()Over(ORDER BY id) as row,*,(select count(*) from tunnel_xjbtype  where typeid=95 and parentid=25) as [count] from tunnel_xjbtype  where typeid=@typeid and parentid=@parentid) as tunnel_xjbtype">
                                                    <SelectParameters>
                                                        <asp:ControlParameter PropertyName="value" ControlID="parentid" Name="parentid" Type="Int32" />
                                                        <asp:QueryStringParameter Name="typeid" Type="Int32" QueryStringField="typeid" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="height: 8px">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                    SelectCommand="select * from (select ROW_NUMBER()Over(ORDER BY id) as row,* from tunnel_xjbtype where parentid=0 and typeid=@typeid) as aa where row%2=0">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="typeid" QueryStringField="typeid" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
