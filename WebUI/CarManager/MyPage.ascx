<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyPage.ascx.cs" Inherits="CarManager_MyPage" %>
<asp:LinkButton ID="lnkFirst" runat="server" OnClick="lnkFirst_Click">首页</asp:LinkButton>
<asp:LinkButton ID="lnkPrev" runat="server" OnClick="lnkPrev_Click">上一页</asp:LinkButton>
<asp:LinkButton ID="lnkNext" runat="server" OnClick="lnkNext_Click">下一页</asp:LinkButton>
<asp:LinkButton ID="lnkLast" runat="server" OnClick="lnkLast_Click">末页</asp:LinkButton>
总共<asp:Label ID="lblTotalPages" runat="server"></asp:Label>页 当前第<asp:Label
    ID="lblCurrentPage" runat="server"></asp:Label>页