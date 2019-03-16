using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Database
{
    /// <summary>
    /// 数据库表
    /// </summary>
    [Serializable]
    public class DatabaseTable : SystemBase
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 数据库连接名称
        /// </summary>
        public string DatabaseLinkName { get; set; }
    }
}
