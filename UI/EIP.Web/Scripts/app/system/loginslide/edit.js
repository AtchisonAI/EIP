define(["edit", 'chosenImage'], function () { });

//�ύ
function formSubmit() {
    var submitValue = $("#form").getValue();
    submitValue["Src"] = $("#Srcimghead").attr("src");
    UtilAjaxPostWait("/System/LoginSlide/Save",submitValue, success);
}

//�ɹ�
function success(data) {
    if (DialogAjaxResult(data)) {
        var win = artDialog.open.origin; //��Դҳ��
        win.getGridData();
        if (UtilEditIsdialogClose()) {
            if ($("#LoginSlideId").val() === Language.common.guidempty) {
                UtilFormReset("form");
            }
        } else {
            art.dialog.close();
        }
    }
}