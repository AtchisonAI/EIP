using EIP.Common.Entities.CustomAttributes;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Models
{
    public class WaferInOutDetailsInput : QueryParam, IInputDto
    {


        public string RECORD_DATE { get; set; }


        public string INOUTTYPE { get; set; }


        //public string sMonthEnd { get; set; }


        //[Param]
        //public string Weekly { get; set; }

        //[Param]
        //public string Daily { get; set; }

    }
}
