using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Entities;
using EIP.Workflow.Models.Dtos.Engine;
using EIP.Workflow.Models.Entities;

namespace EIP.Workflow.Business.Config
{
    public interface IWorkflowProcessInstanceLogic : IAsyncLogic<WorkflowProcessInstance>
    {
        /// <summary>
        /// ��������״̬
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperateStatus> UpdateWorkflowProcessInstanceStatus(WorkflowEngineRunnerInput input);
    }
}
