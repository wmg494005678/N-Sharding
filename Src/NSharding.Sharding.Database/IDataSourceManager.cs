using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Database
{
    public interface IDataSourceManager
    {
        /// <summary>
        /// 数据源保存
        /// </summary>
        /// <param name="dataSource">数据源</param>
        void SaveDataSource(DataSource dataSource);

        /// <summary>
        /// 删除数据源
        /// </summary>
        /// <param name="name">数据源ID</param>
        void DeleteDataSource(string name);

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="name">数据源ID</param>
        /// <returns>数据源</returns>
        DataSource GetDataSource(string name);

        /// <summary>
        /// 获取数据源
        /// </summary>        
        /// <returns>数据源</returns>
        List<DataSource> GetDataSources();
    }
}
