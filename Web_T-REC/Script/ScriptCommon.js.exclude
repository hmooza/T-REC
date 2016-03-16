/* For Non-IE browser */
if (navigator.appName != "Microsoft Internet Explorer" && document.addEventListener) {
    try {
        document.removeEventListener('mousedown', GetEventXY, false);
    } catch (e) { }
    document.addEventListener('mousedown', GetEventXY, false);
}

function GetEventXY(ev) {
    if (ev.target && ev.screenX && ev.screenY) {
        evX = ev.screenX;
        evY = ev.screenY;
    } else {
        evX = 0;
        evY = 0;
    }
}
/* End For */

function SelectDate(txtDate, isSubmit) {

    var idate;
    var hURL = '../WebForm/';
    if (txtDate.value == '')
        idate = '';
    else
        idate = txtDate.value;

    var left, top, screenY, screenY;
    if (navigator.appName == "Microsoft Internet Explorer") {
        screenY = document.body.offsetHeight;
        screenX = window.screen.availWidth;
        if (window.event != null) {
            left = window.event.screenX + 10;
            top = window.event.screenY + 10;
        } else {
            left = screenX / 2;
            top = screenY / 2;
        }
    } else {
        screenY = window.outerHeight;
        screenX = window.outerWidth;
        left = evX + 10;
        top = evY + 10;
    }
    var width = 200;
    var height = 170;
    if (left + width > screenX) left = (screenX - width - 10);
    if (top + height > screenY) top = (screenY - height - 25);
    //alert('dialogWidth:' + width + ',dialogHeight:' + height + ',dialogLeft:' + left + ',dialogTop:' + top + ',resizable:0,status:0,help:0,scrollbars:no');
    //winA = window.showModalDialog(hURL+'SelDate.aspx?textbox=' + txtDate.id + '&setDate=' +idate  ,'dialogWidth:' + width + ',dialogHeight:' + height + ',dialogLeft:' + left + ',dialogTop:' + top + ',resizable:0');
    winA = window.open(hURL + 'SelDate.aspx?textbox=' + txtDate.id + '&setDate=' + idate + '&issubmit=' + isSubmit, 'wndCalendar', 'width=' + width + ',height=' + height + ',left=' + left + ',top=' + top + ',toolbar=no,location=no,menubar=no,status=no,help=no,resizable=no,scrollbars=no'); //,scrollbars:no
    if (winA != null) {
        //winA.focus();
        if (window.attachEvent) {
            window.attachEvent('onbeforeunload', SelDateEx);
        } else if (window.addEventListener) {
            window.addEventListener('unload', SelDateEx, false);
        }
    }
    //txtDate.focus();
}

function SelDateEx() {
    if (winA != null) try { winA.close(); } catch (e) { };
}



//Chan 21/04/2006
function PressOnlyNumber() {
    if ((window.event.keyCode < 48) || (window.event.keyCode > 57)) return false;
}

function SelectTreeViewPopUp(hURL, txtId, txtName, iwidth, iheight, Submit) {
    // POPUP: makes screen display up and/or left, down and/or right 
    //      : depending on where cursor falls and size of window to open

    var height = (iheight == undefined ? 280 : iheight);
    var width = (iwidth == undefined ? 380 : iwidth);

    if (hURL == '../WebForm/SelPeriod.aspx') {
        width = 280
    }
    var properties = "height = " + height + ", width=" + width;
    var leftprop, topprop, screenX, screenY, cursorX, cursorY, padAmt;
    if (navigator.appName == "Microsoft Internet Explorer") {
        screenY = document.body.offsetHeight;
        screenX = window.screen.availWidth;
        if (window.event != null) {
            cursorX = window.event.screenX;
            cursorY = window.event.screenY;
        } else {
            cursorX = screenX / 2;
            cursorY = screenY / 2;
        }
    }
    else {
        screenY = window.outerHeight;
        screenX = window.outerWidth;
        cursorX = evX;
        cursorY = evY;
    }
    padAmtX = 10;
    padAmtY = 10;
    if ((cursorY + height + padAmtY) > screenY) {
        // make sizes a negative number to move left/up
        padAmtY = (-30) + (height * -1);
        // if up or to left, make 30 as padding amount
    }
    if ((cursorX + width + padAmtX) > screenX) {
        padAmtX = (-30) + (width * -1);
        // if up or to left, make 30 as padding amount
    }
    if (navigator.appName == "Microsoft Internet Explorer") {
        leftprop = cursorX + padAmtX;
        topprop = cursorY + padAmtY;
    }
    else {
        leftprop = (cursorX - pageXOffset + padAmtX);
        topprop = (cursorY - pageYOffset + padAmtY);
    }
    properties = properties + ", left = " + leftprop;
    properties = properties + ", top = " + topprop;

    hURL = hURL + (hURL.indexOf('?') == -1 ? '?' : '&') + 'idbox=' + txtId.id + '&namebox=' + txtName.id + '&submit=' + Submit;
    var features = ',toolbar=no,location=no,menubar=no,status=no,help=no,resizable=no,scrollbars=no';

    properties = properties + features;
    winI = window.open(hURL, txtName.id, properties);
    if (winI != null) {
        //winI.focus();
        if (window.attachEvent) {
            window.attachEvent('onbeforeunload', SelPopupEx);
        } else if (window.addEventListener) {
            window.addEventListener('unload', SelPopupEx, false);
        }
    }
}

