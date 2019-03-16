using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.RuleManager.Dac
{
    class DacServiceManager
    {
        //分区策略数据访问实例
        private static IShardingStrategyDao shardingStrategyDao;

        //线程同步锁对象
        private static object syncObj = new object();

        //数据库连接
        public static readonly string ConnectionString = "******"; //读配置文件

        /// <summary>
        /// 获取分区策略数据访问实例
        /// </summary>
        /// <returns>分区策略数据访问实例</returns>
        public static IShardingStrategyDao GetShardingStrategyDao()
        {
            if (shardingStrategyDao == null)
            {
                lock (syncObj)
                {
                    if (shardingStrategyDao == null)
                    {
                        //TODO 对接ELB或者DBHelper
                        //shardingStrategyDao = DaoService.GetInstance(ConnectionString).GetDao<IShardingStrategyDao>();
                    }
                }
            }

            return shardingStrategyDao;
        }
    }
}
