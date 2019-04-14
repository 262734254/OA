<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchRoom.aspx.cs" Inherits="MeetingManager_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加会议室安排信息</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" src="../js/calendar.js" type="text/javascript">

</script>

    <style type="text/css">
        body
        {
            font-size: 9pt; /* 字体大小                  */
            font-family: Verdana; /* 字体名称                  */
        }
        input.BigButton
        {
            border: 1px solid #666666;
            font-size: 12px;
            background-image: url('../css/6/images/button_bg.gif');
            background-color: #ffffff;
        }
        #Select1
        {
            width: 123px;
        }
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
        }
        #Select2
        {
            width: 123px;
        }
        .td_02
        {
            height: -12px;
        }
        .style5
        {
            width: 112%;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
    <table class="style4" width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
        <tr>
            <td class="title1" align="center">
                <h3>
                    会议室状态查看</h3>
            </td>
        </tr>
        <tr valign="top">
            <td align="center" style="height:450px;padding-top:10px">
            
<table width="95%" border="0" style="padding-top:30px" align="center" cellpadding="0" cellspacing="0" class="table01">
  <tr>
    <td width="10%" class="td_02">会议室名称<br /></td>
    <td class="td_02" >
        <asp:DropDownList ID="ddlRoomName"  style="width:95%; height: 13px;" 
           runat="server" DataSourceID="odsAllRoomName" 
            DataTextField="RoomName" DataValueField="RID" 
            onselectedindexchanged="ddlRoomName_SelectedIndexChanged" 
            AutoPostBack="True">
        
        </asp:DropDownList>
        <asp:ObjectDataSource ID="odsAllRoomName" runat="server" 
            SelectMethod="GetAllRoomInfo" TypeName="BLL.Meeting.RoomInfoManager">
            
        </asp:ObjectDataSource>
    </td>
  </tr>
  <tr><td colspan="2"><hr class="td_02"/></td></tr>
</table>
<table width="95%"  border="1" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="td_page"><div align="right">
                            <input id="btnExit0" type="button" value="返   回" 
             onclick="javascript:window.location='ApplicationMeeting.aspx'" class="BigButton" />
    </div></td>
  </tr>
</table>
<br>

<table width="95%"  border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td><table id="1" width="100%"  border="1" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td class="td_page_blue"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="20%" height="30"><div align="center">会议室名称</div></td>
              <td width="60%"><asp:Label ID="lblRoomName" runat="server"></asp:Label>
                                                    </td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td height="30"><div align="center">会议室状态</div></td>
              <td><asp:Label ID="lblRoomState" runat="server"></asp:Label>
                                                    </td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td height="30"><div align="center">会议室描述</div></td>
              <td><asp:Label ID="lblRemark" runat="server"></asp:Label>
                                                    </td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td valign="top"><div align="center">会议安排</div></td>
              <td colspan="2"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="25">
                        <asp:DataList ID="dlRoomArrage" runat="server" DataSourceID="odsRoomArrage" 
                            RepeatColumns="2">
                            <ItemTemplate>
                                <table >
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblBeginTime" runat="server" Text='<%# Eval("BeginTime") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        至
                                                        <asp:Label ID="lblEndTime" runat="server" Text='<%# Eval("EndTime") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRoomName" runat="server" Text='<%# Eval("RoomName") %>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:ObjectDataSource ID="odsRoomArrage" runat="server" 
                            SelectMethod="SearchRoomArrageStateByRoomName" 
                            TypeName="BLL.Meeting.RoomArrageManager">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlRoomName" Name="roomName" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                      </td>
                  </tr>
              </table></td>
            </tr>
        </table></td>
      </tr>
    </table>
      <table id="2" style="display:none " width="100%"  border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td class="td_page_blue"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="20%" height="30"><div align="center">会议室名称</div></td>
                <td width="60%">会议室2</td>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td height="30"><div align="center">会议室状态</div></td>
                <td>使用中...</td>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td height="30"><div align="center">会议室描述</div></td>
                <td>会议室2</td>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td><div align="center">会议安排</div></td>
                <td colspan="2"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td height="25">2008-10-10 08:00 至 2008-10-10 10:00 人事部会议</td>
                      <td>2008-10-10 08:00 至 2008-10-10 10:00 人事部会议</td>
                    </tr>
                    <tr>
                      <td height="25">2008-10-10 08:00 至 2008-10-10 10:00 人事部会议</td>
                      <td>2008-10-10 08:00 至 2008-10-10 10:00 人事部会议</td>
                    </tr>
                </table></td>
              </tr>
          </table></td>
        </tr>
      </table></td>
  </tr>
</table>
            
            </td>
        </tr>
    </table>
    
    
    </form>
</body>
</html>

