//Constants.
SEP_PADDING = 5
HANDLE_PADDING = 7

var yToolbars = new Array();  
var YInitialized = false;

function document.onreadystatechange() {
  if (YInitialized) return;
  YInitialized = true;

  var i, s, curr;

  for (i=0; i<document.body.all.length; i++) {
    curr=document.body.all[i];
    if (curr.className == "yToolbar") {
      if (! InitTB(curr)) {
        alert("工具栏: " + curr.id + " 初始化失败. 状态: false");
      }
      yToolbars[yToolbars.length] = curr;
    }
  }

  DoLayout();
  window.onresize = DoLayout;

  initHTML=bodyTag;
  initEditor();
  Composition.document.body.innerText=''
  Composition.document.body.innerHTML=''
}

function InitBtn(btn) {
  btn.onmouseover = BtnMouseOver;
  btn.onmouseout = BtnMouseOut;
  btn.onmousedown = BtnMouseDown;
  btn.onmouseup = BtnMouseUp;
  btn.ondragstart = YCancelEvent;
  btn.onselectstart = YCancelEvent;
  btn.onselect = YCancelEvent;
  btn.YUSERONCLICK = btn.onclick;
  btn.onclick = YCancelEvent;
  btn.YINITIALIZED = true;
  return true;
}

function InitTB(y) {
  y.TBWidth = 0;
    
  if (! PopulateTB(y)) return false;
  
  y.style.posWidth = y.TBWidth;
  
  return true;
}


function YCancelEvent() {
  event.returnValue=false;
  event.cancelBubble=true;
  return false;
}

function BtnMouseOver() {
  if (event.srcElement.tagName != "IMG") return false;
  var image = event.srcElement;
  var element = image.parentElement;
  
  // Change button look based on current state of image.
  if (image.className == "Ico") element.className = "BtnMouseOverUp";
  else if (image.className == "IcoDown") element.className = "BtnMouseOverDown";

  event.cancelBubble = true;
}

function BtnMouseOut() {
  if (event.srcElement.tagName != "IMG") {
    event.cancelBubble = true;
    return false;
  }

  var image = event.srcElement;
  var element = image.parentElement;
  yRaisedElement = null;
  
  element.className = "Btn";
  image.className = "Ico";

  event.cancelBubble = true;
}

function BtnMouseDown() {
  if (event.srcElement.tagName != "IMG") {
    event.cancelBubble = true;
    event.returnValue=false;
    return false;
  }

  var image = event.srcElement;
  var element = image.parentElement;

  element.className = "BtnMouseOverDown";
  image.className = "IcoDown";

  event.cancelBubble = true;
  event.returnValue=false;
  return false;
}

function BtnMouseUp() {
  if (event.srcElement.tagName != "IMG") {
    event.cancelBubble = true;
    return false;
  }

  var image = event.srcElement;
  var element = image.parentElement;

  if (element.YUSERONCLICK) eval(element.YUSERONCLICK + "anonymous()");

  element.className = "BtnMouseOverUp";
  image.className = "Ico";

  event.cancelBubble = true;
  return false;
}

function PopulateTB(y) {
  var i, elements, element;

  // Iterate through all the top-level elements in the toolbar
  elements = y.children;
  for (i=0; i<elements.length; i++) {
    element = elements[i];
    if (element.tagName == "SCRIPT" || element.tagName == "!") continue;
    
    switch (element.className) {
    case "Btn":
      if (element.YINITIALIZED == null) {
		if (! InitBtn(element)) {
		  alert("Problem initializing:" + element.id);
		  return false;
		}
      }
      
      element.style.posLeft = y.TBWidth;
      y.TBWidth += element.offsetWidth + 1;
      break;
      
    case "TBGen":
      element.style.posLeft = y.TBWidth;
      y.TBWidth += element.offsetWidth + 1;
      break;
      
    case "TBSep":
      element.style.posLeft = y.TBWidth + 2;
      y.TBWidth += SEP_PADDING;
      break;
      
    case "TBHandle":
      element.style.posLeft = 2;
      y.TBWidth += element.offsetWidth + HANDLE_PADDING;
      break;
      
    default:
      alert("Invalid class: " + element.className + " on Element: " + element.id + " <" + element.tagName + ">");
      return false;
    }
  }

  y.TBWidth += 1;
  return true;
}

