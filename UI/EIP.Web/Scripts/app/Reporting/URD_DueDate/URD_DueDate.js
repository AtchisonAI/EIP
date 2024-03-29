﻿define(['reportingbootstrap'],
    function (abc) {
        initSelect();
        initGird();
        size = UtilWindowHeightWidth();
        
    });

function ValidateInput() {
  //  alert($('#selProductID').val());
    if ($('#selProductID').val() == null) {
        DialogTipsMsgError('请输入ProductID!', 5000);
        $('#selProductID').focus();
        return false;
    }
    if ($('#LotType').val() == null) {
        DialogTipsMsgError('请输入LotType!', 5000);
        $('#LotType').focus();
        return false;
    }
    if ($('#StartTime').val() == '') {
        DialogTipsMsgError('请输入StartTime!', 5000);
        $('#StartTime').focus();
        return false;
    }
    if ($('#EndTime').val() == '') {
        DialogTipsMsgError('请输入EndTime!', 5000);
        $('#EndTime').focus();
        return false;
    }
    return true;
}

function initSelect() {

    $("#selTechID").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        placeholder: "请单击或输入数据过滤，选择TECH.ID！",
        maximumSelectionLength: 2,  //设置最多可以选择多少项
        multiple: true,//设置是否可以多选
        allowClear: true,//允许清空
        ajax: {
            url: "/Common/Common/QueryTechIDSelectList",// /Common 文件夹名，/common controllers名字，/query..方法名字 获取数据的地址
            dataType: 'json',
            delay: 250,//按键之后多久才提交后台进行查询
            data: function (params) {//查询参数
                return {
                    selTechID: params.term,//获取输入作为productfamily，提交后台
                    page: params.page || 1//当前页数
                };
            },
            processResults: function (result, params) {//获取到后台数据后，进行解析
                params.page = params.page || 1;
                if (result.isSuccess) {
                    return {
                        results: result.data,
                        pagination: {
                            more: (params.page * 10) < result.totalCount//分页条件：当前已显示数量<总数
                        }
                    };
                } else {
                    return {
                        results: null
                    };
                }
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; } // let our custom formatter work
        //minimumInputLength: 1
    });



    //远程筛选
    $("#selCustomerID").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        placeholder: "请单击或输入数据过滤，选择CustomerID！",
        maximumSelectionLength: 4,  //设置最多可以选择多少项
        multiple: true,
        allowClear: true,//允许清空
        ajax: {
            url: "/Common/Common/QueryCustomerIDSelectList",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                //控件联动，获取到选择的productfamily，传递给后台，过滤product
                var tmpproductfamily;
                if ($("#selTechID").val() !== null) {
                    tmpproductfamily = $("#selTechID").val().join("','");
                }

                return {
                    selTechID: tmpproductfamily,
                    selCustomerID: params.term,
                    page: params.page || 1
                };
            },
            processResults: function (result, params) {
                params.page = params.page || 1;
                if (result.isSuccess) {
                    return {
                        results: result.data,
                        pagination: {
                            more: (params.page * 10) < result.totalCount
                        }
                    };
                } else {
                    return {
                        results: null
                    };
                }
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; } // let our custom formatter work
        //minimumInputLength: 1
    });

    $("#selProductID").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        placeholder: "请单击或输入数据过滤，选择ProductID！",
        maximumSelectionLength: 4,  //设置最多可以选择多少项
        multiple: true,
        allowClear: true,//允许清空
        ajax: {
            url: "/Common/Common/QueryselProductIDSelectList",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                //控件联动，获取到选择的productfamily，传递给后台，过滤product
                var tmpproductfamily;
                var tmpproductfamily1;
                if ($("#selTechID").val() !== null && $("#selCustomerID").val() !== null) {
                    tmpproductfamily = $("#selTechID").val().join("','");
                    tmpproductfamily1 = $("#selCustomerID").val().join("','");
                }

                return {
                    selCustomerID: tmpproductfamily1,
                    selTechID: tmpproductfamily,
                    selProductID: params.term,
                    page: params.page || 1
                };
            },
            processResults: function (result, params) {
                params.page = params.page || 1;
                if (result.isSuccess) {
                    return {
                        results: result.data,
                        pagination: {
                            more: (params.page * 10) < result.totalCount
                        }
                    };
                } else {
                    return {
                        results: null
                    };
                }
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; } // let our custom formatter work
        //minimumInputLength: 1
    });

    $("#LotType").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        placeholder: "请单击或输入数据过滤，选择LotType！",
        maximumSelectionLength: 2,  //设置最多可以选择多少项
        multiple: true,//设置是否可以多选
        allowClear: true,//允许清空
        ajax: {
            url: "/Common/Common/QueryLotTypeList",// /Common 文件夹名，/common controllers名字，/query..方法名字 获取数据的地址
            dataType: 'json',
            delay: 250,//按键之后多久才提交后台进行查询
            data: function (params) {//查询参数
                return {
                    LotType: params.term,//获取输入作为productfamily，提交后台
                    page: params.page || 1//当前页数
                };
            },
            processResults: function (result, params) {//获取到后台数据后，进行解析
                params.page = params.page || 1;
                if (result.isSuccess) {
                    return {
                        results: result.data,
                        pagination: {
                            more: (params.page * 10) < result.totalCount//分页条件：当前已显示数量<总数
                        }
                    };
                } else {
                    return {
                        results: null
                    };
                }
            },
            cache: true
        },
        escapeMarkup: function (markup) { return markup; } // let our custom formatter work
        //minimumInputLength: 1
    });
   
}





var size; //宽高


function loadGraph(data) {
    
    myChart.setOption(data);
    myChart1.setOption(data);
}

//初始化表格
function initGird() {
   var $grid = $("#list").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
           url: '/Reporting/URD_DueDate/QueryInfo',
            colModel: [
                { label: "Date", name: "V_DATE", width: 100, fixed: true},
                { label: "LOTID", name: "APPID",  width: 100, fixed: true },
                { label: "LOTTYPE", name: "LOTTYPE",  width: 100, fixed: true },
                { label: "PRODUCT", name: "PARTID",  width: 100, fixed: true },
                { label: "PRIORITY", name: "PRIORITY", width: 100, fixed: true },
                { label: "STAGENAME", name: "STAGENAME", width: 100, fixed: true },
                { label: "STEPNAME", name: "STEPNAME", width: 100, fixed: true },
                { label: "EQPID", name: "LOCATION", width: 100, fixed: true },
                { label: "STATE", name: "PROCESSINGSTATE", width: 100, fixed: true },
                { label: "CAPABILITY", name: "REQUIREDCAPABILITY", width: 100, fixed: true },
                { label: "EQPTYPE", name: "RESOURCETYPE", width: 100, fixed: true },
                { label: "RECEIP", name: "PPID", width: 130, fixed: true },
                { label: "SEPNO", name: "HANDLE", width:100, fixed: true },
                { label: "CURQTIME", name: "CURQTIME", width: 100, fixed: true },
                { label: "CURHTIME", name: "CURHOLDTIME", width: 100, fixed: true },
                { label: "CURRTIME", name: "CURRTIME", width: 100, fixed: true },
                { label: "TOTALSTEP", name: "TOTALSTEP", width: 100, fixed: true },
                { label: "REMAININGSTEP", name: "REMAININGSTEP", width: 130, fixed: true },
                { label: "TOTALSTAGE", name: "TOTALSTAGE", width: 100, fixed: true },
                { label: "REMAININGSTAGE", name: "REMAININGSTAGE", width: 130, fixed: true }
            
            ],
           sortname: "HANDLE",
            height: '500px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {
                     
            }   
        });
   

}

