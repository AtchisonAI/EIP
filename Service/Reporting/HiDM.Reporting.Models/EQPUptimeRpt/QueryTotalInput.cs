using EIP.Common.Entities.CustomAttributes;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Models
{
    public class QueryTotalInput : QueryParam,IInputDto
    {

        
        public string YearDate { get; set; }

       
        public string StateGrp { get; set; }

      
        public string EqpID { get; set; }


        //[Param]
        //public string Weekly { get; set; }

        //[Param]
        //public string Daily { get; set; }

    }
}
