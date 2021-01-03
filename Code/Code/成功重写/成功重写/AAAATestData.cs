//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace 成功重写
//{
//    public class AAAATestData
//    {
//        public void TestData1(int lim)
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                jishu++;
//                if (jishu == lim)
//                {
//                    break;
//                }

//                //每读取一个数学表达式
//                String queryLaTeX = read;
//                //如果是负数的话
//                queryLaTeX = fushu.fuShu(queryLaTeX);
//                queryLaTeX = duishu.duiShu(queryLaTeX);
//                //如果时负数的话
//                //下面这个是相当于读取子式的那个
//                AARead ar = new AARead();
//                resultLaTeXList = ar.Read(queryLaTeX);
//                resultLaTeXList = resultLaTeXList.Distinct().ToList();

//                List<AAAData> canshu = new List<AAAData>();
//                List<String> canshuu = new List<String>();

//                List<AAAData> jiduan1 = new List<AAAData>();
//                List<String> jiduan11 = new List<String>();

//                List<AAAData> jiduan2 = new List<AAAData>();
//                List<String> jiduan22 = new List<String>();


//                List<String> bingji = new List<String>();
//                List<String> jiaoji = new List<String>();


//                //baoHan, jieGou
//                canshu = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);

//                //Console.WriteLine("参数的：");
//                foreach (var it in canshu)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    canshuu.Add(it.LaTeX);
//                }
//                jiduan1 = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);
//                //Console.WriteLine("极端1：");
//                foreach (var it in jiduan1)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan11.Add(it.LaTeX);
//                }

//                jiduan2 = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);
//                // Console.WriteLine("极端2：");
//                foreach (var it in jiduan2)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan22.Add(it.LaTeX);
//                }


//                bingji = jiduan11.Union(jiduan22).ToList();
//                //Console.WriteLine("并集：");
//                //foreach (var it in bingji)
//                //{
//                //    Console.WriteLine(it);
//                //}

//                jiaoji = canshuu.Intersect(bingji).ToList();
//                //Console.WriteLine("交集：");
//                //foreach (var it in jiaoji)
//                //{
//                //    Console.WriteLine(it);
//                //}


//                a = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(bingji.Count);
//                //Console.WriteLine("交集个数为："+jiaoji.Count + "并集个数为："+bingji.Count);
//                sum = sum + a;

//                count++;
//                Console.Write(count);

//                //break;

//                read = sr.ReadLine();

//            }

//            Console.WriteLine("TestData1平均数为：" + sum / count);


//        }

//        public void TestData2(int lim)
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                jishu++;
//                if (jishu == lim)
//                {
//                    break;
//                }

//                //每读取一个数学表达式
//                String queryLaTeX = read;
//                //如果是负数的话
//                queryLaTeX = fushu.fuShu(queryLaTeX);
//                queryLaTeX = duishu.duiShu(queryLaTeX);
//                //如果时负数的话
//                //下面这个是相当于读取子式的那个
//                AARead ar = new AARead();
//                resultLaTeXList = ar.Read(queryLaTeX);
//                resultLaTeXList = resultLaTeXList.Distinct().ToList();

//                List<AAAData> canshu = new List<AAAData>();
//                List<String> canshuu = new List<String>();

//                List<AAAData> jiduan1 = new List<AAAData>();
//                List<String> jiduan11 = new List<String>();

//                List<AAAData> jiduan2 = new List<AAAData>();
//                List<String> jiduan22 = new List<String>();


//                List<String> bingji = new List<String>();
//                List<String> jiaoji = new List<String>();


//                //baoHan, jieGou
//                canshu = Final.FinalScore(queryLaTeX, resultLaTeXList, 0.1, 0.9);

//                //Console.WriteLine("参数的：");
//                foreach (var it in canshu)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    canshuu.Add(it.LaTeX);
//                }
//                jiduan1 = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);
//                //Console.WriteLine("极端1：");
//                foreach (var it in jiduan1)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan11.Add(it.LaTeX);
//                }

