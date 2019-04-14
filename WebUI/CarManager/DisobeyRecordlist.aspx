<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisobeyRecordlist.aspx.cs"
    Inherits="CarManager_DisobeyRecordlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>违章事故记录查询页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
     <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
    <style type="text/css">
        .style2
        {
            width:100%;
            background-color:#C6DAF3;
            height:450px;
        }
        .style1
        {
            width:800px;
            height:300px;
        }
        .style3
        {
            height:71px;
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
                <td class="title1" align="center">
                    <h3>
                        违章事故记录</h3>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <table class="style1">
                        <tr>
                            <td class="style3">
                                事故日期：<input id="txtStatime" runat="server" class="inputs" 
                        onclick="showcalendar(event, this);" type="text" />
                至<input 
                        id="txtEndtime" runat="server" class="inputs" 
                        onclick="showcalendar(event, this);" type="text" />
                &nbsp;用车类型：<asp:DropDownList 
                        ID="ddlCharType" runat="server" class="inputs">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>普通用车</asp:ListItem>
                        <asp:ListItem>接待用车</asp:ListItem>
                        <asp:ListItem>大型活动用车</asp:ListItem>
                        <asp:ListItem>其它用车</asp:ListItem>
                    </asp:DropDownList>
              
                &nbsp;&nbsp;违章事故车牌号：<asp:DropDownList ID="ddlCarMark" runat="server" Height="16px" 
                        Width="124px" AppendDataBoundItems="True" DataSourceID="objCarMark" 
                                    DataTextField="CarMark" DataValueField="CarMark">
                           <asp:ListItem>全部</asp:ListItem>
                    </asp:DropDownList>
               
                       &nbsp;
                                <asp:Button ID="btnSave" class="BigButton" runat="server" Text="查   询" 
                                    onclick="btnSave_Click" />
                                &nbsp;&nbsp;&nbsp;<a href="DisobeyRecord.aspx">添加记录</a>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <asp:Button ID="btnDel"  runat="server" class="BigButton" Text=" 删 除 " Height="21px" 
                        onclientclick="return confirm(&quot;确定要删除么？&quot;)" Width="50px" 
                                    onclick="btnDel_Click" />
                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table class="style1" cellpadding="0" cellspacing="0">
                                           <tr>
                <td class="style4">
                   
                     <asp:GridView ID="dvDisobeyRecord" runat="server" AutoGenerateColumns="False" 
                         DataKeyNames="DR_Id" Height="140px" Width="745px" 
                         style="margin-right: 0px">
                         <Columns>
                             <asp:TemplateField HeaderText="全选">
                                 <HeaderTemplate>
&nbsp;<input ID="Checkbox11" type="checkbox" onclick="selAll(this)"  / >全选
                                 </HeaderTemplate>
                                 <ItemTemplate>
                                     &nbsp;<asp:CheckBox ID="input" runat="server" 
                                          />
                                     <asp:HiddenField ID="lblDR_Id" runat="server" Value='<%# Eval("DR_Id") %>' />
                                    
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="CarMark" HeaderText="车牌号码" 
                                 SortExpression="CarMark" />
                             <asp:BoundField DataField="Dr_CarType" HeaderText="车辆类型" 
                                 SortExpression="C_CheerType" />
                             <asp:BoundField DataField="FactCost" HeaderText="费用金额" 
                                 SortExpression="CS_Cost" />
                             <asp:TemplateField HeaderText="查询">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lbtnSel" runat="server" CommandArgument='<%# Eval("DR_Id") %>' 
                                         CommandName='Sel' oncommand="lbtnSel_Command">查 询</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="修改">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lbtnUp" runat="server" CommandArgument='<%# Eval("DR_Id") %>' 
                                         CommandName='Up' oncommand="lbtnUp_Command">修 改</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                  
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
                    <br />
                  
                     <asp:ObjectDataSource ID="objDisobeyRecord" runat="server" 
                        SelectMethod="getAllDisobeyRecord" TypeName="BLL.Car.DisobeyRecordManager">
                         <SelectParameters>
                             <asp:Parameter Name="statime" Type="String" />
                             <asp:Parameter Name="endtime" Type="String" />
                             <asp:Parameter Name="dr_CarType" Type="String" />
                             <asp:Parameter Name="carMark" Type="String" />
                         </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="objCarMark" runat="server" 
                        SelectMethod="getDisobeyRecordByMark" 
                        TypeName="BLL.Car.DisobeyRecordManager">
                    </asp:ObjectDataSource>
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