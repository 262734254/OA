<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelMeeting.aspx.cs" Inherits="Meeting_MeetingList" %>

<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<html>
<head>
    <title>��Ҫ��ѯ</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>

    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            font-size: 12px;
        }
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
        }
        .style5
        {
            width: 535px;
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
<body class="bodycolor" style="text-align: left; font-size:12px;">
    <form runat="server" method="post" name="form1">
    <div class="style4">
        <table " width="750px;" class="style4">
            <tr>
                <td class="style5">
                    <h3>
                        �����Ҫ��ѯ</h3>
                </td>
                <td style="text-align: right">
                    <a href="AddMeeting.aspx">���������Ҫ</a>
                </td>
            </tr>
        </table>
        <fieldset style="border: 1px solid #CCCCCC; text-align: center; width: 750px;">
            <br />
            �������ƣ�<input type="text" id="txtRoomName" name="meetingName" style="border: 1px solid #99ccff; width: 113px;"
                size="34"  runat="server" />&nbsp;&nbsp;&nbsp;��ʼʱ�䣺��<input type="text" 
                    name="beginTime" style="border: 1px solid #99ccff; width: 136px;" size="34" id="txtBeginTime"
                    onclick="showcalendar(event, this);" runat="server" />&nbsp;&nbsp;��&nbsp;
            <input type="text" name="endTime" style="border: 1px solid #99ccff; width: 146px;"
                size="34" id="txtEndTime" onclick="showcalendar(event, this);" runat="server" />&nbsp;&nbsp;<asp:CompareValidator 
                ID="cvEndtime" runat="server" ErrorMessage="����ʱ��Ӧ�ô��ڿ�ʼʱ��" 
                ControlToCompare="txtBeginTime" ControlToValidate="txtEndTime" 
                Operator="GreaterThan"></asp:CompareValidator>
            &nbsp;
           
            <asp:TextBox ID="btnSearch" CssClass="BigButton" runat="server" Height="20px" 
                ontextchanged="btnSearch_TextChanged" Width="36px"> ��ѯ</asp:TextBox>
        </fieldset>
        <table class="title1" width="750px;">
            <tr>
                <td style="height: 10px">
                    <span class="big3">&nbsp;��ѯ���</span>
                </td>
            </tr>
        </table>
       
            &nbsp;&nbsp;&nbsp;<input id="btnDelAll" type="button" value="ɾ��" runat="server" class="BigButton" /><br />
                <asp:GridView ID="gvMeetingSummary" HeaderStyle-CssClass="TableHeader"  
            runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsMeetingSummary" Width="748px" 
            onrowcommand="gvMeetingSummary_RowCommand" Font-Size="12pt">
                    
                    <Columns>
                        <asp:TemplateField HeaderText="MSID" SortExpression="MSID">
                            <HeaderTemplate>
                                ȫѡ<input type="checkbox" onclick="selAll(this)" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("MSID") %>'/>
                                <asp:CheckBox ID="cbAllCb" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MeetingTitle" HeaderText="��������" 
                            SortExpression="MeetingTitle" />
                        <asp:BoundField DataField="MeetingContent" HeaderText="��������" 
                            SortExpression="MeetingContent" />
                        <asp:BoundField DataField="Compere" HeaderText="������" SortExpression="Compere" />
                        <asp:BoundField DataField="BeginTime" HeaderText="��ʼʱ��" 
                            SortExpression="BeginTime" />
                        <asp:BoundField DataField="EndTime" HeaderText="����ʱ��" 
                            SortExpression="EndTime" />
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDetail" runat="server" CommandArgument='<%# Eval("MSID") %>' CommandName="Det">����</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�޸�">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbUp" CommandArgument='<%# Eval("MSID") %>' CommandName="Up" runat="server">�޸�</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" runat="server" CommandArgument='<%# Eval("MSID") %>' CommandName="Del">ɾ��</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                   
<HeaderStyle CssClass="TableHeader"></HeaderStyle>
                   
        </asp:GridView>
        <asp:ObjectDataSource ID="odsMeetingSummary" runat="server" 
            SelectMethod="SearchMeetingSummary" 
            TypeName="BLL.Meeting.MeetingSummaryManager">
            <SelectParameters>
                <asp:Parameter DefaultValue=" " Name="roomName" Type="String" />
                <asp:Parameter DefaultValue=" " Name="beginTime" Type="String" />
                <asp:Parameter DefaultValue=" " Name="endTime" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
                ����<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                ��¼&nbsp;&nbsp; |&nbsp;&nbsp; ����<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                ҳ&nbsp; |&nbsp;&nbsp;
                <asp:LinkButton ID="lnkfirst" runat="server">��ҳ</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkprev" runat="server">��һҳ</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnknext" runat="server">��һҳ</asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton ID="lnklast" runat="server">βҳ</asp:LinkButton>
            </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
