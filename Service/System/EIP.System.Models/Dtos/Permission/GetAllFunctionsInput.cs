﻿using EIP.Common.Entities.Dtos;
namespace EIP.System.Models.Dtos.Permission
{
    public class GetAllFunctionsInput : NullableIdInput
    {
        /// <summary>
        /// 是否为界面
        /// </summary>
        public bool IsPage { get; set; }
    }
}