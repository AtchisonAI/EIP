using EIP.Common.Dapper;
namespace EIP.Common.DataAccess
{
    /// <summary>
    /// 所有数据访问基类
    /// </summary>
    public class BaseRepository
    {

        public SqlMapperUtil SqlMapperUtil { get; set; }

        public BaseRepository()
        {
            string assemblyName = this.GetType().Assembly.GetName().Name;
            SqlMapperUtil = new SqlMapperUtil(assemblyName);
        }

        public BaseRepository(string connectionName)
        {
            SqlMapperUtil = new SqlMapperUtil(connectionName);
        }
    }
}