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
using System.Globalization;
using System.Collections;
//using HiDM.Reporting.Models.EQPGroupPerformance;

namespace HiDM.Reporting.Business
{
    public class EQPGroupPerformanceLogic : IEQPGroupPerformanceLogic
    {
        private IEQPGroupPerformanceRepository _Repository;

        public EQPGroupPerformanceLogic(IEQPGroupPerformanceRepository repository)
        {
            _Repository = repository;
        }

       
        public PagedResults GetEQPGroupPerformance(EQPGroupPerformanceInput input)
        {
            input.StartTime = input.StartTime.Replace("-", "").Replace(":", "") + "000";
            input.EndTime = input.EndTime.Replace("-", "").Replace(":", "") + "000";
            var PageResults = _Repository.GetEQPGroupPerformance ( input);
            return PageResults;
        }



        public PagedResults GetEQPGroupWipDetail(EQPGroupPerformanceSubPageInput input)
        {
            var pageResults = _Repository.GetEQPGroupWipDetail(input);
            return pageResults;
        }


        public PagedResults GetEQPGroupMoveDetail(EQPGroupPerformanceSubPageInput input)
        {
            var pageResults = _Repository.GetEQPGroupMoveDetail(input);
            return pageResults;
        }

        public PagedResults GetEQPGroupWipMoveDetail(EQPGroupPerformanceSubPageInput input)
        {
            var pageResults = _Repository.GetEQPGroupWipMoveDetail(input);
            return pageResults;
        }


        public ChartOption GetEQPGroupWipMoveChart(EQPGroupPerformanceSubPageInput input)
        {
            input.StartTime = input.StartTime.Replace("-", "").Replace(":", "") + "000";
            input.EndTime = input.EndTime.Replace("-", "").Replace(":", "") + "000";
            var WipData = _Repository.QueryEQPGroupWipInfo(input);
            var MoveData = _Repository.QueryEQPGroupMoveInfo(input);
            var percentData = _Repository.QueryEQPGroupAvailInfo(input);
            string chartTitle = "EQPGroup WIP & MOVE Chart";

            string firstAxisName = "Wafer Qty";
            string secondAxisName = "EQP Avail";

            ChartOption optionSummary = WipData.ToChartOption(ChartType.Bar, chartTitle, "", "name", "Series", "value", "", ChartDirection.Vertical, "", firstAxisName);
            ChartOption addtionOption = MoveData.AddToChartOption(optionSummary, ChartType.Bar, "name", "Series", "value", "", "", firstAxisName);
            ChartOption addtionOption1 = percentData.AddToChartOption(addtionOption, ChartType.Line, "name", "Series", "value", "", "", secondAxisName);
            addtionOption1.xAxis[0].axisLabel = new AxisLabel() { interval = 0 };
            addtionOption1.yAxis[1].axisLabel = new AxisLabel() { interval = 0 };
            addtionOption1.title.x = "left";

            return addtionOption1;

        }
    }
}
