<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplictionMeetingList.aspx.cs"
    Inherits="MeetingManager_ApplictionMeetingList" %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会议申请列表</title>
    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <link href="../css/public.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>

    <style type="text/css">
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
        }
        .style6
        {
            width: 645px;
        }
        .style7
        {
            width: 906px;
            height: 21px;
        }
        .style8
        {
            height: 21px;
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
    <form id="Form2" runat="server" method="post" name="form1">
    <div class="style4">
        <table class="title1">
            <tr>
                <td class="style6">
                    <span class="title1"><h3>
                        会议列表</h3>
                    </span>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
        <fieldset style="border: 1px solid #CCCCCC; text-align: center;">
            会议名称：<input name="txtRoomName" id="txtRoomName" runat="server" type="text">&nbsp;主办部门：<asp:DropDownList 
                ID="ddlDepartment" class="inputs" runat="server" AppendDataBoundItems="True" 
                DataSourceID="odsAllDepartment" DataTextField="Departmentname" 
                DataValueField="Id">
                <asp:ListItem Value="0">请选择</asp:ListItem>
            </asp:DropDownList>
           
            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="查询" 
                CssClass="BigButton" onclick="btnSearch_Click" />
        </fieldset>
        <br />
        <br />
        <table width="100%" valign="top" style="height: 400px">
            <tr>
                <td class="style7" align="right">
                    &nbsp;
                    <asp:Button ID="btnAdd" runat="server" CssClass="BigButton"  Text="召开会议" 
                        onclick="btnAdd_Click" ToolTip="添加" />
                <td class="style8">
                    </td>
            </tr>
            <tr style="padding-top:10px;">
                <td colspan="2" align="center" valign="top" >
            <asp:GridView ID="gvRoomInfo" runat="server" DataSourceID="odsApplication" 
                Width="720px" AutoGenerateColumns="False" 
                 style="margin-top: 0px" onrowcommand="gvRoomInfo_RowCommand" onrowdatabound="gvRoomInfo_RowDataBound" 
                        >
                <Columns>
                    <asp:TemplateField HeaderText="MID" SortExpression="MID">
                        <HeaderTemplate>
                            <input ID="cbAllCheck" type="checkbox"  onclick="selAll(this)"/>全选
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HiddenField ID="hfMID" runat="server" Value='<%# Bind("MID") %>'/>
                         
                            <asp:CheckBox ID="cbSel" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MeetTitle" HeaderText="会议名称" 
                        SortExpression="MeetTitle" />
                    <asp:TemplateField HeaderText="会议室">
                        <ItemTemplate>
                            <asp:Label ID="lblRoomInfo" runat="server" Text='<%# Eval("RoomInfo.RoomName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MeetType" HeaderText="会议类型" 
                        SortExpression="MeetType" />
                    <asp:TemplateField HeaderText="主办部门">
                        <ItemTemplate>
                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("DepartmentID.Departmentname")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="BeginTime" HeaderText="开始时间" 
                        SortExpression="BeginTime" />
                    <asp:BoundField DataField="EndTime" HeaderText="结束时间" 
                        SortExpression="EndTime" />
                    <asp:TemplateField HeaderText="状态" SortExpression="State">
                        <ItemTemplate>
                            <asp:Label ID="lblState" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="详细">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDetail" CommandName="Del"  CommandArgument='<%# Eval("MID") %>' runat="server">详情</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="修改">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbUp" runat="server" ToolTip="修改" CommandName="Up"  CommandArgument='<%# Eval("MID") %>' >修改</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDel" ToolTip="删除" CommandName="De" OnClientClick="return confirm('确认要删除吗？')" CommandArgument='<%# Eval("MID") %>' runat="server">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="通知">
                        <ItemTemplate>
                            <asp:LinkButton ID="hlSendWord" CommandName="Send" CommandArgument='<%# Eval("MID") %>' runat="server">发布通知</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
                <HeaderStyle CssClass="TableHeader" BackColor="#3366CC" />
            </asp:GridView>
            
                    <asp:ObjectDataSource ID="odsApplication" runat="server" 
                        SelectMethod="SearchMeetingApplication" 
                        TypeName="BLL.Meeting.MeetingApplicationManager">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="无" Name="roomName" Type="String" />
                            <asp:Parameter DefaultValue="0" Name="departmentId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
             <asp:ObjectDataSource ID="odsAllDepartment" runat="server" 
                SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
            </asp:ObjectDataSource>
                    <br />
                    <uc1:Pager ID="Pager1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
