<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMeeting.aspx.cs" Inherits="Meeting_AddMeeting" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加会议纪要</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript" />
    <script type="text/javascript" language="javascript">
	function otherman() 
	{
    window.open("MailSend.aspx?id=1",null,"height=400,width=400,directories = no,status=no,toolbar=no,menubar=no,location=no,titlebar = no,scrollbars = no");
    }
    function othermans() 
	{
    window.open("MailSends.aspx?id=1",null,"height=400,width=400,directories = no,status=no,toolbar=no,menubar=no,location=no,titlebar = no,scrollbars = no");
    }
    
    function addCompere()
    {
	var name = window.showModalDialog("Send.aspx","new","dialogHeight:420px;dialogWidth:500px;edge:Raised;center:Yes;help:No;resizable:no;status:no;");
	if(name==null || name=="")
	{
		alert('请重新选择！');
		document.getElementById("txtChargeMan").value="";
	}
	else{
		document.getElementById("txtChargeMan").value=name;
	}
    }
    </script>

    <link rel="stylesheet" type="text/css" href="../css/6/style.css" />
    <style type="text/css">
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
            height: 511px;
        }
        .style5
        {
            height: 25px;
            width: 499px;
        }
        .style6
        {
            height: 14px;
            width: 499px;
        }
        .style7
        {
            height: 24px;
            width: 499px;
        }
        .style8
        {
            height: 2px;
            width: 499px;
        }
        .style9
        {
            width: 499px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center" class="style4">
        <table  border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="2" width="80" class="title1" align="center">
                    <h3>
                        新增会议纪要</h3>
                </td>
            </tr>
        </table>
        <table width="70%" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td align="right" class="style6">
                    标题：
                </td>
                <td align="left" style="height: 14px">
                    <asp:TextBox ID="txtTitle" runat="server" Style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtTitle"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style7">
                    开始时间：
                </td>
                <td align="left" style="height: 24px">
                    <input type="text" onclick="showcalendar(event, this);" id="txtStartTime" runat="server"
                        style="border: 1px solid #99ccff; height: 19px;" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="txtStartTime" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtEndTime"
                        ControlToValidate="txtStartTime" ErrorMessage="会议开始时间应在当前时间之前" Operator="LessThan"
                        Display="Dynamic"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style8">
                    结束时间：
                </td>
                <td align="left" style="height: 2px">
                    <input type="text" id="txtEndTime" runat="server" onclick="showcalendar(event, this);"
                        style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                        border-bottom: #99ccff 1px solid" />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        ControlToValidate="txtEndTime" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtStartTime"
                        ControlToValidate="txtEndTime" ErrorMessage="结束时间应在开始时间之后" Operator="GreaterThan"
                        Display="Dynamic"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style8">
                    参与者：
                </td>
                <td align="left" style="height: 2px">
                    <asp:TextBox ID="txtOtherMan" runat="server" CssClass="TxCss" name="txtOtherMan" tyle="border: 1px solid #99ccff;
                        width: 355px; height: 67px;" Height="70px" TextMode="MultiLine" 
                        Width="351px"></asp:TextBox>
                     &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style8">
                    缺席者：
                </td>
                <td align="left" style="height: 2px">
                    
                    <input id="txtMissingPeople" runat="server" class="TxCss" name="txtabsentMan" style="border: 1px solid #99ccff;
                        width: 354px; height: 68px;" type="text" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style8">
                    &nbsp;主持人：
                </td>
                <td align="left" style="height: 2px">
                    <asp:DropDownList ID="ddlDepartmentType" runat="server" class="inputs" Style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                        Height="16px" Width="90px" ondatabound="ddlDepartmentType_DataBound" 
                        onselectedindexchanged="ddlDepartmentType_SelectedIndexChanged">
                        <asp:ListItem Selected="True">人事部</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:DropDownList ID="ddlCompere" 
                        runat="server" class="inputs"
                        Style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                        border-bottom: #99ccff 1px solid" Height="16px" Width="90px" 
                       >
                        <asp:ListItem Selected="True">老张</asp:ListItem>
                        <asp:ListItem>紧急会议</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="style8">
                    会议类型：
                </td>
                <td align="left" style="height: 2px">
                    <asp:DropDownList ID="droType" runat="server" class="inputs" Style="border-right: #99ccff 1px solid;
                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                        Height="16px" Width="90px">
                        <asp:ListItem Selected="True">普通会议</asp:ListItem>
                        <asp:ListItem>紧急会议</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td height="25" align="right" class="style9">
                    内容：
                </td>
                <td align="left">
                    <textarea name="txtMeetingContent" rows="2" cols="20" id="txtMeetingContent" style="height: 100px; width: 450px;
                        border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                        border-bottom: #99ccff 1px solid;" runat="server"></textarea>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                        ControlToValidate="txDes" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 25px" align="center">&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="保  存" CssClass="BigButton" onclick="btnSubmit_Click" 
                        />
                    
                    &nbsp;&nbsp;
                    <input id="btnExit" type="button" value="返　回" onclick="history.go(-1);" class="BigButton" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
