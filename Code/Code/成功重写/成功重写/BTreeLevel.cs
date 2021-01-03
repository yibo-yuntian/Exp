using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功插入二叉树
{
   public class BTreeLevel
    {
        int BTreelevels = 1;
        //求每一个节点在二叉树的层次
        public void getBTreeLevel(FinalNode1 node)
        {
            if (node != null)
            {
                node.BTreeLevel = BTreelevels;
                //Console.WriteLine("节点为:"+node.zifu+"\t"+"节点所在层次为:"+node.BTreeLevel);
                ++BTreelevels;
                getBTreeLevel(node.left);
                getBTreeLevel(node.right);
                --BTreelevels;
            }
        }


    }
}
