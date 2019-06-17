define(['reportingbootstrap'],
    function (abc) {
       
        initGird();
        size = UtilWindowHeightWidth();
        if ($('#RECORD_DATE').val() !== '' ) {
            $("[name='btn_select_box']").click();
        }
    });

var $grid,
    size; //宽高


function ValidateInput() {
    if ($('#RECORD_DATE').val() == '') {
        DialogTipsMsgError('请输入日期!', 5000);
        $('#RECORD_DATE').focus();
        return false;
    }

    return true;
}

function initGird() {
    $grid = $("#list").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/WIPWaferInOut/QueryDetails',
            colModel: [
                //{
                //    name: "SYSID", width: 130, fixed: true, hidden: true
                //},
                { label: "track out time", name: "LASTTRACKOUTTIME", width: 160, fixed: true },
                { label: "activity", name: "ACTIVITY", width: 130, fixed: true },
                { label: "lot id", name: "WIPID", width: 130, fixed: true },
                { label: "by user", name: "USERID", width: 100, fixed: true },
                { label: "track out qty", name: "LOTQTYOUT", width: 100, fixed: true },
                { label: "product ID", name: "PRODUCTID", width: 130, fixed: true },
                { label: "sub plan ID", name: "SUBPLANID", width: 130, fixed: true },
                { label: "step ID", name: "STEPID", width: 130, fixed: true },
                { label: "stage", name: "STAGENAME", width: 130, fixed: true },
                { label: "resource type", name: "RESOURCETYPE", width: 130, fixed: true }
                
      
            ],
            sortname: "LASTTRACKOUTTIME",
            height: '500px',
            sortorder: "desc",
            additionalLoadCompleteAction: function (json) {
            }
        });
}
