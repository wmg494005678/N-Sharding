using NSharding.Sharding.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Database
{
    /// <summary>
    /// 数据对象
    /// </summary>
    [Serializable]
    public class DataObject : SystemBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Descriptions { get; set; }

        //列集合
        private List<DataColumn> columns;

        /// <summary>
        /// 列集合
        /// </summary>
        public List<DataColumn> Columns
        {
            get
            {
                if (columns == null)
                    columns = new List<DataColumn>();

                return columns;
            }
            set
            {
                columns = value;
            }
        }

        /// <summary>
        /// 主键列集合
        /// </summary>
        public List<DataColumn> PKColumns
        {
            get
            {
                return Columns.Where(i => i.IsPkColumn).ToList();
            }
        }

        /// <summary>
        /// 分区列
        /// </summary>
        public DataColumn ShardingColumn
        {
            get
            {
                return Columns.FirstOrDefault(i => i.IsShardingColumn);
            }
        }

        /// <summary>
        /// 数据源名称
        /// </summary>
        public string DataSourceName { get; set; }

        /// <summary>
        /// 数据源
        /// </summary>
        public DataSource DataSource { get; set; }

        /// <summary>
        /// 表名称
        /// </summary>
        public string LogicTableName { get; set; }

        /// <summary>
        /// 物理表名集合，以逗号间隔
        /// </summary>
        public string ActualTableNames { get; set; }

        /// <summary>
        /// 是否表分区
        /// </summary>
        public bool IsTableSharding { get; set; }

        private string tableShardingStrategyID;

        /// <summary>
        /// 表分区策略ID
        /// </summary>
        public string TableShardingStrategyID
        {
            get
            {
                return tableShardingStrategyID;
            }
            set
            {
                tableShardingStrategyID = value;
            }
        }

        private TableShardingStrategy tableShardingStrategy;
        /// <summary>
        /// 表分区策略
        /// </summary>
        public TableShardingStrategy TableShardingStrategy
        {
            get
            {
                return tableShardingStrategy;
            }
            set
            {
                tableShardingStrategy = value;
                if (value != null)
                {
                    TableShardingStrategyID = value.ID;
                }
            }
        }

        /// <summary>
        /// 是否分库
        /// </summary>
        public bool IsDatabaseSharding { get; set; }


        /// <summary>
        /// 数据库分库策略ID
        /// </summary>
        public string DatabaseShardingStrategyID { get; set; }

        private DatabaseShardingStrategy databaseShardingStrategy;

        /// <summary>
        /// 数据库分库策略
        /// </summary>
        public DatabaseShardingStrategy DatabaseShardingStrategy
        {
            get
            {
                return databaseShardingStrategy;
            }
            set
            {
                databaseShardingStrategy = value;
                if (value != null)
                {
                    DatabaseShardingStrategyID = value.ID;
                }
            }
        }

        /// <summary>
        /// 是否视图
        /// </summary>
        public bool IsView { get; set; }

        ///// <summary>
        ///// 是否缓存
        ///// </summary>
        //public bool IsCache { get; set; }

        ///// <summary>
        ///// 缓存策略
        ///// </summary>
        //public string CacheStrategy { get; set; }

        /// <summary>
        /// 是否逻辑删除
        /// </summary>
        public bool IsLogicallyDeleted { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public int Version { get; set; }
    }
}
