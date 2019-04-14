function ValidateAllText()
{	
	var rtn=true;	
	var textArray=document.all.tags("input");
	for(var i=0;i<textArray.length;i++)
	{
		if(textArray[i].type=="text")	
		{
			var str=textArray[i].value;
			var title=textArray[i].title;
			if(title==null || title==""){
				continue;
			}
			
			var dataTypeStr="";
			var dataType="";
			var dataLength="";
			var nullStr="";
			
			var index=-1;
			var endIndex=0;
			index=title.indexOf(";")
			var name=title.substr(0,index);
			
			index=0;
			index=title.indexOf("nullStr");				
			if(index>=0)
			{			
				endIndex=title.indexOf(";",index)				
				nullStr=title.substring(index+8,endIndex);				
			}
		
			index=0;
			index=title.indexOf("dataType");
				
			if(index>=0)
			{	
				endIndex=title.indexOf(";",index);				
				dataTypeStr=title.substring(index+9,endIndex);								
				index=dataTypeStr.indexOf(":");				
				if(index>=0)
				{
					dataType=dataTypeStr.substr(0,index);
					dataLength=dataTypeStr.substr(index+1)
				}
				else
				{					
					dataType=dataTypeStr;
					dataLength="";
				}
				
			}		
		
			var errorMsg=ValidateString(str,dataType,nullStr);								
			if(errorMsg!="")
			{
				if(dataType=="date")
				{
					name=name.substr(6);									
				}
				window.alert(name+errorMsg);
				textArray[i].focus();
				rtn=false;				
				break;
			}
		}
	}   
	return rtn;
}

function ValidateString(str,dataType,nullStr)
{
	var errorMsg="";

	if(str=="" && nullStr=="false")
	{
		errorMsg="必填！";
		return errorMsg;
	}
	if(dataType=="number" || dataType=="Number")
	{		
		//if(matchArray!=null)
		if(!CheckNumber(str))
		{
			errorMsg="只能是数字！";
			return errorMsg;
		}
	}
	
	if(dataType=="date")
	{	if(str!="")
		{
			if(!isDate(str))
			{			
				errorMsg="必须输入合法日期-如：2002-01-02";			
			}
		}
	}	
	return errorMsg;
}
	
function DoubleLength(str,intLen,decLen)
	{
		var errorMsg="";
		var strArray = str.split(".");
		
		if(strArray.length>2)
		{
			errorMsg="必须是数字！";
		}
		else 
		{				
			if(strArray.length==2)
			{
				if(strArray[0].length==0)
				{
					errorMsg="，小数点前不能为空值！";
				}
				if(strArray[1].length==0)
				{
					errorMsg="，小数点后不能为空值！";
				}

				
				if(strArray[0].length>intLen)
				{
					errorMsg="，整数位数只允许输入"+intLen+"位，您的输入过长！";
				}
				
				if(strArray[1].length>decLen)
				{
					errorMsg="，小数位数只允许输入"+decLen+"位，您的输入过长！";
				}
			}			
		}
		return errorMsg;
	}
	function CheckNumber(checkStr)
	{
		
		if(checkStr=="")
		{
			return true;
		}
		if(checkStr.charAt(0)=="-")
		{
			checkStr=checkStr.substr(1);
			if(checkStr=="")
			{
				return false;
			}
		}
		
		var strArray = checkStr.split(".");
		
		if(strArray.length>2)
		{
			return false;
		}
		else if(strArray.length==2)
		{				
			if(strArray.length==2)
			{
				if(strArray[0]=="" || strArray[1]=="" || strArray[0].match(/\D/)!=null || strArray[1].match(/\D/)!=null)
				{
					return false;
				}
			}
			
		}
		else if(strArray.length==1) 
		{
			if(checkStr.match(/\D/)!=null)
			{
				return false;
			}
		}
		 return true;
	}
