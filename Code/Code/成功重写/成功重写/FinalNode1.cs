using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功插入二叉树
{
    public class FinalNode1
    {
        public String LaTeXNumber;//字符在数学表达式序号，说白了就是在原始数学表达式里面的序号
        public int yuanshiXuHao;
        public int pailiexuhao;
        public string zifu;
        public int zifuXuHao;//字符在表达式二叉树序号
        public int Level;//Level
        //public int BTLevel;//在二叉树层次
        public int Flag;//Flag
        public int Length;//Length
        public int BTreeLevel;//二叉树层次
        public FinalNode1 left;
        public FinalNode1 right;
        public int CengciBianli;//这个是层次遍历的顺序序号
        public int xuhao;

        //中序遍历
        /*public void middlebianli(FinalNode1 n)
        {
            if (n.left != null)
                n.middlebianli(n.left);
            Console.WriteLine(n.zifu);//输出结点n的数据
            if (n.right != null)
                n.middlebianli(n.right);
        }*/



    }
}
