<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_MessageOld.aspx.cs" Inherits="grzm_OldMessage" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">

    <title>己发站内信息</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

 

    <script type="text/javascript">
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
                    else {
                        if (!checkbox[i].disabled)
                            checkbox[i].checked = true;
                    }
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
                    else {
                        if (!checkbox[i].disabled)
                            checkbox[i].checked = true;
                    }
                }
            }

        }
    </script>

</head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-bottom:0px #6f97b1 solid;border-left:1px #6f97b1 solid;border-top:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr align="left">
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_MessageSend.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">发送信息</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_MessageReceive.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer; text-indent:20px">收件箱</div>
    </a></td>
    <td width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_MessageOld.aspx" class="a">
      <div style="width:73; height:27px;cursor:pointer; text-indent:20px">发件箱</div>
    </a></td>
    <td width="74" id="icon4" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_MessageRecycle.aspx" class="a">
      <div style="width:73; height:27px;cursor:pointer; text-indent:20px">回收站</div>
    </a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
    <table id="tbReport"  width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" bordercolorlight="#c8c8c8" bordercolordark="#FFFFFF" 
        style="border-collapse:collapse;border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid; border-top: 1px #6f97b1 solid; border-bottom: 1px #6f97b1 solid">
        <tr height="20">
            <td width="31" style="border-left:0px;border-top:0px" align="center" bgcolor="#f6f6f6">
                <strong>选择</strong>
            </td>
            <td style="border-top:0px" align="center" bgcolor="#f6f6f6">
                <strong>标题</strong>
            </td>
            <td style="border-top:0px" width="60" align="center" bgcolor="#f6f6f6">
                <strong>发件人</strong>
            </td>
            <td style="border-top:0px" width="110" align="center" bgcolor="#f6f6f6" height="30">
                <strong>发送时间</strong>
            </td>
            <td style="border-top:0px" width="60" align="center" bgcolor="#f6f6f6">
                <strong>收件人</strong>
            </td>
            <td style="border-top:0px" width="100" align="center" bgcolor="#f6f6f6" height="30">
                <strong>附件</strong>
            </td>
            <td style="border-top:0px" width="28" align="center" bgcolor="#f6f6f6" height="30">
                <strong>状态</strong>
            </td>
            <td width="28" align="center" style="border-right:0px;border-top:0px" bgcolor="#f6f6f6" height="30">
                <strong>操作</strong>
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr height="26">
                    <td style="border-left:0px;" bgcolor="#FFFFFF" align="center" height="26">
                        <input id="SelectCode" type="hidden" value='<%#Eval("m_id")%>' runat="server" />
                        <input type="checkbox" name="cb1" tag="cb1" id="cb1" runat="server" />
                    </td>
                    <td bgcolor="#FFFFFF" align="left" height="26">
                        &nbsp;<a href="N_MessageView.aspx?Id=<%#Eval("m_id")%>&typeid=2" title="查看详细"><%#Eval("m_title")%></a>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#ShowUserName(Eval("m_from").ToString())%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#Eval("m_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#ShowUserName(Eval("m_to").ToString())%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<a href='../../<%#Eval("m_file")%> ' title="点击下载"><%#System.IO.Path.GetFileName(Eval("m_file").ToString())%></a>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#ShowState(Eval("m_state").ToString())%>
                    </td>
                    <td bgcolor="#FFFFFF" style="border-right:0px" align="center" height="26">
                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("m_id")%>' runat="server"
                            OnCommand="LinkButton1_Command" ToolTip="删除本条记录">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="8" style="border-bottom:0px;border-right:0px;border-left:0px;border-top:0px">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td width="12%" align="center" bgcolor="#e6f7ff">
                            <span onclick="selectall('cb1',0);" style="cursor: hand; color: Green;">全选</span>
                            <span>/</span> <span onclick="selectall('cb1',1);" style="cursor: hand; color: Green;">
                                反选</span>
                        </td>
                        <td width="7%" bgcolor="#e6f7ff">
                            <asp:Button ID="btnDel" OnClientClick="return confirm('确认删除选中信息？');" runat="server"
                                CssClass="button" Text="批量删除" BorderStyle="None" OnClick="btnDel_Click" />
                        </td>
                        <td height="30" colspan="6" align="center" bgcolor="#e6f7ff">
                            <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                                <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                            </cc1:MTCPager>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