/**
 * b2b JavaScript 检查库
 * @author 
 * @version 1.10
 * #@ validate.js
 * 第一类 检查并返回检查结果(true or false)
 * a-1. ifDigit(String)  是否为数字(可用)
 * a-2. ifLetter(String) 是否为字母(可用)
 * a-3. ifDay(String)    是否为天数(可用)
 * a-4. ifMonth(String)  是否为月份(可用)
 * a-5. ifYear(String)   是否为年份(可用)
 * a-6. ifDate(String)   是否为日期(格式是19990101)(可用)
 * a-7. ifEmail(String)  是否为邮件地址(可用)
 * a-8. ifPhone(String)  是否为电话号码//此方法无法判断是否为电话号码。
 * a-9. ifGBK(String)    是否为中文字符(可用)
 * a-10.ifMoney(String)  是否为合法货币数字(可用)
 * a-11 ifMoenyRange(String,int,int) 判断字符串是否为合法钱数,且是否超过限定范围(可用)
 * a-12. checkMonthLength(mm, dd, yyyy) 判断是否为合法日期 (可用)
 * a-13. getSelectedButton(buttonGroup) 判断buttongroup为名的一组radio中有无被选中的项(可用)
 * a-14. ifSubCollect(String str, String strCollect) 判断子字符串str是否在父字符串strCollect中(可用)
 * a-14.DoubleLength(str,Flen,Llen) 校验数字类型的整数位和小数位是否合法
 
 * 第二类 检查后直接报错
 * b-1. isDigit(Object)	 是否为数字(可用)
 * b-2. isLetter(Object) 是否为字母(可用)
 * b-3. isDay(Object)    是否为天数(dd,01)(可用)
 * b-4. isMonth(Object)  是否为月份(mm,09)(可用)
 * b-5. isYear(Object)   是否为年份(yyyy,1999)(可用)
 * b-6. isDate(Object)   是否为日期(2005-01-01)(可用)
 * b-6.1 isHour(obj)     是否为小时数 (hh,09)(可用)
 * b-6.2 isMinute(obj)   是否为分钟数 (mm,09)(可用)
 * b-6.3 isSecond(obj)   是否为时间秒数 (ss,09)(可用)
 * b-7. isEmail(Object)  是否为邮件地址 (可用)
 * b-8. isPhone(Object)  是否为电话号码
 * b-9. isGBK(Object)    是否不为为中文字符(可用)
 * b-10. isMoney(Object) 是否为合法货币数字(可用)
 * b-11. isMoneyRange(obj,minValue,maxValue)	判断是否合法钱数且是否超过限定额度(可用)
 * b-12. checkLeng(Object, min, max) 字符串长度是否在指定长度范围内(可用)
 * b-13.1 checkValidDate(mmObject,ddObject,yyObject,allowNull)	对日期进行全面的检查
 * b-13.2 checkValidDateRange(mmObject1,ddObject1,yyObject1,allowNull1,mmObject2,ddObject2,yyObject2,allowNull2)
 * b-14 isDigitMaxlength(String obj, int len) 检查是否为数字(不包括小数)并检查是否在指定长度内。(可用)
 *		检查起始日期及截止日期
 * b-14. errorMsg(Object, String) 显示提示信息String,光标焦点落在Object上,返回false(可用)
 * b-15. isSubCollect(String str, String strCollect) 判断子字符串str是否在父字符串strCollect中(可用)
 * 第三类 功能函数，并不报错
 * c-1. getLength(String)  获取字符长度（每个中文字符为2个字符）(可用)
 * c-2. trim(String)  去掉字符串前后的空格并返回(可用)
 * c-3. textsTrim(formname)	将form中所有的text文本进行trim操作。(可用)

 */
//建立者:默认
//判断字符串是否为合法数字（包括小数）
// a-1 ifDigit(String)
function ifDigit(inputVal)
{
	var oneChar
	inputStr=inputVal.toString();
	for (var i=0;i<inputStr.length;i++){
		oneChar=inputStr.charAt(i);
		if (oneChar<"0" || oneChar>"9")
		{
			if(oneChar!="."){
				return false;
			}
		}//end if
	}//end for
	return true;
}

//功能:判断字符串是否都是字母
// a-2 ifLetter(String)
function ifLetter( str ){	
	if ( str.length == 0 )
		return false;
		
	str = str.toUpperCase();
	
	for ( var i = 0 ; i < str.length; i ++ ){
		if ( str.charAt(i) < "A" || str.charAt(i) > "Z" )
			return false;
	}
	return true;
}

