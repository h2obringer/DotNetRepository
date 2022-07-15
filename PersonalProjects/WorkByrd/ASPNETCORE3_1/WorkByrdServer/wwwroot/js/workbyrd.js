// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/**
 * This function returns a promise whose data is a json object that must be manipulated in a .then() call.
 * It is recommended that .catch(err=>console.error(err)) also be tagged after this function. This allows performing AJAX in an INSECURE manner.
 * @param {any} myurl
 * @param {any} isnestedvm
 *   - optional. defaults to false. if set to true, Nested View Model names in forms are removed, allowing correct mappings to the correct ViewModel upon posting to the server.
 */
async function wbGetJSON(myurl) {
    const response = await fetch(
        myurl, {
            method: 'GET'
        }
    );
    return await response.json(); //this returns a promise...
}

/**
 * This function returns a promise whose data is a json object that must be manipulated in a .then() call.
 * It is recommended that .catch(err=>console.error(err)) also be tagged after this function. This allows performing AJAX in a secure manner.
 * @param {any} myurl
 * @param {any} mydata 
 *   - ["__RequestVerificationToken"] should be set on the html page in a hidden input by the @Html.AntiForgeryToken() server function or explicitly set on this parameter.
 *   - additional data...
 * @param {any} type
 *   - optional. defaults to 'application/x-www-form-urlencoded; charset=UTF-8'. if send data as a JSON string if specified as such.
 */
async function wbGetSecureJSON(myurl, mydata) {
    var content = '';
    var contentType = '';

    if (mydata instanceof FormData) {
        if (!mydata.has("__RequestVerificationToken")) {
            mydata.append("__RequestVerificationToken", $('input[name="__RequestVerificationToken"]').val());
            if (mydata.get("__RequestVerificationToken") == null) {
                throw "No Anti-Forgery Token is present.";
            }
        }
        //turn the data into url encoded form data...
        for (var pair of mydata.entries()) {
            content = content + encodeURIComponent(pair[0]) + '=' + encodeURIComponent(pair[1]) + '&';
        }
        if (content.endsWith("&")) {
            content = content.slice(0, -1); //remove the trailing &
        }
        contentType = 'application/x-www-form-urlencoded; charset=UTF-8';

    } else if (typeof (mydata) === "object") {
        if (mydata.__RequestVerificationToken == null) {
            mydata.__RequestVerificationToken = $('input[name="__RequestVerificationToken"]').val();
            if (mydata.__RequestVerificationToken == null) {
                throw "No Anti-Forgery Token is present.";
            }
        }

        content = JSON.stringify(mydata);
        contentType = 'application/json; charset=utf-8';
        
    } else {
        throw "Data must be FormData or an object.";
    }

    const response = await fetch(
        myurl, {
        method: 'POST',
        body: content,
        headers: {
            'Content-Type': contentType
        }
    });

    if (response.ok != null && !response.ok) {
        var msg = "";
        if (response.status != null && !isNaN(response.status)) {
            msg = response.status + ": ";
        }
        if (response.statusText != null && response.statusText != "" && response.status != null && !isNaN(response.status)) {
            msg += response.statusText;
        } else {
            msg += "Unable to complete secure ajax request";
        }
        throw msg;
    }

    return await response.json(); //this returns a promise...
}

function PostJSON(myurl, mydata, success, error) {
    var content = '';
    if (typeof (mydata) === 'string') {
        content = mydata;
    } else {
        content = JSON.stringify(mydata);
    }

    if (success == null) {
        success = function () { };
    }
    if (typeof (success) != 'function') {
        console.error("success parameter must be a function.");
        throw "success parameter must be a function.";
    }

    if (error == null) {
        error = function () { };
    }
    if (typeof (error) != 'function') {
        console.error("error parameter must be a function.");
        throw "error parameter must be a function.";
    }

    $.ajax({
        type: "POST",
        url: myurl,
        data: content,
        contentType: "application/json",
        dataType: "json",
        success: success,
        error: error
    });
}

/**
 * Refresh dropdown items in a <select> form dropdown list with new items.
 * @param {any} selector
 * @param {any} data - json serialized c# SelectListItem list
 */
function refreshDropdown(selector, data) {
    if (data == null || data == "[]") {
        clearDropdown(selector);
        return;
    }

    var selectoptions = [];
    $.each(data, function (i, item) {
        var option = '<option value="' + item.value + '"';
        if (item.selected == true) {
            option += ' selected="selected"';
        }
        option += '>' + item.text + '</option>';
        selectoptions.push(option);
    });
    $(selector).html(selectoptions.join(""));
}

/**
 * Reduces a period delimeted name down to its last part. Helpful for posting variables from ViewModels that combine multiple view models
 * where @Html functions will append each part of the nested object delimeted by a period. 
 * @param {any} fullname - i.e. "RegisterUserViewModel.Email" will return "Email" (and "Email" will return "Email")
 */
function reduceName(fullname) {
    return fullname.split(".").pop();
}

/**
 * Start a slide animation to scroll to a specified on-page anchor
 * @param {any} selector
 */
function scrollToAnchor(selector) {
    if (!$(selector).is('a')) {
        console.log($(selector).is('a'));
        throw "<a> elements are the only allowed scroll-to type.";
    }
    $('html,body').animate({ scrollTop: $(selector).offset().top }, 'slow');
}

/**
 * Clear all dropdown items out of a <select> form dropdown list.
 * @param {any} selector
 */
function clearDropdown(selector) {
    $(selector).html('<option value=" " selected="selected"> </option>');
    return;
}

/**
 * Disable all inputs within a target form to include <include>, <textarea>, and <button>
 * @param {any} selector
 */
function disableForm(selector) {
    var selector = selector + " :input";
    $(selector).prop("disabled", true);
}

/**
 * Enables all inputs within a target form to include <include>, <textarea>, and <button>
 * @param {any} selector
 */
function enableForm(selector) {
    var selector = selector + " :input";
    $(selector).prop("disabled", false);
}


$(document).ready(function () {
    /*Modals*/
    //$('.btn[data-toggle=modal]').on('click', function () {
    //    debugger;
    //    var $btn = $(this);
    //    var currentDialog = $btn.closest('.modal-dialog')
    //    var targetDialog = $($btn.attr('data-target'));
    //    if (!currentDialog.length)
    //        return;
    //    targetDialog.data('previous-dialog', currentDialog);
    //    currentDialog.addClass('aside');
    //    var stackedDialogCount = $('.modal.in .modal-dialog.aside').length;
    //    if (stackedDialogCount <= 5) {
    //        currentDialog.addClass('aside-' + stackedDialogCount);
    //    }
    //});

    //$('.modal').on('hide.bs.modal', function () {
    //    debugger;
    //    var $dialog = $(this);
    //    var previousDialog = $dialog.data('previous-dialog');
    //    if (previousDialog) {
    //        previousDialog.removeClass('aside');
    //        $dialog.data('previous-dialog', undefined);
    //    }
    //});
    /*End Modals*/
});