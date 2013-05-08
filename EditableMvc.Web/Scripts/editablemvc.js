/* Required to bind the htmlhelper with the update controller action*/

var updateUrl = "/editablemvc/update";

function callbackUpdateContent(success, id) {
    id = "#" + id;
    var bgcol = $(id).css('backgroundColor');
    if(success == true) {
        $(id).animate({  opacity: '0.0' }, "slow");
        $(id).animate({  opacity: '0.4' }, "slow");
        $(id).animate({  opacity: '0.8' }, "slow");
        $(id).animate({  opacity: '0.4' }, "slow");
        $(id).animate({  opacity: '1' }, "slow");
    }
}
$(document).ready(function () {
    CKEDITOR.disableAutoInline = true;
    var editableBlocks = $('.editablemvc').select('[contenteditable="true"]');
    for (var i = 0; i < editableBlocks.length; i++) {
        var idOfEditableBlock = $(editableBlocks[i]).attr('id');
        CKEDITOR.inline(idOfEditableBlock);
    }
    CKEDITOR.config.extraPlugins = 'editablemvcsave';
});