// a-3 ifDay(String)
function ifDay(obj)
{
	i=obj.indexOf(".");
	if(i>0)
	{
		return false;
	}
	if (!ifDigit(obj))
	{
		return false;
	}
	if (obj < "01" || obj > "31")
	{
		return false;
	}
	return true;
}

// a-4 ifMonth(String)
function ifMonth(obj)
{	
	i=obj.indexOf(".");
	if(i>0)
	{
		return false;
	}
	if (!ifDigit(obj))
	{
		return false;
	}
	if (obj < "01" || obj > "12")
	{
		return false;
	}
	return true;
}

// a-5 ifYear(String)
function ifYear(obj)
{
	var slen=0;
	slen=obj.length;
	
	i=obj.indexOf(".");
	if(i>0)
	{
		return false;
	}
	if (!ifDigit(obj))
	{
		return false;
	}
	if (slen<4)
	{
		return false;
	}
	if (slen>4)
	{
		return false;
	}
	if (obj<"1800")
	{
		return false;
	}
	return true;
}

// a-6 ifDate(String)
function ifDate(obj)
{
	obj=trim(obj);
	i=obj.indexOf(".");
	if(i>0)
	{
		return false;
	}
	slen=obj.length;
	if (!ifDigit(obj))
	{
		return false;
	}
	else if (slen < 8)
	{
		return false;
	}
	else if (slen > 8)
	{
		return false;
	}
	cc = obj.substr(0,4);
	if (cc < "1800")
	{
		return false;
	}
	cc = obj.substr(4,2);
	if (cc < "01" || cc > "12")
	{
		return false;
	}
	cc = obj.substr(6,2);
	if (cc < "01" || cc > "31")
	{
		return false;
	}
	var mm=obj.substr(4,2);
	var dd=obj.substr(6,2);
	var yy=obj.substr(0,4);
	alert(mm);
    alert(dd);
    alert(yy);

	if(!checkMonthLength(mm,dd,yy))
	{
		return false;
	}
	return true;
}

//建立者:任勇
//判断字符串是否为合法邮件地址
// a-7 ifEmail(String)
function ifEmail(obj)
{
	i=obj.indexOf("@");
	str=obj.substring(0,i);
	j=obj.lastIndexOf(".");
	if (i == -1 || j == -1 || i > j ||str=="" )
	{
		return false;
	}
	return true;
}

// a-8 ifPhone(String)
function ifPhone(obj)
{
	slen=obj.length;
	for (i=0; i<slen; i++){
		cc = obj.charAt(i);
		if ((cc <"0" || cc >"9") && cc != "-" && cc!="+" && cc!="(" && cc !=")" && cc !="/")
		{
			return false;
		}
	}
	return true;
}

// 判断字符串是否不是汉字字符。
// return true or false (不是/是)
function ifGBK(obj)
{
	slen=obj.length;
	for (i=0; i<slen; i++){
		cc = obj.charAt(i);
		cc = escape(cc);
		if (cc.indexOf("%u") >= 0)
		{
			return false;
		}
	}
	return true;
}

//建立者:任勇
//判断字符串是否为合法钱数
// a-10 ifMoeny(String)
function ifMoney(str){
	if ( ( pos = str.indexOf( "." ) ) != -1 ){
	   if (str.length==1)
	     return false;
	     
	   if ( ( pos = str.indexOf(".", pos + 1) )  != -1 )
	     return false;
	}

	for ( var i = 0 ; i < str.length; i ++ ){
	  if (( str.charAt(i) < "0" || str.charAt(i) > "9" )&&(str.charAt(i)!="."))
	    return false;
	}
	if (( str.charAt(0) == "0" && str.charAt(1) != "." ))
	{
	    return false;
	}
	
	return true;
}

//建立者:任勇
//判断字符串是否为合法钱数,且是否超过限定范围
// a-11 ifMoenyRange(String,int,int)
function ifMoneyRange(str,minValue,maxValue)
{
	if(str=="") return true;
	
	if(!ifMoney(str))
		return false;
	
	if(parseFloat(str)>maxValue)
		return false;
	if(parseFloat(str)<minValue)
		return false;
	return true;
}

