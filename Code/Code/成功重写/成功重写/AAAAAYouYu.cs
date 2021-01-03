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
    public class AAAAYou
    {
       

        

        //=================这个是我把子式和数学表达式插入数据库=======================
        

        //=======================下面是把要训练和测试两两一组==============================
        public void WriteTrain2()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\A最后一个吧\\11.txt", Encoding.Default);
            String read = sr.ReadLine();

            StreamWriter sw = new StreamWriter("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\A最后一个吧\\1.txt");
            while (read != null)
            {
                //每进来一个数学表达式，把它的所有子信息全部用一个新的list装吧
                List<String> listNew = new List<String>();
                listNew = Test4(read);

                foreach (var it in listNew)
                {
                    sw.WriteLine(it);

                }

                read = sr.ReadLine();
                sw.Flush();
            }     
        }

        //下面是把要训练的插入整个txt文本
        public void WriteTest2()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\A最后一个吧\\1.txt", Encoding.Default);
            String read = sr.ReadLine();

            StreamWriter sw = new StreamWriter("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\A最后一个吧\\2.txt");
            while (read != null)
            {
                //每进来一个数学表达式，把它的所有子信息全部用一个新的list装吧
                List<String> listNew = new List<String>();
                listNew = Test4(read);

                //===================提取一下==================
                List<String> tiquList = new List<String>();
                foreach (var it in listNew)
                {
                    String[] aa = it.Split('#');
                    tiquList.Add(aa[0]);
                    tiquList.Add(aa[1]);
                }


                //===================提取一下==================


                //==================去重============================
                List<String> listQuchong = new List<String>();
                foreach (var it in tiquList)//遍历重复集合
                {
                    if (listQuchong.Count == 0)
                    {
                        listQuchong.Add(it);
                        continue;
                    }
                    int a = 0;
                    foreach (var item in listQuchong)
                    { 
                        if (item.Equals(it))
                        {
                            a = 1;
                            
                            break;//一旦找到说明找到了，那么就可以终止了，此时等于一加个break，否则又出bug了
                        }
                    }

                    if (a == 1)
                    {
                        continue;
                    }
                    else
                    {
                        listQuchong.Add(it);
                    }



                }

                //==================去重============================




                String s = "";
                foreach (var it in listQuchong)
                {
                    
                    s = s + it + "#";
                }

                s = s + read;
                sw.WriteLine(s);
                read = sr.ReadLine();
                sw.Flush();
            }
        }
        //=======================下面是把要训练和测试两两一组===============================


        //=======================下面是把要训练和测试三三一组==============================
        public void WriteTrain3()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\A最后一个吧\\与盲人系统对比\\11.txt", Encoding.Default);
            String read = sr.ReadLine();

            StreamWriter sw = new StreamWriter("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\A最后一个吧\\与盲人系统对比\\1.txt");
            while (read != null)
            {
                //每进来一个数学表达式，把它的所有子信息全部用一个新的list装吧
                List<String> listNew = new List<String>();
                listNew = Test4(read);

                foreach (var it in listNew)
                {
                    sw.WriteLine(it);

                }

                read = sr.ReadLine();
                sw.Flush();
            }
        }

        //下面是把要训练的插入整个txt文本
        public void WriteTest3()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\A最后一个吧\\与盲人系统对比\\11.txt", Encoding.Default);
            String read = sr.ReadLine();

            StreamWriter sw = new StreamWriter("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\A最后一个吧\\与盲人系统对比\\2.txt");
            while (read != null)
            {
                //每进来一个数学表达式，把它的所有子信息全部用一个新的list装吧
                List<String> listNew = new List<String>();
                listNew = Test4(read);

                //===================提取一下==================
                List<String> tiquList = new List<String>();
                foreach (var it in listNew)
                {
                    Console.WriteLine("========================:"+it);
                    String[] aa = it.Split('#');
                    if (aa.Count() == 3)
                    {
                        tiquList.Add(aa[0]);
                        tiquList.Add(aa[1]);
                        tiquList.Add(aa[2]);
                    }
                    else
                    {
                        tiquList.Add(aa[0]);
                        tiquList.Add(aa[1]);
                    }
                }


                //===================提取一下==================


                //==================去重============================
                List<String> listQuchong = new List<String>();
                foreach (var it in tiquList)//遍历重复集合
                {
                    if (listQuchong.Count == 0)
                    {
                        listQuchong.Add(it);
                        continue;
                    }
                    int a = 0;
                    foreach (var item in listQuchong)
                    {
                        if (item.Equals(it))
                        {
                            a = 1;

                            break;//一旦找到说明找到了，那么就可以终止了，此时等于一加个break，否则又出bug了
                        }
                    }

                    if (a == 1)
                    {
                        continue;
                    }
                    else
                    {
                        listQuchong.Add(it);
                    }



                }

                //==================去重============================




                String s = "";
                foreach (var it in listQuchong)
                {

                    s = s + it + "#";
                }

                s = s + read;
                sw.WriteLine(s);
                read = sr.ReadLine();
                sw.Flush();
            }
        }


        public void Count3()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\三个一组\\11.txt", Encoding.Default);
            String read = sr.ReadLine();

            StreamWriter sw = new StreamWriter("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\三个一组\\2.txt");
            List<String> tiquList = new List<String>();
            while (read != null)
            {
                //每进来一个数学表达式，把它的所有子信息全部用一个新的list装吧
                List<String> listNew = new List<String>();
                listNew = Test4(read);

                //===================提取一下==================     
                foreach (var it in listNew)
                {
                    Console.WriteLine("========================:" + it);
                    String[] aa = it.Split('#');
                    if (aa.Count() == 3)
                    {
                        tiquList.Add(aa[0]);
                        tiquList.Add(aa[1]);
                        tiquList.Add(aa[2]);
                    }
                    else
                    {
                        tiquList.Add(aa[0]);
                        tiquList.Add(aa[1]);
                    }
                }
                //===================提取一下==================
                read = sr.ReadLine();            
            }



            //==================去重============================
            List<String> listQuchong = new List<String>();
            foreach (var it in tiquList)//遍历重复集合
            {
                if (listQuchong.Count == 0)
                {
                    listQuchong.Add(it);
                    continue;
                }
                int a = 0;
                foreach (var item in listQuchong)
                {
                    if (item.Equals(it))
                    {
                        a = 1;

                        break;//一旦找到说明找到了，那么就可以终止了，此时等于一加个break，否则又出bug了
                    }
                }

                if (a == 1)
                {
                    continue;
                }
                else
                {
                    listQuchong.Add(it);
                }
            }
            //==================去重============================

            Console.WriteLine("总子式个数为："+listQuchong.Count());

        }

        //=======================下面是把要训练和测试三三一组===============================



        //=======================三目运算符弄一下==============================
        public void sanmu()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\三个一组求和号\\1.txt", Encoding.Default);
            String read = sr.ReadLine();

            StreamWriter sw = new StreamWriter("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\三个一组求和号\\2.txt");
            while (read != null)
            {
                //每进来一个数学表达式，把它的所有子信息全部用一个新的list装吧
                List<String> listNew = new List<String>();
                listNew = Test4(read);

                foreach (var it in listNew)
                {
                    sw.WriteLine(it);

                }

                read = sr.ReadLine();
                sw.Flush();
            }

        }
        //=======================三目运算符弄一下==============================



        public List<String> Test4(String LaTeX)
        {
            //开始层次遍历
            List<String> list = new List<String>();
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
                //第一种情况是：可交换运算符且左右都不空
                if ((tempNode.left != null && tempNode.right != null && JiaoHuanOperator(tempNode.zifu)))
                {
                    String strs1 = "";
                    String strs2 = "";



                    strs1 = Test5(tempNode.left) + tempNode.left.Flag + tempNode.zifu + tempNode.Flag + "#" + tempNode.zifu + tempNode.Flag + Test5(tempNode.right) + tempNode.right.Flag;// 

                    

                    

                    strs2 = Test5(tempNode.right) + tempNode.right.Flag +  tempNode.zifu + tempNode.Flag + "#" + tempNode.zifu + tempNode.Flag + Test5(tempNode.left) + tempNode.left.Flag;

                    list.Add(strs1);
                    list.Add(strs2);

                    //Console.WriteLine("第一种情况：" + tempNode.zifu);
                    //Console.WriteLine("============第一种情况=================");
                }

                //第二种情况是：不可交换运算符且左右都不空，类似减号
                if ((tempNode.left != null && tempNode.right != null && !JiaoHuanOperator(tempNode.zifu)))
                {
                    String strs1 = "";


                    strs1 = Test5(tempNode.left) + tempNode.left.Flag + tempNode.zifu + tempNode.Flag + "#" + tempNode.zifu + tempNode.Flag + Test5(tempNode.right) + tempNode.right.Flag;// 

                    list.Add(strs1);

                    //Console.WriteLine("============第二种情况=================");
                    //Console.WriteLine("第二种情况：" + tempNode.zifu);
                }

                //第三种情况：类似根号形式的
                if ((tempNode.left != null && tempNode.right == null && !JiaoHuanOperator(tempNode.zifu)))
                {
                    String strs1 = "";
                    strs1 = tempNode.zifu + tempNode.Flag + "#" + Test5(tempNode.left) + tempNode.left.Flag;// "+","左节点"  
                    list.Add(strs1);

                    //Console.WriteLine("这里应该是根号：" + tempNode.zifu);
                    //Console.WriteLine("============第三种情况=================");
                }










                //第一个节点出队
                q.Dequeue();

                if (tempNode.left != null)
                {
                    //tempNode.left.xuhao = tempNode.xuhao * 2;
                    //Console.WriteLine("++++++++++++++left" + tempNode.left.xuhao);
                    q.Enqueue(tempNode.left);
                }
                if (tempNode.right != null)
                {
                    //tempNode.right.xuhao = tempNode.xuhao * 2 + 1;
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




        //判断是可交换运算符
        private Boolean JiaoHuanOperator(String zifu)
        {
            Boolean a = false;
            if (zifu.Equals("+") || zifu.Equals("*") || zifu.Equals("\\times") || zifu.Equals("=") || zifu.Equals("\\neq")
                || zifu.Equals("\\approx") || zifu.Equals("\\cdot") || zifu.Equals("\\equiv") || zifu.Equals(":") || zifu.Equals("\\overline")
                || zifu.Equals("\\arg")   || zifu.Equals("\\mid") || zifu.Equals("\\bar") || zifu.Equals("\\vec") || zifu.Equals("\\hat")
                || zifu.Equals("\\or")  || zifu.Equals("\\lor") || zifu.Equals("\\cap") || zifu.Equals("\\cup") || zifu.Equals("\\cong") || zifu.Equals("\\colon")  
               )
             {
                a = true;
             }
            return a;
            // TODO Auto-generated method stub	
        }

        //判断是运算符
        private Boolean isOperator(String zifu)
        {
            Boolean a = false;
            if (zifu.Equals("-")  ||  zifu.Equals("/") || zifu.Equals("\\frac") || zifu.Equals("#") || zifu.Equals("^") ||  zifu.Equals("\\sqrt") || zifu.Equals("_")
                || zifu.Equals("\\leq") || zifu.Equals("\\geq") || zifu.Equals(">") || zifu.Equals("<") || zifu.Equals("\\sin") || zifu.Equals("\\cos") || zifu.Equals("\\tan")
                || zifu.Equals("\\cot") || zifu.Equals("\\sec") || zifu.Equals("\\csc") || zifu.Equals("\\arcsin") || zifu.Equals("\\arccos") || zifu.Equals("\\arctan") || zifu.Equals("\\arccot") || zifu.Equals("\\arcsec")
                || zifu.Equals("\\arccsc") || zifu.Equals("\\gg")  || zifu.Equals("\\pm")    || zifu.Equals("\\to") 
                || zifu.Equals("\\log")  || zifu.Equals("\\Rightarrow") || zifu.Equals("\\rightarrow") || zifu.Equals("\\quad")  
                || zifu.Equals("\\qquad") || zifu.Equals("\\implies") || zifu.Equals("\\lim") || zifu.Equals("\\sum") || zifu.Equals("\\join") || zifu.Equals("\\connect") || zifu.Equals("\\PowerRoot") || zifu.Equals("\\DuiShu") || zifu.Equals("\\log") || zifu.Equals("\\temp") || zifu.Equals("\\max") || zifu.Equals("\\lnot")
                || zifu.Equals("\\mathbb") || zifu.Equals("\\subset") || zifu.Equals("\\in") || zifu.Equals("\\mathcal") || zifu.Equals("\\tfrac")  || zifu.Equals("\\mathbf")
                || zifu.Equals("\\ll") || zifu.Equals("\\mathrm")  || zifu.Equals("\\tilde") || zifu.Equals("\\dashv") || zifu.Equals("\\dot"))
            {
                a = true;
            }
            return a;
            // TODO Auto-generated method stub	
        }


        public void CountCount()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\A最后一个吧\\vocab.txt", Encoding.Default);
            String read = sr.ReadLine();
            String str = "";
            while (read != null)
            {
                //Console.WriteLine(read);
                str = str + read;
                read = sr.ReadLine();

            }
            //Console.WriteLine("艹鞍山市大大所多撒"+str);
            String[] cao = str.Split(' ');
            Console.WriteLine("草拟吗啊啊啊啊啊啊啊啊啊啊啊啊啊啊"+cao.Count());

        }

        public void C()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\A毕业和成年的字眼格外扣人心弦\\第一篇小论文\\退稿通知\\实验数据\\A最后一个吧\\11.txt", Encoding.Default);
            String read = sr.ReadLine();

            //每进来一个数学表达式，把它的所有子信息全部用一个新的list装吧
            List<String> listNew = new List<String>();
            while (read != null)
            {
                

                listNew.Add(read);


                read = sr.ReadLine();
            }
            //==================去重============================
            List<String> listQuchong = new List<String>();
            foreach (var it in listNew)//遍历重复集合
            {
                if (listQuchong.Count == 0)
                {
                    listQuchong.Add(it);
                    continue;
                }
                int a = 0;
                foreach (var item in listQuchong)
                {
                    if (item.Equals(it))
                    {
                        a = 1;

                        break;//一旦找到说明找到了，那么就可以终止了，此时等于一加个break，否则又出bug了
                    }
                }

                if (a == 1)
                {
                    continue;
                }
                else
                {
                    listQuchong.Add(it);
                }



            }

            Console.WriteLine("qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq"+listQuchong.Count());
            //==================去重============================
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

