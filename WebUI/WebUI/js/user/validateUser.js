/*******************************
*         ������Ϣ�Ļ�����֤       *
*******************************/
/*
//��Ա������֤���Ƿ�Ϊ���ģ�����������Ч
function chkuname(uname){
  var filter=/[\u4e00-\u9fa5]/;
  if (!filter.test(uname)) { return false; }
  return true;
}*/

//��¼�ʺ���֤������Ϊ���ģ�����4λ
function chkulogin(uname){
  var filter=/^\s*[A-Za-z0-9_-]{4,20}\s*$/;
  if (!filter.test(uname)) { return false; }
  return true;
}
//������֤��ֻ������Ӣ�Ļ����֣������пո�����4λ�����20λ
function chkuPassword(password){
  var filter=/^\s*[.A-Za-z0-9_-]{4,20}\s*$/;
  if (!filter.test(password)) { return false; }
  return true;
}
//�����ʽ��֤,��ʽ����Ϊ:****@***.**�ĸ�ʽ
function chkEmail(Email) {
  if (Email.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1)
    return true;
  else
    return false;
}
//��ֵ���
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
*     DIV��ʾ��֤      *
*********************/

//��Ա����
function chechUserName(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(objId.value.length<2){
		 obj.innerHTML = "<font color=red>��Ա������������,ֻ��Ϊ���Ļ�Ӣ��������2λ!</font>";
		 return;
	 }
	 else if(isNumber(objId.value))
	 {
		  obj.innerHTML = "<font color=red>��Ա������������,ֻ��Ϊ���Ļ�Ӣ��������2λ!</font>";
		 return;
	 }
	else{	   
	  if(true){
	   obj.innerHTML="<font color=#33cc66>��Ա������Ч!</font>";
	  }
	 }
	 //sendRequest();
	  return;
}

//����
function chechBirthday(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(objId.value == ""){
		 obj.innerHTML = "<font color=red>��������û��ѡ��</font>";
		 return;
	 }
	else{	 
	  if(true){
	   obj.innerHTML="<font color=#33cc66>����������Ч��</font>";
	  }
	 }
	 //sendRequest();
	  return; 
}

//ְ��
function chechDuty(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(objId.value == ""){
		 obj.innerHTML = "<font color=red>����˵�ְλδ��д</font>";
		 return;
	 }
	else{	 
	  if(true){
	   obj.innerHTML="<font color=#33cc66>ְ����Ч</font>";
	  }
	 }
	 //sendRequest();
	  return; 
}



//��¼�ʻ�
function chechUserLogin(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(!chkulogin(objId.value)){
		 obj.innerHTML = "<font color=red>��¼�ʺ���������,����4λ�Ҳ��ܰ������Ļ��������</font>";
		 return;
	 }
	else{	 
	  if(true){
	   obj.innerHTML="<font color=#33cc66>��¼�ʺ���Ч��</font>";
	  }
	 }
	 //sendRequest();
	  return; 
}

//����
function chechUserEmail(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(!chkEmail(objId.value)){
		 obj.innerHTML = "<font color=red>����������������ȷ��д</font>";
		 return;
	 }
	else{	   
	  if(true){
	   obj.innerHTML="<font color=#33cc66>������Ч��</font>";
	  }
	 }
	 //sendRequest();
	  return;
}

//�绰
function chechUserPhone(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(!isNumber(objId.value)){
		 obj.innerHTML = "<font color=red>�绰����������������ȷ��д</font>";
		 return;
	 }
	else{	   
	  if(true){
	   obj.innerHTML="<font color=#33cc66>�绰������Ч��</font>";
	  }
	 }
	 //sendRequest();
	  return;
}

//����
function chechUserPassword(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    if(!chkuPassword(objId.value)){
		 obj.innerHTML = "<font color=red>���볤��Ϊ4-20λ��ֻ����Ӣ����ĸ��������ɣ��м䲻���пո�</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>������Ч��</font>";
	} 
}

