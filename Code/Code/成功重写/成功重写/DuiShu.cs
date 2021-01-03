using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功重写
{
    public class DuiShu
    {
        public String duiShu(String cao)
        {
            //\\log_{2}N
            //   \\logarithm
            String final = "";
            Stack<String> stack = new Stack<String>();
            char[] caos = cao.ToCharArray();
            for (int i = 0; i < caos.Length; i++)
            {
                //规则1：如果负号是第一个出现的话
                if (Convert.ToString(caos[i]).Equals("\\") && Convert.ToString(caos[i + 1]).Equals("l") && Convert.ToString(caos[i + 2]).Equals("o") && Convert.ToString(caos[i + 3]).Equals("g") && Convert.ToString(caos[i + 4]).Equals("_") && Convert.ToString(caos[i + 5]).Equals("{"))
                {
                    final = final + "\\log_{";
                    stack.Push("\\log_{");
                    i = i + 5;
                }
                else if (stack.Count == 1 && stack.Peek().Equals("\\log_{") && Convert.ToString(caos[i]).Equals("}"))
                {
                    final = final + Convert.ToString(caos[i]) + "\\DuiShu";
                    stack.Pop();
                }
                //其它的就是最一般的直接添加即可
                else
                {
                    final = final + Convert.ToString(caos[i]);
                }
            }
            final = final.Replace("\\log_", "\\temp");
            //Console.WriteLine("NciGenHao.cs又要草拟吗了啊：" + final);
            return final;

            
        }
    }
}
