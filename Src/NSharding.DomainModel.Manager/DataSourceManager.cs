using NSharding.Sharding.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace NSharding.DomainModel.Manager
{
    /// <summary>
    /// 数据源管理类
    /// </summary>
    public class DataSourceManager : IDataSourceManager
    {
        /// <summary>
        /// 数据源保存
        /// </summary>
        /// <param name="dataSource">数据源</param>
        public void SaveDataSource(DataSource dataSource)
        {
            if (dataSource == null)
                throw new ArgumentNullException("DataSourceManager.SaveDataSource.dataSource");

            var tables = new List<DatabaseTable>();
            dataSource.DbLinks.ForEach(i => tables.AddRange(i.Tables));

            try
            {
                using (var tran = new TransactionScope(TransactionScopeOption.Required))
                {
                    DacServiceManager.GetDataSourceDao().SaveDataSource(dataSource);
                    DacServiceManager.GetDataSourceDao().SaveDatabaseTables(tables);

                    tran.Complete();
                }
            }
            catch (Exception e)
            {

            }

            //var context = ContextHelper.GetContext().Clone() as DefaultContext;
            //Task.Run(() =>
            //{
            //    ContextHelper.SetContext(context);
            //    Thread.Sleep(1000);
            //});
        }

        /// <summary>
        /// 删除数据源
        /// </summary>
        /// <param name="name">数据源ID</param>
        public void DeleteDataSource(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("DataSourceManager.DeleteDataSource.id");

            DacServiceManager.GetDataSourceDao().DeleteDataSource(name);
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="name">数据源ID</param>
        /// <returns>数据源</returns>
        public DataSource GetDataSource(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("DataSourceManager.GetDataSource.id");

            return DacServiceManager.GetDataSourceDao().GetDataSource(name);
        }

        /// <summary>
        /// 获取数据源
        /// </summary>        
        /// <returns>数据源</returns>
        public List<DataSource> GetDataSources()
        {
            return DacServiceManager.GetDataSourceDao().GetDataSources();
        }
    }
}
