using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSharding.Sharding.Rule;
using NSharding.DomainModel.Spi;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 数据更新服务接口
    /// </summary>
    public interface IDataUpdateService
    {
        /// <summary>
        /// 保存领域模型数据
        /// </summary>
        /// <param name="domainModel">领域模型</param>
        /// <param name="instance">对象实例</param>
        /// <param name="shardingValue">分区分表键值对</param>
        void Update(DomainModel.Spi.DomainModel domainModel, object instance, ShardingValue shardingValue = null);

        /// <summary>
        /// 保存领域模型数据
        /// </summary>
        /// <param name="domainModel">领域模型</param>
        /// <param name="domainObject">领域对象</param>
        /// <param name="instance">对象实例</param>
        /// <param name="shardingValue">分区分表键值对</param>
        void Update(DomainModel.Spi.DomainModel domainModel, DomainObject domainObject, object instance, ShardingValue shardingValue = null);
    }
}
