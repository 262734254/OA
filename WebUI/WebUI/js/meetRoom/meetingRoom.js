
/*********************
*     DIV提示验证检查      *
*********************/

function checkRequire(objId){
    var obj = document.getElementById(objId.name+"_Msg");
	if(objId.value.length<1){
		 obj.innerHTML = "<font color=red>"+obj.outerText+"</font>";
		 return;
	 }
	else{	   
	  if(true){
	   obj.innerHTML="<font color=#33cc66>"+obj.outerText+"</font>";
	  }
	 }
	 return;
}

function checkRequireById(Id)
{
	var objId = document.getElementById(Id);
	var obj = document.getElementById(Id+"_Msg");
	if(objId.value.length<1){
		 obj.innerHTML = "<font color=red>"+obj.outerText+"</font>";
		 return;
	 }
	else{	
	  if(true){
	   obj.innerHTML="<font color=#33cc66>"+obj.outerText+"</font>";
	  }
	 }
	 return;
}

//删除会议室 
function del(url,confirmString){
	var c = confirmString;
	if(c == null || c == ''){
		c = "你确认要删除吗？";
	}
	if(confirm(c)){
		 document.form_studyTask.action=url;
		 document.form_studyTask.submit();
	}
	else{
		return false;
	}
}


/*********************
*    显示/消失会议室图片层      *
*********************/

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
}