function InputDateTimeCompare(datFromDate,datEndDate,blnCompareFlag)
{
    var intFromYear,intFromMonth,intFromDay,intFromHour,intFromMinute;    //��ʼʱ������ͱ���
	var intEndYear,intEndMonth,intEndDay,intEndHour,intEndMinute;         //����ʱ������ͱ���
	var firstflag,secondflag;                                             //�ֱ��¼�����еĵ�һ���͵ڶ�����-����λ�� 
	var datestringFrom = new String(datFromDate);
	var datestringEnd =  new String(datEndDate);
	
	firstflag = datestringFrom.indexOf("-");                           
	intFromYear = parseInt(datestringFrom.substring(0,firstflag),10);    //�õ���ʼ��� 
	secondflag = datestringFrom.lastIndexOf("-");
	intFromMonth = parseInt(datestringFrom.substring((firstflag+1),secondflag),10);   //�õ���ʼ�·�
	intFromDay = parseInt(datestringFrom.substring((secondflag+1),datestringFrom.length),10); //�õ���ʼ��
		
	firstflag=datestringEnd.indexOf("-");
	intEndYear = parseInt(datestringEnd.substring(0,firstflag),10);     //�õ�������� 
	secondflag = datestringEnd.lastIndexOf("-");
	intEndMonth = parseInt(datestringEnd.substring((firstflag+1),secondflag),10);   //�õ������·�
	intEndDay = parseInt(datestringEnd.substring((secondflag+1),datestringEnd.length),10);  //�õ�������
	
	if (  intFromYear < intEndYear  )    
		return true;
	if (  intFromYear == intEndYear&& intFromMonth < intEndMonth)
		return true;
	if (intFromYear == intEndYear && intFromMonth == intEndMonth  && intFromDay < intEndDay)
		return true;
	if(blnCompareFlag == 1)  
	{
	   intFromHour = parseInt(datestringFrom.substring(datestringFrom.indexOf(" ")+1,datestringFrom.indexOf(":")));       //�õ���ʼСʱ
	   intFromMinute = parseInt(datestringFrom.substring(datestringFrom.indexOf(":")+1,datestringFrom.lastIndexOf(":"))); //�õ���ʼ����
	   
	   intEndHour = parseInt(datestringEnd.substring(datestringEnd.indexOf(" ")+1,datestringEnd.indexOf(":")));       //�õ�����Сʱ
	   intEndMinute = parseInt(datestringEnd.substring(datestringEnd.indexOf(":")+1,datestringEnd.lastIndexOf(":"))); //�õ���������
	   
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
	if (DateString.length==0) return("���ڲ���Ϊ�գ�");
	if (DateString.length<8) return("���ڷǷ���");
	ss = DateString.split("-");		//�����ڷֳ�����
	if (ss.length != 3) return("���ڷǷ���");
	else {
		d_month = parseInt(ss[1]);
		if (isNaN(d_month)) return("�����е��·�ֵ�Ƿ���");
		if (d_month<0 || d_month>12) return("�����е��·�ֵ�Ƿ���");
		d_date = parseInt(ss[2]);
		if (isNaN(d_date)) return("�����е�����ֵ�Ƿ���");
		if (d_date<0 || d_date>31) return("�����е�����ֵ�Ƿ���");
		d_year = parseInt(ss[0]);
		if (isNaN(d_year)) return("�����е����ֵ�Ƿ���");
		if (d_year<1900 || d_year>3000) return("�����е����ֵ�Ƿ���");
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


