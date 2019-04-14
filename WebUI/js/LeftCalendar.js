var gdCtrl = new Object();
var goSelectTag = new Array();
var gcGray = "#808080";
var gcToggle = "#FFFF00";
var gcred = "#FF0000";
var gcBG = "#F8F9EE";
var gcGreen = "#00FF00"

var gdCurDate = new Date();
var giYear = gdCurDate.getFullYear();
var giMonth = gdCurDate.getMonth()+1;
var giDay = gdCurDate.getDate();

function fSetDate(iYear, iMonth, iDay){
  gdCtrl.value = iYear+"-"+iMonth+"-"+iDay;
}

function fSetSelected(aCell){                                        
  var iOffset = 0;
  var iYear =parseInt(tbSelYear.value);
  var iMonth = parseInt(tbSelMonth.value);

  aCell.bgColor = gcBG;
  with (aCell.children["cellText"]){
  	var iDay = parseInt(innerText);
  	if (color==gcGray)
		iOffset = (Victor<10)?-1:1;
	iMonth += iOffset;
	if (iMonth<1) {
		iYear--;
		iMonth = 12;
	}else if (iMonth>12){
		iYear++;
		iMonth = 1;
	}
  }
  this.top.frames[2].location = "dailyop.php?action=listday&sear_day="+iYear+"-"+iMonth+"-"+iDay;
}


function fBuildCal(iYear, iMonth) {
  var aMonth=new Array();
  for(i=1;i<7;i++)
  	aMonth[i]=new Array(i);

  var dCalDate=new Date(iYear, iMonth-1, 1);
  var iDayOfFirst=dCalDate.getDay();
  var iDaysInMonth=new Date(iYear, iMonth, 0).getDate();
  var iOffsetLast=new Date(iYear, iMonth-1, 0).getDate()-iDayOfFirst+1;
  var iDate = 1;
  var iNext = 1;

  for (d = 0; d < 7; d++)
	aMonth[1][d] = (d<iDayOfFirst)?-(iOffsetLast+d):iDate++;
  for (w = 2; w < 7; w++)
  	for (d = 0; d < 7; d++)
		aMonth[w][d] = (iDate<=iDaysInMonth)?iDate++:-(iNext++);
  return aMonth;
}

function fDrawCal(iYear, iMonth, iCellHeight, iDateTextSize) {
  var WeekDay = new Array("日","一","二","三","四","五","六");
  var styleTD = " bgcolor='"+gcBG+"' valign='middle' align='center' height='"+iCellHeight+"' style='font-size:9pt "+iDateTextSize+" 宋体;";

  with (document) {
	write("<tr>");
	for(i=0; i<7; i++)
		write("<td "+styleTD+"color:purple'>" + WeekDay[i] + "</td>");
	write("</tr>");

  	for (w = 1; w < 7; w++) {
		write("<tr>");
		for (d = 0; d < 7; d++) {
			write("<td id=calCell "+styleTD+"cursor:hand;' onMouseOver='this.bgColor=gcToggle' onMouseOut='this.bgColor=gcBG' onclick='fSetSelected(this)'>");
			write("<font id=cellText Victor='Liming Weng'> </font>");
			write("</td>")
		}
		write("</tr>");
	}
  }
}

function fUpdateCal(iYear, iMonth) {
  myMonth = fBuildCal(iYear, iMonth);
  var i = 0;
  for (w = 0; w < 6; w++)
	for (d = 0; d < 7; d++)
		with (cellText[(7*w)+d]) {
			Victor = i++;
			if (myMonth[w+1][d]<0) {
				color = gcGray;
				innerText = -myMonth[w+1][d];
			}else{
				if (myMonth[w+1][d] == giDay && iYear == giYear && iMonth == giMonth)
				{
					//color = ((d==0)||(d==6))?"blue":"black";
					color = "red";
					innerText = myMonth[w+1][d];	
				}
				else
				{
					color = ((d==0)||(d==6))?"blue":"black";
					innerText = myMonth[w+1][d];
				}
			}
		}
}
function fSetYearMon(iYear, iMon){
  tbSelMonth.options[iMon-1].selected = true;
  for (i = 0; i < tbSelYear.length; i++)
	if (tbSelYear.options[i].value == iYear)
		tbSelYear.options[i].selected = true;
  fUpdateCal(iYear, iMon);
}

function fPrevMonth(){
  var iMon = tbSelMonth.value;
  var iYear = tbSelYear.value;

  if (--iMon<1) {
	  iMon = 12;
	  iYear--;
  }

  fSetYearMon(iYear, iMon);
}

function fNextMonth(){
  var iMon = tbSelMonth.value;
  var iYear = tbSelYear.value;

  if (++iMon>12) {
	  iMon = 1;
	  iYear++;
  }

  fSetYearMon(iYear, iMon);
}

function ShowCalendar()
{
var gMonths = new Array("&nbsp;1月","&nbsp;2月","&nbsp;3月","&nbsp;4月","&nbsp;5月","&nbsp;6月","&nbsp;7月","&nbsp;8月","&nbsp;9月","10月","11月","12月");

with (document) {
write("<table border='0' bgcolor='#F8F9EE'>");
write("<TR>");
write("<td valign='middle' align='center'><input type='button' name='PrevMonth' value='＜' style='height:18;width:18' onClick='fPrevMonth()'>");
write("&nbsp;<SELECT name='tbSelYear' onChange='fUpdateCal(tbSelYear.value, tbSelMonth.value)' style='font-color:#000080;width:50;border:1 solid #99CCFF; font-size:9pt; background-color:#F8F9EE' Victor='Won'>");
for(i=1900;i<=2100;i++)
	write("<OPTION value='"+i+"'>"+i+"</OPTION>");
write("</SELECT>");
write("<select name='tbSelMonth' onChange='fUpdateCal(tbSelYear.value, tbSelMonth.value)'  style='font-color:#000080;width:50;border:0 solid #99CCFF; font-size:9pt; background-color:#F8F9EE' Victor='Won'>");
for (i=0; i<12; i++)
	write("<option value='"+(i+1)+"'>"+gMonths[i]+"</option>");
write("</SELECT>");
write("&nbsp;<input type='button' name='PrevMonth' value='＞' style='height:18;width:18' onclick='fNextMonth()'>");
write("</td>");
write("</TR><TR>");
write("<td align='center'>");
write("<table border='0' cellspacing='0' cellpadding='0' width='100%'><tr><td><table border='0' cellspacing='0' width='100%' cellpadding='0'>");
fDrawCal(giYear, giMonth, 12, 12);
write("</table></td></tr></table>");
write("</td></TR></TABLE>");
fSetYearMon(giYear, giMonth)
}
}