using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class AATfIdf
    {
        public List<double> tfidf(String queryLaTeX)
        {
            AABTreeStructure acquireBtreeStructure = new AABTreeStructure();//调用这个类，获取树结构的类
            List<FinalNode1> queryLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“查询表达式”邻接节点有序对的集合
            List<FinalNode1> resultLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“结果表达式”邻接节点有序对的集合
            queryLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(queryLaTeX);
            resultLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(queryLaTeX);

            //我得先把查询表达式的“关键字”放入一个集合
            //（那个徐彩云论文引用的英文论文里面有很多规定，
            //但是许彩云只只把“运算符”，“括号”，“子表达式作为关键字，到时候回去看那篇英文论文再添加再添加）
            List<String> queryLaTeXKeyWords = new List<String>();
            //结果表达式关键字集合
            List<String> resultLaTeXKeyWords = new List<String>();

            Dictionary<int, List<FinalNode1>> children = new Dictionary<int, List<FinalNode1>>();
            ChildrenBTree childrenBTree = new ChildrenBTree();
            children = childrenBTree.childrenBTree(queryLaTeX);

            //foreach (var it in children)
            //{
            //    Console.WriteLine("KEY值:"+it.Key);
            //    foreach (var itt in it.Value)
            //    {
            //        Console.WriteLine("值为:"+itt.zifu);
            //    }
            //    Console.WriteLine("=====================================");
            //}


            //================（我这里关键词只算了运算符，子式，没有算括号group，到时候还得把所有LaTeX以树形结点形式包含group放入数据库以便sql语句查找）=====下面写的代码是找到查询表达式里面的所有关键字，可以重复=========================================
            //首先先把里面的运算符作为关键字放入一个集合里面
            foreach (var it in queryLaTeXAdjacentNodeList)
            {
                if (isOperator(it.zifu))
                {
                    queryLaTeXKeyWords.Add(it.zifu);
                }
            }
            //我这里子表达式是一个一个节点的，因为我要弄那个邻接节点有序对，所以是一个一个的节点，
            //但是我要把子表达式作为关键字，所以我得把一个一个的节点的字符“以字符串”的形式连接起来，真正作为一个关键字
            foreach (var it in children)
            {
                String temp = "";
                foreach (var itt in it.Value)
                {
                    //Console.WriteLine("值为:" + itt.zifu);
                    temp = temp + itt.zifu;
                }

                //获取到第一个子式关键字之后temp，然后装入集合
                queryLaTeXKeyWords.Add(temp);
                //Console.WriteLine("=====================================");
            }
            //================================================上面写的代码是找到查询表达式里面的所有关键字，可以重复=========================================
            
            /*foreach (var it in queryLaTeXKeyWords)
            {
                Console.WriteLine("AATfIdf.cs:tfIdf集合关键字"+it);
            }*/

            //查询表达式每一个关键字在表达式中关键词中出现的次数
            Dictionary<String, int> KeyWordsCount = new Dictionary<string, int>();
            for (int i = 0; i < queryLaTeXKeyWords.Count; i++)
            {
                int a = 0;
                if (KeyWordsCount.Count == 0)
                {
                    //如果一开始为空的话，就是出现一次
                    KeyWordsCount.Add(queryLaTeXKeyWords[i], 1);
                    continue;
                }

                //现在开始去遍历专门存放关键字和次数的字典，查看有没有这个关键字
                foreach (var it in KeyWordsCount)
                {
                    if (queryLaTeXKeyWords[i].Equals(it.Key))//说明有这个关键字
                    {
                        a = 1;//说明有重复的关键字了
                        break;
                        //KeyWordsCount[queryLaTeXKeyWords[i]]++;
                    }
                }
                if (a == 1)
                {
                    KeyWordsCount[queryLaTeXKeyWords[i]]++;
                }
                else
                {
                    KeyWordsCount.Add(queryLaTeXKeyWords[i],1);
                }
            }


            //===============下面里面的代码是我现在做实验临时弄的，这个是读取txt文本（我构建的临时数据集）（到时候读一下数据库数据集）里面的数学公式========================
            Dictionary<String, String> txt = new Dictionary<String,String>();
            StreamReader sr = new StreamReader("E:\\我要用的东西\\1我的论文2第二篇论文\\实验\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
            String read = sr.ReadLine();
            while (read != null)
            {
                //Console.WriteLine("看看行不啊:"+read);
                String temp = "";
                List<FinalNode1> List = new List<FinalNode1>();//存放“查询表达式”邻接节点有序对的集合
                List = acquireBtreeStructure.AdjacentNodeList(read);//已经存放“查询表达式”邻接节点有序对的集合
                foreach (var it in List)
                {
                    temp = temp + it.zifu;
                }
                txt.Add(read,temp);
                read = sr.ReadLine();
            }
            sr.Close();



            //===============上面里面的代码是我现在做实验临时弄的，这个是读取txt文本（我构建的临时数据集）（到时候读一下数据库数据集）里面的数学公式========================



            //现在开始求每一个关键字的权值了,tf*idf
            int allKeyWordsCount = queryLaTeXKeyWords.Count();//一个“查询表达式”中“所有关键字”的总次数

            List<double> queryLaTeXtfIdfs = new List<double>();//这个是放入所有关键字的最终权重值得集合，到时候计算相似度
            foreach (var it in KeyWordsCount)
            {
                double tf = Convert.ToDouble(it.Value) / Convert.ToDouble(allKeyWordsCount);

                //===下面这两个权重到底是在数据库所有数学表达式呢，还是检索结果表达式里面的数学表达式呢？=======
                double LaTeXCount = txt.Count;//所有公式的数量

                //===========包含关键词的数量(这是我临时测试关键词的数量)================
                int tempCount = 0;//包含关键词的数量
                foreach (var it1 in txt)
                {
                    if (it1.Key.Contains(it.Key))
                    {
                        tempCount++;
                    }
                }
                //===========包含关键词的数量(这是我临时测试关键词的数量)================
                //Console.WriteLine("包含关键词："+it.Key + "数量为："+tempCount);
                double ContainKeyWordLaTeXCount = tempCount;//包含关键词的数学公式的数量

                double idf = Math.Log10(LaTeXCount / (1 + ContainKeyWordLaTeXCount));

                double tfIdf = tf * idf;//现在这个算出来的是每一个关键字的权值

                queryLaTeXtfIdfs.Add(tfIdf);
            }

            return queryLaTeXtfIdfs;
        }

        //判断是运算符
        private Boolean isOperator(String zifu)
        {
            Boolean a = false;
            if (zifu.Equals("+") || zifu.Equals("-") || zifu.Equals("*") || zifu.Equals("\\times") || zifu.Equals("/") || zifu.Equals("\\frac") || zifu.Equals("#") || zifu.Equals("^") || zifu.Equals("=") || zifu.Equals("\\sqrt") || zifu.Equals("_")
                || zifu.Equals("\\leq") || zifu.Equals("\\neq") || zifu.Equals("\\geq") || zifu.Equals(">") || zifu.Equals("<") || zifu.Equals("\\sin") || zifu.Equals("\\cos") || zifu.Equals("\\tan")
                || zifu.Equals("\\cot") || zifu.Equals("\\sec") || zifu.Equals("\\csc") || zifu.Equals("\\arcsin") || zifu.Equals("\\arccos") || zifu.Equals("\\arctan") || zifu.Equals("\\arccot") || zifu.Equals("\\arcsec")
                || zifu.Equals("\\arccsc") || zifu.Equals("\\gg") || zifu.Equals("\\approx") || zifu.Equals("\\pm") || zifu.Equals("\\cdot") || zifu.Equals("\\equiv") || zifu.Equals(":") || zifu.Equals("\\to") || zifu.Equals("\\overline")
                || zifu.Equals("\\log") || zifu.Equals("\\arg") || zifu.Equals("\\Rightarrow") || zifu.Equals("\\rightarrow") || zifu.Equals("\\quad") || zifu.Equals("\\mid") || zifu.Equals("\\bar") || zifu.Equals("\\vec") || zifu.Equals("\\hat")
                || zifu.Equals("\\qquad") || zifu.Equals("\\or") || zifu.Equals("\\implies") || zifu.Equals("\\lim") || zifu.Equals("\\sum") || zifu.Equals("\\join") || zifu.Equals("\\connect") || zifu.Equals("\\PowerRoot") || zifu.Equals("\\DuiShu") || zifu.Equals("\\log") || zifu.Equals("\\temp") || zifu.Equals("\\max") || zifu.Equals("\\lor") || zifu.Equals("\\lnot")
                || zifu.Equals("\\mathbb") || zifu.Equals("\\subset") || zifu.Equals("\\in") || zifu.Equals("\\mathcal") || zifu.Equals("\\tfrac") || zifu.Equals("\\cap") || zifu.Equals("\\cup") || zifu.Equals("\\ln") || zifu.Equals("\\colon") || zifu.Equals("\\mathbf")
                || zifu.Equals("\\ll") || zifu.Equals("\\mathrm") || zifu.Equals("\\cong") || zifu.Equals("\\tilde") || zifu.Equals("\\dashv") || zifu.Equals("\\dot"))
            {
                a = true;
            }
            return a;
            // TODO Auto-generated method stub	
        }

    }
}
