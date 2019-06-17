define([
    'list',
    'edit'
],
 function () {
     initGrid();
    // initEvent();
     //showByTriggerType();
     //setJobInterval();
 });

var $grid, currentEditRow;
//表单提交
function formSubmit() {
    cancelEditTable();
    var submitValue = $("#form").getValue();
    //submitValue["PROCEDURENAME"] = submitValue["PROCEDURENAME"];
    submitValue["TRIGGER_TYPE"] = UtilGetDropdownListText("TRIGGER_TYPE");
    submitValue["MAX_RETRY_COUNT"] = submitValue["MAX_RETRY_COUNT"];
    //submitValue["IS_STOP_WHEN_FAILED"] = submitValue["IS_STOP_WHEN_FAILED"];
    var $ts = $("#list"), ids = $ts.getDataIDs(), json = "";;
    $.each(ids, function (index, rowid) {

        $grid.jqGrid('saveRow', rowid);
        var $row = $ts.getGridRowById(rowid);
        //if ($(":text[name='ParamName']", $row).length > 0) {
        //    var ParamName = $.trim($(":text[name='ParamName']", $row).val()),
        //        ParamSequence = $.trim($(":text[name='ParamSequence']", $row).val()),
        //        ParamType = $.trim($(":select[name='ParamType']", $row).val()),
        //        ValueType = $.trim($(":select[name='ValueType']", $row).val()),
        //        ParamExpression = $.trim($(":text[name='ParamExpression']", $row).val()),
        //        Description = $.trim($(":text[name='Description']", $row).val());
        //    if (ParamName != "" && ParamSequence != "" && ParamType != "" && ValueType != "" && ParamExpression != "")
        //        json += "{\"ParamName\":\"" + ParamName +
        //            "\",\"ParamSequence\":\"" + ParamSequence +
        //            "\",\"ParamType\":\"" + ParamType +
        //            "\",\"ValueType\":\"" + ValueType +
        //            "\",\"ParamExpression\":\"" + ParamExpression +
        //            "\",\"Description\":\"" + Description +
        //            "\"},";
        //} else {

            var rowData = $grid.jqGrid("getRowData", rowid), ParamName = rowData.ParamName;
            ParamSequence = rowData.ParamSequence, ParamType = rowData.ParamType;
            ValueType = rowData.ValueType, ParamExpression = rowData.ParamExpression;
        Description = rowData.Description, SysID = rowData.SysID, ParamLength = rowData.ParamLength;
            if (ParamName != "" && ParamSequence != "" && ParamType != "" && ValueType != "" && ParamExpression != "" ) {
                json += "{\"PARAM_NAME\":\"" + ParamName +
                    "\",\"PROCEDURENAME\":\"" + submitValue["PROCEDURENAME"] +
                    "\",\"SYSID\":\"" + SysID +
                    "\",\"PARAM_SEQUENCE\":\"" + ParamSequence +
                    "\",\"PARAM_TYPE\":\"" + ParamType +
                    "\",\"VALUE_TYPE\":\"" + ValueType +
                    "\",\"PARAM_LENGTH\":\"" + ParamLength +
                    "\",\"PARAM_EXPRESSION\":\"" + ParamExpression +
                    "\",\"PARAM_DESCRIPTION\":\"" + Description +
                    "\"},";
            } 
        //}
    });
    json = json.substring(0, json.length - 1);
    json = "[" + json + "]";
    submitValue["ParametersJson"] = json;

    UtilAjaxPostWait("/Reporting/JobConfig/Save",
        submitValue, success);
}

//提交成功
function success(data) {
    if (DialogAjaxResult(data)) {
        var win = artDialog.open.origin; //来源页面
        win.getGridData();
        if (UtilEditIsdialogClose()) {
            if (UtilGetUrlParam("id") == Language.common.guidempty || UtilGetUrlParam("id") == '') {
                UtilFormReset("form");
                UtilFocus("PROCEDURENAME");
            }
        }
        else {
            art.dialog.close();
        }
    }
}