function DebugObject(obj) {
  var msg = "";
  for (var i in TB) {
    ans=prompt(i+"="+TB[i]+"\n");
    if (! ans) break;
  }
}

function LayoutTBs() {
  NumTBs = yToolbars.length;

  if (NumTBs == 0) return;

  var i;
  var ScrWidth = 660//(document.body.offsetWidth);
  var TotalLen = ScrWidth;
  for (i = 0 ; i < NumTBs ; i++) {
    TB = yToolbars[i];
    if (TB.TBWidth > TotalLen) TotalLen = TB.TBWidth;
  }

  var PrevTB;
  var LastStart = 0;
  var RelTop = 0;
  var LastWid, CurrWid;

  //Set up the first toolbar.
  var TB = yToolbars[0];
  TB.style.posTop = 0;
  TB.style.posLeft = 0;

  //Lay out the other toolbars.
  var Start = TB.TBWidth;
  for (i = 1 ; i < yToolbars.length ; i++) {
    PrevTB = TB;
    TB = yToolbars[i];
    CurrWid = TB.TBWidth;

    if ((Start + CurrWid) > ScrWidth) { 
      //TB needs to go on next line.
      Start = 0;
      LastWid = TotalLen - LastStart;
    } 
    else { 
      //Ok on this line.
      LastWid = PrevTB.TBWidth;
      //RelTop -= TB.style.posHeight;
      RelTop -= TB.offsetHeight;
    }
      
    TB.style.posTop = RelTop;
    TB.style.posLeft = Start;
    PrevTB.style.width = LastWid;

    //Increment counters.
    LastStart = Start;
    Start += CurrWid;
  } 

  TB.style.width = TotalLen - LastStart;
  
  i--;
  TB = yToolbars[i];
  var TBInd = TB.sourceIndex;
  var A = TB.document.all;
  var item;
  for (i in A) {
    item = A.item(i);
    if (! item) continue;
    if (! item.style) continue;
    if (item.sourceIndex <= TBInd) continue;
    if (item.style.position == "absolute") continue;
    item.style.posTop = RelTop;
  }
}

function DoLayout() {
  LayoutTBs();
  
  var TBHeight=0;
  for (i = 0 ; i < yToolbars.length ; i++) {
    TBHeight += yToolbars[i].offsetHeight;
  }

  var bodyHeight=document.body.offsetHeight;
  var divHeight=switchDiv.offsetHeight;
  var objIFrame=document.all.tags("IFRAME")[0];
  //标题
  if (typeof(infoHeader)!='undefined'){
    var tableHeight=infoHeader.offsetHeight;
    objIFrame.height=bodyHeight-tableHeight-TBHeight-divHeight;
  }else{
    objIFrame.height=bodyHeight-TBHeight-divHeight;
  }
}

function validateMode()
{
  if (viewMode=="DESIGN")return true;
  
  alert("请返回到“普通”模式!");
  Composition.focus();
  return false;
}

function format1(what,opt)
{
  if (opt=="removeFormat")
  {
    what=opt;
    opt=null;
  }

  if (opt==null) Composition.document.execCommand(what);
  else Composition.document.execCommand(what,"",opt);

  pureText = false;
  Composition.focus();
}

function format(what,opt)
{
  if (!validateMode()) return;

  format1(what,opt);
}

//Formats text in composition.
function format(what,opt) {
  if (!validateMode()) return;
  
  if (opt=="removeFormat") {
    what=opt;
    opt=null;
  }

  if (opt==null) Composition.document.execCommand(what);
  else {
    Composition.document.execCommand(what,"",opt);
  }
  pureText = false;
  Composition.focus();
}

