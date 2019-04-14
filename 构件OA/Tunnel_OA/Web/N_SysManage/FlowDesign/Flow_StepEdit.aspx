<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Flow_StepEdit.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_SysManage_FlowDesign_Flow_StepEdit" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<style type="text/css">
.STYLE1 {color: #FF0000}
</style>
    <link href="../../Css/Css.css" type="text/css" rel="stylesheet"/>
    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

    <script language="javascript">
    function ShowDialog() {
           var url='Flow_UserSelect.aspx?to_id=ctl00_ContentPlaceHolder1_m_value&to_name=ctl00_ContentPlaceHolder1_TextBox3';//+document.getElementById('DropDownList1').value;
           var iWidth=380; //窗口宽度
           var iHeight=400;//窗口高度
           var iTop=(window.screen.height-iHeight)/2;
           var iLeft=(window.screen.width-iWidth)/3;
           window.showModalDialog(url,window,"dialogHeight: "+iHeight+"px; dialogWidth: "+iWidth+"px;dialogTop: "+iTop+"; dialogLeft: "+iLeft+"; resizable: no; status: no;scroll:auto;location:no");
         }
     function onmm(){
        if(document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value==''){
            alert('请输入步骤名称!');
            document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").focus();
            return false;
        }
        if(document.getElementById("ctl00_ContentPlaceHolder1_TextBox3").value==''){
            alert('请选择经办人!');
            return false;
        }
     }
    </script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Flow_Add.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">添加流程</div></a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="Flow_Manage.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">管理流程</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      <tr>
        <td width="80" height="30" align="center" bgcolor="#f6f6f6">序号：</td>
        <td bgcolor="#f6f6f6">&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="21px">1</asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage=" *必须为整数" ValidationExpression="^(\d)+$"></asp:RegularExpressionValidator></td>
      </tr>
      <tr>
        <td height="30" align="center">步骤名称：</td>
        <td>&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>&nbsp;<span style="color:Red">*</span></td>
      </tr>
       <tr>
        <td height="30" align="center" bgcolor="#f6f6f6">审批意见：</td>
        <td bgcolor="#f6f6f6">&nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="0" Selected="True">允许</asp:ListItem>
                        <asp:ListItem Value="1">不允许</asp:ListItem>
                    </asp:RadioButtonList></td>
      </tr>
      <tr id="sh" style="display:">
        <td width="80" height="30" align="center" bgcolor="#ffffff">执行步骤：</td>
        <td bgcolor="#ffffff"><asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                        <asp:ListItem Value="1">是</asp:ListItem>
                        </asp:RadioButtonList></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#f6f6f6">经办人：</td>
        <td bgcolor="#f6f6f6">&nbsp;<asp:TextBox ID="TextBox3" runat="server" Height="48px" 
                ReadOnly="True" TextMode="MultiLine"
                        Width="385px"></asp:TextBox>&nbsp;<span style="color:Red">*</span><asp:HiddenField ID="m_value" runat="server" />
                    <a href="#" onclick="ShowDialog()"><span style="color: Blue">+选择</span></a></td>
      </tr>
      <tr>
        <td height="30" align="center">步骤说明：</td>
        <td>&nbsp;<asp:TextBox ID="TextBox4" runat="server" Height="62px" TextMode="MultiLine"
                        Width="385px" onkeyup="javascrip:checkWord(1000,event,'ctl00_ContentPlaceHolder1_lbl')"></asp:TextBox>&nbsp;
                    <asp:Label ID="lbl" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/1000"></asp:Label></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
        <td height="30" align="left" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
            <asp:Button ID="Button1" runat="server" Text="修 改" OnClientClick="return onmm()" 
                CssClass="button" onclick="Button1_Click" />&nbsp;&nbsp;<input type="reset" name="Submit2" value="重 置" class="button"/>&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button" onclick="Button2_Click" />
</td>
      </tr>
      
    </table></td>
  </tr>
</table>
</asp:Content>