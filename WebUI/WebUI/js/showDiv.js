function showDivInstro(divname) {
	var dname = document.getElementById(divname).style.display;
	if (dname == "none") {
		document.getElementById(divname).style.display = "block";
	} else {
		document.getElementById(divname).style.display = "none";
	}
}

function EditInfo(div1, div2) {
	for (i = 1; i <= 10; i++) {
		var dname1 = document.getElementById(div1 + i).style.display;
		var dname2 = document.getElementById(div2 + i).style.display;
		if (dname1 == "none") {
			document.getElementById(div1 + i).style.display = "block";
			document.getElementById(div2 + i).style.display = "none";
		} else {

			document.getElementById(div1 + i).style.display = "none";
			document.getElementById(div2 + i).style.display = "block";
		}
	}
}

function getType(div1, div2, div3) {
	var num1 = document.getElementById(div1).style.display;
	var num2 = document.getElementById(div2).style.display;
	var num3 = document.getElementById(div3).style.display;
	if (num1 == "none") {
		document.getElementById(div1).style.display = "block";
		document.getElementById(div2).style.display = "none";
		document.getElementById(div3).style.display = "none";
	} else {
		document.getElementById(div1).style.display = "block";
		document.getElementById(div2).style.display = "none";
		document.getElementById(div3).style.display = "none";
	}

}

function showDivInstro1(divname, uid, uname, usex, upublish, upublishName,
		utime, nowPublishId) {
	var dname = document.getElementById(divname).style.display;
	var hidName = document.getElementById("hidSessionName").value;

	if (hidName == uname) {
		alert("�Լ��޷������Լ���");
		return false;
	} else {

		document.getElementById('updateUserId').value = uid;
		document.getElementById('userUpdateName').value = uname;
		document.getElementById("nowPublishId").value = nowPublishId;
		if (usex == 1) {
			document.getElementById('userUpdateSex').value = 'Ů';
		} else {
			document.getElementById('userUpdateSex').value = '��';
		}
		document.getElementById('userUpdatePublish').value = upublish;
		document.getElementById('userUpdatePublishName').value = upublishName;
		document.getElementById('userUpdateTime').value = utime;
		if (dname == "none") {
			document.getElementById(divname).style.display = "block";
		} else {
			document.getElementById(divname).style.display = "none";
		}
	}
}

function showDivInstro2(divname, userId, userName, userEmail, userSex, userTel,
		userBirthday, userAddress, userEduction, userSpecialty, userIdCard,
		publishName) {
	var dname = document.getElementById(divname).style.display;
	var div = 'ed_s_';
	var div1 = 'ed_t_';
	for (i = 1; i <= 10; i++) {
		document.getElementById(div + i).style.display = "block";
		document.getElementById(div1 + i).style.display = "none";
	}

	document.getElementById('userUpdateHidId').value = userId;// �����޸��û���ID

	// �����޸��û�������
	document.getElementById('userDisplayName').value = userName;
	document.getElementById('userUpdateName').value = userName;

	// �����޸��û�������
	document.getElementById('userDisplayEmail').value = userEmail;
	document.getElementById('email').value = userEmail;

	// �����޸��û����Ա�
	if (userSex == 1) {
		document.getElementById('userDisplaySex').value = 'Ů';
	} else {
		document.getElementById('userDisplaySex').value = '��';
	}

	// �����޸��û��ĵ绰
	document.getElementById('userDisplayPhone').value = userTel;
	document.getElementById('phone').value = userTel;

	// �����޸��û�������
	document.getElementById('userDisplayBirthday').value = userBirthday;
	document.getElementById('userBirthday').value = userBirthday;

	// �����޸��û��ĵ�ַ
	document.getElementById('userDisplayAddress').value = userAddress;
	document.getElementById('userAddress').value = userAddress;

	// �����޸��û���ѧ��
	document.getElementById('userDisplaySchoolAge').value = userEduction;
	document.getElementById('schoolAge').value = userEduction;

	// �����޸��û���רҵ
	document.getElementById('userDisplaySpecialty').value = userSpecialty;
	document.getElementById('specialty').value = userSpecialty;

	// �����޸��û������֤
	document.getElementById('userDisplayIdCard').value = userIdCard;
	document.getElementById('userIdCard').value = userIdCard;

	// �����޸��û������֤
	document.getElementById('userDisplayPublish').value = publishName;

	if (dname == "none") {
		document.getElementById(divname).style.display = "block";
	} else {
		document.getElementById(divname).style.display = "none";
	}
}