//                jiduan2 = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);
//                // Console.WriteLine("极端2：");
//                foreach (var it in jiduan2)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan22.Add(it.LaTeX);
//                }


//                bingji = jiduan11.Union(jiduan22).ToList();
//                //Console.WriteLine("并集：");
//                //foreach (var it in bingji)
//                //{
//                //    Console.WriteLine(it);
//                //}

//                jiaoji = canshuu.Intersect(bingji).ToList();
//                //Console.WriteLine("交集：");
//                //foreach (var it in jiaoji)
//                //{
//                //    Console.WriteLine(it);
//                //}


//                a = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(bingji.Count);
//                //Console.WriteLine("交集个数为："+jiaoji.Count + "并集个数为："+bingji.Count);
//                sum = sum + a;

//                count++;
//                Console.Write(count);

//                //break;

//                read = sr.ReadLine();

//            }

//            Console.WriteLine("TestData2平均数为：" + sum / count);


//        }

//        public void TestData3(int lim)
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                jishu++;
//                if (jishu == lim)
//                {
//                    break;
//                }

//                //每读取一个数学表达式
//                String queryLaTeX = read;
//                //如果是负数的话
//                queryLaTeX = fushu.fuShu(queryLaTeX);
//                queryLaTeX = duishu.duiShu(queryLaTeX);
//                //如果时负数的话
//                //下面这个是相当于读取子式的那个
//                AARead ar = new AARead();
//                resultLaTeXList = ar.Read(queryLaTeX);
//                resultLaTeXList = resultLaTeXList.Distinct().ToList();

//                List<AAAData> canshu = new List<AAAData>();
//                List<String> canshuu = new List<String>();

//                List<AAAData> jiduan1 = new List<AAAData>();
//                List<String> jiduan11 = new List<String>();

//                List<AAAData> jiduan2 = new List<AAAData>();
//                List<String> jiduan22 = new List<String>();


//                List<String> bingji = new List<String>();
//                List<String> jiaoji = new List<String>();


//                //baoHan, jieGou
//                canshu = Final.FinalScore(queryLaTeX, resultLaTeXList, 0.2, 0.8);

//                //Console.WriteLine("参数的：");
//                foreach (var it in canshu)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    canshuu.Add(it.LaTeX);
//                }
//                jiduan1 = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);
//                //Console.WriteLine("极端1：");
//                foreach (var it in jiduan1)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan11.Add(it.LaTeX);
//                }

//                jiduan2 = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);
//                // Console.WriteLine("极端2：");
//                foreach (var it in jiduan2)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan22.Add(it.LaTeX);
//                }


//                bingji = jiduan11.Union(jiduan22).ToList();
//                //Console.WriteLine("并集：");
//                //foreach (var it in bingji)
//                //{
//                //    Console.WriteLine(it);
//                //}

//                jiaoji = canshuu.Intersect(bingji).ToList();
//                //Console.WriteLine("交集：");
//                //foreach (var it in jiaoji)
//                //{
//                //    Console.WriteLine(it);
//                //}


//                a = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(bingji.Count);
//                //Console.WriteLine("交集个数为："+jiaoji.Count + "并集个数为："+bingji.Count);
//                sum = sum + a;

//                count++;
//                Console.Write(count);

//                //break;

//                read = sr.ReadLine();

//            }

//            Console.WriteLine("TestData3平均数为：" + sum / count);


//        }

//        public void TestData4(int lim)
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                jishu++;
//                if (jishu == lim)
//                {
//                    break;
//                }

//                //每读取一个数学表达式
//                String queryLaTeX = read;
//                //如果是负数的话
//                queryLaTeX = fushu.fuShu(queryLaTeX);
//                queryLaTeX = duishu.duiShu(queryLaTeX);
//                //如果时负数的话
//                //下面这个是相当于读取子式的那个
//                AARead ar = new AARead();
//                resultLaTeXList = ar.Read(queryLaTeX);
//                resultLaTeXList = resultLaTeXList.Distinct().ToList();

