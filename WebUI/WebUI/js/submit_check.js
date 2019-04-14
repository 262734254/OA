function attemper_check() {
	var publish_now = document.attForm.userUpdatePublishName;
	var publish_att = document.attForm.updatePublishName;
	var userName = document.attForm.userUpdateName.value;
	var hidName = document.attForm.hidSessionName.value;
	if(publish_att.value == "-点击选择部门-") {
		alert("您还未选择要申请调入的部门!");
		return false;
	}
	if(publish_now.value == publish_att.value) {
		alert(userName+"已经是"+publish_now.value+"的人员,无法调入同一部门");
		return false;
	}
	if(hidName==userName) {
		alert("自己无法调度自己！");
		return false;
	}
	return true;
}

function update_check() {
	var userName = document.edForm.userUpdateName;
	var email = document.edForm.email;
	var phone = document.edForm.phone;
	var userBirthday = document.edForm.userBirthday;
	var userAddress = document.edForm.userAddress;
	var schoolAge = document.edForm.schoolAge;
	var specialty = document.edForm.specialty;
	var userIdCard = document.edForm.userIdCard;
	
	if(userName.value == "") {
		alert("您还未输入人员名称!");
		userName.focus();
		return false;
	}
	if(email.value == "") {
		alert("您还未输入邮箱!");
		email.focus();
		return false;
	}
	if(phone.value == "") {
		alert("您还未输入联系电话!");
		phone.focus();
		return false;
	}
	if(userBirthday.value == "") {
		alert("您还未选择出生日期!");		
		return false;
	}
	if(userAddress.value == "") {
		alert("您还未输入地址信息!");
		userAddress.focus();
		return false;
	}
	if(schoolAge.value == "") {
		alert("您还未输入学历信息!");
		schoolAge.focus();
		return false;
	}
	if(specialty.value == "") {
		alert("您还未输入所学的专业信息!");
		specialty.focus();
		return false;
	}
	if(userIdCard.value == "") {
		alert("您还未输入身份证号!");
		userIdCard.focus();
		return false;
	}
}