//建立者:任勇
//判断是否为合法日期
// a-12 checkMonthLength(mm, dd, yyyy)
function checkMonthLength(mm,dd,yyyy){
	  if((mm=="4"||mm=="6"||mm=="9"||mm=="11"||mm=="04"||mm=="06"||mm=="09") && dd>"30"){
      return false;
    }else if((mm=="2")||(mm=="02")){
      if(yyyy % 4 >0 && dd>"28"){
        return false;
      }else if(dd>"29"){
        return false;
      }
    }else if(dd>"31"){
      return false;
    }
	 else if(mm>"12"){
      return false;
    }
	else if(yyyy<"1800"){
      return false;
    }
	else if(mm<"01"){
      return false;
    }
	
	else if(dd<"01"){
      return false;
    }
	
	
    return true;  
}




//建立者:默认
//功能: 检查是否为数字
//示例: isDigit(String)
//输入参数: 需要检查的表单对象名称
//输出参数: true或出错信息
// b-1.1 isDigit(Object)
function isDigit(obj)
{
	slen=obj.value.length;
	for (i=0; i<slen; i++){
		cc = obj.value.charAt(i);
		if (cc <"0" || cc >"9")
		{
			errorMsg(obj,"必须为数字！");
			return false;
		}
	}
	return true;
}

//建立者:任勇
//功能: 检查是否为数字(不包括小数)并检查是否在指定长度内。
//示例: isDigitMaxlength(String obj,int length)
//输入参数: 需要检查的表单对象名称,允许的最大长度
//输出参数: true或出错信息
// b-1.2 isDigitMaxlength(Object,maxlength)
function isDigitMaxlength(obj,maxlength)
{
	obj.value=trim(obj.value);
	slen=obj.value.length;
	if(slen>maxlength){
		errorMsg(obj,"长度最大为"+maxlength+"！");
		return false;
	}
	
	for (i=0; i<slen; i++){
		cc = obj.value.charAt(i);
		if (cc <"0" || cc >"9")
		{
			errorMsg(obj,"必须为数字！");
			return false;
		}
	}
	return true;
}

//建立者:任勇
//功能:判断字符串是否都是字母
// b-2 isLetter(Object)
function isLetter(obj){
	str = obj.value;

	if ( str.length == 0 )
		return false;		
	str = str.toUpperCase();
	
	for ( var i = 0 ; i < str.length; i ++ )
	{
		if ( str.charAt(i) < "A" || str.charAt(i) > "Z" )
		{
			errorMsg(obj, "必须为字母！");
			return false;
		}
	}
	return true;
}

// b-3 isDay(Object)
function isDay(obj)
{
	if (!isDigit(obj))
	{
		return false;
	}
	if (obj.value == "1" || obj.value== "2"|| obj.value== "3")
	{
		errorMsg(obj,"日数格式有误，正确的格式为：DD,如:01");
		return false;
	}
	if (obj.value < "01" || obj.value > "31")
	{
		errorMsg(obj,"日数格式有误，正确的格式为：DD,如:01");
		return false;
	}
	return true;
}

// b-4 isMoneth(Object)
function isMonth(obj)
{	
	if (!isDigit(obj))
	{
		return false;
	}
	if (obj.value == "1" || obj.value== "2"|| obj.value== "3")
	{
		errorMsg(obj,"月份格式有误，正确的格式为：MM,如:01");
		return false;
	}
	if (obj.value < "01" || obj.value > "12")
	{
		errorMsg(obj,"月份格式有误，正确的格式为：MM,如:01");
		return false;
	}
	return true;
}

//建立者：默认
//功能：检查是否合法年份
//示例：isYear(Object)
//输入参数：被检查字符串
//输出参数：true 或 错误信息
// b-5 isYear(Object)
function isYear(obj)
{
	
	vt=obj.value.indexOf(".");
	if(vt>0)
	{
		errorMsg(obj,"年份不能含有小数点！");
		return false;
	}
	if (!ifDigit(obj.value))
	{
		errorMsg(obj,"年份不能含有非数字的字符！");
		return false;
	}
	if (obj.value < "1800"|| obj.value.length != 4)
	{
		errorMsg(obj,"年份格式有误，正确的格式为：YYYY,如:1999");
		return false;
	}
	return true;
}

