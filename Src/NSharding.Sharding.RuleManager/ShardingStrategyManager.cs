using NSharding.Sharding.Rule;
using NSharding.Sharding.RuleManager.Dac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.RuleManager
{
    /// <summary>
    /// 分区策略管理类
    /// </summary>
    public class ShardingStrategyManager
    {
        /// <summary>
        /// 保存分区策略
        /// </summary>
        /// <param name="strategy">分区策略</param>
        public void SaveShardingStrategy(ShardingStrategy strategy)
        {
            if (strategy == null)
                throw new ArgumentNullException("ShardingStrategyManager.SaveShardingStrategy.strategy");

            DacServiceManager.GetShardingStrategyDao().SaveShardingStrategy(strategy);
        }

        /// <summary>
        /// 获取分区策略
        /// </summary>        
        /// <returns>分区策略</returns>
        public List<ShardingStrategy> GetShardingStrategys()
        {
            return DacServiceManager.GetShardingStrategyDao().GetShardingStrategys();
        }

        /// <summary>
        /// 获取分区策略
        /// </summary>
        /// <param name="id">分区策略ID</param>
        /// <returns>分区策略</returns>
        public ShardingStrategy GetShardingStrategy(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("ShardingStrategyManager.GetShardingStrategy.id");

            return DacServiceManager.GetShardingStrategyDao().GetShardingStrategy(id);
        }

        /// <summary>
        /// 删除分区策略
        /// </summary>
        /// <param name="id">分区策略ID</param>
        public void DeleteShardingStrategy(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("ShardingStrategyManager.DeleteShardingStrategy.id");

            DacServiceManager.GetShardingStrategyDao().DeleteShardingStrategy(id);
        }

        /// <summary>
        /// 删除分区列配置
        /// </summary>
        /// <param name="dataObjectID">数据对象ID</param>
        public void DeleteShardingColumns(string dataObjectID)
        {
            if (string.IsNullOrWhiteSpace(dataObjectID))
                throw new ArgumentNullException("ShardingStrategyManager.DeleteShardingColumns.dataObjectID");

            DacServiceManager.GetShardingStrategyDao().DeleteShardingColumns(dataObjectID);
        }

        /// <summary>
        /// 获取分区列配置 
        /// </summary>
        /// <param name="dataObjectID">数据对象ID</param>
        /// <returns>分区列配置</returns>
        public List<ShardingColumn> GetShardingColumns(string dataObjectID)
        {
            if (string.IsNullOrWhiteSpace(dataObjectID))
                throw new ArgumentNullException("ShardingStrategyManager.GetShardingColumns.dataObjectID");

            return DacServiceManager.GetShardingStrategyDao().GetShardingColumns(dataObjectID);
        }

        /// <summary>
        /// 保存分区列配置
        /// </summary>
        /// <param name="columns">分区列配置</param>
        public void SaveShardingColumns(List<ShardingColumn> columns)
        {
            if (columns == null)
                throw new ArgumentNullException("ShardingStrategyManager.SaveShardingColumns.columns");
            if (columns.Count == 0) return;

            DacServiceManager.GetShardingStrategyDao().SaveShardingColumns(columns);
        }
    }
}
