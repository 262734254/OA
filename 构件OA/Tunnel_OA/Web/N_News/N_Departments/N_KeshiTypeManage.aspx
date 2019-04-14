<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="N_KeshiTypeManage.aspx.cs" Inherits="N_News_N_Departments_N_KeshiTypeManage" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
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
        </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top: 1px #6f97b1 solid;
        border-bottom: 1px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
        <tr align="left">
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="N_KeshiTypeManage.aspx" class="a">
                    <div style="width:73; height:27px; cursor:pointer;">类型管理</div>
                </a>
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="N_KeshiAdd.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        发布信息</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="N_KeshiManage.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理信息</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table align="center" border="1" bordercolordark="#ffffff" bordercolorlight="#c1c1c1"
                        cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right" height="35" style="background-color: #f6f6f6">
                科室名称：
            </td>
            <td colspan="2" height="35" style="background-color: #f6f6f6">
                <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" height="35" style="background-color: #f6f6f6">
                科室子类型：
            </td>
            <td colspan="2" height="35" style="background-color: #f6f6f6">
                <asp:TextBox ID="txtname" runat="server" CssClass="inputtext" onkeyup="javascrip:checkWord(100,event,'lbl')"
                    Width="211px">
                </asp:TextBox>
                <asp:Label ID="lbl" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/100"></asp:Label>
                <asp:HiddenField ID="hidValue" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td align="center" height="17" style="background-color: #e6f7ff">
                
            </td>
            <td align="left" colspan="2" height="17" style="background-color: #e6f7ff">
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="保 存" 
                    onclick="Button1_Click"/>
                &nbsp;&nbsp;
                <asp:Button ID="btnCanel" runat="server" CssClass="button" Text="取 消" 
                    onclick="btnCanel_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
            </td>
        </tr>
    </table>
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid; border-top:none">
        <tr>
            <td bgcolor="#e6f7ff">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;科室名称：
                            <asp:DropDownList ID="ddlType1" runat="server">
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            &nbsp;&nbsp;科室子类型：
                            <asp:TextBox ID="txtTitle" runat="server" Text="" Width="320px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                ImageUrl="../../images/search.gif" onclick="ImageButton1_Click"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr>
            <td>
                <asp:DataGrid ID="dgdType" runat="server" AutoGenerateColumns="False" 
                    Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" 
                    AllowCustomPaging="True" onitemcommand="dgdType_ItemCommand">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditItemStyle BackColor="#999999" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle Visible="False" />
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                    <Columns>
                        <asp:BoundColumn DataField="TypeID" HeaderText="编号"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TypeName" HeaderText="科室子类型"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="科室名称">
                            <ItemTemplate>
                                <asp:Label ID="lblBumName" runat="server" Text='<%#GetTypeName(Eval("ParentID").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="ParentID" HeaderText="父ID" Visible="false"></asp:BoundColumn>
                        <asp:ButtonColumn CommandName="Select" Text="修改" HeaderText="修改"></asp:ButtonColumn>
                        <asp:ButtonColumn CommandName="Delete" Text="删除" HeaderText="删除"></asp:ButtonColumn>
                    </Columns>
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Left" />
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td height="30" colspan="6" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
                <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                    <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                </cc1:MTCPager>
            </td>
        </tr>
    </table>
</asp:Content>