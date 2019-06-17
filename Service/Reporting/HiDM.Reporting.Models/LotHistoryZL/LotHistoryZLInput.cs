﻿using EIP.Common.Entities.CustomAttributes;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Models
{
    public class LotHistoryZLInput : QueryParam, IInputDto
    {
        [Param]
        public string LOTID { get; set; }

    }
}
