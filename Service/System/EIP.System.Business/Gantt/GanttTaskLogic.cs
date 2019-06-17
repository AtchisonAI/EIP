using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Core.Extensions;
using EIP.Common.Core.Utils;
using EIP.Common.Entities;
using EIP.System.DataAccess.Gantt;
using EIP.System.Models.Entities;

namespace EIP.System.Business.Gantt
{
    /// <summary>
    ///     �����ҵ���߼��ӿ�ʵ��
    /// </summary>
    public class GanttTaskLogic : AsyncLogic<GanttTask>, IGanttTaskLogic
    {
        #region ���캯��
        private readonly IGanttTaskRepository _ganttTaskRepository;
        public GanttTaskLogic(IGanttTaskRepository ganttTaskRepository)
            : base(ganttTaskRepository)
        {
            _ganttTaskRepository = ganttTaskRepository;
        }

        #endregion

        #region ����

        /// <summary>
        ///     ����
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <returns></returns>
        public async Task<OperateStatus> Save(GanttTask entity)
        {
            if (!entity.Id.IsEmptyGuid())
                return await UpdateAsync(entity);
            entity.Id = CombUtil.NewComb();
            return await InsertAsync(entity);
        }
        #endregion
    }
}