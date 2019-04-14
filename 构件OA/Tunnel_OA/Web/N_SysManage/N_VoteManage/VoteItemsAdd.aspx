<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="VoteItemsAdd.aspx.cs" Inherits="Vote_VoteItemsAdd" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../css/group.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="NewVote.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增投票</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="VoteManageList.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        投票管理</div>
                </a>
            </td>
               <td width="74" id="Td1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="../../N_PicVote/ChangePhotos.aspx"class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        整体风格</div>
                </a>
            </td>
                <td width="74" id="Td2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="../../N_PicVote/UpPhoto.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        上传票项</div>
                </a>
            </td>
                            <td width="74" id="Td3" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="../../N_PicVote/Manage_VotePic.aspx" class="a"  target=_blank>
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理票项</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td class="tou">
                投票候选项管理:<%=voteTitle %>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ivote_Id"
        DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None"
        Width="100%">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="ivote_Id" HeaderText="ivote_Id" InsertVisible="False"
                ReadOnly="True" SortExpression="ivote_Id" Visible="False" />
            <asp:BoundField DataField="ivote_Title" HeaderText="候选项" SortExpression="ivote_Title">
                <ItemStyle Width="400px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="票数" SortExpression="ivote_Count">
                <EditItemTemplate>
                    <%# Eval("ivote_Count") %>票
                </EditItemTemplate>
                <ItemTemplate>
                    <%# Eval("ivote_Count") %>票
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="投票人员">
                <ItemTemplate>
                    <%#GetName(Eval("ivote_yesUserId"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ivote_yesUserId" HeaderText="投票人员" ReadOnly="True" SortExpression="ivote_yesUserId"
                Visible="False" />
            <asp:BoundField DataField="ivote_voteId" HeaderText="ivote_voteId" ReadOnly="True"
                SortExpression="ivote_voteId" Visible="False" />
            <asp:CommandField HeaderText="操作" ShowDeleteButton="True" ShowEditButton="True">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        DeleteCommand="DELETE FROM [Tunnel_Votei] WHERE [ivote_Id] = @original_ivote_Id"
        InsertCommand="INSERT INTO [Tunnel_Votei] ([ivote_Title], [ivote_Count], [ivote_yesUserId], [ivote_voteId]) VALUES (@ivote_Title, @ivote_Count, @ivote_yesUserId, @ivote_voteId)"
        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Tunnel_Votei] WHERE ([ivote_voteId] = @ivote_voteId)"
        UpdateCommand="UPDATE [Tunnel_Votei] SET [ivote_Title] = @ivote_Title WHERE [ivote_Id] = @original_ivote_Id">
        <SelectParameters>
            <asp:QueryStringParameter Name="ivote_voteId" QueryStringField="id" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="original_ivote_Id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="ivote_Title" Type="String" />
            <asp:Parameter Name="ivote_Count" Type="Int32" />
            <asp:Parameter Name="ivote_yesUserId" Type="String" />
            <asp:Parameter Name="ivote_voteId" Type="Int32" />
            <asp:Parameter Name="original_ivote_Id" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="ivote_Title" Type="String" />
            <asp:Parameter Name="ivote_Count" Type="Int32" />
            <asp:Parameter Name="ivote_yesUserId" Type="String" />
            <asp:Parameter Name="ivote_voteId" Type="Int32" />
        </InsertParameters>
    </asp:SqlDataSource>
    添加候选项：<br />
    <asp:TextBox ID="TextBox1" runat="server" Height="138px" TextMode="MultiLine" Width="705px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" CssClass="button" />
    <asp:Button ID="Button2" CssClass="button" runat="server" Text="完成" OnClick="Button2_Click" />
</asp:Content>