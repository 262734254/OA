<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_NewAdd.aspx.cs" Inherits="N_News_N_News_N_NewAdd" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>新增新闻</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    function formCheck()
    {
        if (document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").value == "")
        {
            alert('请输入标题！');
            document.getElementById("ctl00_ContentPlaceHolder1_tb_Title").focus();
            return false;
        }
        if (document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").value == "0" || document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").value == "") {
            alert('请选择审核人！');
            document.getElementById("ctl00_ContentPlaceHolder1_DropDownList1").focus();
            return false;
        }
//        var obj=document.getElementById('ctl00_ContentPlaceHolder1_file1');
//        if(obj.value!="")
//        {
//            var stuff=obj.value.match(/^(.*)(\.)(.{1,8})$/)[3]; 
//            if(stuff!='jpg')
//            {
//               alert('文件类型不正确，请选择.jpg类型的图片文件');
//               return false;
//            }
//        }
    }
    </script>
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>


       <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript" >function file1_onclick() {

}

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr align="left">
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_NewAdd.aspx" class="a">
    <div style="width:74px; height:27px; cursor:pointer;">发布新闻</div></a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_NewManage.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">管理新闻</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      <tr>
        <td width="50" height="70" align="center" bgcolor="#f6f6f6">标题：</td>
        <td align="left" bgcolor="#f6f6f6"><asp:TextBox runat="server" ID="tb_Title" TextMode="MultiLine" 
                Width="70%"  onkeyup="javascrip:checkWord(200,event,'ctl00_ContentPlaceHolder1_lbl1')" Height="35px"></asp:TextBox>
            &nbsp;<br /><asp:Label ID="lbl1" runat="server" Font-Size="12px"   Text="0/200"></asp:Label></td>
      </tr>   
         <tr>
        <td width="50" height="30" align="center" bgcolor="#f6f6f6">审核人：</td>
        <td align="left" bgcolor="#f6f6f6">
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            </td>
      </tr>
      <tr>
        <td align="center">内容：</td>
        
        <td>
            <FCKeditorV2:FCKeditor ID="FCKeditor" Height="480" Width="100%" BasePath="~/Vfckeditor/" runat="server">
            </FCKeditorV2:FCKeditor></td>
      </tr>
      <tr >
        <td bgcolor="#f6f6f6" height="30" align="center">附件：</td>
        <td bgcolor="#f6f6f6"><input type="file" runat="server" name="file1" id="file1" onclick="return file1_onclick()" /></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
            &nbsp;</td>
        <td height="30" align="left" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
        <asp:Button ID="Button1" runat="server" CssClass="button" Text="发布新闻" OnClick="Button1_Click" OnClientClick="return formCheck();" />
            &nbsp;
          <input type="reset" name="Submit2" value="重 置" class="button"/></td>
      </tr>
      
    </table></td>
  </tr>
</table>
</asp:Content>

