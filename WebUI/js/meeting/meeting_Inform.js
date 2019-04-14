
/*********************
*    显示/消失 通知正文层      *
*********************/

//显示层  并填入数据的类型为 文本框
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


//显示层  并填入数据的类型为 层
function showDiv_getDiv(divId,param)
{
	if(document.getElementById(divId).style.display=="none")
	{
		document.getElementById(divId).style.display="";
		//document.getElementById(divId).style.display="block";

		for(var i=0;i<param.split('|').length-1;i++)
		{
			var value = param.split('|')[i].split('=')[1];
			document.getElementById(param.split('|')[i].split('=')[0]).innerHTML=value;
			//document.getElementById(param.split('|')[0].split('=')[0]).value=value;
		}
		//var value = param.split('|')[0].split('=')[1];
        //document.getElementById(param.split('|')[0].split('=')[0]).value=value;
	}
}


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