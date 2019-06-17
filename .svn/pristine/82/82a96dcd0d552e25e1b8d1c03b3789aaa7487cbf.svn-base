using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EIP.Common.Entities.ECharts
{
    public static class DataTableExtensions
    {
        /// <summary>
        /// 将DataTable转换为EChart Option
        /// </summary>
        /// <param name="dtData">DataTable</param>
        /// <param name="chartType">Chart 类型：line,bar,pie</param>
        /// <param name="Title">Chart Title</param>
        /// <param name="subTitle">Chart Sub Title</param>
        /// <param name="columnAxis">DataTable中用于作为坐标轴的列名</param>
        /// <param name="columnSeries">DataTable中用于作为Series的列名</param>
        /// <param name="columnValue">DataTable中用于作为值的列名</param>
        /// <param name="stackName">Stack名</param>
        /// <param name="chartDirection">Chart 方向</param>
        /// <param name="xAxisName">X轴名</param>
        /// <param name="xAxisName">Y轴名</param>
        /// <returns></returns>
        public static ChartOption ToChartOption(this DataTable dtData, ChartType chartType, string Title, string subTitle, string columnAxis, string columnSeries, string columnValue, string stackName, ChartDirection chartDirection, string xAxisName = "", string yAxisName = "")
        {
            ChartOption option = new ChartOption();
            if (string.IsNullOrWhiteSpace(Title) == false)
                option.title = new Title() { text = Title, subtext = subTitle };
            option.ChartDirection = chartDirection;
            option.tooltip = new ToolTip();
            option.legend = new Legend();
            if (chartType == ChartType.Pie)
            {
                option.tooltip.trigger = "item";
            }
            else
            {

                option.tooltip.formatter = null;
            }

            option.toolbox = new ToolBox();
            dtData.AddToChartOption(option, chartType, columnAxis, columnSeries, columnValue, stackName, xAxisName, yAxisName);
            return option;

        }

        /// <summary>
        /// 将DataTable添加到已有EChart Option中
        /// </summary>
        /// <param name="dtData">DataTable</param>
        /// <param name="chartType">Chart 类型：line,bar,pie</param>
        /// <param name="columnAxis">DataTable中用于作为坐标轴的列名</param>
        /// <param name="columnSeries">DataTable中用于作为Series的列名</param>
        /// <param name="columnValue">DataTable中用于作为值的列名</param>
        /// <param name="stackName">Stack名</param>
        /// <param name="xAxisName">X轴名</param>
        /// <param name="xAxisName">Y轴名</param>
        /// <returns></returns>
        public static ChartOption AddToChartOption(this DataTable dtData, ChartOption option, ChartType chartType, string columnAxis, string columnSeries, string columnValue, string stackName, string xAxisName = "", string yAxisName = "")
        {
            DataTable dtAxis = dtData.Distinct(columnAxis);
            DataTable dtSeries = dtData.Distinct(columnSeries);

            List<string> lstAxis = new List<string>();
            List<Series> lstSeries = new List<Series>();
            List<object> lstData = new List<object>();

            int xAxisIndex = 0;
            int yAxisIndex = 0;

            xAxisIndex = option.xAxis.FindIndex(p => p.name == xAxisName);
            xAxisIndex = xAxisIndex == -1 ? option.xAxis.Count : xAxisIndex;


            yAxisIndex = option.yAxis.FindIndex(p => p.name == yAxisName);
            yAxisIndex = yAxisIndex == -1 ? option.yAxis.Count : yAxisIndex;


            //Add New Series
            foreach (DataRow drSeies in dtSeries.Rows)
            {
                Series series = null;
                switch (chartType)
                {
                    case ChartType.Line:
                        if (option.ChartDirection == ChartDirection.Horizontal)
                        {
                            series = new LineSeries() { name = drSeies[0].ToString(), xAxisIndex = xAxisIndex };
                        }
                        else
                        {
                            series = new LineSeries() { name = drSeies[0].ToString(), yAxisIndex = yAxisIndex };
                        }
                        break;
                    case ChartType.Bar:
                        if (option.ChartDirection == ChartDirection.Horizontal)
                        {
                            series = new BarSeries() { name = drSeies[0].ToString(), xAxisIndex = xAxisIndex };
                        }
                        else
                        {
                            series = new BarSeries() { name = drSeies[0].ToString(), yAxisIndex = yAxisIndex };
                        }
                        break;
                    case ChartType.Pie:
                        series = new PieSeries() { name = drSeies[0].ToString() };
                        break;
                    default:
                        series = new Series() { name = drSeies[0].ToString() };
                        break;
                }
                series.data = new List<object>();
                if (string.IsNullOrWhiteSpace(stackName) == false)
                {
                    series.stack = stackName;
                }

                lstSeries.Add(series);

                foreach (DataRow drAxis in dtAxis.Rows)
                {
                    string axis = drAxis[0].ToString();
                    if (lstAxis.Contains(axis) == false)
                        lstAxis.Add(axis);
                    DataRow[] drData = dtData.Select(string.Format("{0}='{1}' AND {2} = '{3}'", columnAxis, axis, columnSeries, series.name));
                    if (drData.Length == 0)
                    {
                        if (chartType == ChartType.Pie)
                            series.data.Add(new { name = axis, value = 0 });
                        else
                            series.data.Add(0);
                    }
                    else
                    {
                        if (chartType == ChartType.Pie)
                            series.data.Add(new { name = axis, value = drData[0][columnValue] });
                        else
                        {
                            series.data.Add(drData[0][columnValue]);
                        }    
                    }
                }
            }

            if (chartType != ChartType.Pie)
            {
                InitOptionAxisFrame(ref option, xAxisName, yAxisName, lstAxis.Cast<object>().ToList());
            }

            if (option.series == null)
            {
                option.series = new List<Series>();
            }

            option.series.AddRange(lstSeries);
            return option;
        }

        public static DataTable Distinct(this DataTable dtData, params string[] columns)
        {
            DataView dataView = dtData.DefaultView;

            DataTable dataTableDistinct = dataView.ToTable(true, columns);
            return dataTableDistinct;
        }

        private static void InitOptionAxisFrame(ref ChartOption option,string xAxisName, string yAxisName , List<object> lstAxis)
        {
            if (option.ChartDirection == ChartDirection.Horizontal)
            {
                if (option.yAxis.Count == 0)
                {
                    option.yAxis.Add(new Axis() { type = "category", name = yAxisName , data = lstAxis });
                }

                if (option.xAxis.Count == 0)
                {
                    //first yAxis
                    option.xAxis.Add(new Axis() { type = "value", name = xAxisName });
                }
                else
                {
                    if (option.xAxis.Where(p => p.name == xAxisName).Count() == 0)
                    {
                        //second yAxis
                        option.xAxis.Add(new Axis() { type = "value", name = xAxisName, splitLine = new SplitLine() { show = false } });
                        if (option.xAxis.Count > 2)
                        {
                            throw new Exception("Count of Axis must be less than 2!");
                        }
                    }
                }
            }
            else
            {
                if (option.xAxis.Count == 0)
                {
                    option.xAxis.Add(new Axis() { type = "category", name = xAxisName, data = lstAxis });
                }
                if (option.yAxis.Count == 0)
                {
                    //first yAxis
                    option.yAxis.Add(new Axis() { type = "value", name = yAxisName });
                }
                else
                {
                    if (option.yAxis.Where(p => p.name == yAxisName).Count() == 0)
                    {
                        //second yAxis
                        option.yAxis.Add( new Axis() { type = "value", name = yAxisName, splitLine = new SplitLine() { show = false } });

                        if (option.yAxis.Count > 2)
                        {
                            throw new Exception("Count of Axis must be less than 2!");
                        }
                    }
                }
            }
        }


        private static int AlignAxisMaxValue(double seriesMaxValue,int splitNum)
        {
            int alignedMaxValue = (int)seriesMaxValue;
            if (0 < seriesMaxValue % splitNum)
            {
                alignedMaxValue = ((int)seriesMaxValue / splitNum + 1) * splitNum;
            }
            return alignedMaxValue;
        }


        private static void InitOptionAxisData(ref ChartOption option, List<object> lstAxis)
        {
            if (option.ChartDirection == ChartDirection.Horizontal)
            {
                option.yAxis[0].data = lstAxis;
                option.yAxis[0].data.AddRange(lstAxis);
                option.yAxis[0].data = option.yAxis[0].data.Distinct().ToList();
            }
            else
            {
                option.xAxis[0].data = lstAxis;
                option.xAxis[0].data.AddRange(lstAxis);
                option.xAxis[0].data = option.xAxis[0].data.Distinct().ToList();
            }

        }
    }
      

    public enum ChartType
    {
        Line,
        Bar,
        Pie
    }

    public enum ChartDirection{
        Vertical,
        Horizontal
    }
}
