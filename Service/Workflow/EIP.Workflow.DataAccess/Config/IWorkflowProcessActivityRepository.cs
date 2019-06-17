using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.Workflow.Models.Entities;

namespace EIP.Workflow.DataAccess.Config
{
    public interface IWorkflowProcessActivityRepository : IAsyncRepository<WorkflowProcessActivity>
    {
        /// <summary>
        ///     ����ʵ��Id��ȡ��Ӧ���Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<WorkflowProcessActivity>> GetWorkflowProcessActivityByProcessId(IdInput input);
    }
}
