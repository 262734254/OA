<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_MessageSend.aspx.cs" Inherits="N_Exchange_N_Message_N_MessageSend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
<title>发送站内短消息</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript" ></script>
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function formCheck()
    {
        if (document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").value == "")
        {
            alert('请输入标题！');
            document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").focus();
            return false;
        }
        if (document.getElementById("ctl00_ContentPlaceHolder1_tb_content").value == "")
        {
            alert('请输入内容！');
            document.getElementById("ctl00_ContentPlaceHolder1_tb_content").focus();
            return false;
        }
        if (document.getElementById("ctl00_ContentPlaceHolder1_id_toValue").value.trim() == "") {
            alert('选择收件人！');
            return false;
        }
    }
    function qiehuan(num) {
        for (var i = 1; i <= 2; i++) {
            if (num == i) {
                document.getElementById("icon" + i).className = "showicon";
            } else {
                document.getElementById("icon" + i).className = "showicons";
            }
        }
    }
    function SelectUserWeb()
    {
        window.open('SelectUser2.aspx', '选择用户', 'height=400, width=300,toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no')
        
    }
    function ShowDialog() {
        var url = '../../N_SysManage/FlowDesign/Flow_UserSelect.aspx?to_id=ctl00_ContentPlaceHolder1_id_toValue&to_name=ctl00_ContentPlaceHolder1_tb_toname&titles=0';
        var iWidth = 380; //窗口宽度
        var iHeight = 400; //窗口高度
        var iTop = (window.screen.height - iHeight) / 4.3;
        var iLeft = (window.screen.width - iWidth) / 1.2;
        window.showModalDialog(url, window, "dialogHeight: " + iHeight + "px; dialogWidth: " + iWidth + "px;dialogTop: " + iTop + "; dialogLeft: " + iLeft + "; resizable: no; status: no;scroll:auto");
    }
    function removeimg(name, id) {
        var td_mail = document.getElementById("ctl00_ContentPlaceHolder1_td_tomail");
        var to_id = document.getElementById("ctl00_ContentPlaceHolder1_id_toValue");
        var to_name = document.getElementById("ctl00_ContentPlaceHolder1_tb_toname");
        to_id.value = to_id.value.replace(id + ",", "");
        to_name.value = to_name.value.replace(name + ",", "");
        innerHTMLtext.innerHTML = name + '<IMG id=' + name + id + ' onclick=' + "'" + 'removeimg("' + name + '","' + id + '");' + "'" + ' src="../../image/remove.png">,';
        td_mail.innerHTML = td_mail.innerHTML.replace(innerHTMLtext.innerHTML, "");
    }
    function fileupload(str) {
        if (str == 0) {
            document.getElementById("ctl00_ContentPlaceHolder1_fileuploaddiv").style.display = '';
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder1_fileuploaddiv").style.display = "none";
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-top:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr align="left">
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_MessageSend.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">发送信息</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_MessageReceive.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer; text-indent:20px">收件箱</div>
    </a></td>
    <td width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_MessageOld.aspx" class="a">
      <div style="width:73; height:27px;cursor:pointer; text-indent:20px">发件箱</div>
    </a></td>
    <td width="74" id="icon4" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_MessageRecycle.aspx" class="a">
      <div style="width:73; height:27px;cursor:pointer; text-indent:20px">回收站</div>
    </a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr>
    <td width="63" height="30" align="right" bgcolor="#f6f6f6">标题：</td>
    <td align="left" bgcolor="#f6f6f6"><label>
          <asp:TextBox runat="server" ID="tb_Title" Width="90%"  TextMode="MultiLine"
                onkeyup="javascrip:checkWord(200,event,'ctl00_ContentPlaceHolder1_lbl1')" Height="55px"></asp:TextBox> <br />
    <asp:Label ID="lbl1" runat="server" Font-Size="12px"   Text="0/200"></asp:Label>
          </label></td>
  </tr>
  
  <tr>
    <td height="75" align="right">内容：</td>
    <td align="left"><asp:TextBox runat="server" ID="tb_content" TextMode="MultiLine" Rows="8" Width="90%" onkeyup="javascrip:checkWord(1000,event,'ctl00_ContentPlaceHolder1_lbl2')"></asp:TextBox>      <br />
    <asp:Label ID="lbl2" runat="server" Font-Size="12px"   Text="0/1000"></asp:Label></td>
  </tr>
  <tr>
    <td bgcolor="#f6f6f6" height="80" align="right">接收人：</td>
    <td align="left" bgcolor="#f6f6f6">
        <div runat="server" id="td_tomail" style="border:1;width:80%;height:60px;overflow-y:auto;"></div>
         <input runat="server" id="id_toValue" type="hidden" />
         <asp:TextBox runat="server" ID="tb_toname"  TextMode="MultiLine" ReadOnly="true" Style="display:none" Width="80%" Rows="8"></asp:TextBox>
          <input  id="Button4" runat="server" class="button" type="button" value="接收人" onclick="ShowDialog();" /></td>
  </tr>
  <tr>
    <td height="30" align="right">附件：</td>
    <td align="left"><input id="file1" type="file" runat="server" /><asp:Label ID="Label1" runat="server"
            Text="此消息已存在附件："></asp:Label>&nbsp;<asp:Label ID="Label2" ForeColor="Red" runat="server" Text="如需修改请重新选择附件！"></asp:Label></td>
  </tr>
  
  <tr>
    <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
    <td height="30" align="left" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
    <asp:Button ID="Button1" runat="server" CssClass="button" Text="发送" OnClick="Button1_Click" OnClientClick="return formCheck();fileupload(0);" />
&nbsp;
<input type="reset" name="Submit2" value="重 置" class="button"/></td>
  </tr>
</table>
    <div style="display:none;" id="innerHTMLtext"></div>
    
            <div runat="server" id="fileuploaddiv" style="width: 100px; height: 100px; top:200px;
        left: 330px; position: absolute; display: none">
        <img src="../../image/img/uploading.gif" style="width: 100px; height: 100px" />
    </div>
</asp:Content>
