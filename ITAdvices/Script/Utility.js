
function BlockUI() {
    if ($('#hdnCulture') != null) {
        var culture = $('#hdnCulture').val();
        $.blockUI({ message: "<br /><p>Attendere Elaborazione in corso...</p><br />", css: { backgroundColor: '#07A', borderColor: '#FFF', color: '#FFF'} });
    }
}

function UnBlockUI() {
    $.unblockUI();
}

function ScrollTopPage() {
    if (typeof (WebForm_RestoreScrollPosition) == 'function') {
        theForm.__SCROLLPOSITIONX = "0";
        theForm.__SCROLLPOSITIONY = "0";
        WebForm_RestoreScrollPosition();
    }
    $("html, body").animate({ scrollTop: 0 }, 'fast');
}

//Clear value of textBox field
function CleanTextBoxValue(IDTextBox) {
    $(IDTextBox).val('');
}

//Clear selected index of ddl
function CleanDdlValue(IDDropDown) {
    $(IDDropDown).get(0).selectedIndex = 0;
}

function cancelBack() {
    if (event.keyCode == 8 || (event.keyCode == 37 && event.altKey) || (event.keyCode == 39 && event.altKey)) {
        if (event.srcElement != null && (event.srcElement.type == "text" || event.srcElement.type == "textarea") && !event.srcElement.readOnly)
            return;
        else if (event.srcElement.form == null || event.srcElement.isContentEditable == false) {
            event.cancelBubble = true;
            event.returnValue = false;
        }
    }
}

function cancelBackFF(event) {
    if (event.keyCode == 8 || (event.keyCode == 37 && event.altKey) || (event.keyCode == 39 && event.altKey)) {
        if (event.originalTarget != null && (event.originalTarget.type == "text" || event.originalTarget.type == "textarea") && !event.originalTarget.readOnly)
            return;
        else if (event.originalTarget.form == null || event.originalTarget.isContentEditable == false) {
            //event.cancelBubble = true;
            event.stopPropagation();
            event.returnValue = false;
        }
    }
}

function isSessionExpired(textStatus, message) {
    if (textStatus == "error" && message == "Unauthorized")
        return true;

    return false;
}


/*INIZIO DATEPICKER*/
//Calendario Giorno/Mese/Anno
$(function () {
    $(".calendar_DDMMYYYY").unmask();
    $(".calendar_DDMMYYYY").mask("99/99/9999");
    $(".calendar_DDMMYYYY").datepicker({
        changeMonth: true,
        changeYear: true,
        changeDay: true,
        showButtonPanel: true,
        dateFormat: 'dd/mm/yy',
        showOn: 'button',
        buttonImageOnly: true,
        buttonImage: '../App_Themes/BlueINPS1/Images/calendar3.png',
        buttonText: 'Calendario',
        minDate: '-100y',
        maxDate: '0',
        yearRange: 'c-80:' + 'c+80:',

        onClose: function (dateText, inst) {
            var dateTypeVar = $(this).datepicker('getDate');
            $.datepicker.formatDate('dd/mm/yy', dateTypeVar);
        },
        beforeShow: function (input, inst) {
            inst.dpDiv.removeClass('calendarDefault');
        }
    });
});

//Calendario Mese/Anno
$(function () {
    $(".calendar_MMYYYY").unmask();
    $(".calendar_MMYYYY").mask("99/9999");
    $(".calendar_MMYYYY").datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: 'mm/yy',
        showOn: 'button',
        buttonImageOnly: true,
        buttonImage: '../App_Themes/BlueINPS1/Images/calendar3.png',
        buttonText: 'Calendario',
        maxDate: +0,
        minDate: '-100y',
        beforeShowDay: function e() { return 0 },
        beforeShow: function (input, inst) {
            inst.dpDiv.addClass('calendarDefault');
        }
    }).focus(function () {
        var thisCalendar = $(this);
        $('.ui-datepicker-calendar').detach();
        $('.ui-datepicker-close').click(function () {
            var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
            var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
            thisCalendar.datepicker('setDate', new Date(year, month, 1));
        });
    });
    ;
});

