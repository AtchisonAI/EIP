define(['reportingbootstrap'],
    function (abc) {
        initSelect();
        initGird();
        initGird1();
        initGird2();
        initGird3();
        initGird4();
        initTabEvent();
        //initGirdAdd();
        size = UtilWindowHeightWidth();
        
    });

function ValidateInput() {
  //  alert($('#selProductID').val());
    
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
}


    var size; //宽高


    function loadGraph(data) {

        myChart.setOption(data);

    }

    //初始化表格
    function initGird() {
        $grid = $("#list").jgridview(
            {
                datatype: "local",
                multiselect: false,
                loadonce: false,
                shrinkToFit: true,
                url: '/Reporting/ProductIndices/QueryInfo',
                colModel: [
                    { label: "Date", name: "RECORD_DATE", width: 130, fixed: true },
                    { label: "Lottype", name: "LOTTYPE", width: 100, fixed: true },
                    { label: "BOH", name: "BOH", width: 100, fixed: true },
                    { label: "EOH", name: "EOH", width: 100, fixed: true },
                    { label: "Move(Lot)", name: "MOVELOTQTY", width: 100, fixed: true },
                    { label: "Move(Wafer)", name: "MOVEWAFERQTY", width: 100, fixed: true },
                    {
                        label: "Start", name: "WAFERSTARTQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                            return "<a herf='javascript:(0)' onclick='showStartDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.WAFERSTARTQTY + "</u></blue></a>";
                        }
                    },
                    { label: "Out", name: "SHIPQTY", width: 100, fixed: true },
                    { label: "Unship", name: "UNSHIPQTY", width: 100, fixed: true },
                    { label: "BankIn", name: "BANKINQTY", width: 100, fixed: true },
                    { label: "BankOut", name: "BANKOUTQTY", width: 100, fixed: true },
                    {
                        label: "Scrap", name: "SCRAPQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                            return "<a herf='javascript:(0)' onclick='showScrapDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.SCRAPQTY + "</u></blue></a>";
                        }
                    },
                    {
                        label: "UnScrap", name: "UNSCRAPQTY", width: 100, fixed: true, formatter: function(cellValue, options, rowdata, action) {
                            return "<a herf='javascript:(0)' onclick='showUnscrapDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.UNSCRAPQTY + "</u></blue></a>";
                        }
                    },
                    { label: "Yield", name: "YIELD", width: 100, fixed: true },
                    {
                        label: "Hold", name: "HOLDQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                            return "<a herf='javascript:(0)' onclick='showHoldDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.HOLDQTY + "</u></blue></a>";
                        }
                    },
                    {
                        label: "Rework", name: "REWORKQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                            return "<a herf='javascript:(0)' onclick='showReworkDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.REWORKQTY + "</u></blue></a>";
                        }
                    }
            
                ],
                sortname: "RECORD_DATE",
                height: '740px',
                sortorder: "asc",
                additionalLoadCompleteAction: function (json) {

                }
            });
    }

    function initGird1() {
        $grid = $("#list1").jgridview(
            {
                datatype: "local",
                multiselect: false,
                loadonce: false,
                shrinkToFit: true,
                url: '/Reporting/ProductIndices/QueryInfo1',
                colModel: [
                    { label: "Date", name: "RECORD_DATE", width: 130, fixed: true },
                    { label: "Lottype", name: "LOTTYPE", width: 100, fixed: true },
                    { label: "BOH", name: "BOH", width: 100, fixed: true },
                    { label: "EOH", name: "EOH", width: 100, fixed: true },
                    { label: "Move(Lot)", name: "MOVELOTQTY", width: 100, fixed: true },
                    { label: "Move(Wafer)", name: "MOVEWAFERQTY", width: 100, fixed: true },
                    {
                        label: "Start", name: "WAFERSTARTQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                            return "<a herf='javascript:(0)' onclick='showStartDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.WAFERSTARTQTY + "</u></blue></a>";
                        }
                    },
                    { label: "Out", name: "SHIPQTY", width: 100, fixed: true },
                    { label: "Unship", name: "UNSHIPQTY", width: 100, fixed: true },
                    { label: "BankIn", name: "BANKINQTY", width: 100, fixed: true },
                    { label: "BankOut", name: "BANKOUTQTY", width: 100, fixed: true },
                    {
                        label: "Scrap", name: "SCRAPQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                            return "<a herf='javascript:(0)' onclick='showScrapDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.SCRAPQTY + "</u></blue></a>";
                        }
                    },
                    {
                        label: "UnScrap", name: "UNSCRAPQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                            return "<a herf='javascript:(0)' onclick='showUnscrapDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.UNSCRAPQTY + "</u></blue></a>";
                        }
                    },
                    { label: "Yield", name: "YIELD", width: 100, fixed: true },
                    {
                        label: "Hold", name: "HOLDQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                            return "<a herf='javascript:(0)' onclick='showHoldDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.HOLDQTY + "</u></blue></a>";
                        }
                    },
                    {
                        label: "Rework", name: "REWORKQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                            return "<a herf='javascript:(0)' onclick='showReworkDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.REWORKQTY + "</u></blue></a>";
                        }
                    }

                ],
                sortname: "RECORD_DATE",
                height: '740px',
                sortorder: "asc",
                additionalLoadCompleteAction: function (json) {

                }
            });
    }

