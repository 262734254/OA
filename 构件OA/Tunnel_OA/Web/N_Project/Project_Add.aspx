<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Project_Add.aspx.cs" Inherits="N_Project_Project_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">

<script src="/javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
       <script type="text/javascript" language="javascript">
           var close = true;
           function sreachname(obj) {
               var nkey = obj.value;
               if ("" == nkey || null == nkey) {
                   document.getElementById("result_id").style.display = "none";
               }
               else {
                   //html 为ajax请求 返回的 字符串
                   var html = $.get("/javascript/Get_XiangUser.ashx?Uname=" + nkey, null, null);
                   document.getElementById("result_id").style.display = "";
                   if (html == "") {
                       document.getElementById("result_id").innerHTML = "没有找到相关主记录";
                   } else {
                       document.getElementById("result_id").innerHTML = html;
                   }
               }
           }
           function showname(id, name) {
               document.getElementById("ctl00_ContentPlaceHolder1_tb_Title8").value = name;
               document.getElementById("ctl00_ContentPlaceHolder1_tb_value").value = id;
               document.getElementById("result_id").style.display = "none";
           }

           function hidename() {
               document.getElementById("result_id").style.display = "none";
           }
    function formCheck()
    {
        var title  = document.getElementById("ctl00_ContentPlaceHolder1_tb_Title");
        var title0 = document.getElementById("ctl00_ContentPlaceHolder1_tb_Title0");
        var title1 = document.getElementById("ctl00_ContentPlaceHolder1_tb_Title1");
        var title2 = document.getElementById("ctl00_ContentPlaceHolder1_tb_Title2");
        var title3 = document.getElementById("ctl00_ContentPlaceHolder1_tb_Title3");
        var title4 = document.getElementById("ctl00_ContentPlaceHolder1_tb_Title4");
        var title5 = document.getElementById("ctl00_ContentPlaceHolder1_tb_Title5");
        var title6 = document.getElementById("ctl00_ContentPlaceHolder1_tb_Title6");
        if(title.value.length==0)
        {
            alert("项目名称不能为空!");title.focus();return false;
        }
        if (title0.value.length==0) {
            alert("项经部名称不能为空!"); title0.focus(); return false;
        }
        if (title1.value.length == 0) {
            alert("项目启动时间不能为空!"); title1.focus(); return false;
        }
        if (title1.value.length == 0) {
            alert("人员需求计划提交时间不能为空!"); title1.focus(); return false;
        }
        if (title2.value.length == 0) {
            alert("合同签订计划提交时间不能为空!"); title2.focus(); return false;
        }
        if (title3.value.length == 0) {
            alert("设备需求计划提交时间不能为空!"); title3.focus(); return false;
        }
        if (title4.value.length == 0) {
            alert("材料进场计划提交时间不能为空!"); title4.focus(); return false;
        }
        if (title5.value.length == 0) {
            alert("施工方案编制计划不能为空!"); title5.focus(); return false;
        }
        if (title6.value.length == 0) {
            alert("安全申报计划提交时间不能为空!"); title6.focus(); return false;
        }
    }
    </script>
    <script src="../../javascript/Calendarform.js" type="text/javascript"></script>
    <script src="../../javascript/utility.js" type="text/javascript"></script>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 163px;
            text-align:right
        }
        .style2
        {
            width: 163px;
            text-align: right;
            height: 30px;
        }
        .style3
        {
            height: 30px;
        }
    </style>
