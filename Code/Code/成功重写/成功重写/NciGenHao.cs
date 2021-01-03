using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功重写
{
    public class NciGenHao
    {
        public String NcigenHao(String cao)
        {
            //这是一类n次根号下的东西啊，N次根号下就用“\PowerRoot”
            //y=\\sqrt[n]{a}
            String final = "";
            Stack<String> stack = new Stack<String>();
            char[] caos = cao.ToCharArray();
            for (int i = 0; i < caos.Length; i++)
            {
                //规则1：如果负号是第一个出现的话
                if (Convert.ToString(caos[i]).Equals("\\") && Convert.ToString(caos[i + 1]).Equals("s") && Convert.ToString(caos[i + 2]).Equals("q") && Convert.ToString(caos[i + 3]).Equals("r") && Convert.ToString(caos[i + 4]).Equals("t") && Convert.ToString(caos[i + 5]).Equals("["))
                {
                    final = final + "\\sqrt[";
                    stack.Push("\\sqrt[");
                    i = i + 5;
                }

                else if (stack.Count == 1 && stack.Peek().Equals("\\sqrt[") && Convert.ToString(caos[i]).Equals("]"))
                {
                    final = final + Convert.ToString(caos[i]) + "\\PowerRoot";
                    stack.Pop();
                }
                //其它的就是最一般的直接添加即可
                else
                {
                    final = final + Convert.ToString(caos[i]);
                }
            }
            //Console.WriteLine("NciGenHao.cs又要草拟吗了啊："+final);
            return final;

        }




    }
}
