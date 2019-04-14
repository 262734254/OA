function checkTime() {
	var applyTime = document.getElementById("appTime");
	var passTime = document.getElementById("passTime");
	if (applyTime.value != "" && passTime.value == "") {
		alert("请选择一个时间范围以方便查询！");
		return false;
	}
	if (applyTime.value == "" && passTime.value != "") {
		alert("请选择一个时间范围以方便查询！");
		return false;
	}
	if (passTime.value < applyTime.value) {
		alert("审批时间无法大于申请时间！");
		return false;
	}
	return true;
}

function search() {
	if (checkTime()) {
		var publishName = document.hFrom.publishName.value;
		var usersName = document.hFrom.usersName.value;
		var appTime = document.hFrom.appTime.value;
		var passTime = document.hFrom.passTime.value;
		var states = document.hFrom.pass.value;
		var idType = document.getElementById("idType").value;

		if (document.hFrom.page != null)
			document.hFrom.page.value = 1;
		document.hFrom.hidType.value = 'generalSearch';
		document.hFrom.hidPublishName.value = publishName;
		document.hFrom.hidUsersName.value = usersName;
		document.hFrom.hidAppTime.value = appTime;
		document.hFrom.hidPassTime.value = passTime;
		document.hFrom.hidStates.value = states;
		document.hFrom.hidIdType.value = idType;
		document.hFrom.action = "/KBS/userRapplyRelation!generalSearch.action?type=generalSearch";
		document.hFrom.submit();
	}
}