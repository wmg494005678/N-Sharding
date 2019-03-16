using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// 单键分片法接口
    /// </summary>
    public interface ISingleKeyShardingAlgorithm : IShardingAlgorithm
    {
        /// <summary>
        /// 根据分片值和SQL的=运算符计算分片结果名称集合.
        /// </summary>
        /// <param name="availableTargetNames">所有的可用目标名称集合, 一般是数据源或表名称</param>
        /// <param name="shardingValue">分片值</param>
        /// <returns>分片后指向的目标名称, 一般是数据源或表名称</returns>
        string DoEqualSharding(List<string> availableTargetNames, ShardingValue shardingValue);

        /// <summary>
        /// 根据分片值和SQL的IN运算符计算分片结果名称集合.
        /// </summary>
        /// <param name="availableTargetNames">所有的可用目标名称集合, 一般是数据源或表名称</param>
        /// <param name="shardingValue">分片值</param>
        /// <returns>分片后指向的目标名称集合, 一般是数据源或表名称</returns>
        List<string> DoInSharding(List<string> availableTargetNames, ShardingValue shardingValue);

        /// <summary>
        /// 根据分片值和SQL的BETWEEN运算符计算分片结果名称集合.
        /// </summary>
        /// <param name="availableTargetNames">所有的可用目标名称集合, 一般是数据源或表名称</param>
        /// <param name="shardingValue">分片值</param>
        /// <returns>分片后指向的目标名称集合, 一般是数据源或表名称</returns>
        List<string> DoBetweenSharding(List<string> availableTargetNames, ShardingValue shardingValue);
    }
}
