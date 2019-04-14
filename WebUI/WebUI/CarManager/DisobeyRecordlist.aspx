<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisobeyRecordlist.aspx.cs" Inherits="CarManager_DisobeyRecordlist" validateRequest="false" %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

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
        }
        .style1
        {
            width:921px;
           
        }
     
        .style3
        {
            width: 835px;
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
                        onclick="showcalendar(event, this);" type="text" /><asp:RegularExpressionValidator 
                                    ID="revStatime" runat="server" ControlToValidate="txtStatime" ErrorMessage="*" 
                                    
                        
                                    ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                至<input 
                        id="txtEndtime" runat="server" class="inputs" 
                        onclick="showcalendar(event, this);" type="text" /><asp:RegularExpressionValidator 
                                    ID="revEndtime" runat="server" ControlToValidate="txtEndtime" ErrorMessage="*" 
                                    
                        
                                    ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                                用车类型：<asp:DropDownList 
                        ID="ddlCharType" runat="server" class="inputs">
                        <asp:ListItem>全部</asp:ListItem>
                        <asp:ListItem>普通用车</asp:ListItem>
                        <asp:ListItem>接待用车</asp:ListItem>
                        <asp:ListItem>大型活动用车</asp:ListItem>
                        <asp:ListItem>其它用车</asp:ListItem>
                    </asp:DropDownList>
              
                                &nbsp;违章事故车牌号：<asp:DropDownList ID="ddlCarMark" runat="server" AppendDataBoundItems="True" DataSourceID="objCarMark" 
                                    DataTextField="CarMark" DataValueField="CarMark">
                           <asp:ListItem>全部</asp:ListItem>
                    </asp:DropDownList>
               
                       &nbsp;<asp:Button ID="btnSave" class="BigButton" runat="server" Text="查   询" 
                                    onclick="btnSave_Click" ToolTip="查询" />
                                &nbsp;<asp:LinkButton ID="lbSave" runat="server" ToolTip="添加" 
                                    PostBackUrl="~/CarManager/DisobeyRecord.aspx">添加记录</asp:LinkButton>
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;" class="style3">
                                <asp:Button ID="btnDel"  runat="server" class="BigButton" Text=" 删 除 " 
                        onclientclick="return confirm(&quot;确定要删除么？&quot;)" Width="50px" 
                                    onclick="btnDel_Click" ToolTip="删除" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                <table class="style1" cellpadding="0" cellspacing="0">
                                           <tr>
                <td class="style4">
                   
                     <asp:GridView ID="dvDisobeyRecord" runat="server" AutoGenerateColumns="False" 
                         DataKeyNames="DR_Id" Width="745px" 
                         style="margin-right:0px">
                         <RowStyle CssClass="TableContent" />
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
                                     <asp:LinkButton ID="lbDetail" runat="server" CommandArgument='<%# Eval("DR_Id") %>' 
                                         CommandName='Sel' oncommand="lbtnSel_Command">查 询</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="修改">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="lbUp" runat="server" CommandArgument='<%# Eval("DR_Id") %>' 
                                         CommandName='Up' oncommand="lbtnUp_Command">修 改</asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                         <HeaderStyle CssClass="TableHeader" ForeColor="Black" Height="32px" />
                     </asp:GridView>
                  
                    <br />
                   
                </td>
            </tr>
            <tr>
           <td class="style5">
                    <uc1:Pager ID="Pager1" runat="server" />
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