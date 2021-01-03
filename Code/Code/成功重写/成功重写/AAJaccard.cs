using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class AAJaccard
    {
        //这是查询表达式的Jaccard系数集合
        public List<String> queryJaccardList(String queryLaTeX)
        {
            AABTree Btree = new AABTree();

            //查询表达式对应的二叉树
            FinalNode1 queryBtree = new FinalNode1();
            queryBtree = Btree.getBTree(queryLaTeX);

            //开始获取“根、叶路径”，试一试
            Dictionary<int, List<FinalNode1>> list = new Dictionary<int, List<FinalNode1>>();
            Queue<FinalNode1> qNode = new Queue<FinalNode1>();
            Queue<List<FinalNode1>> qStr = new Queue<List<FinalNode1>>();

            /*if (queryBtree == null)
                return list;*/
            qNode.Enqueue(queryBtree);

            FinalNode1 temp = new FinalNode1();
            temp.zifu = "#";
            List<FinalNode1> tempList = new List<FinalNode1>();
            tempList.Add(temp);
            qStr.Enqueue(tempList);

            int i = 0;
            while (qNode.Count != 0)
            {
                FinalNode1 curNode = qNode.Dequeue();
                List<FinalNode1> curStr = qStr.Dequeue();

                //如果该节点就是一个根节点并且是叶子节点的话
                if (curNode.left == null && curNode.right == null)
                {
                    i++;
                    List<FinalNode1> templist = new List<FinalNode1>();
                    for (int j = 0; j < curStr.Count; j++)
                    {
                        templist.Add(curStr[j]);
                    }
                    templist.Add(curNode);
                    list.Add(i, templist);
                }

                if (curNode.left != null)
                {
                    qNode.Enqueue(curNode.left);
                    List<FinalNode1> templist = new List<FinalNode1>();
                    for (int j = 0; j < curStr.Count; j++)
                    {
                        templist.Add(curStr[j]);
                    }
                    templist.Add(curNode);
                    qStr.Enqueue(templist);
                }

                if (curNode.right != null)
                {
                    qNode.Enqueue(curNode.right);

                    List<FinalNode1> templist = new List<FinalNode1>();
                    for (int j = 0; j < curStr.Count; j++)
                    {
                        templist.Add(curStr[j]);
                    }
                    templist.Add(curNode);
                    qStr.Enqueue(templist);
                }

            }

            //这一步可以去掉“#”号的，因为每个“#”号肯定是在首元素，所去掉每个集合的首元素就行了
            foreach (var it in list)
            {
                it.Value.RemoveAt(0);
            }

            //这一步是开始把查询表达式里面的“按照jaccd系数那样的所有节点对”放在一个集合里面
            //之前的操作是放到一个字典里面，字典里面是“FinalNode1”这种类型，
            //因为我无法用“节点”操作形成Jaccd系数节点集合，所以再把集合中节点的字符串再次读出
            List<String> finalList = new List<string>();
            //这个list是个字典，字典里面存储着每一个完整的从根到叶子节点的路径，一个一个完整路径，比如a^{2}+b^{2}
            //字典存储着+^a,+^2,+^b,+^2,
            foreach (var it in list)
            {
                //Console.WriteLine("第一个集合：");
                //foreach (var itt in it.Value)
                //{
                //    Console.WriteLine("下面的"+itt.zifu);
                //}

                for (int q = 0;q < it.Value.Count; q++)
                {
                    for (int m = q; m < it.Value.Count; m++)
                    {

                        String tempStr = "";
                        for (int n = q; n < m + 1; n++)
                        {
                            if (!isSpecialYunSuanShu(it.Value[n].zifu))
                                tempStr = tempStr + it.Value[n].zifu /*+ "\t"*/;
                        }
                        finalList.Add(tempStr);
                    }
                }
            }
            //打印一下查询表达式里面所有的“Jaccd系数的字符串”
            /*foreach (var it in finalList)
            {
                Console.WriteLine("看看所有Jaccd系数============================:" + it);
            }*/


            //我得去重啊
            List<String> NoRepeatfinalList = new List<String>();
            //遍历有重复的节点集合，放在一个无重复的集合中
            for (int j = 0; j < finalList.Count; j++)
            {
                //如果是第一个节点的话，直接加入，因为没有重复
                if (j == 0)
                {
                    NoRepeatfinalList.Add(finalList[j]);
                    continue;
                }

                //从第二个字符串开始，要进行判断是否重复，遍历新集合，注意必须得全部遍历一遍
                //所以要设置一个重复标志，biaozhi
                //因为每进来一个元素，都要判断是否有重复，所以都要重新设置一个标志
                int biaozhi = 0;//表示没有重复
                for (int k = 0; k < NoRepeatfinalList.Count; k++)
                {
                    //如果新集合中的元素和原来的元素重复了
                    if (NoRepeatfinalList[k].Equals(finalList[j]))
                    {
                        //说明有重复了，只要有重复了，那就直接break即可
                        biaozhi = 1;
                        break;
                    }
                }
                //如果有重复的话，那就下一次循环
                if (biaozhi == 1)
                {
                    continue;
                }
                else
                {
                    NoRepeatfinalList.Add(finalList[j]);
                }
            }

            //我还得把空字符串去掉
            List<String> NoRepeatfinalLists = new List<String>();

            //遍历一下无重复的，试一下，结果对了
            foreach (var it in NoRepeatfinalList)
            {
                if (it.Equals(""))
                {

                }
                else
                {
                    NoRepeatfinalLists.Add(it);
                }

                //Console.WriteLine("无重复的:" + it);
            }

            //最终版本
            //foreach (var it in NoRepeatfinalLists)
            //{
            //    Console.WriteLine("无重复的:" + it);
            //}

            return NoRepeatfinalLists;
        }

        public List<String> resultJaccardList(String resultLaTeX)
        {
            AABTree Btree = new AABTree();

            //结果表达式对应的二叉树
            FinalNode1 resultBtree = new FinalNode1();
            resultBtree = Btree.getBTree(resultLaTeX);

            //开始获取“根、叶路径”，试一试
            Dictionary<int, List<FinalNode1>> list = new Dictionary<int, List<FinalNode1>>();
            Queue<FinalNode1> qNode = new Queue<FinalNode1>();
            Queue<List<FinalNode1>> qStr = new Queue<List<FinalNode1>>();

            /*if (queryBtree == null)
                return list;*/
            qNode.Enqueue(resultBtree);

            FinalNode1 temp = new FinalNode1();
            temp.zifu = "#";
            List<FinalNode1> tempList = new List<FinalNode1>();
            tempList.Add(temp);
            qStr.Enqueue(tempList);

            int i = 0;
            while (qNode.Count != 0)
            {
                FinalNode1 curNode = qNode.Dequeue();
                List<FinalNode1> curStr = qStr.Dequeue();

                //如果该节点就是一个根节点并且是叶子节点的话
                if (curNode.left == null && curNode.right == null)
                {
                    i++;
                    List<FinalNode1> templist = new List<FinalNode1>();
                    for (int j = 0; j < curStr.Count; j++)
                    {
                        templist.Add(curStr[j]);
                    }
                    templist.Add(curNode);
                    list.Add(i, templist);
                }

                if (curNode.left != null)
                {
                    qNode.Enqueue(curNode.left);
                    List<FinalNode1> templist = new List<FinalNode1>();
                    for (int j = 0; j < curStr.Count; j++)
                    {
                        templist.Add(curStr[j]);
                    }
                    templist.Add(curNode);
                    qStr.Enqueue(templist);
                }

                if (curNode.right != null)
                {
                    qNode.Enqueue(curNode.right);

                    List<FinalNode1> templist = new List<FinalNode1>();
                    for (int j = 0; j < curStr.Count; j++)
                    {
                        templist.Add(curStr[j]);
                    }
                    templist.Add(curNode);
                    qStr.Enqueue(templist);
                }

            }

            //这一步可以去掉“#”号的，因为每个“#”号肯定是在首元素，所去掉每个集合的首元素就行了
            foreach (var it in list)
            {
                it.Value.RemoveAt(0);
            }

            //这一步是开始把查询表达式里面的“按照jaccd系数那样的所有节点对”放在一个集合里面
            //之前的操作是放到一个字典里面，字典里面是“FinalNode1”这种类型，
            //因为我无法用“节点”操作形成Jaccd系数节点集合，所以再把集合中节点的字符串再次读出
            List<String> finalList = new List<string>();
            foreach (var it in list)
            {
                for (int q = 0; q < it.Value.Count; q++)
                {
                    for (int m = q; m < it.Value.Count; m++)
                    {

                        String tempStr = "";
                        for (int n = q; n < m + 1; n++)
                        {
                            if (!isSpecialYunSuanShu(it.Value[n].zifu))
                                tempStr = tempStr + it.Value[n].zifu /*+ "\t"*/;
                        }
                        finalList.Add(tempStr);
                    }
                }
            }

            //打印一下查询表达式里面所有的“Jaccd系数的字符串”
            /*foreach (var it in finalList)
            {
                Console.WriteLine("看看所有Jaccd系数:" + it);
            }*/

            //我得去重啊
            List<String> NoRepeatfinalList = new List<String>();
            //遍历有重复的节点集合，放在一个无重复的集合中
            for (int j = 0; j < finalList.Count; j++)
            {
                //如果是第一个节点的话，直接加入，因为没有重复
                if (j == 0)
                {
                    NoRepeatfinalList.Add(finalList[j]);
                    continue;
                }

                //从第二个字符串开始，要进行判断是否重复，遍历新集合，注意必须得全部遍历一遍
                //所以要设置一个重复标志，biaozhi
                //因为每进来一个元素，都要判断是否有重复，所以都要重新设置一个标志
                int biaozhi = 0;//表示没有重复
                for (int k = 0; k < NoRepeatfinalList.Count; k++)
                {
                    //如果新集合中的元素和原来的元素重复了
                    if (NoRepeatfinalList[k].Equals(finalList[j]))
                    {
                        //说明有重复了，只要有重复了，那就直接break即可
                        biaozhi = 1;
                        break;
                    }
                }
                //如果有重复的话，那就下一次循环
                if (biaozhi == 1)
                {
                    continue;
                }
                else
                {
                    NoRepeatfinalList.Add(finalList[j]);
                }
            }

            //遍历一下无重复的，试一下，结果对了
            /*foreach (var it in NoRepeatfinalList)
            {
                Console.WriteLine("无重复的:" + it);
            }*/


            //我还得把空字符串去掉
            List<String> NoRepeatfinalLists = new List<String>();
            //遍历一下无重复的，试一下，结果对了
            foreach (var it in NoRepeatfinalList)
            {
                if (it.Equals(""))
                {

                }
                else
                {
                    NoRepeatfinalLists.Add(it);
                }

                //Console.WriteLine("无重复的:" + it);
            }

            //最终版本
            //foreach (var it in NoRepeatfinalLists)
            //{
            //    Console.WriteLine("无重复的啊啊:" + it);
            //}

            return NoRepeatfinalLists;
        }


        //判断是特殊运算数，比如\\pi，\\alpha，或者\\beta，先是一个再说，实在不行到时候再弄个类，把这些特殊字符同时放一起不就行了
        public Boolean isSpecialYunSuanShu(String zifu)
        {
            int a = 0;
            if (System.Text.RegularExpressions.Regex.IsMatch(zifu, @"^[A-Za-z0-9]+$") ||zifu.Equals("\\alpha") || zifu.Equals("\\Alpha") || zifu.Equals("\\beta") || zifu.Equals("\\chi") || zifu.Equals("\\delta") || zifu.Equals("\\varepsilon") || zifu.Equals("\\phi") || zifu.Equals("\\varphi") || zifu.Equals("\\gamma") || zifu.Equals("\\eta") || zifu.Equals("\\ell") || zifu.Equals("\\pi")
                || zifu.Equals("\\infty") || zifu.Equals("\\iota") || zifu.Equals("\\Iota") || zifu.Equals("\\kappa") || zifu.Equals("\\Kappa") || zifu.Equals("\\lambda") || zifu.Equals("\\mu") || zifu.Equals("\\nu") || zifu.Equals("\\varpi") || zifu.Equals("\\theta") || zifu.Equals("\\vartheta") || zifu.Equals("\\rho") || zifu.Equals("\\sigma") ||
                zifu.Equals("\\varsigma") || zifu.Equals("\\tau") || zifu.Equals("\\Tau") || zifu.Equals("\\upsilon") || zifu.Equals("\\omega") || zifu.Equals("\\omega") || zifu.Equals("\\xi") || zifu.Equals("\\psi") || zifu.Equals("\\zeta") || zifu.Equals("\\Zeta") || zifu.Equals("\\Delta") || zifu.Equals("\\Phi") ||
                zifu.Equals("\\Gamma") || zifu.Equals("\\Lambda") || zifu.Equals("\\Pi") || zifu.Equals("\\pi") || zifu.Equals("\\Theta") || zifu.Equals("\\Sigma") || zifu.Equals("\\Upsilon") || zifu.Equals("\\Omega") || zifu.Equals("\\Xi") || zifu.Equals("\\Psi") || zifu.Equals("\\varepsilon") || zifu.Equals("\\prime")
                || zifu.Equals("\\epsilon") || zifu.Equals("\\ominus") || zifu.Equals("\\circ") || zifu.Equals("\\nabla") || zifu.Equals("\\partial") || zifu.Equals("\\Pr") || zifu.Equals("\\cdots") || zifu.Equals("\\therefore") || zifu.Equals("\\bigodot") || zifu.Equals("\\star") || zifu.Equals("\\hbar") || zifu.Equals("\\negative"))
                a = 1;
            if (a == 1)
                return true;
            return false;
        }

    }
}
