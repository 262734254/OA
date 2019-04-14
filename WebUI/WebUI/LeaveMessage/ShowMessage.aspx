<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowMessage.aspx.cs" Inherits="OfficeHelp_LeaveMessage_ShowMessage" %>

<%@ Register src="../UserControls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>消息列表</title>
   <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />  
    <style type="text/css">
        .style1
        {
            width: 798px;
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
    <div style="background-color: #C6DAF3">
        <!---留言消息-->
        <div class="title1">
            <h3>
                消息列表</h3>
        </div>
        <fieldset style="border: 1px solid #CCCCCC; text-align: center; padding-left: 25px;
            width: 90%">
            <br />
            <div style="height: 25px">
                按消息状态：<asp:DropDownList ID="dropMsgState" runat="server">
                              <asp:ListItem Value="0">请选择</asp:ListItem>
                              <asp:ListItem Value="已读">已读</asp:ListItem>
                              <asp:ListItem Value="未读">未读</asp:ListItem>
                              <asp:ListItem Value="已发">已发</asp:ListItem>
                          </asp:DropDownList>
&nbsp;按消息类型：<asp:DropDownList ID="dropMsgTypeId" AppendDataBoundItems="true" runat="server" DataSourceID="objMsgTypeId" 
                    DataTextField="MsgType" DataValueField="Id">
                    <asp:ListItem Selected="True" Value="0">请选择</asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="objMsgTypeId" runat="server" 
                    SelectMethod="GetMessageType" TypeName="BLL.WorkHelper.MessageTypeManger">
                </asp:ObjectDataSource>
                &nbsp;&nbsp;
                <asp:Button ID="btnSelect" runat="server" CssClass="textbox_show" 
                    onclick="btnSelect_Click" Text="查   询" Width="193px" />
            </div>
            <div style="width: 705px; height: 49px">
           <br />
                按时间查询:             
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">今日</asp:ListItem>
                    <asp:ListItem Value="2">本周</asp:ListItem>
                    <asp:ListItem Value="3">本月</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </fieldset>
        <asp:Button ID="btnDelete" runat="server" Text="删  除" CssClass="textbox_show" 
            onclick="btnDelete_Click" />
        <asp:GridView ID="gvLeaveWord" runat="server"  class="TableContent" 
            style="width:750px; margin-top: 0px;" cellpadding="0"
            AutoGenerateColumns="False" DataSourceID="objLeaveWord" 
            onrowcommand="gvLeaveWord_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="全选">
                    <HeaderTemplate>
                        <input ID="chSelect" type="checkbox" onclick="selAll(this)"/>全选
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkOne" runat="server" />
                        <asp:HiddenField ID="hfOne" runat="server" Value='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" 
                    Visible="False" />
                <asp:BoundField DataField="MsgTitle" HeaderText="主题" 
                    SortExpression="MsgTitle" />
                <asp:BoundField DataField="MsgContent" HeaderText="消息内容" 
                    SortExpression="MsgContent" Visible="False" />
                <asp:BoundField DataField="MsgSendTime" HeaderText="发送时间" 
                    SortExpression="MsgSendTime" Visible="False" />
                <asp:BoundField DataField="MsgState" HeaderText="状态" SortExpression="MsgState" 
                    Visible="False" />
                <asp:BoundField DataField="MeetingAddr" HeaderText="会议地点" 
                    SortExpression="MeetingAddr" Visible="False" />
                <asp:TemplateField HeaderText="发送人" SortExpression="SenderUser">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SenderUser") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("SenderUser.Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ChargeMan" HeaderText="负责人" 
                    SortExpression="ChargeMan" Visible="False" />
                <asp:TemplateField HeaderText="时间" SortExpression="MeetingBeginTime">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" 
                            Text='<%# Bind("MeetingBeginTime") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("MeetingBeginTime") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="MeetingType" HeaderText="会议类型" 
                    SortExpression="MeetingType" Visible="False" />
                <asp:BoundField DataField="IsAgree" HeaderText="是否同意" SortExpression="IsAgree" 
                    Visible="False" />
                <asp:BoundField DataField="Remark" HeaderText="备注" SortExpression="Remark" 
                    Visible="False" />
                <asp:TemplateField HeaderText="接受者" SortExpression="ReceiverUser" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ReceiverUser") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("ReceiverUser.Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="类型" SortExpression="MsgTypeId">
                   
                    <ItemTemplate>
                        <asp:Label ID="lblType" runat="server" Text='<%# Eval("MsgTypeId.MsgType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="查看">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSelect" runat="server" 
                            CommandArgument='<%# Eval("Id") %>' CommandName="Sele">查看</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#6699FF" BorderColor="#3399FF" CssClass="TableHeader" 
                ForeColor="#0099CC" />
       
                                </asp:GridView>
        <asp:ObjectDataSource ID="objLeaveWord" runat="server" 
            SelectMethod="SelectLeaveWordByAll" 
            TypeName="BLL.WorkHelper.LeaveWordManager">
            <SelectParameters>
                <asp:ControlParameter ControlID="dropMsgTypeId" Name="msgTypeId" 
                    PropertyName="SelectedValue" Type="String" DefaultValue="" />
                <asp:ControlParameter ControlID="dropMsgState" Name="msgState" 
                    PropertyName="SelectedValue" Type="String" DefaultValue="" />
                <asp:ControlParameter ControlID="RadioButtonList1" Name="meetingBeginTime" 
                    PropertyName="SelectedValue" Type="String" DefaultValue="" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <table>
            <tr>
                <td class="style1">
                    <uc1:Pager ID="Pager1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
