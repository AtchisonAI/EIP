define(["edit"], function() {});

//�ύ
function formSubmit() {
    var submitValue = $("#form").getValue();
    UtilAjaxPostWait("/System/Download/Save",
        submitValue, success);
}

//�ɹ�
function success(data) {
    if (DialogAjaxResult(data)) {
        var win = artDialog.open.origin; //��Դҳ��
        win.getGridData();
        if (UtilEditIsdialogClose()) {
            if ($("#DownloadId").val() === Language.common.guidempty) {
                UtilFormReset("form");
            }
        } else {
            art.dialog.close();
        }
    }
}