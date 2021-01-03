using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功重写
{
    public class AACount
    {
        public void Count()
        {
            StreamReader sr = new StreamReader("C:\\Users\\Administrator\\Desktop\\最终版组合测试添加数据用来修改的\\最终版组合测试添加数据用来修改的\\14最终版组合测试模糊匹配有点毛病啊，已解决14\\第二个实验测试数据\\2.txt");
            int a = 0;
            String read = sr.ReadLine();
            Dictionary<string, int> dic = new Dictionary<string, int>();
            while (read != null)
            {
                String[] str = read.Split('#');
                for (int i = 0; i < str.Length-1; i++)
                {
                    if (dic.Count == 0)
                    {
                        dic.Add(str[i], 1);
                        continue;
                    }
                    else if (dic.ContainsKey(str[i]))
                    {
                        continue;
                    }
                    else
                    {
                        dic.Add(str[i],1);
                    }
                }
      

                a++;
                read = sr.ReadLine();
                if (read == null)
                {
                    break;
                }


            }

            //Console.WriteLine("总个数为："+a);
            int cao = 0;
            foreach (var it in dic)
            {
                cao++;
                Console.WriteLine("哈哈："+it.Key);
            }
            Console.WriteLine("哈哈："+cao);

        }
    }
}