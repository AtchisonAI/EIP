using System;
using EIP.Common.Entities;
using EIP.Common.Entities.CustomAttributes;

namespace EIP.System.Models.Entities
{
    [Serializable]
    [Table(Name = "System_DataBase")]
    public class SystemDataBase : EntityBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Id]
        public Guid DataBaseId { get; set; }

        /// <summary>
        /// 数据库类别:SqlServer/Oracle
        /// </summary>
        public string RdbmsType { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        public string DataSource { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        public string CatalogName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// ProviderName
        /// </summary>
        [IgnoreColumn]
        public string ProviderName
        {
            get
            {
                switch (RdbmsType)
                {
                    case "SqlServer":
                        return "System.Data.SqlClient";
                    case "Oracle":
                        return "System.Data.OracleClient";
                }
                return string.Empty;
            }
        }


        /// <summary>
        /// ConnectionString
        /// </summary>
        [IgnoreColumn]
        public string ConnectionString
        {
            get
            {
                switch (RdbmsType)
                {
                    case "SqlServer":
                        return string.Format("server={0};database={1};uid={2};pwd={3}",
                            DataSource,CatalogName,UserId,Password);
                    case "Oracle":
                        return string.Format("Data Source={0};User Id={1};Password={2};Integrated Security=no;",
                            DataSource,UserId,Password);
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }
    }
}