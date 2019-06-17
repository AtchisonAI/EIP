﻿using EIP.Common.Entities.CustomAttributes;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Models
{
    public class WIPStatusInput : QueryParam, IInputDto
    {
        [Param]
        public string ProductName { get; set; }

        

    }
}
