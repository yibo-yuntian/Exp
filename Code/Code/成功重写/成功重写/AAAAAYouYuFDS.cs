using ConsoleApplication7;
using DBhelper类封装起来;
using MathData.DocAnalyse;
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
    public class AAAAAYouYuFDS
    {
        public void Test1(String queryLaTeX)
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\1.txt", Encoding.Default);
            String read = sr.ReadLine();
            //String queryLaTeX = "\\sqrt{b^{2}-4*a*c";
            
            ////统计最大层次
            //int maxBTLevel = 0;
            //while (read != null)
            //{
            //    List<FinalNode1> list = new List<FinalNode1>();
            //    AdjacentNode aa = new AdjacentNode();
            //    list = aa.AdjacentNodeList(read);

            //    foreach (var it in list)
            //    {
            //        if (it.BTreeLevel > maxBTLevel)
            //            maxBTLevel = it.BTreeLevel;

            //    }
            //    read = sr.ReadLine();
            //}
            //Console.WriteLine("最大层次为："+maxBTLevel);


            List<AAAAData> Final = new List<AAAAData>();


            while (read != null)
            {
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
                li = Test4(read);

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
                    Console.WriteLine(count);
                    string sqlstr = "insert into Z89408(子式,数学表达式) values ('" + it.str + "','" + read + "')";
                    panduan = DBhelper.InsertUpdateDal(sqlstr);
                    //if (panduan == true)
                    //{
                    //    Console.Write("操作成功");
                    //}
                    //else
                    //{
                    //    Console.Write("操作失败");
                    //}
                }//循环里面

                read = sr.ReadLine();
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
            
            List<AAAAData> list = new List<AAAAData>();
            ExpUtil exputil = new ExpUtil();
            List<NodeInfo> temp = exputil.GetNodeList(LaTeX, 0);

            //定义一个字典，Key是层次，Value是每一层的子式




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
            li = Test4(queryLaTeX);

            List<String> resultLaTeXList = new List<string>();

            List<String> tempList = new List<string>();

            //=========这个是第一个子式=============================
            tempList.Add(li[0].str);

            //！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！这里的这个表名字Test6需要改的！！！！！！！！！！！！！！！！！！！！！！！！！

            string sqlstr = " select distinct(数学表达式) from Z1397 where 子式 = '" + li[0].str + "'";
            DataSet ds = new DataSet();
            ds = DBhelper.GetDataSet(sqlstr);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                resultLaTeXList.Add(row["数学表达式"].ToString().Trim());
            }
            //==========这个是第二个子式============================

            //第二步：把包含查询表达式所有子表达式的所有结果表达式提取出来，先提取出来吧
            for (int i = 1; i < li.Count; i ++)
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
                    sqlstr = " select distinct(数学表达式) from Z1397 where 子式 = '" + li[i].str + "'";
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

            Console.WriteLine("========================================第一步：检索时间为："+timePast);



            return resultLaTeXList;

        }


        public void sort(String queryLaTeX)
        {

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

                for (int k = 0; k < queryScore.Count; k ++)
                {
                    sum = sum + Math.Abs((14 - queryScore[k]) - (14 - resultScore[k])) / (27);
                }

                //=====================在这里起码补充一下查询树和结果树之间的差距的距离吧？？？？？？？？？？？？===========================
                sum = sum + Math.Abs(MaxBTLevel(queryLaTeX) - MaxBTLevel(resultLaTeX.ToLower())) / (27);
                //=====================在这里起码补充一下查询树和结果树之间的差距的距离吧？？？？？？？？？？？？===========================


                //=====================这里我想连接一下查询表达式各个分数和结果表达式分数
                String queryStr = "";
                foreach (var it in queryScore)
                {
                    queryStr = queryStr + it + "#";

                }
                String resultStr = "";
                foreach (var it in resultScore)
                {
                    resultStr = resultStr + it + "#";

                }
                //=====================这里我想连接一下查询表达式各个分数和结果表达式分数




                //==================================开始查询与结果计算评分=====================================

                //==================把打好分的结果以节点形式放入一个集合当中===========================
                AAAAData data = new AAAAData();
                sum = sum / (queryScore.Count + 1);//？？？？？？？？？？？？？？？？？？？？？？这里加1也不对啊？？？？？？？？？？？？？？？？？？？？？？
                data.BTLevel = 1 - sum;
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

            foreach (var it in quchong)
            {
                Console.WriteLine("结果表达式：" + it.str + "\t" + "查询表达式打分：" + it.queryStr + "\t" + "结果表达式打分：" + it.resultStr + "\t" + "相似度得分为：" + it.BTLevel);

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
        public double ZiShiBTlevel(AAAAData node,String QueryOrResultLaTeX)
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

            dic.Add(data1,lis);

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
                    Console.WriteLine("==========================="+itt);

                }
              

            }



        }




    }




   }

