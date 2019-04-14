<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ElseCostlist.aspx.cs" Inherits="CarManager_ElseCostlist" %>

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
            height:450px;
             }
               
        .style3
        {
            height:28px;
            width:872px;
        }
       
        .style4
        {
            border-style:none;
            border-color:inherit;
            border-width:0px;
            text-align:center;
            background-image: url('../css/6/images/tablehdbg1.gif') ;          /* 表格背景图           */
            font-size:9pt; /* 字体大小             */ /*font-weight: bold;                                          字体粗               */;
            width:872px;                                               /* 表格宽度             */
            height:30px; /* 表格高度  图＋2      */
/* 表格边框宽度         */    COLOR: #264A7E;
            background-repeat:repeat-x;                                          /* 表格背景颜色         */
        }
        .style5
        {
            height:50px;
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
                        onclick="showcalendar(event, this);" type="text" />
                至<input 
                        id="txtEndtime" runat="server" class="inputs" 
                        onclick="showcalendar(event, this);" type="text" />
                &nbsp;&nbsp;用车类型：<asp:DropDownList 
                        ID="ddlCharType" runat="server" class="inputs">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>普通用车</asp:ListItem>
                        <asp:ListItem>接待用车</asp:ListItem>
                        <asp:ListItem>大型活动用车</asp:ListItem>
                        <asp:ListItem>其它用车</asp:ListItem>
                    </asp:DropDownList>
              
                &nbsp;&nbsp;&nbsp;费用车牌号：<asp:DropDownList ID="ddlCarMark" runat="server" Height="16px" 
                        Width="124px" AppendDataBoundItems="True" DataSourceID="objCarMark" 
                           DataTextField="CarMark" DataValueField="CarMark">
                           <asp:ListItem>全部</asp:ListItem>
                    </asp:DropDownList>
               
                       &nbsp;<asp:Button ID="btnSel" class="BigButton" runat="server" Text="查   询" onclick="btnSel_Click" 
                            />
                 &nbsp;<a href="elseCost.aspx">添加记录</td></tr>
                   <tr><td valign="top" class="style3">
                                <asp:Button ID="btnDel"  runat="server"  class="BigButton" Text=" 删 除 "  
                        onclientclick="return confirm(&quot;确定要删除么？&quot;)" Width="50px" 
                                    onclick="btnDel_Click" />
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       </td></tr>
            <tr><td align="center" valign="top" class="style6">               
        <table>
            <tr>
                <td>
                   
                     <asp:GridView ID="dvCostSupervise" runat="server" AutoGenerateColumns="False" 
                         DataKeyNames="CS_Id" Height="140px" Width="745px" 
                         onselectedindexchanged="dvCostSupervise_SelectedIndexChanged">
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
                                     <asp:LinkButton ID="lbtnSel" runat="server" CommandArgument='<%# Eval("CS_Id") %>' 
                                         CommandName='Sel' oncommand="lbtnSel_Command">查 询</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="修改">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lbtnUp" runat="server" CommandArgument='<%# Eval("CS_Id") %>' 
                                         CommandName='Up' oncommand="lbtnUp_Command">修 改</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
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
                    共有<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                记录&nbsp;&nbsp; |&nbsp;&nbsp; 共有<asp:Label ID="Label2" runat="server" 
                    Text="Label"></asp:Label>
                页&nbsp; |&nbsp;&nbsp;
                <asp:LinkButton ID="lnkfirst" runat="server">首页</asp:LinkButton>
&nbsp;
                <asp:LinkButton ID="lnkprev" runat="server">上一页</asp:LinkButton>
&nbsp;
                <asp:LinkButton ID="lnknext" runat="server">下一页</asp:LinkButton>
&nbsp;&nbsp;
                <asp:LinkButton ID="lnklast" runat="server">尾页</asp:LinkButton>
                    </td>
            </tr>
        </table>
        </td></tr></table>
    </div>
    </form>
</body>
</html>

