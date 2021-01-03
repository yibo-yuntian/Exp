using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功重写
{
    public class FuShu
    {
        public String fuShu(String cao)
        {
            //\\negative这个负号就代表“负一”
            String final = "";
            //String cao = "a-b";

            //Console.WriteLine("卧槽："+cao);
            char[] caos = cao.ToCharArray();
            for (int i = 0; i < caos.Length; i++)
            {
                //有负号的无非是定义几个规则而已，没啥新鲜玩意，负号就是===============“\\negative”“*”“1”，其中1可以省略，那就为：“\\negative”“*”“1”“*”
                //\\times10^{-}15
                //规则1：如果负号是第一个出现的话
                if (i == 0 && Convert.ToString(caos[i]).Equals("-"))
                {
                    final = final + "\\negative" + "*";
                }
                //规则2：(1-d)=v={(1+i)}^{-1}或者\\times10^{-}10这样一般形式为：“%{-%”    为了排除这种情况：\\times10^{-}14  :   当前为负号，前一个是“{”，后一个“不是”这个的右括号“}”
                else if (i != 0 && Convert.ToString(caos[i]).Equals("-") && Convert.ToString(caos[i - 1]).Equals("{") && !Convert.ToString(caos[i + 1]).Equals("}"))
                {
                    final = final + "\\negative" + "*";
                }
                //规则3：如果是这种情况的话：\\times10^{-}14   -》    当前为负号，前一个是“{”，后一个“是”这个的右括号“}”，
                else if (i != 0 && Convert.ToString(caos[i]).Equals("-") && Convert.ToString(caos[i - 1]).Equals("{") && Convert.ToString(caos[i + 1]).Equals("}"))
                {
                    final = final + "\\negative";
                }
                //规则4：当前为负号，且它前面不能是字母，不能是数字，不能是特殊运算数，但可以是右括号“}”或者是“)”或者是“]”
                //比如   a^{2}-b^{2}=1这里的减，

                //下面以为“负号”前面这种情况直接注释不就行了，试了一个“x=-\\frac{b}{2*a}”这个还是不能注释啊！！！
                else if (i != 0 && Convert.ToString(caos[i]).Equals("-") && !isZiMu(Convert.ToString(caos[i - 1])) && !isShuZi(Convert.ToString(caos[i - 1])) && !isSpecialYunSuanShu(Convert.ToString(caos[i - 1])) && !Convert.ToString(caos[i - 1]).Equals("}") && !Convert.ToString(caos[i - 1]).Equals("]") && !Convert.ToString(caos[i - 1]).Equals(")"))
                {
                    final = final + "\\negative" + "*";
                }
                //其它的就是最一般的直接添加即可
                else
                {
                    final = final + Convert.ToString(caos[i]);
                }
            }
            return final;  
        }

        //判断是字母
        public Boolean isZiMu(String zifu)
        {
            int a = 0;
            if (zifu.Equals("a") || zifu.Equals("b") || zifu.Equals("c") || zifu.Equals("d") || zifu.Equals("e") || zifu.Equals("f") || zifu.Equals("g") || zifu.Equals("h") || zifu.Equals("i") || zifu.Equals("j")
                || zifu.Equals("k") || zifu.Equals("l") || zifu.Equals("m") || zifu.Equals("n") || zifu.Equals("o") || zifu.Equals("p") || zifu.Equals("q") || zifu.Equals("r") || zifu.Equals("s") || zifu.Equals("t")
                || zifu.Equals("u") || zifu.Equals("v") || zifu.Equals("w") || zifu.Equals("x") || zifu.Equals("y") || zifu.Equals("z")
                || zifu.Equals("A") || zifu.Equals("B") || zifu.Equals("C") || zifu.Equals("D") || zifu.Equals("E") || zifu.Equals("F") || zifu.Equals("G") || zifu.Equals("H") || zifu.Equals("I") || zifu.Equals("J")
                || zifu.Equals("K") || zifu.Equals("L") || zifu.Equals("M") || zifu.Equals("N") || zifu.Equals("O") || zifu.Equals("P") || zifu.Equals("Q") || zifu.Equals("R") || zifu.Equals("S") || zifu.Equals("T")
                || zifu.Equals("U") || zifu.Equals("V") || zifu.Equals("W") || zifu.Equals("X") || zifu.Equals("Y") || zifu.Equals("Z"))
                a = 1;
            if (a == 1)
                return true;
            return false;
        }

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

        //特殊运算数
        public Boolean isSpecialYunSuanShu(String zifu)
        {
            int a = 0;
            if (zifu.Equals("\\alpha") || zifu.Equals("\\Alpha") || zifu.Equals("\\beta") || zifu.Equals("\\chi") || zifu.Equals("\\delta") || zifu.Equals("\\varepsilon") || zifu.Equals("\\phi") || zifu.Equals("\\varphi") || zifu.Equals("\\gamma") || zifu.Equals("\\eta") || zifu.Equals("\\ell") || zifu.Equals("\\pi")
                || zifu.Equals("\\infty") || zifu.Equals("\\iota") || zifu.Equals("\\Iota") || zifu.Equals("\\kappa") || zifu.Equals("\\Kappa") || zifu.Equals("\\lambda") || zifu.Equals("\\mu") || zifu.Equals("\\nu") || zifu.Equals("\\varpi") || zifu.Equals("\\theta") || zifu.Equals("\\vartheta") || zifu.Equals("\\rho") || zifu.Equals("\\sigma") ||
                zifu.Equals("\\varsigma") || zifu.Equals("\\tau") || zifu.Equals("\\Tau") || zifu.Equals("\\upsilon") || zifu.Equals("\\omega") || zifu.Equals("\\omega") || zifu.Equals("\\xi") || zifu.Equals("\\psi") || zifu.Equals("\\zeta") || zifu.Equals("\\Zeta") || zifu.Equals("\\Delta") || zifu.Equals("\\Phi") ||
                zifu.Equals("\\Gamma") || zifu.Equals("\\Lambda") || zifu.Equals("\\Pi") || zifu.Equals("\\pi") || zifu.Equals("\\Theta") || zifu.Equals("\\Sigma") || zifu.Equals("\\Upsilon") || zifu.Equals("\\Omega") || zifu.Equals("\\Xi") || zifu.Equals("\\Psi") || zifu.Equals("\\varepsilon") || zifu.Equals("\\prime")
                || zifu.Equals("\\epsilon") || zifu.Equals("\\ominus") || zifu.Equals("\\circ") || zifu.Equals("\\nabla") || zifu.Equals("\\partial") || zifu.Equals("\\Pr") || zifu.Equals("\\cdots") || zifu.Equals("\\therefore") || zifu.Equals("\\bigodot") || zifu.Equals("\\star") || zifu.Equals("\\hbar"))
                a = 1;
            if (a == 1)
                return true;
            return false;
        }



    }
}
