<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectCalender.aspx.cs" Inherits="SelectCalender" %>

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
        </style>
     <script type="text/javascript">
        function selAll(obj)
        {
            var items=document.getElementsByTagName("input");
            for(var i=0;i<items.length;i++)
            {
                if(items[i]!=null&&items[i].type=="checkbox")
                {
                    items[i].checked=obj.checked;
                }
            }
        }
    </script>

</head>
<body>
    
  <form id="form1" runat="server">
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
                <td colspan="2">
                    
                    <fieldset style="text-align:center; border-color:#CCCCCC">
                        <br />日程主题    <input type="text" name="meetingName" 
                    style="border: 1px solid #99ccff; width: 137px;" size="34" id="Text1" 
                    runat="server" /><br /><br />
                        <input type="radio" />今日&nbsp;&nbsp;&nbsp;&nbsp;<input type="radio" />本周&nbsp;&nbsp;&nbsp;&nbsp;<input type="radio" />本月
                    &nbsp;&nbsp;<input id="btnExit" type="button" value="查询" class="BigButton" /></fieldset>
                    
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;<input type="button" value="删  除" class="BigButton" onclick="return confirm('确定要删除？')"/>
                    <asp:GridView ID="gvCalendar" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" class="TableContent" DataSourceID="objCalendar" 
                        ForeColor="Black" GridLines="Vertical" style="margin-bottom: 0px" Width="746px">
                        <FooterStyle BackColor="#CCCC99" />
                        <RowStyle BackColor="#F7F7DE" />
                        <Columns>
                            <asp:TemplateField HeaderText="全选">
                                <HeaderTemplate>
                                    <input ID="Checkbox2" type="checkbox" onclick="selAll(this)" />全选
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input ID="Checkbox1" type="checkbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="日程ID" SortExpression="Id" 
                                Visible="False" />
                            <asp:BoundField DataField="CalTheme" HeaderText="日程主题" 
                                SortExpression="CalTheme" />
                            <asp:BoundField DataField="CalContent" HeaderText="日程内容" 
                                SortExpression="CalContent" Visible="False" />
                            <asp:BoundField DataField="RemaindTime" HeaderText="执行时间" 
                                SortExpression="RemaindTime" />
                            <asp:BoundField DataField="TransactTime" HeaderText="提醒时间" 
                                SortExpression="TransactTime" Visible="False" />
                            <asp:BoundField DataField="CalType" HeaderText="日程类型" 
                                SortExpression="CalType" />
                            <asp:BoundField DataField="Repeat" HeaderText="是否重复" 
                                SortExpression="Repeat" />
                            <asp:TemplateField HeaderText="详情"></asp:TemplateField>
                            <asp:TemplateField HeaderText="修改"></asp:TemplateField>
                        </Columns>
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="objCalendar" runat="server" 
                        SelectMethod="GetAllCalendar" TypeName="BLL.WorkHelper.CalendarManager">
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
