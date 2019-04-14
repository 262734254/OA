<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="xjb.aspx.cs" Inherits="N_Index_xjb" %>

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
        function showclass(obj, num, name, sum) {
            for (var i = 1; i <= sum; i++) {
                if (num == i) {
                    $(obj).attr("class", "selecttd");
                    $("#tab" + i + name).css("display", "block");
                } else {
                    $("#td" + i + name).attr("class", "tds");
                    $("#tab" + i + name).css("display", "none");
                }
            }
            $("#td1" + name).addClass("toptd");
        }
        $(document).ready(function() {
            $("#divxjb").mouseover(function() {
                $("#ctl00_ContentPlaceHolder1_Panel3").slideDown(700);
            });
            //            $("#ctl00_ContentPlaceHolder1_Panel3").mouseout(function() {
            //                $(this).slideUp(700);
            //            })
            //            $("#sondiv").mouseover(function() {
            //                $("#ctl00_ContentPlaceHolder1_Panel3").slideDown(0);
            //            })
        });
       
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="2" height="4px">
                <div  runat="server" id="Panel3" style="display: none; height: 28px;
                    vertical-align: middle; background-image: url(/images/yincang.gif); width: 100%;float:left;">
                    <div style="width:52px;height:100%;float:left;">
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td width="50%" align="center" valign="top">
                <table width="98%" id="listtable" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;生产日志
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeListXJB.aspx?typeId=<%=Request.QueryString["bum_id"].ToString()%>&lanmuId=1&bum_id=<%=Request.QueryString["bum_id"].ToString()%>&sectype=1">
                                            [更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="500" valign="top" bgcolor="#FFFFFF">
                            <table id="tab1gcgk" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="8" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="" align="left">
                                                <a href="ViewXJB.aspx?id=<%#Eval("Id")%>&TypeId=<%=Request.QueryString["bum_id"].ToString()%>&lanmuId=1&bum_id=<%=Request.QueryString["bum_id"].ToString()%>"
                                                    title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"))%></a> <font color="red">
                                                        <%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="60">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                    SelectCommand="SELECT top 15 * FROM [Tunnel_InfoXJB] WHERE ([typeId] = @bum_id) AND sectype=1 and del=0  ORDER BY [setDate] DESC">
                                    <SelectParameters>
                                        <asp:QueryStringParameter DefaultValue="1" Name="bum_id" QueryStringField="bum_id" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td height="100%" width="50%" align="center" valign="top">
                <table width="98%" id="listtable" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/r_topbg.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="left">
                                        &nbsp;基地动态
                                    </td>
                                    <td width="40">
                                        <a style="color: #0276a5;" href="DataTypeListXJB.aspx?typeId=<%=Request.QueryString["bum_id"].ToString()%>&lanmuId=1&bum_id=<%=Request.QueryString["bum_id"].ToString()%>&sectype=2">
                                            [更多]</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="500" valign="top" bgcolor="#FFFFFF">
                            <table style="display: block" id="tab1jdgl" width="100%" border="0" cellspacing="0"
                                cellpadding="0">
                                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                                    <ItemTemplate>
                                        <tr>
                                            <td width="8" height="25">
                                                &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                            </td>
                                            <td width="" align="left">
                                                <a href="ViewXJB.aspx?id=<%#Eval("Id")%>&TypeId=<%=Request.QueryString["bum_id"].ToString()%>&lanmuId=1&bum_id=<%=Request.QueryString["bum_id"].ToString()%>"
                                                    title="<%#Eval("Title")%>">
                                                    <%#title(Eval("Title"))%></a> <font color="red">
                                                        <%#shownew(Eval("setdate"))%></font>
                                            </td>
                                            <td width="60">
                                                <%#Eval("setdate", "{0:yyyy-MM-dd}")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                    SelectCommand="SELECT top 15 * FROM [Tunnel_InfoXJB] WHERE ([typeId] = @bum_id) and sectype=2 and del=0  ORDER BY [setDate] DESC">
                                    <SelectParameters>
                                        <asp:QueryStringParameter DefaultValue="2" Name="bum_id" 
                                            QueryStringField="bum_id" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
