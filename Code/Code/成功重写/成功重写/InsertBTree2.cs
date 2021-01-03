using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功插入二叉树
{
    public class InsertBTree2
    {

        public List<FinalNode1> insertBTree2(List<FinalNode1> finalList2,String LaTeX, Dictionary<int, string> latexKeyWordsDC)
        {
            Peidui peidui = new Peidui();
            //====================第一步：开始排序，插入二叉树前最后一项工作====================
            FinalNode1 temp = new FinalNode1();
            for (int i = 0; i < finalList2.Count - 1; i++)
            {
                for (int j = i + 1; j < finalList2.Count; j++)
                {
                    if (finalList2[j].pailiexuhao  < finalList2[i].pailiexuhao)
                    {
                        temp = finalList2[j];
                        finalList2[j] = finalList2[i];
                        finalList2[i] = temp;
                    }
                }
            }

            //Console.WriteLine("啥时候弄得括号啊");

            //foreach (var it in finalList2)
            //{
            //    //Console.WriteLine("字符："+it.zifu+"\t\t"+"level:"+it.Level+"\t\t"+"Flag："+it.Flag+"\t\t"+"长度:"+it.Length);
            //    //Console.WriteLine("这他妈哪个啊:" + "字符：" + it.zifu + "\t\t" + "原始序号:" + it.yuanshiXuHao + "\t\t" + "排列序号：" + it.pailiexuhao);
            //    //Console.WriteLine("这他妈哪个啊:"+"字符："+it.zifu+"\t\t"+"长度:" + it.Length);
            //}


            //====================第一步：开始排序，插入二叉树前最后一项工作====================


            //====================第二步：添加括号====================

            //现在开始遍历LaTeX字符串
            for (int j = 0; j < LaTeX.Length; j++)
            {
                if (Convert.ToString(LaTeX[j]).Equals("{"))
                {
                    //Console.WriteLine("这他妈哪个左括号啊:"+ LaTeX[j]+"排列序号:"+j);
                    FinalNode1 current = new FinalNode1();
                    current.zifu = "{";
                    current.pailiexuhao = j;
                    finalList2.Add(current);
                }
                else if (Convert.ToString(LaTeX[j]).Equals("}"))
                {
                    //Console.WriteLine("这他妈哪个右括号啊:" + LaTeX[j] + "排列序号:" + j);
                    FinalNode1 current = new FinalNode1();
                    current.zifu = "}";
                    current.pailiexuhao = j;
                    finalList2.Add(current);
                }
                else if (Convert.ToString(LaTeX[j]).Equals("("))
                {
                    //Console.WriteLine("这他妈哪个右括号啊:" + LaTeX[j] + "排列序号:" + j);
                    FinalNode1 current = new FinalNode1();
                    current.zifu = "(";
                    current.pailiexuhao = j;
                    finalList2.Add(current);
                }
                else if (Convert.ToString(LaTeX[j]).Equals(")"))
                {
                    //Console.WriteLine("这他妈哪个右括号啊:" + LaTeX[j] + "排列序号:" + j);
                    FinalNode1 current = new FinalNode1();
                    current.zifu = ")";
                    current.pailiexuhao = j;
                    finalList2.Add(current);
                }
                else if (Convert.ToString(LaTeX[j]).Equals("["))
                {
                    //Console.WriteLine("这他妈哪个右括号啊:" + LaTeX[j] + "排列序号:" + j);
                    FinalNode1 current = new FinalNode1();
                    current.zifu = "[";
                    current.pailiexuhao = j;
                    finalList2.Add(current);
                }
                else if (Convert.ToString(LaTeX[j]).Equals("]"))
                {
                    //Console.WriteLine("这他妈哪个右括号啊:" + LaTeX[j] + "排列序号:" + j);
                    FinalNode1 current = new FinalNode1();
                    current.zifu = "]";
                    current.pailiexuhao = j;
                    finalList2.Add(current);
                }
                
            }
            //====================第二步：添加括号====================

            //====================打印一下============================
            for (int i = 0; i < finalList2.Count - 1; i++)
            {
                for (int j = i + 1; j < finalList2.Count; j++)
                {
                    if (finalList2[j].pailiexuhao < finalList2[i].pailiexuhao)
                    {
                        temp = finalList2[j];
                        finalList2[j] = finalList2[i];
                        finalList2[i] = temp;
                    }
                }
            }

            //foreach (var it in finalList2)
            //{
            //    //Console.WriteLine("字符："+it.zifu+"\t\t"+"level:"+it.Level+"\t\t"+"Flag："+it.Flag+"\t\t"+"长度:"+it.Length);
            //    //Console.WriteLine("字符：" + it.zifu + "\t\t" + "原始序号:" + it.yuanshiXuHao + "\t\t" + "排列序号：" + it.pailiexuhao);
            //    //Console.WriteLine("字符："+it.zifu+"\t\t"+"长度:" + it.Length);

            //}



            //====================还得交换\frac和括号吧，再写个判断语句，这里是交换\frac，我觉得还得交换\sqrt====================
            for (int m = 0; m < finalList2.Count; m ++)
            {
                //=================================================下面是交换小括号=================================================
                if (finalList2[m].zifu.Equals("\\frac") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                }
                else if (finalList2[m].zifu.Equals("\\tfrac") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                }
                //如果当前为\sqrt且下一个是右括号“）”，并且\sqrt是倒数第二个，）是最后一个（先进行下面的判断），最后进行第三个的判断
                else if (finalList2[m].zifu.Equals("\\sqrt") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sqrt") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sin") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sin") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cos") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cos") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tan") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tan") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cot") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cot") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sec") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sec") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\csc") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\csc") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsin") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsin") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccos") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccos") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arctan") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arctan") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccot") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccot") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsec") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsec") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccsc") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccsc") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\overline") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\overline") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lim") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lim") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sum") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sum") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\log") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\log") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arg") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arg") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\bar") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\bar") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\vec") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\vec") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\hat") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\hat") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\max") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\max") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lnot") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lnot") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbb") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbb") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbf") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbf") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathcal") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathcal") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\ln") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\ln") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathrm") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathrm") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tilde") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tilde") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\dot") && finalList2[m + 1].zifu.Equals(")") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\dot") && finalList2[m + 1].zifu.Equals(")"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                ////=================================================上面是交换小括号=================================================




                //=================================================下面是交换中括号=================================================
                else if (finalList2[m].zifu.Equals("\\frac") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                }
                else if (finalList2[m].zifu.Equals("\\tfrac") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                }
                //如果当前为\sqrt且下一个是右括号“）”，并且\sqrt是倒数第二个，）是最后一个（先进行下面的判断），最后进行第三个的判断
                else if (finalList2[m].zifu.Equals("\\sqrt") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sqrt") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sin") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sin") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cos") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cos") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tan") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tan") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cot") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cot") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sec") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sec") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\csc") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\csc") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsin") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsin") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccos") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccos") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arctan") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arctan") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccot") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccot") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsec") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsec") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccsc") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccsc") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\overline") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\overline") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lim") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lim") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sum") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sum") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\log") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\log") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arg") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arg") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\bar") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\bar") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\vec") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\vec") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\hat") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\hat") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\max") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\max") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lnot") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lnot") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbb") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbb") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbf") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbf") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathcal") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathcal") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\ln") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\ln") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathrm") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathrm") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tilde") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tilde") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\dot") && finalList2[m + 1].zifu.Equals("]") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\dot") && finalList2[m + 1].zifu.Equals("]"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                ////=================================================上面是交换中括号=================================================

                //=================================================下面是交换大括号=================================================
                else if (finalList2[m].zifu.Equals("\\frac") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                }
                else if (finalList2[m].zifu.Equals("\\tfrac") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                }
                //如果当前为\sqrt且下一个是右括号“）”，并且\sqrt是倒数第二个，）是最后一个（先进行下面的判断），最后进行第三个的判断
                else if (finalList2[m].zifu.Equals("\\sqrt") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sqrt") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sin") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sin") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cos") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cos") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tan") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tan") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cot") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\cot") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sec") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sec") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\csc") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\csc") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsin") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsin") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccos") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccos") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arctan") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arctan") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccot") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccot") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsec") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arcsec") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccsc") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arccsc") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\overline") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\overline") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lim") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lim") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sum") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\sum") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\log") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\log") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arg") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\arg") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\bar") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\bar") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\vec") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\vec") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\hat") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\hat") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\max") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\max") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lnot") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\lnot") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbb") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbb") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbf") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathbf") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathcal") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathcal") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\ln") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\ln") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathrm") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\mathrm") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tilde") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\tilde") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\dot") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\dot") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\temp") && finalList2[m + 1].zifu.Equals("}") && m == finalList2.Count - 2)
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                else if (finalList2[m].zifu.Equals("\\temp") && finalList2[m + 1].zifu.Equals("}"))
                {
                    temp = finalList2[m];
                    finalList2[m] = finalList2[m + 1];
                    finalList2[m + 1] = temp;
                    m++;
                }
                ////=================================================上面是交换大括号=================================================

            }
            //====================还得交换\frac和括号吧，再写个判断语句，这里是交换\frac，我觉得还得交换\sqrt====================

            //Console.WriteLine("=========================finalList2========================");
            //foreach (var it in finalList2)
            //{
            //    //Console.WriteLine("字符："+it.zifu+"\t\t"+"level:"+it.Level+"\t\t"+"Flag："+it.Flag+"\t\t"+"长度:"+it.Length);
            //    //Console.WriteLine("字符：" + it.zifu + "\t\t" + "原始序号:" + it.yuanshiXuHao + "\t\t" + "排列序号：" + it.pailiexuhao);
            //    //Console.WriteLine("字符："+it.zifu+"\t\t"+"长度:" + it.Length);

            //}
            return finalList2;
            //====================还得交换\frac和括号吧，再写个判断语句====================

























            //====================第二步：开始插入二叉树了啊====================


            //====================第二步：开始插入二叉树了啊====================







        }


    }
}
