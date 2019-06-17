using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiDM.Reporting.Models.JobConfig
{
    public class RPTJOBCONFIGPARAMSOutput: EIP.Common.Entities.Dtos.IOutputDto
    {

        public string SysID { get; set; }
        public string ParamName { get; set; }

        public int ParamSequence { get; set; }
        public int ParamLength { get; set; }
        public string ParamType{ get; set; }
        public string ValueType { get; set; }
        public String ParamExpression { get; set; }
        public String Description { get; set; }

        public int RecordCount { get; set; }
    }
}
