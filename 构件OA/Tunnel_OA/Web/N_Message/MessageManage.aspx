<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="MessageManage.aspx.cs" Inherits="N_Message_MessageManage" %>
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script src="../javascript/Calendarform.js" type="text/javascript"></script>
        <script src="../javascript/utility.js" type="text/javascript"></script>
        <script src="../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
    <tr>
        <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
        <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
            <a href="MessageAdd.aspx" class="a">
                <div style="width:73; height:27px; cursor:pointer;">发布留言</div>
            </a>
        </td>
        <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon">
            <a href="MessageManage.aspx" class="a">
                <div style="width:73; height:27px;cursor:pointer;">管理留言</div>
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
                                    <asp:ImageButton ID="ibtnQuery" runat="server" ImageUrl="../images/search.gif" 
                                        onclick="ibtnQuery_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
                <tr>
                    <td>
                        <asp:DataGrid ID="dgdMes" runat="server" AutoGenerateColumns="false" 
                            Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" 
                            onitemcommand="dgdMes_ItemCommand" onitemdatabound="dgdMes_ItemDataBound">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundColumn DataField="MesID" HeaderText="编号"></asp:BoundColumn>
                                <asp:BoundColumn DataField="MesTitle" HeaderText="标题"></asp:BoundColumn>
                                <asp:BoundColumn DataField="MesContent" HeaderText="内容"></asp:BoundColumn>
                                <asp:BoundColumn DataField="MesDate" HeaderText="发布时间"></asp:BoundColumn>
                                <asp:BoundColumn DataField="MesUser" HeaderText="发布人"></asp:BoundColumn>
                                <asp:ButtonColumn CommandName="Select" Text="修改" HeaderText="修改">
                                </asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="Delete" Text="删除" HeaderText="删除">
                                </asp:ButtonColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" HorizontalAlign="Center" />
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