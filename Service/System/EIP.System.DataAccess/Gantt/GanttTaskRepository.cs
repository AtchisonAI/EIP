using EIP.Common.DataAccess;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Gantt
{
    /// <summary>
    ///     ��������ݷ��ʽӿ�ʵ��
    /// </summary>
    public class GanttTaskRepository : DapperAsyncRepository<GanttTask>, IGanttTaskRepository
    {
    }
}