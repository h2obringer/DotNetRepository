
/**
 * Any .circle-loader (css class) element will transition to the completed animation
 * showing the checkmark and the progress bar stops spinning.
 * @param {any} selector
 */
function progressComplete(selector) {
    $(selector).addClass("load-complete");
    $(selector + " > .checkmark").show();
}

/**
 * Remove the progress indicator, hide it from view and reset animation.
 * @param {any} selector
 */
function clearProgress(selector) {
    $(selector).removeClass("load-complete");
    $(selector).hide();
    $(selector + " > .checkmark").hide();
}