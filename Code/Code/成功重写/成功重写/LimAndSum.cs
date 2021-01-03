using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功重写
{
    public class LimAndSum
    {
        public String limAndSum(String cao)
        {
            //String temp = "\\lim{\\sqrt{a}\\lim{a+b}}\\frac{a}{b}=1";
            String final = "";
            char[] caos = cao.ToCharArray();
            for (int i = 0; i < caos.Length; i++)
            {
                if (Convert.ToString(caos[i]).Equals("\\") && Convert.ToString(caos[i + 1]).Equals("l") && Convert.ToString(caos[i + 2]).Equals("i") && Convert.ToString(caos[i + 3]).Equals("m") && Convert.ToString(caos[i + 4]).Equals("_"))
                {
                    final = final + "\\lim";
                    i = i + 4;
                }
                else if (Convert.ToString(caos[i]).Equals("\\") && Convert.ToString(caos[i + 1]).Equals("s") && Convert.ToString(caos[i + 2]).Equals("u") && Convert.ToString(caos[i + 3]).Equals("m") && Convert.ToString(caos[i + 4]).Equals("_"))
                {
                    final = final + "\\sum";
                    i = i + 4;
                }
                else
                {
                    final = final + Convert.ToString(caos[i]);
                }
            }
            Stack<String> stack1 = new Stack<String>();
            String final2 = "";
            char[] caos2 = final.ToCharArray();
            for (int j = 0; j < caos2.Length; j++)
            {
                //必须是遇到lim{，才可以把左括号压进去啊，比如极限里面有lim{什么sqrt{}}，就不压入
                if (Convert.ToString(caos2[j]).Equals("\\") && Convert.ToString(caos2[j + 1]).Equals("l") && Convert.ToString(caos2[j + 2]).Equals("i") && Convert.ToString(caos2[j + 3]).Equals("m") && Convert.ToString(caos2[j + 4]).Equals("{"))
                {
                    final2 = final2 + "\\lim" + "{";
                    j = j + 4;
                    stack1.Push("lim{");//必须是遇到lim{
                }
                else if (Convert.ToString(caos2[j]).Equals("{"))
                {
                    stack1.Push("{");
                    final2 = final2 + Convert.ToString(caos2[j]);
                }
                else if (Convert.ToString(caos2[j]).Equals("}") && stack1.Count > 0 && stack1.Peek().Equals("lim{"))//如果遇到右括号，且栈顶元素为lim{，
                {
                    final2 = final2 + Convert.ToString(caos2[j]) + "\\join";
                    stack1.Pop();
                }
                else if (Convert.ToString(caos2[j]).Equals("}") && stack1.Count > 0 && stack1.Peek().Equals("{"))//如果遇到右括号，且栈顶元素为普通的{，
                {
                    stack1.Pop();
                    final2 = final2 + Convert.ToString(caos2[j]);
                }
                else
                {
                    final2 = final2 + Convert.ToString(caos2[j]);
                }
            }


            //====================================下面对含有\\sum的再次处理，只能用笨方法了，实在没辙了
            //=====================================以\\sum{k=0}^{n-1}2^{k}=n-1为例子==============================================
            String final3 = "";
            char[] caos3 = final2.ToCharArray();
            Stack<String> stack3 = new Stack<String>();
            for (int k = 0; k < caos3.Length; k ++)
            {
                //必须是遇到sum{，才可以把左括号压进去啊，比如极限里面有sum{什么sqrt{}}，就不压入
                if (Convert.ToString(caos3[k]).Equals("\\") && Convert.ToString(caos3[k + 1]).Equals("s") && Convert.ToString(caos3[k + 2]).Equals("u") && Convert.ToString(caos3[k + 3]).Equals("m") && Convert.ToString(caos3[k + 4]).Equals("{"))
                {
                    final3 = final3 + "\\sum" + "{";
                    k = k + 4;
                    stack3.Push("sum{");//必须是遇到sum{，说明此时第一次碰到含有sum的了
                }
                //下面如果遇到右括号的话，注意天底下右括号多的是，所以可不是普通的右括号啊，应该是“专属于”“\\sum”的右括号
                else if (stack3.Count() > 0 && Convert.ToString(caos3[k]).Equals("}") && stack3.Peek().Equals("sum{"))
                {
                    final3 = final3 + Convert.ToString(caos3[k]);
                }
                //就算遇到左括号的话，那也不能随便操作，天底下左括号多的是，所有左括号都压入那还了得，所以应该是“专属于”“\\sum”的左括号
                //这是第一次遇到上标“^”的这个左括号，所以得压入栈中，此时里面“第一次压的是“sum{””，第二次压的“{”，现在栈中有两个了啊，注意

                //我现在是默认上面例子“\\sum{k=0}^{n-1}2^{k}=n-1”中“k=0这个括号里面“应该不可能再有根号什么的吧””，
                //==========================我真想多了，根本就没有什么其它根号啥的，几乎就没有啊=======================
                else if (stack3.Count()>0 && Convert.ToString(caos3[k]).Equals("{") && stack3.Peek().Equals("sum{"))
                {
                    //把第一次这个挨着上标的这个左括号压进去，但是压之前还得把这个括号给拿上啊
                    final3 = final3 + Convert.ToString(caos3[k]);
                    stack3.Push("{");
                }
                
                else if (Convert.ToString(caos3[k]).Equals("}") && stack3.Count() == 2)
                {
                    //先把这个括号给添加上,然后，该释放“栈里的“sum”和那个括号了，相当于判断标志吧”
                    final3 = final3 + Convert.ToString(caos3[k]) + "\\connect";
                    stack3.Pop();//弹出去说明释放了，一个含有sum的周期结束了
                    stack3.Pop();//弹出去说明释放了，一个含有sum的周期结束了
                }
                else
                {
                    final3 = final3 + Convert.ToString(caos3[k]);
                }
            }

            //Console.WriteLine("LimAndSum.cs："+final3);

            return final3;
        }


    }
}
