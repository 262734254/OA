<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="N_XJBInfoManage.aspx.cs" Inherits="N_News_N_EntryByTheDepartmentOf_N_XJBInfoManage" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>科室信息管理</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/Calendarform.js" type="text/javascript"></script>

    <script src="../../javascript/utility.js" type="text/javascript"></script>

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function fshow(obj) {
            $("#" + obj).show();
        }
        function fhide(obj) {
            $("#" + obj).hide();
        }
        function selectall(id, select) {
            var form = tbReport.getElementsByTagName("INPUT");
            var checkbox = new Array();
            var num1 = 0;
            for (var i = 0; i < form.length; i++) {
                if (form[i].type == "checkbox") {
                    checkbox[num1] = form[i];
                    num1++;
                }
            }
            var num = 0;
            if (select == 0) {
                for (var i = 0; i < checkbox.length; i++) {
                    if (checkbox[i].checked)
                        num++;
                    else
                        checkbox[i].checked = true;
                }
                if (checkbox.length == num) {
                    for (var i = 0; i < checkbox.length; i++) {
                        checkbox[i].checked = false;
                    }
                }
            }
            else {
                for (var i = 0; i < checkbox.length; i++) {
                    if (checkbox[i].checked)
                        checkbox[i].checked = false;
                    else
                        checkbox[i].checked = true;
                }
            }

        }
    </script>

    <style type="text/css">
        ul
        {
            margin: 0px;
            padding: 0px;
        }
        li
        {
            list-style: none;
            height: 20px;
            text-align: center;
            margin: 0px;
            width: 100%;
            padding-top: 5px;
            cursor: pointer;
        }
        .style1
        {
            width: 93px;
        }
        .style2
        {
            height: 24px;
            width: 93px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border-top: 1px #6f97b1 solid;
        border-bottom: 0px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
        <tr align="left">
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="N_XJBTypeAdd.aspx" class="a">
                    <div style="width:73; height:27px; cursor:pointer;">类型管理</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="N_XJBInfoAdd.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        信息发布</div>
                </a>
            </td>
            <td width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="N_XJBInfoManage.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        信息管理</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border-bottom: 0px #6f97b1 solid;
        border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid; height: 30px;border-top:1px #6f97b1 solid;">
        <tr>
            <td style="width: 400px" align="right" bgcolor="#f6f6f6">
                标题关键字：&nbsp;<asp:TextBox ID="TextBox1" Width="300" runat="server"></asp:TextBox>
            </td>
            <td align="left" bgcolor="#f6f6f6">
                &nbsp;<asp:Button ID="BtnSearch" runat="server" CssClass="searchbutton" OnClick="BtnSearch_Click" />
            </td>
        </tr>
    </table>
    <table width="100%" border="0" id="tbReport" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC"
        bordercolorlight="#c8c8c8" bordercolordark="#FFFFFF" style="border-collapse:collapse;border-left: 1px #6f97b1 solid;
        border-right: 1px #6f97b1 solid;border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;">
        <tr>
            <td style="border-top:0px;border-left:0px" width="31" align="center" bgcolor="#f6f6f6">
                <strong>选择</strong>
            </td>
            <td style="border-top:0px;" height="30" align="center" bgcolor="#f6f6f6">
                <strong>标题</strong>
            </td>
            <td style="border-top:0px;" width="90" align="center" bgcolor="#f6f6f6">
                <strong>项经部</strong>
            </td>
            <td style="border-top:0px;" width="90" align="center" bgcolor="#f6f6f6">
                <strong>子类型</strong>
            </td>
            <td style="border-top:0px;" width="55" align="center" bgcolor="#f6f6f6">
                <strong>发布人</strong>
            </td>
            <td style="border-top:0px;" width="55" align="center" bgcolor="#f6f6f6">
                <strong>部门</strong>
            </td>
            <td style="border-top:0px;" style="border-top:0px;" width="31" align="center" bgcolor="#f6f6f6">
                <strong>附件</strong>
            </td>
            <td style="border-top:0px;" width="110" align="center" bgcolor="#f6f6f6">
                <strong>发布时间</strong>
            </td>
            <td style="border-top:0px;border-right:0px" width="58" align="center" bgcolor="#f6f6f6">
                <strong>操作</strong>
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <tr style="height: 26px">
                    <td style="border-left:0px;" bgcolor="#FFFFFF" align="center" height="26">
                        <input id="SelectCode" type="hidden" value='<%#Eval("Id")%>' runat="server" />
                        <input type="checkbox" name="cb1" tag="cb1" id="cb1" runat="server" />
                    </td>
                    <td bgcolor="#FFFFFF" align="left" height="26" title='<%#Eval("Title")%>'>
                        &nbsp;<%#title(Eval("Title"),43)%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center" height="26">
                        &nbsp;<%#Getsectype(Eval("TypeId").ToString())%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center" height="26">
                        &nbsp;<%#strShow(Eval("secType").ToString())%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#ShowUserName(Eval("UserId").ToString())%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center" height="26">
                        &nbsp;<%#GetBum(Eval("UserId"))%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center" height="26">
                        &nbsp;<%#iffile(Eval("id"))%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%# Convert.ToDateTime(Eval("SetDate")).ToString("yyyy-MM-dd")%>
                    </td>
                    <td style="border-right:0px;" bgcolor="#FFFFFF" align="center" height="26">
                        <asp:LinkButton ID="LinkButton2" CommandArgument='<%#Eval("UserId")%>' CommandName='<%#Eval("Id")%>'
                            runat="server" OnCommand="LinkButton2_Command" ToolTip="修改本条记录">修改</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("UserId")%>' CommandName='<%#Eval("Id")%>'
                            runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('是否删除此条记录？')">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td height="30" colspan="9" align="center" bgcolor="#e6f7ff" style="border:0px">
                <table width="100%" style="border-collapse:collapse;height: 28px" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="12%" align="center">
                            <span onclick="selectall('cb1',0);" style="cursor: hand; color: Green;">全选</span>
                            <span>/</span> <span onclick="selectall('cb1',1);" style="cursor: hand; color: Green;">
                                反选</span>
                        </td>
                        <td width="7%">
                            <asp:Button ID="btnDel" OnClientClick="return confirm('确认删除选中信息？');" runat="server"
                                CssClass="button" Text="批量删除" BorderStyle="None" OnClick="btnDel_Click" />
                        </td>
                        <td width="85%" align="center">
                            &nbsp;
                            <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                                <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                            </cc1:MTCPager>
                        </td>
                    </tr>
                </table>
                <label>
                </label>
            </td>
        </tr>
    </table>
</asp:Content>
