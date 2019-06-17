using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.DataAccess;
using EIP.Common.Entities.Paging;
using HiDM.FactoryWorks.TibcoRV;
using HiDM.Reporting.Models;
using HiDM.FactoryWorks.Messages;
using EIP.Common.Entities.ECharts;
using EIP.Common.Entities;
using System.Data;

namespace HiDM.Reporting.Business
{
    public class WIPWaferInOutRptLogic : IWIPWaferInOutRptLogic
    {
        private IWIPWaferInOutRptRepository _WIPWaferInOutRptRepository;

        public WIPWaferInOutRptLogic(IWIPWaferInOutRptRepository WIPWaferInOutRptRepository)
        {
            _WIPWaferInOutRptRepository = WIPWaferInOutRptRepository;
        }


        public ChartOption GetMonInOutInfo(WIPWaferInOutInput input)
        {

            var summaryData = _WIPWaferInOutRptRepository.QueryMonInWaferInfo(input);
            var percentData = _WIPWaferInOutRptRepository.QueryMonOutWaferInfo(input);
            string chartTitle = "Fab In & Fab Out Chart( " + input.sMonthStart + " -" + input.sMonthEnd + " )";

            string firstAxisName = "Fab In";
            string secondAxisName = "Fab Out";

            ChartOption optionSummary = summaryData.ToChartOption(ChartType.Bar, chartTitle, "", "name", "Series", "value", "",ChartDirection.Vertical, "", firstAxisName);
            ChartOption addtionOption = percentData.AddToChartOption(optionSummary, ChartType.Bar, "name", "Series", "value", "", "", firstAxisName);
            addtionOption.xAxis[0].axisLabel = new AxisLabel() { interval = 0 };
            //addtionOption.yAxis[1].axisLabel = new AxisLabel() { interval = 0 };
           addtionOption.title.x = "left";

            return addtionOption;

        }


        public ChartOption GetMTDInOutInfo(WIPWaferInOutInput input)
        {

            var summaryData = _WIPWaferInOutRptRepository.QueryMTDInWaferInfo(input);
            var percentData = _WIPWaferInOutRptRepository.QueryMTDOutWaferInfo(input);
            string chartTitle = "Fab In & Fab Out Chart( " + input.sMTD + " )";

            string firstAxisName = "Fab In";
            string secondAxisName = "Fab Out";

            ChartOption optionSummary = summaryData.ToChartOption(ChartType.Bar, chartTitle, "", "name", "Series", "value", "", ChartDirection.Vertical, "", firstAxisName);
            ChartOption addtionOption = percentData.AddToChartOption(optionSummary, ChartType.Bar, "name", "Series", "value", "", "", firstAxisName);
            addtionOption.xAxis[0].axisLabel = new AxisLabel() { interval = 0, rotate=40 };
            addtionOption.title.x = "left";

            return addtionOption;

        }

        public PagedResults QueryInfo(WaferInOutDetailsInput InfoInput)
        {

            var pageResults = _WIPWaferInOutRptRepository.GetQueryInfoList(InfoInput);
            return pageResults;

        }

    }
}