function doSelectClick(str, el) {
	var Index = el.selectedIndex;
	if (Index != 0){
		el.selectedIndex = 0;
		if (el.id == "specialtype")
			specialtype(el.options[Index].value);
		else
			format(str,el.options[Index].value);
	}
}

var bIsIE5 = navigator.userAgent.indexOf("IE 5")  > -1;
var bIsIE6 = navigator.userAgent.indexOf("IE 6")  > -1;

function selectRange(){
	edit = Composition.document.selection.createRange();
	RangeType =  Composition.document.selection.type;
}

function specialtype(Mark){
	var strHTML;
	if (bIsIE5||bIsIE6) selectRange();	
	if (RangeType == "Text"){
		strHTML = "<" + Mark + ">" + edit.text + "</" + Mark + ">"; 
		edit.pasteHTML(strHTML);
		Composition.focus();
		edit.select();
	}		
}

function getEl(sTag,start) {
  while ((start!=null) && (start.tagName!=sTag)) start = start.parentElement;
  return start;
}

function createLink() {
  if (!validateMode()) return;
  
  var isA = getEl("A",Composition.document.selection.createRange().parentElement());
  var str=prompt("键入超级链接地址 (e.g. http://www.xsp.cn):", isA ? isA.href : "http:\/\/");
  
  if ((str!=null) && (str!="http://")) {
    if (Composition.document.selection.type=="None") {
      var sel=Composition.document.selection.createRange();
      sel.pasteHTML("<A HREF=\""+str+"\">"+str+"</A> ");
      sel.select();
    }
    else format("CreateLink",str);
  }
  else Composition.focus();
}

function createImage() {
  if (!validateMode()) return;
  
  var isA = getEl("A",Composition.document.selection.createRange().parentElement());
  var str=prompt("键入图象的绝对路径 (e.g. http://www.xsp.cn/images/blank.gif):", isA ? isA.href : "http:\/\/");
  
  if ((str!=null) && (str!="http://")) {
    if (Composition.document.selection.type=="None") {
      var sel=Composition.document.selection.createRange();
      sel.pasteHTML("<img src=\""+str+"\">");
      sel.select();
    }
    else format("CreateImage",str);
  }
  else Composition.focus();
}

function insertImage(){//插入图片
  if (!validateMode()) return;
  var objForm=document.forms(0);

  var sURL="./images.php";
  openWindow("",430,500,sURL)
}

function openWindow(name,ww,wh,url){
    var wl=(screen.width) ? (screen.width-ww)/2 : 220;
    var wt=(screen.height) ? (screen.height-wh)/2 : 220;
    var features="resizable=no,scrollbars=no,top="+wt+",left="+wl+",height="+wh+",width="+ww+",status=yes,toolbar=no,menubar=no,location=no";
    window.open(url,name,features);
}

function backColor() {
  if (!validateMode()) return;
  var arr = showModalDialog("selcolor.html", "", "font-family:Verdana; font-size:9pt; dialogWidth:30em; dialogHeight:35em");
  if (arr != null) format('backcolor', arr);
  else Composition.focus()
}

function UserDialog(what)
{
  if (!validateMode()) return;
  
  if (Composition.document.selection.type=="None")
    Composition.focus();
  Composition.document.execCommand(what, true);

  pureText = false;
  Composition.focus();
}

function foreColor()
{
  if (!	validateMode())	return;
  var arr = showModalDialog("document/selcolor.html", "", "dialogWidth:18em; dialogHeight:16em; status:0");
  if (arr != null) format('forecolor', arr);
  else Composition.focus();
}

