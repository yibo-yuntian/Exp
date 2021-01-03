using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功插入二叉树
{
    class Default
    {
        public int defaults(Stack<ZifuNode> stack1,String LaTeX,int j, List<FinalNode1> finalList1, ZifuNode current)
        {


            //\\PowerRoot
            //下面这种是不管在不在界面内都没问题吧，之前试的这个，因为它是运算符，所以直接跳过，后续会处理
            if (Convert.ToString(LaTeX[j]).Equals("\\"))//第一次先“预”判断一下
            {
                if (LaTeX.Substring(j, 3).Equals("\\si"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\sin"))
                    {
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\co")&& !LaTeX.Substring(j, 4).Equals("\\cot"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\cos"))
                    {
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ta"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\tan"))
                    {
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\co") && LaTeX.Substring(j, 4).Equals("\\cot"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\cot"))
                    {
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\se"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\sec"))
                    {
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\cs"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\csc"))
                    {
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\lo"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\log"))
                    {
                        //Console.WriteLine("草拟吗执行了没");
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ar"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\arg"))
                    {
                        //Console.WriteLine("草拟吗执行了没");
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\li"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\lim"))
                    {
                        //Console.WriteLine("草拟吗执行了没");
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\su"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\sum"))
                    {
                        //Console.WriteLine("草拟吗执行了没");
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\do"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\dot"))
                    {
                        //Console.WriteLine("草拟吗执行了没");
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\te"))
                {
                    if (LaTeX.Substring(j, 5).Equals("\\temp"))
                    {
                        //Console.WriteLine("草拟吗执行了没");
                        j = j + 4;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ar"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\arc"))
                    {
                        if (LaTeX.Substring(j, 7).Equals("\\arcsin"))
                        {
                            j = j + 6;
                            return j;
                        }
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ar"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\arc"))
                    {
                        if (LaTeX.Substring(j, 7).Equals("\\arccos"))
                        {
                            j = j + 6;
                            return j;
                        }
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ar"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\arc"))
                    {
                        if (LaTeX.Substring(j, 7).Equals("\\arctan"))
                        {
                            j = j + 6;
                            return j;
                        }
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ar"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\arc"))
                    {
                        if (LaTeX.Substring(j, 7).Equals("\\arccot"))
                        {
                            j = j + 6;
                            return j;
                        }
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ar"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\arc"))
                    {
                        if (LaTeX.Substring(j, 7).Equals("\\arcsec"))
                        {
                            j = j + 6;
                            return j;
                        }
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ar"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\arc"))
                    {
                        if (LaTeX.Substring(j, 7).Equals("\\arccsc"))
                        {
                            j = j + 6;
                            return j;
                        }
                    }
                }
                //注意啊，有时候有公共前缀的时候，前面前缀判断完之后就不执行后面的代码了
                else if (LaTeX.Substring(j, 3).Equals("\\ma")&& LaTeX.Substring(j, 8).Equals("\\mathcal"))
                {
                        //Console.WriteLine("草拟吗了到底执行了没啊:");
                        j = j + 7;
                        return j;   
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ma")&& LaTeX.Substring(j, 7).Equals("\\mathbb"))
                {

                    //Console.WriteLine("草拟吗了到底执行了没啊:");
                    j = j + 6;
                    return j;      
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ma")&& LaTeX.Substring(j, 7).Equals("\\mathbf"))
                {
                        //Console.WriteLine("草拟吗了到底执行了没啊:");
                        j = j + 6;
                        return j;
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ma")&& LaTeX.Substring(j, 7).Equals("\\mathrm"))
                {
                    //Console.WriteLine("草拟吗了到底执行了没啊:");
                    j = j + 6;
                    return j;  
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ov"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\ove"))
                    {
                        if (LaTeX.Substring(j, 9).Equals("\\overline"))
                        {
                            j = j + 8;
                            return j;
                        }
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\fr"))
                {
                    if (LaTeX.Substring(j, 5).Equals("\\frac"))
                    {
                        //Console.WriteLine("\\frac到底在没在了啊");
                        j = j + 4;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\tf"))
                {
                    //Console.WriteLine("\\tf到底在没在了啊");
                    if (LaTeX.Substring(j, 6).Equals("\\tfrac"))
                    {
                        //Console.WriteLine("\\tfrac到底在没在了啊");
                        j = j + 5;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\sq"))
                {
                    if (LaTeX.Substring(j, 5).Equals("\\sqrt"))
                    {
                        //Console.WriteLine("草拟吗执行了没");
                        j = j + 4;
                        return j;
                    }
                }
                
                else if (LaTeX.Substring(j, 3).Equals("\\ln")&& LaTeX.Substring(j, 5).Equals("\\lnot"))
                {

                        //Console.WriteLine("草拟吗执行了没");
                        j = j + 4;
                        return j;
                    
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ln"))
                {
                    //Console.WriteLine("草拟吗执行了没");
                    j = j + 2;
                    return j;
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ba"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\bar"))
                    {
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ve"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\vec"))
                    {
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ha"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\hat"))
                    {
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\lo"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\log"))
                    {
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ma"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\max"))
                    {
                        j = j + 3;
                        return j;
                    }
                }
                else if (LaTeX.Substring(j, 3).Equals("\\ti"))
                {
                    if (LaTeX.Substring(j, 4).Equals("\\til"))
                    {
                        if (LaTeX.Substring(j, 6).Equals("\\tilde"))
                        {
                            j = j + 5;
                            return j;
                        }
                    }
                }

            }
            
            //艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹括号外艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹
            //应该先判断栈空不空，因为遇到类似\\pi的时候，有两种情况，一种是\\pi在括号外时需要添加进去，一种是在括号内时，需要跳过去
            //一、下面是括号外的一般运算数和特殊运算数
            if (stack1.Count <= 0)//这里是当不在括号内的话，也可能遇到类似\\pi的运算数的，所以还得他妈的考虑，把所有加进去
            {
                
                if ((Convert.ToString(LaTeX[j]).Equals("\\")))
                {
                    //===================================下面是特殊运算符=======================================
                    
                    //===================================上面是特殊运算符=======================================

                    //括号内：特殊运算数，找到并且压入
                    if (LaTeX.Substring(j, 3).Equals("\\pi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\pi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\Pi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Pi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }

                    else if (LaTeX.Substring(j, 3).Equals("\\Xi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Xi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\xi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\xi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\nu"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\nu";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\mu"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\mu";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\gg"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\gg";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\pm"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\pm";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\to"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\to";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\or"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\or";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\Pr"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Pr";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\in")&& !LaTeX.Substring(j, 4).Equals("\\inf"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\in";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\ll"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\ll";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\cap"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\cap";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\cup"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\cup";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\lor"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\lor";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\leq"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\leq";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\neq"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\neq";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\geq"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\geq";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    
                    else if (LaTeX.Substring(j, 4).Equals("\\mid"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\mid";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\psi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\psi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\Phi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Phi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\Psi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Psi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\ell"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\ell";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\eta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\eta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\phi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\phi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\chi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\chi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\rho"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\rho";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\tau"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\tau";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\Tau"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Tau";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\hbar"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\hbar";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\cong"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\cong";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\star"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\star";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\join"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\join";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\quad"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\quad";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\circ"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\circ";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\zeta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\zeta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\Zeta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Zeta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\beta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\beta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\iota"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\iota";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\Iota"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Iota";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\cdots"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\cdots";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\cdot"))
                    {
                        //Console.WriteLine("有草泥马的怎么了这是骂了个比的:");
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\cdot";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\times"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\times";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\dashv"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\dashv";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\colon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\colon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\qquad"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\qquad";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\nabla"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\nabla";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\equiv"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\equiv";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\infty"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\infty";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\prime"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\prime";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\sigma"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\sigma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Delta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Delta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\delta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\delta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Gamma"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Gamma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Theta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Theta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Sigma"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Sigma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\sigma"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Sigma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Omega"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Omega";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\alpha"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\alpha";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Alpha"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Alpha";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\gamma"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\gamma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\kappa"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\kappa";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Kappa"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Kappa";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\varpi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\varpi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\theta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\theta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\omega"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\omega";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\DuiShu"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\DuiShu";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\subset"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\subset";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\ominus"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\ominus";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\approx"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\approx";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\lambda"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\lambda";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\Lambda"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Lambda";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\varphi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\varphi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\connect"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\connect";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\bigodot"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\bigodot";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\implies"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\implies";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\partial"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\partial";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\epsilon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\epsilon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\upsilon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\upsilon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\Upsilon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Upsilon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 9).Equals("\\negative"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\negative";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 8;
                    }
                    else if (LaTeX.Substring(j, 9).Equals("\\vartheta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\vartheta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 8;
                    }
                    else if (LaTeX.Substring(j, 9).Equals("\\varsigma"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\varsigma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 8;
                    }
                    else if (LaTeX.Substring(j, 10).Equals("\\PowerRoot"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\PowerRoot";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 9;
                    }
                    
                    else if (LaTeX.Substring(j, 10).Equals("\\therefore"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\therefore";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 9;
                    }
                    else if (LaTeX.Substring(j, 11).Equals("\\varepsilon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\varepsilon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 10;
                    }
                    else if (LaTeX.Substring(j, 11).Equals("\\varepsilon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\varepsilon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 10;
                    }
                    else if (LaTeX.Substring(j, 11).Equals("\\Rightarrow"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Rightarrow";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 10;
                    }
                    else if (LaTeX.Substring(j, 11).Equals("\\rightarrow"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\rightarrow";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;
                        finalList1.Add(noo);
                        j = j + 10;
                    }
                }
                //括号外：一般运算数，直接压入
                else
                {
                    FinalNode1 noo = new FinalNode1();
                    noo.zifu = Convert.ToString(current.zifu);
                    noo.yuanshiXuHao = current.position;
                    noo.pailiexuhao = current.position;
                    //Console.WriteLine("看看defalut第一次出现的那个字符:"+noo.zifu);
                    finalList1.Add(noo);
                }


            }




            //艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹括号内艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹
            //下面是在“括号内”时的\\pi的运算数（之所以括号内的没有一般运算数比如a，因为括号内的都是后续会自动处理的）
            else //如果栈不空的话，说明此时在括号内，现在可以先跳过去，因为后续会处理
            {
                if ((Convert.ToString(LaTeX[j]).Equals("\\")))
                {
                    //===================================下面是特殊运算符=======================================
                    
                    //===================================上面是特殊运算符=======================================

                    if (LaTeX.Substring(j, 3).Equals("\\pi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\pi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\Pi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Pi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\Xi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Xi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\xi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\xi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\nu"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\nu";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\mu"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\mu";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\gg"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\mu";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\pm"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\pm";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\to"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\to";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\or"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\or";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\Pr"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Pr";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\in")&& !LaTeX.Substring(j, 4).Equals("\\inf"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\in";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 3).Equals("\\ll"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\ll";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 2;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\cap"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\cap";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\cup"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\cup";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\lor"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\lor";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\leq"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\leq";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\neq"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\neq";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\geq"))//============================特殊运算符==================================
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\geq";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }

                    else if (LaTeX.Substring(j, 4).Equals("\\mid"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\mid";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\psi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\psi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\Phi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Phi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\Psi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Psi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\eta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\eta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\ell"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\ell";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\phi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\phi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\chi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\chi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\rho"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\rho";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\tau"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\tau";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 4).Equals("\\Tau"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Tau";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 3;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\hbar"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\hbar";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\cong"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\cong";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\star"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\star";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\join"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\join";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\quad"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\quad";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\circ"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\circ";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\zeta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\zeta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\Zeta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Zeta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\beta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\beta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\iota"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\iota";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\Iota"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Iota";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\cdots"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\cdots";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 5).Equals("\\cdot"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\cdot";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 4;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\times"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\times";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\dashv"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\dashv";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\colon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\colon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\qquad"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\qquad";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\nabla"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\nabla";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\equiv"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\equiv";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\infty"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\infty";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\prime"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\prime";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\sigma"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\sigma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Delta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Delta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\delta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\delta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Gamma"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Gamma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Theta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Theta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Sigma"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Sigma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Omega"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Omega";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\alpha"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\alpha";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Alpha"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Alpha";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\gamma"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\gamma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\kappa"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\kappa";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\Kappa"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Kappa";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\varpi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\varpi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\theta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\theta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 6).Equals("\\omega"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\omega";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 5;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\DuiShu"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\DuiShu";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\subset"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\subset";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\ominus"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\ominus";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\approx"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\approx";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\lambda"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\lambda";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\Lambda"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Lambda";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 7).Equals("\\varphi"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\varphi";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 6;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\connect"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\connect";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\bigodot"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\bigodot";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\implies"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\implies";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\partial"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\partial";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\epsilon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\epsilon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\upsilon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\upsilon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 8).Equals("\\Upsilon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Upsilon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 7;
                    }
                    else if (LaTeX.Substring(j, 9).Equals("\\negative"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\negative";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 8;
                    }
                    else if (LaTeX.Substring(j, 9).Equals("\\vartheta"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\vartheta";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 8;
                    }
                    else if (LaTeX.Substring(j, 9).Equals("\\varsigma"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\varsigma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 8;
                    }
                    else if (LaTeX.Substring(j, 10).Equals("\\PowerRoot"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\PowerRoot";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 9;
                    }

                    else if (LaTeX.Substring(j, 10).Equals("\\therefore"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\varsigma";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 9;
                    }
                    else if (LaTeX.Substring(j, 11).Equals("\\varepsilon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\varepsilon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 10;
                    }
                    else if (LaTeX.Substring(j, 11).Equals("\\varepsilon"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\varepsilon";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 10;
                    }
                    else if (LaTeX.Substring(j, 11).Equals("\\Rightarrow"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\Rightarrow";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 10;
                    }
                    else if (LaTeX.Substring(j, 11).Equals("\\rightarrow"))
                    {
                        FinalNode1 noo = new FinalNode1();
                        noo.zifu = "\\rightarrow";
                        noo.yuanshiXuHao = current.position;
                        noo.pailiexuhao = current.position;

                        j = j + 10;
                    }
                }

                /*else//如果括号内，遇到的不是特殊字符
                {



                }*/
                /*if ((Convert.ToString(LaTeX[j]).Equals("\\") && LaTeX.Substring(j, 3).Equals("\\pi")))
                {
                    j = j + 2;
                }
                else if ((Convert.ToString(LaTeX[j]).Equals("\\") && LaTeX.Substring(j, 7).Equals("\\varphi")))
                {
                    j = j + 6;
                }*/
            }

            //Console.WriteLine("艹艹艹艹 日艹艹艹艹艹艹艹艹艹 艹艹 艹:字符"+LaTeX[j]);
            //Console.WriteLine("艹艹艹艹 日艹艹艹艹艹艹艹艹艹 艹艹 艹:位置"+j);

            return j;
        }
    }
}
