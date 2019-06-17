using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Entities;
using EIP.System.Models.Entities;

namespace EIP.System.Business.Gantt
{
	/// <summary>
    /// �����ҵ���߼��ӿ�
    /// </summary>
    public interface IGanttTaskLogic : IAsyncLogic<GanttTask>
    {
        /// <summary>
        ///     ����
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <returns></returns>
        Task<OperateStatus> Save(GanttTask entity);
    }
}