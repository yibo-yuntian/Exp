using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功插入二叉树
{
    public class SpecialYunSuanShu
    {
        public int specialYunSuanShu(String tempStr,int k, List<FinalNode1> finalList1, ZifuNode top)
        {

            //=======================================也有特殊运算符======================================


            

            //=======================================也有特殊运算符======================================



            //第一种是\\pi，应该把这个π以整体形式放进去
            if (Convert.ToString(tempStr[k]).Equals("\\") && Convert.ToString(tempStr[k + 1]).Equals("p") && Convert.ToString(tempStr[k + 2]).Equals("i"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\pi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
                
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\pi"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\pi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\Pi"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Pi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\Xi"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Xi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\xi"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\xi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\nu"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\nu";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\mu"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\mu";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\pm"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\pm";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\to"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\to";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\or"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\or";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\Pr"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Pr";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }

            //其实这里用哪个逆向减字最大匹配算法用一下，截取一下，然后写在if语句里面（if（截取的是\\in或者\\infity不就行了么，哈哈））
            //还有哪个default里面，因为\\in和\\infity重复了
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\in") && !tempStr.Substring(k, 4).Equals("\\inf"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\in";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 3).Equals("\\ll"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\ll";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 2;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\cap"))//============================特殊运算符==================================
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\cap";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\cup"))//============================特殊运算符==================================
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\cup";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\lor"))//============================特殊运算符==================================
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\leq";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\leq"))//============================特殊运算符==================================
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\leq";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\neq"))//============================特殊运算符==================================
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\leq";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\geq"))//============================特殊运算符==================================
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\leq";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\mid"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\mid";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\psi"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\psi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\ell"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\ell";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\Phi"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Phi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\Psi"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Psi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\eta"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\eta";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\phi"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\phi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\chi"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\chi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\rho"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\rho";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\tau"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\tau";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 4).Equals("\\Tau"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\tau";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 3;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\cong"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\cong";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\star"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\star";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\join"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\join";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\quad"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\circ";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\circ"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\circ";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\zeta"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\zeta";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\Zeta"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Zeta";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\hbar"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\hbar";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\beta"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\beta";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\iota"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\iota";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\Iota"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Iota";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\cdots"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\cdots";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 5).Equals("\\cdot"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\cdot";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 4;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\times"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\times";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\dashv"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\dashv";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\colon"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\colon";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\qquad"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\qquad";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\nabla"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\nabla";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\equiv"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\equiv";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\infty"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\infty";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\sigma"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\sigma";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\Delta"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Delta";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }

            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\Gamma"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Gamma";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\Theta"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Theta";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\Sigma"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Sigma";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\Omega"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Omega";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\alpha"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\alpha";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\Alpha"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Alpha";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\delta"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\delta";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\gamma"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\gamma";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\kappa"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\kappa";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\Kappa"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Kappa";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\varpi"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\varpi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\theta"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\theta";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\omega"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\omega";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 6).Equals("\\prime"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\prime";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 5;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 7).Equals("\\DuiShu"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\DuiShu";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 6;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 7).Equals("\\subset"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\subset";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 6;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 7).Equals("\\ominus"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\ominus";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 6;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 7).Equals("\\lambda"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\lambda";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 6;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 7).Equals("\\Lambda"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Lambda";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 6;
            }
            //第二种是fai
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k,7).Equals("\\varphi"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\varphi";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 6;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 8).Equals("\\connect"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\connect";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 7;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 8).Equals("\\bigodot"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\bigodot";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 7;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 8).Equals("\\implies"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\partial";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 7;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 8).Equals("\\partial"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\partial";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 7;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 8).Equals("\\epsilon"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\epsilon";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 7;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 8).Equals("\\upsilon"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\upsilon";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 7;
            }


            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 8).Equals("\\Upsilon"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Upsilon";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 7;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 9).Equals("\\negative"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\negative";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 8;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 9).Equals("\\vartheta"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\vartheta";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 8;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 9).Equals("\\varsigma"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\varsigma";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 8;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 10).Equals("\\PowerRoot"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\PowerRoot";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 9;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 10).Equals("\\therefore"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\therefore";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 9;
            }

            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 11).Equals("\\varepsilon"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\varepsilon";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 10;
            }
            
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 11).Equals("\\varepsilon"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\varepsilon";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 10;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 11).Equals("\\Rightarrow"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\Rightarrow";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 10;
            }
            else if (Convert.ToString(tempStr[k]).Equals("\\") && tempStr.Substring(k, 11).Equals("\\rightarrow"))
            {
                FinalNode1 no = new FinalNode1();
                no.zifu = "\\rightarrow";
                no.yuanshiXuHao = top.position + 1 + k;
                no.pailiexuhao = top.position + 1 + k;
                finalList1.Add(no);
                k = k + 10;
            }




            return k;
        }
    }
}