function SelPopupEx() {
    if (winI != null) try { winI.close(); } catch (e) { };
}

function PressOnlyNumberdot() {
    if ((window.event.keyCode == 46) || ((window.event.keyCode > 47) && (window.event.keyCode < 58))) {
        return true;
    } else return false;
}

function GetDate(year) {
    if (year == 0)
        return "";
    else {
        var today = new Date();
        //var year  = today.getYear();
        var month = today.getMonth() + 1;
        var day = today.getDate();
        if (day < 10) day = '0' + day;
        if (month < 10) month = '0' + month;
        var str = day + '/' + month + '/' + year;
        return (str);
    }
}

//Created by Ton Use to check valid time textbox
//Used for OnKeyDown/OnKeyUp Only
function InputTime(obj) {
    if ((window.event.keyCode != 8) && (window.event.keyCode != 46)) {
        if (!(((window.event.keyCode >= 48) && (window.event.keyCode <= 57)) ||
				((window.event.keyCode >= 96) && (window.event.keyCode <= 105)))) {
            obj.value = obj.value.substring(0, obj.value.length - 1);
            return false;
        }
        else {
            if (obj.value.length == 2)
                obj.value += ":";
        }

        if (obj.value.length == 5)
            obj.value = obj.value.substring(0, 2) + ":" + obj.value.substring(3, 5);
    }
}

//Created by Ton Use to check valid time textbox
//Used for OnBlur
function CheckValidTime(obj) {
    var blnComplete = true;
    for (i = 0; i < obj.value.length; i++) {
        var ch = obj.value.charCodeAt(i);
        if ((ch < 48) || (ch > 58))
            blnComplete = false;
    }

    if (!blnComplete) {
        alert('Time format is not correct');
        obj.focus();
    }
    else {
        var arrChar = obj.value.split(":");
        if ((arrChar[0] > 23) || (arrChar[1] > 59)) {
            alert('Time format is not correct');
            obj.focus();
            blnComplete = false;
        }
    }
    return blnComplete;
}

// use for clear textBox

function ClearTextboxValues(txt) {
    txt.value = '';
}


// Create by Chan 19/07/2006
// modified by nut 26/07/2006 add การเติมจุดทศนิยม
function PressOnlyNumberdotFix(txt1, int1, int2) {
    var str1 = txt1.value
    var foundDot = str1.indexOf('.');

    if (foundDot > -1) {
        if (window.event.keyCode == 46) {
            return false;
        }
    }
    else {
        if ((str1.length > 0) && (window.event.keyCode == 46)) {
            if (str1.length <= int1) {
                return true;
            }
            else return false;
        }
    }

    if ((window.event.keyCode > 47) && (window.event.keyCode < 58)) {
        var aryVal = str1.split('.');

        if (aryVal.length == 1) {
            if (aryVal[0].length < int1)
            { return true; }
            else return false;
        }

        if (aryVal.length == 2) {
            if (aryVal[1].length < int2)
            { return true; }
            else return false;
        }
    }
    else return false;
}

function CheckNumberdotFix(txt1, int1, int2) {
    var aryVal = txt1.value.split('.');
    var foundDot1 = txt1.value.indexOf('.');
    var foundDot2 = txt1.value.lastIndexOf('.');

    if (foundDot1 != foundDot2) {
        txt1.value = '';
        return false;
    }

    if (aryVal.length == 1) {
        if (aryVal[0].length > int1) {
            txt1.value = '';
            return false;
        }
        else {
            txt1.value = txt1.value + '.00'
        }
    }

    if (aryVal.length == 2) {
        if (aryVal[0].length > int1) {
            txt1.value = '';
            return false;
        }


        if (aryVal[1].length > int2) {
            txt1.value = '';
            return false;
        }
        else {
            if (aryVal[1].length == 1) {
                txt1.value = txt1.value + '0'
            }

            if (aryVal[1].length == 0) {
                txt1.value = txt1.value + '00'
            }
        }
    }

    return true;
}

