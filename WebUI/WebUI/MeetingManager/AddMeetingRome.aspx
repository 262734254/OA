<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMeetingRome.aspx.cs" Inherits="MeetingManager_AddMeetingRome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增会议室</title>
    <link href="../css/6/style.css" rel="Stylesheet" />
    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>
    <style type="text/css">
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
        }
    </style>
    <script type="text/javascript">
        function checkNumber(){
            var number=document.getElementById("txtContainNum").value;
            for(var i=0;i<number.length;i++){
                var a=number[i];
                if(a>=0 && a<=9){
                    document.getElementById("divNumber").innerHTML="";
                }
                else{
                document.getElementById("divNumber").innerHTML="容纳人数格式不正确";
                   return;
                
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style4">
        <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td style="height: 25px" class="title1">
                    <h3>
                        新增会议室</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;
                </td>
            </tr>
        </table>
        <table width="80%" cellpadding="2" cellspacing="1" border="0" class="px12" style="font: menu">
            <tr>
                <td align="right" class="style2">
                    会议室名称：
                </td>
                <td align="left" class="style5">
                    <input name="startDate8" id="txtRomeName" style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                        runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="*" ControlToValidate="txtRomeName" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    容纳人数：
                </td>
                <td align="left" class="style6">
                    <input name="txtContainNum" id="txtContainNum" style="border: 1px solid #99ccff; height: 20px; width: 126px;"
                        runat="server"  /><div style="display:inline;" id="divNumber"></div><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="*" ControlToValidate="txtContainNum" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ControlToValidate="txtContainNum" ErrorMessage="容纳人数格式不正确" MaximumValue="200" 
                        MinimumValue="1" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    地点：
                </td>
                <td align="left" class="style6">
                    <input name="txtAddress" id="txtAddress" style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                        runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="*" ControlToValidate="txtAddress" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    室内配备：
                </td>
                <td align="left" class="style6">
                    <textarea name="txDes1" id="txtEquip" style="height: 130px; width: 380px;
                        border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                        border-bottom: #99ccff 1px solid;" runat="server" cols="20"
                        rows="1"></textarea><asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="*" ControlToValidate="txtEquip" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style4">
                    备注：
                </td>
                <td align="left" class="style7">
                    <textarea name="txDes" id="txtRomeCondition" runat="server" class="TxCss" style="height: 130px; width: 380px;
                        border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                        border-bottom: #99ccff 1px solid;" runat="server" cols="20"
                        rows="1"></textarea>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 25px" align="center">
                    &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="保 存"  CssClass="BigButton" onclick="btnSave_Click" 
                         />
                    &nbsp;&nbsp; &nbsp;
                    <input id="btnExit" type="button" value="返　回" class="BigButton" 
                        onclick="history.go(-1);" causesvalidation="False" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
