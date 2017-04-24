$(function () {
    console.log("ready!");

    //$(window).bind('beforeunload', function () {
    //    BlockUI();
    //});
});

function doAjax(webMethod, jsonPar, isAsync) {
    if (isAsync == undefined)
        isAsync = false;
    $.ajax({
        type: "POST",
        url: webMethod, // "GestioneUtenti.aspx/OperazioneRisorse",
        data: jsonPar, // "{param:" + JSON.stringify(operazione) + ", guidArr:" + JSON.stringify(checkedGuid) + "}",
        contentType: "application/json; charset=utf-8",
        async: isAsync,
        dataType: "json",
        success: function (data) {
            if (data.d == null || data.d.length <= 0) {
                return;
            }
            ShowMessage(data.d, "success");
            __doPostBack(btnID, 'Operation_' + operazione);
        },
        error: OnErrorShowMessage
    });
}

function ShowMessage(message, type) {
    if (type == undefined)
        type = 'danger';
    GrowlMessage(type + ': ' + message);
    //$("#BodyContent_ucAvviso_divAvviso").show();
    //$("#BodyContent_ucAvviso_divAvviso").find("span").text(message);
    //if (classLbl == undefined)
    //    $("#BodyContent_ucAvviso_divAvviso").find("span").removeClass().addClass("label label-danger");
    //else
    //    $("#BodyContent_ucAvviso_divAvviso").find("span").removeClass().addClass("label label-" + classLbl);
}

function OnErrorShowMessage(response) {
    var err = eval("(" + response.responseText + ")");
    if (err.Message == "Authentication failed.") {
        window.location.href("Default.aspx");
        return;
    }
    ShowMessage(err.Message);
}

function GrowlMessage(message, timeOutSeconds) {
    if (timeOutSeconds == undefined)
        timeOutSeconds = 2500;
    $.blockUI({
        message: message,
        fadeIn: 700,
        fadeOut: 700,
        timeout: timeOutSeconds,
        showOverlay: false,
        centerY: false,
        css: {
            width: '350px',
            top: '30px',
            left: '',
            right: '10px',
            border: 'none',
            padding: '5px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: 1,// .6,
            color: '#fff'
        }
    });
}