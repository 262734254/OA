//�����ύ���n ��ǰҳ�汻�ύ��form���ƣ�nextpage �ύҳ�����ƣ�
//command �ύִ�����anexecute �ύ�Ƿ�ִ������
var chknum=0;//�û�ѡ��ļ�¼��
var check="";//�û�ѡ��ļ�¼����ֵ


//��������������(ϵͳ����)**��ʼ**��������������

//ҳ�����ʱ�����Ҽ��˵�
function Document_onLoad(){

	//document.oncontextmenu = function() {
	//	var tagName = event.srcElement.tagName.toLowerCase();
	//	if (tagName != "input"
	//		&& tagName != "textarrea"
	//		&& tagName != "select") {
	//		return false;
	//	}
	//};
	//document.onclick = function() {return (event.shiftKey == false)};
	//document.onkeydown = function () {
	//	if (event.keyCode == 116 || event.keyCode == 122) {
	//		event.keyCode = 0;
	//		event.returnValue = 0;
	//	}
	//};
} 
//��ʱ����������Ϊ��ʱ��������
function sleep(milliSeconds){
	showModalDialog("../gwp/controller?nextpage=sleep&command=&canexecute=false", milliSeconds, "dialogWidth:15; dialogHeight:1; status:no; center:yes; dialogHide:yes");
}
//ȡ������
function cancel_back(){
	window.history.go(-1);
}
//�ر�
function cancel_close(){
	window.close();
} 
//�˳�ϵͳ
function quit(){
	top.close();
}
//��������������(ϵͳ����)**����**��������������

//��������������(���桢�޸ġ�ɾ����ť����)**��ʼ**��������������
//����Cmd,��ʾҳ��
function pageshow(n,nextpage,command,canexecute){
	document.forms[n].nextpage.value=nextpage;
	document.forms[n].command.value=command;
	document.forms[n].canexecute.value=canexecute;
	document.forms[n].action = "/SEWeb/se/controller"
	document.forms[n].submit();
}
function LdapPageshow(n,nextpage,command,canexecute,context){
	document.forms[n].nextpage.value=nextpage;
	document.forms[n].command.value=command;
	document.forms[n].canexecute.value=canexecute;
	document.forms[n].context.value = context + document.forms[n].context.value;
	document.forms[n].action = "/GWPWEB/gwp/controller"
	document.forms[n].submit();
}
//�ж�checkvalue�����Ƿ���ֵ
function ischecked(){
	var els = document.getElementsByName("check");
	for (var i = 0; i < els.length; i++){
		var el = els.item(i);
		if (el.checked){
			return true;
		}
	}
	alert("��ѡ��Ҫ�����ļ�¼��");
	return false;
}
//ִ�а�ť����ǰ����Ƿ�ѡ�в�����¼��
function checkcmd(n,nextpage,command,canexecute){
	if(ischecked()){
		if(confirm("ɾ���󲻿ɻָ���ȷ����")){
			pageshow(n,nextpage,command,canexecute);
		}else false;
	}else false;
}
function checkUserDepartcmd(n,nextpage,command,canexecute){
	if(ischecked()){
		if(confirm("ɾ���󲻿ɻָ���ȷ����")){
			pageshow(n,nextpage,command,canexecute);
		}else false;
	}else false;
}
//����
function InfoModify(n,nextpage,command,canexecute,m){
	if(m=='one'){
		if(ischeckedOne()){
			pageshow(n,nextpage,command,canexecute);
		}
	}	
	else{
		if(ischecked()){
			pageshow(n,nextpage,command,canexecute);
		}		
	}	
}
//ˢ��
function appRefresh(n,nextpage,command,canexecute){
	pageshow(n,nextpage,command,canexecute);
	parent.frames("top").location = parent.frames("top").location
	parent.frames("left").location = parent.frames("left").location
}
//ɾ��
function InfoDelete(n,nextpage,command,canexecute){
	checkcmd(n,nextpage,command,canexecute);
}
//ѡ�м�¼
function ischeckedOne(){
	var els = document.getElementsByName("check");
	//alert(els.length);
	var j=0;
	for (var i = 0; i < els.length; i++){
		var el = els.item(i);
		if (el.checked){
			j++;	
		}
	}
	if(j==0){
		alert("��ѡ��Ҫ�����ļ�¼��");
		return false;
	}
	else if(j>1){
		alert("��ֻѡ��һ����¼��");
		j==0;
		return false;
	}
	else if(j==1){
		return true;
	}
}
//�жϲ����û�����������ϳ��µ��ַ�������Command
function deleteCheck(){
	var sValue = new Array();
	var sRtnValue = new Array();
	var j = 0;
	var k = 0;
	for(i=0;i < document.getElementsByName("check").length;i++){
		if(document.all("check").item(i).checked){
			sValue[i] = document.all("check").item(i).value;
			if(sValue[i].indexOf("U") != -1){
				j++;
				sRtnValue[j] = sValue[i].substring(1);
				hu.innerHTML += "<input type='hidden' name='checkdel' value='" + sRtnValue[j] + "'>";
				//window.alert("<input type='hidden' name='checkdel' value='" + sRtnValue[j] + "'>");
			}else{
				++k;
			}
		}
	}
	if (k > 0){
		alert("�������ڴ˴�ɾ������");
	}else{
		checkcmd(0,'UserDepartList','delUser','true');
	}
} 
//ɾ������
function delDepart(n,nextpage,command,canexecute){
	if(confirm("ɾ���󲻿ɻָ���ȷ����")){
			pageshow(n,nextpage,command,canexecute);
	}else{
		return false;
	}
}
//�жϲ����û���ѡ���޸�ҳ��
function updateCheck(){
	var sValue = new Array();
	if(ischeckedOne()){
		for(i=0;i < document.getElementsByName("check").length;i++){
			if(document.all("check").item(i).checked){
				sValue[i] = document.all("check").item(i).value;
				document.all("checkvalue").value = sValue[i].substring(1);
				if(sValue[i].indexOf("U") != -1){ 
					pageshow(0,'UserUpdate','detailUser','true');
				}else{
					pageshow(0,'DepartUpdate','detailDepartment','true');
				}
			}
		}
	}
} 
//��������������LDAP�������������� ��ʼ��������������

//ɾ��LDAP����
function LDAPdelDepart(n,nextpage,command,canexecute){
	if(confirm("ɾ���󲻿ɻָ���ȷ����")){
			pageshow(n,nextpage,command,canexecute);
	}else{
		return false;
	}
}

//�ж�LDAP�����û�����������ϳ��µ��ַ�������Command
function LDAPdeleteCheck(){
	var sValue = new Array();
	var sRtnValue = new Array();
	var j = 0;
	var k = 0;
	for(i=0;i < document.getElementsByName("check").length;i++){
		if(document.all("check").item(i).checked){
			sValue[i] = document.all("check").item(i).value;
			if(sValue[i].indexOf("UID") != -1){
				j++;
				sRtnValue[j] = sValue[i];
				hu.innerHTML += "<input type='hidden' name='checkdel' value='" + sRtnValue[j] + "'>";
				//window.alert("<input type='hidden' name='checkdel' value='" + sRtnValue[j] + "'>");
			}else{
				++k;
			}
		}
	}
	if (k > 0){
		alert("�������ڴ˴�ɾ������");
	}else{
		checkcmd(0,'LdapList','DeleteLDAPUserCmd','true');
	}
} 

//�ж�LDAP�����û���ѡ���޸�ҳ��
function LDAPupdateCheck(){
	var sValue = new Array();
	if(ischeckedOne()){
		for(i=0;i < document.getElementsByName("check").length;i++){
			if(document.all("check").item(i).checked){
				sValue[i] = document.all("check").item(i).value;
				document.all("checkvalue").value = sValue[i];
				if(sValue[i].indexOf("UID=") != -1){ 
					pageshow(0,'UpdateLDAPUser','DisplayLDAPUserDetailCmd','true');
				}else{
					pageshow(0,'UpdateLDAPDepartment','DisplayLDAPDepartmentDetailCmd','true');
				}
			}
		}
	}
} 

//LDAP�û�У��
function LDAPuserDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "uid").value.trim() == ""){
		alert("�û���¼������Ϊ�գ�");
		document.all(type + "uid").focus();
	}else if(document.all(type + "userPassword").value.trim() == ""){
		alert("��¼���벻��Ϊ�գ�");
		document.all(type + "userPassword").focus();
	}else if(document.all(type + "cn").value.trim() == ""){
		alert("�û��ղ���Ϊ�գ�");
		document.all(type + "cn").focus();
	}else if(document.all(type + "sn").value.trim() == ""){
		alert("�û�������Ϊ�գ�");
		document.all(type + "sn").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//LDAP����У��
function LDAPdeptDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "ou").value.trim() == ""){
		alert("�������Ʋ���Ϊ�գ�");
		document.all(type + "ou").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//�û���У��
function LDAPgroupDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "cn").value.trim() == ""){
		alert("�û������Ʋ���Ϊ�գ�");
		document.all(type + "cn").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}