//                List<AAAData> canshu = new List<AAAData>();
//                List<String> canshuu = new List<String>();

//                List<AAAData> jiduan1 = new List<AAAData>();
//                List<String> jiduan11 = new List<String>();

//                List<AAAData> jiduan2 = new List<AAAData>();
//                List<String> jiduan22 = new List<String>();


//                List<String> bingji = new List<String>();
//                List<String> jiaoji = new List<String>();


//                //baoHan, jieGou
//                canshu = Final.FinalScore(queryLaTeX, resultLaTeXList, 0.3, 0.7);

//                //Console.WriteLine("参数的：");
//                foreach (var it in canshu)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    canshuu.Add(it.LaTeX);
//                }
//                jiduan1 = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);
//                //Console.WriteLine("极端1：");
//                foreach (var it in jiduan1)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan11.Add(it.LaTeX);
//                }

//                jiduan2 = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);
//                // Console.WriteLine("极端2：");
//                foreach (var it in jiduan2)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan22.Add(it.LaTeX);
//                }


//                bingji = jiduan11.Union(jiduan22).ToList();
//                //Console.WriteLine("并集：");
//                //foreach (var it in bingji)
//                //{
//                //    Console.WriteLine(it);
//                //}

//                jiaoji = canshuu.Intersect(bingji).ToList();
//                //Console.WriteLine("交集：");
//                //foreach (var it in jiaoji)
//                //{
//                //    Console.WriteLine(it);
//                //}


//                a = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(bingji.Count);
//                //Console.WriteLine("交集个数为："+jiaoji.Count + "并集个数为："+bingji.Count);
//                sum = sum + a;

//                count++;
//                Console.Write(count);

//                //break;

//                read = sr.ReadLine();

//            }

//            Console.WriteLine("TestData4平均数为：" + sum / count);


//        }

//        public void TestData5(int lim)
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                jishu++;
//                if (jishu == lim)
//                {
//                    break;
//                }

//                //每读取一个数学表达式
//                String queryLaTeX = read;
//                //如果是负数的话
//                queryLaTeX = fushu.fuShu(queryLaTeX);
//                queryLaTeX = duishu.duiShu(queryLaTeX);
//                //如果时负数的话
//                //下面这个是相当于读取子式的那个
//                AARead ar = new AARead();
//                resultLaTeXList = ar.Read(queryLaTeX);
//                resultLaTeXList = resultLaTeXList.Distinct().ToList();

//                List<AAAData> canshu = new List<AAAData>();
//                List<String> canshuu = new List<String>();

//                List<AAAData> jiduan1 = new List<AAAData>();
//                List<String> jiduan11 = new List<String>();

//                List<AAAData> jiduan2 = new List<AAAData>();
//                List<String> jiduan22 = new List<String>();


//                List<String> bingji = new List<String>();
//                List<String> jiaoji = new List<String>();


//                //baoHan, jieGou
//                canshu = Final.FinalScore(queryLaTeX, resultLaTeXList, 0.4, 0.6);

//                //Console.WriteLine("参数的：");
//                foreach (var it in canshu)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    canshuu.Add(it.LaTeX);
//                }
//                jiduan1 = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);
//                //Console.WriteLine("极端1：");
//                foreach (var it in jiduan1)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan11.Add(it.LaTeX);
//                }

//                jiduan2 = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);
//                // Console.WriteLine("极端2：");
//                foreach (var it in jiduan2)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan22.Add(it.LaTeX);
//                }


//                bingji = jiduan11.Union(jiduan22).ToList();
//                //Console.WriteLine("并集：");
//                //foreach (var it in bingji)
//                //{
//                //    Console.WriteLine(it);
//                //}

//                jiaoji = canshuu.Intersect(bingji).ToList();
//                //Console.WriteLine("交集：");
//                //foreach (var it in jiaoji)
//                //{
//                //    Console.WriteLine(it);
//                //}


