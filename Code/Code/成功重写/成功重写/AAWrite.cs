using DBhelper类封装起来;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class AAWrite
    {

        public void GloVe()
        {
            //42706
            StreamReader sr = new StreamReader("I:\\Python\\PythonProject\\GloVe模型\\原版笑傲江湖.txt", Encoding.Default);
            StreamWriter sw = new StreamWriter("I:\\Python\\PythonProject\\GloVe模型\\笑傲江湖.txt");
            int a = 0;
            String read = sr.ReadLine();
            while (read != null)
            {
                a++;
                //if (a == 40000)
                //{
                //    break;
                //}
                sw.WriteLine(read);
                read = sr.ReadLine();
            }

            Console.WriteLine("最终结果："+a);

            sw.Flush();


        }




        //重新写结构
        public void WriteStructure()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\1.txt", Encoding.Default);
            StreamWriter sw = new StreamWriter("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\2.txt");
            String read = sr.ReadLine();


            while (read != null)
            {
                //开始层次遍历
                Dictionary<int, List<String>> dic = new Dictionary<int, List<string>>();
                BinaryTreeNode bnode = new BinaryTreeNode();
                FinalNode1 root = new FinalNode1();
                FinalNode1 tempNode = new FinalNode1();




                root = bnode.getNode(read);
                root.xuhao = 1;
                tempNode = root;//临时指向根结点
                Queue<FinalNode1> q = new Queue<FinalNode1>();
                q.Enqueue(root);
                while (q.Count != 0)
                {
                    //指向队列第一个字符
                    tempNode = q.First();

                    if (dic.Count == 0)
                    {
                        List<String> list = new List<string>();
                        list.Add(tempNode.zifu + "1" + "1");
                        dic.Add(tempNode.BTreeLevel, list);
                    }
                    else
                    {
                        if (dic.ContainsKey(tempNode.BTreeLevel))
                        {
                            if (isOperator(tempNode.zifu))
                            {
                                dic[tempNode.BTreeLevel].Add(tempNode.zifu + tempNode.BTreeLevel + tempNode.xuhao);
                            }
                            else
                            {
                                dic[tempNode.BTreeLevel].Add("$" + tempNode.BTreeLevel + tempNode.xuhao);
                            }
                            
                        }
                        else
                        {
                            if (isOperator(tempNode.zifu))
                            {
                                List<String> list = new List<string>();
                                list.Add(tempNode.zifu + tempNode.BTreeLevel + tempNode.xuhao);
                                dic.Add(tempNode.BTreeLevel, list);
                            }
                            else
                            {
                                List<String> list = new List<string>();
                                list.Add("$" + tempNode.BTreeLevel + tempNode.xuhao);
                                dic.Add(tempNode.BTreeLevel, list);
                            }

                        }
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




                //开始写了
                String str = null;
                foreach (var it in dic)
                {
                    String text = "";
                    foreach (var itt in it.Value)
                    {
                        text = text + itt;
                    }
                    str = str + text + "#";
                }

                str = str + read;

                Console.WriteLine("结果为："+str);
                sw.WriteLine(str);

                read = sr.ReadLine();
            }//读取内容

            sw.Flush();
        }

        public void insertData()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\1.txt", Encoding.Default);
            String read = sr.ReadLine();
            while (read != null)
            {
                bool panduan;
                string sqlstr = "insert into Test(数学公式) values ('" + read + "')";
                panduan = DBhelper.InsertUpdateDal(sqlstr);
                if (panduan == true)
                {
                    //Console.Write("操作成功");
                }
                else
                {
                    //Console.Write("操作失败");
                }
                read = sr.ReadLine();
            }
        }


        public void WriteTxt()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\日了\\1.txt", Encoding.Default);
            StreamWriter sw = new StreamWriter("C:\\Users\\dell\\Desktop\\日了\\不重复.txt");
            String read = sr.ReadLine();

            Dictionary<string, int> dic = new Dictionary<string, int>();

            while (read != null)
            {
                String[] s = read.Split('#');

                if (dic.Count == 0)
                {
                    dic.Add(s[s.Length - 1], 1);
                }
                else
                {
                    if (dic.ContainsKey(s[s.Length - 1]))
                    {

                    }
                    else
                    {
                        dic.Add(s[s.Length - 1], 1);
                    }

                }



                read = sr.ReadLine();
            }

            foreach (var it in dic)
            {
                sw.WriteLine(it.Key);
            }
            sw.Flush();



        }

        public void Cao()
        {

            StreamWriter sw = new StreamWriter("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\1.txt");
            String path = "C:\\Users\\dell\\Desktop\\暑假\\result";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles();
            
            for (int i = 0; i < files.Length; i++)
            {
                if (i == 100)
                    break;
                //Console.WriteLine(files.Length);

                if (files[i].Extension.Equals(".txt"))   //判断是否为txt文件
                {
                    StreamReader sr = new StreamReader(path + "\\" + files[i].Name, Encoding.Default);
                    String read = sr.ReadLine();
                    
                    while (read != null)
                    {
                        sw.WriteLine(read);
                        read = sr.ReadLine();
                    }
                    sw.Flush();

                }
            }
                
        
         }

        public void Test()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\新建文件夹\\result.txt", Encoding.Default);
            String read = sr.ReadLine();
            
            while (read != null)
            {
                Console.WriteLine(read);
                Console.WriteLine("==========================================");

                read = sr.ReadLine();
            }
            

        }



        public void WriteReplace()
        {
            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\2.txt", Encoding.Default);
            StreamWriter sw = new StreamWriter("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\3.txt");
            String read = sr.ReadLine();
            int hang = 0;
            while (read != null)
            {
                if (read.Contains("#") && !read.Contains("1\fracx#\frac{1}{x}"))
                {
                    //每读完一行之后
                    String[] str = read.Split('#');
                    String newStr = null;
                    for (int i = 0; i < str.Length - 1; i++)
                    {
                        newStr = newStr + str[i] + "#";
                    }
                    hang++;
                    Console.WriteLine("第" + hang + "行" + "：" + newStr);

                    if (newStr.Contains("a+b") || newStr.Contains("A+B"))
                    {
                        read = read.Replace("a+b", "1\\fracx");
                        read = read.Replace("A+B", "1\\fracx");
                        sw.WriteLine(read);
                    }
                }
                 
                read = sr.ReadLine();
            }
            sw.Flush();

        }


        public void WriteData()
        {
            
            //第一步：先把txt所有数学公式读入内存
            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
            StreamWriter sw = new StreamWriter("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\2.txt");
            List<AAIndex> indexList = new List<AAIndex>();
            DuiShu duishu = new DuiShu();
            FuShu fuShu = new FuShu();
            String read = sr.ReadLine();
            read = duishu.duiShu(read);
            read = fuShu.fuShu(read);

            



            int a = 0;
            while (read != null)
            {
                //if (a == 1)
                //{
                //    break;

                //}
                //a++;

                List<FinalNode1> AdjacentNodeList = new List<FinalNode1>();
                AdjacentNode ad = new AdjacentNode();
                AdjacentNodeList = ad.AdjacentNodeList(read);
                String str = null;


                //这个是每一个字符串
                //现在这个是中序遍历好的节点
                List<String> ji = new List<string>();
                foreach (var it in AdjacentNodeList)
                {
                    //第一：如果左右节点都为操作数
                    if (isOperator(it.zifu)&& it.left!= null && it.right != null && !isOperator(it.left.zifu) && !isOperator(it.right.zifu))
                    {
                        List<FinalNode1> nodeList = new List<FinalNode1>();
                        middleBianLi zhongxu = new middleBianLi(nodeList, it);
                        String strr = null;
                        foreach (var itt in nodeList)
                        {
                            strr = strr + itt.zifu;
                            //Console.WriteLine("链接为："+itt.zifu);
                        }
                        //foreach (var itt in nodeList)
                        //{
                        //    if (isOperator(itt.zifu))
                        //    {
                        //        strr = strr + itt.BTreeLevel;
                        //    }
                        //}
                        ji.Add(strr);
                    }
                    //第二：如果左节点是操作数，右节点是操作符
                    if (isOperator(it.zifu) && it.left != null && it.right != null && !isOperator(it.left.zifu) && isOperator(it.right.zifu))
                    {
                        ji.Add(it.left.zifu /*+ it.left.BTreeLevel*/);
                        ji.Add(it.zifu/*+it.BTreeLevel*/);
                    }
                    //第三：如果左节点是操作符，右节点是操作数
                    if (isOperator(it.zifu) && it.left != null && it.right != null && isOperator(it.left.zifu) && !isOperator(it.right.zifu))
                    {
                        ji.Add(it.zifu /*+ it.BTreeLevel*/);
                        ji.Add(it.right.zifu /*+ it.right.BTreeLevel*/);
                        
                    }
                    //第四：如果左右节点都是操作符
                    if (isOperator(it.zifu) && it.left != null && it.right != null && isOperator(it.left.zifu) && isOperator(it.right.zifu))
                    {
                        ji.Add(it.zifu /*+ it.BTreeLevel*/);                        
                    }
                    //第五：类似sina
                    if (isOperator(it.zifu) && it.left != null && it.right == null && !isOperator(it.left.zifu) )
                    {

                        ji.Add(it.left.zifu+it.zifu);
                    }
                    //第六：类似sin（a+b）
                    if (isOperator(it.zifu) && it.left != null && it.right == null && isOperator(it.left.zifu))
                    {

                        ji.Add(it.zifu /*+ it.BTreeLevel*/);
                    }

                    //if (isOperator(it.zifu) && it.left!=null && it.right != null && !isOperator(it.left.zifu) && !isOperator(it.right.zifu))
                    //{
                    //    //如果该字符是运算符且左右节点都是运算数，说明它是个子树
                    //    //把中序遍历好的每一个节点存入集合当中
                    //    //Console.WriteLine("哈哈哈："+it.zifu);
                    //    List<FinalNode1> nodeList = new List<FinalNode1>();
                    //    middleBianLi zhongxu = new middleBianLi(nodeList, it);
                    //    String strr = null;
                    //    foreach (var itt in nodeList)
                    //    {
                    //        strr = strr + itt.zifu;
                    //        //Console.WriteLine("链接为："+itt.zifu);
                    //    }
                    //    foreach (var itt in nodeList)
                    //    {
                    //        if (isOperator(itt.zifu))
                    //        {
                    //            strr = strr + itt.BTreeLevel;
                    //        }
                    //    }
                    //    ji.Add(strr);
                    //}
                    //else if (it.left != null && it.right != null && isOperator(it.left.zifu) && !isOperator(it.right.zifu))
                    //{
                    //    ji.Add(it.zifu+it.BTreeLevel);
                    //    ji.Add(it.right.zifu+it.right.BTreeLevel);
                    //}
                    //else if (it.left != null && it.right != null && !isOperator(it.left.zifu) && isOperator(it.right.zifu))
                    //{
                    //    ji.Add(it.left.zifu+ it.left.BTreeLevel);
                    //    ji.Add(it.zifu+it.BTreeLevel);
                    //}




                }

                foreach (var itt in ji)
                {
                    str = str + itt + "#";
                }

                str = str + read;
                sw.WriteLine(str);
                //Console.WriteLine("草泥马了：" + str);
                //Console.WriteLine("==============================");



                read = sr.ReadLine();
                if (read == null)
                {
                    break;
                }
                read = duishu.duiShu(read);
                read = fuShu.fuShu(read);
            }
            //Console.WriteLine("哪出bug了：===============");
            //开始写了
            //foreach (var it in indexList)
            //{
            //    if (it.zishiStructure.Equals(""))
            //    {
            //        sw.WriteLine(it.zishi + "#" + " " + "#" + it.LaTeX + "#" + it.xuhao);
            //    }
            //    else
            //        sw.WriteLine(it.zishi + "#" + it.zishiStructure + "#" + it.LaTeX + "#" + it.xuhao);
            //}
            sw.Flush();

        }

        public void CountZiShi()
        {
            StreamReader sr = new StreamReader("C:\\Users\\dell\\Desktop\\暑假\\实验数据\\2.txt", Encoding.Default);
            String read = sr.ReadLine();
            int hang = 0;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            while (read != null)
            {
                String[] str = read.Split('#');
                String newStr = null;
                for (int i = 0; i < str.Length - 1; i++)
                {
                    if (dic.Count == 0)
                    {
                        dic.Add(str[i], 1);
                        continue;
                    }
                    else
                    {
                        if (dic.ContainsKey(str[i]))
                        {
                            dic[str[i]]++;
                        }
                        else
                        {
                            dic.Add(str[i],1);
                        }

                    }
                    
                }

                read = sr.ReadLine();
            }

            List<Tada> li = new List<Tada>();

            foreach (var it in dic)
            {
                Tada t = new Tada();
                t.zifu = it.Key;
                t.count = it.Value;
                li.Add(t);
            }

            Console.WriteLine("啊啊啊啊啊啊啊："+dic.Count);

            Tada temp = new Tada();

            for (int i = 0; i < li.Count-1; i++)
            {
                for (int j=i+1; j < li.Count; j++)
                {
                    if (li[j].count < li[i].count)
                    {
                        temp = li[j];
                        li[j] = li[i];
                        li[i] = temp;
                    }
                }
            }

            foreach (var it in li)
            {
                Console.WriteLine("字符："+it.zifu +"\t" + "次数："+it.count);
            }
            
        }



        //判断是运算符
        private Boolean isOperator(String zifu)
        {
            Boolean a = false;
            if (zifu.Equals("+") || zifu.Equals("-") || zifu.Equals("*") || zifu.Equals("\\times") || zifu.Equals("/") || zifu.Equals("lgroup") || zifu.Equals("group") || zifu.Equals("\\frac") || zifu.Equals("#") || zifu.Equals("^") || zifu.Equals("=") || zifu.Equals("\\sqrt") || zifu.Equals("_")
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


        //这个方法是把数据写入txt文件，到时候写入SQLServer里面，因为我现在没有内存下载数据库了
        public void Write()
        {
            //先测试一下
            //StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\测试建索引\\1.txt", Encoding.Default);
            //StreamWriter sw = new StreamWriter("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\测试建索引\\2.txt");

            //第一步：先把txt所有数学公式读入内存
            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\1.txt", Encoding.Default);
            StreamWriter sw = new StreamWriter("C:\\Users\\Administrator\\Desktop\\第二篇论文实验读写数据库\\2.txt");

            List<AAIndex> indexList = new List<AAIndex>();

            DuiShu duishu = new DuiShu();
            FuShu fuShu = new FuShu();
            String read = sr.ReadLine();
            read = duishu.duiShu(read);
            read = fuShu.fuShu(read);

            int a = 0;


            while (read != null)
            {
                //if (a == 100)
                //{
                //    break;

                //}
                //a++;
                //先读每一个数学公式，然后把每一个数学公式的子式、子式结构和该数学公式提取出即可
                
                //Console.WriteLine(read);
                Dictionary<int, List<FinalNode1>> children = new Dictionary<int, List<FinalNode1>>();
                ChildrenBTree childrenBTree = new ChildrenBTree();
                children = childrenBTree.childrenBTree(read);

                //这个是获取一个LaTeX的每一个子式
                foreach (var it in children)
                {
                    //定义每一个子式
                    String zishi = "";

                    //定义每一个子式结构
                    String zishiStructure = "";

                    foreach (var itt in it.Value)
                    {
                        zishi = zishi + itt.zifu;
                        
                        if (isSpecialYunSuanShu(itt.zifu))
                        {

                        }
                        else
                            zishiStructure = zishiStructure + itt.zifu;      
                    }
                    //Console.WriteLine("子式：" + zishi);
                    AAIndex index = new AAIndex();
                    index.zishi = zishi;
                    index.zishiStructure = zishiStructure;
                    index.LaTeX = read;
                    
                    indexList.Add(index);
                }

                

                read = sr.ReadLine();
                if (read == null)
                {
                    break;
                }
                read = duishu.duiShu(read);
                read = fuShu.fuShu(read);
            }
            //Console.WriteLine("哪出bug了：===============");
            //开始写了
            foreach (var it in indexList)
            {
                if (it.zishiStructure.Equals(""))
                {
                    sw.WriteLine(it.zishi + "#" + " " + "#" + it.LaTeX + "#" + it.xuhao);
                }
                else
                    sw.WriteLine(it.zishi + "#" + it.zishiStructure + "#" + it.LaTeX + "#" + it.xuhao);
            }
            sw.Flush();

        }

        //判断是特殊运算数，比如\\pi，\\alpha，或者\\beta，先是一个再说，实在不行到时候再弄个类，把这些特殊字符同时放一起不就行了
        public Boolean isSpecialYunSuanShu(String zifu)
        {
            int a = 0;
            if (System.Text.RegularExpressions.Regex.IsMatch(zifu, @"^[A-Za-z0-9]+$")  || zifu.Equals("\\alpha") || zifu.Equals("\\Alpha") || zifu.Equals("\\beta") || zifu.Equals("\\chi") || zifu.Equals("\\delta") || zifu.Equals("\\varepsilon") || zifu.Equals("\\phi") || zifu.Equals("\\varphi") || zifu.Equals("\\gamma") || zifu.Equals("\\eta") || zifu.Equals("\\ell") || zifu.Equals("\\pi")
                || zifu.Equals("\\infty") || zifu.Equals("\\iota") || zifu.Equals("\\Iota") || zifu.Equals("\\kappa") || zifu.Equals("\\Kappa") || zifu.Equals("\\lambda") || zifu.Equals("\\mu") || zifu.Equals("\\nu") || zifu.Equals("\\varpi") || zifu.Equals("\\theta") || zifu.Equals("\\vartheta") || zifu.Equals("\\rho") || zifu.Equals("\\sigma") ||
                zifu.Equals("\\varsigma") || zifu.Equals("\\tau") || zifu.Equals("\\Tau") || zifu.Equals("\\upsilon") || zifu.Equals("\\omega") || zifu.Equals("\\omega") || zifu.Equals("\\xi") || zifu.Equals("\\psi") || zifu.Equals("\\zeta") || zifu.Equals("\\Zeta") || zifu.Equals("\\Delta") || zifu.Equals("\\Phi") ||
                zifu.Equals("\\Gamma") || zifu.Equals("\\Lambda") || zifu.Equals("\\Pi") || zifu.Equals("\\pi") || zifu.Equals("\\Theta") || zifu.Equals("\\Sigma") || zifu.Equals("\\Upsilon") || zifu.Equals("\\Omega") || zifu.Equals("\\Xi") || zifu.Equals("\\Psi") || zifu.Equals("\\varepsilon") || zifu.Equals("\\prime")
                || zifu.Equals("\\epsilon") || zifu.Equals("\\ominus") || zifu.Equals("\\circ") || zifu.Equals("\\nabla") || zifu.Equals("\\partial") || zifu.Equals("\\Pr") || zifu.Equals("\\cdots") || zifu.Equals("\\therefore") || zifu.Equals("\\bigodot") || zifu.Equals("\\star") || zifu.Equals("\\hbar") || zifu.Equals("\\negative"))
                a = 1;
            if (a == 1)
                return true;
            return false;
        }

    }



}
