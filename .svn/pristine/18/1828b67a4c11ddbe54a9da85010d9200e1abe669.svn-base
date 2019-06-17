using EIP.Common.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiDM.Reporting.DataAccess;
using EIP.Common.Entities.ECharts;
using System.Data;

namespace HiDM.Reporting.Business.EmployInfo
{
    public class EmployInfoLogic : IEmployInfoLogic
    {
        private IEmployInfoRepository iEmployInfoRepository;

        public EmployInfoLogic(IEmployInfoRepository employInfoRepository)
        {
            iEmployInfoRepository = employInfoRepository;
        }

        public async Task<PagedResults> QueryEmployListAsync(Models.QueryEmployInfoInput input)
        {
            var pageResults = await iEmployInfoRepository.GetEmployListAsync(input);
            pageResults.ExtraDatas.Add("Summary", await iEmployInfoRepository.GetEmploySummaryAsync(input));

            return pageResults;
        }

        public PagedResults QueryEmployListSync(Models.QueryEmployInfoInput input)
        {
            var pageResults = iEmployInfoRepository.GetEmployListSync(input);
            var summaryData = iEmployInfoRepository.GetEmploySummarySync(input);
            var summaryDataList = iEmployInfoRepository.GetEmploySummaryListSync(input);

            ChartOption optionPie = summaryData.ToChartOption(ChartType.Pie, "", "", "name", "Series", "value", "EmployEE", ChartDirection.Vertical);
            pageResults.ExtraDatas.Add("SummaryPie", optionPie);

            ChartOption optionBar = summaryDataList[0].ToChartOption(ChartType.Bar, "", "", "name", "Series", "value", "EmployEE", ChartDirection.Vertical);

            ChartOption addtionOption;
            for (int i=1;i<summaryDataList.Length; ++i)
            {
                addtionOption = summaryDataList[i].AddToChartOption(optionBar, ChartType.Line, "name", "Series", "value", " ");
                pageResults.ExtraDatas.Add("SummaryBar", addtionOption);
            }

            ChartOption optionLine = summaryData.ToChartOption(ChartType.Line, "", "", "name", "Series", "value", "EmployEE", ChartDirection.Vertical);
            pageResults.ExtraDatas.Add("SummaryLine", optionLine);

            return pageResults;
        }
    }
}