//ȷ������
function chechUserPassword2(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    var objId2 = document.getElementById("userPassword");
    if((objId.value!=objId2.value)||!chkuPassword(objId.value)){
		 obj.innerHTML = "<font color=red>ȷ������Ҫ��������ȫһ�£�ע��Ӣ����ĸ��Сд��</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>ȷ��������Ч��</font>";
	} 
}

//��ַ
function chechUserAddress(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    if(objId.value==""){
		 obj.innerHTML = "<font color=red>Ŀǰ���ڵ�ַ������д��</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>��ַ��Ч��</font>";
	} 
}
//ѧ��
function chechSchoolAge(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    if(objId.value==""){
		 obj.innerHTML = "<font color=red>����дѧ����Ϣ��</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>ѧ����Ϣ��Ч��</font>";
	} 
}
//רҵ
function chechSpecialty(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    if(objId.value==""){
		 obj.innerHTML = "<font color=red>��ѧרҵ��Ϣ������д��</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>רҵ��Ϣ��Ч��</font>";
	} 
}
//���֤
function chechUserIdCard(objId){
    var obj = document.getElementById(objId.name+"_Msg");
    if(!isNumber(objId.value)||objId.value.length<18){
		 obj.innerHTML = "<font color=red>���֤��Ϊ18λ��ֻ��Ϊ������ɡ�</font>";
		 return;
	 }
	else{
	    obj.innerHTML="<font color=#33cc66>���֤����Ч��</font>";
	} 
}

/*****************
*    ����֤       *
******************/

function frmCheck(){
    
    if(document.getElementById("userLogin").value==""){
       alert('��¼�ʺ���������ȷ��д');
       addUserFrm.userLogin.focus();
       return false;
    }
    
    var pas1 = document.getElementById("userPassword") ;
    var pas2 = document.getElementById("userPasswordConfirm") ;
    if(!chkuPassword(pas1.value)){
     alert('���������ȷ��д��');
     addUserFrm.userPassword.focus();
     return false;
    }
    if(!chkuPassword(pas2.value)||pas2.value!=pas1.value){
     alert('ȷ�����������ȷ��д��');
     addUserFrm.userPasswordConfirm.focus();
     return false;
    }
	if(document.getElementById("userName").value==""){
       alert('��Ա���Ʊ�����ȷ��д');
       addUserFrm.userName.focus();
       return false;
    }
    if(document.getElementById("userAddress").value==""){
       alert('Ŀǰ���ڵ�ַ������д');
       addUserFrm.userAddress.focus();
       return false;
    }
    if(document.getElementById("userIdCard").value=="" ||document.getElementById("userIdCard").value.length<18 ){
       alert('���֤�ű�����ȷ��д');
       addUserFrm.userIdCard.focus();
       return false;
    }
    if(document.getElementById("userBirthday").value==""){
       alert('�������ڱ���ѡ��');
       addUserFrm.userBirthday.focus();
       return false;
    }
    if(document.getElementById("userEmail").value==""){
       alert('���������䣡');
       addUserFrm.userEmail.focus();
       return false;
    } else if(!chkEmail(document.getElementById("userEmail").value)) {
       alert('�����ʽ�������');
	   addUserFrm.userEmail.focus();
       return false;
    }
    
    if(document.getElementById("userMobel").value==""){
       alert('������绰����~��');
       addUserFrm.userMobel.focus();
       return false;
    } else if(!isNumber(document.getElementById("userMobel").value)){;
    	alert('�绰������������');
		 addUserFrm.userMobel.focus();
    	return false;
    }
    if(document.getElementById("userEduction").value==""){
       alert('ѧ����Ϣ������д');
       addUserFrm.userEduction.focus();
       return false;
    }
    if(document.getElementById("userSpecialty").value==""){
       alert('רҵ��Ϣ������д');
       addUserFrm.userSpecialty.focus();
       return false;
    }
    if(document.getElementById("publish").value=="") {
    	alert('��ѡ����');  
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