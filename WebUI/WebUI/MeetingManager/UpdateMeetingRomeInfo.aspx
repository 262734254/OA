<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateMeetingRomeInfo.aspx.cs"
    Inherits="MeetingManager_UpdateMeetingRomeInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改会议室信息</title>
    <link href="../css/6/style.css" rel="Stylesheet" />
    <link href="../css/public.css" rel="Stylesheet" />
    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>
    <style type="text/css">
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
        }
        .style5
        {
            width: 375px;
        }
        .style6
        {
            width: 375px;
            background-color: #C6DAF3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style4">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
        <tr>
            <td style="height: 25px" class="title1">
                <h3>
                    修改会议室信息</h3>
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="80%" cellpadding="2" cellspacing="1" border="0" style="font: menu">
        <tr>
            <td align="right" class="style5">
                会议室名称：
            </td>
            <td align="left">
                <input name="startDate8" id="txtRomeName" style="border-right: #99ccff 1px solid;
                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                    runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="*" ControlToValidate="txtRomeName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style5">
                容纳人数：
            </td>
            <td align="left">
                <input name="txtContainNum" id="txtContainNum" style="border-right: #99ccff 1px solid;
                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                    runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="*" ControlToValidate="txtContainNum"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ControlToValidate="txtContainNum" ErrorMessage="容纳人数格式不正确" MaximumValue="200" 
                    MinimumValue="1" Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style5">
                地点：
            </td>
            <td align="left">
                <input name="txtAddress" id="txtAddress" style="border-right: #99ccff 1px solid;
                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                    runat="server"  /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="*" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style5">
                室内配备：
            </td>
            <td align="left">
            <asp:TextBox ID="txtEquip" runat="server" style="height: 130px; width: 380px;
                        border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                        border-bottom: #99ccff 1px solid;"  TextMode="MultiLine"></asp:TextBox>
                        
               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ErrorMessage="*" ControlToValidate="txtEquip"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style6">
                备注：
            </td>
            <td align="left">
            <asp:TextBox ID="txtRomeCondition" runat="server" style="height: 130px; width: 380px;
                        border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                        border-bottom: #99ccff 1px solid;"  TextMode="MultiLine"></asp:TextBox>
                        
                
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 25px" align="center">
                &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btnUpdate" runat="server" 
                    Text="保 存" 
                    CssClass="BigButton" onclick="btnUpdate_Click"  />
              
                &nbsp;&nbsp; &nbsp;
                <input id="btnExit" type="button" value="返　回" class="BigButton" onclick="history.go(-1);" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
