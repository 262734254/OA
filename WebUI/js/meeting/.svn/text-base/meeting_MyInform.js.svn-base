
/*********************
*    显示/消失 通知正文层      *
*********************/

//比较会议开始时间是否在 当前时间之后
function isBegin(meetingBeginTime){
	
	meetingBeginTime=meetingBeginTime.substring(0,meetingBeginTime.indexOf("."));
		
		var date=new Date();
		
		var nowTime=date.getYear();
	    if(date.getMonth().toString().length<=1){
	    	nowTime=nowTime+"-0"+escape(date.getMonth()+1);
	    }else{
	    	nowTime=nowTime+"-"+escape(date.getMonth()+1);
	    }
	    
	    if(date.getDate().toString().length<=1){
	    	nowTime=nowTime+"-0" +date.getDate();
	    }else{
	    	nowTime=nowTime+"-" +date.getDate();
	    }
	    
	    nowTime=nowTime+" "+date.getHours()+":"+date.getMinutes()+":"+ date.getSeconds(); 

	    if(meetingBeginTime <= nowTime){
			return false;
		}
		return true;
}

//显示层  
function showDiv(meetingBeginTime,receipt,divId,rowId,url,isRead,param)
{
	var div=divId.substring(0,divId.length-1);
	for(var i=0;i<5;i++){
		if(document.getElementById(div+i)!=null){
			document.getElementById(div+i).style.display="none";
		}
	}

	document.getElementById(divId).style.display="";
	//document.getElementById(divId).style.display="block";
	
	//设置需要更新的值 会议通知的阅读状态
	document.getElementById(isRead).value=param;
	
	//调用以下函数方法用于会议的开始时间和当前时间进行比较 如果会议已经开始 则回复按钮不可点击
	if(!isBegin(meetingBeginTime)){
		document.getElementById(receipt).disabled="disabled";
	}
	
	var objIsRead=document.getElementById("isRead"+rowId);
	if(objIsRead.outerText.replace(" ","")=="未查看"){
		//调用 ajaxMeetingInform.js文件里的函数方法 进行数据库数据的更新 (更新会议通知的阅读状态为已阅读)
		changeMeetingInformIsRead(rowId,url);
	}
}

/** 回复会议通知 如果为不出席时不出席的原因必填 **/
function meetingReceipt(meetingBeginTime,formName,rowId,isRead,param,url)
{
	if(!isBegin(meetingBeginTime)){
		alert("会议已经开始了,不需要发回执了！");
		return ;
	}

   	var form = document.getElementById(formName);
   	var  value=form.state.options[form.state.selectedIndex].value;
	if(value=="0")
	{
		if(form.receiptContent.value.replace(" ","")=="")
		{
			alert("请说明缺席原因!!");
			return false;
		}
	}
	document.getElementById(isRead).value=param;
	url=url+"?informId="+form.informId.value+"&state="+form.state.value+"&receiptContent="+form.receiptContent.value+"&isRead=2";
	//调用 ajaxMeetingInform.js文件里的函数方法 进行数据库数据的更新 
	//(先在MeetingReceipt回执表里插入一条数据 然后更新会议通知的阅读状态为已回复)
	changeMeetingInformIsRead(rowId,url);
}

//显示层  并填入数据的类型为 文本框
function showDiv_getText(divId,param)
{
	if(document.getElementById(divId).style.display=="none")
	{
		document.getElementById(divId).style.display="";
		//document.getElementById(divId).style.display="block";

		for(var i=0;i<param.split('|').length-1;i++)
		{
			var value = param.split('|')[i].split('=')[1];
			//document.getElementById(param.split('|')[i].split('=')[0]).innerHTML=value;
			document.getElementById(param.split('|')[0].split('=')[0]).value=value;
		}
		//var value = param.split('|')[0].split('=')[1];
        //document.getElementById(param.split('|')[0].split('=')[0]).value=value;
	}
}


////显示层  并填入数据的类型为 层
//function showDiv_getDiv(divId,param)
//{
//	if(document.getElementById(divId).style.display=="none")
//	{
//		document.getElementById(divId).style.display="";
//		//document.getElementById(divId).style.display="block";
//
//		for(var i=0;i<param.split('|').length-1;i++)
//		{
//			var value = param.split('|')[i].split('=')[1];
//			document.getElementById(param.split('|')[i].split('=')[0]).innerHTML=value;
//			//document.getElementById(param.split('|')[0].split('=')[0]).value=value;
//		}
//		//var value = param.split('|')[0].split('=')[1];
//        //document.getElementById(param.split('|')[0].split('=')[0]).value=value;
//	}
//}


//显示层  并填入数据的类型为 层
function showDiv_getDiv(divId,param)
{
	if(document.getElementById(divId).style.display=="none")
	{
		document.getElementById(divId).style.display="";
		//document.getElementById(divId).style.display="block";
		
		var value = param.split('=')[1];
        document.getElementById(param.split('=')[0]).innerHTML=value;
	}
}

