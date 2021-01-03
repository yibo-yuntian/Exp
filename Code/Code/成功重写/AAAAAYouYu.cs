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





    }




   }

