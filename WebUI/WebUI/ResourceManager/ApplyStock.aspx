<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyStock.aspx.cs" Inherits="StockApply" %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>采购申请页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            background-color: #C6DAF3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="background-color: #C6DAF3">
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        采购申请</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="500px">
                        <tr align="left">
                            <td>
                                申 请 人 ：<asp:TextBox ID="txtUser" class="inputs" runat="server" Width="120" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtUser"
                                    ErrorMessage="资源名称不能为空">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                采购时间：<input id="txtSATime" name="txtSATime" type="text" value="" style="border: 1px solid #99ccff;
                                    width: 120px; height: 17px;" runat="server" onclick="showcalendar(event, this);" readonly="readonly"/>
                                <asp:RequiredFieldValidator ID="rfvSATime" runat="server" ErrorMessage="采购时间不能为空" ControlToValidate="txtSATime">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                所需费用：<asp:TextBox ID="txtNeedCharge" runat="server" class="inputs" Width="120"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtNeedCharge"
                                    ErrorMessage="所需费用不能为空">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                采购原因：<asp:TextBox ID="txtSACause" runat="server" class="inputs" Height="90px" TextMode="MultiLine"
                                    Width="333px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSACause" runat="server" ControlToValidate="txtSACause"
                                    ErrorMessage="采购原因不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtMark" class="inputs" runat="server"
                                    Height="90px" TextMode="MultiLine" Width="333px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRemark" runat="server" ControlToValidate="txtMark"
                                    ErrorMessage="备注不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="left">
                                采购资源
                            </th>
                            <th align="right">
                                <asp:Button ID="btnAdd" runat="server" class="BigButton" Text="添加资源" 
                                    OnClick="btnAdd_Click" CausesValidation="False" />
                            </th>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <asp:GridView ID="gvSelectedResouce" runat="server" AutoGenerateColumns="False" Width="100%"
                                    PageSize="5" OnRowDeleting="gvSelectedResource_RowDeleting">
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
                                        <asp:TemplateField HeaderText="采购数量">
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
                                    <HeaderStyle CssClass="TableHeader" ForeColor="Black" Height="32px"/>
                                </asp:GridView>
                                <uc1:Pager ID="ucPager" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="确   定" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="返   回" OnClick="btnReset_Click"
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
