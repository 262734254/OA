function attemper_check() {
	var publish_now = document.attForm.userUpdatePublishName;
	var publish_att = document.attForm.updatePublishName;
	var userName = document.attForm.userUpdateName.value;
	var hidName = document.attForm.hidSessionName.value;
	if(publish_att.value == "-���ѡ����-") {
		alert("����δѡ��Ҫ�������Ĳ���!");
		return false;
	}
	if(publish_now.value == publish_att.value) {
		alert(userName+"�Ѿ���"+publish_now.value+"����Ա,�޷�����ͬһ����");
		return false;
	}
	if(hidName==userName) {
		alert("�Լ��޷������Լ���");
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
		alert("����δ������Ա����!");
		userName.focus();
		return false;
	}
	if(email.value == "") {
		alert("����δ��������!");
		email.focus();
		return false;
	}
	if(phone.value == "") {
		alert("����δ������ϵ�绰!");
		phone.focus();
		return false;
	}
	if(userBirthday.value == "") {
		alert("����δѡ���������!");		
		return false;
	}
	if(userAddress.value == "") {
		alert("����δ�����ַ��Ϣ!");
		userAddress.focus();
		return false;
	}
	if(schoolAge.value == "") {
		alert("����δ����ѧ����Ϣ!");
		schoolAge.focus();
		return false;
	}
	if(specialty.value == "") {
		alert("����δ������ѧ��רҵ��Ϣ!");
		specialty.focus();
		return false;
	}
	if(userIdCard.value == "") {
		alert("����δ�������֤��!");
		userIdCard.focus();
		return false;
	}
}