//初始化表格
function initGrid() {
    $grid = $("#list").jgridview(
        {
            shrinkToFit: true,
            url: "/Reporting/JobConfig/PagingConfigParamQuery",
            postData: {
                ProcedureName: $("#PROCEDURENAME").val()
            },
            cellEdit: true,
            cellsubmit: 'clientArray',
            multiselect: false,
            colModel: [{
                label: "", name: "SysID", fixed: true, editable: true, edittype: "text",hidden:true
            },
                {
                    label: "Param Name", name: "ParamName", width: 100, fixed: true, editable: true, edittype: "text",
                    editrules: { required: true }},
                {
                    label: "Sequence", name: "ParamSequence", width: 90, fixed: true, editable: true, edittype: "text",
                    editrules: { required: true }
                },
                {
                    label: "Param Type", name: "ParamType", width: 130, align: "center", fixed: true, editable: true, edittype: 'select',
                    editoptions:
                    {
                        value: {
                            OraExpression: 'OraExpression', SQL: 'SQL', SysExpression: 'SysExpression'
                        }
                    },
                    editrules: { required: true }
                },
                {
                    label: "Value Type", name: "ValueType", width: 120, align: "center", fixed: true, editable: true, edittype: 'select',
                    editoptions:
                    {
                            value: {
                                Date: 'Date', Varchar2: 'Varchar2', Varchar: 'Varchar', Number: 'Number', Char: 'Char'
                            }
                        },
                    editrules: { required: true }
                },
                {
                    label: "Param Length", name: "ParamLength", width: 90, fixed: true, editable: true, edittype: "text",
                    editrules: { required: true }
                },
                {
                    label: "Expression", name: "ParamExpression", width: 200, align: "center", fixed: true, editable: true, edittype: "textarea", editoptions: { rows: "2", cols: "10" },
                    editrules: { required: true } },
                { label: "Description", name: "Description", width: 160, align: "center", fixed: true,  editable: true, edittype: "textarea", editoptions: { rows: "2", cols: "10" } },
                {
                    label: "<span class='l-icon-add' title='新增' style='display:inline-block;height:16px;width:16px'></span>", sortable: false, fixed: true, width: 60, name: "Action", align: "center", formatter: function (cellValue, options, rowdata, action) {

                        return "<span class='l-icon-edit' title='编辑' onclick='editRow(\"" + options.rowId + "\")' style='display:inline-block;height:16px;width:16px;margin-right:8px'></span><span onclick='delRow(\"" + options.rowId + "\")' class='l-icon-delete' title='删除' style='display:inline-block;height:16px;width:16px'></span>";
                    }
                }
            ],
            ondblClickRow: editRow,
            height: 370,
            rowNum: 500,
            sortname: 'Param_Sequence',
            sortorder: "asc",
            loadComplete: function () {
                //// 添加一条
                //$grid.addRow({
                //    position: "last"
                //});
            }
        });

    $(".l-icon-add").bind("click", function () {
        $grid.addRow({ position: "last" });
    });

    //$('#list').delegate('.l-icon-delete', 'click', function () { // 删除
    //    delRow($(this));
    //});
    //$('#list').delegate('.l-icon-edit', 'click', function () { // 编辑
    //    var str = $(this).parents(".ui-jqgrid-btable").attr("id");
    //    var element = $(this).parent().parent();
    //    if (element.find("input").length > 1) {
    //        cancelEditTable(); // 取消
    //    } else {
    //        editTable(str, element); // 编辑
    //    }
    //});
}

// 删除行
function delRow(rowId) {
    //var rowId = element.parents("tr").attr("id");
    //element.parents("table").delRowData(rowId);
    $grid.delRowData(rowId);
}

//取消编辑
function cancelEditTable() {
    if (currentEditRow != null && currentEditRow != "" && currentEditRow.length > 0) {
        $grid.jqGrid('saveRow', currentEditRow);//保存上一行
    }
}

//编辑
function editRow(rowid) {
    // 如果当前处于编辑状态直接返回
    cancelEditTable(); // 取消编辑行的编辑状态

    if (rowid === currentEditRow) {
        currentEditRow = '';
        return;
    }
    ////设置element为编辑列
    //element.find(".input_text").each(function () {
    //    var value = $(this).text();
    //    var input = $("<input type='text'  style='width: 99%;height: 90%;'/>");
    //    input.val(value);
    //    $(this).html(input);
    //});

    $grid.jqGrid('editRow', rowid, { focusField: 1 });
    
    currentEditRow = rowid;
};
