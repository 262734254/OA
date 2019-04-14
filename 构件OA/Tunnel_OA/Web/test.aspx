<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<link href="css/Css.css" rel="stylesheet" type="text/css" />
<body>
    <form id="form1" runat="server">
  <div style="width:340px" align="center">
                                <script language="javascript">
                                    var simgUrl = new Array();
                                    var simgLink = new Array();
                                    var slabel = new Array();
                                    
                                    simgUrl[1] = "image/XFSY/xfsy_1.jpg";
                                    simgLink[1] = "";
                                    slabel[1] = "1";

                                    simgUrl[2] = "image/XFSY/xfsy_2.jpg";
                                    simgLink[2] = "";
                                    slabel[2] = "2";

                                    simgUrl[3] = "image/XFSY/xfsy_3.jpg";
                                    simgLink[3] = "";
                                    slabel[3] = "3";

                                    simgUrl[4] = "image/XFSY/xfsy_4.jpg";
                                    simgLink[4] = "";
                                    slabel[4] = "4";

                                    simgUrl[5] = "image/XFSY/xfsy_5.jpg";
                                    simgLink[5] = "";
                                    slabel[5] = "5";

                                    simgUrl[6] = "image/XFSY/xfsy_6.jpg";
                                    simgLink[6] = "";
                                    slabel[6] = "6";

                                    var snum_pic = 6;
                                    var slabel_width = 100 / snum_pic - 2;

                                    var sfocusPicNumSrc = "http://www.chinaz.com/";
                                    var stime1 = 0; //打开页面时等待图片载入的时间，单位为秒，可以设置为0
                                    var stime2 = 10; //图片轮转的间隔时间

                                    var stimeout1 = stime1 * 1000;
                                    var stimeout2 = stime2 * 1000;
                                    var sjumpUrl = '';
                                    var snn = 1; //初始焦点
                                    var scurFileNum = 1; //传递给myPlayer对象 表示目前焦点序列值

                                    document.write('<style>');
                                    document.write('.sfocusPic {border:0px #333333 solid; OVERFLOW: hidden;  WIDTH: 320px; POSITION: relative; HEIGHT: 150px}');
                                    document.write('.sfocusPicNum {Z-INDEX: 99; right: 0px; POSITION: absolute; TOP: 190px;MARGIN: 3px}');
                                    document.write('</style>');
                                    if (navigator.appName == "Microsoft Internet Explorer") {
                                        setTimeout('schange_img()', stimeout1);
                                    }
                                    function schange_img() {
                                        if (snn > snum_pic) snn = 1;
                                        setTimeout('ssetFocus2(' + snn + ')', stimeout1);
                                        snn++;
                                        stt = setTimeout('schange_img()', stimeout2);
                                    }
                                    function ssetFocus2(i) {
                                        sjumpUrl = simgLink[i];
                                        var simgInit = document.getElementById("simgInit");
                                        scurFileNum = i;
                                        sselectLayer1(i);
                                        simgInit.filters.revealTrans.Transition = 23;
                                        simgInit.filters.revealTrans.apply();
                                        splayTran();
                                        document.images.simgInit.src = simgUrl[i];
                                    }
                                    function ssetFocus1(i) {
                                        snn = i;
                                        sln = i;
                                        scurFileNum = i;
                                        sselectLayer1(i);
                                        ssetFocus2(i);
                                    }
                                    function sselectLayer1(i) {
                                        for (a = 1; a < snum_pic + 1; a++) {
                                            //document.images['fi_'+a].src=focusPicNumSrc+'/bn_focus_num_ws_0'+a+'off.gif';
                                            //document.getElementById('label_'+id).class='sty20';
                                            var obj = sGetObj('slabel_' + a);
                                            obj.className = 'ssty20';
                                            obj.style.width = slabel_width;
                                        }
                                        //document.images['fi_'+i].src=focusPicNumSrc+'/bn_focus_num_ws_0'+i+'on.gif';
                                        //	document.getElementById('label_'+id).class='sty21';
                                        var obj = sGetObj('slabel_' + i);
                                        obj.className = 'ssty21';
                                        obj.style.width = slabel_width;
                                    }
                                    function sgoUrl() {
                                        sln = snn;
                                        if (sln == 1) if (sjumpUrl != '') sjumpUrl = simgLink[ln];
                                        sjumpTarget = '_blank';
                                        if (sjumpUrl != '') {
                                            if (sjumpTarget != '') window.open(sjumpUrl, sjumpTarget);
                                            else location.href = sjumpUrl;
                                        }
                                    }

                                    function splayTran() {
                                        var simgInit = document.getElementById("simgInit");
                                        if (document.all) simgInit.filters.revealTrans.play();
                                    }
                                    function sGetObj(objName) {
                                        if (document.getElementById) {
                                            return eval('document.getElementById("' + objName + '")');
                                        } else if (document.layers) {
                                            return eval("document.layers['" + objName + "']");
                                        } else {
                                            return eval('document.all.' + objName);
                                        }
                                    } 

                                </script>

                                <div class="sfocusPic" id="sfocusPic">

                                    <script language="JavaScript">
<!--
                                        document.write('<DIV class=sfocusPicNum style=display:none>');
                                        for (i = 1; i < snum_pic + 1; i++) {
                                            document.write('<A href=javascript:ssetFocus1(' + i + ');><IMG height=15 src=' + sfocusPicNumSrc + '/bn_focus_num_ws_0' + i + 'off.gif width=23 border=0 name=sfi_' + i + '></A>');
                                        }
                                        document.write('</DIV>');
                                        document.write('<div id="spage_left_1">');
                                        document.write('<img src="' + simgUrl[1] + '" width=100%  id="simgInit" name=simgInit height="150" border="0" style="FILTER: revealTrans(duration=0.8,transition=6)">');
                                        document.write('</div>');
                                        document.images.simgInit.src = simgUrl[1];

//-->
                                    </script>

                                </div>
                                <div class="schinaz">

                                    <script language="javascript">
<!--
                                        for (i = 1; i < snum_pic + 1; i++)
                                            document.write('<div class="ssty20" style="width:' + slabel_width + '" id="slabel_' + i + '" onMouseOver="ssetFocus1(' + i + ')"><div id="spage_left_2_1_1">' + slabel[i] + '</div></div>');
-->
                                    </script>
                                </div>
                                </div>
    </form>
</body>
</html>
