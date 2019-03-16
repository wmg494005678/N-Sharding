using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Database
{
    /// <summary>
    /// 数据库连接
    /// </summary>
    [Serializable]
    public class DatabaseLink : SystemBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        private string dataSourceName;
        /// <summary>
        /// 数据源名称
        /// </summary>  
        public string DataSourceName
        {
            get
            {
                if (DataSource != null)
                    dataSourceName = DataSource.Name;

                return dataSourceName;
            }
            set
            {
                dataSourceName = value;
            }
        }

        /// <summary>
        /// 是否默认的数据库连接
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        public DataSource DataSource { get; set; }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }


        private List<DatabaseTable> tableNames;

        /// <summary>
        /// 数据库表名称
        /// </summary>
        public List<DatabaseTable> Tables
        {
            get
            {
                if (tableNames == null)
                {
                    tableNames = new List<DatabaseTable>();
                }

                return tableNames;
            }
            set
            {
                tableNames = value;
            }
        }
    }
}
