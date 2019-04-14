<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="SelMeetingRome.aspx.cs" Inherits="MeetingManager_SelMeetingRome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会议室信息</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>

    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
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
    <style type="text/css">
        body
        {
            font-size: 12px;
        }
        .style4
        {
            width: 100%; 
            background-color:#C6DAF3;
            height: 461px;
        }
        </style>
</head>
<body class="bodycolor" style="text-align: left">
    <form id="Form1" runat="server" method="post" name="form1">
    <div class="style4">
    <table class="title1">
        <tr>
            <td style="width: 903px">
                <h3>
                    <img height="16" src="../images/right.gif" />
                    会议室信息</h3>
            </td>
            <td style="width: 905px; text-align: right; padding-right:30px">
              <a href="AddMeetingRome.aspx"> 添加会议室</a>
            </td>
        </tr>
    </table>
    <br />
    <fieldset style="border: 1px solid #CCCCCC; text-align: center; padding-left: 25px;
        width: 90%">
            会议室名称：<asp:TextBox ID="txtRoomName" size="34" runat="server" style="border-right: #99ccff 1px solid;
                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                &nbsp;<asp:Button ID="btnSearchRoom" runat="server" CssClass="BigButton" 
                Text="查询" onclick="btnSearchRoom_Click" />
            <br />
        
            <br />
    </fieldset>
    <table class="title1">
        <tr>
            <td style="height: 10px">
                <span class="big3">
                    &nbsp;查询结果</span>
            </td>
        </tr> 
    </table>
            <br />
            <asp:GridView ID="gvRoomInfo" runat="server" DataSourceID="odsAllRoomInfo" 
                Width="720px" AutoGenerateColumns="False" 
                 style="margin-top: 0px"  
                onrowcommand="gvRoomInfo_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="RID" SortExpression="RID">
                        
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("RID") %>'></asp:Label>
                            <asp:CheckBox ID="cbSel" runat="server" />
                        </ItemTemplate>
                        <HeaderTemplate>
                        全选<input type="checkbox" id="cbAll" onclick="selAll(this)"/>
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="RoomName" HeaderText="会议室名称" 
                        SortExpression="RoomName" />
                    <asp:BoundField DataField="ContainNum" HeaderText="容纳人数" 
                        SortExpression="ContainNum" />
                    <asp:BoundField DataField="Equip" HeaderText="室内配备" SortExpression="Equip" />
                    <asp:BoundField DataField="RomeAddr" HeaderText="地点" 
                        SortExpression="RomeAddr" />
                    <asp:TemplateField HeaderText="修改">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Up" CommandArgument='<%# Eval("RID") %>'>修改</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                            <asp:LinkButton ID="lbDel" runat="server" CommandName="Del" CommandArgument='<%# Eval("RID") %>' OnClientClick="return confirm('确定要删除吗？')">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="TableHeader" BackColor="#3366CC" />
            </asp:GridView>
            
            <asp:ObjectDataSource ID="odsAllRoomInfo" runat="server" 
                SelectMethod="GetAllRoomInfo" TypeName="BLL.Meeting.RoomInfoManager">
                <SelectParameters>
                    <asp:Parameter DefaultValue=" " Name="roomName" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
    <table>
    <tr>
        <td>
            共有<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            记录&nbsp;&nbsp; |&nbsp;&nbsp; 共有<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
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
    </div>
    </form>
</body>
</html>
