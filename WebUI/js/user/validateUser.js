/*******************************
*         输入信息的基本验证       *
*******************************/
/*
//人员名称验证，是否为中文，输入其他无效
function chkuname(uname){
  var filter=/[\u4e00-\u9fa5]/;
  if (!filter.test(uname)) { return false; }
  return true;
}*/

//登录帐号验证，不能为中文，最少4位
function chkulogin(uname){
  var filter=/^\s*[A-Za-z0-9_-]{4,20}\s*$/;
  if (!filter.test(uname)) { return false; }
  return true;
}
//密码验证，只能输入英文或数字，不能有空格，最少4位，最多20位
function chkuPassword(password){
  var filter=/^\s*[.A-Za-z0-9_-]{4,20}\s*$/;
  if (!filter.test(password)) { return false; }
  return true;
}
//邮箱格式验证,格式必须为:****@***.**的格式
function chkEmail(Email) {
  if (Email.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1)
    return true;
  else
    return false;
}
//数值检测
function isNumber(name)  
{  
if(name.length  ==  0)
	return  false;
for(i  =  0;  i  <  name.length;  i++)  {  
		if(name.charAt(i)  > "0"  &&  name.charAt(i) <  "9")
			return  true;
		}
return  false;
}


/*********************
*     DIV提示验证      *
*********************/

//人员名称
function chechUserName(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(objId.value.length<2){
		 obj.innerHTML = "<font color=red>人员名称输入有误,只能为中文或英文且最少2位!</font>";
		 return;
	 }
	 else if(isNumber(objId.value))
	 {
		  obj.innerHTML = "<font color=red>人员名称输入有误,只能为中文或英文且最少2位!</font>";
		 return;
	 }
	else{	   
	  if(true){
	   obj.innerHTML="<font color=#33cc66>人员名称有效!</font>";
	  }
	 }
	 //sendRequest();
	  return;
}

//生日
function chechBirthday(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(objId.value == ""){
		 obj.innerHTML = "<font color=red>出生日期没有选择</font>";
		 return;
	 }
	else{	 
	  if(true){
	   obj.innerHTML="<font color=#33cc66>出生日期有效！</font>";
	  }
	 }
	 //sendRequest();
	  return; 
}

//职务
function chechDuty(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(objId.value == ""){
		 obj.innerHTML = "<font color=red>添加人的职位未填写</font>";
		 return;
	 }
	else{	 
	  if(true){
	   obj.innerHTML="<font color=#33cc66>职务有效</font>";
	  }
	 }
	 //sendRequest();
	  return; 
}



//登录帐户
function chechUserLogin(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(!chkulogin(objId.value)){
		 obj.innerHTML = "<font color=red>登录帐号输入有误,最少4位且不能包含中文或特殊符号</font>";
		 return;
	 }
	else{	 
	  if(true){
	   obj.innerHTML="<font color=#33cc66>登录帐号有效！</font>";
	  }
	 }
	 //sendRequest();
	  return; 
}

//邮箱
function chechUserEmail(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(!chkEmail(objId.value)){
		 obj.innerHTML = "<font color=red>邮箱输入有误，请正确填写</font>";
		 return;
	 }
	else{	   
	  if(true){
	   obj.innerHTML="<font color=#33cc66>邮箱有效！</font>";
	  }
	 }
	 //sendRequest();
	  return;
}

//电话
function chechUserPhone(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(!isNumber(objId.value)){
		 obj.innerHTML = "<font color=red>电话号码输入有误，请正确填写</font>";
		 return;
	 }
	else{	   
	  if(true){
	   obj.innerHTML="<font color=#33cc66>电话号码有效！</font>";
	  }
	 }
	 //sendRequest();
	  return;
}

//密码
function chechUserPassword(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    if(!chkuPassword(objId.value)){
		 obj.innerHTML = "<font color=red>密码长度为4-20位，只能由英文字母、数字组成，中间不能有空格。</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>密码有效！</font>";
	} 
}

