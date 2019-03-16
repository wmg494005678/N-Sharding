using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Manager
{
    /// <summary>
    /// 数据访问服务管理类
    /// </summary>
    class DacServiceManager
    {
        //数据源数据访问类实例
        private static IDataSourceDao dataSourceDao;

        //数据对象数据访问类实例
        private static IDataObjectDao dataObjectDao;

        //领域模型数据访问类实例
        private static IDomainModelDao domainModelDao;

        //线程同步锁对象
        private static object syncObj = new object();

        //数据库连接
        public static readonly string ConnectionString = "sqlmap_teldmaster";

        /// <summary>
        /// 获取数据源数据访问类实例
        /// </summary>
        /// <returns>数据源数据访问类实例</returns>
        public static IDataSourceDao GetDataSourceDao()
        {
            if (dataSourceDao == null)
            {
                lock (syncObj)
                {
                    if (dataSourceDao == null)
                    {
                        //dataSourceDao = DaoService.GetInstance(ConnectionString).GetDao<IDataSourceDao>();
                    }
                }
            }

            return dataSourceDao;
        }


        /// <summary>
        /// 获取数据对象数据访问类实例
        /// </summary>
        /// <returns>数据对象数据访问类实例</returns>
        public static IDataObjectDao GetDataObjectDao()
        {
            if (dataObjectDao == null)
            {
                lock (syncObj)
                {
                    if (dataObjectDao == null)
                    {
                        //dataObjectDao = DaoService.GetInstance(ConnectionString).GetDao<IDataObjectDao>();
                    }
                }
            }

            return dataObjectDao;
        }

        /// <summary>
        /// 获取领域模型数据访问类实例
        /// </summary>
        /// <returns>领域模型数据访问类实例</returns>
        public static IDomainModelDao GetDomainModelDao()
        {
            if (domainModelDao == null)
            {
                lock (syncObj)
                {
                    if (domainModelDao == null)
                    {
                        //domainModelDao = DaoService.GetInstance(ConnectionString).GetDao<IDomainModelDao>();
                    }
                }
            }

            return domainModelDao;
        }
    }
}
