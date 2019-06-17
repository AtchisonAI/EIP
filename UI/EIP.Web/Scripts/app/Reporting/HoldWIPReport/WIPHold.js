﻿define(['reportingbootstrap'],
    function (abc) {
     //   initSelect();
        initGird();
        initGird1();
        size = UtilWindowHeightWidth();
        var mydate = new Date();
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
    $('#refreshTime').html(new Date().Format('yyyy-MM-dd hh:mm:ss'));  //点击按钮后，显示当前时间
}

//默认执行class为grid和chart的自适应方法
function windowResized() {
    
}

function loadGraph(data) {

    // 基于准备好的dom，获取echarts实例
    var myChart = echarts.getInstanceByDom(document.getElementById('browserAnalysis'));
    myChart.setOption(data);
    // 基于准备好的dom，获取echarts实例
    var myChart1 = echarts.getInstanceByDom(document.getElementById('browserAnalysis1'));
    myChart1.setOption(data);
}

//初始化表格
function initGird() {
   var grid = $("#list").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
           url: '/Reporting/HoldWIPReport/QueryWIPInfo',
            colModel: [
                {
                    label: "Lot ID", name: "LOTID",  width: 130, fixed: true,
                    formatter: function (cellValue, options, rowdata, action) {                        
                        return "<a herf='javascript:(0)' onclick='showLotHistory(\"" + rowdata.LOTID + "\")' ><font color='blue'><u>" + rowdata.LOTID +"</u></blue></a>";
                    }
                },
                { label: "Area", name: "AREA", width: 130, fixed: true },
                { label: "Product Name", name: "PRODUCTNAME", width: 130, fixed: true },
                { label: "Stage Name", name: "STAGENAME",  width: 130, fixed: true },
                { label: "Pri", name: "PRIORITY",  width: 130, fixed: true },
                { label: "Qty", name: "QTY",  width: 50, fixed: true },
                { label: "Hold Time", name: "HOLDTIME", width: 130, fixed: true, cellattr: addCellAttr    },
                { label: "Last Hold Reason", name: "LASTHOLDREASON", width: 130, fixed: true },
                { label: "Last Hold User", name: "LASTHOLDUSER", width: 130, fixed: true },
                { label: "Last Step Hold Time", name: "LASTSTEPHOLDTIME", width: 130, fixed: true },
                { label: "Last Hold Time", name: "LASTHOLDTIME", width: 130, fixed: true }
            ],
            sortname: "LOTID",
            height: '370px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {
            //           loadGraph(json.ExtraDatas.Summary);
                //alert(123);
                //return false;
            }
        });

}

function showLotHistory(lotID) {
         $("#list1").jqGrid('setGridParam', { datatype: 'json' });
         var postData = $("#list1").getGridParam('postData');
        $.extend(postData, { LotID: lotID });
        $("#list1").setGridParam({ search: true }).trigger("reloadGrid", [{ page: 1 }]);
  } 

function initGird1() {
    $grid = $("#list1").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/HoldWIPReport/QueryLotDetail',
            colModel: [
                {
                    name: "SYSID", width: 130, fixed: true, hidden: true
                },
                { label: "LotID", name: "LOTID", sortable: false, width: 130, fixed: true },
                { label: "Start Hold Time", name: "STARTHOLDTIME", sortable: false, width: 130, fixed: true },
                { label: "Release Time", name: "RELEASETIME", sortable: false, width: 130, fixed: true },
                { label: "Hold User", sortable: false, name: "HOLD_USER", width: 130, fixed: true },
                { label: "Comment Code", name: "COMMENTCODE", sortable: false, width: 130, fixed: true },
                { label: "Hold Code", name: "HOLDCODE", sortable: false, width: 130, fixed: true },
                { label: "Hold Time", name: "HOLDTIME", sortable: false, width: 130, fixed: true, cellattr: addCellAttr   },
                { label: "Eqp ID", name: "LOCATION", sortable: false, width: 130, fixed: true }   ,
                { label: "QTY", name: "LOTQTYIN", sortable: false, width: 130, fixed: true }   

            ],

            pager: "pager1",
            sortname: "hr.holdtime",
            height: '250px',
            sortorder: "desc",
            additionalLoadCompleteAction: function (json) {
            }
        });
}

function addCellAttr(rowId, val, rawObject, cm, rdata) {       //Hold Time HightLight Rule Define
    if (rawObject.HOLDTIME >= 120 && (rawObject.LASTHOLDREASON == "HMOOS" || rawObject.HOLDCODE == "HMOOS") ){
        return "style='background-color:red'";
    } else {
        return "style='background-color:yellow'";
    }
}

