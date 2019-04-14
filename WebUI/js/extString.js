/* ------------------------------------------------------------
        file:extString.js
        function:java script中未提供的字符串处理函数
        author:alamo,createTime:11:01 01-8-3
        function list:
                function lpad(countLen,addStr)
                function rpad(countLen,addStr)
                function trim();
                function rtrim()
                function ltrim()
                function getByte()
                function dbcToSbc(dbcStr)
*/

/*
        function:在字符串左边补指定的字符串
        parameter：
                countLen:结果字符串的长度
                addStr:要附加的字符串
        return:处理后的字符串
*/
String.prototype.lpad = function(countLen,addStr)
{
        // 如果countLen不是数字，不处理返回
        if(isNaN(countLen))return this;

        // 初始字符串长度大于指定的长度，则不需处理
        if(initStr.length >= countLen)return this;

        var initStr = this;        // 初始字符串
        var tempStr = new String();        // 临时字符串

        for(;;)
        {
                tempStr += addStr;
                if(tempStr.length >= countLen - initStr.length)
                {
                        tempStr = tempStr.substring(0,countLen - initStr.length);
                        break;
                }
        }
        return tempStr + initStr;
}


/*
        function:在字符串右边补指定的字符串
        parameter：
                countLen:结果字符串的长度
                addStr:要附加的字符串
        return:处理后的字符串
*/
String.prototype.rpad = function(countLen,addStr)
{
        // 如果countLen不是数字，不处理返回
        if(isNaN(countLen))return this;

        // 初始字符串长度大于指定的长度，则不处理返回
        if(initStr.length >= countLen)return this;

        var initStr = this;        // 初始字符串

        for(;;)
        {
                initStr += addStr;
                if(initStr.length >= countLen)
                {
                        initStr = initStr.substring(0,countLen);
                        break;
                }
        }
        return initStr;
}

/*
        function: 删除字符串中的所有空格、回车、换行、制表符和垂直制表符
        return: 处理后的字符串
*/
String.prototype.atrim = function()
{
    // 用正则表达式将前后空格
    // 用空字符串替代。
    return this.replace(/\s/g, "");
}

// 增加一个名为 trim 的函数作为
// String 构造函数的原型对象的一个方法。
String.prototype.trim = function()
{
    // 用正则表达式将前后空格
    // 用空字符串替代。
    return this.replace(/(^\s＝)|(\s＝$)/g, "");
}

/*
        function:去掉字符串左边的空格
        return:处理后的字符串
*/
String.prototype.ltrim = function()
{
        return this.replace(/ +/,"");
}


/*
        function:去掉字符串左边的空格
        return:处理后的字符串
*/
String.prototype.rtrim = function()
{
        return this.replace(/ +$/,"");
}


/*
        function:获得字符串的字节数
        return:字节数
        example:"test测试".getByte值为8
*/
String.prototype.getByte = function()
{
        var intCount = 0;
        for(var i = 0;i < this.length;i ++)
        {
                // Ascii码大于255是双字节的字符
                if(this.charCodeAt(i) > 255)intCount += 2;
                else intCount += 1;
        }
        return intCount;
}

/*
        function: 指定字符集半角字符全部转变为对应的全角字符
        parameter:
                dbcStr: 要转换的半角字符集合
        return: 转换后的字符串
*/
String.prototype.dbcToSbc = function(dbcStr)
{
        var resultStr = this;

        for(var i = 0;i < this.length;i ++)
        {
                switch(dbcStr.charAt(i))
                {
                        case ",":
                                resultStr = resultStr.replace(/\,/g,"，"); 
                                break;
                        case "!":
                                resultStr = resultStr.replace(/\!/g,"！"); 
                                break;
                        case "#":
                                resultStr = resultStr.replace(/\#/g,"＃"); 
                                break;
                        case "|":
                                resultStr = resultStr.replace(/\|/g,"|"); 
                                break;
                        case ".":
                                resultStr = resultStr.replace(/\./g,"。"); 
                                break;
                        case "?":
                                resultStr = resultStr.replace(/\?/g,"？"); 
                                break;
                        case ";":
                                resultStr = resultStr.replace(/\;/g,"；"); 
                                break;
                }
        }
        return resultStr;
}

String.prototype.bytesubstr = function(index1,index2)
{
        var resultStr = "";
        var byteCount = 0;
        for(var i = index1;i < index2;i ++)
        {
                if(i > this.length)break;
                if(this.charCodeAt(i) > 255)byteCount += 2;
                else byteCount += 1;
                if(byteCount > (index2 - index1))break;
                resultStr += this.charAt(i);
        }
        return resultStr;
}

