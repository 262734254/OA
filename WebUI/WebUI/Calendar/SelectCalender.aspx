<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="SelectCalender.aspx.cs" Inherits="SelectCalender" %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看日程</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="../css/6/style.css" />
    <style type="text/css">
         .style4
        {
            width: 100%; background-color:#C6DAF3;
            height: 511px;
        }
        .style5
        {
            height: 80px;
        }
        </style>
        
           


</head>
<body>
    
  <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
    <div class="style4">
        <table align="left" width="750px;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2" class="title1"><h3>我的日程</h3></td>
            </tr>
             <tr>
                <td colspan="2" style="text-align:right">
                <a href="AddCalender.aspx">新增日程</a></td>
            </tr>
            <tr>
                <td colspan="2" class="style5">
                    
                    <fieldset style="text-align:center; border-color:#CCCCCC; height: 40px;">
                        <br />日程主题:   
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnSeach" runat="server" Text="查  询" onclick="btnSeach_Click" 
                            CssClass="TableLine1" />
                        &nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">今日</asp:ListItem>
                            <asp:ListItem Value="2">本周</asp:ListItem>
                            <asp:ListItem Value="3">本月</asp:ListItem>
                        </asp:RadioButtonList>
                        &nbsp;</fieldset>
                    
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="textbox_show" 
                        onclick="btnDelete_Click" Text="删  除" />
                    <asp:GridView ID="gvCalendar" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" class="TableContent" DataSourceID="objCalendar" 
                        ForeColor="#333333" GridLines="None" 
                        style="margin-bottom: 0px; margin-left: 0px;" Width="770px" 
                        onrowcommand="gvCalendar_RowCommand" 
                        onrowdatabound="gvCalendar_RowDataBound"   
                        HeaderStyle-CssClass="TableHeader" >
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" CssClass="TableContent" />
                        <EmptyDataRowStyle CssClass="TableContent" />
                        <Columns >
                            <asp:BoundField DataField="Id" HeaderText="日程ID" SortExpression="Id" 
                                Visible="False"  />
                            <asp:TemplateField HeaderText="全选">
                                <HeaderTemplate>
                                    <input ID="Checkbox2" type="checkbox" onclick="selAll(this)" />全选
                                </HeaderTemplate>
                                <ItemTemplate>
                                    &nbsp;<asp:CheckBox ID="chkOne" runat="server" />
                                    <asp:HiddenField ID="hfOne" runat="server" Value='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="日程主题" SortExpression="CalTheme">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CalTheme") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CalTheme") %>'></asp:Label>
                                    <asp:HiddenField ID="hfCalendar" runat="server" 
                                        Value='<%# Eval("CalTheme") %>' />
                                    <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CalContent" HeaderText="日程内容" 
                                SortExpression="CalContent" Visible="False" />
                            <asp:BoundField DataField="TransactTime" HeaderText="执行时间" 
                                SortExpression="TransactTime" />
                            <asp:TemplateField HeaderText="提醒时间" SortExpression="TransactTime">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("RemaindTime") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTime" runat="server" Text='<%# Eval("RemaindTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CalType" HeaderText="日程类型" 
                                SortExpression="CalType" />
                            <asp:TemplateField HeaderText="是否重复" SortExpression="Repeat">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Repeat") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="yes" runat="server" Text='<%# Eval("Repeat") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="详情">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDetail" runat="server" 
                                        CommandArgument='<%# Eval("Id") %>' CommandName="De">详情</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="修改">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("Id") %>' 
                                        CommandName="Xiu">修改</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" 
                            CssClass="TableContent" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                            CssClass="TableHeader" />
                        <EditRowStyle BackColor="#2461BF" CssClass="TableContent" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="objCalendar" runat="server" 
                        SelectMethod="SelectLeaveWord" TypeName="BLL.WorkHelper.CalendarManager">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtTitle" Name="calTheme" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="RadioButtonList1" Name="remaindTime" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick"  />
                        </Triggers>
                    </asp:UpdatePanel>
                    
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" 
    ontick="Timer1_Tick">
                            </asp:Timer>
                    <uc1:Pager ID="Pager1" runat="server" />
                    
                </td>
            </tr>
        </table>
    </div>
     <div>
     
      
    
    </div>
    </form>
</body>
</html>
