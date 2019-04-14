<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="AddMeeting.aspx.cs" Inherits="Meeting_AddMeeting" %>

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
    
    </script>

    <script type="text/javascript">
    
    
    function addPerson(ojb)
    {

	    var arr=new Array();
	    //返回一个object对象
	    arr = window.showModalDialog("MailSend.aspx","new","dialogHeight:500px;dialogWidth:800px;edge:Raised;center:Yes;help:No;resizable:no;status:no;");
	    //alert(arr);
	    var person=new Array();
	    if(ojb==1)
	    {
	        alert(ojb+"1111");
	        //将所有已存在的与会人员获取到person中
	        for(var i=0;i<document.getElementById("txtOtherMan ").options.length;i++)
	        {   
		        person[i]=document.getElementById("txtOtherMan").options[i].value;
	        }
	        //判断与会人员是否存在，如果为空，将获取的与会人员添加到ListBox列表中
	        if(person.length==0)
	        {
		        for(var i=0;i<arr.length;i++)
		        {
			        document.getElementById("txtOtherMan").options.add(new Option(arr[i],arr[i]));
		        }
	        }
	        else  //如果存在与会人员，遍历获取到的array对象
	        {
		        for(var j=0;j<arr.length;j++)
		        {	
			        if(!jsSelectIsExitItem(person,arr[j]))  //判断返回的对象中是否已存在，存在，不重复添加
			        {
				        document.getElementById("txtOtherMan").options.add(new Option(arr[j],arr[j]));
			        }
		        }
	        }
	        var num="";
	        //循环listbox中的值
	         for(var i=0;i<document.getElementById("txtOtherMan ").options.length;i++)
	        {   
		        num+=document.getElementById("txtOtherMan").options[i].value+",";
	        }
	        document.getElementById("hfOtherMan").value=num;
	         alert(num);
	        
	    }
	    else{
	        //将所有已存在的与会人员获取到person中
	        for(var i=0;i<document.getElementById("txtMissingPeople").options.length;i++)
	        {
		        person[i]=document.getElementById("txtMissingPeople").options[i].value;
	        }
	        //判断与会人员是否存在，如果为空，将获取的与会人员添加到ListBox列表中
	        if(person.length==0)
	        {
		        for(var i=0;i<arr.length;i++)
		        {
			        document.getElementById("txtMissingPeople").options.add(new Option(arr[i],arr[i]));
		        }
	        }
	        else  //如果存在与会人员，遍历获取到的array对象
	        {
		        for(var j=0;j<arr.length;j++)
		        {	
			        if(!jsSelectIsExitItem(person,arr[j]))  //判断返回的对象中是否已存在，存在，不重复添加
			        {
				        document.getElementById("txtMissingPeople").options.add(new Option(arr[j],arr[j]));
			        }
		        }
		        
	        }
	        
	        var num="";
	        //循环listbox中的值
	         for(var i=0;i<document.getElementById("txtMissingPeople ").options.length;i++)
	        {   
		        num+=document.getElementById("txtMissingPeople").options[i].value+",";
	        }
	        document.getElementById("hfMissingPeople").value=num;
	        alert(num);
	    }
	    
    }
    
    
    function jsSelectIsExitItem(objSelect, objItemValue) {           
        var isExit = false;           
        for (var i = 0; i < objSelect.length; i++) {           
            if (objSelect[i] == objItemValue) {           
                isExit = true;           
                break;           
            }           
        }           
        return isExit;           
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
            width: 118px;
        }
        .style7
        {
            height: 19px;
            width: 118px;
        }
        .style8
        {
            height: 2px;
            width: 118px;
        }
        .style9
        {
            width: 118px;
        }
        .style10
        {
            height: 19px;
        }
        .style11
        {
            height: 91px;
        }
        #txtOtherMan
        {
            height: 61px;
            width: 284px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center" class="style4">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="2" width="80" class="title1" align="center">
                    <h3>
                        新增会议纪要</h3>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" border="0" align="center" style="width: 73%">
            <tr>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td align="right" class="style9">
                    标题：
                </td>
                <td align="left">
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
                <td align="left" class="style10">
                    <input type="text" onclick="showcalendar(event, this);" id="txtStartTime" runat="server"
                        style="border: 1px solid #99ccff; height: 19px;" readonly="readonly" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="txtStartTime" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtEndTime"
                        ControlToValidate="txtStartTime" ErrorMessage="会议开始时间应在当前时间之后" Operator="LessThan"
                        Display="Dynamic"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style8">
                    结束时间：
                </td>
                <td align="left" style="height: 2px">
                    <input type="text" id="txtEndTime" runat="server" readonly="readonly" onclick="showcalendar(event, this);"
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
                <td align="right" class="style11">
                    参与者：
                </td>
                <td align="left" class="style11">
           
                    <asp:ListBox ID="txtOtherMan" runat="server" Width="298px"></asp:ListBox>
                    
                    <input name="Submit3" type="button" value="添加与会人员" class="BigButton" onclick="addPerson(1)" />
        &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" class="style8">
                    缺席者：
                </td>
                <td align="left" style="height: 2px">
                    <asp:ListBox ID="txtMissingPeople" runat="server" Width="294px"></asp:ListBox>
                
                    <input name="Submit3" type="button" value="添加缺席人员" class="BigButton" onclick="addPerson(2)" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style8">
                    &nbsp;主持人：
                </td>
                <td align="left" style="height: 2px">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlDepartmentType" runat="server" class="inputs" Style="border-right: #99ccff 1px solid;
                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                                Height="16px" Width="90px" OnSelectedIndexChanged="ddlDepartmentType_SelectedIndexChanged"
                                DataSourceID="odsAllDepartment" DataTextField="Departmentname" DataValueField="Id"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:DropDownList ID="ddlCompere" runat="server"
                                class="inputs" Style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" Height="16px"
                                Width="90px">
                            </asp:DropDownList>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:ObjectDataSource ID="odsAllDepartment" runat="server" SelectMethod="GetAllDepartment"
                        TypeName="BLL.Power.DepartmentManager"></asp:ObjectDataSource>
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
                    <textarea name="txtMeetingContent" rows="2" cols="20" id="txtMeetingContent" style="height: 100px;
                        width: 450px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                        border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" runat="server"></textarea>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                        ControlToValidate="txtMeetingContent" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 25px" align="center">
                    &nbsp;<asp:HiddenField ID="hfOtherMan" runat="server" />
                            <asp:HiddenField ID="hfMissingPeople" runat="server" />
                    <asp:Button ID="btnSubmit" runat="server" Text="保  存" CssClass="BigButton" OnClick="btnSubmit_Click" />
                    &nbsp;&nbsp;
                    <input id="btnExit" type="button" value="返　回" onclick="history.go(-1);" class="BigButton" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
