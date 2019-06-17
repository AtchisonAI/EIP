using EIP.Common.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.Business
{
    public class CommonLogic : ICommonLogic
    {
        private ICommonQueryRepository _Repository;

        public CommonLogic(ICommonQueryRepository repository)
        {
            _Repository = repository;
        }

        public Entities.Select2.Select2Output QuerySelectList(string connectionStringName, string sql)
        {
            return _Repository.QuerySelectList(connectionStringName,sql);
        }
    }
}
