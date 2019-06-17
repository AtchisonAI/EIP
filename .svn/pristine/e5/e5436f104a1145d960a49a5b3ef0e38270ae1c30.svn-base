var echarts, $, jQuery;
define([
    'echarts',
    'jquery',
    'select2zhcn',
    'bootstrap',
    'jqgrid',
    'jgridview',
    'reportingListview',
    'language',
    'solutionFun',
    'artdialog',
    'artdialogIframeTools',
    'wdatepicker'],
    function (echarts) {
        jQuery = this.$;
        //this.echarts = echarts;
        this.echarts = echarts;
        $('body').css('overflow', 'scroll');
        $.fn.select2.defaults.set("theme", "bootstrap");

        initOnDocumentReady();
        $(window).resize(function () {


            if (typeof $charts != 'undefined' && $charts.length >0) {
                $charts.each(function () {
                    var chart = echarts.getInstanceByDom(document.getElementById($(this).attr('id')));
                    chart.resize();
                });
            }


            if (typeof $grids != 'undefined' && $grids.length >0) {
                $grids.each(function () {
                    $(this).setGridWidth($(this).parents('.ui-jqgrid').parent().width());
                });
            }

            if (typeof windowResized !== 'undefined' && windowResized instanceof Function) {
                windowResized();
            }
        });

    });