//                a = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(bingji.Count);
//                //Console.WriteLine("交集个数为："+jiaoji.Count + "并集个数为："+bingji.Count);
//                sum = sum + a;

//                count++;
//                Console.Write(count);

//                //break;

//                read = sr.ReadLine();

//            }

//            Console.WriteLine("TestData5平均数为：" + sum / count);


//        }

//        public void TestData6(int lim)
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                jishu++;
//                if (jishu == lim)
//                {
//                    break;
//                }

//                //每读取一个数学表达式
//                String queryLaTeX = read;
//                //如果是负数的话
//                queryLaTeX = fushu.fuShu(queryLaTeX);
//                queryLaTeX = duishu.duiShu(queryLaTeX);
//                //如果时负数的话
//                //下面这个是相当于读取子式的那个
//                AARead ar = new AARead();
//                resultLaTeXList = ar.Read(queryLaTeX);
//                resultLaTeXList = resultLaTeXList.Distinct().ToList();

//                List<AAAData> canshu = new List<AAAData>();
//                List<String> canshuu = new List<String>();

//                List<AAAData> jiduan1 = new List<AAAData>();
//                List<String> jiduan11 = new List<String>();

//                List<AAAData> jiduan2 = new List<AAAData>();
//                List<String> jiduan22 = new List<String>();


//                List<String> bingji = new List<String>();
//                List<String> jiaoji = new List<String>();


//                //baoHan, jieGou
//                canshu = Final.FinalScore(queryLaTeX, resultLaTeXList, 0.5, 0.5);

//                //Console.WriteLine("参数的：");
//                foreach (var it in canshu)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    canshuu.Add(it.LaTeX);
//                }
//                jiduan1 = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);
//                //Console.WriteLine("极端1：");
//                foreach (var it in jiduan1)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan11.Add(it.LaTeX);
//                }

//                jiduan2 = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);
//                // Console.WriteLine("极端2：");
//                foreach (var it in jiduan2)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan22.Add(it.LaTeX);
//                }


//                bingji = jiduan11.Union(jiduan22).ToList();
//                //Console.WriteLine("并集：");
//                //foreach (var it in bingji)
//                //{
//                //    Console.WriteLine(it);
//                //}

//                jiaoji = canshuu.Intersect(bingji).ToList();
//                //Console.WriteLine("交集：");
//                //foreach (var it in jiaoji)
//                //{
//                //    Console.WriteLine(it);
//                //}


//                a = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(bingji.Count);
//                //Console.WriteLine("交集个数为："+jiaoji.Count + "并集个数为："+bingji.Count);
//                sum = sum + a;

//                count++;
//                Console.Write(count);

//                //break;

//                read = sr.ReadLine();

//            }

//            Console.WriteLine("TestData6平均数为：" + sum / count);


//        }

//        public void TestData7(int lim)
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                jishu++;
//                if (jishu == lim)
//                {
//                    break;
//                }

//                //每读取一个数学表达式
//                String queryLaTeX = read;
//                //如果是负数的话
//                queryLaTeX = fushu.fuShu(queryLaTeX);
//                queryLaTeX = duishu.duiShu(queryLaTeX);
//                //如果时负数的话
//                //下面这个是相当于读取子式的那个
//                AARead ar = new AARead();
//                resultLaTeXList = ar.Read(queryLaTeX);
//                resultLaTeXList = resultLaTeXList.Distinct().ToList();

//                List<AAAData> canshu = new List<AAAData>();
//                List<String> canshuu = new List<String>();

//                List<AAAData> jiduan1 = new List<AAAData>();
//                List<String> jiduan11 = new List<String>();

//                List<AAAData> jiduan2 = new List<AAAData>();
//                List<String> jiduan22 = new List<String>();


//                List<String> bingji = new List<String>();
//                List<String> jiaoji = new List<String>();


