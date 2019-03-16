using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// 多键分片法接口
    /// </summary>
    public interface IMultipleKeysShardingAlgorithm<T> : IShardingAlgorithm
        where T : IComparable
    {

        /// <summary>
        /// 根据分片值计算分片结果名称集合
        /// </summary>
        /// <param name="availableTargetNames">所有的可用目标名称集合, 一般是数据源或表名称</param>
        /// <param name="shardingValues">分片值集合</param>
        /// <returns>分片后指向的目标名称集合, 一般是数据源或表名称</returns>
        List<string> DoSharding(List<string> availableTargetNames, List<ShardingValue> shardingValues);
    }
}
