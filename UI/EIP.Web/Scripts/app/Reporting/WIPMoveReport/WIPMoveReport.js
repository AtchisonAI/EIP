﻿define(['reportingbootstrap'],
    function (abc) {
        initSelect();
        initGird();
        initGirdAdd();
        size = UtilWindowHeightWidth();
        
    });

function ValidateInput() {
  //  alert($('#selProductID').val());
    if ($('#selProductID').val() == null) {
        DialogTipsMsgError('请输入ProductID!', 5000);
        $('#selProductID').focus();
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


    $("#selPriority").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        maximumSelectionLength:9,
        placeholder: "请单击或输入数据过滤，选择Priority！",
        multiple: true,
        allowClear: true,//允许清空
        escapeMarkup: function (markup) { return markup; } // let our custom formatter work
        //minimumInputLength: 1
    });

    $("#InternalPriority").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        maximumSelectionLength: 9,
        placeholder: "请单击或输入数据过滤，选择Internal Priority！",
        multiple: true,
        allowClear: true,//允许清空
        escapeMarkup: function (markup) { return markup; } // let our custom formatter work
        //minimumInputLength: 1
    });

    $("#Bydate").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        maximumSelectionLength:1,
        placeholder: "请单击或输入数据过滤，选择By Monthly/Weekly/Daily！",
        multiple: true,
        allowClear: true,//允许清空
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
            url: '/Reporting/WIPMoveReport/QueryInfo',
            colModel: [
                { label: "Date", name: "V_DATE", width: 200, fixed: true},
                { label: "BOH", name: "BOH",  width: 200, fixed: true },
                { label: "EOH", name: "EOH",  width: 200, fixed: true },
                { label: "Daily Move", name: "STAGEMOVE",  width: 200, fixed: true },
                { label: "Avg.TR", name: "TR", width: 200, fixed: true }
            
            ],
            sortname: "V_DATE",
            height: '500px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {
                     
            }   
        });
    $("#list").setGroupHeaders({
        useColSpanStyle: true,    //表头是否合并行
        groupHeaders: [
            { startColumnName: 'V_DATE', numberOfColumns: 5, titleText: '<div align="center"><span>Product</span></div> ', textAlign: "center" }
        ]
    });

}

function initGirdAdd() {
   var   $grid1 = $("#list1").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/WIPMoveReport/QueryInfo1',
            colModel: [
                { label: "Date", name: "V_DATE", index: "V_DATE", width: 200, fixed: true },
                { label: "BOH", name: "BOH", width: 200, fixed: true },
                { label: "EOH", name: "EOH", width: 200, fixed: true },
                { label: "Daily Move", name: "STAGEMOVE", width: 200, fixed: true },
                { label: "Avg.TR", name: "TR", width:200, fixed: true }
                
            ],
            pager:'pager1',
            sortname: "V_DATE",
            height: '500px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {
            }
        });

    $("#list1").setGroupHeaders({
        useColSpanStyle: true,    //表头是否合并行
        groupHeaders: [
            { startColumnName: 'V_DATE', numberOfColumns: 5, titleText: '<div align="center"><span>Engineering</span></div> ', textAlign: "center" }
        ]
    });
}