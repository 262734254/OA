function InputDateTimeCompare(datFromDate,datEndDate,blnCompareFlag)
{
    var intFromYear,intFromMonth,intFromDay,intFromHour,intFromMinute;    //开始时间的整型变量
	var intEndYear,intEndMonth,intEndDay,intEndHour,intEndMinute;         //结束时间的整型变量
	var firstflag,secondflag;                                             //分别记录日期中的第一个和第二个“-”的位置 
	var datestringFrom = new String(datFromDate);
	var datestringEnd =  new String(datEndDate);
	
	firstflag = datestringFrom.indexOf("-");                           
	intFromYear = parseInt(datestringFrom.substring(0,firstflag),10);    //得到开始年份 
	secondflag = datestringFrom.lastIndexOf("-");
	intFromMonth = parseInt(datestringFrom.substring((firstflag+1),secondflag),10);   //得到开始月份
	intFromDay = parseInt(datestringFrom.substring((secondflag+1),datestringFrom.length),10); //得到开始日
		
	firstflag=datestringEnd.indexOf("-");
	intEndYear = parseInt(datestringEnd.substring(0,firstflag),10);     //得到结束年份 
	secondflag = datestringEnd.lastIndexOf("-");
	intEndMonth = parseInt(datestringEnd.substring((firstflag+1),secondflag),10);   //得到结束月份
	intEndDay = parseInt(datestringEnd.substring((secondflag+1),datestringEnd.length),10);  //得到结束日
	
	if (  intFromYear < intEndYear  )    
		return true;
	if (  intFromYear == intEndYear&& intFromMonth < intEndMonth)
		return true;
	if (intFromYear == intEndYear && intFromMonth == intEndMonth  && intFromDay < intEndDay)
		return true;
	if(blnCompareFlag == 1)  
	{
	   intFromHour = parseInt(datestringFrom.substring(datestringFrom.indexOf(" ")+1,datestringFrom.indexOf(":")));       //得到开始小时
	   intFromMinute = parseInt(datestringFrom.substring(datestringFrom.indexOf(":")+1,datestringFrom.lastIndexOf(":"))); //得到开始分钟
	   
	   intEndHour = parseInt(datestringEnd.substring(datestringEnd.indexOf(" ")+1,datestringEnd.indexOf(":")));       //得到结束小时
	   intEndMinute = parseInt(datestringEnd.substring(datestringEnd.indexOf(":")+1,datestringEnd.lastIndexOf(":"))); //得到结束分钟
	   
	   if( intFromYear==intEndYear && intFromMonth == intEndMonth && intFromDay==intEndDay && intFromHour<intEndHour ) 
		    return true;
	   if( intFromYear==intEndYear && intFromMonth == intEndMonth && intFromDay==intEndDay && intFromHour==intEndHour && intFromMinute<intEndMinute)
			return true;
	}
	return false;
}

function IsDateInput(DateString)
{
	var ss;
	var d_month, d_date, d_year;
	if (DateString.length==0) return("日期不能为空！");
	if (DateString.length<8) return("日期非法！");
	ss = DateString.split("-");		//将日期分成三段
	if (ss.length != 3) return("日期非法！");
	else {
		d_month = parseInt(ss[1]);
		if (isNaN(d_month)) return("日期中的月份值非法！");
		if (d_month<0 || d_month>12) return("日期中的月份值非法！");
		d_date = parseInt(ss[2]);
		if (isNaN(d_date)) return("日期中的日期值非法！");
		if (d_date<0 || d_date>31) return("日期中的日期值非法！");
		d_year = parseInt(ss[0]);
		if (isNaN(d_year)) return("日期中的年份值非法！");
		if (d_year<1900 || d_year>3000) return("日期中的年份值非法！");
		};
	return("");   
}

function ThrowBlank(string)
{
	var msg="";
	
	msg=string;
	while(msg.substring(0,1)==" ")
	{
		msg=msg.substring(1,msg.length);
	}  
	return msg;

}