//================================================
function PressOnlyNumberdotFixGPA(txt1) {
    var str1 = txt1.value
    var foundDot = str1.indexOf('.');

    if (foundDot > -1) {
        if (window.event.keyCode == 46) {
            return false;
        }
    }
    else {
        if ((str1.length > 0) && (window.event.keyCode == 46)) {
            if (str1.length <= 1) {
                return true;
            }
            else return false;
        }
    }

    if ((window.event.keyCode > 47) && (window.event.keyCode < 58)) {
        var aryVal = str1.split('.');

        if (aryVal.length == 1) {
            if (aryVal[0].length < 1) {
                if ((window.event.keyCode >= 48) && (window.event.keyCode <= 52)) {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        if (aryVal.length == 2) {
            if (aryVal[0] == 4) {
                if (window.event.keyCode > 48)
                { return false; }
            }
            if (aryVal[1].length < 2)
            { return true; }
            else return false;
        }
    }
    else return false;
}

function CheckNumberdotFixGPA(txt1) {
    var aryVal = txt1.value.split('.');
    var foundDot1 = txt1.value.indexOf('.');
    var foundDot2 = txt1.value.lastIndexOf('.');

    if (foundDot1 != foundDot2) {
        txt1.value = '';
        return false;
    }

    if (txt1.value > 4) {
        txt1.value = '';
        return false;
    }

    if (aryVal.length == 1) {
        if (aryVal[0].length > 1) {
            txt1.value = '';
            return false;
        }
        else {
            if (txt1.value != '') {
                txt1.value = txt1.value + '.00'
            }

        }
    }

    if (aryVal.length == 2) {
        if (aryVal[0].length > 1) {
            txt1.value = '';
            return false;
        }


        if (aryVal[1].length > 2) {
            txt1.value = '';
            return false;
        }


        else {
            if (aryVal[1].length == 1) {
                txt1.value = txt1.value + '0'
            }

            if (aryVal[1].length == 0) {
                txt1.value = txt1.value + '00'
            }

        }
    }

    return true;
}
//---------------------------------------
//check Tax
function PressOnlyNumberdotFixTAX(txt1) {
    var str1 = txt1.value
    var foundDot = str1.indexOf('.');

    if (foundDot > -1) {
        if (window.event.keyCode == 46) {
            return false;
        }
    }
    else {
        if ((str1.length > 0) && (window.event.keyCode == 46)) {
            if (str1.length <= 3) {
                return true;
            }
            else return false;
        }
    }

    if ((window.event.keyCode > 47) && (window.event.keyCode < 58)) {
        var aryVal = str1.split('.');

        if (aryVal.length == 1) {
            if (aryVal[0].length <= 3) {
                //if ((window.event.keyCode >=48) && (window.event.keyCode <= 52))
                //{	
                return true;
                //}
                //else return false;
            }
            /*else if (aryVal[0].length == 3)
            {
            if(aryVal[0] > 100)
            {
            return false;
            }
            }*/
            else return false;
        }

        if (aryVal.length == 2) {
            if (aryVal[0] == 100) {
                if (window.event.keyCode > 48)
                { return false; }
            }
            if (aryVal[1].length < 2)
            { return true; }
            else return false;
        }
    }
    else return false;
}

function CheckNumberdotFixTAX(txt1) {
    var aryVal = txt1.value.split('.');
    var foundDot1 = txt1.value.indexOf('.');
    var foundDot2 = txt1.value.lastIndexOf('.');

    if (foundDot1 != foundDot2) {
        txt1.value = '';
        return false;
    }

    if (txt1.value > 100) {
        txt1.value = '';
        return false;
    }

    if (aryVal.length == 1) {
        if (aryVal[0].length > 3) {
            txt1.value = '';
            return false;
        }
        else {
            if (txt1.value != '') {
                txt1.value = txt1.value + '.00'
            }

        }
    }

    if (aryVal.length == 2) {
        if (aryVal[0].length > 3) {
            txt1.value = '';
            return false;
        }


        if (aryVal[1].length > 2) {
            txt1.value = '';
            return false;
        }


        else {
            if (aryVal[1].length == 1) {
                txt1.value = txt1.value + '0'
            }

            if (aryVal[1].length == 0) {
                txt1.value = txt1.value + '00'
            }

        }
    }

    return true;
}

//---------------------------------
function PressOnlyNumberdotFixTAX(txt1, int1, int2) {
    var str1 = txt1.value
    var foundDot = str1.indexOf('.');
    var aryVal = str1.split('.');
    var oldInt;
    var oldDec;

    var foundDot1 = txt1.value.indexOf('.');
    var foundDot2 = txt1.value.lastIndexOf('.');

    if (aryVal[0] == '') {
        txt1.value = ''
        return false;
    }

    if (foundDot1 != foundDot2) {
        if (aryVal.length > 2) {
            txt1.value = aryVal[0] + '.' + aryVal[1];
        }
        else {
            txt1.value = txt1.value.substring(0, foundDot1 + 1);
        }
        return false;
    }

    if (aryVal.length == 1) {
        oldInt = aryVal[0].substring(0, int1)
        if (aryVal[0].length > int1 - 1) {
            if (aryVal[0] > 100) {
                txt1.value = ''
            }
        }
    }

    if (aryVal.length == 2) {
        oldInt = aryVal[0].substring(0, int1)
        oldDec = aryVal[1].substring(0, int2)

        if (aryVal[1].length > int2)
        { txt1.value = oldInt + '.' + oldDec }

        if (aryVal[0].length > int1)
        { txt1.value = oldInt + '.' + oldDec }

    }
}

//---------function isDate check Date----------
function isdate(dd, mm, yy) {
    var maxDayArray = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    var Xday = dd
    var Xmonth = mm
    var Xyear = yy

    if ((Xyear < 1900) || (mm > 12)) { return false; }

    if (((Xmonth == 2) && (Xyear % 4 > 0)) || (Xmonth != 2)) {

        if (Xday > maxDayArray[Xmonth - 1])
            return false;
    }
    else {
        if (Xday > 29)
            return false;
    }


    return true;
}

//---------function check Date----------
function checkDate(val) {

    var dateString = new String(val.value)
    var dd = dateString.substr(0, 2);
    var mm = dateString.substr(3, 2);
    var yyyy = dateString.substr(6, 4);

    if (val.value.length == 10) {
        if (!isNaN(mm) && !isNaN(dd) && !isNaN(yyyy)) {

            verifyDate = dd + "/" + mm + "/" + yyyy;

            if (val.value != '') {
                if (yyyy > 2400) {
                    if (!isdate(dd, mm, yyyy)) {
                        alert('Incorrect Format! Please Try agin \n     (dd/mm/yyyy)');
                        val.value = '';
                    }
                    else {
                        return true;
                    }
                }
                else {
                    alert('Please Enter Buddhist \'s Year'); val.value = '';
                }
            }

        }
        else { alert('Incorrect Format! Please Try agin \n     (dd/mm/yyyy)'); val.value = ''; }
    }
    else {
        val.value = '';
    }
    return false;
}

// --function AddToRetireDate 
function AddToRetireDate(val, txtRetire) {
    if (checkDate(val)) {
        var dateString = new String(val.value)
        var dd = dateString.substr(0, 2);
        var mm = dateString.substr(3, 2);
        var yyyy = dateString.substr(6, 4);
        var ChrisYear = parseInt(yyyy - 543);

        DateCompare = dd + "/" + mm + "/" + ChrisYear;
        DateCompared = "02/10/" + ChrisYear;

        blnReturn = Compare2Date(DateCompare, DateCompared);
        if (blnReturn >= 0) {
            if (txtRetire != null) {
                //ก่อน 2 ตุลา +60 หลัง 2 ตุลา +61
                if (blnReturn == 0) txtRetire.value = "30/09/" + (parseInt(yyyy) + 60); //dd + "/" + mm + "/" + (parseInt(yyyy)+60);
                else txtRetire.value = "30/09/" + (parseInt(yyyy) + 61); //dd + "/" + mm + "/" + (parseInt(yyyy)+61);				
            }
        }
    }
}

//-----function Compare2Date(dd/MM/yyyy)เป็น string  return 0 ถ้าน้อยกว่า,return 1 ถ้ามากกว่าหรือเท่ากัน
//return -1 ผิดรูปแบบ   --DateCompare คือ ตัวที่เอามาเทียบ  DateCompared คือตัวถูกเทียบ
function Compare2Date(DateCompare, DateCompared) {
    var dt1 = parseInt(DateCompare.substring(0, 1), 10);
    var mon1 = parseInt(DateCompare.substring(3, 4), 10);
    var yr1 = parseInt(DateCompare.substring(6, 9), 10);
    var dt2 = parseInt(DateCompared.substring(0, 1), 10);
    var mon2 = parseInt(DateCompared.substring(3, 4), 10);
    var yr2 = parseInt(DateCompared.substring(6, 9), 10);
    var date1 = new Date(yr1, mon1, dt1);
    var date2 = new Date(yr2, mon2, dt2);
    if (date2 > date1) return 0;
    else if (date2 <= date1) return 1;
    else return -1;
}

//nut 21/04/2006
function PressOnlyNumberAndslah() {
    if ((window.event.keyCode < 47) || (window.event.keyCode > 57)) return false;
}

//24/01/2012
function PressExceptNumberAndDash() {
    if ((window.event.keyCode == 45) || ((window.event.keyCode > 47) && (window.event.keyCode < 58))) return false;
}