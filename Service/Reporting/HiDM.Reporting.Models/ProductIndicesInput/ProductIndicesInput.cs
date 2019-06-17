using EIP.Common.Entities.CustomAttributes;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Models
{
    public class ProductIndicesInput : QueryParam,IInputDto
    {
        [Param]
        public string StartTime { get; set; }

        [Param]
        public string EndTime { get; set; }

       
       

    }
}
