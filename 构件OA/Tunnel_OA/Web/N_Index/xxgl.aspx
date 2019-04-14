<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="xxgl.aspx.cs" Inherits="N_Index_xxgl" %>

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
            background: url(images/r_g_01.gif) repeat-x;
        }
        .STYLE1
        {
            color: #FF0000;
            font-weight: normal;
        }
        .style2
        {
            color: #0080C0;
            font-size: 14px;
            font-weight: 800;
        }
       </style>

    <script type="text/javascript">

        function show(obj, img) {
            var objt = document.getElementById(obj);
            if (objt.style.display == 'none') {
                img.src = 'images/listtableicon-down.gif';
                objt.style.display = '';
            } else {
                img.src = 'images/listtableicon.gif';
                objt.style.display = 'none';
            }
        }

        function MM_jumpMenu(targ, selObj, restore) { //v3.0
            eval(targ + ".location='" + selObj.options[selObj.selectedIndex].value + "'");
            if (restore) selObj.selectedIndex = 0;
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
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeId=55&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource6">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="84%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=55&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"))%></a> <font color="red">
                                                        <%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="12%">
                                                <%#Eval("setdate", "{0:MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                    SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="55" Name="typeId" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td width="50%" align="center">
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;档案检索
                                    </td>
                                    <td width="40">
                                        <asp:LinkButton Text="[更多]" runat="server" ID="lkb1" CssClass="a" ForeColor="#0276a5"
                                            OnCommand="lkb1_Command"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="middle" bgcolor="#FFFFFF" align="center">
                            <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="27px" height="35px">
                                        <img src="../images/searchWD.gif" width="25px" />
                                    </td>
                                    <td class="style2" width="80px" align="right">
                                        文件名称:
                                    </td>
                                    <td align="left">
                                        <label>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2" width="80px" colspan="2" align="right" height="35px">
                                        年份:
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2" width="80px" colspan="2" align="right" height="35px">
                                        部门:
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownList2" runat="server">
                                            <asp:ListItem>请选择</asp:ListItem>
                                            <asp:ListItem>党总支</asp:ListItem>
                                            <asp:ListItem>工会</asp:ListItem>
                                            <asp:ListItem>总工程师室</asp:ListItem>
                                            <asp:ListItem>总经理办公室</asp:ListItem>
                                            <asp:ListItem>人力资源部</asp:ListItem>
                                            <asp:ListItem>经营计划部</asp:ListItem>
                                            <asp:ListItem>资产管理部</asp:ListItem>
                                            <asp:ListItem>工程管理部</asp:ListItem>
                                            <asp:ListItem>安全管理部</asp:ListItem>
                                            <asp:ListItem>贯标办公室</asp:ListItem>
                                            <asp:ListItem>信息管理中心</asp:ListItem>
                                            <asp:ListItem>团总支</asp:ListItem>
                                            <asp:ListItem>防水室</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2" width="80px" colspan="2" align="right" height="35px">
                                        文件类型:
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownList3" runat="server">
                                            <asp:ListItem>请选择</asp:ListItem>
                                            <asp:ListItem>通知/办法/决议/批复/请示</asp:ListItem>
                                            <asp:ListItem>规定/制度/标准</asp:ListItem>
                                            <asp:ListItem>报表</asp:ListItem>
                                            <asp:ListItem>申报材料/评比表彰</asp:ListItem>
                                            <asp:ListItem>会议记录</asp:ListItem>
                                            <asp:ListItem>计划/总结</asp:ListItem>
                                            <asp:ListItem>大事记</asp:ListItem>
                                            <asp:ListItem>QC</asp:ListItem>
                                            <asp:ListItem>论文</asp:ListItem>
                                            <asp:ListItem>专利</asp:ListItem>
                                            <asp:ListItem>合同</asp:ListItem>
                                            <asp:ListItem>施组</asp:ListItem>
                                            <asp:ListItem>特殊载体</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center" height="35px">
                                        <asp:Button ID="Button1" runat="server" Text="" CssClass="searchbutton" OnClick="Button1_Click" />
                                    </td>
                                </tr>
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
                                        &nbsp;统计信息
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeid=57&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="57" Name="typeId" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="84%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=57&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"))%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="12%">
                                                <%#Eval("setdate", "{0:MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="height: 8px">
                        </td>
                    </tr>
                </table>
                <table width="98%" id="listtable" border="0" height="232" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" colspan="2" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;图片信息
                                    </td>
                                    <td width="40">
                                        <asp:LinkButton runat="server" ID="lkb2" Text="[更多]" ForeColor="#0276a5" OnCommand="lkb2_Command"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 206px" valign="top" bgcolor="#FFFFFF">
                            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                                <tr style="display:none">
                                    <td width="50px">
                                    </td>
                                    <td width="27px" height="35px">
                                        <img src="../images/searchWD.gif" width="25px" />
                                    </td>
                                    <td class="style2" width="80px" align="right">
                                        文件名称:
                                    </td>
                                    <td width="160px">
                                        <label>
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="inputsearch" Height="16px"></asp:TextBox>
                                        </label>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" runat="server" src="../images/gif53_007.gif" border="0"
                                            OnClick="ImageButton1_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" align="center" valign="middle">
                                        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" DataSourceID="SqlDataSource1"
                                            Width="95%" RepeatDirection="Horizontal">
                                            <ItemTemplate>
                                                <table   border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="100" align="center">
                                                            <a href="../N_Search/N_PictureView.aspx?id=<%#Eval("i_id") %>&type=2" title="<%# Eval("i_name") %>">
                                                                <image src="../N_News/N_Picture/image/_<%#Eval("i_uri") %>" width="100" height="80" />
                                                                <div><%#title(Eval("i_name"),12)%></div>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                            SelectCommand="SELECT top 6 [i_id], [i_name], [i_uri], [i_date], [i_user] FROM [Tunnel_Img] ORDER BY [i_date] DESC">
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
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
                                        &nbsp;宣传工作
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeid=88&lanmuId=0">[更多]</a>
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
                                            <td width="84%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=88&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"))%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="12%">
                                                <%#Eval("setdate", "{0:MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                    SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="88" Name="typeId" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
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
                                        &nbsp;参考资料
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeList.aspx?typeid=59&lanmuId=0">[更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="206" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater6" runat="server" DataSourceID="SqlDataSource5">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="4%" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="84%" align="left">
                                                <a href="ViewIndex.aspx?id=<%#Eval("Id")%>&TypeId=59&lanmuId=0" title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"))%></a>&nbsp;<font color="red"><%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="12%">
                                                <%#Eval("setdate", "{0:MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                    SelectCommand="SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="59" Name="typeId" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
