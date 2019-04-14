String.prototype.trim = function() {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

function checkWord(len, evt, sid) {
    if (evt == null)
        evt = window.event;

    var src = evt.srcElement ? evt.srcElement : evt.target;
    var str = src.value.trim();
    myLen = 0;
    i = 0;
    for (; (i < str.length) && (myLen <= len); i++) {
        if (str.charCodeAt(i) > 0 && str.charCodeAt(i) < 128)
            myLen++;
        else
            myLen += 2;
    }
    if (myLen <= len) {
        document.getElementById(sid).innerText =  myLen + "/" + len;
    }
    else {
        document.getElementById(sid).innerText =  myLen-1 + "/" + len;
        src.value = str.substring(0, i - 1);
    }

}