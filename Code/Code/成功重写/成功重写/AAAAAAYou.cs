using DBhelper类封装起来;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class AAAAAYou
    {
        //=================这个是我把子式和数学表达式插入数据库=======================
        public void insertDataBase()
        {

            //LaTeX，子式节点
            Dictionary<AAAAData, List<String>> dic = new Dictionary<AAAAData, List<String>>();
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\1.txt", Encoding.Default);
            String read = sr.ReadLine();

            //为每一个数学公式分配一个Id
            int ExpId = 0;

            //================定义一个集合判断是否重复出现字符串=============================
            List<String> list = new List<string>();
            //================定义一个集合判断是否重复出现字符串=============================

            //================计数器=========================
            int count = 0;
            //=================计数器========================


            //第一步：开始读取每一个数学表达式了啊
            while (read != null)
            {
                count++;
                Console.WriteLine(count);
                //Console.WriteLine(count);
                if (count == 89408)
                    break;

                //Console.WriteLine("===========================================");

                int biaozhi = 0;//每次进来一个数学公式设置一个判断标志为0

                //第二步：直接构成倒排索引吧，省的以后要是有重复的数学表达式啥的
                //对于输入进来的每一个数学公式，把它解析为各个子式
                List<AAAAData> li = new List<AAAAData>();
                li = Test444(read);

                //foreach (var it in li)
                //{
                //    Console.WriteLine("草拟吗又少子式了啊："+it.str + "\t" + "层次："+it.BTLevel);
                //}



                //if (list.Count == 0)
                //{
                //    //Console.WriteLine("===========================================");
                //    //Console.WriteLine("==========================================="+read);
                //    list.Add(read);
                //    read = sr.ReadLine();
                //    continue;
                //}

                ////进行下一个数学表达式，如果下一个数学公式和之前的数学公式重复了
                //foreach (var it in list)
                //{
                //    if (it.Equals(read))//如果出现重复了
                //    {
                //        //Console.WriteLine("==========================================="+it);
                //        //Console.WriteLine("==========================================="+read);
                //        biaozhi = 1;
                //        break;
                //    }
                //}

                ////Console.WriteLine("===========================================");

                //if (biaozhi == 1)//说明出现重复了，那就别加了,这个起到过滤作用
                //{
                //    //Console.WriteLine("草泥马");
                //    read = sr.ReadLine();
                //    continue;
                //}
                //else
                //{
                //    list.Add(read);
                //    ExpId++;

                //}

                //Console.WriteLine("===========================================");

                //对于单个的数学公式，其中，每一个子式节点，我
                foreach (var it in li)
                {
                    //,'" + read + "'
                    //这里把数据倒排插入数据库
                    bool panduan;
                    //Console.WriteLine(count);
                    string sqlstr = "insert into AAAA(子式,空间标志位) values ('" + it.str + "','" + it.Flag + "')";
                    panduan = DBhelper.InsertUpdateDal(sqlstr);

                }//循环里面

                read = sr.ReadLine();
            }

        }

        public void CountZishiFlag()
        {


        }
        public void meiyong()
        {
            String queryLaTeX;
            Console.WriteLine("请输入您要查询的表达式:");
            queryLaTeX = Console.ReadLine();

            String resulta;
            Console.WriteLine("请输入您要查询的结果表达式:");
            resulta = Console.ReadLine();
            AAAAAYou you = new AAAAAYou();
            List<double> queryYouYu = new List<double>();
            List<AAAAData> queryzishiList = new List<AAAAData>();
            queryzishiList = you.Test4(queryLaTeX);
            BinaryTreeNode bnode = new BinaryTreeNode();
            FinalNode1 root = new FinalNode1();
            root = bnode.getNode(queryLaTeX);//完整数学表达式的根结点
            foreach (var it in queryzishiList)
            {
                queryYouYu.Add(you.zhibiao1(it, queryzishiList));
                queryYouYu.Add(you.zhibiao2(it, root));
                queryYouYu.Add(you.zhibiao3(it, root));
                queryYouYu.Add(you.zhibiao4(it, queryLaTeX));
                queryYouYu.Add(you.zhibiao5(it, queryLaTeX));
            }

            double tempdata;
            //for (int i = 0; i < queryYouYu.Count - 1; i++)
            //{
            //    for (int j = i + 1; j < queryYouYu.Count; j++)
            //    {
            //        if (queryYouYu[j] < queryYouYu[i])
            //        {
            //            tempdata = queryYouYu[j];
            //            queryYouYu[j] = queryYouYu[i];
            //            queryYouYu[i] = tempdata;
            //        }
            //    }
            //}

            foreach (var it in queryYouYu)
            {
                Console.WriteLine("键盘声那么大草拟吗啊查询：" + it);
            }

            //===========================犹豫模糊语言术语集FDS============================

            Console.WriteLine("==========================================================================================");


            //===========================犹豫模糊语言术语集1============================
            List<String> ResultLaTeXList = new List<String>();
            List<AAAAData> Final = new List<AAAAData>();

            //ResultLaTeXList = you.getResultLaTeXList(queryLaTeX);
            List<double> resultYouYu = new List<double>();
            //遍历结果表达式

            List<AAAAData> resultzishiList = new List<AAAAData>();
            resultzishiList = you.Test4(resulta);
            root = bnode.getNode(resulta);//完整数学表达式的根结点

            //对于每一个结果表达式，计算每一个查询子式在结果表达式里面的犹豫模糊语言术语
            foreach (var itt in queryzishiList)
            {
                resultYouYu.Add(you.zhibiao1(itt, resultzishiList));
                resultYouYu.Add(you.zhibiao2(itt, root));
                resultYouYu.Add(you.zhibiao3(itt, root));
                resultYouYu.Add(you.zhibiao4(itt, resulta));
                resultYouYu.Add(you.zhibiao5(itt, resulta));
            }

            //for (int i = 0; i < resultYouYu.Count - 1; i++)
            //{
            //    for (int j = i + 1; j < resultYouYu.Count; j++)
            //    {
            //        if (resultYouYu[j] < resultYouYu[i])
            //        {
            //            tempdata = resultYouYu[j];
            //            resultYouYu[j] = resultYouYu[i];
            //            resultYouYu[i] = tempdata;
            //        }
            //    }
            //}
            foreach (var it in resultYouYu)
            {
                Console.WriteLine("键盘声那么大草拟吗啊结果：" + it);
            }


            //===========================犹豫模糊语言术语集1============================

            Console.WriteLine("草拟吗的：" + you.Compute(queryYouYu, resultYouYu));

            ////
        }

        public void Test1(String queryLaTeX)
        {
            //第一步：先获取查询表达式的犹豫模糊语言术语集
            List<AAAAData> queryList = new List<AAAAData>();
            queryList = Test4(queryLaTeX);
            for (int i = 0; i < queryList.Count; i ++)
            {



            }






            //第一步：先获取查询表达式的犹豫模糊语言术语集


            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第二篇小论文\\实验\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\实验数据\\1.txt", Encoding.Default);
            String read = sr.ReadLine();
            //String queryLaTeX = "\\sqrt{b^{2}-4*a*c";




            List<AAAAData> Final = new List<AAAAData>();


            while (read != null)
            {
                //第一步：读进来某个结果表达式了











                Dictionary<int, List<FinalNode1>> dics = new Dictionary<int, List<FinalNode1>>();
                AAAA A = new AAAA();
                dics = A.BTLevelScore(queryLaTeX, read);

                if (dics == null || dics.Count == 0)
                {
                    //Console.WriteLine("草擦曹操");
                    read = sr.ReadLine();
                    continue;
                }


                //下面这个是统计查询表达式a+b，在结果表达式a+b+c+a+b，的两个a+b的最小树的层次啊
                String str = "";
                foreach (var it in dics)
                {
                    //Console.WriteLine("键值：" + it.Key);
                    int min = 10000;
                    foreach (var itt in it.Value)
                    {
                        if (itt.BTreeLevel < min)
                        {
                            min = itt.BTreeLevel;
                        }
                        //Console.WriteLine(itt.zifu+"\t"+itt.BTreeLevel);
                    }
                    str = str + min + "#";
                }

                //统计一下负数的那个，树的高度越高，它的负值越大，负的越厉害。注意现在统计的是结果表达式的最大高度，也就是read
                int fushu = 0;
                int maxBTLevel = 0;
                List<FinalNode1> lists = new List<FinalNode1>();
                AdjacentNode aa = new AdjacentNode();
                lists = aa.AdjacentNodeList(read);

                foreach (var it in lists)
                {
                    if (it.BTreeLevel > fushu)
                        fushu = it.BTreeLevel;

                }

                fushu = (-1) * fushu;



                str = str + fushu + "#" + read;
                //Console.WriteLine(str);
                //已经得到一个查询表达式在结果表达式里面的层次级别了，开始计算分数了
                String[] news = str.Split('#');
                List<int> list = new List<int>();
                for (int i = 0; i < news.Length - 1; i++)
                {
                    list.Add(Convert.ToInt32(news[i]));
                    //Console.WriteLine("草："+news[i]);
                }



                //开始排序
                int tempdata;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[j] < list[i])
                        {
                            tempdata = list[j];
                            list[j] = list[i];
                            list[i] = tempdata;
                        }
                    }
                }





                //=================开始利用公式计算=====================
                double sum = 0;
                for (int i = 0; i < news.Length - 1; i++)
                {
                    sum = sum + Math.Abs(19 - (20 - Convert.ToDouble(news[i]))) / (19);
                    //Console.WriteLine("看看结果："+sum);
                }

                sum = sum / (news.Length - 1);
                AAAAData d = new AAAAData();
                d.BTLevel = 1 - sum;
                d.str = read;
                Final.Add(d);

                read = sr.ReadLine();

            }

            //开始排序
            AAAAData tempdatas;
            for (int i = 0; i < Final.Count - 1; i++)
            {
                for (int j = i + 1; j < Final.Count; j++)
                {
                    if (Final[j].BTLevel > Final[i].BTLevel)
                    {
                        tempdatas = Final[j];
                        Final[j] = Final[i];
                        Final[i] = tempdatas;
                    }
                }
            }

            foreach (var it in Final)
            {
                Console.WriteLine("公式为：" + it.str + "\t" + "相似度为：" + it.BTLevel);

            }


        }


        //=====================================第一：这里定义指标吧===========================
        //第一个指标：子式出现个数占总个数
        public double zhibiao1(AAAAData queryZiShi, List<AAAAData> resultZiShiList)
        {
            double a = 0;
            double resultScore;
            foreach (var it in resultZiShiList)
            {
                if (queryZiShi.str.Equals(it.str))
                {
                    a++;
                }
            }
            resultScore = a / Convert.ToDouble(resultZiShiList.Count);

            double pinjia = -4;

            if (resultScore == 0)
                pinjia = -4;
            else if (resultScore > 0 && resultScore < 0.25)
                pinjia = -3;
            else if (resultScore == 0.25)
                pinjia = -2;
            else if (resultScore > 0.25 && resultScore < 0.5)
                pinjia = -1;
            else if (resultScore == 0.5)
                pinjia = 0;
            else if (resultScore > 0.5 && resultScore < 0.75)
                pinjia = 1;
            else if (resultScore == 0.75)
                pinjia = 2;
            else if (resultScore > 0.75 && resultScore < 1)
                pinjia = 3;
            else if (resultScore == 1)
                pinjia = 4;

            return pinjia;

        }

        //第二个指标：子式运算符出现个数占总运算符个数
        public double zhibiao2(AAAAData queryZiShi, FinalNode1 bnode)//这里是结果表达式对应二叉树的根结点
        {
            double a = 0;
            double resultScore = 0;
            String[] result = queryZiShi.str.Split('#').Distinct().ToArray();
            String newsss = string.Join("#",result);
            String[] newss = newsss.Split('#');
            String[] news;
            String strs = "";
            foreach (var it in newss)
            {
                if (isOperator(Convert.ToString(it)))
                {
                    strs = strs + it + "#";
                }
            }
            strs = strs.TrimEnd('#');
            news = strs.Split('#');



            String[] newresult;
            String resultList = Test5(bnode);//这里是结果表达式的层次遍历用#号隔开
            String strss = "";
            foreach (var it in resultList.Split('#'))
            {
                if (isOperator(Convert.ToString(it)))
                {
                    strss = strss + it + "#";
                }
            }
            strss = strss.TrimEnd('#');
            newresult = strss.Split('#');
      

            foreach (var it in news)
            {
                foreach (var itt in newresult)
                {
                    if (Convert.ToString(it).Equals(Convert.ToString(itt)))
                    {
                        a++;
                    }
                }
            }
            resultScore = a / Convert.ToDouble(newresult.Count());

            double pinjia = -4;

            if (resultScore == 0)
                pinjia = -4;
            else if (resultScore > 0 && resultScore < 0.25)
                pinjia = -3;
            else if (resultScore == 0.25)
                pinjia = -2;
            else if (resultScore > 0.25 && resultScore < 0.5)
                pinjia = -1;
            else if (resultScore == 0.5)
                pinjia = 0;
            else if (resultScore > 0.5 && resultScore < 0.75)
                pinjia = 1;
            else if (resultScore == 0.75)
                pinjia = 2;
            else if (resultScore > 0.75 && resultScore < 1)
                pinjia = 3;
            else if (resultScore == 1)
                pinjia = 4;

            return pinjia;
        }

        //第三个指标：子式运算数出现个数占总运算数个数
        public double zhibiao3(AAAAData queryZiShi, FinalNode1 bnode)//这里是结果表达式对应二叉树的根结点
        {
            double a = 0;
            double resultScore = 0;
            String[] result = queryZiShi.str.Split('#').Distinct().ToArray();
            String newsss = string.Join("#", result);
            String[] newss = newsss.Split('#');
            String[] news;
            String strs = "";
            foreach (var it in newss)
            {
                if (!isOperator(Convert.ToString(it)))
                {
                    strs = strs + it + "#";
                }
            }
            strs = strs.TrimEnd('#');
            news = strs.Split('#');


            String[] newresult;
            String resultList = Test5(bnode);//这里是结果表达式的层次遍历用#号隔开
            String strss = "";
            foreach (var it in resultList.Split('#'))
            {
                if (!isOperator(Convert.ToString(it)))
                {
                    strss = strss + it + "#";
                }
            }
            strss = strss.TrimEnd('#');
            newresult = strss.Split('#');
            foreach (var it in news)
            {
                foreach (var itt in newresult)
                {
                    if (Convert.ToString(it).Equals(Convert.ToString(itt)))
                    {
                        a++;
                    }
                }
            }
            resultScore = a / Convert.ToDouble(newresult.Count());

            double pinjia = -4;

            if (resultScore == 0)
                pinjia = -4;
            else if (resultScore > 0 && resultScore < 0.25)
                pinjia = -3;
            else if (resultScore == 0.25)
                pinjia = -2;
            else if (resultScore > 0.25 && resultScore < 0.5)
                pinjia = -1;
            else if (resultScore == 0.5)
                pinjia = 0;
            else if (resultScore > 0.5 && resultScore < 0.75)
                pinjia = 1;
            else if (resultScore == 0.75)
                pinjia = 2;
            else if (resultScore > 0.75 && resultScore < 1)
                pinjia = 3;
            else if (resultScore == 1)
                pinjia = 4;

            return pinjia;
        }

        //第四个指标：子式层次
        public double zhibiao4(AAAAData queryZiShi, String QueryOrResultLaTeX)//这里是结果表达式对应二叉树的根结点
        {

            double resultScore;
            double a;
            double b;
            //返回子在二叉树的最低层次
            a = ZiShiBTlevel(queryZiShi, QueryOrResultLaTeX);
            //返回最大层次
            b = MaxBTLevel(QueryOrResultLaTeX);

            resultScore = 1 - a / b;

            double pinjia = -4;

            if (resultScore == 0)
                pinjia = -4;
            else if (resultScore > 0 && resultScore < 0.25)
                pinjia = -3;
            else if (resultScore == 0.25)
                pinjia = -2;
            else if (resultScore > 0.25 && resultScore < 0.5)
                pinjia = -1;
            else if (resultScore == 0.5)
                pinjia = 0;
            else if (resultScore > 0.5 && resultScore < 0.75)
                pinjia = 1;
            else if (resultScore == 0.75)
                pinjia = 2;
            else if (resultScore > 0.75 && resultScore < 1)
                pinjia = 3;
            else if (resultScore == 1)
                pinjia = 4;

            return pinjia;
        }

        //第五个指标：子式空间标志位
        public double zhibiao5(AAAAData queryZiShi, String QueryOrResultLaTeX)
        {
            double FlagBest;
            double a;
            double b;
            //返回子式在数学表达式的最好的空间标志位
            FlagBest = ZiShiFlag(queryZiShi, QueryOrResultLaTeX);

            //Console.WriteLine("zhibiao5："+FlagBest);
            double pinjia = -4;

            if (FlagBest == 0)
                pinjia = 4;

            else if (FlagBest == 6)
                pinjia = -1;

            else if (FlagBest == 1)
                pinjia = 3;

            else if (FlagBest == 5)
                pinjia = 2;

            else if (FlagBest == 2)
                pinjia = 1;

            else if (FlagBest == 4)
                pinjia = 0;

            else if (FlagBest == 7)
                pinjia = -2;

            else if (FlagBest == 8)
                pinjia = -3;

            return pinjia;

        }

        public double ZiShiFlag(AAAAData node, String QueryOrResultLaTeX)
        {
            //首先获取不管是查询表达式还是结果表达式的“字符串”
            List<AAAAData> List = new List<AAAAData>();
            List = Test444(QueryOrResultLaTeX);

            double maxFlagValue = 0;//记录Flag值的最大值
            foreach (var it in List)
            {
                //遍历整个二叉树的节点，和整个二叉树的每一个节点一个一个去比
                //如果第一次找到相同的子式的话
                if (node.str.Equals(it.str))
                {
                    if ( FlagValue(it.Flag) > maxFlagValue)
                    {  
                        //Console.WriteLine("ZiShiFlag：子式位：" + node.str);
                        //Console.WriteLine("ZiShiFlag："+it.Flag);
                        maxFlagValue = FlagValue(it.Flag);
                    }
                }
            }

            double pinjia = 0;
            if (maxFlagValue == 1)
                pinjia = 0;
            else if (maxFlagValue == 0.7)
                pinjia = 1;
            else if (maxFlagValue == 0.55)
                pinjia = 2;
            else if (maxFlagValue == 0.3)
                pinjia = 4;
            else if (maxFlagValue == 0.7)
                pinjia = 5;
            else if (maxFlagValue == 0.75)
                pinjia = 6;
            else if (maxFlagValue == 0.25)
                pinjia = 7;
            else if (maxFlagValue == 0.25)
                pinjia = 8;
            return pinjia;

        }

        public double FlagValue(double flag)
        {
            double pinjia = 0;
            if (flag == 0)
                pinjia = 1;
            else if (flag == 1)
                pinjia = 0.7;
            else if (flag == 2)
                pinjia = 0.55;
            else if (flag == 4)
                pinjia = 0.3;
            else if (flag == 5)
                pinjia = 0.7;
            else if (flag == 6)
                pinjia = 0.75;
            else if (flag == 7)
                pinjia = 0.25;
            else if (flag == 8)
                pinjia = 0.25;
            return pinjia;

        }

        public List<AAAAData> Test444(String LaTeX)
        {
            //开始层次遍历
            List<AAAAData> list = new List<AAAAData>();
            BinaryTreeNode bnode = new BinaryTreeNode();
            FinalNode1 root = new FinalNode1();
            FinalNode1 tempNode = new FinalNode1();

            root = bnode.getNode(LaTeX);


            //Console.WriteLine("来看看第一个节点：" + root.zifu);

            root.xuhao = 1;
            tempNode = root;//临时指向根结点
            Queue<FinalNode1> q = new Queue<FinalNode1>();
            q.Enqueue(root);

            //Console.WriteLine("下一个来看看第一个节点：" + q.First().zifu);

            while (q.Count != 0)
            {
                //指向队列第一个字符
                tempNode = q.First();



                //Console.WriteLine("什么鬼啊下下一个来看看第一个节点：" + tempNode.zifu);

                //下面这个再加个判断就行了就是if(tempNode.left == null && tempNode.right == null),tempNode就是出队节点


                //=======！！！！！！！！！！！！！！这里注意：因为有根号的了，所以不能直接判断左右为空，而我根号默认是左节点！！！！！！！！！！！！！！！！！
                if ((tempNode.left != null && tempNode.right != null) || (tempNode.left != null && tempNode.right == null))
                {
                    AAAAData data = new AAAAData();
                    data.BTLevel = tempNode.BTreeLevel;
                    data.str = Test555(tempNode);
                    data.Flag = tempNode.Flag;
                    list.Add(data);

                    //Console.WriteLine("这里应该是根号：" + tempNode.zifu);
                }


                //第一个节点出队
                q.Dequeue();

                if (tempNode.left != null)
                {
                    tempNode.left.xuhao = tempNode.xuhao * 2;
                    //Console.WriteLine("++++++++++++++left" + tempNode.left.xuhao);
                    q.Enqueue(tempNode.left);
                }
                if (tempNode.right != null)
                {
                    tempNode.right.xuhao = tempNode.xuhao * 2 + 1;
                    //Console.WriteLine("++++++++++++++" + tempNode.right.xuhao);
                    q.Enqueue(tempNode.right);
                }

            }

            return list;

        }

        //对于每一个节点，返回其层次遍历序列，该序列代表一个子式，该序列也可以唯一确定一个子式
        public String Test555(FinalNode1 bnode)
        {
            //开始层次遍历

            FinalNode1 root = new FinalNode1();
            FinalNode1 tempNode = new FinalNode1();

            //下面这个是层次遍历字符串，唯一代表一个子式
            String str = "";


            //root = bnode.getNode(LaTeX);
            root = bnode;

            //Console.WriteLine("了："+root.zifu);


            tempNode = root;//临时指向根结点
            Queue<FinalNode1> q = new Queue<FinalNode1>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                //指向队列第一个字符
                tempNode = q.First();

                str = str + tempNode.zifu + "#";



                //第一个节点出队
                q.Dequeue();

                if (tempNode.left != null)
                {
                    tempNode.left.xuhao = tempNode.xuhao * 2;
                    //Console.WriteLine("++++++++++++++left" + tempNode.left.xuhao);
                    q.Enqueue(tempNode.left);
                }
                if (tempNode.right != null)
                {
                    tempNode.right.xuhao = tempNode.xuhao * 2 + 1;
                    //Console.WriteLine("++++++++++++++" + tempNode.right.xuhao);
                    q.Enqueue(tempNode.right);
                }

            }
            //开始写了

            //百度了一下，把最后一个“#”号移除https://www.cnblogs.com/tianjifa/p/9207241.html
            str = str.TrimEnd('#');
            return str;
        }
        //=====================================第一：这里定义指标吧==============================


        //=====================================第二：开始输入接口吧==============================
        public void Start(String queryLaTeX)
        {
            //Console.WriteLine("1你全家============================");
            List<AAAAData> final = new List<AAAAData>();
            //===================================（1）先算查询表达式每一个子式在该二叉树中的犹豫模糊语言术语集=================
            List<double> queryYouYu = new List<double>();
            List<AAAAData> queryzishiList = new List<AAAAData>();




            queryzishiList = Test4(queryLaTeX);
            BinaryTreeNode bnode = new BinaryTreeNode();
            FinalNode1 root = new FinalNode1();
            root = bnode.getNode(queryLaTeX);//完整数学表达式的根结点
            foreach (var it in queryzishiList)
            {
                queryYouYu.Add(zhibiao1(it,queryzishiList));
                queryYouYu.Add(zhibiao2(it,root));
                queryYouYu.Add(zhibiao3(it, root));
                queryYouYu.Add(zhibiao4(it, queryLaTeX));
                queryYouYu.Add(zhibiao5(it, queryLaTeX));
            }
            //===================================（1）先算查询表达式每一个子式在该二叉树中的犹豫模糊语言术语集=================
            
            List<String> ResultLaTeXList = new List<String>();
            List<AAAAData> Final = new List<AAAAData>();
            Console.WriteLine("2你全家============================");
            ResultLaTeXList = getResultLaTeXList(queryLaTeX);

            //foreach (var it in ResultLaTeXList)
            //{
            //    Console.WriteLine("=================不听的======================"+it);

            //}


            //======================================第二步：排序时间的测量=====================================================================
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间


            //遍历结果表达式
            foreach (var it in ResultLaTeXList)
            {
                List<AAAAData> resultzishiList = new List<AAAAData>();
                resultzishiList = Test4(it);
                root = bnode.getNode(it);//完整数学表达式的根结点
                List<double> resultYouYu = new List<double>();
                //对于每一个结果表达式，计算每一个查询子式在结果表达式里面的犹豫模糊语言术语
                foreach (var itt in queryzishiList)
                {
                    resultYouYu.Add(zhibiao1(itt, resultzishiList));
                    resultYouYu.Add(zhibiao2(itt, root));
                    resultYouYu.Add(zhibiao3(itt, root));
                    resultYouYu.Add(zhibiao4(itt, it));
                    resultYouYu.Add(zhibiao5(itt, it));
                }
                AAAAData d = new AAAAData();
                d.Score = Compute(queryYouYu,resultYouYu);
                d.LaTeX = it;
                final.Add(d);
            }

            finalSort(final);

            stopwatch.Stop(); //  停止监视

            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            double hours = timespan.TotalHours; // 总小时
            double minutes = timespan.TotalMinutes;  // 总分钟
            double seconds = timespan.TotalSeconds;  //  总秒数
            double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数

            string timePast = "耗时" + seconds + "秒，即" + milliseconds + "毫秒！";

            Console.WriteLine("========================================第二步：排序时间为：" + timePast);


        }
        //=====================================第二：开始输入接口吧==============================

        //=====================================第三：计算两个犹豫模糊语言术语集====================================
        public double Compute(List<double> queryYouYu, List<double> resultYouYu)
        {
            double tempdata;
            //for (int i = 0; i < queryYouYu.Count - 1; i++)
            //{
            //    for (int j = i + 1; j < queryYouYu.Count; j++)
            //    {
            //        if (queryYouYu[j] < queryYouYu[i])
            //        {
            //            tempdata = queryYouYu[j];
            //            queryYouYu[j] = queryYouYu[i];
            //            queryYouYu[i] = tempdata;
            //        }
            //    }
            //}

            //for (int i = 0; i < resultYouYu.Count - 1; i++)
            //{
            //    for (int j = i + 1; j < resultYouYu.Count; j++)
            //    {
            //        if (resultYouYu[j] < resultYouYu[i])
            //        {
            //            tempdata = resultYouYu[j];
            //            resultYouYu[j] = resultYouYu[i];
            //            resultYouYu[i] = tempdata;
            //        }
            //    }
            //}

            double sum = 0;
            for (int k = 0; k < queryYouYu.Count; k++)
            {
                sum = sum + (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9); // 拉姆达=1
                //sum = sum + (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9) * (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9); // 拉姆达=2
                //sum = sum + (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9) * (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9) * (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9); // 拉姆达=3
                //sum = sum + (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9) * (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9) * (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9) * (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9); // 拉姆达=4
                //sum = sum + (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9) * (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9) * (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9) * (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9) * (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9); // 拉姆达=5
                //Console.WriteLine("尼玛死了："+ (Math.Abs(queryYouYu[k] - resultYouYu[k]) / 9));
            }
            sum = sum / Convert.ToDouble(queryYouYu.Count);
            //sum = Math.Sqrt(sum);// 拉姆达=2

            sum = 1 - sum;
            return sum;
        }
        //=====================================第三：计算两个犹豫模糊语言术语集====================================

        //=====================================第四个：排序==================
        public void finalSort(List<AAAAData> final)
        {
            AAAAData tempdata;
            for (int i = 0; i < final.Count - 1; i++)
            {
                for (int j = i + 1; j < final.Count; j++)
                {
                    if (final[j].Score > final[i].Score)
                    {
                        tempdata = final[j];
                        final[j] = final[i];
                        final[i] = tempdata;
                    }
                }
            }

            foreach (var it in final)
            {
                Console.WriteLine("数学表达式："+it.LaTeX + "\t" + "分数："+ it.Score);
            }


        }
        //=====================================第四个：排序==================









        public void Test2(String queryLaTeX)
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\1.txt", Encoding.Default);
            String read = sr.ReadLine();

            List<AAAAData> Final = new List<AAAAData>();
            while (read != null)
            {
                //获取子式
                ChildrenBTree children = new ChildrenBTree();
                Dictionary<int, List<FinalNode1>> aaa = new Dictionary<int, List<FinalNode1>>();
                aaa = children.childrenBTree(read);

                String strs = "";

                //Console.WriteLine("草拟吗："+read);


                foreach (var aaaa in aaa)
                {
                    //每一个子式
                    String str = "";

                    foreach (var aaaaa in aaaa.Value)
                    {
                        str = str + aaaaa.zifu;
                    }



                    Dictionary<int, List<FinalNode1>> dics = new Dictionary<int, List<FinalNode1>>();
                    AAAA A = new AAAA();
                    dics = A.BTLevelScore(str, read);
                    if (dics == null || dics.Count == 0)
                    {
                        //Console.WriteLine("草擦曹操");
                        read = sr.ReadLine();
                        continue;
                    }
                    //下面这个是统计查询表达式a+b，在结果表达式a+b+c+a+b，的两个a+b的最小树的层次啊

                    foreach (var it in dics)
                    {
                        //Console.WriteLine("键值：" + it.Key);
                        int min = 10000;
                        foreach (var itt in it.Value)
                        {
                            if (itt.BTreeLevel < min)
                            {
                                min = itt.BTreeLevel;
                            }
                            //Console.WriteLine(itt.zifu+"\t"+itt.BTreeLevel);
                        }
                        strs = strs + min + "#";
                    }


                }


                //=============================
                //统计一下负数的那个，树的高度越高，它的负值越大，负的越厉害。注意现在统计的是结果表达式的最大高度，也就是read
                int fushu = 0;
                int maxBTLevel = 0;
                List<FinalNode1> lists = new List<FinalNode1>();
                AdjacentNode aa = new AdjacentNode();
                lists = aa.AdjacentNodeList(read);
                foreach (var it in lists)
                {
                    if (it.BTreeLevel > fushu)
                        fushu = it.BTreeLevel;
                }

                fushu = (-1) * fushu;
                strs = strs + fushu + "#" + read;
                //Console.WriteLine(str);
                //已经得到一个查询表达式在结果表达式里面的层次级别了，开始计算分数了
                String[] news = strs.Split('#');
                List<int> list = new List<int>();
                for (int i = 0; i < news.Length - 1; i++)
                {
                    list.Add(Convert.ToInt32(news[i]));
                    //Console.WriteLine("草："+news[i]);
                }
                //开始排序
                int tempdata;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[j] < list[i])
                        {
                            tempdata = list[j];
                            list[j] = list[i];
                            list[i] = tempdata;
                        }
                    }
                }
                //开始利用公式计算
                double sum = 0;
                for (int i = 0; i < news.Length - 1; i++)
                {
                    sum = sum + Math.Abs(19 - (20 - Convert.ToDouble(news[i]))) / (19);
                    //Console.WriteLine("看看结果："+sum);
                }
                sum = sum / (news.Length - 1);
                AAAAData d = new AAAAData();
                d.BTLevel = 1 - sum;
                d.str = read;
                Final.Add(d);


                //=============================



                read = sr.ReadLine();
            }






            //开始排序
            AAAAData tempdatas;
            for (int i = 0; i < Final.Count - 1; i++)
            {
                for (int j = i + 1; j < Final.Count; j++)
                {
                    if (Final[j].BTLevel > Final[i].BTLevel)
                    {
                        tempdatas = Final[j];
                        Final[j] = Final[i];
                        Final[i] = tempdatas;
                    }
                }
            }
            foreach (var it in Final)
            {
                Console.WriteLine("公式为：" + it.str + "\t" + "相似度为：" + it.BTLevel);
            }


        }



        //下面是插入索引表
        public void insertIndex()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\1.txt", Encoding.Default);
            String read = sr.ReadLine();

            int count = 0;


            //为每一个数学公式分配一个Id
            int ExpId = 0;
            //第一步：开始读取每一个数学表达式了啊



            while (read != null)
            {
                count++;

                bool panduan;
                string sqlstr = "insert into Test44(数学表达式,子式所在高度) values ('" + read + "','" + count + "')";
                panduan = DBhelper.InsertUpdateDal(sqlstr);
                read = sr.ReadLine();
            }




        }



        ////我把第一篇论文的实验数据的子式写入数据库吧
        //public void Test3()
        //{
        //    //         LaTeX，子式节点
        //    Dictionary<AAAAData, List<String>> dic = new Dictionary<AAAAData, List<String>>();
        //    StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\1.txt", Encoding.Default);
        //    String read = sr.ReadLine();
        //    //第一步：开始读取每一个数学表达式了啊
        //    while (read != null)
        //    {
        //        //第二步：直接构成倒排索引吧，省的以后要是有重复的数学表达式啥的
        //        //对于输入进来的每一个数学公式，把它解析为各个子式
        //        List<AAAAData> li = new List<AAAAData>();
        //        li = Test4(read);
        //        int biaozhi = 0;//每进来一个子式，就记作一个标志
        //        //对于每一个子式节点，我需要插入字典，作为倒排索引
        //        foreach (var it in li)
        //        {
        //            //if (dic.Count == 0)
        //            //{
        //            //    List<String> list = new List<string>();
        //            //    list.Add(read);
        //            //    dic.Add(it,list);
        //            //    Console.WriteLine("第一个if");
        //            //}
        //            //else
        //            //{
        //            //    //我去遍历字典的键值对象
        //            //    foreach (var zidian in dic)
        //            //    {
        //            //        //如果字典里面的倒排索引有某一个子式了
        //            //        if (zidian.Key.Equals(it) && (biaozhi == 0))
        //            //        {
        //            //            Console.WriteLine("第二个if");
        //            //            dic[zidian.Key].Add(read);
        //            //            biaozhi++;
        //            //        }
        //            //        else if(!zidian.Key.Equals(it))
        //            //        {
        //            //            List<String> list = new List<string>();
        //            //            list.Add(read);
        //            //            dic.Add(it, list);
        //            //        }
        //            //    }
        //            //}
        //            //==========================================================
        //            if (dic.Count == 0)
        //            {
        //                List<String> list = new List<string>();
        //                list.Add(read);
        //                dic.Add(it, list);
        //                continue;
        //            }
        //            int a = 0;//这是个判断标志，下面开始遍历，如果找到，那么a=1，没找到a=0
        //            AAAAData tempKey = null;//定义临时键存储文件名字
        //            foreach (var item in dic)
        //            {
        //                if (item.Key.Equals(it))
        //                {
        //                    a = 1;
        //                    tempKey = item.Key;//其实不用定义,因为如果找到，indexes.FileName与item.Key相等，下面那个“[]中括号”找谁不都一样么，多此一举
        //                    break;//一旦找到说明找到了，那么就可以终止了，此时等于一加个break，否则又出bug了
        //                }
        //            }
        //            if (a == 1)//说明找到了
        //            {
        //                dic[tempKey].Add(read);
        //            }
        //            else if (a == 0)//说明没找到
        //            {
        //                List<String> list = new List<string>();
        //                list.Add(read);
        //                dic.Add(it, list);
        //            }
        //            //==========================================================
        //        }//循环里面
        //        read = sr.ReadLine();
        //    }
        //    ////这里把数据倒排插入数据库
        //    //bool panduan;
        //    //string sqlstr = "insert into Test1(子式,子式所在高度,数学表达式) values ('" + node + "','" + filename + "','" + path + "')";
        //    //panduan = DBhelper.InsertUpdateDal(sqlstr);
        //    //if (panduan == true)
        //    //{
        //    //    Console.Write("操作成功");
        //    //}
        //    //else
        //    //{
        //    //    Console.Write("操作失败");
        //    //}
        //}








        //我先试一试获取数学表达式子式



        public List<AAAAData> Test4(String LaTeX)
        {
            //开始层次遍历
            List<AAAAData> list = new List<AAAAData>();
            BinaryTreeNode bnode = new BinaryTreeNode();
            FinalNode1 root = new FinalNode1();
            FinalNode1 tempNode = new FinalNode1();

            root = bnode.getNode(LaTeX);


            //Console.WriteLine("来看看第一个节点：" + root.zifu);

            root.xuhao = 1;
            tempNode = root;//临时指向根结点
            Queue<FinalNode1> q = new Queue<FinalNode1>();
            q.Enqueue(root);

            //Console.WriteLine("下一个来看看第一个节点：" + q.First().zifu);

            while (q.Count != 0)
            {
                //指向队列第一个字符
                tempNode = q.First();



                //Console.WriteLine("什么鬼啊下下一个来看看第一个节点：" + tempNode.zifu);

                //下面这个再加个判断就行了就是if(tempNode.left == null && tempNode.right == null),tempNode就是出队节点


                //=======！！！！！！！！！！！！！！这里注意：因为有根号的了，所以不能直接判断左右为空，而我根号默认是左节点！！！！！！！！！！！！！！！！！
                if ((tempNode.left != null && tempNode.right != null) || (tempNode.left != null && tempNode.right == null))
                {
                    AAAAData data = new AAAAData();
                    data.BTLevel = tempNode.BTreeLevel;
                    data.str = Test5(tempNode);
                    list.Add(data);

                    //Console.WriteLine("这里应该是根号：" + tempNode.zifu);
                }


                //第一个节点出队
                q.Dequeue();

                if (tempNode.left != null)
                {
                    tempNode.left.xuhao = tempNode.xuhao * 2;
                    //Console.WriteLine("++++++++++++++left" + tempNode.left.xuhao);
                    q.Enqueue(tempNode.left);
                }
                if (tempNode.right != null)
                {
                    tempNode.right.xuhao = tempNode.xuhao * 2 + 1;
                    //Console.WriteLine("++++++++++++++" + tempNode.right.xuhao);
                    q.Enqueue(tempNode.right);
                }

            }

            return list;

        }

        //对于每一个节点，返回其层次遍历序列，该序列代表一个子式，该序列也可以唯一确定一个子式
        public String Test5(FinalNode1 bnode)
        {
            //开始层次遍历

            FinalNode1 root = new FinalNode1();
            FinalNode1 tempNode = new FinalNode1();

            //下面这个是层次遍历字符串，唯一代表一个子式
            String str = "";


            //root = bnode.getNode(LaTeX);
            root = bnode;

            //Console.WriteLine("了："+root.zifu);


            tempNode = root;//临时指向根结点
            Queue<FinalNode1> q = new Queue<FinalNode1>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                //指向队列第一个字符
                tempNode = q.First();

                str = str + tempNode.zifu + "#";



                //第一个节点出队
                q.Dequeue();

                if (tempNode.left != null)
                {
                    tempNode.left.xuhao = tempNode.xuhao * 2;
                    //Console.WriteLine("++++++++++++++left" + tempNode.left.xuhao);
                    q.Enqueue(tempNode.left);
                }
                if (tempNode.right != null)
                {
                    tempNode.right.xuhao = tempNode.xuhao * 2 + 1;
                    //Console.WriteLine("++++++++++++++" + tempNode.right.xuhao);
                    q.Enqueue(tempNode.right);
                }

            }
            //开始写了

            //百度了一下，把最后一个“#”号移除https://www.cnblogs.com/tianjifa/p/9207241.html
            str = str.TrimEnd('#'); 
            return str;
        }



        public List<AAAAData> Test44(String LaTeX)
        {
            //开始层次遍历
            List<AAAAData> list = new List<AAAAData>();
            BinaryTreeNode bnode = new BinaryTreeNode();
            FinalNode1 root = new FinalNode1();
            FinalNode1 tempNode = new FinalNode1();

            root = bnode.getNode(LaTeX);


            //Console.WriteLine("来看看第一个节点：" + root.zifu);

            root.xuhao = 1;
            tempNode = root;//临时指向根结点
            Queue<FinalNode1> q = new Queue<FinalNode1>();
            q.Enqueue(root);

            //Console.WriteLine("下一个来看看第一个节点：" + q.First().zifu);

            while (q.Count != 0)
            {
                //指向队列第一个字符
                tempNode = q.First();



                //Console.WriteLine("什么鬼啊下下一个来看看第一个节点：" + tempNode.zifu);

                //下面这个再加个判断就行了就是if(tempNode.left == null && tempNode.right == null),tempNode就是出队节点


                //=======！！！！！！！！！！！！！！这里注意：因为有根号的了，所以不能直接判断左右为空，而我根号默认是左节点！！！！！！！！！！！！！！！！！
                if ((tempNode.left != null && tempNode.right != null) || (tempNode.left != null && tempNode.right == null))
                {
                    AAAAData data = new AAAAData();
                    data.BTLevel = tempNode.BTreeLevel;
                    data.str = Test55(tempNode);
                    list.Add(data);

                    //Console.WriteLine("这里应该是根号：" + tempNode.zifu);
                }


                //第一个节点出队
                q.Dequeue();

                if (tempNode.left != null)
                {
                    tempNode.left.xuhao = tempNode.xuhao * 2;
                    //Console.WriteLine("++++++++++++++left" + tempNode.left.xuhao);
                    q.Enqueue(tempNode.left);
                }
                if (tempNode.right != null)
                {
                    tempNode.right.xuhao = tempNode.xuhao * 2 + 1;
                    //Console.WriteLine("++++++++++++++" + tempNode.right.xuhao);
                    q.Enqueue(tempNode.right);
                }

            }

            return list;

        }

        //对于每一个节点，返回其层次遍历序列，该序列代表一个子式，该序列也可以唯一确定一个子式
        public String Test55(FinalNode1 bnode)
        {
            //开始层次遍历

            FinalNode1 root = new FinalNode1();
            FinalNode1 tempNode = new FinalNode1();

            //下面这个是层次遍历字符串，唯一代表一个子式
            String str = "";


            //root = bnode.getNode(LaTeX);
            root = bnode;

            //Console.WriteLine("了："+root.zifu);


            tempNode = root;//临时指向根结点
            Queue<FinalNode1> q = new Queue<FinalNode1>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                //指向队列第一个字符
                tempNode = q.First();

                str = str + tempNode.zifu;



                //第一个节点出队
                q.Dequeue();

                if (tempNode.left != null)
                {
                    tempNode.left.xuhao = tempNode.xuhao * 2;
                    //Console.WriteLine("++++++++++++++left" + tempNode.left.xuhao);
                    q.Enqueue(tempNode.left);
                }
                if (tempNode.right != null)
                {
                    tempNode.right.xuhao = tempNode.xuhao * 2 + 1;
                    //Console.WriteLine("++++++++++++++" + tempNode.right.xuhao);
                    q.Enqueue(tempNode.right);
                }

            }
            //开始写了

            return str;
        }



        //这个就开始了,从这输入查询表达式，得到包含查询表达式子式的所有结果表达式
        public List<String> getResultLaTeXList(String queryLaTeX)
        {

            //======================================第一步：检索时间的测量=====================================================================
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间






            //第一步：首先得获取查询表达式的所有子式及其对应层次，然后放入一个集合当中
            List<AAAAData> li = new List<AAAAData>();
            li = Test44(queryLaTeX);

            List<String> resultLaTeXList = new List<string>();

            List<String> tempList = new List<string>();

            //=========这个是第一个子式=============================
            tempList.Add(li[0].str);

            //！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！这里的这个表名字Test6需要改的！！！！！！！！！！！！！！！！！！！！！！！！！

            string sqlstr = " select distinct(数学表达式) from AA where 子式 = '" + li[0].str + "'";
            DataSet ds = new DataSet();
            ds = DBhelper.GetDataSet(sqlstr);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                resultLaTeXList.Add(row["数学表达式"].ToString().Trim());
            }
            //==========这个是第二个子式============================

            //第二步：把包含查询表达式所有子表达式的所有结果表达式提取出来，先提取出来吧
            for (int i = 1; i < li.Count; i++)
            {
                int biaozhi = 0;//每一个子式进来了，都要设置一个标志看看有没有和它一样的
                //遍历已经访问过的子式集合，看看有没有重复的子式
                foreach (var it in tempList)
                {
                    if (li[i].str.Equals(it))//如果出现重复了
                    {
                        biaozhi = 1;
                        break;
                    }
                }

                if (biaozhi == 0)//说明没有出现重复了，你染没有重复，那就读取对应的结果表达式
                {
                    //！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！这里的这个表名字Test6需要改的！！！！！！！！！！！！！！！！！！！！！
                    sqlstr = " select distinct(数学表达式) from AA where 子式 = '" + li[i].str + "'";
                    ds = DBhelper.GetDataSet(sqlstr);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        resultLaTeXList.Add(row["数学表达式"].ToString().Trim());
                    }
                }

            }

            //=============打印输出一下结果表达式=================

            //foreach (var it in resultLaTeXList)
            //{
            //    Console.WriteLine("总个数为：" + resultLaTeXList.Count);
            //    Console.WriteLine("打印输出一下："+it);
            //}

            //==============打印输出一下结果表达式================


            //======================================第一步：检索时间的测量=====================================================================
            stopwatch.Stop(); //  停止监视

            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            double hours = timespan.TotalHours; // 总小时
            double minutes = timespan.TotalMinutes;  // 总分钟
            double seconds = timespan.TotalSeconds;  //  总秒数
            double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数

            string timePast = "耗时" + seconds + "秒，即" + milliseconds + "毫秒！";

            Console.WriteLine("========================================第一步：检索时间为：" + timePast);



            return resultLaTeXList;

        }


        public void sort(String queryLaTeX)
        {

            //=========用来判断节点个数==============
            AdjacentNode anode = new AdjacentNode();
            //=========用来判断节点个数==============

            //Console.WriteLine("草拟吗了");

            //======================================第二步：排序时间的测量=====================================================================
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间




            //第一步：获取查询表达式的所有子式集合
            List<AAAAData> queryLaTeXList = new List<AAAAData>();
            queryLaTeXList = Test4(queryLaTeX);

            //第二步：获取所有结果表达式集合（字符串）
            List<String> resultLaTeXList = new List<string>();
            resultLaTeXList = getResultLaTeXList(queryLaTeX);

            //第三步：开始对查询表达式和每一个结果表达式进行打分,那就遍历每一个结果表达式吧

            //======================！！！！！“查询表达式”的各个子式的分数依次是固定的==========================
            List<double> queryScore = new List<double>();
            foreach (var queryZiShi in queryLaTeXList)
            {
                queryScore.Add(ZiShiBTlevel(queryZiShi, queryLaTeX));
            }
            //======================！！！！！“查询表达式”的各个子式的分数依次是固定的==========================

            //======================放结果的最终需要排序的==========================================
            List<AAAAData> FinalList = new List<AAAAData>();
            //======================放结果的最终需要排序的==========================================

            foreach (var resultLaTeX in resultLaTeXList)
            {



                //===================！！！！！对于每一个结果表达式，肯定也对应一个分数集合吧=====================
                List<double> resultScore = new List<double>();
                foreach (var queryZiShiNode in queryLaTeXList)
                {
                    if (ZiShiBTlevel(queryZiShiNode, resultLaTeX.ToLower()) == 1000)//说明结果表达式不存在查询子式
                    {
                        //resultScore.Add(-(queryZiShiNode.BTLevel+1));

                        //这里没有的话我就弱化一下吧
                        resultScore.Add(-queryZiShiNode.BTLevel);
                    }
                    else
                    {
                        resultScore.Add(ZiShiBTlevel(queryZiShiNode, resultLaTeX.ToLower()));
                    }
                }
                //===================！！！！！对于每一个结果表达式，肯定也对应一个分数集合吧=====================


                //==================================开始查询与结果计算评分=====================================
                //开始利用公式计算

                double sum = 0;

                for (int k = 0; k < queryScore.Count; k++)
                {
                    //sum = sum + Math.Abs((14 - queryScore[k]) - (14 - resultScore[k])) / (27 - Min(14 - queryScore[k], 14 - resultScore[k]));

                    //sum = sum + Math.Abs((14 - queryScore[k]) - (14 - resultScore[k])) / (27); // 拉姆达=1

                    sum = sum + ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)) * ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)); // 拉姆达=2

                    //sum = sum + ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)) * ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)) * ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)); // 拉姆达=3

                    //sum = sum + ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)) * ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)) * ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)) * ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)); // 拉姆达=4

                    //sum = sum + ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)) * ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)) * ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)) * ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)) * ((Math.Abs((14 - queryScore[k]) - (14 - resultScore[k]))) / (27)); // 拉姆达=5
                }

                //=====================在这里起码补充一下查询树和结果树之间的差距的距离吧？？？？？？？？？？？？===========================
                //sum = sum + Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower())) / (27 - Min(14 - MaxBTLevel(queryLaTeX), 14 - MaxBTLevel(resultLaTeX.ToLower())));

                //sum = sum + Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower())) / (27); //拉姆达=1

                sum = sum + ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)) * ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)); //拉姆达=2

                //sum = sum + ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)) * ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)) * ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)); //拉姆达=3

                //sum = sum + ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)) * ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)) * ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)) * ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)); //拉姆达=4

                //sum = sum + ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)) * ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)) * ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)) * ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)) * ((Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower()))) / (27)); //拉姆达=5


                //这里是节点个数不咋地
                //sum = sum + Math.Abs(anode.AdjacentNodeList(queryLaTeX).Count - anode.AdjacentNodeList(resultLaTeX.ToLower()).Count) / (27);
                //=====================在这里起码补充一下查询树和结果树之间的差距的距离吧？？？？？？？？？？？？===========================


                //=====================这里我想连接一下查询表达式各个分数和结果表达式分数
                String queryStr = "";
                foreach (var it in queryScore)
                {
                    queryStr = queryStr + it + "#";

                }
                queryStr = queryStr + MaxBTLevel(queryLaTeX);
                String resultStr = "";
                foreach (var it in resultScore)
                {
                    resultStr = resultStr + it + "#";

                }
                resultStr = resultStr + MaxBTLevel(resultLaTeX.ToLower());

                //=====================这里我想连接一下查询表达式各个分数和结果表达式分数




                //==================================开始查询与结果计算评分=====================================

                //==================把打好分的结果以节点形式放入一个集合当中===========================
                AAAAData data = new AAAAData();
                sum = sum / (queryScore.Count + 1);//？？？？？？？？？？？？？？？？？？？？？？这里加1也不对啊？？？？？？？？？？？？？？？？？？？？？？
                //data.BTLevel = 1 - sum;//拉姆达=1

                data.BTLevel = 1 - Math.Sqrt(sum);//拉姆达=2

                //data.BTLevel = 1 - Math.Pow(sum,0.3333333333);//拉姆达=3
                //data.BTLevel = 1 - Math.Pow(sum,0.25);//拉姆达=4

                //data.BTLevel = 1 - Math.Pow(sum, 0.2);//拉姆达=5

                data.str = resultLaTeX;
                data.queryStr = queryStr;
                data.resultStr = resultStr;
                FinalList.Add(data);
                //==================把打好分的结果以节点形式放入一个集合当中===========================


            }

            //======================对最终结果进行排序======================
            AAAAData tempdata;
            for (int i = 0; i < FinalList.Count - 1; i++)
            {
                for (int j = i + 1; j < FinalList.Count; j++)
                {
                    if (FinalList[j].BTLevel > FinalList[i].BTLevel)
                    {
                        tempdata = FinalList[j];
                        FinalList[j] = FinalList[i];
                        FinalList[i] = tempdata;
                    }
                }
            }
            //======================对最终结果进行排序======================


            //======================打印输出================================
            //foreach (var it in FinalList)
            //{
            //    Console.WriteLine("结果表达式："+it.str + "\t" + "查询表达式打分：" + it.queryStr + "\t" + "结果表达式打分：" + it.resultStr + "\t" + "相似度得分为：" + it.BTLevel);

            //}


            //===========我想去个重==================
            List<AAAAData> quchong = new List<AAAAData>();
            foreach (var it in FinalList)
            {
                if (quchong.Count == 0)
                {
                    quchong.Add(it);
                }
                else
                {
                    int biaozhi = 0;
                    foreach (var itt in quchong)
                    {
                        if (it.str.Equals(itt.str))//如果出现重复了
                        {
                            biaozhi = 1;
                            break;
                        }
                    }

                    if (biaozhi == 0)//说明没有出现重复了，你染没有重复，那就读取对应的结果表达式
                    {
                        quchong.Add(it);
                    }
                }

            }

            int counttt = 1;
            foreach (var it in quchong)
            {
                if (it.str.Equals("\\frac{a+b}{2}\\geq\\sqrt{a*b}"))
                {


                }

                Console.WriteLine("==========================================================第" + counttt + "个====================================================");
                Console.WriteLine("结果表达式：" + it.str + "\t" + "查询表达式打分：" + it.queryStr + "\t" + "结果表达式打分：" + it.resultStr + "\t" + "相似度得分为：" + it.BTLevel);
                Console.WriteLine("");
                Console.WriteLine("");

                counttt++;
            }
            //===========我想去个重==================




            //======================打印输出================================

            //======================================第二步：排序时间的测量=====================================================================
            stopwatch.Stop(); //  停止监视

            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            double hours = timespan.TotalHours; // 总小时
            double minutes = timespan.TotalMinutes;  // 总分钟
            double seconds = timespan.TotalSeconds;  //  总秒数
            double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数

            string timePast = "耗时" + seconds + "秒，即" + milliseconds + "毫秒！";

            Console.WriteLine("========================================第二步：排序时间为：" + timePast);



        }



        //麻求烦的，直接写一个函数，判断子式（假如有重复子式）在二叉树中的高度吧，反正不管是查询表达式还是结果表达式，都得判断某个子式在二叉树的高度吗？
        public double ZiShiBTlevel(AAAAData node, String QueryOrResultLaTeX)
        {
            //首先获取不管是查询表达式还是结果表达式的“字符串”
            List<AAAAData> List = new List<AAAAData>();
            List = Test4(QueryOrResultLaTeX);

            double MinBTLevel = 1000;//记录最大高度 
            foreach (var it in List)
            {
                //遍历整个二叉树的节点，和整个二叉树的每一个节点一个一个去比
                //如果第一次找到相同的子式的话
                if (node.str.Equals(it.str))
                {
                    if (it.BTLevel < MinBTLevel)
                    {
                        MinBTLevel = it.BTLevel;
                    }
                }
            }

            //if (MinBTLevel == 1000)//如果这个值还是1000，说明根本没找到
            //{
            //    MinBTLevel = 38 - node.BTLevel;

            //}

            return MinBTLevel;

        }


        


        //找数学表达式二叉树最大高度
        public double MaxBTLevel(String QueryOrResultLaTeX)
        {
            List<AAAAData> List = new List<AAAAData>();
            List = Test4(QueryOrResultLaTeX);

            double MaxBTLevel = 0;//记录最大高度


            foreach (var it in List)
            {
                //遍历整个二叉树的节点，和整个二叉树的每一个节点一个一个去比

                if (it.BTLevel > MaxBTLevel)
                {
                    MaxBTLevel = it.BTLevel;
                }

            }

            return MaxBTLevel;

        }







        //=================这个是我把子式和数学表达式插入数据库=======================



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








        //这个没啥用
        public void practise()
        {
            AAAAData data1 = new AAAAData();
            data1.str = "张三";
            data1.BTLevel = 1;

            AAAAData data2 = new AAAAData();
            data2.str = "张三";
            data2.BTLevel = 2;

            //if (data1.Equals(data2))
            //{
            //    Console.WriteLine("两者相等");
            //}
            //else
            //{
            //    Console.WriteLine("两者不相等");
            //}

            Dictionary<AAAAData, List<String>> dic = new Dictionary<AAAAData, List<String>>();
            List<String> lis = new List<string>();

            lis.Add("1");

            dic.Add(data1, lis);

            foreach (var it in dic)
            {
                if (it.Key.Equals(data2))
                {
                    //dic[data2] = 2;
                    dic[it.Key].Add("2");

                }

            }

            foreach (var it in dic)
            {
                //Console.WriteLine("===========================");
                //Console.WriteLine(it.Value);
                foreach (var itt in it.Value)
                {
                    Console.WriteLine("===========================" + itt);

                }


            }



        }



        public double Min(double a, double b)
        {
            double c = 0;
            if (a < b)
                c = a;
            else if (a > b)
                c = b;
            else if (a == b)
                c = a;
            return c;
        }

        public void Testtttt()
        {
            double z = 1 / 3;
            Console.WriteLine(Math.Pow(81, 0.25));

        }

        public void insertCao()
        {
            int a = 0;
            //LaTeX，子式节点
            Dictionary<AAAAData, List<String>> dic = new Dictionary<AAAAData, List<String>>();
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\1.txt", Encoding.Default);
            String read = sr.ReadLine();
            string sqlstr;
            bool panduan;
            sqlstr = "select * from AAA";
            DataSet ds = new DataSet();
            ds = DBhelper.GetDataSet(sqlstr);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (a == 2)
                    break;
                sqlstr = "insert into AA(子式,数学表达式) values ('" + row["子式"].ToString().Trim() + "','" + row["数学表达式"].ToString().Trim() + "')";
                panduan = DBhelper.InsertUpdateDal(sqlstr);
                a++;
            }
          
        }






    }




}