function initGird2() {
    $grid = $("#list2").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/ProductIndices/QueryInfo2',
            colModel: [
                { label: "Date", name: "RECORD_DATE", width: 130, fixed: true },
                { label: "Lottype", name: "LOTTYPE", width: 100, fixed: true },
                { label: "BOH", name: "BOH", width: 100, fixed: true },
                { label: "EOH", name: "EOH", width: 100, fixed: true },
                { label: "Move(Lot)", name: "MOVELOTQTY", width: 100, fixed: true },
                { label: "Move(Wafer)", name: "MOVEWAFERQTY", width: 100, fixed: true },
                {
                    label: "Start", name: "WAFERSTARTQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showStartDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.WAFERSTARTQTY + "</u></blue></a>";
                    }
                },
                { label: "Out", name: "SHIPQTY", width: 100, fixed: true },
                { label: "Unship", name: "UNSHIPQTY", width: 100, fixed: true },
                { label: "BankIn", name: "BANKINQTY", width: 100, fixed: true },
                { label: "BankOut", name: "BANKOUTQTY", width: 100, fixed: true },
                {
                    label: "Scrap", name: "SCRAPQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showScrapDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.SCRAPQTY + "</u></blue></a>";
                    }
                },
                {
                    label: "UnScrap", name: "UNSCRAPQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showUnscrapDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.UNSCRAPQTY + "</u></blue></a>";
                    }
                },
                { label: "Yield", name: "YIELD", width: 100, fixed: true },
                {
                    label: "Hold", name: "HOLDQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showHoldDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.HOLDQTY + "</u></blue></a>";
                    }
                },
                {
                    label: "Rework", name: "REWORKQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showReworkDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.REWORKQTY + "</u></blue></a>";
                    }
                }

            ],
            sortname: "RECORD_DATE",
            height: '740px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {

            }
        });
}

function initGird3() {
    $grid = $("#list3").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/ProductIndices/QueryInfo3',
            colModel: [
                { label: "Date", name: "RECORD_DATE", width: 130, fixed: true },
                { label: "Lottype", name: "LOTTYPE", width: 100, fixed: true },
                { label: "BOH", name: "BOH", width: 100, fixed: true },
                { label: "EOH", name: "EOH", width: 100, fixed: true },
                { label: "Move(Lot)", name: "MOVELOTQTY", width: 100, fixed: true },
                { label: "Move(Wafer)", name: "MOVEWAFERQTY", width: 100, fixed: true },
                {
                    label: "Start", name: "WAFERSTARTQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showStartDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.WAFERSTARTQTY + "</u></blue></a>";
                    }
                },
                { label: "Out", name: "SHIPQTY", width: 100, fixed: true },
                { label: "Unship", name: "UNSHIPQTY", width: 100, fixed: true },
                { label: "BankIn", name: "BANKINQTY", width: 100, fixed: true },
                { label: "BankOut", name: "BANKOUTQTY", width: 100, fixed: true },
                {
                    label: "Scrap", name: "SCRAPQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showScrapDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.SCRAPQTY + "</u></blue></a>";
                    }
                },
                {
                    label: "UnScrap", name: "UNSCRAPQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showUnscrapDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.UNSCRAPQTY + "</u></blue></a>";
                    }
                },
                { label: "Yield", name: "YIELD", width: 100, fixed: true },
                {
                    label: "Hold", name: "HOLDQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showHoldDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.HOLDQTY + "</u></blue></a>";
                    }
                },
                {
                    label: "Rework", name: "REWORKQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showReworkDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.REWORKQTY + "</u></blue></a>";
                    }
                }

            ],
            sortname: "RECORD_DATE",
            height: '740px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {

            }
        });
}

