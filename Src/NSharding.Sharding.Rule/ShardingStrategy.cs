using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// 分片策略
    /// </summary>
    [Serializable]
    public class ShardingStrategy : SystemBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }

        private List<ShardingColumn> shardingColumns;

        /// <summary>
        /// 分片列集合
        /// </summary>
        public List<ShardingColumn> ShardingColumns
        {
            get
            {
                if (shardingColumns == null)
                    shardingColumns = new List<ShardingColumn>();

                return shardingColumns;
            }
            set
            {
                shardingColumns = value;
            }
        }

        /// <summary>
        /// 分片类型
        /// </summary>
        public ShardingType ShardingType { get; set; }

        /// <summary>
        /// 分片因子
        /// </summary>
        public int ShardingFactor { get; set; }

        /// <summary>
        /// 计算表达式
        /// </summary>
        public string AlgorithmExpression { get; set; }

        /// <summary>
        /// 分片后缀配置
        /// </summary>
        public string PostFixListConfig { get; set; }

        //分片后缀集合
        private List<string> postFixValueList;

        /// <summary>
        /// 分片后缀集合
        /// </summary>
        public List<string> PostFixValueList
        {
            get
            {
                if (postFixValueList == null)
                    postFixValueList = new List<string>();

                if (!string.IsNullOrEmpty(PostFixListConfig))
                {
                    postFixValueList = PostFixListConfig.Split(',').ToList();
                }

                return postFixValueList;
            }
            set
            {
                postFixValueList = value;
                if (value != null)
                {
                    PostFixListConfig = string.Join(",", value);
                }
            }
        }
    }
}