jQuery(function ($) {
    $.datepicker.regional['it'] = {
        closeText: 'Chiudi',
        prevText: '&#x3c;Prec',
        nextText: 'Succ&#x3e;',
        currentText: 'Oggi',
        monthNames: ['Gennaio', 'Febbraio', 'Marzo', 'Aprile', 'Maggio', 'Giugno',
                        'Luglio', 'Agosto', 'Settembre', 'Ottobre', 'Novembre', 'Dicembre'],
        monthNamesShort: ['Gen', 'Feb', 'Mar', 'Apr', 'Mag', 'Giu',
                        'Lug', 'Ago', 'Set', 'Ott', 'Nov', 'Dic'],
        dayNames: ['Domenica', 'Luned&#236', 'Marted&#236', 'Mercoled&#236', 'Gioved&#236', 'Venerd&#236', 'Sabato'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mer', 'Gio', 'Ven', 'Sab'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Me', 'Gi', 'Ve', 'Sa'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['it']);
});

var JumpOnClose = false;

jQuery.datepicker._gotoToday = function (id) {
    JumpOnClose = true;
    var today = new Date();
    var dateRef = jQuery("<td><a>" + today.getDate() + "</a></td>");
    this._selectDay(id, today.getMonth(), today.getFullYear(), dateRef);
};

//Funzione che abilita/disabilita l'icona del DatePicker
function ManageDatePicker(IDcontrol) {
    if ($(IDcontrol).is(":disabled"))
        $(IDcontrol).datepicker('disable');
    else
        $(IDcontrol).datepicker('enable');
}
/*FINE DATEPICKER*/

function SetSelectStyleDisableBackground() {
    $("select:disabled.selectDisableBackground").addClass("disableBackground");
    $("input:disabled.selectDisableBackground").addClass("disableBackground");
}

function extractNumber(obj, decimalPlaces, allowNegative) {
    var temp = obj.value;
    var decimalSeparator = ',';

    // avoid changing things if already formatted correctly
    var reg0Str = '[0-9]*';
    if (decimalPlaces > 0) {

        reg0Str += '\\' + decimalSeparator + '?[0-9]{0,' + decimalPlaces + '}';
    } else if (decimalPlaces < 0) {
        reg0Str += '\\.?[0-9]*';
    }
    reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
    reg0Str = reg0Str + '$';
    var reg0 = new RegExp(reg0Str);
    if (reg0.test(temp)) return true;

    // first replace all non numbers
    var reg1Str = '[^0-9' + (decimalPlaces != 0 ? decimalSeparator : '') + (allowNegative ? '-' : '') + ']';
    var reg1 = new RegExp(reg1Str, 'g');
    temp = temp.replace(reg1, '');

    if (allowNegative) {
        // replace extra negative
        var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
        var reg2 = /-/g;
        temp = temp.replace(reg2, '');
        if (hasNegative) temp = '-' + temp;
    }

    if (decimalPlaces != 0) {
        //var reg3 = /\,/g;
        //alert(reg3);
        var reg = '/\\' + decimalSeparator + '/g';
        var reg3 = new RegExp(eval(reg));

        var reg3Array = reg3.exec(temp);
        if (reg3Array != null) {
            // keep only first occurrence of .
            //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
            var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
            reg3Right = reg3Right.replace(reg3, '');
            reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
            temp = temp.substring(0, reg3Array.index) + decimalSeparator + reg3Right;
        }
    }

    obj.value = temp;
}

function blockNonNumbers(obj, e, allowDecimal, allowNegative) {
    var key;
    var isCtrl = false;
    var keychar;
    var reg;
    var decimalSeparator = ',';

    if (window.event) {
        key = e.keyCode;
        isCtrl = window.event.ctrlKey
    }
    else if (e.which) {
        key = e.which;
        isCtrl = e.ctrlKey;
    }

    if (isNaN(key)) return true;

    keychar = String.fromCharCode(key);

    // check for backspace or delete, or if Ctrl was pressed
    if (key == 8 || isCtrl) {
        return true;
    }

    reg = /\d/;
    var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
    var isFirstD = allowDecimal ? keychar == decimalSeparator && obj.value.indexOf(',') == -1 : false;

    //Errore, decimalSeparator  non definito
    //	var isFirstD = allowDecimal ? keychar == decimalSeparator && obj.value.indexOf(',') == -1 : false;

    return isFirstN || isFirstD || reg.test(keychar);
}





function extractPhoneChar(obj) {
    var temp = obj.value;

    // avoid changing things if already formatted correctly
    var reg0Str = '[0-9]*/+';

    reg0Str = reg0Str + '$';
    var reg0 = new RegExp(reg0Str);
    if (reg0.test(temp)) return true;

    // first replace all non numbers
    var reg1Str = '[^0-9' + '/' + '\+' + ']';
    var reg1 = new RegExp(reg1Str, 'g');
    temp = temp.replace(reg1, '');



    obj.value = temp;
}

function blockNonPhone(obj, e) {
    var key;
    var isCtrl = false;
    var keychar;
    var reg;

    if (window.event) {
        key = e.keyCode;
        isCtrl = window.event.ctrlKey
    }
    else if (e.which) {
        key = e.which;
        isCtrl = e.ctrlKey;
    }

    if (isNaN(key)) return true;

    keychar = String.fromCharCode(key);

    // check for backspace or delete, or if Ctrl was pressed
    if (key == 8 || isCtrl) {
        return true;
    }

    reg = /\d/;


    return keychar;
}
