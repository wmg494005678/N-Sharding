using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Spi
{
    /// <summary>
    /// 关联项
    /// </summary>
    [Serializable]
    public class AssociateItem : SystemBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 来源节点对象元素ID
        /// </summary>       
        public string SourceElementID { get; set; }

        /// <summary>
        /// 目的节点对象元素ID
        /// </summary>        
        public string TargetElementID { get; set; }

        /// <summary>
        /// 隶属的关联ID
        /// </summary>
        public string AssociationID { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public AssociateItem() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sourceElementID">源节点对象元素ID</param>
        /// <param name="targetElementID">目标节点对象元素ID</param>
        public AssociateItem(string sourceElementID, string targetElementID)
            : this()
        {
            SourceElementID = sourceElementID;
            TargetElementID = targetElementID;
        }
    }
}
