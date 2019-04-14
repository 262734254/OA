


function banSelect(){
	window.event.returnValue=false;
}
document.onselectstart=banSelect;



function Click(){ 
window.event.returnValue=false;
} 
document.oncontextmenu=Click; 


function doc_keyDown() 
{ 
return(!(event.keyCode==78 && event.ctrlKey)); 
} 
document.onkeydown=doc_keyDown;


function onKeyDown()
{
	if ((event.keyCode==116)||(window.event.ctrlKey)||(window.event.shiftKey))
	{
	event.keyCode=0;
	event.returnValue=false;
	}
}
