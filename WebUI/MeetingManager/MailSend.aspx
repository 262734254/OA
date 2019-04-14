<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailSend.aspx.cs" Inherits="UserWork_MailSend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>添加发送者</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />      
    <script language="javascript">
function clickOk()
{
	var arr=new Array(document.form1.selectBasLeft.length);
	for(var i=0;i<arr.length;i++)
	{
		arr[i]=document.form1.selectBasLeft.options[i].value;
	}
	window.returnValue = arr;
	window.close();
}
function makeValue(){
document.getElementById("dept").options.length=0;
if(document.getElementById("select").value==1)
{
	document.getElementById("dept").options.length=0;
	document.getElementById("dept").options.add(new Option("张三","张三")); 
	document.getElementById("dept").options.add(new Option("李四","李四")); 
	document.getElementById("dept").options.add(new Option("王五","王五")); 
}
if(document.getElementById("select").value==2)
{
	document.getElementById("dept").options.length=0;
	document.getElementById("dept").options.add(new Option("小李","小李")); 
	document.getElementById("dept").options.add(new Option("小王","小王")); 
	document.getElementById("dept").options.add(new Option("小猪","小猪")); 
}
}
//function BasMove (nType)
//{
//    switch (nType)
//    {
//        case 0:
//            OrtSelectMove (document.form1.selectBasRight, document.form1.selectBasLeft, 0);
//            break;
//        case 1:
//            OrtSelectMove (document.form1.selectBasLeft, document.form1.selectBasRight, 0);
//            break;
//        case 2:
//            OrtSelectMoveAll (document.form1.selectBasRight, document.form1.selectBasLeft, 0);
//            break;
//        case 3:
//            OrtSelectMoveAll (document.form1.selectBasLeft, document.form1.selectBasRight, 0);
//            break;
//    }
//}

 function OrtSelectMoveAll (Source, Target, Start)
{
    var eItem;
    if (Start < 0)
        Start = 0;
    if (Source.length < Start)
        return;
    while (Source.length > Start)
    {
        if (Target != null)
        {
            eItem = document.createElement ("OPTION");
            Target.add (eItem);
            eItem.innerText = Source.item (Start).text;
            eItem.value = Source.item (Start).value;
        }
        Source.remove (Start);
    }
    Source.selectedIndex = -1;
    if (Target != null)
        Target.selectedIndex = Target.length - 1;
}
function OrtSelectMove (Source, Target, Start)
{
    var nIndex;
    var eItem;
    if (Start < 0)
        Start = 0;
    nIndex = Source.selectedIndex;
    if (nIndex < Start)
        return;
    if (Target != null)
    {
        eItem = document.createElement ("OPTION");
        Target.add (eItem);
        eItem.innerText = Source.item (nIndex).text;
        eItem.value = Source.item (nIndex).value;
        Target.selectedIndex = Target.length - 1;
    }
    Source.remove (nIndex);
    if (nIndex >= Source.length)
        nIndex = Source.length - 1;
    Source.selectedIndex = nIndex;
}
</script>
    <style type="text/css">
        .style1
        {
            width: 101px;
        }
        .style3
        {
            height: 72px;
            width: 101px;
        }
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
        }
    </style>
    
</head>
<body>
    <form id="Form1" runat="server">
    <div class="style4">
        <table style="position: relative; top: 1px; left: 0px; width: 432px; height: 451px;" 
            align="center">
            <tr>
                <td class="style1">
                </td>
                <td style="width: 37px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td>
                    部门：<asp:DropDownList ID="DropDownList1" class="inputs" runat="server" onChange="makeValue()">
                    <asp:ListItem Selected="True">人事部门</asp:ListItem>
                    <asp:ListItem>市场部</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td colspan="2" style="height: 42px">
                </td>
            </tr>
            <tr>
                <td class="style1">
                    人员</td>
                <td style="width: 37px">
                </td>
                <td style="width: 100px">
                    已选人员</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:ListBox ID="selectBasRight"  runat="server" class="inputs" Height="241px" Width="146px">
                    </asp:ListBox></td>
                <td style="width: 37px; height: 72px;">
                
                <table align="center" style="width: 10px; height: 217px">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/sel1.gif"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButton2" runat="server"  ImageUrl="~/images/sel2.gif"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/sel3.gif"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButton4" runat="server"  ImageUrl="~/images/sel4.gif" />
                        </td>
                    </tr>
                </table>
                </td>
                <td style="width: 100px; height: 72px;">
                    <asp:ListBox ID="selectBasLeft" runat="server" class="inputs" Height="241px" Width="146px"></asp:ListBox></td>
            </tr>
            <tr>
                <td align="center" colspan="3" class="style4">
                    	 <asp:Button ID="Button1" runat="server" class="BigButton"  Text="确   定" Height="25px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" class="BigButton"  Text="取   消" Height="25px" /></td>
            </tr>
            
        </table>
        
    </div>
    </form>
</body>
	<SCRIPT language="javascript">
	function Ok() 
	{
		window.close();
		opener.document.all.txtOtherMan.value = window.Form1.hide.value;
	}
    	function Cancel() 
	{
    		window.close();
   	}
</SCRIPT>
</html>
