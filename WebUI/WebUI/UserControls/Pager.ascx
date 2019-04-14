<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pager.ascx.cs" Inherits="_Controls_Pager" %>
<style type="text/css">
	



A:link
{
	font-size: 12px;
	color: #000000;
	text-decoration: underline;
}	
		
A:link { 
color: #152948; 
TEXT-DECORATION: none;}         

</style>
<p>
                    共<asp:Label ID="lblDataCount" runat="server"></asp:Label>
                    条记录|
第<asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
    页&nbsp;| 共<asp:Label ID="lblPageCount" runat="server" Text="lblPageCount"></asp:Label>
    页&nbsp;|&nbsp;
                    <asp:LinkButton ID="btnFirst" runat="server" 
        onclick="btnFirst_Click">首页</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnPrev" runat="server" 
        onclick="btnPrev_Click">上一页</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnNext" runat="server" 
        onclick="btnNext_Click">下一页</asp:LinkButton>
                    &nbsp;&nbsp;<asp:LinkButton ID="btnEnd" runat="server" 
        onclick="btnEnd_Click">尾页</asp:LinkButton>
                </p>

