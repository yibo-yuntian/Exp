using DBhelper类封装起来;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;
using 成功重写;

namespace 成功
{
    public class LaTeXQuery
    {

        public void DuiJiaoXianQuery(String queryLaTeX,Dictionary<String, List<Number>>[][] DataBase, Dictionary<String, int> dictionary2)
        {
            //矩阵对角线上的元素
            foreach (var it in DataBase[dictionary2[queryLaTeX]][dictionary2[queryLaTeX]]["#"])
            {
                String sqlstr = "select * from 第一篇论文里面的实验数据 where 序号 = '" + it.number + "'";//where 数学公式 = 'z=\\frac{a}{b}*x' or 数学公式 = '\\frac{a}{b}'
                DataSet ds = new DataSet();
                ds = DBhelper.GetDataSet(sqlstr);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine(row["数学公式"].ToString().Trim());
                }
            }
            
        }






        public void BaoHan(Dictionary<String, List<Number>>[][] DataBase, Dictionary<String, int> dictionary2, List<FinalNode1> AdjacentNodeList)
        {
            //突然又想到，精确匹配的时候，第一个邻接节点有序对比如“a”，“+”，
            //如果是精确匹配的话，那就在第一个空里面直接去找前驱为“#”的集合

            //长度为3时，所需要的集合为2个，长度为4时，所需要的集合为3个
            for (int i = 0; i < AdjacentNodeList.Count; i++)
            {
                AdjacentNodeList[i].Length = AdjacentNodeList.Count;
                AdjacentNodeList[i].zifuXuHao = i + 1;
                //到时候试试，下面里面的LaTeXNumber最好改为AdjacentNodeList[i].LaTeXNumber，到时候试试
                //AdjacentNodeList[i].LaTeXNumber = LaTeXNumber;
            }

            //把查询到每一个邻接节点有序对对应的集合先放在一个字典里面
            int a = 0;
            Dictionary<int, List<Number>> tempDic = new Dictionary<int, List<Number>>();
            for (int i = 0; i < AdjacentNodeList.Count - 1; i++)
            {
                //
                if (tempDic.Count == 0)
                {
                    //明白了啊，下面这个注释是直接查询含有比如a+这个邻接对的所有表达式，忘了查询不但含有a+这个对，也得查询含有a+这个对及对应的这个特征
                    //tempDic.Add(i, DataBase[dictionary2[AdjacentNodeList[i].zifu]][dictionary2[AdjacentNodeList[i + 1].zifu]]["#"]);
                    Number numbers = new Number();
                    numbers.baohanFeature = Convert.ToString(AdjacentNodeList[i + 1].Level - AdjacentNodeList[i].Level) + Convert.ToString(AdjacentNodeList[i + 1].BTreeLevel - AdjacentNodeList[i].BTreeLevel);

                    //Console.WriteLine("前字符为:"+ AdjacentNodeList[i].zifu+"后字符为:"+ AdjacentNodeList[i+1].zifu+"前字符树层次为："+ AdjacentNodeList[i].BTreeLevel);

                    //Console.WriteLine("简直草死你妈了字符序号差:"+ Convert.ToString(AdjacentNodeList[i + 1].zifuXuHao - AdjacentNodeList[i].zifuXuHao)+"Level差:"+ Convert.ToString(AdjacentNodeList[i + 1].Level - AdjacentNodeList[i].Level)+"树层次差:"+ Convert.ToString(AdjacentNodeList[i + 1].BTreeLevel - AdjacentNodeList[i].BTreeLevel));
                    //Console.WriteLine("公式序号"+"邻接节点有序对:"+AdjacentNodeList[i].zifu+"隔开"+AdjacentNodeList[i+1].zifu+"包含特征为:"+numbers.baohanFeature);
                    //Console.WriteLine("=========================================简直日了狗了======================================"+ numbers.finalFeature);

                    List<Number> tempFirstList = new List<Number>();

                    //如果是包含匹配的话，在第一个邻接节点有序对的时候，包含匹配，那就要把该空里面的所有的集合都查找出来然后放进字典
                    //遍历该孔的字典
                    //Console.WriteLine("一开始进来的是什么==============================================:"+ AdjacentNodeList[i].zifu+"和："+ AdjacentNodeList[i + 1].zifu);
                    foreach (var it in DataBase[dictionary2[AdjacentNodeList[i].zifu]][dictionary2[AdjacentNodeList[i + 1].zifu]])
                    {

                        //Console.WriteLine("===================================================================================================这个执行了几次");
                        //我他妈终于知道了啊，艹艹艹艹艹艹艹艹艹 艹艹存储 艹艹，我想的是把含有（a，group）这个对的索引字典里面的第一个“孔”里面的每一个Key下面的所有集合放入一个集合当中，此时对应一个Key，然后存入字典，这他妈，我现在是把
                        //这他妈我现在是又把一个集合放入一个Key，一个集合放入一个Key，又他妈回到原来了啊，草拟吗的，
                        //我应该重新弄一个集合，然后循环把下面的it.Value.Where(p => p.baohanFeature.Contains(numbers.baohanFeature)).ToList()“每个”这个集合里面的元素放（读）入我新new的集合当中，最后统一放入一个Key对应的所有集合元素
                        //tempDic.Add(a,it.Value.Where(p => p.baohanFeature.Contains(numbers.baohanFeature)).ToList());
                        //把每一个孔的每个Key对应集合的元素进行遍历，放入一个新集合中，这个“只限于在第一次出现的空”的“包含匹配”的条件下啊
                        foreach (var itt in it.Value.Where(p => p.baohanFeature.Contains(numbers.baohanFeature)).ToList())
                        {
                            tempFirstList.Add(itt);
                        }
                    }

                    tempDic.Add(a, tempFirstList);

                    //下面这个他妈的是“#”啊，草拟吗的啊，怪不得打不开了啊
                    /*foreach (var it in DataBase[dictionary2[AdjacentNodeList[i].zifu]][dictionary2[AdjacentNodeList[i + 1].zifu]]["#"].Where(p => p.baohanFeature.Contains(numbers.baohanFeature)).ToList())
                    {
                        Console.WriteLine("真是草拟吗了啊，到底查询到了没啊c艹艹艹艹艹艹艹艹艹草拟吗啊啊啊啊啊啊艹艹艹艹艹艹艹艹艹艹"+it.number);
                    }*/
                }
                else
                {
                    a++;
                    //明白了啊，下面这个注释是直接查询含有比如a+这个邻接对的所有表达式，忘了查询不但含有a+这个对，也得查询含有a+这个对及对应的这个特征
                    //tempDic.Add(i, DataBase[dictionary2[AdjacentNodeList[i].zifu]][dictionary2[AdjacentNodeList[i + 1].zifu]][AdjacentNodeList[i-1].zifu]);
                    Number numbers = new Number();
                    numbers.baohanFeature = Convert.ToString(AdjacentNodeList[i + 1].Level - AdjacentNodeList[i].Level) + Convert.ToString(AdjacentNodeList[i + 1].BTreeLevel - AdjacentNodeList[i].BTreeLevel);
                    //Console.WriteLine("=========================================简直日了狗了======================================"+ numbers.finalFeature);
                    //Console.WriteLine("=========================================草拟吗i循环了多少次了啊艹======================================"+i);
                    //Console.WriteLine("公式序号"+"邻接节点有序对:" + AdjacentNodeList[i].zifu + "隔开" + AdjacentNodeList[i + 1].zifu + "包含特征为:" + numbers.baohanFeature);
                    tempDic.Add(a, DataBase[dictionary2[AdjacentNodeList[i].zifu]][dictionary2[AdjacentNodeList[i + 1].zifu]][AdjacentNodeList[i - 1].zifu].Where(p => p.baohanFeature.Contains(numbers.baohanFeature)).ToList());
                }
            }

            /*foreach (var it in tempDic)
            {
                Console.WriteLine("包含匹配艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹又无语了艹:"+it.Key);
                foreach (var its in it.Value)
                {
                    Console.WriteLine("包含匹配特征草拟吗的:"+its.number);
                }
            }*/



            //终于把含有number2的集合放到一个字典里面，提取出来了啊，现在可以求交集了啊
            int c = 1;
            List<Number> first = new List<Number>();
            foreach (var it in tempDic)
            {
                if (c == 1)
                {
                    first = it.Value;
                    foreach (var ittt in first)
                    {
                        // Console.WriteLine("第一个读取的集合："+ittt.number);
                    }
                    c++;
                    continue;
                }
                //first = first.jiaoji(it.Value)
                first = first.Intersect(it.Value).ToList();
            }

            foreach (var it in first)
            {
                String sqlstr = "select * from 第一篇论文里面的实验数据 where 序号 = '" + it.number + "'";//where 数学公式 = 'z=\\frac{a}{b}*x' or 数学公式 = '\\frac{a}{b}'
                DataSet ds = new DataSet();
                ds = DBhelper.GetDataSet(sqlstr);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine(row["数学公式"].ToString().Trim());
                }

                //Console.WriteLine("精确匹配结果自动化:" + it.number);

                //Console.WriteLine("包含匹配结果自动化:" + it.number);
            }
        }



        public void JingQue(Dictionary<String, List<Number>>[][] DataBase, Dictionary<String, int> dictionary2, List<FinalNode1> AdjacentNodeList)
        {

            //突然又想到，精确匹配的时候，第一个邻接节点有序对比如“a”，“+”，
            //如果是精确匹配的话，那就在第一个空里面直接去找前驱为“#”的集合
            //长度为3时，所需要的集合为2个，长度为4时，所需要的集合为3个
            for (int i = 0; i < AdjacentNodeList.Count; i++)
            {
                AdjacentNodeList[i].Length = AdjacentNodeList.Count;
                AdjacentNodeList[i].zifuXuHao = i + 1;
                //到时候试试，下面里面的LaTeXNumber最好改为AdjacentNodeList[i].LaTeXNumber，到时候试试
                //AdjacentNodeList[i].LaTeXNumber = LaTeXNumber;
            }

            //把查询到每一个邻接节点有序对对应的集合先放在一个字典里面
            Dictionary<int, List<Number>> tempDic = new Dictionary<int, List<Number>>();
            for (int i = 0; i < AdjacentNodeList.Count - 1; i++)
            {
                //
                if (tempDic.Count == 0)
                {
                    //明白了啊，下面这个注释是直接查询含有比如a+这个邻接对的所有表达式，忘了查询不但含有a+这个对，也得查询含有a+这个对及对应的这个特征
                    //tempDic.Add(i, DataBase[dictionary2[AdjacentNodeList[i].zifu]][dictionary2[AdjacentNodeList[i + 1].zifu]]["#"]);
                    Number numbers = new Number();
                    numbers.finalFeature = Convert.ToString(AdjacentNodeList[i].Level) + Convert.ToString(AdjacentNodeList[i].Flag) + Convert.ToString(AdjacentNodeList[i].Length) + Convert.ToString(AdjacentNodeList[i + 1].Level) + Convert.ToString(AdjacentNodeList[i + 1].Flag) + Convert.ToString(AdjacentNodeList[i + 1].Length);
                    //Console.WriteLine("=========================================简直日了狗了======================================"+ numbers.finalFeature);
                    tempDic.Add(i, DataBase[dictionary2[AdjacentNodeList[i].zifu]][dictionary2[AdjacentNodeList[i + 1].zifu]]["#"].Where(p => p.finalFeature.Contains(numbers.finalFeature)).ToList());
                    /*foreach (var it in tempDic)
                    {
                    Console.WriteLine("KEY:" + it.Key);
                    foreach (var cao in it.Value)
                    {
                    Console.WriteLine("=========================================日了狗了======================================" + cao.finalFeature);
                    }

                    }*/
                }
                else
                {
                    //明白了啊，下面这个注释是直接查询含有比如a+这个邻接对的所有表达式，忘了查询不但含有a+这个对，也得查询含有a+这个对及对应的这个特征
                    //tempDic.Add(i, DataBase[dictionary2[AdjacentNodeList[i].zifu]][dictionary2[AdjacentNodeList[i + 1].zifu]][AdjacentNodeList[i-1].zifu]);
                    Number numbers = new Number();
                    numbers.finalFeature = Convert.ToString(AdjacentNodeList[i].Level) + Convert.ToString(AdjacentNodeList[i].Flag) + Convert.ToString(AdjacentNodeList[i].Length) + Convert.ToString(AdjacentNodeList[i + 1].Level) + Convert.ToString(AdjacentNodeList[i + 1].Flag) + Convert.ToString(AdjacentNodeList[i + 1].Length);
                    //Console.WriteLine("=========================================简直日了狗了======================================"+ numbers.finalFeature);
                    //Console.WriteLine("=========================================草拟吗i循环了多少次了啊艹======================================"+i);
                    tempDic.Add(i, DataBase[dictionary2[AdjacentNodeList[i].zifu]][dictionary2[AdjacentNodeList[i + 1].zifu]][AdjacentNodeList[i - 1].zifu].Where(p => p.finalFeature.Contains(numbers.finalFeature)).ToList());
                }
            }

            //=====================还得草拟吗打印==============================
            /*foreach (var it in tempDic)
            {
                Console.WriteLine("KEY:" + it.Key);
                foreach (var cao in it.Value)
                {
                    Console.WriteLine("=========================================日了狗了======================================" + cao.finalFeature);
                }
            }*/
            //=====================还得草拟吗打印==============================


            //终于把含有number2的集合放到一个字典里面，提取出来了啊，现在可以求交集了啊
            int c = 1;
            List<Number> first = new List<Number>();
            foreach (var it in tempDic)
            {
                if (c == 1)
                {
                    first = it.Value;
                    c++;
                    continue;
                }
                //first = first.jiaoji(it.Value)
                first = first.Intersect(it.Value).ToList();
            }

            foreach (var it in first)
            {
                String sqlstr = "select * from 第一篇论文里面的实验数据 where 序号 = '" + it.number + "'";//where 数学公式 = 'z=\\frac{a}{b}*x' or 数学公式 = '\\frac{a}{b}'
                DataSet ds = new DataSet();
                ds = DBhelper.GetDataSet(sqlstr);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine(row["数学公式"].ToString().Trim());

                    //Console.WriteLine("精确匹配结果自动化:" + it.number);
                }
            }

        }


        //=======================================================================模糊查询==========================================================

        //上面那个每次精确查询最后一个参数是一个LaTeX的所有邻接节点有序对集合，而现在是一个字典，即存有一个LaTeX的所有子节点的字典。里面好多个集合，说白了就是好多个集合
        public void MoHu(Dictionary<String, List<Number>>[][] DataBase, Dictionary<String, int> dictionary2, Dictionary<int, List<FinalNode1>> children)
        {
            //遍历字典中每一个集合
            foreach (var it in children)
            {
                /*Console.WriteLine("键盘:"+it.Key);
                foreach (var itt in it.Value)
                {
                    Console.WriteLine("值为:"+itt.zifu+"Level为:"+itt.Level+"BTLevel为:"+itt.BTreeLevel);
                }*/
                this.BaoHan(DataBase,dictionary2,it.Value);
            }

        }




    }
}