//建立者：zhubing
//功能：检查是否合法小时
//isHour(Object)
//输入参数：被检查字符串
//输出参数：true 或 错误信息
// b-5 isHour(Object)
function isHour(obj)
{
	vt=obj.value.indexOf(".");
	if(vt>0)
	{
		errorMsg(obj,"时间错误，不能含有小数点！");
		return false;
	}
	if (!ifDigit(obj.value))
	{
		errorMsg(obj,"时间错误，不能含有非数字的字符！");
		return false;
	}
	if (obj.value == "1" || obj.value == "2"|| obj.value == "3"|| obj.value == "4"|| obj.value == "5")
	{
		errorMsg(obj,"时间错误，正确的格式为：hh,如:01");
		return false;
	}
	if (obj.value < "00" || obj.value > "23")
	{
		errorMsg(obj,"时间错误，小时数只能在：00~23范围内");
		return false;
	}
	return true;
}

//建立者：默认
//功能：检查是否合法分钟数
//示例：isMinute(Object)
//输入参数：被检查字符串
//输出参数：true 或 错误信息
// b-5 isMinute(Object)
function isMinute(obj)
{
	vt=obj.value.indexOf(".");
	if(vt>0)
	{
		errorMsg(obj,"错误，不能含有小数点！");
		return false;
	}
	if (!ifDigit(obj.value))
	{
		errorMsg(obj,"错误，含有非数字字符！");
		return false;
	}
	if (obj.value == "1" || obj.value == "2"|| obj.value == "3"|| obj.value == "4"|| obj.value == "5")
	{
		errorMsg(obj,"错误，正确的格式为：mm,如:01");
		return false;
	}
	if (obj.value < "00" || obj.value > "59")
	{
		errorMsg(obj,"错误，分钟数只能在：00~59范围内");
		return false;
	}
	return true;
}

//建立者：默认
//功能：检查是否合法秒数
//示例：isSecond(Object)
//输入参数：被检查字符串
//输出参数：true 或 错误信息
// b-5 isSecond(Object)
function isSecond(obj)
{

	vt=obj.value.indexOf(".");
	if(vt>0)
	{
		errorMsg(obj,"错误，不能含有小数点！");
		return false;
	}
	if (!ifDigit(obj.value))
	{
		errorMsg(obj,"错误，含有非数字字符！");
		return false;
	}
	if (obj.value == "1" || obj.value == "2"|| obj.value == "3"|| obj.value == "4"|| obj.value == "5")
	{
		errorMsg(obj,"错误，正确的格式为：ss,如:01");
		return false;
	}
	if (obj.value < "00" || obj.value > "59")
	{
		errorMsg(obj,"错误，秒数只能在：00~59范围内");
		return false;
	}
	return true;
}

//建立者：默认 
//功能：检查是否合法日期--合法日期为：2002-01-01
//示例：isDate(Object)
//输入参数：被检查字符串
//输出参数：true 或 错误信息
// b-6 isDate(Object)

function isDate(obj)
{
	obj=trim(obj);
	slen=obj.length;
	
	
	if (slen!=10)
	{
		return false;
		
	}
	cc = obj.substr(0,4);
	if (cc < "1800")
	{
		
		return false;
		
	}
	cc = obj.substr(4,1);
	if (cc!="-")
	{
		return false;
	}
	cc = obj.substr(5,2);
	if (cc < "01" || cc > "12")
	{
		return false;
	}
	cc = obj.substr(7,1);
	if (cc !="-" )
	{
		
		return false;
	}
	cc = obj.substr(8,2);
	if (cc < "01" || cc > "31")
	{
		
		return false;
	}
	var mm=obj.substr(5,2);
	var dd=obj.substr(8,2);
	var yyyy=obj.substr(0,4);
	if(!checkMonthLength(mm,dd,yyyy))
	{
		return false;
	}
	else
	{
		return true;
	}
	
	return true;
}




// b-7 isEmail(Object)
function isEmail(obj)
{
	i=obj.value.indexOf("@");
	str=obj.value.substring(0,i);
	j=obj.value.lastIndexOf(".");
	// if (! ifGBK(obj)) i = -1;
	if (i == -1 || j == -1 || i > j || str=="")
	{
		errorMsg(obj,"请输入正确的Email格式如：kk@163.com！");
		return false;
	}
	return true;
}

