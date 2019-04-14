//控制提交命令，n 当前页面被提交的form名称；nextpage 提交页面名称；
//command 提交执行命令；anexecute 提交是否执行命令
var chknum=0;//用户选择的记录数
var check="";//用户选择的记录主键值


//＝＝＝＝＝＝＝(系统操作)**开始**＝＝＝＝＝＝＝

//页面加载时屏蔽右键菜单
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
//延时函数，参数为延时毫秒数。
function sleep(milliSeconds){
	showModalDialog("../gwp/controller?nextpage=sleep&command=&canexecute=false", milliSeconds, "dialogWidth:15; dialogHeight:1; status:no; center:yes; dialogHide:yes");
}
//取消返回
function cancel_back(){
	window.history.go(-1);
}
//关闭
function cancel_close(){
	window.close();
} 
//退出系统
function quit(){
	top.close();
}
//＝＝＝＝＝＝＝(系统操作)**结束**＝＝＝＝＝＝＝

//＝＝＝＝＝＝＝(保存、修改、删除按钮操作)**开始**＝＝＝＝＝＝＝
//调用Cmd,显示页面
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
//判断checkvalue对象是否有值
function ischecked(){
	var els = document.getElementsByName("check");
	for (var i = 0; i < els.length; i++){
		var el = els.item(i);
		if (el.checked){
			return true;
		}
	}
	alert("请选中要操作的记录！");
	return false;
}
//执行按钮操作前检查是否选中操作记录。
function checkcmd(n,nextpage,command,canexecute){
	if(ischecked()){
		if(confirm("删除后不可恢复，确认吗？")){
			pageshow(n,nextpage,command,canexecute);
		}else false;
	}else false;
}
function checkUserDepartcmd(n,nextpage,command,canexecute){
	if(ischecked()){
		if(confirm("删除后不可恢复，确认吗？")){
			pageshow(n,nextpage,command,canexecute);
		}else false;
	}else false;
}
//更新
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
//刷新
function appRefresh(n,nextpage,command,canexecute){
	pageshow(n,nextpage,command,canexecute);
	parent.frames("top").location = parent.frames("top").location
	parent.frames("left").location = parent.frames("left").location
}
//删除
function InfoDelete(n,nextpage,command,canexecute){
	checkcmd(n,nextpage,command,canexecute);
}
//选中记录
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
		alert("请选中要操作的记录！");
		return false;
	}
	else if(j>1){
		alert("请只选择一条记录！");
		j==0;
		return false;
	}
	else if(j==1){
		return true;
	}
}
//判断部门用户，并重新组合成新的字符串传给Command
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
		alert("您不能在此处删除部门");
	}else{
		checkcmd(0,'UserDepartList','delUser','true');
	}
} 
//删除部门
function delDepart(n,nextpage,command,canexecute){
	if(confirm("删除后不可恢复，确认吗？")){
			pageshow(n,nextpage,command,canexecute);
	}else{
		return false;
	}
}
//判断部门用户，选择修改页面
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
//＝＝＝＝＝＝＝LDAP服务器操作功能 开始＝＝＝＝＝＝＝

//删除LDAP部门
function LDAPdelDepart(n,nextpage,command,canexecute){
	if(confirm("删除后不可恢复，确认吗？")){
			pageshow(n,nextpage,command,canexecute);
	}else{
		return false;
	}
}

//判断LDAP部门用户，并重新组合成新的字符串传给Command
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
		alert("您不能在此处删除部门");
	}else{
		checkcmd(0,'LdapList','DeleteLDAPUserCmd','true');
	}
} 

//判断LDAP部门用户，选择修改页面
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

//LDAP用户校验
function LDAPuserDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "uid").value.trim() == ""){
		alert("用户登录名不可为空！");
		document.all(type + "uid").focus();
	}else if(document.all(type + "userPassword").value.trim() == ""){
		alert("登录密码不可为空！");
		document.all(type + "userPassword").focus();
	}else if(document.all(type + "cn").value.trim() == ""){
		alert("用户姓不可为空！");
		document.all(type + "cn").focus();
	}else if(document.all(type + "sn").value.trim() == ""){
		alert("用户名不可为空！");
		document.all(type + "sn").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//LDAP部门校验
function LDAPdeptDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "ou").value.trim() == ""){
		alert("部门名称不可为空！");
		document.all(type + "ou").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//用户组校验
function LDAPgroupDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "cn").value.trim() == ""){
		alert("用户组名称不可为空！");
		document.all(type + "cn").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}

//＝＝＝＝＝＝＝LDAP服务器操作功能  结束＝＝＝＝＝＝＝



