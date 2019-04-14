<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Top3.ascx.cs" Inherits="N_UserContrl_Top" %>
<table width="1024" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                width="1024" height="62">
                <param name="movie" value="/css/fla6.swf">
                <param name="quality" value="high">
                <embed src="/css/fla6.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                    type="application/x-shockwave-flash" width="1024" height="62"></embed>
            </object>
        </td>
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
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/zjl.aspx')" style="position: relative;">总经理办公室</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,5)" id="menu5">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/rlzyb.aspx')" style="position: relative;">人力资源部</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,6)" id="menu6">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/jyjh.aspx')" style="position: relative;">经营计划部</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,7)" id="menu7">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/zcgl.aspx')" style="position: relative;">资产管理部</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,8)" id="menu8">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/gcgl.aspx')" style="position: relative;">工程管理部</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,9)" id="menu9">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/aqgl.aspx')" style="position: relative;">安全管理部</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,10)" id="menu10">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/xxgl.aspx')" style="position: relative;">信息管理中心</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td class="menus" onclick="showclass(this,11)" id="menu11">
                        &nbsp;<a href="#" onclick="ShowMenu('/N_Index/gbbg.aspx')" style="position: relative;">贯标办公室</a>
                    </td>
                    <td valign="middle" width="3">
                        <img src="/images/line.gif" />
                    </td>
                    <td style="width:100px" class="menus" onclick="showclass(this,13)" id="menu13" onmouseout="richContext(event,3)"
                        onmouseover="richContext(event,1)">
                        <div id="contextobox" style="position: relative; font-size: 13px; font-weight: bold; padding-top:-10px;z-index: 999;">
                            项目经理部
                            <div style="width: 145px; display: none; position: absolute; left: -48px; _left:-63px;top: 20.5px;
                                z-index: 999" id="son">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" id="sontable" style="font-size: 12px;
                                    color: #368cb5; background-color: #e3f4fb; color: #000; border: 1px #1778a9 solid;
                                    border-top: none; font-weight: normal">
                                    <tr>
                                        <td height="30" align="left" bgcolor="#e3f4fb" style="cursor: pointer; color: #0e74a5"
                                            onclick="location='/N_Index/xjb.aspx?bum_id=100'">
                                            &nbsp;&nbsp;<img src="/images/arra.gif" />
                                            郑州地铁04合同段
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="left" bgcolor="#e3f4fb" style="cursor: pointer; color: #0e74a5"
                                            onclick="location='/N_Index/xjb.aspx?bum_id=89'">
                                            &nbsp;&nbsp;<img src="/images/arra.gif" />
                                            杭州1号线地铁
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="left" bgcolor="#e3f4fb" style="cursor: pointer; color: #0e74a5"
                                            onclick="location='/N_Index/xjb.aspx?bum_id=108'">
                                            &nbsp;&nbsp;<img src="/images/arra.gif" />
                                            宁波地铁
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="left" bgcolor="#e3f4fb" style="cursor: pointer; color: #0e74a5"
                                            onclick="location='/N_Index/xjb.aspx?bum_id=99'">
                                            &nbsp;&nbsp;<img src="/images/arra.gif" />
                                            11.G.8标
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="left" bgcolor="#e3f4fb" style="cursor: pointer; color: #0e74a5"
                                            onclick="location='/N_Index/xjb.aspx?bum_id=109'">
                                            &nbsp;&nbsp;<img src="/images/arra.gif" />
                                            11号线南段6标
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="left" bgcolor="#e3f4fb" style="cursor: pointer; color: #0e74a5"
                                            onclick="location='/N_Index/xjb.aspx?bum_id=90'">
                                            &nbsp;&nbsp;<img src="/images/arra.gif" />
                                            杭州钱江通道
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="left" bgcolor="#e3f4fb" style="cursor: pointer; color: #0e74a5"
                                            onclick="location='/N_Index/xjb.aspx?bum_id=95'">
                                            &nbsp;&nbsp;<img src="/images/arra.gif" />
                                            迎宾三路隧道
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="left" bgcolor="#e3f4fb" style="cursor: pointer; color: #0e74a5"
                                            onclick="location='/N_Index/xjb.aspx?bum_id=107'">
                                            &nbsp;&nbsp;<img src="/images/arra.gif" />
                                            香港污水处理工程
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="left" bgcolor="#e3f4fb" style="cursor: pointer; color: #0e74a5"
                                            onclick="location='/N_Index/xjb.aspx?bum_id=97'">
                                            &nbsp;&nbsp;<img src="/images/arra.gif" />
                                            华能汕头电厂工程
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                    <td width="20px">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