// b-8 isPhone(Object)
function isPhone(obj)
{
	slen=obj.value.length;
	if (slen <1)
	{
		errorMsg(obj, "信息为空，请修改！");
		return false;
	}
	for (i=0; i<slen; i++){
		cc = obj.value.charAt(i);
		if ((cc <"0" || cc >"9") && cc != "-" && cc!="+" && cc!="(" && cc !=")" && cc !="/")
		{
			errorMsg(obj,"必须为数字！");
			return false;
		}
	}
	return true;
}

// b-9 isGBK(Object)
function isGBK(obj)
{
	slen=obj.value.length;
	for (i=0; i<slen; i++){
		cc = obj.value.charAt(i);
		cc = escape(cc);
		if (cc.indexOf("%u") >= 0)
		{
			errorMsg(obj,"该项不能为汉字！");
			return false;
		}
	}
	return true;
}

//判断字符串是否为合法钱数
// b-10 isMoney(Object)
function isMoney(obj)
{
	if (ifMoney(obj.value))
	{
		return true;
	}
	else
	{
		errorMsg(obj, "不是合法的货币数！");
		return false
	}	
	return true;
}

//判断是否合法钱数且是否超过限定额度
//b-11 isMoneyRange(obj,minValue,maxValue)
function isMoneyRange(obj,minValue,maxValue)
{
	
	if(!isMoney(obj))
	{
		return false;
	}
	obj.value=trim(obj.value);
	
	if(obj.value=="") return true;
	
	if(parseFloat(obj.value)>=maxValue)
		return showMsg("货币值过大！",obj);
	if(parseFloat(obj.value)<minValue)
		return showMsg("货币值过小！",obj);
	return true;
}

//功能: 检查字段长度是否在指定范围内
//示例: chekLeng(form1.t1, 4,10)
//输入参数: 需要检查的表单对象名称，最小长度，最大长度
//输出参数: true
// b-12 checkLeng(obj, min, max)
function checkLeng(obj, min, max)
{
	slen=getLength(obj.value);
	if (slen < min)
	{
		errorMsg(obj,"请至少输入 " + min + " 个字符！");
		return false;
	}
	if (slen > max)
	{
		errorMsg(obj,"请最多输入 " + max + " 个字符！");
		return false;
	}
	return true;
}

//功能:对日期进行全面的检查
//输入参数:mmObject:月的object;ddObject:日的object;yyObject:年的object;
//输入参数:allowNull:true允许日期为空;false:必须选择日期
//输出参数:ture of false;
// b-13.1 checkValiDate(mmObject,ddObject,yyObject,allowNull)
function checkValidDate(mmObject,ddObject,yyObject,allowNull)
{
  	if(allowNull)
	{
  		if(!(((!yyObject.options[0].selected)&&(!mmObject.options[0].selected)&&(!ddObject.options[0].selected)) || ((yyObject.options[0].selected)&&(mmObject.options[0].selected)&&(ddObject.options[0].selected))))
  			return showMsg("日期必须全部选择或者全部不选择!",yyObject);
  	}
	else
	{
			if(yyObject.options[0].selected)
			{
				return showMsg("请选择日期的年!",yyObject);
			}
			if(mmObject.options[0].selecte)
			{
				return showMsg("请选择日期的月!",mmObject);
			}
			if(ddObject.options[0].selected)
			{
				return showMsg("请选择日期的日!",ddObject);
			}
  	}
  	
  	if(!yyObject.options[0].selected){
  		var my_year=yyObject[yyObject.selectedIndex].value;
  		var my_month=mmObject[mmObject.selectedIndex].value;
  		var my_day=ddObject[ddObject.selectedIndex].value;
  		
  		if(!checkMonthLength(my_month,my_day,my_year))
  			return showMsg("选择的日期不合法!",ddObject);
  	}
  	return true;
}


