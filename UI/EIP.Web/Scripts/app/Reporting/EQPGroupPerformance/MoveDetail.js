define(['reportingbootstrap'],
    function (abc) {

        initGird();
        size = UtilWindowHeightWidth();
        if ($('#RECORD_DATE').val() !== '') {
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
            url: '/Reporting/EQPGroupPerformance/GetEQPGroupMoveDetail',
            colModel: [
                //{
                //    name: "SYSID", width: 130, fixed: true, hidden: true
                //},
                
                { label: "Lotid", name: "LOTID", index: "HS.WIPID", width: 120, fixed: true },
                { label: "Productid", name: "PRODUCTID", index: "l.productname || '.' || l.productrevision", width: 120, fixed: true },
                { label: "Priority", name: "PRIORITY", index: "L.PRIORITY", width: 120, fixed: true },
                { label: "QTY", name: "MOVEWAFERQTY", index: "decode(hs.activity, 'JobOut', hs.lotqtyout, 0)", width: 120, fixed: true },
                { label: "Lot Type", name: "LOTTYPE", index: "L.LOTTYPE", width: 120, fixed: true },
                { label: "Stage", name: "STAGENAME", index: "WS.STAGENAME", width: 120, fixed: true },
                { label: "Area", name: "AREA", index: "SVP.VALDATA", width: 120, fixed: true },
                { label: "Capability", name: "CAPABILITY", index: "SVN.REQUIREDCAPABILITY", width: 120, fixed: true },
                { label: "Eqptype", name: "EQPTYPE", index: "SV.RESOURCETYPE", width: 120, fixed: true },
                { label: "Eqpid", name: "EQPID", index: "WS.LOCATION", width: 120, fixed: true },
                { label: "Recipename", name: "RECIPENAME", index: "FLE.RECIPENAME", width: 120, fixed: true },
                { label: "ArriveTime", name: "ARRIVETIME", index: "WS.TIMEHERESINCE", width: 120, fixed: true },
                { label: "TrackIn Time", name: "TRACKINTIME", index: "WS.TRACKINTIME", width: 130, fixed: true },
                { label: "TrackOut Time", name: "TRACKOUTTIME", index: "WS.TRACKOUTTIME", width: 120, fixed: true },
                { label: "TrackIn User", name: "TRACKINUSER", index: "WS.TRACKINUSER", width: 130, fixed: true },
                { label: "TrackOut User", name: "TRACKOUTUSER", index: "WS.TRACKOUTUSER", width: 120, fixed: true },
                { label: "Rtime(Min)", name: "RTIME", width: 120, fixed: true },
                { label: "Htime(Min)", name: "HTIME", width: 120, fixed: true },
                { label: "Qtime(Min)", name: "QTIME", width: 120, fixed: true }
                
                
            ],
            sortname: "hs.wipid",

            height: '500px',
            sortorder: "desc",
            additionalLoadCompleteAction: function (json) {
            }
        });
}
