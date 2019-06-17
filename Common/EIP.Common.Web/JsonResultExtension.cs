using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EIP.Common.Web
{
    /// <summary>
    /// Json结果扩展
    /// </summary>
    public class JsonResultExtension : JsonResult
    {
        /// <summary>
        /// 自定义格式字符串:yyyy-MM-dd等
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        ///     重写执行视图
        /// </summary>
        /// <param name="context">上下文</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var response = context.HttpContext.Response;

            response.ContentType = string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data == null) return;


            if (string.IsNullOrWhiteSpace(Format))
            {
                Format = "yyyy-MM-dd HH:mm:ss";
            }

            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = Format;

            var seriesSetting = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, NullValueHandling = NullValueHandling.Ignore };
            seriesSetting.Converters.Add(timeFormat);

            var jsonString = JsonConvert.SerializeObject(Data,seriesSetting);
            const string p = @"\\/Date\((\d+)\)\\/";
            MatchEvaluator matchEvaluator = ConvertJsonDateToDateString;
            var reg = new Regex(p);
            jsonString = reg.Replace(jsonString, matchEvaluator);
            response.Write(jsonString);
        }

        /// <summary>
        ///     将Json序列化的时间由/Date(1294499956278)转为字符串 .
        /// </summary>
        /// <param name="m">正则匹配</param>
        /// <returns>格式化后的字符串</returns>
        private string ConvertJsonDateToDateString(Match m)
        {
            var dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
            dt = dt.ToLocalTime();
            var result = dt.ToString(Format);
            return result;
        }
    }
}