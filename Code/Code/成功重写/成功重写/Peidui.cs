using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功插入二叉树
{
    public class Peidui
    {
        public bool IsCouple(ZifuNode left, ZifuNode right)
        {
            if (left.zifu == '(' && right.zifu == ')')
            {
                return true;
            }
            if (left.zifu == '[' && right.zifu == ']')
            {
                return true;
            }
            if (left.zifu == '{' && right.zifu == '}')
            {
                return true;
            }
            return false;
        }

    }
}