//功能:对日期进行全面的检查
//输入参数:mmObject1:其始月的object;ddObject1:其始日的object;yyObject1:其始年的object;
//输入参数:allowNull1:起始日期true允许日期为空;false:必须选择日期
//输入参数:mmObject2:截止月的object;ddObject2:截止日的object;yyObject2:截止年的object;
//输入参数:allowNull2:截止日期true允许日期为空;false:必须选择日期
//输出参数:ture of false;
// b-13.2 checkValidDateRange(mmObject1,ddObject1,yyObject1,allowNull1,mmObject2,ddObject2,yyObject2,allowNull2)
function checkValidDateRange(mmObject1,ddObject1,yyObject1,allowNull1,mmObject2,ddObject2,yyObject2,allowNull2){
	if(!checkValidDate(mmObject1,ddObject1,yyObject1,allowNull1)) return false;
	if(!checkValidDate(mmObject2,ddObject2,yyObject2,allowNull2)) return false;
	
	if((!yyObject1.options[0].selected) && (!yyObject2.options[0].selected)){
		date1=new Date(yyObject1[yyObject1.selectedIndex].value-1900,mmObject1[mmObject1.selectedIndex].value-1,ddObject1[ddObject1.selectedIndex].value);
		date2=new Date(yyObject2[yyObject2.selectedIndex].value-1900,mmObject2[mmObject2.selectedIndex].value-1,ddObject2[ddObject2.selectedIndex].value);
		if(date1>date2){
			return showMsg("起始日期不能大于截止日期！",yyObject1);
		}
	}
	return true;
}

// 报错
// b-14 errorMsg(Object, String)
// 功能:显示提示信息Msg,光标焦点落在Obj上,返回false
// 主要用于检查必要字段是否正确
// 示例:showMsg("用户名不能为空.",myform.username)
// 输入参数:Msg(提示信息) Obj(光标焦点对象)
// 输出参数:false

function errorMsg(obj,msg)
{
	obj.focus();
	alert(msg);
	return false;
}
function showMsg(Msg, Obj)
{
	alert( Msg );
	Obj.focus();
	return false;
}

// b-15 isSubCollect(String, String)
// 功能：判断子字符串str是否在父字符串strCollect中
// 输入参数：string str 子字符串字段
// 输入参数：string strCollect 父字符串
// 输出参数：true or false 包含或不包含
function isSubCollect(str, strCollect)
{
    var validCount = 0;
	var collectStr = "";
	for(i=0;i<strCollect.length;i++)
	{
		collectStr=strCollect.substring(i,i+1);
		if (str == collectStr)
			validCount++;
	}
	if (validCount < 1)
	{
	    alert("在预定信息集中没有包含信息:" +str  );
	    return false;
	}
	else
		alert("在预定信息集中包含信息:" +str  );
	    return true;
}
/**
以下是第三类
*/

//求得输入字符串的长度
// c-1 getLength(String)
function getLength(str){
	var templen=str.length;
	if(navigator.appName=='Netscape') return templen;
	for(var i=0;i<str.length;i++){
    		var rstr=escape(str.substring(i,i+1)); 
    		if (rstr.substring(0,2)=="%u"){ 
       			templen++;
    		} 
  	}
	return templen;
}

//功能:去掉字符串前后的空格并返回
//输入参数:inputStr(待处理的字符串)
//输出参数:inputStr(处理后的字符串)
// c-2 trim(String)
function trim(inputStr) {
	var result = inputStr
	while (result.substring(0,1) == " ") {
		result = result.substring(1,result.length)
	}
	
	while (result.substring(result.length-1, result.length) == " ") {
		result = result.substring(0, result.length-1)
	}
		
	return result
}


//功能:将form中所有的text文本进行trim操作。
//输入参数:myform(form名)
//输出参数:无
// c-3 textTrim(form名称)
function textsTrim(myform){
  	for(var i=0;i<myform.elements.length;i++){
  		var etype=myform.elements[i].type;
  		if(etype =="text"){
 			myform.elements[i].value=trim(myform.elements[i].value);
			alert(myform.elements[i].value);
  		}
  	}
}


// 功能：判断子字符串str是否在父字符串strCollect中
// 输入参数：string str 子字符串字段
// 输入参数：string strCollect 父字符串
// 输出参数：true or false 包含或不包含
// c-4 ifSubCollect(string,string)
function ifSubCollect(str,strCollect)
{
    var validCount = 0;
	var collectStr = "";
	for(i=0;i<strCollect.length;i++)
	{
		collectStr=strCollect.substring(i,i+1);
		if (str == collectStr)
			validCount++;
	}
	
	if (validCount < 1)
	    return false;
	else
	    return true;
}





	




