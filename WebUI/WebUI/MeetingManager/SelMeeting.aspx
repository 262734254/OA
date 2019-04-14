<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelMeeting.aspx.cs" Inherits="Meeting_MeetingList" %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

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
            height: 483px;
        }
        #btnDelAll
        {
            height: 20px;
        }
        .style7
        {
            width: 646px;
        }
        .style8
        {
            width: 716px;
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
    <div class="style4" align="center">
        <table " width="750px;">
            <tr>
                <td align="center" class="style8">
                    <h3 >
                        �����Ҫ��ѯ</h3>
                </td>
                <td style="text-align: right" class="style7">
                  
                    <asp:LinkButton ID="lbAdd" runat="server" 
                        PostBackUrl="~/MeetingManager/AddMeeting.aspx" ToolTip="���"  >���������Ҫ</asp:LinkButton>
                </td>
            </tr>
        </table>
        <fieldset style="border: 1px solid #CCCCCC;  width: 843px;">
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
            <asp:Button ID="btnSearch" runat="server" Text="��ѯ"  CssClass="BigButton" 
                onclick="btnSearch_Click"/>
        </fieldset>
        <table class="title1" width="750px;">
            <tr>
                <td style="height: 10px">
                    <span class="big3">&nbsp;��ѯ���</span>
                </td>
            </tr>
        </table>
       <div align="left" style="padding-left:40">
          <asp:Button ID="btnDelAll" 
            CssClass="BigButton" runat="server" Text="ɾ��"  ToolTip="ɾ��" Height="19px"  OnClientClick="return comfirm('ȷ��Ҫɾ����')" 
            onclick="btnDelAll_Click" Width="55px" /></div>
        <br />
    
                <asp:GridView ID="gvMeetingSummary" HeaderStyle-CssClass="TableHeader"  
            runat="server" AutoGenerateColumns="False" 
            DataSourceID="odsMeetingSummary" Width="748px" 
            onrowcommand="gvMeetingSummary_RowCommand" Font-Size="12pt" 
            DataKeyNames="MSID">
                    
                    <Columns>
                        <asp:TemplateField HeaderText="MSID" SortExpression="MSID">
                            <HeaderTemplate>
                                ȫѡ<input type="checkbox" onclick="selAll(this)" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfMSID" runat="server" Value='<%# Bind("MSID") %>'/>
                                <asp:CheckBox ID="cbAllCb"  runat="server" />
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
                                <asp:LinkButton ID="lbDel" OnClientClick="return comfirm('ȷ��Ҫɾ����')" runat="server" CommandArgument='<%# Eval("MSID") %>' CommandName="Del">ɾ��</asp:LinkButton>
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
                <uc1:Pager ID="Pager1" runat="server" />
    </div>
    </form>
</body>
</html>
