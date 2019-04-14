<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cheerlist.aspx.cs" Inherits="CarManager_Cheerlist" %>

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
            width:100%; background-color:#C6DAF3;
             height:450px;
        }
        .style1
        {
            width: 750px;
            height:300px;
           
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
                        onclick="showcalendar(event, this);" type="text" />至<input 
                        id="txtEndtime" runat="server" class="inputs" 
                        onclick="showcalendar(event, this);" type="text" />&nbsp;&nbsp;&nbsp;车辆类型：<asp:DropDownList 
                        ID="ddlCharType" runat="server" class="inputs">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>普通用车</asp:ListItem>
                        <asp:ListItem>接待用车</asp:ListItem>
                        <asp:ListItem>大型活动用车</asp:ListItem>
                        <asp:ListItem>其它用车</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;加油站：&nbsp;<asp:DropDownList ID="ddlCheerStation" runat="server" Height="16px" 
                        Width="93px" DataSourceID="objStation" DataTextField="C_Station" 
                        DataValueField="C_Station" AppendDataBoundItems="True">
                     <asp:ListItem Value="全部" Selected="True">全部</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" class="BigButton" Text="查   询" 
                        onclick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp; <a href="Cheer.aspx">添加记录</a>
                </td>
            </tr>
            <tr>
                <td class="style3">
                                <asp:Button ID="btnDel"  runat="server" class="BigButton" Text=" 删 除 "  
                        onclientclick="return confirm(&quot;确定要删除么？&quot;)" Width="50px" 
                                    onclick="btnDel_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>

                     <asp:GridView ID="gvCheer" runat="server" AutoGenerateColumns="False" 
                         DataKeyNames="C_Id" Height="140px" Width="745px">
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
                                     <asp:LinkButton ID="lbtnSel" runat="server" CommandArgument='<%# Eval("C_Id") %>' 
                                         CommandName='Sel' oncommand="lbtnSel_Command">查 询</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="修改">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lbtnUp" runat="server" CommandArgument='<%# Eval("C_Id") %>' 
                                         CommandName='Up' oncommand="lbtnUp_Command">修 改</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
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
    
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