//                //baoHan, jieGou
//                canshu = Final.FinalScore(queryLaTeX, resultLaTeXList, 0.6, 0.4);

//                //Console.WriteLine("参数的：");
//                foreach (var it in canshu)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    canshuu.Add(it.LaTeX);
//                }
//                jiduan1 = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);
//                //Console.WriteLine("极端1：");
//                foreach (var it in jiduan1)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan11.Add(it.LaTeX);
//                }

//                jiduan2 = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);
//                // Console.WriteLine("极端2：");
//                foreach (var it in jiduan2)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan22.Add(it.LaTeX);
//                }


//                bingji = jiduan11.Union(jiduan22).ToList();
//                //Console.WriteLine("并集：");
//                //foreach (var it in bingji)
//                //{
//                //    Console.WriteLine(it);
//                //}

//                jiaoji = canshuu.Intersect(bingji).ToList();
//                //Console.WriteLine("交集：");
//                //foreach (var it in jiaoji)
//                //{
//                //    Console.WriteLine(it);
//                //}


//                a = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(bingji.Count);
//                //Console.WriteLine("交集个数为："+jiaoji.Count + "并集个数为："+bingji.Count);
//                sum = sum + a;

//                count++;
//                Console.Write(count);

//                //break;

//                read = sr.ReadLine();

//            }

//            Console.WriteLine("TestData7平均数为：" + sum / count);


//        }

//        public void TestData8(int lim)
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                jishu++;
//                if (jishu == lim)
//                {
//                    break;
//                }

//                //每读取一个数学表达式
//                String queryLaTeX = read;
//                //如果是负数的话
//                queryLaTeX = fushu.fuShu(queryLaTeX);
//                queryLaTeX = duishu.duiShu(queryLaTeX);
//                //如果时负数的话
//                //下面这个是相当于读取子式的那个
//                AARead ar = new AARead();
//                resultLaTeXList = ar.Read(queryLaTeX);
//                resultLaTeXList = resultLaTeXList.Distinct().ToList();

//                List<AAAData> canshu = new List<AAAData>();
//                List<String> canshuu = new List<String>();

//                List<AAAData> jiduan1 = new List<AAAData>();
//                List<String> jiduan11 = new List<String>();

//                List<AAAData> jiduan2 = new List<AAAData>();
//                List<String> jiduan22 = new List<String>();


//                List<String> bingji = new List<String>();
//                List<String> jiaoji = new List<String>();


//                //baoHan, jieGou
//                canshu = Final.FinalScore(queryLaTeX, resultLaTeXList, 0.7, 0.3);

//                //Console.WriteLine("参数的：");
//                foreach (var it in canshu)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    canshuu.Add(it.LaTeX);
//                }
//                jiduan1 = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);
//                //Console.WriteLine("极端1：");
//                foreach (var it in jiduan1)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan11.Add(it.LaTeX);
//                }

//                jiduan2 = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);
//                // Console.WriteLine("极端2：");
//                foreach (var it in jiduan2)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan22.Add(it.LaTeX);
//                }


//                bingji = jiduan11.Union(jiduan22).ToList();
//                //Console.WriteLine("并集：");
//                //foreach (var it in bingji)
//                //{
//                //    Console.WriteLine(it);
//                //}

//                jiaoji = canshuu.Intersect(bingji).ToList();
//                //Console.WriteLine("交集：");
//                //foreach (var it in jiaoji)
//                //{
//                //    Console.WriteLine(it);
//                //}


//                a = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(bingji.Count);
//                //Console.WriteLine("交集个数为："+jiaoji.Count + "并集个数为："+bingji.Count);
//                sum = sum + a;

//                count++;
//                Console.Write(count);

//                //break;

//                read = sr.ReadLine();

//            }

//            Console.WriteLine("TestData8平均数为：" + sum / count);


//        }

//        public void TestData9(int lim)
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                jishu++;
//                if (jishu == lim)
//                {
//                    break;
//                }

