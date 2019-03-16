using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSharding.Sharding.Rule;
using NSharding.DomainModel.Spi;

namespace NSharding.DataAccess.Spi
{
    /// <summary>
    /// 数据查询服务接口
    /// </summary>
    public interface IDataQueryService
    {
        /// <summary>
        /// 获取对象数据
        /// </summary>        
        /// <param name="domainModel">领域模型</param>
        /// <param name="dataID">数据唯一标识</param>
        /// <param name="shardingValue">分库分表键值对</param>
        /// <returns>对象数据</returns>
        List<DataTable> GetData(DomainModel.Spi.DomainModel domainModel, string dataID, ShardingValue shardingValue = null);

        /// <summary>
        /// 获取对象数据
        /// </summary>        
        /// <param name="domainModel">领域模型</param>
        /// <param name="domainObject">领域对象</param>
        /// <param name="dataID">数据唯一标识</param>
        /// <param name="shardingValue">分库分表键值对</param>
        /// <returns>对象数据</returns>
        List<DataTable> GetData(DomainModel.Spi.DomainModel domainModel, DomainObject domainObject, string dataID, ShardingValue shardingValue = null);
    }
}
