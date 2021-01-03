using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class AAAA
    {
        public void Test1(String queryLaTeX)
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\1.txt", Encoding.Default);
            String read = sr.ReadLine();

            Dictionary<String, List<String>> dicnew = new Dictionary<string, List<string>>();

            while (read != null)
            {
                ChildrenBTree t = new ChildrenBTree();

                Dictionary<int, List<FinalNode1>> dic = new Dictionary<int, List<FinalNode1>>();
                dic = t.childrenBTree(read);

                foreach (var it in dic)
                {
                    Console.WriteLine(it.Key);
                    String str = null;
                    foreach (var itt in it.Value)
                    {
                        str = str + itt.zifu;
                    }
                    Console.WriteLine("结果：" + str);
                    if (dicnew.Count == 0)
                    {
                        List<String> list = new List<String>();
                        list.Add(read);
                        dicnew.Add(str, list);
                    }
                    else
                    {
                        if (dicnew.ContainsKey(str))
                        {
                            dicnew[str].Add(read);

                        }
                        else
                        {
                            List<String> list = new List<String>();
                            list.Add(read);
                            dicnew.Add(str, list);
                        }
                    }
                }

                read = sr.ReadLine();
                
            }


            ChildrenBTree queryziFu = new ChildrenBTree();

            Dictionary<int, List<FinalNode1>> querydic = new Dictionary<int, List<FinalNode1>>();
            querydic = queryziFu.childrenBTree(queryLaTeX);

            String strs = null;
            foreach (var it in querydic)
            {
                foreach (var itt in it.Value)
                {
                    strs = strs + itt.zifu;
                }
            }

            List<AAAAData> dataList = new List<AAAAData>();

            //这个是查询公式对应的数学公式
            foreach (var it in dicnew[strs])
            {
                //开始处理每一个数学公式it
                ChildrenBTree t = new ChildrenBTree();
                Dictionary<int, List<FinalNode1>> dicc = new Dictionary<int, List<FinalNode1>>();
                dicc = t.childrenBTree(it);
                String tempStr = null;
                foreach (var itt in dicc)
                {
                    foreach (var ittt in itt.Value)
                    {
                        tempStr = tempStr + ittt.zifu;
                    }
                    if (strs.Equals(tempStr))
                    {


                    }

                }

            }





        }


        public Dictionary<int, List<FinalNode1>> BTLevelScore(String queryLaTeX, String resultLaTeX)
        {
            AABTreeStructure acquireBtreeStructure = new AABTreeStructure();//调用这个类，获取树结构的类
            List<FinalNode1> queryLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“查询表达式”邻接节点有序对的集合
            List<FinalNode1> resultLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“结果表达式”邻接节点有序对的集合
            queryLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(queryLaTeX);//已经存放“查询表达式”邻接节点有序对的集合
            resultLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(resultLaTeX);//已经存放“结果表达式”邻接节点有序对的集合

            //=====这个方法一开始只是默认查询表达式是结果表达式的子式，但是如果查询表达式不是结果表达式的子式，那就不能用这个指标了=======================

            //如果查询表达式的长度“大于”结果表达式的长度，那说明一定没有包含，所以此时该指标得分为0
            if (queryLaTeXAdjacentNodeList.Count > resultLaTeXAdjacentNodeList.Count)
                return null;

            //=====这个方法一开始只是默认查询表达式是结果表达式的子式，但是如果查询表达式不是结果表达式的子式，那就不能用这个指标了=======================


            //我先算一下查询表达式的树在结果表达式的树中的高度
            
            int panduan1 = queryLaTeXAdjacentNodeList.Count;//这个是查询表达式的节点的个数
            int panduan2 = 0;
            int i = 0;
            int p = 0;
            int counts = 1;
            Dictionary<int, List<FinalNode1>> tempdic = new Dictionary<int, List<FinalNode1>>();

            for (int j = 0; j < resultLaTeXAdjacentNodeList.Count; j++)
            {
                p = j;
                while (i != queryLaTeXAdjacentNodeList.Count)
                {
                    //Console.WriteLine("查询表达式集合：" + i);
                    //Console.WriteLine("查询表达式总共个数：" + queryLaTeXAdjacentNodeList.Count);
                    //Console.WriteLine("结果表达式集合：" + p);
                    //Console.WriteLine("结果表达式总共个数：" + resultLaTeXAdjacentNodeList.Count);
                    //Console.WriteLine("==============================");
                    if (queryLaTeXAdjacentNodeList[i].zifu.Equals(resultLaTeXAdjacentNodeList[p].zifu))
                    {
                        i++;
                        p++;
                        panduan2++;
                    }
                    else//一旦有不相等的，说明肯定不相等，那就直接终止循环
                    {
                        //这里得添加一个标志吧，直接结束
                        panduan2 = 0;
                        break;
                    }

                    if (p == resultLaTeXAdjacentNodeList.Count)
                        break;

                }//这个是循环比较完每一个查询表达式与结果表达式的j从0开始

                if (panduan2 == panduan1)//说明结果表达式里面至少有一个查询表达式，既然有的话，那就添加一下不就行了
                {
                    //Console.WriteLine("panduan2:"+panduan2+"panduan1:"+panduan1);
                    //Console.WriteLine("第一次出现的j是多少:"+j);
                    List<FinalNode1> tempList = new List<FinalNode1>();
                    for (int k = j; k < j + queryLaTeXAdjacentNodeList.Count; k++)
                    {
                        //Console.WriteLine("哪里超界限了："+k);

                        //Console.WriteLine("哪里超界限了："+ resultLaTeXAdjacentNodeList[k].zifu);
                        tempList.Add(resultLaTeXAdjacentNodeList[k]);
                    }


                    tempdic.Add(counts,tempList);
                    counts ++;
                    i = 0;
                    panduan2 = 0;
                }
                else//如果不相等的话，说明目前没找到
                {
                    i = 0;
                    panduan2 = 0;
                    continue;
                }

                //也就是说“p”是从结果表达式一个一个字符开始，
                //开始找和查询表达式具有相同首字符的时候，所以有的是从结果表达式快最后的时候
                //才可能找到查询表达式的开始
                if (p == resultLaTeXAdjacentNodeList.Count)
                    break;
            }

            List<AAAAData> list = new List<AAAAData>();
            


            return tempdic;

        }//第一个指标：树的层次（高度）这个指标

    }




   }

