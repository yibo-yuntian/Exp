using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class middleBianLi
    {
        List<FinalNode1> nodeList;
        FinalNode1 node;
        public middleBianLi(List<FinalNode1> nodeList1,FinalNode1 node1)
        {
            nodeList = nodeList1;
            node = node1;
            this.middlebianli(node);
        }

        public void middlebianli(FinalNode1 a)
        {
            if (a.left != null)
                middlebianli(a.left);
            //Console.WriteLine("草泥马了什么鬼"+a.zifu);
            nodeList.Add(a);
            foreach (var it in nodeList)
            {
               //Console.WriteLine("什么鬼啊啊啊啊啊啊:"+it.zifu);
            }
            if (a.right != null)
                middlebianli(a.right);
        }
    }
}