//                //每读取一个数学表达式
//                String queryLaTeX = read;
//                //如果是负数的话
//                queryLaTeX = fushu.fuShu(queryLaTeX);
//                queryLaTeX = duishu.duiShu(queryLaTeX);
//                //如果时负数的话
//                //下面这个是相当于读取子式的那个
//                AARead ar = new AARead();
//                resultLaTeXList = ar.Read(queryLaTeX);
//                resultLaTeXList = resultLaTeXList.Distinct().ToList();

//                List<AAAData> canshu = new List<AAAData>();
//                List<String> canshuu = new List<String>();

//                List<AAAData> jiduan1 = new List<AAAData>();
//                List<String> jiduan11 = new List<String>();

//                List<AAAData> jiduan2 = new List<AAAData>();
//                List<String> jiduan22 = new List<String>();


//                List<String> bingji = new List<String>();
//                List<String> jiaoji = new List<String>();


//                //baoHan, jieGou
//                canshu = Final.FinalScore(queryLaTeX, resultLaTeXList, 0.8, 0.2);

//                //Console.WriteLine("参数的：");
//                foreach (var it in canshu)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    canshuu.Add(it.LaTeX);
//                }
//                jiduan1 = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);
//                //Console.WriteLine("极端1：");
//                foreach (var it in jiduan1)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan11.Add(it.LaTeX);
//                }

//                jiduan2 = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);
//                // Console.WriteLine("极端2：");
//                foreach (var it in jiduan2)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan22.Add(it.LaTeX);
//                }


//                bingji = jiduan11.Union(jiduan22).ToList();
//                //Console.WriteLine("并集：");
//                //foreach (var it in bingji)
//                //{
//                //    Console.WriteLine(it);
//                //}

//                jiaoji = canshuu.Intersect(bingji).ToList();
//                //Console.WriteLine("交集：");
//                //foreach (var it in jiaoji)
//                //{
//                //    Console.WriteLine(it);
//                //}


//                a = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(bingji.Count);
//                //Console.WriteLine("交集个数为："+jiaoji.Count + "并集个数为："+bingji.Count);
//                sum = sum + a;

//                count++;
//                Console.Write(count);

//                //break;

//                read = sr.ReadLine();

//            }

//            Console.WriteLine("TestData9平均数为：" + sum / count);


//        }

//        public void TestData10(int lim)
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                jishu++;
//                if (jishu == lim)
//                {
//                    break;
//                }

//                //每读取一个数学表达式
//                String queryLaTeX = read;
//                //如果是负数的话
//                queryLaTeX = fushu.fuShu(queryLaTeX);
//                queryLaTeX = duishu.duiShu(queryLaTeX);
//                //如果时负数的话
//                //下面这个是相当于读取子式的那个
//                AARead ar = new AARead();
//                resultLaTeXList = ar.Read(queryLaTeX);
//                resultLaTeXList = resultLaTeXList.Distinct().ToList();

//                List<AAAData> canshu = new List<AAAData>();
//                List<String> canshuu = new List<String>();

//                List<AAAData> jiduan1 = new List<AAAData>();
//                List<String> jiduan11 = new List<String>();

//                List<AAAData> jiduan2 = new List<AAAData>();
//                List<String> jiduan22 = new List<String>();


//                List<String> bingji = new List<String>();
//                List<String> jiaoji = new List<String>();


//                //baoHan, jieGou
//                canshu = Final.FinalScore(queryLaTeX, resultLaTeXList, 0.9, 0.1);

//                //Console.WriteLine("参数的：");
//                foreach (var it in canshu)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    canshuu.Add(it.LaTeX);
//                }
//                jiduan1 = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);
//                //Console.WriteLine("极端1：");
//                foreach (var it in jiduan1)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan11.Add(it.LaTeX);
//                }

//                jiduan2 = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);
//                // Console.WriteLine("极端2：");
//                foreach (var it in jiduan2)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan22.Add(it.LaTeX);
//                }


