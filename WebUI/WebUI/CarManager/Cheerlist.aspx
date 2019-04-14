<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cheerlist.aspx.cs" Inherits="CarManager_Cheerlist" validateRequest="false"  %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>加油记录查询页面</title>
   <LINK href="../css/public.css" type="text/css" rel="stylesheet"/>
      <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
      <link rel="Stylesheet" type="text/css" href="../js/calendar.js" />
           <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
    <style type="text/css">
       .style2
        {
            width:100%;background-color:#C6DAF3;
        }
        .style1
        {
            width:855px;
            
           
        }
        .style3
        {
            height: 10px;
        }
        .style4
        {
            height: 19px;
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
    <div>
    
        <table class="style2">
            <tr>
                <td class="title1">
                    <h3>加油管理</h3></td>
            </tr>
            <tr>
                <td align="center" valign="top">
    
        <table class="style1">
            <tr>
                <td class="style4">
                    加油日期：<input id="txtStatime" runat="server" class="inputs" 
                        onclick="showcalendar(event, this);" type="text" /><asp:RegularExpressionValidator 
                                    ID="revStatime" runat="server" ControlToValidate="txtStatime" ErrorMessage="*" 
                                    
                        
                        ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                                至<input 
                        id="txtEndtime" runat="server" class="inputs" 
                        onclick="showcalendar(event, this);" type="text" /><asp:RegularExpressionValidator 
                                    ID="revEndtime" runat="server" ControlToValidate="txtEndtime" ErrorMessage="*" 
                                    
                        
                        ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                                &nbsp;车辆类型：<asp:DropDownList 
                        ID="ddlCharType" runat="server" class="inputs">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>普通用车</asp:ListItem>
                        <asp:ListItem>接待用车</asp:ListItem>
                        <asp:ListItem>大型活动用车</asp:ListItem>
                        <asp:ListItem>其它用车</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;加油站：&nbsp;<asp:DropDownList ID="ddlCheerStation" runat="server"  
                        DataSourceID="objStation" DataTextField="C_Station" 
                        DataValueField="C_Station" AppendDataBoundItems="True">
                     <asp:ListItem Value="全部" Selected="True">全部</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" class="BigButton" Text="查   询" 
                        onclick="btnSave_Click" ToolTip="查询" />
                    &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lbtnSave" runat="server" ToolTip="添加" 
                        PostBackUrl="~/CarManager/Cheer.aspx">添加记录</asp:LinkButton>
&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style3" align="left">
                                <asp:Button ID="btnDel"  runat="server" class="BigButton" Text=" 删 除 "  
                        onclientclick="return confirm(&quot;确定要删除么？&quot;)" Width="50px" 
                                    onclick="btnDel_Click" ToolTip="删除" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
                                    ID="lblMessage" runat="server" Visible="False"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>

                     <asp:GridView ID="gvCheer" runat="server" AutoGenerateColumns="False" 
                         DataKeyNames="C_Id" Width="745px">
                         <RowStyle CssClass="TableContent" Height="32px" />
                         <Columns>
                             <asp:TemplateField HeaderText="全选">
                                 <HeaderTemplate>
&nbsp;<input ID="Checkbox11" type="checkbox" onclick="selAll(this)"  / >全选
                                 </HeaderTemplate>
                                 <ItemTemplate>
                                     &nbsp;<asp:CheckBox ID="input" runat="server" AutoPostBack="True" 
                                          />
                                     <asp:HiddenField ID="lblC_Id" runat="server" Value='<%# Eval("C_Id") %>' />
                                    
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="CarMark" HeaderText="车牌号码" 
                                 SortExpression="CarMark" />
                             <asp:BoundField DataField="C_CheerType" HeaderText="加油类型" 
                                 SortExpression="C_CheerType" />
                             <asp:BoundField DataField="C_Sum" HeaderText="费用金额" SortExpression="C_Sum" />
                             <asp:TemplateField HeaderText="查询">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lbDetail" runat="server" CommandArgument='<%# Eval("C_Id") %>' 
                                         CommandName='Sel' oncommand="lbtnSel_Command">查 询</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="修改">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lbUp" runat="server" CommandArgument='<%# Eval("C_Id") %>' 
                                         CommandName='Up' oncommand="lbtnUp_Command">修 改</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                         <HeaderStyle CssClass="TableHeader" ForeColor="Black" Height="32px" />
                     </asp:GridView>
                  
                     <asp:ObjectDataSource ID="objCheer" runat="server" SelectMethod="getAllCheer" 
                         TypeName="BLL.Car.CheerManager">
                         <SelectParameters>
                             <asp:Parameter Name="statime" Type="String" />
                             <asp:Parameter Name="endtime" Type="String" />
                             <asp:Parameter Name="c_CarType" Type="String" />
                             <asp:Parameter Name="c_Station" Type="String" />
                         </SelectParameters>
                     </asp:ObjectDataSource>
                     <asp:ObjectDataSource ID="objStation" runat="server" 
                         SelectMethod="getCheerStation" TypeName="BLL.Car.CheerManager">
                     </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:Pager ID="Pager1" runat="server" />
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
