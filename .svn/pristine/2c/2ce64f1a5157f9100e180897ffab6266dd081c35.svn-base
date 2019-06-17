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
using EIP.Common.Entities.ECharts;
using System.Globalization;
using System.Collections;
using HiDM.Reporting.Models.EQPStatusMonitor;

namespace HiDM.Reporting.Business
{
    public class EQPStatusMonitorLogic : IEQPStatusMonitorLogic
    {
        private IEQPStatusMonitorRepository _Repository;

        public EQPStatusMonitorLogic(IEQPStatusMonitorRepository repository)
        {
            _Repository = repository;
        }

        public EQPStatusMonitorOutput QueryEQPStatusMonitorData(EQPStatusMonitorInput input)
        {
            Dictionary<string, string> dicStatusColor = new Dictionary<string, string>();

            input.StartTime = input.StartTime.Replace("-", "").Replace(":", "")+"000";
            input.EndTime = input.EndTime.Replace("-", "").Replace(":", "") + "000";

            DataTable dt =  _Repository.QueryEQPStatusMonitorData(input);
            List<string> _EQPList = dt.AsEnumerable().Select(d => d.Field<string>("EQUIPMENTNAME")).Distinct().ToList();
            DataTable  dtStatus = dt.Distinct("STATE","COLOR");

            int index = 0;
            foreach(DataRow drStatus in dtStatus.Rows)
            {
                if (drStatus["COLOR"] == null || string.IsNullOrEmpty(drStatus["COLOR"].ToString()))
                {
                    int colorStart = (index / dtStatus.Rows.Count) * 255;
                    int colorEnd = ((index+1) / dtStatus.Rows.Count) * 255;

                    dicStatusColor.Add(drStatus["STATE"].ToString(), GetColorIndex(index));
                }
                index++;
            }

            EQPStatusMonitorOutput output = new EQPStatusMonitorOutput();
            output.StartDate = GetCurrentTicksForJs(DateTime.ParseExact(input.StartTime, "yyyyMMdd HHmmssfff", System.Globalization.CultureInfo.CurrentCulture));
            output.EndDate = GetCurrentTicksForJs(DateTime.ParseExact(input.EndTime, "yyyyMMdd HHmmssfff", System.Globalization.CultureInfo.CurrentCulture));

            output.categories = _EQPList;
            index = 0;
            foreach (var eqp in _EQPList)
            {
                var drStatuses = dt.Select("EQUIPMENTNAME = '" + eqp + "'");
                EQPStatusDetails detail = new EQPStatusDetails();

                foreach (DataRow drStatus in drStatuses)
                {
                    string status = drStatus["STATE"].ToString();
                    string parentName = drStatus["PNAME"].ToString();

                    string color = string.Empty;
                    if (drStatus["COLOR"] == null || string.IsNullOrEmpty(drStatus["COLOR"].ToString()))
                    {
                        color = dicStatusColor[status];
                    }
                    else
                    {
                        color = drStatus["COLOR"].ToString();
                    }
                    DateTime dateStart = (DateTime)drStatus["START_TIME"];
                    DateTime dateEnd = (DateTime)drStatus["END_TIME"];
                    double durationMinutes = double.Parse(drStatus["duration_mi"].ToString());
                    double durationms = double.Parse(drStatus["duration_ms"].ToString());
                    var arrList = new ArrayList();
                    arrList.Add(index);
                    arrList.Add(GetCurrentTicksForJs(dateStart));
                    arrList.Add(GetCurrentTicksForJs(dateEnd));
                    arrList.Add(durationms);
                    arrList.Add(durationMinutes);
                    arrList.Add(eqp);
                    arrList.Add(parentName);

                    output.data.Add(new EQPStatusMonitorData() { name = status,
                            value = arrList,//{ index, dateStart.ToOADate(), dateEnd.ToOADate(), durationms, durationMinutes },
                            itemStyle = new { normal = new { color = color } }
                    });

                    detail.StatusDetails.Add(new EQPStatusDetailsItem() { name = status, StartTime = dateStart.ToString("yyyy-MM-dd HH:mm:ss"), EndTime = dateEnd.ToString("yyyy-MM-dd HH:mm:ss"), value = durationMinutes });
                    detail.Colors.Add(color);
                }
                output.StatusDetails.Add(eqp, detail);
                index++;
            }
            output.StatusColor = dicStatusColor;
            return output;
        }


        public long GetCurrentTicksForJs(DateTime dtEnd)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));        
            long t = (dtEnd.Ticks - startTime.Ticks) / 10000;//除10000调整为13位
            return t;
        }


        private String GetColorIndex(int index)
        {
            List<string> ColorList = new List<string>()
            {
                "#0099FF","#9999CC",
                "#99CC33","#330066",
                "#336666","#99CC99",
                "#99FFFF","#339999",
                "#FF66FF","#FF6633",
                "#FFCC33","#CCFFFF",
                "#330000","#999966",
                "#660000","#333333",
                "#990099","#FF6600",
                "#000000","#00FFFF",
                "#006600","#FF6600",
                "#009900","#666699",
                "#333366","#6600FF",
                "#663333","#CC99CC",
                "#669966","#6699FF",
                "#996633","#33CCFF",
                "#000066","#996699",
                "#006666","#999900",
                "#0000FF","#9999FF",
                "#99FF00","#CC0000",
                "#009966","#CC0066",
                "#CC33FF","#CC9999",
                "#CCCCCC","#CCFF99",
                "#0066FF","#CCFFCC",
                "#996600","#CC0033",
                "#CC6699","#339999",
                "#003333","#663300",
                "#9900CC","#669999",
                "#33FFFF","#333300",
                "#CC6666","#6666FF"
            };

            return ColorList[index];
        }

        public PagedResults GetProcessLotList(EQPStatusProcessLotInput input)
        {
           return _Repository.GetProcessLotList(input);
        }
    }
}
