using NSharding.Sharding.Database;
using NSharding.Sharding.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.RuleManager
{
    /// <summary>
    /// 分区规则服务类
    /// </summary>
    public class ShardingRuleService
    {
        private static object syncObj = new object();

        private static ShardingRuleService instance;

        /// <summary>
        /// 构造函数
        /// </summary>
        private ShardingRuleService()
        {

        }

        public static ShardingRuleService GetInstance()
        {
            if (instance == null)
            {
                lock (syncObj)
                {
                    if (instance == null)
                    {
                        instance = new ShardingRuleService();
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// 解析Sharding规则
        /// </summary>       
        /// <param name="dataObject">数据对象</param>
        /// <param name="value">值</param>
        /// <returns>连接</returns>
        public IList<ShardingTarget> Parse(DataObject dataObject, ShardingValue value)
        {
            var dbNames = new List<string>();

            if (dataObject.IsDatabaseSharding && dataObject.DatabaseShardingStrategy != null)
            {
                var databaseStragety = dataObject.DatabaseShardingStrategy;
                var dblinks = dataObject.DataSource.DbLinks.Select(i => i.Name).ToList();
                var calc = ShardingStrategyFactory.GetSingKeyShardingAlgorithm(databaseStragety);
                switch (value.ShardingValueType)
                {
                    case ShardingValueType.SINGLE:
                        dbNames.Add(calc.DoEqualSharding(dblinks, value));
                        break;
                    case ShardingValueType.LIST:
                        dbNames.AddRange(calc.DoInSharding(dblinks, value).Distinct());
                        break;
                    case ShardingValueType.RANGE:
                        dbNames.AddRange(calc.DoBetweenSharding(dblinks, value).Distinct());
                        break;
                    default: break;
                }
            }
            else
            {
                dbNames.Add(dataObject.DataSource.DefaultDbLink.Name);
            }

            var tableList = new List<string>();
            if (dataObject.IsTableSharding && dataObject.TableShardingStrategy != null)
            {
                var tableNames = dataObject.ActualTableNames.Split(',').ToList();
                var calc = ShardingStrategyFactory.GetSingKeyShardingAlgorithm(dataObject.TableShardingStrategy);
                switch (value.ShardingValueType)
                {
                    case ShardingValueType.SINGLE:
                        tableList.Add(calc.DoEqualSharding(tableNames, value));
                        break;
                    case ShardingValueType.LIST:
                        tableList.AddRange(calc.DoInSharding(tableNames, value).Distinct());
                        break;
                    case ShardingValueType.RANGE:
                        tableList.AddRange(calc.DoBetweenSharding(tableNames, value).Distinct());
                        break;
                    default: break;
                }
            }
            else
            {
                tableList.Add(dataObject.LogicTableName);
            }

            var result = new List<ShardingTarget>();

            foreach (var tableName in tableList)
            {
                var dbName = dataObject.DataSource.DbLinks.FirstOrDefault(i => i.Tables.FirstOrDefault(t => t.Name == tableName) != null);
                if (dbNames.Contains(dbName.Name))
                    result.Add(new ShardingTarget() { DataSource = dbName.Name, TableName = tableName });
            }

            return result;
        }
    }
}
