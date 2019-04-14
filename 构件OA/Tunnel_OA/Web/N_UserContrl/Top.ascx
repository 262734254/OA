<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Top.ascx.cs" Inherits="N_UserContrl_Top" %>
<table width="1024"  border="0" cellpadding="0" cellspacing="0">
	   <tr><td width="307"><img src="/images/TOPL.gif" width="307" height="62" /></td>
	   <td width="820" style="background-image:url('/images/TOPM.gif'); background-repeat:repeat-x;"></td>
	   <td width="157" valign="bottom" style="background:url(/images/TOPR.gif) no-repeat"><table width="100%" height="30" border="0" cellpadding="0" cellspacing="0">
         <tr>
           <td width="95%" height="30" valign="bottom" style="color:#FFFFFF"></td>
         </tr>
         <tr>
           <td height="30" style="color:#FFFFFF"></td>
         </tr>
       </table></td>
  </tr>
</table>
<table class="titleFont" width="100%" cellpadding="0" cellspacing="0" border="0"
    style="background: url(/images/topmenubak.gif) repeat-x;" height="28">
    <tr valign="middle">
        <td align="center">
            <table id="top-zi"  width="95%" cellpadding="0" cellspacing="0"
                border="0" style="background: url(/images/topmenubak.gif) repeat-x;" height="28">
                <tr valign="middle">
                    <td class="menus" onclick="showclass(this,1)" id="menu1" align="left">
                        &nbsp;<a href="#" onclick="ShowMenu('/Index.aspx')" style="font-size: 14px; position: relative;
                            padding-left: 4px; font-weight: bold;">首页</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,2)" id="menu2">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/dgt.aspx')" style="position: relative; color">党工团</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,3)" id="menu3">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/zgh.aspx')" style="position: relative;">总工室</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,4)" id="menu4">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/zjl.aspx')" style="position: relative;">办公室</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,5)" id="menu5">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/dszc.aspx')" style="position: relative;">质量安全</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,6)" id="menu6">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/gbbg.aspx')" style="position: relative;">经营计划</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,7)" id="menu7">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/gcgl.aspx')" style="position: relative;">资产设备</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,8)" id="menu8">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/jyjh.aspx')" style="position: relative;">材料管理</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,9)" id="menu9">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/rlzyb.aspx')" style="position: relative;">综合管理</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td style="width:100px" class="menus" onclick="showclass(this,13)" id="menu13" onmouseout="richContext(event,3)" onmouseover="richContext(event,1)">
                        <div width="110px" id="contextobox" style="position: relative; font-size: 12px; font-weight: bold; padding-top:-10px;z-index: 999;">
                            厂(基地)项经部
                            <div style="width: 140px; display: none; position: absolute;  left:-23px; top: 20px;z-index: 999;" id="son">
                                <table  width="100%" border="0" cellpadding="0" cellspacing="0" id="" style="font-size: 12px;
                                    color: #368cb5; background-color: #e3f4fb; color: #000; border: 1px #1778a9 solid;
                                    border-top: none; font-weight: normal">
                                    <tr>
                                        <td valign="top" style="width:50%">
                                            <br />
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" id="sontable" style="font-size: 12px;
                                                color: #368cb5; background-color: #e3f4fb; color: #000; border: 1px #1778a9 solid;
                                                border-top: none; font-weight: normal;border-right:0px;border-left:0px;border-bottom:0px">
                                                <tr>
                                                    <td height="30" align="left" bgcolor="#e3f4fb" style="cursor: pointer; color: #0e74a5">
                                                        <asp:Repeater ID="Repeat2" runat="server" DataSourceID="SqlData">
                                                            <ItemTemplate>
                                                                <table border="0" width="100%" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td height="30" align="left" bgcolor="#e3f4fb" style="cursor: pointer; color: #0e74a5" onclick="location='<%#Eval("url") %>?bum_id=<%#Eval("id") %>'">
                                                                            &nbsp;&nbsp;
                                                                            <img src="/images/arra.gif" />
                                                                            <%#Eval("typename") %>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <asp:SqlDataSource ID="SqlData" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                                            SelectCommand="SELECT [id], [typename], [url] FROM [Tunnel_xjbType] WHERE IsStop='N'">
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                    <td width="30px">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
