/* Add save button to the editor and perform post/callback of data */

CKEDITOR.plugins.add('editablemvcsave', {
    init: function (editor) {
        editor.addCommand('saveEditableContent', {
            exec: function (editor) {
                var values =
                    {
                        "Id": editor.name,
                        "Content": editor.getData()
                    };
                //posting the content to the controller method via ajax
                $.post(updateUrl, values, function (data)
                {
                    // add something if you like;
                    callbackUpdateContent(data, editor.name);
                });
            }
        });
        editor.ui.addButton('Timestamp', {
            label: 'Save content [EditableMvc]',
            command: 'saveEditableContent',
            icon: this.path + "save.png"
        });
    }
});