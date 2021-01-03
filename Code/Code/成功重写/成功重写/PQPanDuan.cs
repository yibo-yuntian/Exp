using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class PQPanDuan
    {

        public bool pqPanDuan(String LaTeX,int k, ZifuNode top, List<PQ> PQList)
        {
            int biaozhi = 0;
            //开始遍历这个全部的PQList集合
            foreach (var it in PQList)
            {
                //只要出现它在这个集合当中，那肯定是立刻break
                if ((k + LaTeX.Substring(0, top.position + 1).Length >= it.P) && (k + LaTeX.Substring(0, top.position + 1).Length <= it.Q))
                {
                    //Console.WriteLine("满足几次应该是两次啊");//这里他妈没执行啊艹
                    biaozhi = 1;
                    break;
                }
            }
            if (biaozhi == 1)
                return true;
            else
                return false;
   
        }
    }
}