//主键值选择
function checkselect(chk)
{
	if (chk.checked){
    	document.forms[0].checkvalue.value=chk.value;
    	chknum++;
    	//主键值累加
    	check=check+"|"+chk.value;  
    	//alert(chknum+"/"+check);  
 	}else{
  		chknum--;
  		//从主键值中删除取消选择的主键。
  		if(check!=""){
       		var delstr="|"+chk.value;
       		check=check.substring(0,check.indexOf(delstr))+check.substring(check.indexOf(delstr)+delstr.length,check.length+1);       	
        } 
		if(document.forms[0].checkvalue.value==chk.value){
			//重置单选值
			document.forms[0].checkvalue.value=check.substring(check.lastIndexOf("|")+1,check.length+1);                 
		}    
	}
}
//执行按钮操作前检查是否选中操作记录。
function checkupdate(n,nextpage,command,canexecute){
	if(document.forms[0].checkvalue.value == null || document.forms[0].checkvalue.value == ""){
		alert("请选择要操作的记录！");
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//示例保存
function samplesave(n,nextpage,command,canexecute){
	if (document.forms[n].Ins_Sample_Name.value == null || document.forms[n].Ins_Sample_Name.value.trim() == ""){
		alert("对不起，名称不能为空！");
		return;
	}
	if (document.forms[n].Ins_Sample_Email.value == null || document.forms[n].Ins_Sample_Email.value.trim() == ""){
		alert("对不起，电子邮件不能为空！");
		return;
	}
	pageshow(n,nextpage,command,canexecute);
}
//公文交换域对应关系保存
function FieldXmlSave(n,nextpage,command,canexecute){
	if (document.forms[n].ModName.value == null || document.forms[n].ModName.value.trim() == ""){
		alert("对不起，模块名称不能为空！");
		return;
	}
	if (document.forms[n].FieldName.value == null || document.forms[n].FieldName.value.trim() == ""){
		alert("对不起，域名不能为空！");
		return;
	}
	if (document.forms[n].XmlTag.value == null || document.forms[n].XmlTag.value.trim() == ""){
		alert("对不起，XML标签不能为空！");
		return;
	}	
	pageshow(n,nextpage,command,canexecute);
}
//下级功能树显示
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
//选择应用树保存
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
//＝＝＝＝＝＝＝(保存、修改、删除按钮操作)**结束**＝＝＝＝＝＝＝

//＝＝＝＝＝＝＝(弹出对话框，并返回以","分割的字符串)**开始**＝＝＝＝＝＝＝
//弹出对话框
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
//角色赋值应用树
function setPurview(n,nextpage,command,canexecute,type){

    if(document.forms[n].checkvalue.value==null||document.forms[n].checkvalue.value==""){
    	alert("请您选择一条记录!");
    	return;
    }
    if(check.lastIndexOf("|")>0){
    	alert("对不起，请您选择一条记录!");
    	return;
    }
    var val=document.forms[n].checkvalue.value;
	var url="../gwp/controller?nextpage="+nextpage+"&command="+command+"&canexecute="+canexecute+"&checkvalue="+val+"&type="+type;
	window.open(url,"应用选择","width=400,height=500,vscrollbars=yes");
	
}
//确定按钮　返回所有的选择结果组成的以“，”分割的字符串
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

//角色分配给用户、部门、组
function assignRole(n,nextpage,command,canexecute,field,select,selecttype,type,parentid,asstype){
	if(document.forms[n].checkvalue.value==null||document.forms[n].checkvalue.value==""){
    	alert("请您选择一条记录!");
    	return;
    }
    if(check.lastIndexOf("|")>0){
    	alert("对不起，请您选择一条记录!");
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
//收回部门、用户、小组的角色
function getRole(n,nextpage,command,canexecute){
	if(document.forms[n].checkvalue.value==null||document.forms[n].checkvalue.value==""){
    	alert("请您选择一条记录!");
    	return;
    }
    if(check.lastIndexOf("|")>0){
    	alert("对不起，请您选择一条记录!");
    	return;
    }
    pageshow(n,nextpage,command,canexecute);
}
//用户、组、部门选择角色
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
//用户组添加用户
function addUserDialog(){
	if(ShowDialog('user','../gwp/controller?command=UserTreeCmd&nextpage=TreeSelect&type=0&selectType=1&canexecute=true&dept_id=10000')){
		pageshow(0,'UserList','AddGroupUser','true');
	}
} 
//＝＝＝＝＝＝＝(弹出对话框，并返回以,分割的字符串)**结束**＝＝＝＝＝＝＝

//＝＝＝＝＝＝＝(分页显示)**开始**＝＝＝＝＝＝＝
//上一页
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
//下一页
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
//至第几页
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
//＝＝＝＝＝＝＝(分页显示)**结束**＝＝＝＝＝＝＝

//＝＝＝＝＝＝＝(数据校验)**开始**＝＝＝＝＝＝＝
//应用数据校验
function appDataCheck(n,nextpage,command,canexecute){
	if(document.all("Ins_AppName").value.trim() == ""){
		alert("应用名称不可为空！");
		document.all("Ins_AppName").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//字典数据校验
function dictDataCheck(n,nextpage,command,canexecute){
	if(document.all("Ins_Name").value.trim() == ""){
		alert("名称不可为空！");
		document.all("Ins_Name").focus();
	}else if(document.all("Ins_Value").value.trim() == ""){
		alert("编码不可为空！");
		document.all("Ins_Value").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//日志查询校验
function logDataCheck(n,nextpage,command,canexecute){
	if(document.all.item("Ins_StartDate").value.trim() == "" && document.all.item("Ins_EndDate").value.trim() == ""){
		alert("起始时间或终止时间不可为空！请您重新填写！");
		//document.all("Ins_StartDate").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//角色校验
function roleDataCheck(n,nextpage,command,canexecute){
	if(document.all("Ins_RoleName").value.trim() == ""){
		alert("角色名称不可为空！");
		document.all("Ins_RoleName").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}

//用户组校验
function groupDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "GroupName").value.trim() == ""){
		alert("用户组名称不可为空！");
		document.all(type + "GroupName").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}
//部门校验
function deptDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "Dept_Name").value.trim() == ""){
		alert("部门名称不可为空！");
		document.all(type + "Dept_Name").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}


//用户校验
function userDataCheck(n,nextpage,command,canexecute,type){
	if(document.all(type + "Login_Name").value.trim() == ""){
		alert("用户登录名不可为空！");
		document.all(type + "Login_Name").focus();
	}else if(document.all(type + "PassWord").value.trim() == ""){
		alert("登录密码不可为空！");
		document.all(type + "PassWord").focus();
	}else if(document.all(type + "FamilyName").value.trim() == ""){
		alert("用户姓不可为空！");
		document.all(type + "FamilyName").focus();
	}else if(document.all(type + "Name").vauserPassword() == ""){
		alert("用户名不可为空！");
		document.all(type + "Name").focus();
	}else{
		pageshow(n,nextpage,command,canexecute);
	}
}

//登陆名校验
function isRegister(sName){  
	var register=document.all(sName).value.trim();  
	var inchars = "_.1234567890abcdefghigklmnopqrstuvwxyzABCDEPGHIGKLMNOPQRSTUVWXYZ";  
	for (i=0;i< register.length;i++){  
		regChar=register.charAt(i)  
		if (inchars.indexOf(regChar, 0) == -1){ 
			alert("登录名和密码必须为数字、26字母、下划线与小数点！");
			document.all(sName).focus(); 
			return false;  
		}  
	}  
}
//数字校验
function isNum(sName){
	var numNo=document.all(sName).value.trim();  
	var inChars = "1234567890";  
	for (i=0;i<numNo.length;i++){  
		numNoChar=numNo.charAt(i)  
		if (inChars.indexOf(numNoChar, 0) == -1){
			alert("请您输入整数！");
			document.all(sName).focus(); 
			return false;  
		}
	}
	return true;
}
//EMail校验
function isEmail(sName){
	if (document.all(sName).value.trim()!=""){
		var email=(document.all(sName).value.trim());
		inChars = "/;,:{}[]|*%$#!()`<>?";
		for (i=0; i< inChars.length; i++){
			badChar = inChars.charAt(i)
			if (email.indexOf(badChar,0) > -1){
				alert("您的Email输入不正确！");
				document.all(sName).value.focus();
				return false;  
			} 
		}
		atEmail = email.indexOf("@",1)
		dotEmail = email.indexOf(".",atEmail)  
		if (atEmail == -1 || email.indexOf("@", atEmail+1) != -1 || dotEmail == -1 || atEmail +2 > dotEmail || dotEmail +3 > email.length){  
			alert("您的Email输入不正确！");
			document.all(sName).focus();
			return false;  
	    }
    }  
}
//电话号码校验  
function isTel(sName){  
	var tel=document.all(sName).value.trim();  
	var inChars = "-()1234567890,";  
	for (i=0;i<tel.length;i++){  
		telchar=tel.charAt(i)  
		if (inChars.indexOf(telchar, 0) == -1){ 
			alert("电话号码只能输入'-()1234567890,'！");
			document.all(sName).focus(); 
			return false;  
		}  
	}  
}
//＝＝＝＝＝＝＝(数据校验)**结束**＝＝＝＝＝＝＝

//流程定制和表单定制系统的函数
	//选择模块函数
	function selModal(idField, nameField) {
		var rtnValue = window.showModalDialog("controller?nextpage=ModalSelect&command=ModalManagerCmd&canexecute=true&aaa=" + Math.random(), "", "dialogWidth:300px;dialogHeight:400px;center:1;status:0;scroll:1");
		if (rtnValue != null && rtnValue.trim() != "") {
			var values = rtnValue.split("щ");
			document.getElementsByName(idField)[0].value = values[0];
			document.getElementsByName(nameField)[0].value = values[1];
		}
	}
	//获取浏览器当前URI，如：http://www.langchao.com.cn
	function getUri() {
		var protocol = window.location.protocol;
		var host = window.location.host;
		host = protocol+"//"+host;
		return host;	
	}
	
	//获取Word对象，若获取失败则弹出提示并返回null
	function getWord() {
		try{
			return new ActiveXObject("Word.Application");    //启动word
		}
		catch (e) {
			alert("对不起，初始化Word对象失败！\n请确认您是否安装了Microsoft Word 97或更高版本；\n并且将本站点添加到可信站点列表。");
			return null;
		}
	}
	
	//获取Excel对象，若获取失败则弹出提示并返回null
	function getExcel() {
		try{
			return new ActiveXObject("Excel.Application");    //启动word
		}
		catch (e) {
			alert("对不起，初始化Excel对象失败！\n请确认您是否安装了Microsoft Excel 97或更高版本；\n并且将本站点添加到可信站点列表。");
			return null;
		}
	}
	
	//对指定文件进行Base64编码，并返回编码后的字符串
	function encoding(filename){
		try {
			newMothod1.filename = filename;
			newMothod1.encode();                 //将需要编辑的文件编码
			var encodeString = newMothod1.encodeString;
			return encodeString;
		}
		catch (e) {
			alert("对不起，处理文件时错误！\n请确认文件是否保存并关闭！");
			return null;
		}
	}

	//对传入的经过Base64编码的字符串进行解码，并返回解码后的文件全名
	function decoding(encodeString){
		newMothod1.decodeValue(encodeString);//将编码后文件进行解码
		var decodefile = newMothod1.decodefile;
		return decodefile;
	}
	//初始化模板编辑对话框
	function initTemplateEditor() {
		var success;
		if (data["mimetype"].toLowerCase() == "application/msword") {
			success = editTemplateWord();
		}
		else if(data["mimetype"].toLowerCase() == "application/vnd.ms-excel") {
			success = editTemplateExcel();
		}
		else {
			alert("对不起，模板类型不正确！");
			success = false;
		}
		if (success == false) {
			window.close();
		}
	}
	//编辑Word模板
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
		if (data["templateName"] == "print.doc" && confirm("是否在打印模板中添加新的表单数据？")) {
			var xml = new ActiveXObject("Microsoft.XMLDOM");
			xml.async=false;
			xml.loadXML("<all>" + field + "</all>");
			var root = xml.documentElement;
			for (var i = 0; i < root.childNodes.length; i++) {
				if (root.childNodes.item(i).nodeType == 1) {
					app.Selection.TypeText("щ" + root.childNodes.item(i).attributes.getNamedItem("displayname").nodeValue + "щ");
					app.Selection.TypeParagraph();
				}
			}
		}
		app.visible = true;
		return true;	
	}
	//编辑Excel模板
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
	//模板编辑完成
	function editTemplateComplete() {
		if (document.forms[0].templateName.value == null || document.forms[0].templateName.value.trim() == "") {
			alert("对不起，模板名称不能为空！");
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
	
	//删除选定的模板
	function deleteTemplate() {
		if (!confirm("您确定要删除指定的模板吗？")) {
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
	
	//模板完成
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
	//新建正文模板
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
	//修改选定的模板
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
	//保存表单
	function saveForm(n, nextpage, command, canexecute, complete) {
		if (document.FormEditor.isFormAttribute() == true) {
			alert("对不起，表单属性页打开时不能保存表单！");
			return;
		}
		if (document.forms[n].Ins_Form_Moid.value == null || document.forms[n].Ins_Form_Moid.value.trim() == "") {
			alert("对不起，您还没有选择表单所属模块！");
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
			alert("对不起，表单名称不能为空！");
			return;
		}
		if (document.forms[n].Ins_Form_Caption.value == null || document.forms[n].Ins_Form_Caption.value.trim() == "") {
			alert("对不起，表单标题不能为空！");
			return;
		}
		pageshow(n, nextpage, command, canexecute);
	}
	//初始化表单数据
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
	//表单定制的模板按钮响应函数
	function template() {
		if (document.FormEditor.isFormAttribute() == true) {
			alert("对不起，表单属性页打开时不能设置表单模板！");
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



