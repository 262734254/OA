function GetXmlHttpObject() {
    //创建XMLHttpRequest对象来发送和接收HTTP请求与响应
    xmlHttpObj = null;
    try {
        // FireFox Opera 8.0+ Safari
        xmlHttpObj = new XMLHttpRequest();
        if (xmlHttpObj.overrideMimeType) {
            xmlHttpObj.overrideMimeType('text/xml');
        }
    }
    catch (e) {
        // IE
        try {
            xmlHttpObj = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e) {
            xmlHttpObj = new ActiveXObject("Microsoft.XMLHTTP");
        }
    }
    return xmlHttpObj;
}

function StateChanged() {
    if (xmlHttp.readyState == 4) {
        if (xmlHttp.status == 200) {
        }
        else {
        }
    }
}

var xmlHttp = null;
function ClearSession() {
    if (xmlHttp == null)
        xmlHttp = GetXmlHttpObject();
    if (xmlHttp == null)
        return false;
    var url = "../CleanSession.aspx?command=ClearSession";
    xmlHttp.open("GET", url, true);
    xmlHttp.onreadystatechange = StateChanged;
    xmlHttp.send(null);

}


window.onbeforeunload = function() {

    var n = window.event.screenX - window.screenLeft;

    var b = n > document.documentElement.scrollWidth - 20;


    if (b && window.event.clientY < 0 || window.event.altKey) {

        //alert("是关闭而非刷新");

        ClearSession();


        //return false;   

        //window.event.returnValue = ""; }    

    } else {

        //alert("是刷新而非关闭");

    }

}  