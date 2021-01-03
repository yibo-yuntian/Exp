using ConsoleApplication7;
using MathData.DocAnalyse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功重写;

namespace 成功插入二叉树
{
    public class InsertBTree
    {

        public List<FinalNode1> insertBTree(List<FinalNode1> finalList1,String LaTeX)
        {
            
            /*Console.WriteLine("初步打印结果");
            foreach (var it in finalList1)
            {
                Console.WriteLine("字符:" + it.zifu + "原始序号:" + it.yuanshiXuHao + "排列序号:" + it.pailiexuhao);
            }*/
            FinalNode1 tempNode1 = new FinalNode1();
            for (int i = 0; i < finalList1.Count - 1; i++)
            {
                for (int j = i + 1; j < finalList1.Count; j++)
                {
                    if (finalList1[j].yuanshiXuHao < finalList1[i].yuanshiXuHao)
                    {
                        tempNode1 = finalList1[j];
                        finalList1[j] = finalList1[i];
                        finalList1[i] = tempNode1;
                    }
                }
            }

            //=====下面这个赋特征很重要啊，非常重要啊=====================下面我封装成一个函数了，按照杨颂强那个一个一个得为我的节点传入Level和Flag等特征=================================
            FuZhiFeature fu = new FuZhiFeature();
            finalList1 = fu.FuZhi(finalList1,LaTeX);
            //==========================下面我封装成一个函数了，按照杨颂强那个一个一个得为我的节点传入Level和Flag等特征=================================











            //Console.WriteLine("========================================");
            //foreach (var it in finalList1)
            //{
            //    //Console.WriteLine("字符："+it.zifu+"\t\t"+"level:"+it.Level+"\t\t"+"Flag："+it.Flag+"\t\t"+"长度:"+it.Length);
            //   // Console.WriteLine("字符：" + it.zifu + "\t\t" + "原始序号:" + it.yuanshiXuHao + "\t\t" + "排列序号：" + it.pailiexuhao);
            //    //Console.WriteLine("字符："+it.zifu+"\t\t"+"长度:" + it.Length);

            //}
            //Console.WriteLine("========================================");
            /*foreach (var it in temp)
            {
               //Console.WriteLine("字符：" + it.nodeexp +"\t"+ "level:" + it.level +"\t"+"Flag：" + it.flag);
            }*/

            //这不就对了么，哈哈，比之前什么设置biaozhi1和biaozhi2强多了，还有加个什么两个循环，什么加do while那就更扯了
            //============================================1、需要弄一系列特征，和杨颂强依次对应比较============================================

            //现在开始最终的插入二叉树前的序列了
            /*ExpUtil exputill = new ExpUtil();
            List<NodeInfo> tempp = exputil.GetNodeList(LaTeX, 0);
            int n = 0;
            for (int m = 0; m < tempp.Count; m++)//遍历杨颂强
            {
                if (finalList1[n] != null)//需要添加元素的集合元素不为空
                {
                    if (tempp[m].nodeexp.Equals(finalList1[n].zifu) && tempp[m].level == finalList1[n].Level && tempp[m].flag == finalList1[n].Flag)
                    {
                        n++;
                        continue;
                    }
                    else if (!tempp[m].nodeexp.Equals(finalList1[n].zifu) && finalList1[n].zifu.Equals("^"))
                    {
                        n++;
                        m--;
                    }
                    else if (!tempp[m].nodeexp.Equals(finalList1[n].zifu) && !finalList1[n].zifu.Equals("^"))
                    {


                    }
                }
                else//如果遇到为空的元素了，说明后面全为空了，所以把杨颂强元素全部加到
                {


                }
             
            }*/
            //现在开始最终的插入二叉树前的序列了


            return finalList1;
        }//这个方法，函数






    }
}
