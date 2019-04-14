<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Produce_Manage.aspx.cs" Inherits="N_Produce_Produce_Manage" %>
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>

<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<script src="../javascript/Calendarform.js" type="text/javascript"></script>
        <script src="../javascript/utility.js" type="text/javascript"></script>
        <script src="../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
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
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
        <a href="Produce_Add.aspx?type=<%=Request.QueryString["type"] %>&name=<%=Request.QueryString["name"] %>" class="a">
            <div style="width:73; height:27px; cursor:pointer;">新建<%=Request.QueryString["name"] %></div>
        </a>
    </td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon">
        <a href="Produce_Manage.aspx?type=<%=Request.QueryString["type"] %>&name=<%=Request.QueryString["name"] %>" class="a">
            <div style="width:73; height:27px;cursor:pointer;">管理<%=Request.QueryString["name"] %></div>
        </a>
    </td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid; border-top:none">
                <tr>
                    <td bgcolor="#f6f6f6">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>&nbsp;标题：</td>
                                <td>
                                    <asp:TextBox ID="txtTitle" runat="server" Text="" Width="212px"></asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>&nbsp;时间：</td>
                                <td>
                                    <asp:TextBox ID="txtStarDate" runat="server" Width="80px" onpaste= "return   false "></asp:TextBox>
                                    <img style="cursor:pointer" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_txtStarDate')" src="../image/icon5.gif" />
                                    &nbsp;
                                    －
                                    <asp:TextBox ID="txtEndDate" runat="server" Width="80px" onpaste= "return   false "></asp:TextBox>
                                    <img style="cursor:pointer" src="../image/icon5.gif" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_txtEndDate')"/>
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        ImageUrl="../images/search.gif" onclick="ImageButton1_Click"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
                <tr>
                    <td>
                        <asp:DataGrid ID="dgdPro" runat="server" AutoGenerateColumns="False" 
                            Width="100%" CellPadding="4" ForeColor="#333333" 
                                                        GridLines="None" onitemcommand="dgdPro_ItemCommand" 
                                                        onitemdatabound="dgdPro_ItemDataBound" 
                            AllowCustomPaging="True">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle Visible="False" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundColumn DataField="ProID" HeaderText="编号"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ProTitle" HeaderText="标题"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ProName" HeaderText="附件名"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CreateUser" HeaderText="上传人"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CreateDate" HeaderText="上传时间"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ProSrc" HeaderText="路径" Visible="false"></asp:BoundColumn>
                                <asp:ButtonColumn CommandName="Select" Text="修改" HeaderText="修改">
                                </asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="Delete" Text="删除" HeaderText="删除">
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
        </td>
  </tr>
</table>
</asp:Content>
