<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="AddressManager_WebUserControl" %>

<asp:TreeView ID="TreeView1" runat="server" ImageSet="Contacts" NodeIndent="10">
    <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
    <HoverNodeStyle Font-Underline="False" />
    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" 
        VerticalPadding="0px" />
    <Nodes>
        <asp:TreeNode Text="个人通讯录" Value="个人通讯录">
            <asp:TreeNode NavigateUrl="~/AddressManager/UserInfo.aspx" Text="张三" Value="张三">
            </asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/AddressManager/UserInfo.aspx" Text="李四" Value="李四">
            </asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Text="公司通讯录" Value="公司通讯录">
            <asp:TreeNode NavigateUrl="~/AddressManager/UserInfo.aspx" Text="王五" Value="王五">
            </asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/AddressManager/UserInfo.aspx" Text="赵六" Value="赵六">
            </asp:TreeNode>
        </asp:TreeNode>
    </Nodes>
    <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
        HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
</asp:TreeView>



