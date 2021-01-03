using ConsoleApplication7;
using MathData.DocAnalyse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class FuZhiFeature
    {
        public List<FinalNode1> FuZhi(List<FinalNode1> finalList1,String LaTeX)
        {
            ExpUtil exputil = new ExpUtil();

            //Console.WriteLine("FuZhiFeature:传进来的LaTeX为:" + LaTeX);
            if (LaTeX.Contains("\\lim") || LaTeX.Contains("\\sum"))//如果含有lim的话，这个是含有lim的得特殊处理啊
            {
                //Console.WriteLine("FuZhiFeature:传进来的LaTeX为:" + LaTeX);
                LaTeX = LaTeX.Replace("\\join", "");
                LaTeX = LaTeX.Replace("\\connect", "");
                LaTeX = LaTeX.Replace("\\negative*", "-");
                LaTeX = LaTeX.Replace("\\negative", "-");
                LaTeX = LaTeX.Replace("\\PowerRoot", "");
                LaTeX = LaTeX.Replace("\\DuiShu", "");
                LaTeX = LaTeX.Replace("\\temp", "\\log_");
                //Console.WriteLine("替换后的LaTeX为:" + LaTeX);
                char[] limcaos = LaTeX.ToCharArray();
                LaTeX = "";
                for (int d = 0; d < limcaos.Length; d++)
                {
                    if (Convert.ToString(limcaos[d]).Equals("\\") && Convert.ToString(limcaos[d + 1]).Equals("l") && Convert.ToString(limcaos[d + 2]).Equals("i") && Convert.ToString(limcaos[d + 3]).Equals("m"))
                    {
                        //下面这个下标是为了使杨颂强那个给解析出特征然后赋给我啊，而我那个里面没有任何变动
                        LaTeX = LaTeX + "\\lim_";
                        d = d + 3;
                    }
                    else if (Convert.ToString(limcaos[d]).Equals("\\") && Convert.ToString(limcaos[d + 1]).Equals("s") && Convert.ToString(limcaos[d + 2]).Equals("u") && Convert.ToString(limcaos[d + 3]).Equals("m"))
                    {
                        LaTeX = LaTeX + "\\sum_";
                        d = d + 3;
                    }
                    else
                    {
                        LaTeX = LaTeX + Convert.ToString(limcaos[d]);
                    }
                }

                //Console.WriteLine("FuZhiFeature:处理的差不多了LaTeX:" + LaTeX);
                //============================================1、需要弄一系列特征，和杨颂强依次对应比较============================================   


                List<NodeInfo> temps = exputil.GetNodeList(LaTeX, 0);
                if (finalList1[finalList1.Count - 1].zifu.Equals("\\join") || finalList1[finalList1.Count - 1].zifu.Equals("\\connect"))//如果最后一个元素是“\\join”或者是“\\connect”
                {
                    List<FinalNode1> tempFinalist = new List<FinalNode1>();
                    for (int e = 0; e < finalList1.Count - 1; e++)
                    {
                        tempFinalist.Add(finalList1[e]);
                    }
                    finalList1 = tempFinalist;
                }

                /*foreach (var it in temps)
                {
                    Console.WriteLine("FuZhiFeature.cs:杨颂强字符:" + it.nodeexp + "Level：" + it.level + "Flag:" + it.flag);
                }

                foreach (var itt in finalList1)
                {
                    Console.WriteLine("FuZhiFeature.cs:我的字符:" + itt.zifu + "Level：" + itt.Level + "Flag:" + itt.Flag);
                }*/


                //Console.WriteLine("需要弄一系列特征的打印结果，所以先按原始序号，因此需要按照杨颂强那个顺序依次进行比较");
                int c = 0;
                for (int a = 0; a < finalList1.Count; a++)//外层循环肯定是LaTeX表达式，因为它里面字符多，比如有一些上标^,下标_在杨颂强里面没有解析
                {
                    if (temps[c].nodeexp.Equals("(") || temps[c].nodeexp.Equals(")")|| temps[c].nodeexp.Equals("[") || temps[c].nodeexp.Equals("]"))
                    {
                        //Console.WriteLine("执行了没啊:");
                        c++;
                        a--;
                        continue;

                    }
                    else if (finalList1[a].zifu.Equals(temps[c].nodeexp))//如果LaTeX字符与杨颂强节点字符相等，把杨颂强对应特征传进我的LaTeX对应节点里面
                    {
                        finalList1[a].Level = temps[c].level;
                        finalList1[a].Flag = temps[c].flag;
                        finalList1[a].Length = finalList1.Count;
                        c++;
                    }
                    else if (finalList1[a].zifu.Equals("^") || finalList1[a].zifu.Equals("_"))//如果不相等，说明肯定遇到了类似“上标”或者“下标”，到时候再添加
                    {
                        //既然遇到了“上标”或者“下标”，那就对它进行处理么
                        finalList1[a].Level = temps[c].level;
                        finalList1[a].Flag = temps[c].flag;
                        finalList1[a].Length = finalList1.Count;
                        Console.WriteLine("现在字符："+ finalList1[a].zifu + "\t" + "杨颂强字符：" + temps[c].nodeexp);

                    }
                    //这个是下面那个含有以谁为底，以其它为对数的
                    else if (finalList1[a].zifu.Equals("\\temp") && temps[c].nodeexp.Equals("\\log") && temps[c + 1].flag == 4)
                    {
                        //Console.WriteLine("怎么不能执行呢？");
                        finalList1[a].zifu = temps[c].nodeexp;
                        finalList1[a].Level = temps[c].level;
                        finalList1[a].Flag = temps[c].flag;
                        finalList1[a].Length = finalList1.Count;
                        c++;
                    }
                    //实际上没有下面的这个判断也行啊，也就是弄了半天，我就是把原来那个要解析的杨颂强的那个\\lim_这个极限符号给它加个下划线“_”，这样才能解析得到杨颂强的各项特征
                    //从而把各项特征传过来，传到我的这里啊
                    else if (finalList1[a].zifu.Equals("\\join") || finalList1[a].zifu.Equals("\\connect")|| finalList1[a].zifu.Equals("\\PowerRoot"))
                    {
                        continue;
                    }
                    else if (a == finalList1.Count - 1 && finalList1[a].zifu.Equals("\\negative"))
                    {
                        finalList1[a].Level = temps[c].level;
                        finalList1[a].Flag = temps[c].flag;
                        finalList1[a].Length = finalList1.Count;
                        c++;
                    }
                    else if (finalList1[a].zifu.Equals("\\negative") && finalList1[a + 1].zifu.Equals("*"))
                    {
                        finalList1[a].Level = temps[c].level;
                        finalList1[a].Flag = temps[c].flag;
                        finalList1[a].Length = finalList1.Count;
                        finalList1[a + 1].Level = temps[c].level;
                        finalList1[a + 1].Flag = temps[c].flag;
                        finalList1[a + 1].Length = finalList1.Count;
                        a++;
                        c++;
                    }
                    else if (a < finalList1.Count - 1 && finalList1[a].zifu.Equals("\\negative") && !finalList1[a + 1].zifu.Equals("*"))
                    {
                        finalList1[a].Level = temps[c].level;
                        finalList1[a].Flag = temps[c].flag;
                        finalList1[a].Length = finalList1.Count;
                        c++;
                    }


                }

                //用个栈来存放\lim元素，类似于左括号，我的\join是右括号
                Stack<FinalNode1> stack = new Stack<FinalNode1>();
                foreach (var it in finalList1)
                {
                    if (it.zifu.Equals("\\lim"))//相当于左括号
                    {
                        stack.Push(it);
                    }
                    else if (it.zifu.Equals("\\join"))//相当于右括号,遇到右括号的话
                    {
                        FinalNode1 tem = new FinalNode1();
                        tem = stack.Pop();//把栈里面的\lim给弹出来
                        it.Level = tem.Level;
                        it.Flag = tem.Flag;
                    }
                }

                /*foreach (var it in finalList1)
                {
                    Console.WriteLine("FuZhiFeature.cs就差\\sum了啊:" + it.zifu + "\t" + "Level:" + it.Level + "\t" + "Flag:" + it.Flag);
                }*/

                //用个栈来存放\sum元素，类似于左括号，我的“^”是右括号，先这么个简单的啊，我这里规定\sum的那个connect是与“上标的那个特征是一样的”
                Stack<FinalNode1> stack1 = new Stack<FinalNode1>();
                foreach (var it in finalList1)
                {
                    if (it.zifu.Equals("\\sum"))//相当于左括号
                    {
                        //Console.WriteLine("==========尼玛执行了吗1");
                        stack1.Push(it);
                        continue;
                    }
                    else if (stack1.Count == 1 && it.zifu.Equals("^") && stack1.Peek().zifu.Equals("\\sum"))
                    {
                        //Console.WriteLine("草你妈了个比");
                        stack1.Push(it);
                        continue;
                    }
                    else if (stack1.Count == 2 && it.zifu.Equals("\\connect") && stack1.Peek().zifu.Equals("^"))//此时仅仅有\\sum和第一个“^”
                    {
                        //Console.WriteLine("====================================尼玛执行了吗3");
                        FinalNode1 tem = new FinalNode1();
                        tem = stack1.Pop();//把栈里面的"^"给弹出来
                        it.Level = tem.Level;
                        it.Flag = tem.Flag;

                        Console.WriteLine("第三个：字符"+it.zifu + "\t" + "空间标志位：" + it.Flag + "\t" + "第三个：字符" + tem.zifu + "\t" + "空间标志位：" + tem.Flag);

                        stack1.Pop();
                        continue;
                    }
                }

                /*foreach (var itt in finalList1)
                {
                    Console.WriteLine("FuZhiFeature.cs:我的字符:" + itt.zifu + "Level：" + itt.Level + "Flag:" + itt.Flag);
                }*/


                //用个栈来存放\sqrt元素，类似于左括号，我的\PowerRoot是右括号
                Stack<FinalNode1> stack2 = new Stack<FinalNode1>();
                for (int i = 0; i < finalList1.Count; i++)
                {
                    if (finalList1[i].zifu.Equals("\\sqrt") && finalList1[i + 1].Flag == 7)//当前是根号，且和它相邻的下一个的字符flag为左上标，说明当前的这个根号是N次方根的那种
                    {
                        //Console.WriteLine("压入了几次啊");
                        stack2.Push(finalList1[i]);
                    }
                    else if (finalList1[i].zifu.Equals("\\PowerRoot"))//相当于右括号,遇到右括号的话
                    {
                        FinalNode1 tem = new FinalNode1();
                        tem = stack2.Pop();//把栈里面的\\PowerRoot给弹出来
                        finalList1[i].Level = tem.Level;
                        finalList1[i].Flag = tem.Flag;
                    }
                }
                //用个栈来存放\sqrt元素，类似于左括号，我的\PowerRoot是右括号
                /*Stack<FinalNode1> stack2 = new Stack<FinalNode1>();
                foreach (var it in finalList1)
                {
                    if (it.zifu.Equals("\\sqrt"))//相当于左括号
                    {
                        stack2.Push(it);
                    }
                    else if (it.zifu.Equals("\\join"))//相当于右括号,遇到右括号的话
                    {
                        FinalNode1 tem = new FinalNode1();
                        tem = stack2.Pop();//把栈里面的\lim给弹出来
                        it.Level = tem.Level;
                        it.Flag = tem.Flag;
                    }
                }*/

                //foreach (var it in finalList1)
                //{
                //    Console.WriteLine("FuZhiFeature.cs:"+it.zifu+"\t"+"Level:"+it.Level+"\t"+"Flag:"+it.Flag);
                //}

            }//含有特殊字符lim和sum的处理啊

            //else if (LaTeX.Contains("\\negative"))
            //{
            //    LaTeX = LaTeX.Replace("\\negative*", "-");
            //    LaTeX = LaTeX.Replace("\\negative", "-");
            //    List<NodeInfo> temps = exputil.GetNodeList(LaTeX, 0);
            //    foreach (var it in temps)
            //    {
            //        Console.WriteLine("FuZhiFeature.cs:杨颂强字符:" + it.nodeexp + "Level：" + it.level + "Flag:" + it.flag);
            //    }
            //    foreach (var itt in finalList1)
            //    {
            //        Console.WriteLine("FuZhiFeature.cs:我的字符:" + itt.zifu + "Level：" + itt.Level + "Flag:" + itt.Flag);
            //    }

            //    int c = 0;
            //    for (int a = 0; a < finalList1.Count; a++)//外层循环肯定是LaTeX表达式，因为它里面字符多，比如有一些上标^,下标_在杨颂强里面没有解析
            //    {
            //        if (finalList1[a].zifu.Equals(temps[c].nodeexp))//如果LaTeX字符与杨颂强节点字符相等，把杨颂强对应特征传进我的LaTeX对应节点里面
            //        {
            //            finalList1[a].Level = temps[c].level;
            //            finalList1[a].Flag = temps[c].flag;
            //            finalList1[a].Length = finalList1.Count;
            //            c++;
            //        }
            //        else if (finalList1[a].zifu.Equals("^") || finalList1[a].zifu.Equals("_"))//如果不相等，说明肯定遇到了类似“上标”或者“下标”，到时候再添加
            //        {
            //            //既然遇到了“上标”或者“下标”，那就对它进行处理么
            //            finalList1[a].Level = temps[c].level;
            //            finalList1[a].Flag = temps[c].flag;
            //            finalList1[a].Length = finalList1.Count;
            //        }
            //        //下面这种情况是数学表达式：“-\\frac{a}{b}”，对应的
            //        /*
            //             我：  \negative      *      \frac      a      b
            //             杨：      -        \frac      a       b
            //         */
            //        else if (a == finalList1.Count - 1 && finalList1[a].zifu.Equals("\\negative"))
            //        {
            //            finalList1[a].Level = temps[c].level;
            //            finalList1[a].Flag = temps[c].flag;
            //            finalList1[a].Length = finalList1.Count;
            //            c++;
            //        }
            //        else if (finalList1[a].zifu.Equals("\\negative") && finalList1[a + 1].zifu.Equals("*"))
            //        {
            //            finalList1[a].Level = temps[c].level;
            //            finalList1[a].Flag = temps[c].flag;
            //            finalList1[a].Length = finalList1.Count;
            //            finalList1[a + 1].Level = temps[c].level;
            //            finalList1[a + 1].Flag = temps[c].flag;
            //            finalList1[a + 1].Length = finalList1.Count;
            //            a++;
            //            c++;
            //        }
            //        else if (a<finalList1.Count-1 && finalList1[a].zifu.Equals("\\negative") && !finalList1[a + 1].zifu.Equals("*"))
            //        {
            //            finalList1[a].Level = temps[c].level;
            //            finalList1[a].Flag = temps[c].flag;
            //            finalList1[a].Length = finalList1.Count;
            //            c++;
            //        }
            //    }
            //}


            else
            {
                
                LaTeX = LaTeX.Replace("\\negative*", "-");
                LaTeX = LaTeX.Replace("\\negative", "-");
                LaTeX = LaTeX.Replace("\\PowerRoot", "");
                LaTeX = LaTeX.Replace("\\DuiShu", "");
                LaTeX = LaTeX.Replace("\\temp","\\log_");
                //Console.WriteLine("FuZhiFeature.cs:卧槽===========:" + LaTeX);
                //======================================下面这个是最一般字符的处理，不用管了，之前已经验证了========================================================
                //============================================1、需要弄一系列特征，和杨颂强依次对应比较============================================    
                List<NodeInfo> temp = exputil.GetNodeList(LaTeX, 0);
                //Console.WriteLine("草拟吗："+LaTeX);

                /*foreach (var it in temp)
                {
                    Console.WriteLine("FuZhiFeature.cs:杨颂强字符:" + it.nodeexp + "Level：" + it.level + "Flag:" + it.flag);
                }

                foreach (var itt in finalList1)
                {
                    Console.WriteLine("FuZhiFeature.cs:我的字符:" + itt.zifu + "Level：" + itt.Level + "Flag:" + itt.Flag);
                }*/


                //Console.WriteLine("需要弄一系列特征的打印结果，所以先按原始序号，因此需要按照杨颂强那个顺序依次进行比较");
                int b = 0;
                for (int a = 0; a < finalList1.Count; a++)//外层循环肯定是LaTeX表达式，因为它里面字符多，比如有一些上标^,下标_在杨颂强里面没有解析
                {
                    if (temp[b].nodeexp.Equals("(")|| temp[b].nodeexp.Equals(")") || temp[b].nodeexp.Equals("[") || temp[b].nodeexp.Equals("]"))
                    {
                        //Console.WriteLine("执行了没啊:");
                        b++;
                        a--;
                        continue;

                    }
                    else if (finalList1[a].zifu.Equals(temp[b].nodeexp))//如果LaTeX字符与杨颂强节点字符相等，把杨颂强对应特征传进我的LaTeX对应节点里面
                    {
                        finalList1[a].Level = temp[b].level;
                        finalList1[a].Flag = temp[b].flag;
                        finalList1[a].Length = finalList1.Count;
                        b++;
                        /////////////////////////////////////////////Console.WriteLine("第一个b"+b);
                    }

                    //=======================================！！！！！！！！！！！！！！！！！！！！下面这个是改上下标啊=================================================
                    else if (finalList1[a].zifu.Equals("^") || finalList1[a].zifu.Equals("_"))//如果不相等，说明肯定遇到了类似“上标”或者“下标”，到时候再添加
                    {
                        //既然遇到了“上标”或者“下标”，那就对它进行处理么
                        /////////////////////////////////Console.WriteLine("================b"+b);

                        //Console.WriteLine("原始字符："+finalList1[a].zifu);
                       // Console.WriteLine("杨颂强字符：" + temp[b].nodeexp);
                        finalList1[a].Level = temp[b-1].level;
                        finalList1[a].Flag = temp[b-1].flag;
                        finalList1[a].Length = finalList1.Count;
                        
                        //////////////////////////////////Console.WriteLine("FuZhiFeature.cs第二个：原始字符"+ finalList1[a].zifu + "\t" + "空间标志为：" + finalList1[a].Flag + "第二个：杨颂强字符" + temp[b].nodeexp + "\t" + "空间标志为：" + temp[b].flag);
                    }
                    //=======================================！！！！！！！！！！！！！！！！！下面这个是改上下标啊=================================================
                    else if (a == finalList1.Count - 1 && finalList1[a].zifu.Equals("\\negative"))
                    {
                        finalList1[a].Level = temp[b].level;
                        finalList1[a].Flag = temp[b].flag;
                        finalList1[a].Length = finalList1.Count;
                        b++;
                    }
                    else if (finalList1[a].zifu.Equals("\\negative") && finalList1[a + 1].zifu.Equals("*"))
                    {
                        finalList1[a].Level = temp[b].level;
                        finalList1[a].Flag = temp[b].flag;
                        finalList1[a].Length = finalList1.Count;
                        finalList1[a + 1].Level = temp[b].level;
                        finalList1[a + 1].Flag = temp[b].flag;
                        finalList1[a + 1].Length = finalList1.Count;
                        a++;
                        b++;
                    }
                    else if (a < finalList1.Count - 1 && finalList1[a].zifu.Equals("\\negative") && !finalList1[a + 1].zifu.Equals("*"))
                    {
                        finalList1[a].Level = temp[b].level;
                        finalList1[a].Flag = temp[b].flag;
                        finalList1[a].Length = finalList1.Count;
                        b++;
                    }
                    else if (finalList1[a].zifu.Equals("\\temp") && temp[b].nodeexp.Equals("\\log") && temp[b + 1].flag == 4)
                    {
                        //Console.WriteLine("怎么不能执行呢？");
                        finalList1[a].zifu = temp[b].nodeexp;
                        finalList1[a].Level = temp[b].level;
                        finalList1[a].Flag = temp[b].flag;
                        finalList1[a].Length = finalList1.Count;
                        b++;
                    }
                    else if (finalList1[a].zifu.Equals("\\PowerRoot") || finalList1[a].zifu.Equals("\\DuiShu"))
                    {
                        continue;
                    }
                }

                //用个栈来存放\sqrt元素，类似于左括号，我的\PowerRoot是右括号
                Stack<FinalNode1> stack2 = new Stack<FinalNode1>();
                for (int i = 0; i < finalList1.Count; i ++)
                {
                    if (finalList1[i].zifu.Equals("\\sqrt")&&finalList1[i+1].Flag == 7)//当前是根号，且和它相邻的下一个的字符flag为左上标，说明当前的这个根号是N次方根的那种
                    {
                        stack2.Push(finalList1[i]);
                    }
                    else if (finalList1[i].zifu.Equals("\\PowerRoot"))//相当于右括号,遇到右括号的话
                    {
                        FinalNode1 tem = new FinalNode1();
                        tem = stack2.Pop();//把栈里面的\lim给弹出来
                        finalList1[i].Level = tem.Level;
                        finalList1[i].Flag = tem.Flag;
                    }
                }

            }//一般字符



            return finalList1;

        }

    }
}
