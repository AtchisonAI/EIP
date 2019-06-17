﻿using EIP.Common.Entities.CustomAttributes;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;

namespace HiDM.Reporting.Models
{
    public class QueryInfoInputForDueDate : QueryParam,IInputDto
    {
        public string selProductID { get; set; }

      
        public string StartTime { get; set; }

        public string EndTime { get; set; }


        public string LotType { get; set; }


        public string Bydate { get; set; }

        //[Param]
        //public string Weekly { get; set; }

        //[Param]
        //public string Daily { get; set; }
       

    }
}
