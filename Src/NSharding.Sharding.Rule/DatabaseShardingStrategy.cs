using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// 数据库分片策略
    /// </summary>
    public class DatabaseShardingStrategy : ShardingStrategy
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DatabaseShardingStrategy()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strategy">分片策略</param>
        public DatabaseShardingStrategy(ShardingStrategy strategy)
        {
            if (strategy != null)
            {
                this.ID = strategy.ID;
                this.AlgorithmExpression = strategy.AlgorithmExpression;
                this.CreateTime = strategy.CreateTime;
                this.Creator = strategy.Creator;
                this.DisplayName = strategy.DisplayName;
                this.LastModifier = strategy.LastModifier;
                this.PostFixListConfig = strategy.PostFixListConfig;
                this.ShardingColumns = strategy.ShardingColumns;
                this.ShardingFactor = strategy.ShardingFactor;
                this.ShardingType = strategy.ShardingType;
            }
        }
    }
}
