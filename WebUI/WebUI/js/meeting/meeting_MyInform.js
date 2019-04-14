
/*********************
*    ��ʾ/��ʧ ֪ͨ���Ĳ�      *
*********************/

//�Ƚϻ��鿪ʼʱ���Ƿ��� ��ǰʱ��֮��
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

//��ʾ��  
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
	
	//������Ҫ���µ�ֵ ����֪ͨ���Ķ�״̬
	document.getElementById(isRead).value=param;
	
	//�������º����������ڻ���Ŀ�ʼʱ��͵�ǰʱ����бȽ� ��������Ѿ���ʼ ��ظ���ť���ɵ��
	if(!isBegin(meetingBeginTime)){
		document.getElementById(receipt).disabled="disabled";
	}
	
	var objIsRead=document.getElementById("isRead"+rowId);
	if(objIsRead.outerText.replace(" ","")=="δ�鿴"){
		//���� ajaxMeetingInform.js�ļ���ĺ������� �������ݿ����ݵĸ��� (���»���֪ͨ���Ķ�״̬Ϊ���Ķ�)
		changeMeetingInformIsRead(rowId,url);
	}
}

/** �ظ�����֪ͨ ���Ϊ����ϯʱ����ϯ��ԭ����� **/
function meetingReceipt(meetingBeginTime,formName,rowId,isRead,param,url)
{
	if(!isBegin(meetingBeginTime)){
		alert("�����Ѿ���ʼ��,����Ҫ����ִ�ˣ�");
		return ;
	}

   	var form = document.getElementById(formName);
   	var  value=form.state.options[form.state.selectedIndex].value;
	if(value=="0")
	{
		if(form.receiptContent.value.replace(" ","")=="")
		{
			alert("��˵��ȱϯԭ��!!");
			return false;
		}
	}
	document.getElementById(isRead).value=param;
	url=url+"?informId="+form.informId.value+"&state="+form.state.value+"&receiptContent="+form.receiptContent.value+"&isRead=2";
	//���� ajaxMeetingInform.js�ļ���ĺ������� �������ݿ����ݵĸ��� 
	//(����MeetingReceipt��ִ�������һ������ Ȼ����»���֪ͨ���Ķ�״̬Ϊ�ѻظ�)
	changeMeetingInformIsRead(rowId,url);
}

//��ʾ��  ���������ݵ�����Ϊ �ı���
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


////��ʾ��  ���������ݵ�����Ϊ ��
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


//��ʾ��  ���������ݵ�����Ϊ ��
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

//��ʾ��  ���������ݵ�����Ϊ ͼƬ��·��
function showDiv_getImg(divId,param)
{
	if(document.getElementById(divId).style.display=="none")
	{
		document.getElementById(divId).style.display="";
		//document.getElementById(divId).style.display="block";

		document.getElementById(param.split('=')[0]).src=param.split('=')[1];
	}
}

//�رղ�
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

//form���ύ  ���� formNameΪ form���� ,fileNameΪ �ı��������,���� urlΪ Ҫ��ת��Action��·��
function formSubmit(formName,fileName,url){
	if(fileName!=""){
		var fileValue=document.getElementById(fileName);
		//�ж� ������ ��ѡ��  -1 ��ʾû��ѡ�� ѡ���Ϊ��
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
*    ���ݷ�ҳ      *
*********************/

//��ҳ ��ת�������� ��ȡ����

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
*    ���ݷ�ҳ      *
*********************/

//��ҳ ��ת�������� ��ȡ����

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


//��ѡ��ȫѡ
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

//����ɾ��
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


