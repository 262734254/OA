<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Tunnel_Bum.aspx.cs" Inherits="SystemManage_Tunnel_Bum" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header"></asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">
    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid;">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="Tunnel_Bum.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        部门管理</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
            <tr>
                <td style="width: 200px" valign="top">
                    <asp:TreeView ID="TreeView1" runat="server" ImageSet="BulletedList4" Width="100%"
                        ShowExpandCollapse="False">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px"
                            ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
                <td valign="top">
                    <table align="center" border="1" bordercolordark="#ffffff" bordercolorlight="#c1c1c1"
                        cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="right" height="35" style="background-color: #f6f6f6">
                                部门名称： 
                            </td>
                            <td colspan="2" height="35" style="background-color: #f6f6f6">
                                <asp:TextBox ID="txtname" runat="server" CssClass="inputtext" onkeyup="javascrip:checkWord(100,event,'lbl')"
                                    Width="211px"></asp:TextBox>
                                <br />
                                <asp:Label ID="lbl" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/100"></asp:Label>
                            </td>
                        </tr>
                        <tr style="color: #000000">
                            <td align="right" height="35">
                                备注： 
                            </td>
                            <td align="left" colspan="2" height="35" valign="middle">
                                <asp:TextBox ID="txtname2" runat="server" Height="92px" TextMode="MultiLine"
                                    Width="214px" onkeyup="javascrip:checkWord(1000,event,'lbl0')"></asp:TextBox>
                                
                                <br />
                                <asp:Label ID="lbl0" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/1000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" height="35" style="background-color: #f6f6f6">
                                上级部门： 
                            </td>
                            <td align="left" colspan="2" height="35" valign="middle" style="background-color: #f6f6f6">
                                
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="212px">
                                    <asp:ListItem Value="0">顶级机构</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" height="17" style="background-color: #e6f7ff">
                                <asp:Button ID="Button1" runat="server" CssClass="button" Text="保 存" OnClick="Button1_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
</asp:Content>
