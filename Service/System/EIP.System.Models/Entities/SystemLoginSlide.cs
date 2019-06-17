using System;
using EIP.Common.Entities;
using EIP.Common.Entities.CustomAttributes;

namespace EIP.System.Models.Entities
{
    /// <summary>
    /// ��¼�õ�Ƭ��ʵ����
    /// </summary>
    [Serializable]
    [Table(Name = "System_LoginSlide")]
    public class SystemLoginSlide : EntityBase
    {
        /// <summary>
        /// ����
        /// </summary>
        [Id]
        public Guid LoginSlideId { get; set; }

        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public bool IsFreeze { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        public int OrderNo { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark { get; set; }


    }
}