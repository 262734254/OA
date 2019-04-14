<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="CalendarAdd.aspx.cs" Inherits="N_Calendar_CalendarAdd" %>

    <asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header"> </asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="Default.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        日程提示</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="CalendarAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新建日程</div>
                </a>
            </td>            
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="1" width="100%" bordercolorlight="#c1c1c1"
        bordercolordark="#FFFFFF">
        <tr bgcolor="#f6f6f6">
            <td class="style1" align="right">
                标题：
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                待办时间：
            </td>
            <td valign="middle">

                <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>

                <input type="text" class="Wdate" id="text1" onfocus="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd HH:mm:ss',alwaysUseStartDate:true})"
                    runat="server" />
        </tr>
        <tr bgcolor="#f6f6f6">
            <td class="style1" align="right">
                是否提醒：
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="0">不提醒</asp:ListItem>
                    <asp:ListItem Value="5">到点提醒</asp:ListItem>
                    <asp:ListItem Value="1">10分钟之前</asp:ListItem>
                    <asp:ListItem Value="2">半个小时之前</asp:ListItem>
                    <asp:ListItem Value="3">1个小时之前</asp:ListItem>
                    <asp:ListItem Value="4">全天</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1" align="right">
                内容：
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="111px" TextMode="MultiLine" Width="309px"></asp:TextBox>
            </td>
        </tr>
        <tr class="di">
            <td class="style1">
                &nbsp;
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="保存" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
