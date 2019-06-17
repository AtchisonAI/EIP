﻿using EIP.Common.Entities.CustomAttributes;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Models
{
    public class LotHoldInfoInput : QueryParam,IInputDto
    {
        [Param]
        public string LotID { get; set; }

        [Param]
        public string HoldToDept { get; set; }


    }
}
