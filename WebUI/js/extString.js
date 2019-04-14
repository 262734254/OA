/* ------------------------------------------------------------
        file:extString.js
        function:java script��δ�ṩ���ַ���������
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
        function:���ַ�����߲�ָ�����ַ���
        parameter��
                countLen:����ַ����ĳ���
                addStr:Ҫ���ӵ��ַ���
        return:�������ַ���
*/
String.prototype.lpad = function(countLen,addStr)
{
        // ���countLen�������֣���������
        if(isNaN(countLen))return this;

        // ��ʼ�ַ������ȴ���ָ���ĳ��ȣ����账��
        if(initStr.length >= countLen)return this;

        var initStr = this;        // ��ʼ�ַ���
        var tempStr = new String();        // ��ʱ�ַ���

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
        function:���ַ����ұ߲�ָ�����ַ���
        parameter��
                countLen:����ַ����ĳ���
                addStr:Ҫ���ӵ��ַ���
        return:�������ַ���
*/
String.prototype.rpad = function(countLen,addStr)
{
        // ���countLen�������֣���������
        if(isNaN(countLen))return this;

        // ��ʼ�ַ������ȴ���ָ���ĳ��ȣ��򲻴�����
        if(initStr.length >= countLen)return this;

        var initStr = this;        // ��ʼ�ַ���

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
        function: ɾ���ַ����е����пո񡢻س������С��Ʊ���ʹ�ֱ�Ʊ��
        return: �������ַ���
*/
String.prototype.atrim = function()
{
    // ��������ʽ��ǰ��ո�
    // �ÿ��ַ��������
    return this.replace(/\s/g, "");
}

// ����һ����Ϊ trim �ĺ�����Ϊ
// String ���캯����ԭ�Ͷ����һ��������
String.prototype.trim = function()
{
    // ��������ʽ��ǰ��ո�
    // �ÿ��ַ��������
    return this.replace(/(^\s��)|(\s��$)/g, "");
}

/*
        function:ȥ���ַ�����ߵĿո�
        return:�������ַ���
*/
String.prototype.ltrim = function()
{
        return this.replace(/ +/,"");
}


/*
        function:ȥ���ַ�����ߵĿո�
        return:�������ַ���
*/
String.prototype.rtrim = function()
{
        return this.replace(/ +$/,"");
}


/*
        function:����ַ������ֽ���
        return:�ֽ���
        example:"test����".getByteֵΪ8
*/
String.prototype.getByte = function()
{
        var intCount = 0;
        for(var i = 0;i < this.length;i ++)
        {
                // Ascii�����255��˫�ֽڵ��ַ�
                if(this.charCodeAt(i) > 255)intCount += 2;
                else intCount += 1;
        }
        return intCount;
}

/*
        function: ָ���ַ�������ַ�ȫ��ת��Ϊ��Ӧ��ȫ���ַ�
        parameter:
                dbcStr: Ҫת���İ���ַ�����
        return: ת������ַ���
*/
String.prototype.dbcToSbc = function(dbcStr)
{
        var resultStr = this;

        for(var i = 0;i < this.length;i ++)
        {
                switch(dbcStr.charAt(i))
                {
                        case ",":
                                resultStr = resultStr.replace(/\,/g,"��"); 
                                break;
                        case "!":
                                resultStr = resultStr.replace(/\!/g,"��"); 
                                break;
                        case "#":
                                resultStr = resultStr.replace(/\#/g,"��"); 
                                break;
                        case "|":
                                resultStr = resultStr.replace(/\|/g,"|"); 
                                break;
                        case ".":
                                resultStr = resultStr.replace(/\./g,"��"); 
                                break;
                        case "?":
                                resultStr = resultStr.replace(/\?/g,"��"); 
                                break;
                        case ";":
                                resultStr = resultStr.replace(/\;/g,"��"); 
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

