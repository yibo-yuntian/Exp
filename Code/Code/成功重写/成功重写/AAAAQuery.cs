using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功重写
{
    public class AAAAQuery
    {
        public void finalQuery()
        {
            AAFinalScore Final = new AAFinalScore();
            List<String> resultLaTeXList = new List<string>();
            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
            String read = sr.ReadLine();
            FuShu fushu = new FuShu();
            DuiShu duishu = new DuiShu();
            while (true)
            {
                Console.WriteLine("请输入您的查询请求：包含分数为：");
                double baoHan = Convert.ToDouble(Console.ReadLine());
            //    Console.WriteLine("请输入您的查询请求：结构分数为：");
            //double jieGou = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入您想要查的字符串:（#为结束字符）");
            String queryLaTeX = Console.ReadLine();
                //如果是负数的话
                queryLaTeX = fushu.fuShu(queryLaTeX);
                queryLaTeX = duishu.duiShu(queryLaTeX);
                //如果时负数的话
                //下面这个是相当于读取子式的那个
                AARead ar = new AARead();
            resultLaTeXList = ar.Read(queryLaTeX);
            resultLaTeXList = resultLaTeXList.Distinct().ToList();
            System.Diagnostics.Stopwatch stop = new System.Diagnostics.Stopwatch();
            stop.Start();//开始监视代码运行时间
            Final.FinalScore(queryLaTeX, resultLaTeXList, baoHan/*, jieGou*/);
            stop.Stop();//代码结束时间
            TimeSpan timespan = stop.Elapsed;
            double milliseconds = timespan.TotalMilliseconds;//总毫秒
            Console.WriteLine("排序时间为：" + milliseconds + "毫秒");
        }
    }
    }
}
