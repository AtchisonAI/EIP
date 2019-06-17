using System;
using EIP.Common.Entities;
using EIP.Common.Entities.CustomAttributes;

namespace EIP.System.Models.Entities
{
    /// <summary>
    /// Gantt_Dependencie��ʵ����
    /// </summary>
    [Serializable]
    [Table(Name = "Gantt_Dependencie")]
    public class GanttDependencie : EntityBase
    {
        /// <summary>
        /// ����
        /// </summary>
        [Id(true)]
        public Guid Id { get; set; }

        /// <summary>
        /// ǰ�������ID
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// �����ID
        /// </summary>
        public int To { get; set; }

        /// <summary>
        /// ���������֮��Ŀ��������ֹ�ϵ�����-���(FF) 0�����-��ʼ(FS) 1����ʼ-���(SF) 2����ʼ-��ʼ(SS) 3
        /// </summary>
        public int Type { get; set; }
    }
}