//显示层  并填入数据的类型为 图片的路径
function showDiv_getImg(divId,param)
{
	if(document.getElementById(divId).style.display=="none")
	{
		document.getElementById(divId).style.display="";
		//document.getElementById(divId).style.display="block";

		document.getElementById(param.split('=')[0]).src=param.split('=')[1];
	}
}

//关闭层
function closeDiv(divId)
{
	 document.getElementById(divId).style.display="none";
	 var obj=document.getElementById("message");
	 obj.innerHTML="";
}


function goToMeetingReceipt(formName,url){

	var form=document.getElementById(formName);
	form.action=url;
	form.submit();
}

//form表单提交  参数 formName为 form名称 ,fileName为 文本框的名称,参数 url为 要跳转到Action的路径
function formSubmit(formName,fileName,url){
	if(fileName!=""){
		var fileValue=document.getElementById(fileName);
		//判断 下拉框 的选项  -1 表示没有选择 选择的为空
		if(fileValue.value=="" ||fileValue.value == -1){
			return ;
		}
	}
	var form=document.getElementById(formName);
	if(url!="")
	{
		form.action=url;
	}
	form.submit();
}

/*********************
*    数据分页      *
*********************/

//分页 跳转到服务器 提取数据

function jumping(formName,hidePageName)
{
	var obj= document.getElementById(formName);
	var objPage= document.getElementById(hidePageName);
	
	var type = objPage.value;
	
	if(type=='all')
	{
		obj.action="meetingInform!findAllMeetingInfom.action";
	}
	else if(type=='byUserId')
	{
		obj.action="meetingInform!findAllMeetingInformByUserId.action";
	}
	else if(type='byInformCreateDate')
	{
		obj.action="meetingInform!findMeetingInformByUserIdInformCreateDate.action";
	}
	
  	obj.submit();
}

function fun(formName,hidePageName,page)
{
	var obj= document.getElementById(formName);
	var objPage= document.getElementById(hidePageName);
	
	var type = objPage.value;

	if(type=='all')
	{
		obj.action="meetingInform!findAllMeetingInfom.action";
	}
	else if(type=='byUserId')
	{
		obj.action="meetingInform!findAllMeetingInformByUserId.action";
	}
	else if(type='byInformCreateDate')
	{
		obj.action="meetingInform!findMeetingInformByUserIdInformCreateDate.action";
	}
	
	obj.page.value=page;
	obj.submit();
}



/*********************
*    数据分页      *
*********************/

//分页 跳转到服务器 提取数据

function myJumping(formName,hidePageName)
{
	var obj= document.getElementById(formName);
	var objPage= document.getElementById(hidePageName);
	
	var type = objPage.value;

	if(type=='all')
	{
		obj.action="meetingInform!findAllMeetingInfom.action";
	}
	else if(type=='myMeetingInformByUserId')
	{
		obj.action="meetingInform!findMyMeetingInformAllByUserId.action";
	}
	else if(type=='myByUserIdMeetingTitle')
	{
		obj.action="meetingInform!findMyMeetingInformByUserIdMeetingTitle.action";
	}
	else if(type=='myByUserIdInformCreateDate')
	{
		obj.action="meetingInform!findMyMeetingInformByUserIdInformCreateDate.action";
	}
	
  	obj.submit();
}

function myFun(formName,hidePageName,page)
{
	var obj= document.getElementById(formName);
	var objPage= document.getElementById(hidePageName);
	
	var type = objPage.value;

	if(type=='all')
	{
		obj.action="meetingInform!findAllMeetingInfom.action";
	}
	else if(type=='myMeetingInformByUserId')
	{
		obj.action="meetingInform!findMyMeetingInformAllByUserId.action";
	}
	else if(type=='myByUserIdMeetingTitle')
	{
		obj.action="meetingInform!findMyMeetingInformByUserIdMeetingTitle.action";
	}
	else if(type=='myByUserIdInformCreateDate')
	{
		obj.action="meetingInform!findMyMeetingInformByUserIdInformCreateDate.action";
	}
	
	
	obj.page.value=page;
	obj.submit();
}


//复选框全选
function checkAll(obj,formName)
{
    var form=document.getElementById(formName);
	if(obj.checked==true)
	{
		for (var i = 0; i < form.all.length; i++) {
			form.all[i].checked = true;
		}
	}
	else
	{
		for(var i=0;i<form.all.length;i++)
		{
			form.all[i].checked=false;
		}
	}
}

//批量删除
function deleteMeetingInforms(formName) 
{
	var re = false;
	var form = document.getElementById(formName);

	for (var i = 0; i < form.ids.length; i++) {
		if (form.ids[i].checked) {
			re = true;
		}
	}
	if (re) {
		if (confirm("\u60a8\u786e\u8ba4\u5220\u9664?")) {
			if(form.page != null)
			  form.page.value = 1;
			  form.action = "userInfo_DeleteAll.action";
			  form.submit();
		}
	} else {
		alert("\u8bf7\u9009\u62e9\u9700\u8981\u5220\u9664\u7684\u6570\u636e");
	}
}


