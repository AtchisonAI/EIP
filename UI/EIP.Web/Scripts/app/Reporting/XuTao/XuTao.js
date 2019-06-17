﻿define(['reportingbootstrap'],
    function (abc) {
        initSelect();
        initGird();
        size = UtilWindowHeightWidth();
    });

function initSelect() {

    $("#selProductFamily").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        placeholder: "请单击或输入数据过滤，选择产品族！",
        maximumSelectionLength: 2,  //设置最多可以选择多少项
        multiple: true,//设置是否可以多选
        allowClear: true,//允许清空
        ajax: {
            url: "/Common/Common/QueryProductFamilySelectList",//获取数据的地址
            dataType: 'json',
            delay: 250,//按键之后多久才提交后台进行查询
            data: function (params) {//查询参数
                return {
                    productfamily: params.term,//获取输入作为productfamily，提交后台
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

    $("#selProductFamily").on("select2:unselect", function (e) {//绑定选中事件
        $("#selProduct").val(null).trigger('change');
    });

    $("#selProductFamily").on("select2:select", function (e) {//绑定取消选中事件
        $("#selProduct").val(null).trigger('change');
    });


    //远程筛选
    $("#selProduct").select2({
        language: "zh-CN", //设置 提示语言
        width: "100%", //设置下拉框的宽度
        placeholder: "请单击或输入数据过滤，选择产品！",
        maximumSelectionLength: 4,  //设置最多可以选择多少项
        multiple: true,
        allowClear: true,//允许清空
        ajax: {
            url: "/Common/Common/QueryProductSelectList",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                //控件联动，获取到选择的productfamily，传递给后台，过滤product
                var tmpproductfamily;
                if ($("#selProductFamily").val() !== null) {
                    tmpproductfamily = $("#selProductFamily").val().join("','");
                }

                return {
                    productfamily:tmpproductfamily,
                    product: params.term,
                    page:  params.page || 1
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
}

var size;//宽高


//重置流程
//ResetBefore
//如果 ResetBefore 返回 true
//  自动执行clearCondition();
//  自动执行clearGrids();
//  自动执行clearCharts();
//  AdditionalReset

function ResetBefore() {
    //自动重置之前，执行，如果不希望执行自动重置逻辑，则返回false
}

function AdditionalReset() {
   
    return true;
}

//提交流程
//ValidateInput
//如果 ValidateInput 返回 true
//  BeforeSearchClick
//  如果 BeforeSearchClick 返回 true
//      自动执行获取条件
//      自动执行所有class为grid的元素的reload事件
//      AfterSearchClick
function ValidateInput() {
    //客户端条件验证，如果不通过，返回false
}

function BeforeSearchClick() {
    //点击查询按钮后，在查询前触发，如果不希望执行自动查询，可返回false
    AdditionalReset();
    //asdfadsfasdf
    //adsfadsf
    return true;
}


function AfterSearchClick() {

}

//默认执行class为grid和chart的自适应方法
function windowResized() {
    
}

function loadGraph(data,data2) {

    // 基于准备好的dom，获取echarts实例
    var myChart = echarts.getInstanceByDom(document.getElementById('browserAnalysis'));
    myChart.setOption(data);
    // 基于准备好的dom，获取echarts实例
    var myChart1 = echarts.getInstanceByDom(document.getElementById('browserAnalysis1'));
    myChart1.setOption(data2);
}

//初始化表格
function initGird() {
   var grid = $("#list").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/XuTao/QueryLotInfo',
            colModel: [
                {
                    label: "Lot ID", name: "LOTID", index: "LOT.APPID", width: 130, fixed: true,
                    formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showLotHistory(\"" + rowdata.LOTID + "\")' ><font color='blue'><u>" + rowdata.LOTID +"</u></blue></a>";
                    }
                },
                { label: "Carrier ID", name: "CARRIERID", index: "LOT.TRANSPORTID", width: 130, fixed: true },
                { label: "Plan Name", name: "PLANNAME",  width: 130, fixed: true },
                { label: "Step Name", name: "STEPNAME", index: "FWS.StepName", width: 130, fixed: true },
                { label: "Product Name", name: "PRODUCTNAME", index: "LOT.ProductName", width: 130, fixed: true },
                { label: "Quanity", name: "QTY", index: "FWS.CURRENTQTY", width: 50, fixed: true },
                { label: "Status", name: "PROCESSINGSTATUS", index: "PROCESSINGSTATUS", width: 130, fixed: true },
                { label: "Customer Status", name: "EXTRASTATUS", index: "EXTRASTATUS", width: 130, fixed: true }
            ],
            sortname: "LOT.APPID",
            height: '500px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {
                loadGraph(json.ExtraDatas.Summary, json.ExtraDatas.Summary1);
                //alert(123);
                //return false;
            }
        });
    /*grid.setGroupHeaders({
        useColSpanStyle: true,    //表头是否合并行
        groupHeaders: [
            { startColumnName: 'LOTID', numberOfColumns: 2, titleText: '<div align="center"><span>二级表头1</span></div> ', textAlign: "center" },

            { startColumnName: 'PLANNAME', numberOfColumns: 2, titleText: '二级表头2 ', textAlign: "center" }
        ] });*/
}

function showLotHistory(lotID) {
    ArtDialogOpen("/Reporting/XuTao/LotHistory?lotID=" + lotID, "Lot History-" + lotID, true, 750,1200 ,true);
}
