using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class AARead
    {
        public List<String> Read(String queryLaTeX)
        {
            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\第二篇论文实验读写数据库\\2.txt", Encoding.Default);
            List<AAIndex> list = new List<AAIndex>();
            String read = sr.ReadLine();
            //int a = 0;
            while (read != null)
            {
                //a++;
                //if (a == 6742)
                //    break;
                String[] re = read.Split('#');
                AAIndex index = new AAIndex();
                index.zishi = re[0];
                //Console.WriteLine("txt文件中子式为："+re[0]);
                index.zishiStructure = re[1];
                index.LaTeX = re[2];
                
                list.Add(index);
               // Console.WriteLine(re[2]);
                read = sr.ReadLine();
            }

            System.Diagnostics.Stopwatch stop = new System.Diagnostics.Stopwatch();
            stop.Start();//开始监视代码运行时间

            //现在相当于当成数据库了，这个list存储着属性为子式、子式结构和数学公式的集合
            Dictionary<int, List<FinalNode1>> children = new Dictionary<int, List<FinalNode1>>();
            ChildrenBTree childrenBTree = new ChildrenBTree();
            children = childrenBTree.childrenBTree(queryLaTeX);

            //用一个集合存储最终查询后的结果表达式的集合
            List<String> resultList = new List<String>();

            //这个是获取一个LaTeX的每一个子式
            foreach (var it in children)
            {
                //定义每一个子式
                String zishi = "";
                foreach (var itt in it.Value)
                {
                   zishi = zishi + itt.zifu;
                }
                //Console.WriteLine("AARead.cs:"+zishi);
                //先查询包含子式的集合
                foreach (var itts in list.Where(p => p.zishi.Equals(zishi)).ToList())
                {
                    //Console.WriteLine(itts.LaTeX);
                    resultList.Add(itts.LaTeX);
                    
                }
                
            }

            //foreach (var it in resultList)
            //{
            //    Console.WriteLine("草泥马有没有啊："+it);

            //}


            //这个是获取一个LaTeX的每一个子式结构
            foreach (var it in children)
            {

                //定义每一个子式结构
                String zishiStructure = "";
                foreach (var itt in it.Value)
                {
                    if (isSpecialYunSuanShu(itt.zifu))
                    {

                    }
                    else
                        zishiStructure = zishiStructure + itt.zifu;
                }

                //Console.WriteLine("AARead.cs:" + zishiStructure);
                if (zishiStructure.Equals(""))
                    continue;

                //先查询包含子式的集合
                foreach (var itts in list.Where(p => p.zishiStructure.Equals(zishiStructure)).ToList())
                {
                    resultList.Add(itts.LaTeX);
                }

            }
            stop.Stop();//代码结束时间
            TimeSpan timespan = stop.Elapsed;
            double milliseconds = timespan.TotalMilliseconds;//总毫秒
            //Console.WriteLine("查询所得数学表达式时间为：" + milliseconds + "毫秒");
            return resultList;

        }

        //判断是特殊运算数，比如\\pi，\\alpha，或者\\beta，先是一个再说，实在不行到时候再弄个类，把这些特殊字符同时放一起不就行了
        public Boolean isSpecialYunSuanShu(String zifu)
        {
            int a = 0;
            if (System.Text.RegularExpressions.Regex.IsMatch(zifu, @"^[A-Za-z0-9]+$") || zifu.Equals("\\alpha") || zifu.Equals("\\Alpha") || zifu.Equals("\\beta") || zifu.Equals("\\chi") || zifu.Equals("\\delta") || zifu.Equals("\\varepsilon") || zifu.Equals("\\phi") || zifu.Equals("\\varphi") || zifu.Equals("\\gamma") || zifu.Equals("\\eta") || zifu.Equals("\\ell") || zifu.Equals("\\pi")
                || zifu.Equals("\\infty") || zifu.Equals("\\iota") || zifu.Equals("\\Iota") || zifu.Equals("\\kappa") || zifu.Equals("\\Kappa") || zifu.Equals("\\lambda") || zifu.Equals("\\mu") || zifu.Equals("\\nu") || zifu.Equals("\\varpi") || zifu.Equals("\\theta") || zifu.Equals("\\vartheta") || zifu.Equals("\\rho") || zifu.Equals("\\sigma") ||
                zifu.Equals("\\varsigma") || zifu.Equals("\\tau") || zifu.Equals("\\Tau") || zifu.Equals("\\upsilon") || zifu.Equals("\\omega") || zifu.Equals("\\omega") || zifu.Equals("\\xi") || zifu.Equals("\\psi") || zifu.Equals("\\zeta") || zifu.Equals("\\Zeta") || zifu.Equals("\\Delta") || zifu.Equals("\\Phi") ||
                zifu.Equals("\\Gamma") || zifu.Equals("\\Lambda") || zifu.Equals("\\Pi") || zifu.Equals("\\pi") || zifu.Equals("\\Theta") || zifu.Equals("\\Sigma") || zifu.Equals("\\Upsilon") || zifu.Equals("\\Omega") || zifu.Equals("\\Xi") || zifu.Equals("\\Psi") || zifu.Equals("\\varepsilon") || zifu.Equals("\\prime")
                || zifu.Equals("\\epsilon") || zifu.Equals("\\ominus") || zifu.Equals("\\circ") || zifu.Equals("\\nabla") || zifu.Equals("\\partial") || zifu.Equals("\\Pr") || zifu.Equals("\\cdots") || zifu.Equals("\\therefore") || zifu.Equals("\\bigodot") || zifu.Equals("\\star") || zifu.Equals("\\hbar") || zifu.Equals("\\negative"))
                a = 1;
            if (a == 1)
                return true;
            return false;
        }

    }
}