function initGird4() {
    $grid = $("#list4").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/ProductIndices/QueryInfo4',
            colModel: [
                { label: "Date", name: "RECORD_DATE", width: 130, fixed: true },
                { label: "Lottype", name: "LOTTYPE", width: 100, fixed: true },
                { label: "BOH", name: "BOH", width: 100, fixed: true },
                { label: "EOH", name: "EOH", width: 100, fixed: true },
                { label: "Move(Lot)", name: "MOVELOTQTY", width: 100, fixed: true },
                { label: "Move(Wafer)", name: "MOVEWAFERQTY", width: 100, fixed: true },
                {
                    label: "Start", name: "WAFERSTARTQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showStartDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.WAFERSTARTQTY + "</u></blue></a>";
                    }
                },
                { label: "Out", name: "SHIPQTY", width: 100, fixed: true },
                { label: "Unship", name: "UNSHIPQTY", width: 100, fixed: true },
                { label: "BankIn", name: "BANKINQTY", width: 100, fixed: true },
                { label: "BankOut", name: "BANKOUTQTY", width: 100, fixed: true },
                {
                    label: "Scrap", name: "SCRAPQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showScrapDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.SCRAPQTY + "</u></blue></a>";
                    }
                },
                {
                    label: "UnScrap", name: "UNSCRAPQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showUnscrapDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.UNSCRAPQTY + "</u></blue></a>";
                    }
                },
                { label: "Yield", name: "YIELD", width: 100, fixed: true },
                {
                    label: "Hold", name: "HOLDQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showHoldDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.HOLDQTY + "</u></blue></a>";
                    }
                },
                {
                    label: "Rework", name: "REWORKQTY", width: 100, fixed: true, formatter: function (cellValue, options, rowdata, action) {
                        return "<a herf='javascript:(0)' onclick='showReworkDetails(\"" + rowdata.RECORD_DATE + "\",\"" + rowdata.LOTTYPE + "\")' ><font color='blue'><u>" + rowdata.REWORKQTY + "</u></blue></a>";
                    }
                }

            ],
            sortname: "RECORD_DATE",
            height: '740px',
            sortorder: "asc",
            additionalLoadCompleteAction: function (json) {

            }
        });
}


//Start Detail
function showStartDetails(RECORD_DATE,PART) {
    ArtDialogOpen("/Reporting/ProductIndices/StartDetails?date=" + RECORD_DATE + "&type=LotStart" + "&Part=" + PART, "StartDetails-" + RECORD_DATE, true, 750, 1200, true);
}

//Scrap Detail
function showScrapDetails(RECORD_DATE, PART) {
    ArtDialogOpen("/Reporting/ProductIndices/ScrapDetails?date=" + RECORD_DATE + "&type=Scrap" + "&Part=" + PART, "ScrapDetails-" + RECORD_DATE, true, 750, 1200, true);
}

//Unscrap Detail
function showUnscrapDetails(RECORD_DATE, PART) {
    ArtDialogOpen("/Reporting/ProductIndices/UnscrapDetails?date=" + RECORD_DATE + "&type=Unscrap" + "&Part=" + PART, "UnscrapDetails-" + RECORD_DATE, true, 750, 1200, true);
}

//Hold Detail
function showHoldDetails(RECORD_DATE, PART) {
    ArtDialogOpen("/Reporting/ProductIndices/HoldDetails?date=" + RECORD_DATE + "&type=Hold" + "&Part=" + PART, "ScrapDetails-" + RECORD_DATE, true, 750, 1200, true);
}

//Rework Detail
function showReworkDetails(RECORD_DATE, PART) {
    ArtDialogOpen("/Reporting/ProductIndices/ReworkDetails?date=" + RECORD_DATE + "&type=Rework" + "&Part=" + PART, "ScrapDetails-" + RECORD_DATE, true, 750, 1200, true);
}




function initTabEvent() {
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        var activeTabName = $(e.target).attr('href');
        var activeGrid;
        if (activeTabName === '#home') {
            activeGrid = $('#list');
        }
        else if (activeTabName === '#page1') {
            activeGrid = $('#list1');
        }
        else if (activeTabName === '#page2') {
            activeGrid = $('#list2');
        }
        else if (activeTabName === '#page3') {
            activeGrid = $('#list3');
        }
        else if (activeTabName === '#page4') {
            activeGrid = $('#list4');
        }
          
        activeGrid.setGridWidth(activeGrid.parents('.ui-jqgrid').parent().width());

        //ShowDetails();
    });
}