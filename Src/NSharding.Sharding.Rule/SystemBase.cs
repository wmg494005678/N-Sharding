using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    /// <summary>
    /// 系统基类
    /// </summary>
    [DataContract]
    [Serializable]
    public class SystemBase
    {
        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public string Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>        
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        [DataMember]
        public string LastModifier { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>        
        [DataMember]
        public DateTime LastModifyTime { get; set; }
    }
}
