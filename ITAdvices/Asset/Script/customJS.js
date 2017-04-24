$(function () {
    console.log("ready!");

    //$(window).bind('beforeunload', function () {
    //    BlockUI();
    //});
});

function doAjax(webMethod, jsonPar, isAsync) {
    if (isAsync == undefined)
        isAsync = false;
    var isOk = false
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
            NotifyMessage(data.d, "success");
            isOk = true;
        },
        error: OnErrorShowMessage
    });
    return isOk;
}

function OnErrorShowMessage(response) {
    var err = eval("(" + response.responseText + ")");
    if (err.Message == "Authentication failed.") {
        window.location.href("Default.aspx");
        return;
    }
    NotifyError(err.Message);
}

function NotifyMessage(message, type, icon) {
    if (icon == undefined)
        icon = 'fa fa-comment-o';
    
    $.notify({
        // options
        icon: icon,
        title: '<b>itAdvices dice:</b>',
        message: message,
        target: '_self'
    }, {
            // settings
            type: type,
            allow_dismiss: false,
            mouse_over: 'pause',
            delay: 2000
        }
    );
}
function NotifyError(message) {
    $.notify({
        // options
        icon: 'fa fa-exclamation-circle',
        title: '<b>itAdvices dice:</b>',
        message: message,
        target: '_self'
    }, {
            // settings
            type: 'danger',
            allow_dismiss: false,
            mouse_over: 'pause',
            delay: 2000
        }
    );
}
function NotifyLink(message, url) {
    if (url == undefined)
        url = 'javascript:void(0)';

    $.notify({
        // options
        icon: 'fa fa-external-link',
        title: '<b>itAdvices dice:</b>',
        message: message,
        url: url,
        target: '_self'
    }, {
            // settings
            type: 'primary',
            allow_dismiss: false,
            mouse_over: 'pause',
            delay: 2500
        }
    );
}

//$.notify({
//    // options
//    icon: 'glyphicon glyphicon-warning-sign',
//    title: 'Bootstrap notify',
//    message: 'Turning standard Bootstrap alerts into "notify" like notifications',
//    url: 'https://github.com/mouse0270/bootstrap-notify',
//    target: '_blank'
//}, {
//        // settings
//        element: 'body',
//        position: null,
//        type: "info",
//        allow_dismiss: true,
//        newest_on_top: false,
//        showProgressbar: false,
//        placement: {
//            from: "top",
//            align: "right"
//        },
//        offset: 20,
//        spacing: 10,
//        z_index: 1031,
//        delay: 5000,
//        timer: 1000,
//        url_target: '_blank',
//        mouse_over: null,
//        animate: {
//            enter: 'animated fadeInDown',
//            exit: 'animated fadeOutUp'
//        },
//        onShow: null,
//        onShown: null,
//        onClose: null,
//        onClosed: null,
//        icon_type: 'class',
//        template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
//        '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
//        '<span data-notify="icon"></span> ' +
//        '<span data-notify="title">{1}</span> ' +
//        '<span data-notify="message">{2}</span>' +
//        '<div class="progress" data-notify="progressbar">' +
//        '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
//        '</div>' +
//        '<a href="{3}" target="{4}" data-notify="url"></a>' +
//        '</div>'
//    });