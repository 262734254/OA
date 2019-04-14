<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Document_Add.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_WorkFlow_CDocument_Document_Add" %>

<%@ Register assembly="Tunnel.BLL" namespace="OurControl" tagprefix="cc1" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<script type="text/javascript">
      function ShowDialog() {
           var url='../../N_SysManage/FlowDesign/Flow_UserSelect.aspx?to_id=ctl00_ContentPlaceHolder1_m_value&to_name=ctl00_ContentPlaceHolder1_TextBox2';//+document.getElementById('DropDownList1').value;
           var iWidth=380; //窗口宽度
           var iHeight=400;//窗口高度
           var iTop=(window.screen.height-iHeight)/2;
           var iLeft=(window.screen.width-iWidth)/3;
           window.showModalDialog(url,window,"dialogHeight: "+iHeight+"px; dialogWidth: "+iWidth+"px;dialogTop: "+iTop+"; dialogLeft: "+iLeft+"; resizable: no; status: no;scroll:auto;location:no");
         }
      function ShowDialog1() {
           var url='../../N_SysManage/FlowDesign/Flow_UserSelect.aspx?to_id=ctl00_ContentPlaceHolder1_first_value&to_name=ctl00_ContentPlaceHolder1_TextBox3&type=single';//+document.getElementById('DropDownList1').value;
           var iWidth=380; //窗口宽度
           var iHeight=400;//窗口高度
           var iTop=(window.screen.height-iHeight)/2;
           var iLeft=(window.screen.width-iWidth)/3;
           window.showModalDialog(url,window,"dialogHeight: "+iHeight+"px; dialogWidth: "+iWidth+"px;dialogTop: "+iTop+"; dialogLeft: "+iLeft+"; resizable: no; status: no;scroll:auto;location:no");
         }
     function formCheck() {
        if (document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").value=="")
        {
            alert('请输入标题！');
            document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").focus();
            fileupload(1);
            return false;
        }
        if (document.getElementById("ctl00_ContentPlaceHolder1_TextBox3").value=="")
        {
            if(!confirm("您确认不设置第一浏览人吗？")){
               fileupload(1); return false;
            }
        }
        if(document.getElementById("zuser").style.display==''&&document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value==""){
            alert('请选择其它浏览人！');
            fileupload(1);
            return false;
        }
    }
    function fileupload(str) {
        if (str == 0) {
            document.getElementById("ctl00_ContentPlaceHolder1_fileuploaddiv").style.display = '';
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_fileuploaddiv").style.display = "none";
        }
    }
    
    function showtr(num){
        if(num==1)
            document.getElementById("zuser").style.display='';
        else
            document.getElementById("zuser").style.display='none';
    }
    </script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="Document_Add.aspx" class="a">
      <div style="width:73; height:27px; cursor:pointer;">创建文件</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Document_Manage.aspx" class="a">
      <div style="width:73; height:27px;cursor:pointer;">管理文件</div>
    </a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      
      <tr>
        <td height="30" align="center" bgcolor="#ffffff">标题：</td>
        <td ><asp:TextBox runat="server" ID="tb_Title" onkeyup="javascrip:checkWord(100,event,'ctl00_ContentPlaceHolder1_lbl1')" Width="328px" ></asp:TextBox>
          &nbsp;<asp:Label ID="lbl1" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/100"></asp:Label></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#f6f6f6">分类：</td>
        <td align="left" bgcolor="#f6f6f6">
            <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="1" Text="外部来文"></asp:ListItem>
            <asp:ListItem Value="2" Text="普通文件"></asp:ListItem>
            <asp:ListItem Value="3" Text="其它文件"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;</td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#ffffff">内容：</td>
        <td bgcolor="#f6f6f6">
            <FCKeditorV2:FCKeditor ID="tb_content" Height="380" Width="100%" BasePath="~/Vfckeditor/" runat="server">
            </FCKeditorV2:FCKeditor>
          </td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#f6f6f6">附件：</td>
        <td bgcolor="#f6f6f6">
            <input id="file1" type="file" runat="server" /><asp:Label runat="server"  ID="lblFileInfo" ForeColor="Red" Text=""></asp:Label>
                                </td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#ffffff">第一浏览人：</td>
        <td bgcolor="#ffffff">
            <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true"></asp:TextBox><asp:HiddenField ID="first_value" runat="server" />
&nbsp;<a href="#" onclick="ShowDialog1()"><span style="color: Blue">+选择</span></a>
                                </td>
      </tr>
      <tr id="zuser">
        <td height="30" align="center" bgcolor="#f6f6f6">其它浏览人</td>
        <td bgcolor="#f6f6f6">
            <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" Height="53px" TextMode="MultiLine" 
                Width="367px"></asp:TextBox><asp:HiddenField ID="m_value" runat="server" />
<font color="red">*</font>&nbsp;<a href="#" onclick="ShowDialog()"><span style="color:Blue">+选择</span></a></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
            <asp:Button ID="Button1" runat="server" Text="保 存" CssClass="button" OnClientClick="fileupload(0);return formCheck();" onclick="Button1_Click"/>
          &nbsp;
          <input type="reset" name="Submit2" value="重 置" class="button"/></td>
      </tr>
    </table></td>
  </tr>
</table>
    <div runat="server" id="fileuploaddiv" style="width:100px;height:100px;top:300px;left:350px;position:absolute;display:none" ><img src="../../image/img/uploading.gif" style="width:100px;height:100px" /></div>
</asp:Content>