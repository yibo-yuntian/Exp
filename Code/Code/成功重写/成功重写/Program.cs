using DBhelper类封装起来;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;
using 成功重写;

namespace 成功
{
    class Program
    {
        static void Main(string[] args)
        {

            //\frac{a}{2}
            //\frac{\frac{a}{2}}{2}

            //AAWrite w = new AAWrite();
            //w.GloVe();



            //youyu.WriteTrain3();
            //youyu.WriteTest3();
            //youyu.Count3();
            //\sqrt{b^{2}-4*a*c}
            //youyu.C();
            //a+b+c=1
            //r_{a}+r_{b}+r_{c}+r=a+b+c
            //a+b=b+a


            String queryLaTeX;
            Console.WriteLine("请输入您要查询的表达式:");
            queryLaTeX = Console.ReadLine();
            AAAAAYou cao = new AAAAAYou();
            cao.Start(queryLaTeX);
            //cao.insertDataBase();

            //cao.meiyong();


            //cao.insertCao();

            //List<String> lists = new List<String>();

            //lists.Add("1");
            //lists.Add("1");

            //foreach (var it in lists)
            //{
            //    Console.WriteLine(it);
            //}



            ////===========================犹豫模糊语言术语集FDS============================





        }
    }
}
