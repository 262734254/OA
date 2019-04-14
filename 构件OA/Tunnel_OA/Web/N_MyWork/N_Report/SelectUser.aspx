<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectUser.aspx.cs" Inherits="grzm_SelectUser" %>
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>选择用户</title>
<link href="../../css/group.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
function CheckAll(form)
{
	for(var y=0; y<form1.elements.length; y++)
	{
		var e = form.elements[y];
		if (e.name != "all"&&e.disabled==false)
        e.checked = form.all.checked;
	}
}
function CheckGroup(form,ID)
//---选组---
{
	var nameStr="click"+ID.toString();
	for(var i=0;i<form.elements.length;i++)
	{
		if (form.elements[i].id == nameStr)
		{
			form.elements[i].checked = eval("form.gourp"+ID+".checked");
		}
	}
}
function SelectUser(form,name)
{
    var nameStr = name;
	var str = ""
	var strName = "";
	var strValue = "";
	for(var x=0; x<form.elements.length; x++)
	{
		if(form.elements[x].id >= nameStr)
		{
			if (form.elements[x].checked == true)
			{
			    var temp = form.elements[x].value;
			    var strArr = temp.split(',');
				strName = strName + strArr[1] +",";
				strValue = strValue + strArr[0] +",";
			}
		}
	}
	strName = strName.slice(0,strName.length-1)
	strValue = strValue.slice(0,strValue.length-1)
	var objName = window.opener.aspnetForm.ctl00_ContentPlaceHolder1_txtUsers;
	var objValue = window.opener.aspnetForm.ctl00_ContentPlaceHolder1_HiddenField1;

    if(objName != null)
        objName.value = strName;
    if(objValue != null)
        objValue.value = strValue;
    window.close();
    alert(strName)
}
function expandTree(str)
{
    var objStr = document.getElementById(str)
    if(objStr != null)
    {
        if(objStr.style.display == "none")
            objStr.style.display = "";
        else
            objStr.style.display = "none";    
    }
}
</script>
</head>
<body>
<form id="form1" runat="server">
  <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td colspan="3" class="tou" height="30" align="center"> 选择用户</td>
      </tr>
    </table>
   
    
    <table width="96%" border="0" cellpadding="0" cellspacing="0" align="center">
       <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
        <ItemTemplate>
          <tr>
            <td height="23" align="left" style="width: 10%">
            <div style=" background-color:#e8e8e8; height: 18px; padding-top: 4px; padding-left:4px;"> <a onclick="expandTree('user_Content<%#Eval("b_id")%>');" style=" cursor: hand; text-decoration: none"><%#Eval("b_name")%></a></div>
            <div id='user_Content<%#Eval("b_id")%>' style="display:none">
            <table width="100%" border="1" align="center" cellpadding="6" cellspacing="0" bordercolorlight="#c1c1c1" bordercolordark="#FFFFFF">
             <tr>
               <td style="width: 2%;padding-left: 8px;" ><input name='gourp<%#Eval("b_id")%>' type="checkbox" onclick="CheckGroup(this.form,<%#Eval("b_id")%>)"/></td>
               <td style="width: 8%"><strong>姓名</strong></td>
               <td style="width: 10%"><strong>邮箱</strong></td>
            </tr>
            <asp:Repeater ID="Repeater3" runat="server">
            <ItemTemplate>
              <tr>
                <td align="center" style="width: 2%">&nbsp;<input type="checkbox" id='click<%#Eval("m_bum") %>' value='<%#Eval("m_id") %>,<%#Eval("m_name")%>' title="点击您要选择的用户" /></td>
                <td align="center" style="width: 8%">&nbsp;<%#Eval("m_name")%></td>
                <td align="center" style="width: 18%">&nbsp;<%#Eval("m_mail")%></td>
              </tr>
              </ItemTemplate>
              </asp:Repeater>
            </table>
            </div>
            </td>
          </tr>
        </ItemTemplate>
      </asp:Repeater>
    </table>
    
    <table width="96%" border="0" align="center" cellpadding="6" cellspacing="0">
      <tr>
        <td style="padding-left: 11px;"><input type="checkbox" id="all" title="全选" onclick="CheckAll(this.form)" /> 全选</td>
        <td align="center"><input type="button" value=" 确定 " onclick="SelectUser(this.form,'click');"> &nbsp; </td>
      </tr>
    </table>
  </div>
</form>
</body>
</html>
