using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    public class NodeInfo
    {
        /// <summary>
        /// 当前节点id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 当前节点所在公式id
        /// </summary>
        public int expid { get; set; }
        /// <summary>
        /// 当前节点描述
        /// </summary>
        public string nodeexp { get; set; }
        /// <summary>
        /// 当前节点在公式中的编号
        /// </summary>
        public int num { get; set; }
        /// <summary>
        /// 当前节点在公式中的层次
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 当前节点是否是操作符
        /// </summary>
        public int opetate { get; set; }
        /// <summary>
        /// 当前节点相对空间位置标记
        /// </summary>
        public int flag { get; set; }
    }
}
