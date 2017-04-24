
function BlockUI() {
    $.blockUI({ message: "<br /><p>Attendere Elaborazione in corso...</p><br />", css: { backgroundColor: '#07A', borderColor: '#FFF', color: '#FFF'} });
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