function fortable()
{
  if (!	validateMode())	return;
  var arr = showModalDialog("document/table.html", "", "dialogWidth:300px; dialogHeight:170px; status:0");
  
  if (arr != null){
  var ss;
  ss=arr.split("*")
  row=ss[0];
  col=ss[1];
  color=ss[2];
  var string;
  string="<table border=0 cellpadding='0' cellspacing='1' bgcolor='"+color+"'>";
  for(i=1;i<=row;i++){
    string=string+"<tr bgcolor='#ffffff'>";
    for(j=1;j<=col;j++){
      string=string+"<td>&nbsp;&nbsp;</td>";
    }
    string=string+"</tr>";
  }
  string=string+"</table>";
  content=Composition.document.body.innerHTML;
  content=content+string;
   Composition.document.body.innerHTML=content;
  }
  else Composition.focus();
}
function cleanHtml() {
  var fonts = Composition.document.body.all.tags("FONT");
  var curr;
  for (var i = fonts.length - 1; i >= 0; i--) {
    curr = fonts[i];
    if (curr.style.backgroundColor == "#ffffff") curr.outerHTML = curr.innerHTML;
  }
}

function getPureHtml() {
  var str = "";
  var paras = Composition.document.body.all.tags("P");
  if (paras.length > 0) {
    for (var i=paras.length-1; i >= 0; i--) str = paras[i].innerHTML + "\n" + str;
  } else {
    str = Composition.document.body.innerHTML;
  }
  return str;
}

function swapModes(Mode) {
	switch(Mode){
		case 1:	//普通
			if (viewMode == "HTML"){
				Composition.document.body.innerHTML = Composition.document.body.innerText;
				Composition.document.body.style.fontFamily = "";
				Composition.document.body.style.fontSize ="";
			}else{
				initHTML = Composition.document.body.innerHTML;
				initEditor();
			}
			viewMode = "DESIGN";
			break;	
		case 2:	//HTML
			if (viewMode == "PREVIEW"){
				initHTML = Composition.document.body.innerHTML;
				initEditor();
			}	
			Composition.document.body.innerText = Composition.document.body.innerHTML;
			Composition.document.body.style.fontFamily = "Verdana";
			Composition.document.body.style.fontSize = "9pt";
			viewMode = "HTML";
			break;
		case 3:	//预览
			var strHTML = "";
			if(viewMode == "HTML"){
				strHTML = Composition.document.body.innerText;
				Composition.document.body.style.fontFamily = "";
				Composition.document.body.style.fontSize ="";				
			}else{
				strHTML = Composition.document.body.innerHTML;				
			}			
			Composition.document.designMode="Off";
			Composition.document.open();
			Composition.document.write(strHTML);
			Composition.document.close();
			if(Composition.document.styleSheets.length == 0){
				Composition.document.createStyleSheet();
				var oSS = Composition.document.styleSheets[0];
				oSS.addRule("IMG","border: 0");
				oSS.addRule("TABLE","font-size: 9pt;");
				oSS.addRule("BODY","font-size: 9pt;");
			}
			viewMode = "PREVIEW";
			break;
	}
	Composition.focus();
}

function initEditor() {
	Composition.document.designMode="On";
	Composition.document.open();
	Composition.document.write(initHTML);
	Composition.document.close();
	
  initHTML = "";
	if(Composition.document.styleSheets.length == 0){
		Composition.document.createStyleSheet();
		var oSS = Composition.document.styleSheets[0];
		oSS.addRule("IMG","border: 0");
		oSS.addRule("TABLE","font-size: 9pt;");
		oSS.addRule("BODY","font-size: 9pt");
	}	
  Composition.focus();
}

function switchstatus(flag){
  swapModes(flag);

  for(var i=1;i<4;i++){
    document.all["status" + i].style.display = "none";
  }
  document.all["status" + flag].style.display = "block";
}


function openImageList(href) {
    var newwin=window.open(href,"","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=240,height=400");
    return;
}

function receive9(which) {
Format1('pic','',which);
}


function Popupnew(href) {
	window.open(href, "","toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,border=0,width=269,height=230");
	
}	
