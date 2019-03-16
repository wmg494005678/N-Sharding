using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Database
{
    /// <summary>
    /// 数据源
    /// </summary>
    [Serializable]
    public class DataSource : SystemBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public DbType DbType { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否分库
        /// </summary>
        public bool IsSharding { get; set; }

        //数据库连接
        private List<DatabaseLink> dbLinks;

        /// <summary>
        /// 数据库连接
        /// </summary>
        public List<DatabaseLink> DbLinks
        {
            get
            {
                if (dbLinks == null)
                    dbLinks = new List<DatabaseLink>();

                return dbLinks;
            }
            set
            {
                dbLinks = value;
            }
        }

        /// <summary>
        /// 默认的数据库连接
        /// </summary>
        public DatabaseLink DefaultDbLink
        {
            get
            {
                return DbLinks.FirstOrDefault(i => i.IsDefault);
            }
        }
    }
}
