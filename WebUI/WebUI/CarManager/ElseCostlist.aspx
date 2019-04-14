<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ElseCostlist.aspx.cs" Inherits="CarManager_ElseCostlist"  validateRequest="false" %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>其他费用记录详细</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
    <link rel="Stylesheet" type="text/css" href="../js/calendar.js" />
          <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
    <style type="text/css">
        .style2 
        {
        	width:100%;background-color:#C6DAF3;
           
        }
               
        .style3
        {
           
            width:872px;
            height: 13px;
        }
       
        .style4
        {
            border-style:none;
            border-color:inherit;
            border-width:0px;
            text-align:center;
            background-image:url('../css/6/images/tablehdbg1.gif');          /* 表格背景图 */
            font-size:9pt; /* 字体大小             */ font-weight: bold;    /*            字体粗               */
            width:872px;                                               /* 表格宽度             */
           
            /* 表格边框宽度         */    COLOR: #264A7E;
            background-repeat:repeat-x;                              /* 表格背景颜色         */
        }
        .style5
        {
          
            width:872px;
        }
        .style6
        {
            width:872px;
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
    <div style="text-align: center">
                 <table class="style2">
                 <tr>  <td class="style4" align="center">
                   <h3>其他费用管理</h3></td></tr>
                   <tr><td valign="top" class="style5">
                费用日期：<input id="txtStatime" runat="server" class="inputs" 
                        onclick="showcalendar(event, this);" type="text" /><asp:RegularExpressionValidator 
                                    ID="revStatime" runat="server" ControlToValidate="txtStatime" ErrorMessage="*" 
                                    
                        
                           ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                                &nbsp;至<input 
                        id="txtEndtime" runat="server" class="inputs" 
                        onclick="showcalendar(event, this);" type="text" /> <asp:RegularExpressionValidator 
                                    ID="revEndtime" runat="server" ControlToValidate="txtEndtime" ErrorMessage="*" 
                                    
                        
                           ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                &nbsp;&nbsp;用车类型：<asp:DropDownList 
                        ID="ddlCharType" runat="server" class="inputs">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>普通用车</asp:ListItem>
                        <asp:ListItem>接待用车</asp:ListItem>
                        <asp:ListItem>大型活动用车</asp:ListItem>
                        <asp:ListItem>其它用车</asp:ListItem>
                    </asp:DropDownList>
              
                &nbsp;&nbsp;&nbsp;费用车牌号：<asp:DropDownList ID="ddlCarMark" runat="server" 
                        AppendDataBoundItems="True" DataSourceID="objCarMark" 
                           DataTextField="CarMark" DataValueField="CarMark">
                           <asp:ListItem>全部</asp:ListItem>
                    </asp:DropDownList>
               
                       &nbsp;<asp:Button ID="btnSel" class="BigButton" runat="server" Text="查   询" 
                           onclick="btnSel_Click" ToolTip="查询" 
                            />
                 &nbsp;<asp:LinkButton ID="lbSave" runat="server" 
                           PostBackUrl="~/CarManager/elseCost.aspx" ToolTip="添加">添加记录</asp:LinkButton>
                             </td></tr>
                   <tr><td valign="top" class="style3">
                                <asp:Button ID="btnDel"  runat="server"  class="BigButton" Text=" 删 除 "  
                        onclientclick="return confirm(&quot;确定要删除么？&quot;)" Width="50px" 
                                    onclick="btnDel_Click" ToolTip="删除" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
                                    ID="lblMessage" runat="server" Visible="False"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       </td></tr>
            <tr><td align="center" valign="top" class="style6">               
        <table>
            <tr>
                <td>
                   
                     <asp:GridView ID="dvCostSupervise" runat="server" AutoGenerateColumns="False" 
                         DataKeyNames="CS_Id" Width="745px" 
                         onselectedindexchanged="dvCostSupervise_SelectedIndexChanged">
                         <RowStyle CssClass="TableContent" />
                         <Columns>
                             <asp:TemplateField HeaderText="全选">
                                 <HeaderTemplate>
&nbsp;<input ID="Checkbox11" type="checkbox" onclick="selAll(this)"  / >全选
                                 </HeaderTemplate>
                                 <ItemTemplate>
                                     &nbsp;<asp:CheckBox ID="input" runat="server" 
                                          />
                                     <asp:HiddenField ID="lblCS_Id" runat="server" Value='<%# Eval("CS_Id") %>' />
                                    
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="CarMark" HeaderText="车牌号码" 
                                 SortExpression="CarMark" />
                             <asp:BoundField DataField="CS_CarType" HeaderText="车辆类型" 
                                 SortExpression="C_CheerType" />
                             <asp:BoundField DataField="CS_Cost" HeaderText="费用金额" SortExpression="CS_Cost" />
                             <asp:TemplateField HeaderText="查询">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lbDetail" runat="server" CommandArgument='<%# Eval("CS_Id") %>' 
                                         CommandName='Sel' oncommand="lbtnSel_Command">查 询</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="修改">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lbUp" runat="server" CommandArgument='<%# Eval("CS_Id") %>' 
                                         CommandName='Up' oncommand="lbtnUp_Command">修 改</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                         <HeaderStyle CssClass="TableHeader" ForeColor="Black" Height="32px" />
                     </asp:GridView>
                  
                     <asp:ObjectDataSource ID="objCostSupervise" runat="server" 
                        SelectMethod="getAllCostSupervise" TypeName="BLL.Car.CostSuperviseManager">
                         <SelectParameters>
                             <asp:Parameter Name="statime" Type="String" />
                             <asp:Parameter Name="endtime" Type="String" />
                             <asp:Parameter Name="cs_CarType" Type="String" />
                             <asp:Parameter Name="carMark" Type="String" />
                         </SelectParameters>
                    </asp:ObjectDataSource>
                     <asp:ObjectDataSource ID="objCarMark" runat="server" 
                         SelectMethod="getCostSupervise" TypeName="BLL.Car.CostSuperviseManager">
                     </asp:ObjectDataSource>
                    <br />
                   
                </td>
            </tr>
            <tr>
           <td class="style5">
                    &nbsp;<uc1:Pager ID="Pager1" runat="server" /></td>
            </tr>
        </table>
        </td></tr></table>
    </div>
    </form>
</body>
</html>

