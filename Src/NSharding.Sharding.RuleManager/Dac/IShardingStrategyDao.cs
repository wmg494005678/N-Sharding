using NSharding.Sharding.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.RuleManager
{
    /// <summary>
    /// 分区策略持久化接口
    /// </summary>
    public interface IShardingStrategyDao
    {
        /// <summary>
        /// 保存分区策略
        /// </summary>
        /// <param name="strategy">分区策略</param>
        void SaveShardingStrategy(ShardingStrategy strategy);

        /// <summary>
        /// 获取分区策略
        /// </summary>
        /// <param name="id">分区策略ID</param>
        /// <returns>分区策略</returns>
        ShardingStrategy GetShardingStrategy(string id);

        /// <summary>
        /// 获取分区策略
        /// </summary>        
        /// <returns>分区策略</returns>
        List<ShardingStrategy> GetShardingStrategys();

        /// <summary>
        /// 删除分区策略
        /// </summary>
        /// <param name="id">分区策略ID</param>
        void DeleteShardingStrategy(string id);

        /// <summary>
        /// 删除分区列配置
        /// </summary>
        /// <param name="dataObjectID">数据对象ID</param>
        void DeleteShardingColumns(string dataObjectID);

        /// <summary>
        /// 获取分区列配置 
        /// </summary>
        /// <param name="dataObjectID">数据对象ID</param>
        /// <returns>分区列配置</returns>
        List<ShardingColumn> GetShardingColumns(string dataObjectID);

        /// <summary>
        /// 保存分区列配置
        /// </summary>
        /// <param name="columns">分区列配置</param>
        void SaveShardingColumns(List<ShardingColumn> columns);
    }
}