//                bingji = jiduan11.Union(jiduan22).ToList();
//                //Console.WriteLine("并集：");
//                //foreach (var it in bingji)
//                //{
//                //    Console.WriteLine(it);
//                //}

//                jiaoji = canshuu.Intersect(bingji).ToList();
//                //Console.WriteLine("交集：");
//                //foreach (var it in jiaoji)
//                //{
//                //    Console.WriteLine(it);
//                //}


//                a = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(bingji.Count);
//                //Console.WriteLine("交集个数为："+jiaoji.Count + "并集个数为："+bingji.Count);
//                sum = sum + a;

//                count++;
//                Console.Write(count);

//                //break;

//                read = sr.ReadLine();

//            }

//            Console.WriteLine("TestData10平均数为：" + sum / count);


//        }

//        public void TestData11(int lim)
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                jishu++;
//                if (jishu == lim)
//                {
//                    break;
//                }

//                //每读取一个数学表达式
//                String queryLaTeX = read;
//                //如果是负数的话
//                queryLaTeX = fushu.fuShu(queryLaTeX);
//                queryLaTeX = duishu.duiShu(queryLaTeX);
//                //如果时负数的话
//                //下面这个是相当于读取子式的那个
//                AARead ar = new AARead();
//                resultLaTeXList = ar.Read(queryLaTeX);
//                resultLaTeXList = resultLaTeXList.Distinct().ToList();

//                List<AAAData> canshu = new List<AAAData>();
//                List<String> canshuu = new List<String>();

//                List<AAAData> jiduan1 = new List<AAAData>();
//                List<String> jiduan11 = new List<String>();

//                List<AAAData> jiduan2 = new List<AAAData>();
//                List<String> jiduan22 = new List<String>();


//                List<String> bingji = new List<String>();
//                List<String> jiaoji = new List<String>();


//                //baoHan, jieGou
//                canshu = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);

//                //Console.WriteLine("参数的：");
//                foreach (var it in canshu)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    canshuu.Add(it.LaTeX);
//                }
//                jiduan1 = Final.FinalScore(queryLaTeX, resultLaTeXList, 1, 0);
//                //Console.WriteLine("极端1：");
//                foreach (var it in jiduan1)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan11.Add(it.LaTeX);
//                }

//                jiduan2 = Final.FinalScore(queryLaTeX, resultLaTeXList, 0, 1);
//                // Console.WriteLine("极端2：");
//                foreach (var it in jiduan2)
//                {
//                    //Console.WriteLine(it.LaTeX);
//                    jiduan22.Add(it.LaTeX);
//                }


//                bingji = jiduan11.Union(jiduan22).ToList();
//                //Console.WriteLine("并集：");
//                //foreach (var it in bingji)
//                //{
//                //    Console.WriteLine(it);
//                //}

//                jiaoji = canshuu.Intersect(bingji).ToList();
//                //Console.WriteLine("交集：");
//                //foreach (var it in jiaoji)
//                //{
//                //    Console.WriteLine(it);
//                //}


//                a = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(bingji.Count);
//                //Console.WriteLine("交集个数为："+jiaoji.Count + "并集个数为："+bingji.Count);
//                sum = sum + a;

//                count++;
//                Console.Write(count);

//                //break;

//                read = sr.ReadLine();

//            }

//            Console.WriteLine("TestData11平均数为：" + sum / count);


//        }

//        public void TestData12()
//        {
//            AAFinalScore Final = new AAFinalScore();
//            List<String> resultLaTeXList = new List<string>();
//            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            //String read = sr.ReadLine();
//            FuShu fushu = new FuShu();
//            DuiShu duishu = new DuiShu();

//            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
//            String read = sr.ReadLine();

//            double a = 0;
//            double sum = 0;
//            double count = 0;

//            int jishu = 0;

//            while (read != null)
//            {
//                count++;
//                read = sr.ReadLine();
//                Console.WriteLine(count);
//            }




//        }

//    }
//}