<style type="text/css">
#search_id{font-size:12px; color:#333333}
#search_id div{ float:left}
#search_body{ border:1px solid #999999; padding-top:0px; width:240px; position:relative}
#search_body input{margin-top:0px;}
#search_body #ctl00_ContentPlaceHolder1_tb_Title8{border:0px;width:236px;}
#result_id{ padding-top:0px; width:100%; position:absolute;border:1px solid #999999; border-top:none;width:240px; background:#ffffff;top:21px; left:-1px;}
#result_id table{ width:100%; }
#result_id table tr td:hover{background-color:#FF9999; cursor:pointer }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="Project_Add.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">新建项目</div></a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Project_Manage.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">管理项目</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
    
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      <tr>
        <td height="30" align="center" class="style1">项目名称：</td>
        <td><asp:TextBox runat="server" ID="tb_Title" 
                onkeyup="javascrip:checkWord(100,event,'ctl00_ContentPlaceHolder1_lbl1')" 
                Width="300px"></asp:TextBox>&nbsp;<asp:Label ID="lbl1" runat="server" Font-Size="12px"   Text="0/100"></asp:Label></td>
      </tr>
      <tr>
        <td align="center" height="30" bgcolor="#f6f6f6" class="style1">项经部名称：</td>
        
        <td bgcolor="#f6f6f6">
            <asp:TextBox runat="server" ID="tb_Title0" 
                onkeyup="javascrip:checkWord(50,event,'ctl00_ContentPlaceHolder1_Label1')" 
                Width="235px"></asp:TextBox>&nbsp;<asp:Label ID="Label1" runat="server" Font-Size="12px"   Text="0/50"></asp:Label>(下拉菜单显示名称)</td>
      </tr>
      <tr>
        <td align="center" height="30" class="style1">项目经理：</td>
        
        <td>
   <div id="search_body">
            <asp:TextBox runat="server" onkeyup="sreachname(this)" onblur="hidename()" ID="tb_Title8"></asp:TextBox><asp:HiddenField
                ID="tb_value" runat="server" />
       <div id="result_id" style="display:none"></div>
   </div>
            </td>
      </tr>
      <tr>
        <td align="center" bgcolor="#f6f6f6" class="style2">项目启动时间：</td>
        
        <td bgcolor="#f6f6f6" class="style3">
            <asp:TextBox runat="server" ID="tb_Title1" Width="80px"></asp:TextBox><img style="cursor:pointer" src="../../image/icon5.gif" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_tb_Title1')"/></td>
      </tr>
      <tr>
        <td align="center" height="30" class="style1">人员需求计划提交时间：</td>
        
        <td>
            <asp:TextBox runat="server" ID="tb_Title2"  Width="80px"></asp:TextBox><img style="cursor:pointer" src="../../image/icon5.gif" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_tb_Title2')"/></td>
      </tr>
      <tr>
        <td bgcolor="#f6f6f6" align="center" height="30" class="style1">合同签订计划提交时间：</td>
        
        <td bgcolor="#f6f6f6">
            <asp:TextBox runat="server" ID="tb_Title3" Width="80px"></asp:TextBox><img style="cursor:pointer" src="../../image/icon5.gif" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_tb_Title3')"/></td>
      </tr>
      <tr>
        <td align="center" height="30" class="style1">设备需求计划提交时间：</td>
        <td>
            <asp:TextBox runat="server" ID="tb_Title4" Width="80px"></asp:TextBox><img style="cursor:pointer" src="../../image/icon5.gif" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_tb_Title4')"/></td>
      </tr>
      <tr>
        <td bgcolor="#f6f6f6"  align="center" height="30" class="style1">材料进场计划提交时间：</td>
        <td bgcolor="#f6f6f6">
            <asp:TextBox runat="server" ID="tb_Title5" Width="80px"></asp:TextBox><img style="cursor:pointer" src="../../image/icon5.gif" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_tb_Title5')"/></td>
      </tr>
      <tr>
        <td align="center" height="30" class="style1">施工方案编制计划提交时间：</td>
        <td>
            <asp:TextBox runat="server" ID="tb_Title6" Width="80px"></asp:TextBox><img style="cursor:pointer" src="../../image/icon5.gif" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_tb_Title6')"/></td>
      </tr>
       <tr>
        <td bgcolor="#f6f6f6" align="right" height="30" class="style1">安全申报计划提交时间：</td>
        <td bgcolor="#f6f6f6">
            <asp:TextBox runat="server" ID="tb_Title7" Width="80px"></asp:TextBox><img style="cursor:pointer" src="../../image/icon5.gif" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_tb_Title7')"/></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#e6f7ff" 
              style="border-bottom:1px #6f97b1 solid" class="style1">&nbsp;</td>
        <td height="30" align="left" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
        <asp:Button ID="Button1" runat="server" CssClass="button" Text="新建项目" 
                OnClick="Button1_Click" OnClientClick="return formCheck();" />
          &nbsp;
          <input type="reset" name="Submit2" value="重 置" class="button"/></td>
      </tr>
      
    </table></td>
  </tr>
</table>
</asp:Content>