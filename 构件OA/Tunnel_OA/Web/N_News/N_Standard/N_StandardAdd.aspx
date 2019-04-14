<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_StandardAdd.aspx.cs" Inherits="N_News_N_Standard_N_StandardAdd"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
  <title>标准规范</title>
    <link href="../../Css/Css.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="../../javascript/Calendarform.js"></script>
<script type="text/javascript" src="../../javascript/utility.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.3.2.min.js"></script>
<script src="../../javascript/StrLength.js" type="text/javascript" language="javascript" ></script>
    <script type="text/javascript">
        function formCheck() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").value == "")
        {
            alert('请输入标题！');
            document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").focus();
            fileupload(1);
            return false;
        }
     
        if (document.getElementById("ctl00_ContentPlaceHolder1_file1").value == "")
        {
            alert('请选择附件！');
            document.getElementById("ctl00_ContentPlaceHolder1_file1").focus();
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
    </script>
    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript" ></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr align="left">
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_StandardAdd.aspx" class="a" >
      <div style="width:73; height:27px; cursor:pointer;">新建规范</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_Standard_Manage.aspx" class="a" >
      <div style="width:73; height:27px;cursor:pointer;">规范管理</div>
    </a></td>
    
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
    <div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      <tr>
        <td height="30" align="center" bgcolor="#ffffff">标题：</td>
        <td align="left"><label>
          <asp:TextBox runat="server" ID="tb_Title" Width="90%" 
                onkeyup="javascrip:checkWord(100,event,'ctl00_ContentPlaceHolder1_lbl1')" ></asp:TextBox>
          </label>
   <br />
    <asp:Label ID="lbl1" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/100"></asp:Label></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#ffffff">附件：</td>
        <td align="left"><input id="file1" type="file" runat="server" /><asp:Label runat="server"  ID="lblFileInfo" ForeColor="Red" Text=""></asp:Label></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
            <asp:Button ID="btnSave" runat="server" CssClass="button"  Text="提交" 
                OnClick="Button1_Click" OnClientClick="return formCheck();fileupload(0);" /> &nbsp; <input id="Button2" class="button" type="button" onclick="window.history.go(-1)" value="返 回" />
        </td>
      </tr>

    </table>
        <div runat="server" id="fileuploaddiv" style="width:100px;height:100px;top:200px;left:330px;position:absolute;display:none" ><img src="../../image/img/uploading.gif" style="width:100px;height:100px" /></div>
    </div>
</asp:Content>

