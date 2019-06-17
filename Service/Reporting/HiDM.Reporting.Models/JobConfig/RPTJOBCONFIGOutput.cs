using EIP.Common.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiDM.Reporting.Models.JobConfig
{
    public class RPTJOBCONFIGOutput: IOutputDto
    {
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
        public String LatestCircleStatus { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastestCircleStartTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? NextRunTime { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int MAX_RETRY_COUNT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? LastestCircleRetryCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? IS_STOP_WHEN_FAILED { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int SEQUENCE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string JOB_STATE { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        /// [Column(IsInsert = false,IsUpdate = false,IsSelect = false,IsSort = false)]
        public int RecordCount { get; set; }
    }
}