//确认密码
function chechUserPassword2(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    var objId2 = document.getElementById("userPassword");
    if((objId.value!=objId2.value)||!chkuPassword(objId.value)){
		 obj.innerHTML = "<font color=red>确认密码要与密码完全一致，注意英文字母大小写。</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>确认密码有效！</font>";
	} 
}

//地址
function chechUserAddress(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    if(objId.value==""){
		 obj.innerHTML = "<font color=red>目前所在地址必须填写。</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>地址有效！</font>";
	} 
}
//学历
function chechSchoolAge(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    if(objId.value==""){
		 obj.innerHTML = "<font color=red>请填写学历信息。</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>学历信息有效！</font>";
	} 
}
//专业
function chechSpecialty(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    if(objId.value==""){
		 obj.innerHTML = "<font color=red>所学专业信息必须填写。</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>专业信息有效！</font>";
	} 
}
//身份证
function chechUserIdCard(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    if(!isNumber(objId.value)||objId.value.length<18){
		 obj.innerHTML = "<font color=red>身份证号为18位，只能为数字组成。</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>身份证号有效！</font>";
	} 
}

/*****************
*    表单验证       *
******************/

function frmCheck(){
    
    if(document.getElementById("userLogin").value==""){
       alert('登录帐号名必须正确填写');
       addUserFrm.userLogin.focus();
       return false;
    }
    
    var pas1 = document.getElementById("userPassword") ;
    var pas2 = document.getElementById("userPasswordConfirm") ;
    if(!chkuPassword(pas1.value)){
     alert('密码必须正确填写！');
     addUserFrm.userPassword.focus();
     return false;
    }
    if(!chkuPassword(pas2.value)||pas2.value!=pas1.value){
     alert('确认密码必须正确填写！');
     addUserFrm.userPasswordConfirm.focus();
     return false;
    }
	if(document.getElementById("userName").value==""){
       alert('人员名称必须正确填写');
       addUserFrm.userName.focus();
       return false;
    }
    if(document.getElementById("userAddress").value==""){
       alert('目前所在地址必须填写');
       addUserFrm.userAddress.focus();
       return false;
    }
    if(document.getElementById("userIdCard").value=="" ||document.getElementById("userIdCard").value.length<18 ){
       alert('身份证号必须正确填写');
       addUserFrm.userIdCard.focus();
       return false;
    }
    if(document.getElementById("userBirthday").value==""){
       alert('出生日期必须选择');
       addUserFrm.userBirthday.focus();
       return false;
    }
    if(document.getElementById("userEmail").value==""){
       alert('请输入邮箱！');
       addUserFrm.userEmail.focus();
       return false;
    } else if(!chkEmail(document.getElementById("userEmail").value)) {
       alert('邮箱格式输入错误');
	   addUserFrm.userEmail.focus();
       return false;
    }
    
    if(document.getElementById("userMobel").value==""){
       alert('请输入电话号码~！');
       addUserFrm.userMobel.focus();
       return false;
    } else if(!isNumber(document.getElementById("userMobel").value)){;
    	alert('电话号码输入有误');
		 addUserFrm.userMobel.focus();
    	return false;
    }
    if(document.getElementById("userEduction").value==""){
       alert('学历信息必须填写');
       addUserFrm.userEduction.focus();
       return false;
    }
    if(document.getElementById("userSpecialty").value==""){
       alert('专业信息必须填写');
       addUserFrm.userSpecialty.focus();
       return false;
    }
    if(document.getElementById("publish").value=="") {
    	alert('请选择部门');  
    	addUserFrm.publish.focus();
    	return false;
    }
    return true;
}
/***/
function showNotice(obj){
	var objMsg=document.getElementById(obj.userName+"_Msg");
	if(objMsg.className!="warning"&&(objMsg.innerHTML!="sdfdsf")&&(objMsg.innerHTML!="&nbsp;"))	
		objMsg.className="notice";
}