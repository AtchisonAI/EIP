using EIP.Common.Entities.CustomAttributes;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiDM.Reporting.Models
{
    public class DetailInput : QueryParam, IInputDto
    {

        [Param]
        public string LotID { get; set; }


    }
}
