using NSharding.Sharding.Rule;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.RuleManager
{
    /// <summary>
    /// Sharding策略服务
    /// </summary>
    public class ShardingStrategyService
    {
        private static ConcurrentDictionary<string, ShardingStrategy> dataSourceDic;

        private static object syncObj = new object();

        private static ShardingStrategyService instance;

        private ShardingStrategyManager manager;

        /// <summary>
        /// 构造函数
        /// </summary>
        private ShardingStrategyService()
        {
            manager = new ShardingStrategyManager();
            dataSourceDic = new ConcurrentDictionary<string, ShardingStrategy>();
        }

        public static ShardingStrategyService GetInstance()
        {
            if (instance == null)
            {
                lock (syncObj)
                {
                    if (instance == null)
                    {
                        instance = new ShardingStrategyService();
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// 保存分区策略
        /// </summary>
        /// <param name="strategy">分区策略</param>
        public void SaveShardingStrategy(ShardingStrategy strategy)
        {
            if (strategy == null)
                throw new ArgumentNullException("ShardingStrategyService.SaveShardingStrategy.strategy");

            manager.SaveShardingStrategy(strategy);
        }

        /// <summary>
        /// 获取分区策略
        /// </summary>        
        /// <returns>分区策略</returns>
        public List<ShardingStrategy> GetShardingStrategys()
        {
            return manager.GetShardingStrategys();
        }

        /// <summary>
        /// 获取分区策略
        /// </summary>
        /// <param name="id">分区策略ID</param>
        /// <returns>分区策略</returns>
        public ShardingStrategy GetShardingStrategy(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("ShardingStrategyService.GetShardingStrategy.id");

            if (!dataSourceDic.ContainsKey(id))
            {
                lock (syncObj)
                {
                    if (!dataSourceDic.ContainsKey(id))
                    {
                        var dataSource = manager.GetShardingStrategy(id);
                        dataSourceDic.TryAdd(id, dataSource);

                        return dataSource;
                    }
                    else
                    {
                        return dataSourceDic[id];
                    }
                }
            }

            return dataSourceDic[id];
        }

        /// <summary>
        /// 获取表分区策略
        /// </summary>
        /// <param name="id">分区策略ID</param>
        /// <returns>表分区策略</returns>
        public TableShardingStrategy GetTableShardingStrategy(string id)
        {
            var strategy = GetShardingStrategy(id);

            return new TableShardingStrategy(strategy);
        }

        /// <summary>
        /// 获取分区表名称
        /// </summary>
        /// <param name="strategy">分区策略</param>
        /// <param name="logicalTableName">逻辑表名</param>
        /// <returns>分区表名称</returns>
        public List<string> GetShardingTableNames(TableShardingStrategy strategy, string logicalTableName)
        {
            var tables = new List<string>();
            strategy.PostFixValueList.ForEach(i => tables.Add(string.Format("{0}{1}", logicalTableName, i)));

            return tables;
        }

        /// <summary>
        /// 获取分区数据库名称
        /// </summary>
        /// <param name="strategy">分区策略</param>
        /// <param name="logicalDbName">逻辑数据库名</param>
        /// <returns>分区数据库名称</returns>
        public List<string> GetShardingDBNames(DatabaseShardingStrategy strategy, string logicalDbName)
        {
            var dbNames = new List<string>();
            strategy.PostFixValueList.ForEach(i => dbNames.Add(string.Format("{0}{1}", logicalDbName, i)));

            return dbNames;
        }

        /// <summary>
        /// 获取数据库分区策略
        /// </summary>
        /// <param name="id">分区策略ID</param>
        /// <returns>数据库分区策略</returns>
        public DatabaseShardingStrategy GetDatabaseShardingStrategy(string id)
        {
            var strategy = GetShardingStrategy(id);

            return new DatabaseShardingStrategy(strategy);
        }

        /// <summary>
        /// 删除分区策略
        /// </summary>
        /// <param name="id">分区策略ID</param>
        public void DeleteShardingStrategy(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("ShardingStrategyService.DeleteShardingStrategy.id");

            if (dataSourceDic.ContainsKey(id))
            {
                lock (syncObj)
                {
                    if (dataSourceDic.ContainsKey(id))
                    {
                        ShardingStrategy dataSource = null;
                        dataSourceDic.TryRemove(id, out dataSource);
                    }
                }
            }

            manager.DeleteShardingStrategy(id);
        }

        /// <summary>
        /// 删除分区列配置
        /// </summary>
        /// <param name="dataObjectID">数据对象ID</param>
        public void DeleteShardingColumns(string dataObjectID)
        {
            if (string.IsNullOrWhiteSpace(dataObjectID))
                throw new ArgumentNullException("ShardingStrategyService.DeleteShardingColumns.dataObjectID");

            manager.DeleteShardingColumns(dataObjectID);
        }

        /// <summary>
        /// 获取分区列配置 
        /// </summary>
        /// <param name="dataObjectID">数据对象ID</param>
        /// <returns>分区列配置</returns>
        public List<ShardingColumn> GetShardingColumns(string dataObjectID)
        {
            if (string.IsNullOrWhiteSpace(dataObjectID))
                throw new ArgumentNullException("ShardingStrategyService.GetShardingColumns.dataObjectID");

            return manager.GetShardingColumns(dataObjectID);
        }

        /// <summary>
        /// 保存分区列配置
        /// </summary>
        /// <param name="columns">分区列配置</param>
        public void SaveShardingColumns(List<ShardingColumn> columns)
        {
            if (columns == null)
                throw new ArgumentNullException("ShardingStrategyService.SaveShardingColumns.columns");
            if (columns.Count == 0) return;

            manager.SaveShardingColumns(columns);
        }
    }
}
