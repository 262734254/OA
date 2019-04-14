<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_Factory.aspx.cs" Inherits="N_News_N_Performance_N_Factory"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">

    <script type="text/javascript" src="../../javascript/Calendarform.js"></script>

    <script type="text/javascript" src="../../javascript/utility.js"></script>

    <script type="text/javascript" src="../../javascript/jquery-1.3.2.min.js"></script>

    <script src="../../javascript/IframeReSize.js" type="text/javascript"></script>

    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

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
    function disup(){
        $("#fileup").toggle($("#fileup").css('display') == 'none');
    }
    var inputid=1;
    function shiws(obj){
        var path=obj.value;
        if(document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value.indexOf(path)>=0)
        {
            $(obj).val("");
            alert("己经添加过该文件了");            
        }else{
            var index=path.lastIndexOf('\\');
            var filename=path.substring(index+1,path.length); 
            var reg=/\\/g;
            document.getElementById("Label3").innerHTML+="<span><img src=\"../../image/attach.png\">"+filename+"<img style='cursor:hand' onclick=\"del(this,'"+path.replace(reg,"\\\\")+"','File"+inputid+"')\" alt='删除附件' src=\"../../image/remove.png\">;</span>";
            inputid++;
            $("#inputq").append(CreateFileEl("File"+inputid,obj.onchange));
            $(obj).hide();
            document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value+=path+",";
            //alert(document.getElementById("HiddenField1").value);
        }
    }
    function del(obj,path,input){
        //alert(path);
        var h_path=document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value;
        h_path=h_path.replace(path+",",'');
        document.getElementById("ctl00_ContentPlaceHolder1_HiddenField1").value=h_path;
        $("#"+input).remove();
        $(obj).parents("span").remove();
    }
    function delp(obj){
        $(obj).parent("div").remove();
    }
    function CreateFileEl(id,onchange)
    {   
       var attach=document.createElement("input");
       attach.type="file";
       attach.className="butt";
       attach.name=id;
       attach.id=id;
       attach.size=20;
       attach.hideFocus="true";
       attach.onchange=onchange;
       return attach;
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

    <style type="text/css">
        .style1
        {
            height: 30px;
        }
        .button
        {
            height: 26px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
 <%--    <td width="74" id="Td2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_SectionAdd.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">科室考核</div></a></td>--%>
    <td width="74" id="Td1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_SectionAdd.aspx" class="a">
    <div style="width:74px; height:27px; cursor:pointer;">分厂考核</div></a></td>
  <%--  <td width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_ManagementSection.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">管理科室</div></a></td>--%>
    <td width="74" id="icon4" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_ManagFactory.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">管理分厂</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
</table> 
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      <tr>
        <td width="50" height="70" align="center" bgcolor="#f6f6f6">标题：</td>
        <td align="left" bgcolor="#f6f6f6"><asp:TextBox runat="server" ID="tb_Title" TextMode="MultiLine" 
                Width="70%"  onkeyup="javascrip:checkWord(200,event,'ctl00_ContentPlaceHolder1_lbl1')" Height="35px"></asp:TextBox>&nbsp;<br /><asp:Label ID="lbl1" runat="server" Font-Size="12px"   Text="0/200"></asp:Label></td>
      </tr>                
     <tr>
                        <td height="30" width="80" align="center" bgcolor="#f6f6f6">
                            附件：
                        </td>
                        <td bgcolor="#f6f6f6">
                            <table border="0" align="center" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" colspan="2" rowspan="1" class="style1">
                                        <div id="label3">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <font style="color: blue; cursor: pointer" onclick="disup()">+添加附件&nbsp;</font>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </td>
                                </tr>
                                <tr id="fileup" style="display: none">
                                    <td align="left" colspan="2" rowspan="1" id="inputq" style="height: 30px;">
                                        <input id="File1" name="File1" type="file" onchange="shiws(this)" class="butt" />
                                        <asp:Label runat="server" ID="lblFileInfo" ForeColor="Red" Text=""></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
      <tr>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
        <td height="30" align="left" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
        <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="发布" 
                OnClick="BtnAdd_Click" />
          &nbsp;
          <input type="reset" name="btnSubmit" value="重 置" class="button"/></td>

      </tr>
      
    </table></td>
  </tr>
</table>
</asp:Content>

