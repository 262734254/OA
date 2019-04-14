<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyBorrow.aspx.cs" Inherits="ApplyBorrow" %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>借用申请录入页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>

    <%--<script type="text/javascript">
    function openAdd(){
        window.showModalDialog("SelectResource.aspx","new");
    }
</script>--%>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 450px;
            background-color: #C6DAF3;
        }
        .style2
        {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        资源借用申请</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table style="" width="500px">
                        <tr align="left">
                            <td>
                                借&nbsp;用&nbsp;人 ：<asp:TextBox ID="txtUser" class="inputs" runat="server" Width="120"
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                            <td>
                                申请类型：<asp:DropDownList ID="ddlType" runat="server" Width="120px">
                                    <asp:ListItem Value="1">借用</asp:ListItem>
                                    <asp:ListItem Value="2">使用</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                借用时间：<input type="text" onclick="showcalendar(event, this);" id="txtBorrowTime" runat="server"
                                    style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    width: 120px; border-bottom: #99ccff 1px solid" readonly="readonly" /><asp:RequiredFieldValidator ID="rfvBorrowTime"
                                        runat="server" ErrorMessage="请点击选择借用时间" ControlToValidate="txtBorrowTime">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                紧急程度：<asp:TextBox ID="txtExigentGrade" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvExigentGrade" runat="server" ErrorMessage="请输入紧急程度"
                                    ControlToValidate="txtExigentGrade">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2" class="style2">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtMark" class="inputs" runat="server"
                                    Height="59px" TextMode="MultiLine" Width="330px"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator5" runat="server" ErrorMessage="备注不能为空" ControlToValidate="txtMark">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="center">
                            <th align="left">
                                借用资源
                            </th>
                            <th align="right">
                                <asp:Button ID="btnAdd" runat="server" class="BigButton" Text="添加资源" CausesValidation="False"
                                    OnClick="btnAdd_Click" />
                            </th>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:GridView ID="gvSelectedResouce" runat="server" AutoGenerateColumns="False" PageSize="5"
                                    Width="100%" OnRowDeleting="gvSelectedResouce_RowDeleting">
                                    <RowStyle CssClass="TableContent" Height="32px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="资源类型">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Resource.Type.RTName") %>'></asp:Label>
                                                <asp:HiddenField ID="hidId" runat="server" Value='<%# Eval("Resource.RIID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="资源名称">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Resource.RIName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="资源规格">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Resource.RISpec") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="借用数量">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("Number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="单价">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Resource.Price") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="供应商名称">
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Resource.Provider.PName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" HeaderText="删除" />
                                    </Columns>
                                    <HeaderStyle CssClass="TableHeader" ForeColor="Black" Height="32px" />
                                </asp:GridView>
                                <uc1:Pager ID="ucPager" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="提   交" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="取   消" OnClick="btnReset_Click"
                                    CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
