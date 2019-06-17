using EIP.Common.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Workflow.DataAccess
{
    public class WorkFlowBaseRepository<T> : DapperAsyncRepository<T> where T : class, new()
    {
        public WorkFlowBaseRepository()
        {
            base.SqlMapperUtil = new Common.Dapper.SqlMapperUtil("EIP");
        } 
    }
}
