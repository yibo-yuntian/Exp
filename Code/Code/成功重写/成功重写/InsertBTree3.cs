using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功插入二叉树
{
    public class InsertBTree3
    {
        //现在才是真正插入二叉树了啊，哈哈哈哈哈哈！！！
        public FinalNode1 insertBTree3(List<FinalNode1> finalList3)
        {
            
            Stack<FinalNode1> numStack = new Stack<FinalNode1>();
            Stack<FinalNode1> operStack = new Stack<FinalNode1>();
            FinalNode1 temp = new FinalNode1();
            temp.zifu = "#";
            temp.left = null;
            temp.right = null;
            operStack.Push(temp);
            for (int i = 0; i < finalList3.Count;i ++)
            {
                //Console.WriteLine("字符:"+ finalList3[i].zifu);//一般来这里注释啊
                if (isShuZi(finalList3[i].zifu) || isZiMu(finalList3[i].zifu) || isSpecialYunSuanShu(finalList3[i].zifu))
                {
                    //Console.WriteLine("又咋了:"+ finalList3[i].zifu);//一般来这里注释啊
                    FinalNode1 tempp = new FinalNode1();
                    tempp.zifu = finalList3[i].zifu;
                    tempp.Level = finalList3[i].Level;
                    tempp.Flag = finalList3[i].Flag;
                    tempp.left = null;
                    tempp.right = null;
                    numStack.Push(tempp);
                }

                //=========这是最后一个字符才考虑===============================================================================================
                //========================“这里容易出Bug”，假如上面最后一个数字压进去之后，实际上最后压进去的肯定是数字或字母=============================
                if (i == finalList3.Count-1&&!finalList3[i].zifu.Equals(")") && !finalList3[i].zifu.Equals("]") && !finalList3[i].zifu.Equals("}"))//现在都最后一个了哇，之前该循环的就循环完了吧,
                {

                    FinalNode1 top = new FinalNode1();
                    top = operStack.Peek();
                    
                    int a = 0;
                    while (!top.zifu.Equals("#"))//现在是最后一个字符，如果top不等于“#”
                    {
                        a = 0;
                        if (top.zifu.Equals("("))
                        {
                            //Console.WriteLine("最后是:" + operStack.Pop().zifu);
                            operStack.Pop();
                            a = 1;
                            if (a == 1)
                            {
                                FinalNode1 tempp3 = operStack.Pop();
                                FinalNode1 right = numStack.Pop();
                                FinalNode1 left = numStack.Pop();
                                tempp3.left = left;
                                tempp3.right = right;
                                numStack.Push(tempp3);
                                top = operStack.Peek();
                            }
                            else
                            {
                                FinalNode1 tempp3 = operStack.Pop();
                                FinalNode1 right = numStack.Pop();
                                FinalNode1 left = numStack.Pop();
                                tempp3.left = left;
                                tempp3.right = right;

                                
                                numStack.Push(tempp3);
                                top = operStack.Peek();
                            }
                        }
                        
                        else if (top.zifu.Equals("["))
                        {
                            //Console.WriteLine("最后是:" + operStack.Pop().zifu);
                            operStack.Pop();
                            a = 1;
                            if (a == 1)
                            {
                                FinalNode1 tempp3 = operStack.Pop();
                                FinalNode1 right = numStack.Pop();
                                FinalNode1 left = numStack.Pop();
                                tempp3.left = left;
                                tempp3.right = right;
                                numStack.Push(tempp3);
                                top = operStack.Peek();
                            }
                            else
                            {
                                FinalNode1 tempp3 = operStack.Pop();
                                FinalNode1 right = numStack.Pop();
                                FinalNode1 left = numStack.Pop();
                                tempp3.left = left;
                                tempp3.right = right;

                               
                                numStack.Push(tempp3);
                                top = operStack.Peek();
                            }
                        }
                        else if (top.zifu.Equals("{"))
                        {
                            //Console.WriteLine("最后是:" + operStack.Pop().zifu);
                            operStack.Pop();
                            a = 1;
                            if (a == 1)
                            {
                                FinalNode1 tempp3 = operStack.Pop();
                                FinalNode1 right = numStack.Pop();
                                FinalNode1 left = numStack.Pop();
                                tempp3.left = left;
                                tempp3.right = right;
                                numStack.Push(tempp3);
                                top = operStack.Peek();
                            }
                            else
                            {
                                FinalNode1 tempp3 = operStack.Pop();
                                FinalNode1 right = numStack.Pop();
                                FinalNode1 left = numStack.Pop();
                                tempp3.left = left;
                                tempp3.right = right;

                                
                                numStack.Push(tempp3);
                                top = operStack.Peek();
                            }
                        }
                        else
                        {
                            //Console.WriteLine("草拟吗啊啊啊啊啊啊啊啊啊啊啊啊啊:" + top.zifu);
                            FinalNode1 tempp3 = operStack.Pop();
                            FinalNode1 right = numStack.Pop();
                            FinalNode1 left = numStack.Pop();
                            tempp3.left = left;
                            tempp3.right = right;
                            numStack.Push(tempp3);
                            top = operStack.Peek();
                        }

                    }
                    return numStack.Pop();
                }

                //========这是最后一个字符才考虑============================================================================================


                if (/*isZiMu(finalList3[i].zifu)||*/isOperator(finalList3[i].zifu) || finalList3[i].zifu.Equals("(") || finalList3[i].zifu.Equals(")") || finalList3[i].zifu.Equals("{") || finalList3[i].zifu.Equals("}") || finalList3[i].zifu.Equals("[") || finalList3[i].zifu.Equals("]"))
                {
                   
                    FinalNode1 top = new FinalNode1();
                        top = operStack.Peek();

//艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹如果遇到左括号就压进去，继续下一次循环
                      if (finalList3[i].zifu.Equals("("))
                     {
                        FinalNode1 tempp1 = new FinalNode1();
                        tempp1.zifu = finalList3[i].zifu;
                        tempp1.Level = finalList3[i].Level;
                        tempp1.Flag = finalList3[i].Flag;
                        tempp1.left = null;
                        tempp1.right = null; 
                        operStack.Push(tempp1);
                        continue;
                     }
                    if (finalList3[i].zifu.Equals("["))
                    {
                        FinalNode1 tempp1 = new FinalNode1();
                        tempp1.zifu = finalList3[i].zifu;
                        tempp1.Level = finalList3[i].Level;
                        tempp1.Flag = finalList3[i].Flag;
                        tempp1.left = null;
                        tempp1.right = null;
                        operStack.Push(tempp1);
                        continue;
                    }
                    if (finalList3[i].zifu.Equals("{"))
                    {
                        FinalNode1 tempp1 = new FinalNode1();
                        tempp1.zifu = finalList3[i].zifu;
                        tempp1.Level = finalList3[i].Level;
                        tempp1.Flag = finalList3[i].Flag;
                        tempp1.left = null;
                        tempp1.right = null;
                        operStack.Push(tempp1);
                        continue;
                    }


                    //====================================================================遇到右小括号====================================================================
                    if (finalList3[i].zifu.Equals(")"))
                    {

                        //在上面右括号的基础上，如果该右括号是最后一个字符的话，说明已经到最后一个了
                        if (i == finalList3.Count - 1)//那就用一个循环，把此时两个栈里面的东西弹出来，因为是最后了，所以就开始把所有弹出来吧
                        {
                            if (finalList3[i - 2].zifu.Equals("(") && top.zifu.Equals("("))
                            {
                                operStack.Pop();//既然已经确定了，那就把这个括号弹出去不就得了吗？上面注释的那个弹出去括号明显一开始就不对，傻逼
                                //Console.WriteLine("傻逼草拟吗=============================");
                                FinalNode1 yige = numStack.Pop();
                                
                                numStack.Push(yige);
                                top = operStack.Peek();
                            }

                            top = operStack.Peek();
                            int a = 0;
                            while (!top.zifu.Equals("#"))//现在是最后一个字符，如果top不等于“#”，外层循环是要清空到底啊，所以外层循环到“#”才肯善罢甘休
                            {
                                if (top.zifu.Equals("("))//清空栈的过程中，需要判断左右括号，如果遇到左括号
                                {
                                    operStack.Pop();//把那个左括号弹出，然后加个group
                                    
                                    numStack.Push(numStack.Pop());
                                    top = operStack.Peek();
                                }
                                else//只要top不等于“(”，
                                {
                                    FinalNode1 tempp3 = operStack.Pop();
                                    FinalNode1 right = numStack.Pop();
                                    FinalNode1 left = numStack.Pop();
                                    tempp3.left = left;
                                    tempp3.right = right;
                                    numStack.Push(tempp3);
                                    top = operStack.Peek();
                                }

                            }
                            return numStack.Pop();

                        }
                        else//=====================如果不是最后一个右括号的话，当前这个是右括号，但不是最后一个括号，那就和我之前的那个思路一样，就不用管了，现在还是右括号，但不是最后一个
                        {
                            //==============================================================================有规律可循，\sqrt和\sin和\cos一系列======================================================================================================================

                            //艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹\\sqrt============================================================

                            //下面这个情况是类似“x=\\sqrt{a*b+c}”，也就是“x=(a*b+c)\sqrt”  或者  “x=\\sqrt{a+b*c}”，也就是“x=(a+b*c)\sqrt”
                            //下面这个第一次if里面的循环本来是处理“x=(a+b*c)\sqrt”，的，但是因为x=\\sqrt{a*b+c}里面的a*b可以根据上面算法化成一个元素，又回到了我下面这个算法包含的里面了
                            if (finalList3[i + 1].zifu.Equals("\\sqrt")&&i==finalList3.Count-2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sqrt";//这里的\\sqrt等价于，finalList3[i + 1].zifu，也是为了好看我才没有用“finalList3[i + 1].zifu”这个来代替的啊
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }

//艹艹艹艹艹艹艹艹艹艹艹上面那个if语句默认“根号是最后一个字符”，如果根号不是最后一个字符的话，想想咋办啊，现在还未解决啊
//下面这个是默认是\\sqrt不是最后一个字符，并且\\sqrt后面还有东西比如 x=(a+b*c)\sqrt+b
                            else if (finalList3[i + 1].zifu.Equals("\\sqrt") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sqrt";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\ln============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathrm") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathrm";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }


                            else if (finalList3[i + 1].zifu.Equals("\\mathrm") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathrm";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\mathrm============================================================

                            //==============================================================================\\ln============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\ln") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\ln";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }


                            else if (finalList3[i + 1].zifu.Equals("\\ln") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\ln";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\ln============================================================
                            //==============================================================================\\mathcal============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathcal") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathcal";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }


                            else if (finalList3[i + 1].zifu.Equals("\\mathcal") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathcal";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\mathcal============================================================
                            //==============================================================================00、\\tilde============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\tilde") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                       
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\tilde";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\tilde") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\tilde";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\\tilde============================================================
                            //==============================================================================00、\\\mathbf============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathbf") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathbf";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\mathbf") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathbf";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\\mathbf============================================================
                            //==============================================================================00、\\\mathbb============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathbb") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathbb";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\mathbb") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                   
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathbb";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\\mathbb============================================================
                            //==============================================================================00、\dot============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\dot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\dot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\dot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\dot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\dot============================================================
                            //==============================================================================00、\\lnot============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\lnot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                       
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\lnot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\lnot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\lnot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\lnot============================================================
                            //==============================================================================00、\\max============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\max") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\max";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\max") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\max";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\max============================================================
                            //==============================================================================00、\\log============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\log";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\log";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\log============================================================
                            //==============================================================================00、\\sum============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\sum") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sum";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\sum") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sum";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\sum============================================================

                            //==============================================================================00、\\lim============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\lim") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                       
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\lim";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\lim") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\lim";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\lim============================================================

                            //==============================================================================00、\\vec============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\vec") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\vec";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\vec") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\vec";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\vec============================================================
                            
                            //==============================================================================1、\bar============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\bar") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\bar";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\bar") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\bar";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================0、\bar============================================================

                            //==============================================================================1、\sin============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\sin") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sin";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\sin") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sin";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================1、\sin============================================================

                            //==============================================================================2、\\cos====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\cos") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\cos";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\cos") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\cos";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\cos====================================================================

                            //==============================================================================3、\\tan====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\tan") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\tan";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\tan") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\tan";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\tan====================================================================

                            //==============================================================================4、\\cot====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\cot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\cot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\cot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\cot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\cot====================================================================

                            //==============================================================================5、\\sec====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\sec") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sec";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\sec") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sec";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\sec====================================================================

                            //==============================================================================6、\\csc====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\csc") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\csc";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\csc") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\csc";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\csc====================================================================

                            //==============================================================================7、\\arcsin====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arcsin") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arcsin";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arcsin") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arcsin";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arcsin====================================================================

                            //==============================================================================8、\\arccos====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arccos") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arccos";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arccos") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arccos";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arccos====================================================================

                            //==============================================================================9、\\arctan====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arctan") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arctan";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arctan") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arctan";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arctan====================================================================

                            //==============================================================================10、\\arccot====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arccot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arccot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arccot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arccot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================arccot====================================================================

                            //==============================================================================11、\\arcsec====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arcsec") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arcsec";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arcsec") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arcsec";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arcsec====================================================================

                            //==============================================================================12、\\arccsc====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arccsc") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arccsc";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arccsc") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                   
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arccsc";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arccsc====================================================================

                            //==============================================================================13、\\overline====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\overline") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\overline";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\overline") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\overline";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\overline====================================================================
                            
                            //==============================================================================14、\\log====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\log";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\log";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\log====================================================================
                            //==============================================================================14、\\arg====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arg") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arg";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arg") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arg";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arg====================================================================
                            //==============================================================================15、\\hat====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\hat") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("("))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\hat";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\hat") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("("))
                                {
                                    if (top.zifu.Equals("("))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("("))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\hat";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\hat====================================================================
                            //==============================================================================有规律可循，\sqrt和\sin和\cos一系列======================================================================================================================




                            //本来下面这个就是一般形式，所以如果遇到右括号的话
                            else//本来这个就是一般形式，以后他妈“如果遇到其它特殊形式，直接添加几个if语句不就行了么”，“直接添加几行if语句不就行了么，草草草”，现在是添加group了
                            {
                                

                                //现在下面是添加group
                                if (finalList3[i - 2].zifu.Equals("(") && top.zifu.Equals("("))
                                {
                                    //Console.WriteLine("傻逼草拟吗=============================");
                                    FinalNode1 yige = numStack.Pop();
                                    
                                    numStack.Push(yige);
                                    operStack.Pop();//还是那个问题，最上面那个“傻逼傻逼”那当时不知道为啥在那有个弹出，但是让我注释了，真是傻逼
                                    top = operStack.Peek();
                                    continue;
                                }
                                     //下面一开始做的是默认一个括号里面就有一个式子比如（a+b），但是像（a+b*c）里面可以有很多，“所以应该加个循环”，上面这个是默认括号只含一个字母例如（a）
                                
                                    
                                    while (!top.zifu.Equals("("))//只要top不等于(
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                    if (top.zifu.Equals("("))
                                    {
                                        
                                        numStack.Push(numStack.Pop());
                                        top = operStack.Peek();
                                    }

                                

                            }

                        }//如果不是最后一个右括号的吧


                        if (top.zifu.Equals("("))
                        {
                            //Console.WriteLine("最后是:" + operStack.Pop().zifu);
                            operStack.Pop();
                        }
                        continue;
                    }//=遇到右小括号
                     //===================================================================1、遇到右小括号====================================================================

                    //====================================================================2、下面遇到右中括号====================================================================
                    //====================================================================遇到右中括号====================================================================
                    if (finalList3[i].zifu.Equals("]"))
                    {

                        //在上面右括号的基础上，如果该右括号是最后一个字符的话，说明已经到最后一个了
                        if (i == finalList3.Count - 1)//那就用一个循环，把此时两个栈里面的东西弹出来，因为是最后了，所以就开始把所有弹出来吧
                        {
                            if (finalList3[i - 2].zifu.Equals("[") && top.zifu.Equals("["))
                            {
                                operStack.Pop();//既然已经确定了，那就把这个括号弹出去不就得了吗？上面注释的那个弹出去括号明显一开始就不对，傻逼
                                //Console.WriteLine("傻逼草拟吗=============================");
                                FinalNode1 yige = numStack.Pop();
                                
                                numStack.Push(yige);
                                top = operStack.Peek();
                            }

                            top = operStack.Peek();
                            int a = 0;
                            while (!top.zifu.Equals("#"))//现在是最后一个字符，如果top不等于“#”，外层循环是要清空到底啊，所以外层循环到“#”才肯善罢甘休
                            {
                                if (top.zifu.Equals("["))//清空栈的过程中，需要判断左右括号，如果遇到左括号
                                {
                                    operStack.Pop();//把那个左括号弹出，然后加个group
                                    
                                    numStack.Push(numStack.Pop());
                                    top = operStack.Peek();
                                }
                                else//只要top不等于“(”，
                                {
                                    FinalNode1 tempp3 = operStack.Pop();
                                    FinalNode1 right = numStack.Pop();
                                    FinalNode1 left = numStack.Pop();
                                    tempp3.left = left;
                                    tempp3.right = right;
                                    numStack.Push(tempp3);
                                    top = operStack.Peek();
                                }

                            }
                            return numStack.Pop();

                        }
                        else//=====================如果不是最后一个右括号的话，当前这个是右括号，但不是最后一个括号，那就和我之前的那个思路一样，就不用管了，现在还是右括号，但不是最后一个
                        {
                            //==============================================================================有规律可循，\sqrt和\sin和\cos一系列======================================================================================================================

                            //艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹\\sqrt============================================================

                            //下面这个情况是类似“x=\\sqrt{a*b+c}”，也就是“x=(a*b+c)\sqrt”  或者  “x=\\sqrt{a+b*c}”，也就是“x=(a+b*c)\sqrt”
                            //下面这个第一次if里面的循环本来是处理“x=(a+b*c)\sqrt”，的，但是因为x=\\sqrt{a*b+c}里面的a*b可以根据上面算法化成一个元素，又回到了我下面这个算法包含的里面了
                            if (finalList3[i + 1].zifu.Equals("\\sqrt") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sqrt";//这里的\\sqrt等价于，finalList3[i + 1].zifu，也是为了好看我才没有用“finalList3[i + 1].zifu”这个来代替的啊
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }

                            //艹艹艹艹艹艹艹艹艹艹艹上面那个if语句默认“根号是最后一个字符”，如果根号不是最后一个字符的话，想想咋办啊，现在还未解决啊
                            //下面这个是默认是\\sqrt不是最后一个字符，并且\\sqrt后面还有东西比如 x=(a+b*c)\sqrt+b
                            else if (finalList3[i + 1].zifu.Equals("\\sqrt") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sqrt";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\ln============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathrm") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathrm";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }


                            else if (finalList3[i + 1].zifu.Equals("\\mathrm") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathrm";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\mathrm============================================================

                            //==============================================================================\\ln============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\ln") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\ln";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }


                            else if (finalList3[i + 1].zifu.Equals("\\ln") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\ln";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\ln============================================================
                            //==============================================================================\\mathcal============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathcal") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathcal";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }


                            else if (finalList3[i + 1].zifu.Equals("\\mathcal") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathcal";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\mathcal============================================================
                            //==============================================================================00、\\tilde============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\tilde") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\tilde";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\tilde") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\tilde";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\\tilde============================================================
                            //==============================================================================00、\\\mathbf============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathbf") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathbf";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\mathbf") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathbf";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\\mathbf============================================================
                            //==============================================================================00、\\\mathbb============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathbb") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathbb";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\mathbb") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathbb";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\\mathbb============================================================
                            //==============================================================================00、\dot============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\dot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\dot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\dot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\dot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\dot============================================================
                            //==============================================================================00、\\lnot============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\lnot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\lnot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\lnot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\lnot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\lnot============================================================
                            //==============================================================================00、\\max============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\max") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\max";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\max") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\max";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\max============================================================
                            //==============================================================================00、\\log============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\log";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\log";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\log============================================================
                            //==============================================================================00、\\sum============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\sum") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sum";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\sum") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sum";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\sum============================================================

                            //==============================================================================00、\\lim============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\lim") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\lim";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\lim") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\lim";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\lim============================================================

                            //==============================================================================00、\\vec============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\vec") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\vec";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\vec") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\vec";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\vec============================================================

                            //==============================================================================1、\bar============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\bar") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                       
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\bar";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\bar") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\bar";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================0、\bar============================================================

                            //==============================================================================1、\sin============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\sin") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sin";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\sin") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sin";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================1、\sin============================================================

                            //==============================================================================2、\\cos====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\cos") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\cos";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\cos") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\cos";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\cos====================================================================

                            //==============================================================================3、\\tan====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\tan") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\tan";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\tan") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\tan";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\tan====================================================================

                            //==============================================================================4、\\cot====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\cot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\cot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\cot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                   
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\cot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\cot====================================================================

                            //==============================================================================5、\\sec====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\sec") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sec";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\sec") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sec";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\sec====================================================================

                            //==============================================================================6、\\csc====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\csc") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\csc";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\csc") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\csc";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\csc====================================================================

                            //==============================================================================7、\\arcsin====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arcsin") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arcsin";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arcsin") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arcsin";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arcsin====================================================================

                            //==============================================================================8、\\arccos====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arccos") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arccos";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arccos") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arccos";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arccos====================================================================

                            //==============================================================================9、\\arctan====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arctan") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arctan";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arctan") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arctan";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arctan====================================================================

                            //==============================================================================10、\\arccot====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arccot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arccot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arccot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arccot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================arccot====================================================================

                            //==============================================================================11、\\arcsec====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arcsec") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arcsec";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arcsec") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arcsec";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arcsec====================================================================

                            //==============================================================================12、\\arccsc====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arccsc") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arccsc";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arccsc") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arccsc";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arccsc====================================================================

                            //==============================================================================13、\\overline====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\overline") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\overline";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\overline") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\overline";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\overline====================================================================

                            //==============================================================================14、\\log====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\log";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\log";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\log====================================================================
                            //==============================================================================14、\\arg====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arg") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arg";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arg") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arg";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arg====================================================================
                            //==============================================================================15、\\hat====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\hat") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("["))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\hat";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\hat") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("["))
                                {
                                    if (top.zifu.Equals("["))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("["))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\hat";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\hat====================================================================
                            //==============================================================================有规律可循，\sqrt和\sin和\cos一系列======================================================================================================================




                            //本来下面这个就是一般形式，所以如果遇到右括号的话
                            else//本来这个就是一般形式，以后他妈“如果遇到其它特殊形式，直接添加几个if语句不就行了么”，“直接添加几行if语句不就行了么，草草草”，现在是添加group了
                            {


                                //现在下面是添加group
                                if (finalList3[i - 2].zifu.Equals("[") && top.zifu.Equals("["))
                                {
                                    //Console.WriteLine("傻逼草拟吗=============================");
                                    FinalNode1 yige = numStack.Pop();
                                    
                                    numStack.Push(yige);
                                    operStack.Pop();//还是那个问题，最上面那个“傻逼傻逼”那当时不知道为啥在那有个弹出，但是让我注释了，真是傻逼
                                    top = operStack.Peek();
                                    continue;
                                }
                                //下面一开始做的是默认一个括号里面就有一个式子比如（a+b），但是像（a+b*c）里面可以有很多，“所以应该加个循环”，上面这个是默认括号只含一个字母例如（a）


                                while (!top.zifu.Equals("["))//只要top不等于(
                                {
                                    FinalNode1 tempp3 = operStack.Pop();
                                    FinalNode1 right = numStack.Pop();
                                    FinalNode1 left = numStack.Pop();
                                    tempp3.left = left;
                                    tempp3.right = right;
                                    numStack.Push(tempp3);
                                    top = operStack.Peek();
                                }
                                if (top.zifu.Equals("["))
                                {
                                    
                                    numStack.Push(numStack.Pop());
                                    top = operStack.Peek();
                                }



                            }

                        }//如果不是最后一个右括号的吧


                        if (top.zifu.Equals("["))
                        {
                            //Console.WriteLine("最后是:" + operStack.Pop().zifu);
                            operStack.Pop();
                        }
                        continue;
                    }//=遇到右中括号

                    //====================================================================2、上面遇到右中括号====================================================================



                    //===================================================================3、下面遇到右大括号====================================================================
                    //====================================================================遇到右大括号====================================================================
                    if (finalList3[i].zifu.Equals("}"))
                    {

                        //在上面右括号的基础上，如果该右括号是最后一个字符的话，说明已经到最后一个了
                        if (i == finalList3.Count - 1)//那就用一个循环，把此时两个栈里面的东西弹出来，因为是最后了，所以就开始把所有弹出来吧
                        {
                            if (finalList3[i - 2].zifu.Equals("{") && top.zifu.Equals("{"))
                            {
                                operStack.Pop();//既然已经确定了，那就把这个括号弹出去不就得了吗？上面注释的那个弹出去括号明显一开始就不对，傻逼
                                //Console.WriteLine("傻逼草拟吗=============================");
                                FinalNode1 yige = numStack.Pop();
                                
                                numStack.Push(yige);
                                top = operStack.Peek();
                            }

                            top = operStack.Peek();
                            int a = 0;
                            while (!top.zifu.Equals("#"))//现在是最后一个字符，如果top不等于“#”，外层循环是要清空到底啊，所以外层循环到“#”才肯善罢甘休
                            {
                                if (top.zifu.Equals("{"))//清空栈的过程中，需要判断左右括号，如果遇到左括号
                                {
                                    operStack.Pop();//把那个左括号弹出，然后加个group
                                    
                                    numStack.Push(numStack.Pop());
                                    top = operStack.Peek();
                                }
                                else//只要top不等于“(”，
                                {
                                    FinalNode1 tempp3 = operStack.Pop();
                                    FinalNode1 right = numStack.Pop();
                                    FinalNode1 left = numStack.Pop();
                                    tempp3.left = left;
                                    tempp3.right = right;
                                    numStack.Push(tempp3);
                                    top = operStack.Peek();
                                }

                            }
                            return numStack.Pop();

                        }
                        else//=====================如果不是最后一个右括号的话，当前这个是右括号，但不是最后一个括号，那就和我之前的那个思路一样，就不用管了，现在还是右括号，但不是最后一个
                        {
                            //==============================================================================有规律可循，\sqrt和\sin和\cos一系列======================================================================================================================

                            //艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹\\sqrt============================================================

                            //下面这个情况是类似“x=\\sqrt{a*b+c}”，也就是“x=(a*b+c)\sqrt”  或者  “x=\\sqrt{a+b*c}”，也就是“x=(a+b*c)\sqrt”
                            //下面这个第一次if里面的循环本来是处理“x=(a+b*c)\sqrt”，的，但是因为x=\\sqrt{a*b+c}里面的a*b可以根据上面算法化成一个元素，又回到了我下面这个算法包含的里面了
                            if (finalList3[i + 1].zifu.Equals("\\sqrt") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sqrt";//这里的\\sqrt等价于，finalList3[i + 1].zifu，也是为了好看我才没有用“finalList3[i + 1].zifu”这个来代替的啊
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }

                            //艹艹艹艹艹艹艹艹艹艹艹上面那个if语句默认“根号是最后一个字符”，如果根号不是最后一个字符的话，想想咋办啊，现在还未解决啊
                            //下面这个是默认是\\sqrt不是最后一个字符，并且\\sqrt后面还有东西比如 x=(a+b*c)\sqrt+b
                            else if (finalList3[i + 1].zifu.Equals("\\sqrt") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sqrt";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\ln============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathrm") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathrm";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }


                            else if (finalList3[i + 1].zifu.Equals("\\mathrm") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathrm";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\mathrm============================================================

                            //==============================================================================\\ln============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\ln") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\ln";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }


                            else if (finalList3[i + 1].zifu.Equals("\\ln") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\ln";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\ln============================================================
                            //==============================================================================\\mathcal============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathcal") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathcal";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();

                            }


                            else if (finalList3[i + 1].zifu.Equals("\\mathcal") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\sqrt，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sqrt了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();

                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathcal";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\mathcal============================================================
                            //==============================================================================00、\\tilde============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\tilde") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\tilde";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\tilde") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\tilde";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\\tilde============================================================
                            //==============================================================================00、\\\mathbf============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathbf") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathbf";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\mathbf") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathbf";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\\mathbf============================================================
                            //==============================================================================00、\\\mathbb============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\mathbb") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\mathbb";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\mathbb") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\mathbb";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\\mathbb============================================================
                            //==============================================================================00、\dot============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\dot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\dot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\dot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\dot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\dot============================================================
                            //==============================================================================00、\\lnot============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\lnot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\lnot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\lnot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\lnot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\lnot============================================================
                            //==============================================================================00、\\max============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\max") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\max";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\max") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\max";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\max============================================================
                            //==============================================================================00、\\log============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\log";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\log";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\log============================================================
                            //==============================================================================00、\\sum============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\sum") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sum";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\sum") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sum";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\sum============================================================

                            //==============================================================================00、\\lim============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\lim") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\lim";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\lim") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\lim";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\lim============================================================

                            //==============================================================================00、\\vec============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\vec") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\vec";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\vec") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\vec";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================00、\vec============================================================

                            //==============================================================================1、\bar============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\bar") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\bar";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\bar") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\bar";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================0、\bar============================================================

                            //==============================================================================1、\sin============================================================
                            else if (finalList3[i + 1].zifu.Equals("\\sin") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sin";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\sin") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sin";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================1、\sin============================================================

                            //==============================================================================2、\\cos====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\cos") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\cos";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\cos") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\cos";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\cos====================================================================

                            //==============================================================================3、\\tan====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\tan") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\tan";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\tan") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\tan";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\tan====================================================================

                            //==============================================================================4、\\cot====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\cot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\cot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\cot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\cot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\cot====================================================================

                            //==============================================================================5、\\sec====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\sec") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\sec";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\sec") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\sec";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\sec====================================================================

                            //==============================================================================6、\\csc====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\csc") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\csc";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\csc") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\csc";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\csc====================================================================

                            //==============================================================================7、\\arcsin====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arcsin") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arcsin";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arcsin") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arcsin";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arcsin====================================================================

                            //==============================================================================8、\\arccos====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arccos") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arccos";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arccos") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arccos";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arccos====================================================================

                            //==============================================================================9、\\arctan====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arctan") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arctan";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arctan") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arctan";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arctan====================================================================

                            //==============================================================================10、\\arccot====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arccot") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arccot";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arccot") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arccot";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================arccot====================================================================

                            //==============================================================================11、\\arcsec====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arcsec") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arcsec";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arcsec") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arcsec";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arcsec====================================================================

                            //==============================================================================12、\\arccsc====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arccsc") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arccsc";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arccsc") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arccsc";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arccsc====================================================================

                            //==============================================================================13、\\overline====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\overline") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\overline";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\overline") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\overline";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\overline====================================================================

                            //==============================================================================14、\\log====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\log";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\log") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\log";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\log====================================================================
                            //==============================================================================14、\\arg====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\arg") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\arg";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\arg") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\arg";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\arg====================================================================
                            //==============================================================================15、\\hat====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\hat") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\hat";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\hat") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\hat";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\hat====================================================================
                            //==============================================================================15、\\hat====================================================================
                            else if (finalList3[i + 1].zifu.Equals("\\temp") && i == finalList3.Count - 2)//当前是右括号，且最后一个是“根号”
                            {
                                while (!top.zifu.Equals("#"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {
                                        operStack.Pop();
                                        
                                        FinalNode1 genhao = new FinalNode1();
                                        genhao.zifu = "\\temp";
                                        genhao.Level = finalList3[i + 1].Level;
                                        genhao.Flag = finalList3[i + 1].Flag;
                                        genhao.left = numStack.Pop();
                                        numStack.Push(genhao);
                                        top = operStack.Peek();
                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                return numStack.Pop();
                            }
                            else if (finalList3[i + 1].zifu.Equals("\\temp") && i != finalList3.Count - 2)//如果遇到右括号且再下一个是\\sin，此时下面那个continue需要继续了啊，本来continue之后，i跑到\\sin了
                            {
                                while (!top.zifu.Equals("{"))
                                {
                                    if (top.zifu.Equals("{"))
                                    {

                                    }
                                    else
                                    {
                                        FinalNode1 tempp3 = operStack.Pop();
                                        FinalNode1 right = numStack.Pop();
                                        FinalNode1 left = numStack.Pop();
                                        tempp3.left = left;
                                        tempp3.right = right;
                                        numStack.Push(tempp3);
                                        top = operStack.Peek();
                                    }
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    operStack.Pop();
                                    
                                    FinalNode1 genhao = new FinalNode1();
                                    genhao.zifu = "\\temp";
                                    genhao.Level = finalList3[i + 1].Level;
                                    genhao.Flag = finalList3[i + 1].Flag;
                                    genhao.left = numStack.Pop();
                                    numStack.Push(genhao);
                                    i++;
                                    continue;
                                }
                            }
                            //==============================================================================\\temp====================================================================
                            //==============================================================================有规律可循，\sqrt和\sin和\cos一系列======================================================================================================================




                            //本来下面这个就是一般形式，所以如果遇到右括号的话
                            else//本来这个就是一般形式，以后他妈“如果遇到其它特殊形式，直接添加几个if语句不就行了么”，“直接添加几行if语句不就行了么，草草草”，现在是添加group了
                            {


                                //现在下面是添加group
                                if (finalList3[i - 2].zifu.Equals("{") && top.zifu.Equals("{"))
                                {
                                    //Console.WriteLine("傻逼草拟吗=============================");
                                    FinalNode1 yige = numStack.Pop();
                                    
                                    numStack.Push(yige);
                                    operStack.Pop();//还是那个问题，最上面那个“傻逼傻逼”那当时不知道为啥在那有个弹出，但是让我注释了，真是傻逼
                                    top = operStack.Peek();
                                    continue;
                                }
                                //下面一开始做的是默认一个括号里面就有一个式子比如（a+b），但是像（a+b*c）里面可以有很多，“所以应该加个循环”，上面这个是默认括号只含一个字母例如（a）


                                while (!top.zifu.Equals("{"))//只要top不等于(
                                {
                                    FinalNode1 tempp3 = operStack.Pop();
                                    FinalNode1 right = numStack.Pop();
                                    FinalNode1 left = numStack.Pop();
                                    tempp3.left = left;
                                    tempp3.right = right;
                                    numStack.Push(tempp3);
                                    top = operStack.Peek();
                                }
                                if (top.zifu.Equals("{"))
                                {
                                    
                                    numStack.Push(numStack.Pop());
                                    top = operStack.Peek();
                                }



                            }

                        }//如果不是最后一个右括号的吧


                        if (top.zifu.Equals("{"))
                        {
                            //Console.WriteLine("最后是:" + operStack.Pop().zifu);
                            operStack.Pop();
                        }
                        continue;
                    }//=遇到右大括号
                    //===================================================================3、上面遇到右大括号====================================================================




                    //艹艹艹当前运算符优先级 > 栈顶优先级艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹这个是如果当前运算符优先级大于栈顶优先级，就直接把当前运算符压进去艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹
                    if (isOperator(finalList3[i].zifu)&&/*top.zifu.Equals("#")&&*/getPriority(top.zifu, finalList3[i].zifu) <= 0)
                    {
                       //Console.WriteLine("艹艹艹艹 艹艹艹 艹艹 艹艹艹 艹艹-------------------------------------------------------------------曹尼玛"+finalList3[i].zifu);
                        FinalNode1 tempp1 = new FinalNode1();
                        tempp1.zifu = finalList3[i].zifu;
                        tempp1.Level = finalList3[i].Level;
                        tempp1.Flag = finalList3[i].Flag;
                        //Console.WriteLine("卧槽你吗啊哈哈哈哈哈哈========================================="+finalList3[i].zifu);
                        tempp1.left = null;
                        tempp1.right = null;
                        operStack.Push(tempp1);
                       // Console.WriteLine("中序遍历");
                        //middlebianli(numStack.Peek());
                        continue;
                    }



                    //Console.WriteLine("top:"+top.zifu+"\t"+"2:"+finalList3[i].zifu);

//艹艹艹艹艹艹艹艹艹艹艹下面这个事现在的这个运算符优先级小于top优先级时候，现在就需要往出来弹栈顶运算符和num栈中组成新的元素，一直遇到top优先级较小的时候，把当前元素压进去艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹
//艹艹艹艹艹艹艹艹艹艹艹终于明白了，下面这个的用处是当“当前字符优先级小于top优先级时，并且当前字符还不是最后一个字符时，
//艹艹艹艹艹艹艹艹艹艹艹下面这个是循环反复弹出元素组成新元素，一直到最后是“#”或者大于top时，
//艹艹艹艹艹艹艹艹艹艹艹也就是说先在“遇到最后一个字符前给它反复处理一下”
//艹艹艹艹艹艹艹艹艹艹艹等到遇到“最后一个字符时，上面有专门的最后一个字符的处理过程，再次循环直到结束”
//艹艹艹艹艹艹最下面这个是当遇到“top是#时，此时“当前字符还不是最后一个字符”，
//又必须压进去，“还不能弹出来”所以这里又是小于了，上面大于，下面这个是小于了”
                    //
                    while (getPriority(top.zifu, finalList3[i].zifu) > 0)
                    {
                        if (getPriority(top.zifu, finalList3[i].zifu) > 0)
                       {
//艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹这个是专门用来当top为左括号，就算当前运算符优先级小于栈顶，按理说弹出栈顶，但是因为栈顶是左括号，
//艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹所以压入，且当前刚好要压入任意一个运算符，就直接压进去
                            if (top.zifu.Equals("(") && !finalList3[i].zifu.Equals(")"))
                            {
                                FinalNode1 tempp1 = new FinalNode1();
                                tempp1.zifu = finalList3[i].zifu;
                                tempp1.Level = finalList3[i].Level;
                                tempp1.Flag = finalList3[i].Flag;
                               //Console.WriteLine("看看这里执行了吗:"+finalList3[i].zifu);
                                tempp1.left = null;
                                tempp1.right = null;
                                operStack.Push(tempp1);
                                break;
                            }

                            if (top.zifu.Equals("[") && !finalList3[i].zifu.Equals("]"))
                            {
                                FinalNode1 tempp1 = new FinalNode1();
                                tempp1.zifu = finalList3[i].zifu;
                                tempp1.Level = finalList3[i].Level;
                                tempp1.Flag = finalList3[i].Flag;
                                //Console.WriteLine("看看这里执行了吗:"+finalList3[i].zifu);
                                tempp1.left = null;
                                tempp1.right = null;
                                operStack.Push(tempp1);
                                break;
                            }

                            if (top.zifu.Equals("{") && !finalList3[i].zifu.Equals("}"))
                            {
                                FinalNode1 tempp1 = new FinalNode1();
                                tempp1.zifu = finalList3[i].zifu;
                                tempp1.Level = finalList3[i].Level;
                                tempp1.Flag = finalList3[i].Flag;
                                //Console.WriteLine("看看这里执行了吗:"+finalList3[i].zifu);
                                tempp1.left = null;
                                tempp1.right = null;
                                operStack.Push(tempp1);
                                break;
                            }

                            //如果符号栈只剩下#,说明算术表达式已经解析完了,返回数字栈中的结点
                            if (top.zifu.Equals("#"))
                            {
                                return numStack.Pop();
                            }

                            FinalNode1 tempp4 = operStack.Pop();
                            FinalNode1 right = numStack.Pop();
                            FinalNode1 left = numStack.Pop();

                            tempp4.left = left;
                            tempp4.right = right;
                            numStack.Push(tempp4);
                            //middlebianli(tempp4);
                            top = operStack.Peek();



                            if (/*top.zifu.Equals("#")&&*/isOperator(finalList3[i].zifu)&&getPriority(top.zifu, finalList3[i].zifu)<=0)
                            {
                                FinalNode1 tempp44 = new FinalNode1();
                                
                                tempp44.zifu = finalList3[i].zifu;
                                tempp44.Level = finalList3[i].Level;
                                tempp44.Flag = finalList3[i].Flag;
                                tempp44.left = null;
                                tempp44.right = null;
                                operStack.Push(tempp44);
                            }

                        }
                        else
                        {
                            //下面这个说白就是读取到的字符串运算符的优先级大于运算符栈顶部的优先级,那么跳出循环,那么把读取到的运算符放入栈里面
                            FinalNode1 tempp = new FinalNode1();
                            tempp.zifu = finalList3[i].zifu;
                            tempp.Level = finalList3[i].Level;
                            tempp.Flag = finalList3[i].Flag;
                            tempp.left = null;
                            tempp.right = null;
                            operStack.Push(tempp);
                            break ;
                        }
                    }


                }//
                //(numStack.Peek());


            }


            return null;
        }

        //判断是字母
        public Boolean isZiMu(String zifu)
        {
            int a=0;
		    if(zifu.Equals("a") || zifu.Equals("b") || zifu.Equals("c") || zifu.Equals("d") || zifu.Equals("e") || zifu.Equals("f") || zifu.Equals("g") || zifu.Equals("h") || zifu.Equals("i") || zifu.Equals("j")
                || zifu.Equals("k") || zifu.Equals("l") || zifu.Equals("m") || zifu.Equals("n") || zifu.Equals("o") || zifu.Equals("p") || zifu.Equals("q") || zifu.Equals("r") || zifu.Equals("s") || zifu.Equals("t")
                || zifu.Equals("u") || zifu.Equals("v") || zifu.Equals("w") || zifu.Equals("x") || zifu.Equals("y") || zifu.Equals("z")
                || zifu.Equals("A") || zifu.Equals("B") || zifu.Equals("C") || zifu.Equals("D") || zifu.Equals("E") || zifu.Equals("F") || zifu.Equals("G") || zifu.Equals("H") || zifu.Equals("I") || zifu.Equals("J")
                || zifu.Equals("K") || zifu.Equals("L") || zifu.Equals("M") || zifu.Equals("N") || zifu.Equals("O") || zifu.Equals("P") || zifu.Equals("Q") || zifu.Equals("R") || zifu.Equals("S") || zifu.Equals("T")
                || zifu.Equals("U") || zifu.Equals("V") || zifu.Equals("W") || zifu.Equals("X") || zifu.Equals("Y") || zifu.Equals("Z")) 
			    a =1;
		    if(a==1)
			    return true;
		    return false;	
        }



        //至于优先级以后在用的时候直接再向里面插就可以了,照猫画虎即可
        private int getPriority(String top, String charAt)
        {
            // TODO Auto-generated method stub
            //计算运算符c的栈内优先级
            //我这里定义的是数字越大,优先级越高
            int prioritytop = 0;
            int prioritycharAt = 0;
            switch (top)
            {
                case "(": prioritytop = 1000; break;
                case ")": prioritytop = 1000; break;
                case "^": prioritytop = 100; break;
                case "_": prioritytop = 100; break;
                case "+": prioritytop = 10; break;
                case "-": prioritytop = 10; break;
                case "\\pm": prioritytop = 10; break;
                case "*": prioritytop = 49; break;
                case "\\times": prioritytop = 49; break;
                case "/": prioritytop = 49; break;
                case "\\cdot": prioritytop = 10; break;
                case "\\frac": prioritytop = 50; break;
                case "=": prioritytop = 5; break;
                case "\\dashv": prioritytop = 10; break;
                case "\\cong": prioritytop = 10; break;
                case "\\colon": prioritytop = 10; break;
                case "\\cap": prioritytop = 10; break;
                case "\\cup": prioritytop = 10; break;
                case "\\in": prioritytop = 10; break;
                case "\\subset": prioritytop = 10; break;
                case "\\join": prioritytop = 10; break;
                case "\\connect": prioritytop = 10; break;
                case "\\PowerRoot": prioritytop = 10; break;
                case "\\DuiShu": prioritytop = 10; break;
                case "\\implies": prioritytop = 10; break;
                case "\\or": prioritytop = 10; break;
                case "\\mid": prioritytop = 10; break;
                case "\\quad": prioritytop = 10; break;
                case "\\qquad": prioritytop = 10; break;
                case "\\Rightarrow": prioritytop = 10; break;
                case "\\rightarrow": prioritytop = 10; break;
                case "\\to": prioritytop = 10; break;
                case ":": prioritytop = 10; break;
                case "\\equiv": prioritytop = 5; break;
                case "\\approx": prioritytop = 5; break;
                case "\\leq": prioritytop = 5; break;
                case "\\neq": prioritytop = 5; break;
                case "\\geq": prioritytop = 5; break;
                case ">": prioritytop = 5; break;
                case "<": prioritytop = 5; break;
                case "\\gg": prioritytop = 5; break;
                case "\\ll": prioritytop = 5; break;
                case "#": prioritytop = 0; break;
            }

            switch (charAt)
            {
                case "(": prioritycharAt = 1000; break;
                case ")": prioritycharAt = 1000; break;
                case "^": prioritycharAt = 100; break;
                case "_": prioritycharAt = 100; break;
                case "+": prioritycharAt = 10; break;
                case "-": prioritycharAt = 10; break;
                case "\\pm": prioritycharAt = 10; break;
                case "*": prioritycharAt = 49; break;
                case "\\times": prioritycharAt = 49; break;
                case "/": prioritycharAt = 49; break;
                case "\\cdot": prioritycharAt = 10; break;
                case "\\frac": prioritycharAt = 50; break;
                case "=": prioritycharAt = 5; break;
                case "\\dashv": prioritycharAt = 10; break;
                case "\\cong": prioritycharAt = 10; break;
                case "\\colon": prioritycharAt = 10; break;
                case "\\cap": prioritycharAt = 10; break;
                case "\\cup": prioritycharAt = 10; break;
                case "\\in": prioritycharAt = 10; break;
                case "\\subset": prioritycharAt = 10; break;
                case "\\join": prioritycharAt = 10; break;
                case "\\connect": prioritycharAt = 10; break;
                case "\\PowerRoot": prioritycharAt = 10; break;
                case "\\DuiShu": prioritycharAt = 10; break;
                case "\\implies": prioritycharAt = 10; break;
                case "\\or": prioritycharAt = 10; break;
                case "\\mid": prioritycharAt = 10; break;
                case "\\quad": prioritycharAt = 10; break;
                case "\\qquad": prioritycharAt = 10; break;
                case "\\Rightarrow": prioritycharAt = 10; break;
                case "\\rightarrow": prioritycharAt = 10; break;
                case "\\to": prioritycharAt = 10; break;
                case ":": prioritycharAt = 10; break;
                case "\\equiv": prioritycharAt = 5; break;
                case "\\approx": prioritycharAt = 5; break;
                //case "\\leq": prioritytop = 1; break;//尼玛傻逼啊，这个是典型逻辑错误啊，引以为戒，这里应该是“prioritycharAt”，而不是prioritytop
                case "\\leq": prioritycharAt = 5; break;
                case "\\neq": prioritycharAt = 5; break;
                case "\\geq": prioritycharAt = 5; break;
                case ">": prioritycharAt = 5; break;
                case "<": prioritycharAt = 5; break;
                case "\\gg": prioritycharAt = 5; break;
                case "\\ll": prioritycharAt = 5; break;
                case "#": prioritycharAt = 0; break;
                    
            }
            //Console.WriteLine("top是=:"+top+"优先级："+prioritytop+"\t"+"当前是\\leq"+charAt+ "优先级：" + prioritycharAt);
            if (prioritycharAt > prioritytop)
                return -1;
            else
                return 1;
        }

        

        //====================================================三个判断====================================================
        //判断是数字
        public Boolean isShuZi(String zifu)
        {
            int a = 0;
            if (zifu.Equals("0") || zifu.Equals("1") || zifu.Equals("2") || zifu.Equals("3") || zifu.Equals("4") || zifu.Equals("5") || zifu.Equals("6") || zifu.Equals("7") || zifu.Equals("8") || zifu.Equals("9"))
                a = 1;
            if (a == 1)
                return true;
            return false;
        }

        //判断是特殊运算数，比如\\pi，\\alpha，或者\\beta，先是一个再说，实在不行到时候再弄个类，把这些特殊字符同时放一起不就行了
        public Boolean isSpecialYunSuanShu(String zifu)
        {
            int a = 0;
            if (zifu.Equals("\\alpha") || zifu.Equals("\\Alpha") || zifu.Equals("\\beta") || zifu.Equals("\\chi") || zifu.Equals("\\delta") || zifu.Equals("\\varepsilon") || zifu.Equals("\\phi") || zifu.Equals("\\varphi") || zifu.Equals("\\gamma") || zifu.Equals("\\eta") || zifu.Equals("\\ell") || zifu.Equals("\\pi")
                || zifu.Equals("\\infty") || zifu.Equals("\\iota") || zifu.Equals("\\Iota") || zifu.Equals("\\kappa") || zifu.Equals("\\Kappa") || zifu.Equals("\\lambda") || zifu.Equals("\\mu") || zifu.Equals("\\nu") || zifu.Equals("\\varpi") || zifu.Equals("\\theta") || zifu.Equals("\\vartheta") || zifu.Equals("\\rho") || zifu.Equals("\\sigma") ||
                zifu.Equals("\\varsigma") || zifu.Equals("\\tau") || zifu.Equals("\\Tau") || zifu.Equals("\\upsilon") || zifu.Equals("\\omega") || zifu.Equals("\\omega") || zifu.Equals("\\xi") || zifu.Equals("\\psi") || zifu.Equals("\\zeta") || zifu.Equals("\\Zeta") || zifu.Equals("\\Delta") || zifu.Equals("\\Phi") ||
                zifu.Equals("\\Gamma") || zifu.Equals("\\Lambda") || zifu.Equals("\\Pi") || zifu.Equals("\\pi") || zifu.Equals("\\Theta") || zifu.Equals("\\Sigma") || zifu.Equals("\\Upsilon") || zifu.Equals("\\Omega") || zifu.Equals("\\Xi") || zifu.Equals("\\Psi") || zifu.Equals("\\varepsilon") || zifu.Equals("\\prime")
                || zifu.Equals("\\epsilon") || zifu.Equals("\\ominus") || zifu.Equals("\\circ") || zifu.Equals("\\nabla") || zifu.Equals("\\partial") || zifu.Equals("\\Pr") || zifu.Equals("\\cdots") || zifu.Equals("\\therefore") || zifu.Equals("\\bigodot") || zifu.Equals("\\star") || zifu.Equals("\\hbar") || zifu.Equals("\\negative"))
                a = 1;
            if (a == 1)
                return true;
            return false;
        }

        //判断是运算符
        private Boolean isOperator(String zifu)
        {
            Boolean a = false;
            if (zifu.Equals("+") || zifu.Equals("-") || zifu.Equals("*") || zifu.Equals("\\times") || zifu.Equals("/") || zifu.Equals("\\frac") || zifu.Equals("#") || zifu.Equals("^") || zifu.Equals("=") || zifu.Equals("\\sqrt") || zifu.Equals("_")
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
        //====================================================三个判断====================================================



    }
}
