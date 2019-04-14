<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="N_XJBTypeAdd.aspx.cs" Inherits="N_News_N_EntryByTheDepartmentOf_N_XJBTypeAdd" %>
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>

<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
        
    <script type="text/javascript">
        function fshow(obj){
            $("#"+obj).show();
         }
        function fhide(obj){
            $("#"+obj).hide();
         }
        
    </script>
    <style type="text/css">
        ul{ margin:0px; padding:0px}
        li{ list-style:none; height:20px; text-align:center; margin:0px; width:100%; padding-top:5px; cursor:pointer}
    </style>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top: 1px #6f97b1 solid;
        border-bottom: 1px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
        <tr align="left">
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon">
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
            <td width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicons">
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
    <table align="center" border="1" bordercolordark="#ffffff" bordercolorlight="#c1c1c1"
                        cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right" height="35" style="background-color: #f6f6f6">
                项经部名称：
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
            <td align="right" height="35" style="background-color: #f6f6f6">
                
            </td>
            <td align="left" colspan="2" height="35" valign="middle" style="background-color: #f6f6f6">
                <asp:CheckBox ID="cboxDate" runat="server" Text="停用" />
            </td>
        </tr>
        <tr>
            <td align="center" height="17" style="background-color: #e6f7ff">
                
            </td>
            <td align="left" colspan="2" height="17" style="background-color: #e6f7ff">
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="保 存" 
                    onclick="Button1_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnCanel" runat="server" CssClass="button" Text="取 消" 
                    onclick="btnCanel_Click" />
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
                            项经部名称：
                            <asp:TextBox ID="txtTitle" runat="server" Text="" Width="212px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            是否停用：
                            <asp:DropDownList ID="ddlStop" runat="server">
                                <asp:ListItem Text="全部" Value="A" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="是" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="否" Value="N"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                <asp:DataGrid ID="dgdXJBType" runat="server" AutoGenerateColumns="False" 
                    Width="100%" CellPadding="4" ForeColor="#333333" 
                                                GridLines="None" AllowCustomPaging="True" 
                    onitemcommand="dgdXJBType_ItemCommand" 
                    onitemdatabound="dgdXJBType_ItemDataBound">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditItemStyle BackColor="#999999" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle Visible="False" />
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                    <Columns>
                        <asp:BoundColumn DataField="id" HeaderText="编号"></asp:BoundColumn>
                        <asp:BoundColumn DataField="typename" HeaderText="项经部名"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IsStop" HeaderText="是否停用"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UserID" HeaderText="停用者"></asp:BoundColumn>
                        <asp:ButtonColumn CommandName="Select" Text="修改" HeaderText="修改">
                        </asp:ButtonColumn>
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
         
