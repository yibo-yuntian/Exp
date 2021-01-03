using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功重写
{
    public class AAFinalScore
    {
        //传入查询表达式，和含有检索出来的结果表达式的集合，开始对每一个表达式进行排序
        public /*List<AAAData>*/ void  FinalScore(String queryLaTeX,List<String> resultLaTeXList,double baoHan/*,double jieGou*/)
        {

            List<AAAData> finalList = new List<AAAData>();
            AAAData tempdata = new AAAData();
            AAZhiBiao aazhibiao = new AAZhiBiao();
            //现在开始遍历检索到的每一个结果表达式，我开始计算他们之间的分数
            foreach (var resultLaTeX in resultLaTeXList)
            {
                //Console.WriteLine("AAFinalScore.cs："+resultLaTeX);
                double a, b;
                double d;

                //a = (   (1 - aazhibiao.BTLevelScore(queryLaTeX, resultLaTeX)  ) * (1 - aazhibiao.BTLevelScore(queryLaTeX, resultLaTeX)) + (1 - aazhibiao.childrenCountScore(queryLaTeX, resultLaTeX)) * (1 - aazhibiao.childrenCountScore(queryLaTeX, resultLaTeX)) + (1 - aazhibiao.formulaCoverage(queryLaTeX,resultLaTeX)) * (1 - aazhibiao.formulaCoverage(queryLaTeX,resultLaTeX))) / 3;
                //b = ((1 - aazhibiao.RootPath(queryLaTeX, resultLaTeX)) * (1 - aazhibiao.RootPath(queryLaTeX, resultLaTeX)) + (1 - aazhibiao.OperateBTLevelAndType(queryLaTeX, resultLaTeX)) * (1 - aazhibiao.OperateBTLevelAndType(queryLaTeX, resultLaTeX))) / 2; ;
                a =  aazhibiao.formulaCoverage(queryLaTeX, resultLaTeX);
                /*b = aazhibiao.RootPath(queryLaTeX, resultLaTeX);*/
                d = a*baoHan /*+ b*jieGou*/;
                
                AAAData data = new AAAData();
                data.LaTeX = resultLaTeX;
                data.Score = d;
                finalList.Add(data);            
            }

            //开始对相似度进行排序
            /*Console.WriteLine("排序前:");
            for (int i = 0; i < finalList.Count; i++)
            {
                Console.WriteLine("LaTeX为:" + finalList[i].LaTeX + "分数为:" + finalList[i].Score);
            }*/


            //开始排序
            for (int i = 0; i < finalList.Count - 1; i++)
            {
                for (int j = i + 1; j < finalList.Count; j++)
                {
                    if (finalList[j].Score > finalList[i].Score)
                    {
                        tempdata = finalList[j];
                        finalList[j] = finalList[i];
                        finalList[i] = tempdata;
                    }
                }
            }

            //List<AAAData> finalLists = new List<AAAData>();
            //for (int k = 0; k < 5; k++)
            //{
            //    if (finalList.Count > 5)
            //    {
            //        finalLists.Add(finalList[k]);
            //    }
            //}
            //return finalLists;

            Console.WriteLine("排序后最终结果为:");
            for (int i = 0; i < finalList.Count; i++)
            {
                if (finalList[i].Score > 0.1)
                {
                    Console.WriteLine("LaTeX:" + finalList[i].LaTeX + "分数为:" + finalList[i].Score);
                }
            }

        }


    }
}
