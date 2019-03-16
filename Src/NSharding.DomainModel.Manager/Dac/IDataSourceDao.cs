using NSharding.Sharding.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Manager
{
    /// <summary>
    /// 数据源管理持久化接口
    /// </summary>
    public interface IDataSourceDao
    {
        /// <summary>
        /// 数据源保存
        /// </summary>
        /// <param name="dataSource">数据源</param>
        void SaveDataSource(DataSource dataSource);

        /// <summary>
        /// 删除数据源
        /// </summary>
        /// <param name="id">数据源ID</param>
        void DeleteDataSource(string id);

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="id">数据源ID</param>
        /// <returns>数据源</returns>
        DataSource GetDataSource(string id);

        /// <summary>
        /// 保存数据表
        /// </summary>
        /// <param name="tables">数据表</param>
        void SaveDatabaseTables(List<DatabaseTable> tables);


        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="name">数据源ID</param>
        /// <returns>数据源</returns>
        List<DataSource> GetDataSources();
    }
}
