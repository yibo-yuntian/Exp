using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功重写
{
    public class AAPrintScore
    {
        public void printScore(String queryLaTeX,String resultLaTeX)
        {
            //这个函数用来打印每个指标的分数
            AAZhiBiao aazhibiao = new AAZhiBiao();
            //首先是包含的话是，是最匹配的，并且树的层次越接近根的话，以最接近根的那个为标准，就越相似，这是第一点
            Console.WriteLine("第一个：树的高度层次分数："+aazhibiao.BTLevelScore(queryLaTeX,resultLaTeX));

            //第二个指标：查询表达式在结果表达式中的个数*0.8  + 与查询表达式节点相同的个数*0.2 这个指标
            Console.WriteLine("第二个：查询表达式在结果表达式个数以及与查询表达式节点相同的个数："+ aazhibiao.childrenCountScore(queryLaTeX,resultLaTeX));

            //第三个指标：查询表达式的子式个数在结果表达式里面占的比重
            Console.WriteLine("第三个：公式覆盖度"+aazhibiao.formulaCoverage(queryLaTeX,resultLaTeX));

            //第四个指标：树根路径求交集，
            Console.WriteLine("第四个：树根路径用Jaccard系数求交集："+aazhibiao.RootPath(queryLaTeX,resultLaTeX));

            //第五个指标：运算符所在层次和类型
            Console.WriteLine("第五个：运算符所在层次和类型："+aazhibiao.OperateBTLevelAndType(queryLaTeX,resultLaTeX));

            ////第六个指标：tfIdf
            //Console.WriteLine("第六个：TF-IDF："+aazhibiao.TFIDF(queryLaTeX,resultLaTeX));


        }

    }
}
