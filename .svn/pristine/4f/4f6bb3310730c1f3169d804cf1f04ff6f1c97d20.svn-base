using EIP.Common.Dapper;
using EIP.Common.Entities.Select2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.DataAccess
{
    public class CommonQueryRepository : ICommonQueryRepository
    {
        public Entities.Select2.Select2Output QuerySelectList(string connectionStringName, string sql)
        {
            Select2Output output = new Select2Output();
            try
            {
                output.isSuccess = true;
                var sqlUtility = new SqlMapperUtil(connectionStringName);
                DataTable dtData = sqlUtility.SqlWithParamsDataTableSync(sql, "Select");
                if (dtData.Rows.Count > 0)
                {
                    output.totalCount = double.Parse(dtData.Rows[0]["totalCount"].ToString());
                }
                output.data = new List<Select2OutputItem>();
                foreach (DataRow drData in dtData.Rows)
                {
                    output.data.Add(new Select2OutputItem() { id = drData["id"].ToString(), text = drData["text"].ToString() });
                }

            }
            catch (Exception ex)
            {
                output.isSuccess = false;
                output.errorMsg = ex.Message;
            }
            return output;

        }

    }
}
