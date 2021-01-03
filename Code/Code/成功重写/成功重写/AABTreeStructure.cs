using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class AABTreeStructure
    {
        public List<FinalNode1> AdjacentNodeList(String LaTeX)
        {
            AdjacentNode adjacentNodes = new AdjacentNode();
            List<FinalNode1> AdjacentNodeList = new List<FinalNode1>();//存放邻接节点有序对的集合
            LimAndSum limandSums = new LimAndSum();
            DuiJiaoXian duijiaoxian = new DuiJiaoXian();
            NciGenHao nicigenHao = new NciGenHao();
            DuiShu duishu = new DuiShu();
            int biaozhi;
            String final;
            String cao;
            char[] caos;
            FuShu fushu = new FuShu();
            biaozhi = 1;//每次循环前设置一个标志令标志等于1
            final = "";//每次令final为空字符串，用来接收“特殊lim和sum表达式”还是“一般表达式”
            cao = LaTeX.ToString().Trim();//把数据库的数学表达式读出来，要开始判断了啊
            caos = cao.ToCharArray();
            for (int i = 0; i < caos.Length; i++)
            {
                if (Convert.ToString(caos[i]).Equals("\\") && Convert.ToString(caos[i + 1]).Equals("l") && Convert.ToString(caos[i + 2]).Equals("i") && Convert.ToString(caos[i + 3]).Equals("m"))
                {
                    biaozhi = 0;
                    break;
                }
                else if (Convert.ToString(caos[i]).Equals("\\") && Convert.ToString(caos[i + 1]).Equals("s") && Convert.ToString(caos[i + 2]).Equals("u") && Convert.ToString(caos[i + 3]).Equals("m"))
                {
                    biaozhi = 0;
                    break;
                }
            }
            if (biaozhi == 0)//说明有lim这种的
            {
                final = limandSums.limAndSum(cao);
                final = fushu.fuShu(final);
                final = nicigenHao.NcigenHao(final);
                final = duishu.duiShu(final);
            }
            else
            {
                //下面这个是普通的和负号的
                final = fushu.fuShu(cao);
                final = nicigenHao.NcigenHao(final);
                final = duishu.duiShu(final);
            }
            //================================对于遇到含有lim和sum等特殊表达式的需要一段代码来特殊处理，如果不是这类表达式，那就不用处理，不过还有一些负号这类的===========================================
            AdjacentNodeList = adjacentNodes.AdjacentNodeList(final);

            return AdjacentNodeList;
        }


    }
}