//��������������LDAP��������������  ������������������



//����ֵѡ��
function checkselect(chk)
{
	if (chk.checked){
    	document.forms[0].checkvalue.value=chk.value;
    	chknum++;
    	//����ֵ�ۼ�
    	check=check+"|"+chk.value;  
    	//alert(chknum+"/"+check);  
 	}else{
  		chknum--;
  		//������ֵ��ɾ��ȡ��ѡ���������
  		if(check!=""){
       		var delstr="|"+chk.value;
       		check=check.substring(0,check.indexOf(delstr))+check.substring(check.indexOf(delstr)+delstr.length,check.length+1);       	
        } 
		if(document.forms[0].checkvalue.value==chk.value){
			//���õ�ѡֵ
			document.forms[0].checkvalue.value=check.substring(check.lastIndexOf("|")+1,check.length+1);                 
		}    
	}
}
//ִ�а�ť����ǰ����Ƿ�ѡ�в�����¼��
function checkupdate(n,nextpage,command,canexecute){
	if(document.forms[0].checkvalue.value == null || document.forms[0].checkvalue.value == ""){
		alert("��ѡ��Ҫ�����ļ�¼��");
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//ʾ������
function samplesave(n,nextpage,command,canexecute){
	if (document.forms[n].Ins_Sample_Name.value == null || document.forms[n].Ins_Sample_Name.value.trim() == ""){
		alert("�Բ������Ʋ���Ϊ�գ�");
		return;
	}
	if (document.forms[n].Ins_Sample_Email.value == null || document.forms[n].Ins_Sample_Email.value.trim() == ""){
		alert("�Բ��𣬵����ʼ�����Ϊ�գ�");
		return;
	}
	pageshow(n,nextpage,command,canexecute);
}
//���Ľ������Ӧ��ϵ����
function FieldXmlSave(n,nextpage,command,canexecute){
	if (document.forms[n].ModName.value == null || document.forms[n].ModName.value.trim() == ""){
		alert("�Բ���ģ�����Ʋ���Ϊ�գ�");
		return;
	}
	if (document.forms[n].FieldName.value == null || document.forms[n].FieldName.value.trim() == ""){
		alert("�Բ�����������Ϊ�գ�");
		return;
	}
	if (document.forms[n].XmlTag.value == null || document.forms[n].XmlTag.value.trim() == ""){
		alert("�Բ���XML��ǩ����Ϊ�գ�");
		return;
	}	
	pageshow(n,nextpage,command,canexecute);
}
//�¼���������ʾ
function openAppDialog(id){
	document.forms[0].checkvalue.value=id;
	pageshow(0,'ApplicationList','ApplicationList','true');
}
function openDictDialog(id){
	document.forms[0].checkvalue.value=id;
	pageshow(0,'DictionaryList','DictionaryList','true');
}
function openGroupDialog(id){
	document.forms[0].GroupID.value=id;
	pageshow(0,'UserList','userListCmd','true'); 
}
function openDeptDialog(id){
	document.forms[0].ParentID.value=id;
	pageshow(0,'UserDepartList','commListCmd','true');
}
//ѡ��Ӧ��������
function btnOkApp(n,objName,nextpage,command,canexecute,type){
    var	sRtnValue = "";
    var sValue = "";
	for(i=0;i < document.getElementsByName("check").length;i++){
	   	if(document.all("check").item(i).checked){
			sValue = sValue + document.all("check").item(i).value + ",";
		}
	}
	if(sValue.length > 0){
		sRtnValue = sValue.substr(0,sValue.length - 1);
	}
	opener.document.all.item(objName).value=sRtnValue;
	opener.document.all.item("nextpage").value=nextpage;
	opener.document.all.item("command").value=command;
	opener.document.all.item("canexecute").value=canexecute;
	opener.document.all.item("type").value=type;
	window.close();
	opener.document.forms[n].submit();
}
//��������������(���桢�޸ġ�ɾ����ť����)**����**��������������

//��������������(�����Ի��򣬲�������","�ָ���ַ���)**��ʼ**��������������
//�����Ի���
function ShowDialog(objName,URL){
	var rtnValue;
	rtnValue = window.showModalDialog(URL,"","dialogWidth:300px;dialogHeight:400px;center:1;status:0;scroll:1");
	if(rtnValue!=null) {
		document.all.item(objName).value = rtnValue;
		return true;
	}else{
		return false;
	}
}
//��ɫ��ֵӦ����
function setPurview(n,nextpage,command,canexecute,type){

    if(document.forms[n].checkvalue.value==null||document.forms[n].checkvalue.value==""){
    	alert("����ѡ��һ����¼!");
    	return;
    }
    if(check.lastIndexOf("|")>0){
    	alert("�Բ�������ѡ��һ����¼!");
    	return;
    }
    var val=document.forms[n].checkvalue.value;
	var url="../gwp/controller?nextpage="+nextpage+"&command="+command+"&canexecute="+canexecute+"&checkvalue="+val+"&type="+type;
	window.open(url,"Ӧ��ѡ��","width=400,height=500,vscrollbars=yes");
	
}
//ȷ����ť���������е�ѡ������ɵ��ԡ������ָ���ַ���
function btnOk(){
	var	sRtnValue = "";
	var sValue = "";
	var ss = "";
	if(document.all("check")!=null){
		for(i=0;i < document.getElementsByName("check").length;i++){
			if(document.all("check").item(i).checked){
				ss = document.all("check").item(i).value;
				if(ss.indexOf("|") != -1){
					if(ss.indexOf("*") != -1){
						ss= ss.substring(1,ss.indexOf("|"));
					}else{
						ss= ss.substring(0,ss.indexOf("|"));
					}
				}
				sValue=sValue+ss+",";
			}
		}
		if(sValue.length > 0){
			sRtnValue = sValue.substr(0,sValue.length - 1);
		}
		window.returnValue = sRtnValue;
	}
	window.close();
}

//��ɫ������û������š���
function assignRole(n,nextpage,command,canexecute,field,select,selecttype,type,parentid,asstype){
	if(document.forms[n].checkvalue.value==null||document.forms[n].checkvalue.value==""){
    	alert("����ѡ��һ����¼!");
    	return;
    }
    if(check.lastIndexOf("|")>0){
    	alert("�Բ�������ѡ��һ����¼!");
    	return;
    }
    var checkvalue=document.forms[n].checkvalue.value;
	if(ShowDialog(field,'../gwp/controller?nextpage='+nextpage+'&command='+command+'&canexecute='+canexecute+'&type='+select+'&selectType='+selecttype+'&dept_id='+parentid+"&assocType="+asstype+"&checkvalue="+checkvalue)){
		document.all.item('type').value=type;
		document.all.item('command').value="RoleAssignByType";
		document.all.item('nextpage').value="RoleList";
		document.all.item('canexecute').value="true";
		document.forms[n].submit();
	}
}
//�ջز��š��û���С��Ľ�ɫ
function getRole(n,nextpage,command,canexecute){
	if(document.forms[n].checkvalue.value==null||document.forms[n].checkvalue.value==""){
    	alert("����ѡ��һ����¼!");
    	return;
    }
    if(check.lastIndexOf("|")>0){
    	alert("�Բ�������ѡ��һ����¼!");
    	return;
    }
    pageshow(n,nextpage,command,canexecute);
}
//�û����顢����ѡ���ɫ
function allSelectRole(){
	var sValue = new Array();
	if(ischeckedOne()){
		if(document.all("check")!=null){
			for(i=0;i < document.getElementsByName("check").length;i++){
				if(document.all("check").item(i).checked){
					sValue[i] = document.all("check").item(i).value;
					if(sValue[i].indexOf("U") != -1){ 
						document.all("checkvalue").value = sValue[i].substring(1);
						if(ShowDialog('roles','../gwp/controller?nextpage=RoleSelect&command=RoleSelect&canexecute=true&type=3&checkvalue='+sValue[i].substring(1))){
						//if(document.all.item("roles").value!=null&&document.all.item("roles").value.length>0){
							pageshow(0,'UserDepartList','AddUserRole','true'); 
						}
					}else if(sValue[i].indexOf("D") != -1){
					    document.all("checkvalue").value = sValue[i].substring(1);	
	           			if(ShowDialog('roles','../gwp/controller?nextpage=RoleSelect&command=RoleSelect&canexecute=true&type=2&checkvalue='+sValue[i].substring(1))){	
							pageshow(0,'UserDepartList','AddDepartRole','true'); 
						}
					}else{
						document.all("checkvalue").value = sValue[i].substring(1);	
						if(ShowDialog('roles','../gwp/controller?nextpage=RoleSelect&command=RoleSelect&canexecute=true&type=4&checkvalue='+sValue[i])){
							pageshow(0,'GroupList','AddGroupRole','true'); 
						}
					}
					
				}
			}
		}
	}
}
//�û�������û�
function addUserDialog(){
	if(ShowDialog('user','../gwp/controller?command=UserTreeCmd&nextpage=TreeSelect&type=0&selectType=1&canexecute=true&dept_id=10000')){
		pageshow(0,'UserList','AddGroupUser','true');
	}
} 
//��������������(�����Ի��򣬲�������,�ָ���ַ���)**����**��������������

//��������������(��ҳ��ʾ)**��ʼ**��������������
//��һҳ
function uppage(n,nextpage,command,canexecute){
	var now=document.all.item("nowpage").value;
	if(now!=null){
		var up=parseInt(now);
		if(!isNaN(up)){
			if(now-1<=0){
				up=1;
			}else{
				up=now-1;
			}
			document.all.item("nowpage").value=up;
			pageshow(n,nextpage,command,canexecute);
		}
	}
}
//��һҳ
function nextpage(n,nextpage,command,canexecute){
	var now=document.all.item("nowpage").value;
	var all=document.all.item("allpage").value;
	if(now!=null&&all!=null){
		var next=parseInt(now);
		if(!isNaN(next)){
		    if(!isNaN(parseInt(all))){
				if(next+1>parseInt(all)){
					next=parseInt(all);
				}else{
					next+=1;
				}
				document.all.item("nowpage").value=next;
				pageshow(n,nextpage,command,canexecute);
			}
		}
	}
}
//���ڼ�ҳ
function gotopage(n,nextpage,command,canexecute){
    var now=document.all.item("nowpage").value;
	var all=document.all.item("allpage").value;
	var go=document.all.item("gopage").value;
	if(!isNaN(parseInt(go))){
		if(go!=null&&now!=null&&all!=null){	   
		    if(!isNaN(parseInt(all))&&parseInt(go)>parseInt(all)){
				document.all.item("nowpage").value=parseInt(all);
				pageshow(n,nextpage,command,canexecute);
				return;
			}
			if(parseInt(go)<1){
				document.all.item("nowpage").value="1";
				pageshow(n,nextpage,command,canexecute);
				return;
			}
			document.all.item("nowpage").value=parseInt(go);
			pageshow(n,nextpage,command,canexecute);
		}
	}
}
//��������������(��ҳ��ʾ)**����**��������������

//��������������(����У��)**��ʼ**��������������
//Ӧ������У��
function appDataCheck(n,nextpage,command,canexecute){
	if(document.all("Ins_AppName").value.trim() == ""){
		alert("Ӧ�����Ʋ���Ϊ�գ�");
		document.all("Ins_AppName").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//�ֵ�����У��
function dictDataCheck(n,nextpage,command,canexecute){
	if(document.all("Ins_Name").value.trim() == ""){
		alert("���Ʋ���Ϊ�գ�");
		document.all("Ins_Name").focus();
	}else if(document.all("Ins_Value").value.trim() == ""){
		alert("���벻��Ϊ�գ�");
		document.all("Ins_Value").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//��־��ѯУ��
function logDataCheck(n,nextpage,command,canexecute){
	if(document.all.item("Ins_StartDate").value.trim() == "" && document.all.item("Ins_EndDate").value.trim() == ""){
		alert("��ʼʱ�����ֹʱ�䲻��Ϊ�գ�����������д��");
		//document.all("Ins_StartDate").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//��ɫУ��
function roleDataCheck(n,nextpage,command,canexecute){
	if(document.all("Ins_RoleName").value.trim() == ""){
		alert("��ɫ���Ʋ���Ϊ�գ�");
		document.all("Ins_RoleName").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}

//�û���У��
function groupDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "GroupName").value.trim() == ""){
		alert("�û������Ʋ���Ϊ�գ�");
		document.all(type + "GroupName").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//����У��
function deptDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "Dept_Name").value.trim() == ""){
		alert("�������Ʋ���Ϊ�գ�");
		document.all(type + "Dept_Name").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}


//�û�У��
function userDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "Login_Name").value.trim() == ""){
		alert("�û���¼������Ϊ�գ�");
		document.all(type + "Login_Name").focus();
	}else if(document.all(type + "PassWord").value.trim() == ""){
		alert("��¼���벻��Ϊ�գ�");
		document.all(type + "PassWord").focus();
	}else if(document.all(type + "FamilyName").value.trim() == ""){
		alert("�û��ղ���Ϊ�գ�");
		document.all(type + "FamilyName").focus();
	}else if(document.all(type + "Name").vauserPassword() == ""){
		alert("�û�������Ϊ�գ�");
		document.all(type + "Name").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}

//��½��У��
function isRegister(sName){  
	var register=document.all(sName).value.trim();  
	var inchars = "_.1234567890abcdefghigklmnopqrstuvwxyzABCDEPGHIGKLMNOPQRSTUVWXYZ";  
	for (i=0;i< register.length;i++){  
		regChar=register.charAt(i)  
		if (inchars.indexOf(regChar, 0) == -1){ 
			alert("��¼�����������Ϊ���֡�26��ĸ���»�����С���㣡");
			document.all(sName).focus(); 
			return false;  
		}  
	}  
}
//����У��
function isNum(sName){
	var numNo=document.all(sName).value.trim();  
	var inChars = "1234567890";  
	for (i=0;i<numNo.length;i++){  
		numNoChar=numNo.charAt(i)  
		if (inChars.indexOf(numNoChar, 0) == -1){
			alert("��������������");
			document.all(sName).focus(); 
			return false;  
		}
	}
	return true;
}
//EMailУ��
function isEmail(sName){
	if (document.all(sName).value.trim()!=""){
		var email=(document.all(sName).value.trim());
		inChars = "/;,:{}[]|*%$#!()`<>?";
		for (i=0; i< inChars.length; i++){
			badChar = inChars.charAt(i)
			if (email.indexOf(badChar,0) > -1){
				alert("����Email���벻��ȷ��");
				document.all(sName).value.focus();
				return false;  
			} 
		}
		atEmail = email.indexOf("@",1)
		dotEmail = email.indexOf(".",atEmail)  
		if (atEmail == -1 || email.indexOf("@", atEmail+1) != -1 || dotEmail == -1 || atEmail +2 > dotEmail || dotEmail +3 > email.length){  
			alert("����Email���벻��ȷ��");
			document.all(sName).focus();
			return false;  
	    }
    }  
}
//�绰����У��  
function isTel(sName){  
	var tel=document.all(sName).value.trim();  
	var inChars = "-()1234567890,";  
	for (i=0;i<tel.length;i++){  
		telchar=tel.charAt(i)  
		if (inChars.indexOf(telchar, 0) == -1){ 
			alert("�绰����ֻ������'-()1234567890,'��");
			document.all(sName).focus(); 
			return false;  
		}  
	}  
}
//��������������(����У��)**����**��������������

//���̶��ƺͱ�����ϵͳ�ĺ���
	//ѡ��ģ�麯��
	function selModal(idField, nameField) {
		var rtnValue = window.showModalDialog("controller?nextpage=ModalSelect&command=ModalManagerCmd&canexecute=true&aaa=" + Math.random(), "", "dialogWidth:300px;dialogHeight:400px;center:1;status:0;scroll:1");
		if (rtnValue != null && rtnValue.trim() != "") {
			var values = rtnValue.split("��");
			document.getElementsByName(idField)[0].value = values[0];
			document.getElementsByName(nameField)[0].value = values[1];
		}
	}
	//��ȡ�������ǰURI���磺http://www.langchao.com.cn
	function getUri() {
		var protocol = window.location.protocol;
		var host = window.location.host;
		host = protocol+"//"+host;
		return host;	
	}
	
	//��ȡWord��������ȡʧ���򵯳���ʾ������null
	function getWord() {
		try{
			return new ActiveXObject("Word.Application");    //����word
		}
		catch (e) {
			alert("�Բ��𣬳�ʼ��Word����ʧ�ܣ�\n��ȷ�����Ƿ�װ��Microsoft Word 97����߰汾��\n���ҽ���վ����ӵ�����վ���б�");
			return null;
		}
	}
	
	//��ȡExcel��������ȡʧ���򵯳���ʾ������null
	function getExcel() {
		try{
			return new ActiveXObject("Excel.Application");    //����word
		}
		catch (e) {
			alert("�Բ��𣬳�ʼ��Excel����ʧ�ܣ�\n��ȷ�����Ƿ�װ��Microsoft Excel 97����߰汾��\n���ҽ���վ����ӵ�����վ���б�");
			return null;
		}
	}
	
	//��ָ���ļ�����Base64���룬�����ر������ַ���
	function encoding(filename){
		try {
			newMothod1.filename = filename;
			newMothod1.encode();                 //����Ҫ�༭���ļ�����
			var encodeString = newMothod1.encodeString;
			return encodeString;
		}
		catch (e) {
			alert("�Բ��𣬴����ļ�ʱ����\n��ȷ���ļ��Ƿ񱣴沢�رգ�");
			return null;
		}
	}

	//�Դ���ľ���Base64������ַ������н��룬�����ؽ������ļ�ȫ��
	function decoding(encodeString){
		newMothod1.decodeValue(encodeString);//��������ļ����н���
		var decodefile = newMothod1.decodefile;
		return decodefile;
	}
	//��ʼ��ģ��༭�Ի���
	function initTemplateEditor() {
		var success;
		if (data["mimetype"].toLowerCase() == "application/msword") {
			success = editTemplateWord();
		}
		else if(data["mimetype"].toLowerCase() == "application/vnd.ms-excel") {
			success = editTemplateExcel();
		}
		else {
			alert("�Բ���ģ�����Ͳ���ȷ��");
			success = false;
		}
		if (success == false) {
			window.close();
		}
	}
	//�༭Wordģ��
	function editTemplateWord() {
		app = getWord();
		if (app == null) {
			return false;
		}
		if (data["value"] == null || data["value"].trim() == "") {
			var url = getUri() + "/GWPWEB/resource/doc/word.doc";
			newMothod1.downFileFromUrl(url);
			fileName = newMothod1.DownLoadFileName;
		}
		else {
			fileName = decoding(data["value"]);
		}
		app.Documents.Open(fileName);
		if (data["templateName"] == "print.doc" && confirm("�Ƿ��ڴ�ӡģ��������µı����ݣ�")) {
			var xml = new ActiveXObject("Microsoft.XMLDOM");
			xml.async=false;
			xml.loadXML("<all>" + field + "</all>");
			var root = xml.documentElement;
			for (var i = 0; i < root.childNodes.length; i++) {
				if (root.childNodes.item(i).nodeType == 1) {
					app.Selection.TypeText("��" + root.childNodes.item(i).attributes.getNamedItem("displayname").nodeValue + "��");
					app.Selection.TypeParagraph();
				}
			}
		}
		app.visible = true;
		return true;	
	}
	//�༭Excelģ��
	function editTemplateExcel() {
		app = getExcel();
		if (app == null) {
			return false;
		}
		if (data["value"] == null || data["value"].trim() == "") {
			var url = getUri() + "/GWPWEB/resource/doc/excel.xls";
			newMothod1.downFileFromUrl(url);
			fileName = newMothod1.DownLoadFileName;
		}
		else {
			fileName = decoding(data["value"]);
		}
		var book = app.Workbooks.Open(fileName);
		book.Application.Visible = true;
		return true;
	}
	//ģ��༭���
	function editTemplateComplete() {
		if (document.forms[0].templateName.value == null || document.forms[0].templateName.value.trim() == "") {
			alert("�Բ���ģ�����Ʋ���Ϊ�գ�");
			document.forms[0].templateName.focus();
			return;
		}
		data["templateName"] = document.forms[0].templateName.value.trim();
		data["value"] = encoding(fileName);
		if (data["value"] != null) {
			window.returnValue = data;
			window.close();
		}
	}
	
	//ɾ��ѡ����ģ��
	function deleteTemplate() {
		if (!confirm("��ȷ��Ҫɾ��ָ����ģ����")) {
			return;
		}
		var sel = document.forms[0].TemplateList.options;
		for (var i = sel.length - 1; i > 0; i--) {
			if (sel[i].selected == true) {
				templates.splice(parseInt(sel[i].value), 1, null);
				document.forms[0].TemplateList.remove(i);
			}
		}
	}
	
	//ģ�����
	function completeTemplate() {
		var templateNode = "";
		var tempString = "";
		for (var i = 0; i < templates.length; i++) {
			if (templates[i] != null) {
				tempString += "<encodefile";
	   			for ( templateNode in templates[i] ) {
	    			if (templateNode != "value") {
	    				tempString += " " + templateNode + "=\"" + templates[i][templateNode] + "\"";
	    			}
	   			}
	   			tempString +=">" + templates[i]["value"] + "</encodefile>";
	   		}
  		}
  		window.returnValue = tempString;
  		window.close();
	}
	//�½�����ģ��
	function newTemplate(mimeType) {
		var newEl = new Array();
		newEl["templateName"] = "";
		newEl["template"] = "1";
		newEl["mimetype"] = mimeType;
		newEl["value"] = "";
		var newData = new Array();
		newData["template"] = newEl;
		newData["fields"] = field;
		result = showModalDialog("controller?nextpage=TemplateEdit&command=&canexecute=false&aaa=" + Math.random(), newData, "dialogWidth:250px; dialogHeight:100px; status:no; center:yes; scroll:no");
		if (result != null) {
			if (templates.length == 0) {
				templates[1] = result;
			}
			else {
				templates.push(result);
			}
			var myel = document.createElement("option");
			myel.value = new Number(templates.length - 1).toString();
			myel.text = result["templateName"];
			document.forms[0].TemplateList.add(myel);
		}
	}
	//�޸�ѡ����ģ��
	function modifyTemplate() {
		var selItem = document.forms[0].TemplateList.options[document.forms[0].TemplateList.selectedIndex];
		var myel = templates[parseInt(selItem.value)];
		if (myel == null) {
			myel = new Array();
			myel["templateName"] = "print.doc";
			myel["template"] = "0";
			myel["mimetype"] = "application/msword";
			myel["value"] = "";
		}
		var newData = new Array();
		newData["template"] = myel;
		newData["fields"] = field;
		var result = showModalDialog("controller?nextpage=TemplateEdit&command=&canexecute=false&aaa=" + Math.random(), newData, "dialogWidth:250px; dialogHeight:100px; status:no; center:yes; scroll:no");
		//myel["templateName"] = "aaaaa";
		//var result = myel;
		if (result != null) {
			selItem.text = result["templateName"];
			templates.splice(parseInt(selItem.value), 1, result);
		}
	}
	
	function HTMLencode(strToCode) { 
		strToCode = strToCode.replace(/</g,"&lt;");
		strToCode = strToCode.replace(/>/g,"&gt;");
		return strToCode;
	}
	//�����
	function saveForm(n, nextpage, command, canexecute, complete) {
		if (document.FormEditor.isFormAttribute() == true) {
			alert("�Բ��𣬱�����ҳ��ʱ���ܱ������");
			return;
		}
		if (document.forms[n].Ins_Form_Moid.value == null || document.forms[n].Ins_Form_Moid.value.trim() == "") {
			alert("�Բ�������û��ѡ�������ģ�飡");
			document.ModSel.focus();
			return;
		}
		document.forms[n].Ins_Form_IsComplete.value = complete;
		document.forms[n].Ins_Form_FormName.value = document.FormEditor.getFormName();
		document.forms[n].Ins_Form_Caption.value = document.FormEditor.getFormTitle();
		document.forms[n].Ins_Form_FormOrder.value = document.FormEditor.getFormNum();
		document.forms[n].Ins_Form_Html.value = HTMLencode(document.FormEditor.getFormStr());
		document.forms[n].Ins_Form_FieldList.value = document.FormEditor.getFieldStr();
		document.forms[n].Ins_Form_LocalAction.value = document.FormEditor.getLocalAction();
		if (document.forms[n].Ins_Form_FormName.value == null || document.forms[n].Ins_Form_FormName.value.trim() == "") {
			alert("�Բ��𣬱����Ʋ���Ϊ�գ�");
			return;
		}
		if (document.forms[n].Ins_Form_Caption.value == null || document.forms[n].Ins_Form_Caption.value.trim() == "") {
			alert("�Բ��𣬱����ⲻ��Ϊ�գ�");
			return;
		}
		pageshow(n, nextpage, command, canexecute);
	}
	//��ʼ��������
	function initForm() {
		if (document.forms[0].Ins_Form_FormId.value == null || document.forms[0].Ins_Form_FormId.value.trim() == "") {
			document.getElementById("tdModSel").style.removeAttribute("display");
		}
		else {
			document.FormEditor.setFormName(document.myform.Ins_Form_FormName.value);
			document.FormEditor.setFormTitle(document.myform.Ins_Form_Caption.value);
			document.FormEditor.setFormNum(document.myform.Ins_Form_FormOrder.value);
			document.FormEditor.setFormStr(document.myform.Ins_Form_Html.value);
			document.FormEditor.setFieldStr(document.myform.Ins_Form_FieldList.value);
			document.FormEditor.setLocalAction(document.myform.Ins_Form_LocalAction.value);
			document.FormEditor.savaform();
		}
	}
	//�����Ƶ�ģ�尴ť��Ӧ����
	function template() {
		if (document.FormEditor.isFormAttribute() == true) {
			alert("�Բ��𣬱�����ҳ��ʱ�������ñ�ģ�壡");
			return;
		}
		var data = new Array();
		data["template"] = document.forms[0].Ins_Form_TemplateList.value;
		data["fields"] = document.FormEditor.getFieldStr();
		var result = showModalDialog("controller?nextpage=TemplateList&command=&canexecute=false&aaa=" + Math.random(), data, "dialogWidth:350px; dialogHeight:250px; status:no; center:yes; scroll:no");
		if (result != null) {
			document.forms[0].Ins_Form_TemplateList.value = result;
		}
	}



