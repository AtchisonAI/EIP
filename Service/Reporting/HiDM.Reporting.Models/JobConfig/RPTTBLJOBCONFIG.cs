using System;
using System.Collections.Generic;
using EIP.Common.Entities;
using EIP.Common.Entities.CustomAttributes;
using Newtonsoft.Json;

namespace HiDM.Reporting.Models.JobConfig
{
    /// <summary>
    /// 表实体类
    /// </summary>
    [Serializable]
    [Table(Name = "RPT_TBL_JOB_CONFIG")]
    public class RPTTBLJOBCONFIG : EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        ///[Id(Name = "SYSID", Strategy = GenerationType.Indentity)]
        [Id]
        public string SYSID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String PROCEDURENAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String TRIGGER_TYPE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String CURRENT_CYCLE_JOB_STATUS_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MAX_RETRY_COUNT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SEQUENCE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IS_STOP_WHEN_FAILED { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string JOB_STATE { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        /// [Column(IsInsert = false,IsUpdate = false,IsSelect = false,IsSort = false)]
        [IgnoreColumn]
        public int RecordCount { get; set; }


        /// <summary>
        /// 作业传入参数
        /// </summary>
        [IgnoreColumn]
        public string ParametersJson { get; set; }

        private List<RPTTBLJOBCONFIGPARAMS> _Parameters;

        [IgnoreColumn]
        public List<RPTTBLJOBCONFIGPARAMS> Parameters
        {
            get
            {
                if (_Parameters == null)
                {
                    _Parameters = JsonConvert.DeserializeObject<List<RPTTBLJOBCONFIGPARAMS>>(ParametersJson);
                }
                return _Parameters;
            }
        }
    }
}