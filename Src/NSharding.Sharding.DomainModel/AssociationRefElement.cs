using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.DomainModel.Spi
{
    /// <summary>
    /// 关联带出元素
    /// </summary>
    public class AssociationRefElement
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 领域对象ID
        /// </summary>
        public string DomainObjectID { get; set; }

        /// <summary>
        /// 领域模型元素ID
        /// </summary>
        public string ElementID { get; set; }
    }
}
