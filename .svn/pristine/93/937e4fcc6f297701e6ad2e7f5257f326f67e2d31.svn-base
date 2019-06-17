define(['reportingbootstrap'],
    function (abc) {
        initGird();
        size = UtilWindowHeightWidth();
        if ($('#lotid').val() !== '') {
            $("[name='btn_select_box']").click();
        }
    });

var $grid,
    size; //宽高


function ValidateInput() {
    if ($('#lotid').val() == '') {
        DialogTipsMsgError('请输入Lot ID!', 5000);
        $('#lotid').focus();
        return false;
    }
    return true;
}

//初始化表格
function initGird() {
    $grid = $("#list").jgridview(
        {
            datatype: "local",
            multiselect: false,
            loadonce: false,
            shrinkToFit: true,
            url: '/Reporting/WIPProfile/QueryLotForecast',
            colModel: [
                {
                   name: "SYSID", width: 130, fixed: true,hidden:true
                },
                { label: "Activity", name: "ACTIVITY",sortable:false, width: 130, fixed: true },
                { label: "Txn Time", name: "TXNTIMESTAMP", sortable: false,  width: 130, fixed: true },
                { label: "Step ID", name: "STEPID", sortable: false,  width: 130, fixed: true },
                { label: "Step Description", sortable: false, name: "DESCRIPTION",  width: 130, fixed: true },
                { label: "Step Seq", name: "HANDLE", sortable: false, width: 50, fixed: true },
                { label: "Qty", name: "LOTQUANTITY", sortable: false,  width: 130, fixed: true },
                { label: "EQP Type", name: "RESOURCETYPE", sortable: false, width: 130, fixed: true },
                { label: "Equipment", name: "EQUIPMENT", sortable: false, width: 130, fixed: true },
                { label: "Txn User", name: "USERID", sortable: false, width: 130, fixed: true },
                { label: "Lot Type", name: "LOTTYPE", sortable: false, width: 130, fixed: true },
                { label: "Process Plan", name: "PLANID", sortable: false, width: 130, fixed: true },
                { label: "Sub Plan", name: "SUBPLANID", sortable: false, width: 130, fixed: true },
                { label: "Product", name: "PRODUCTID", sortable: false, width: 130, fixed: true },
                { label: "Area", name: "AREA", sortable: false, width: 130, fixed: true },
                { label: "Tunnel ID", name: "TUNNELID", sortable: false, width: 130, fixed: true },
                { label: "Recipe ID", name: "RECIPEID", sortable: false, width: 130, fixed: true },
                { label: "EDC Plan", name: "EDCPLANID", sortable: false, width: 130, fixed: true },
                { label: "Comments", name: "BRIEFDESCRIPTION", sortable: false, width: 130, fixed: true }
            ],
            sortname: "W.txnTimeStamp",
            height: '500px',
            sortorder: "desc",
            additionalLoadCompleteAction: function (json) {
            }
        });
}

