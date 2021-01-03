using DBhelper类封装起来;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class AdjacentNode
    {
        public List<FinalNode1> AdjacentNodeList(String LaTeX)
        {
            //==============类创建对象===============
            Peidui peidui = new Peidui();
            SpecialYunSuanShu specialYunSuanShus = new SpecialYunSuanShu();
            Default defaults = new Default();
            //==============类创建对象===============


            //前期准备工作
            Dictionary<int, string> latexKeyWordsDC = new Dictionary<int, string>();//存储字典 必须进行初始化
            Dictionary<int, string> latexKeyWordTypesDC = new Dictionary<int, string>();//存储字典 必须进行初始化
            int theLength;//关键字最大长度 必须进行初始化
            //初始化字典

            string path = @"C:\\Users\\dell\\Desktop\\暑假\\实验数据\\latexSybs.txt";
            string sLine = "";
            int i = 0;
            int theMostLength = 0;
            string theStrMostLength = null;
            StreamReader latexSybsReader = new StreamReader(path);
            while (sLine != null)
            {
                i += 1;
                sLine = latexSybsReader.ReadLine();
                if (sLine == "")
                {
                    continue;
                }
                else if (sLine == null)
                {
                    break;
                }
                string[] line = sLine.Split('#');
                latexKeyWordsDC.Add(i, line[0]);
                latexKeyWordTypesDC.Add(i, line[1]);
            }
            //找到最长的符号和最长的符号对应的长度
            foreach (string value in latexKeyWordsDC.Values)
            {
                if (value.Length > theMostLength)
                {
                    theMostLength = value.Length;
                    theStrMostLength = value;
                }
            }
            //初始化长度
            theLength = theMostLength;
            //前期准备
            //Console.WriteLine("最大长度为:"+theLength);
            //找类似\frac这样的东西
            for (int posInExp = 0; posInExp < LaTeX.Length; posInExp++)
            {
                string keyWord = null;    //存储关键字
                char c = LaTeX[posInExp];
                if (c == '\\')
                {
                    if (LaTeX.Length - (posInExp + 1) < theLength)
                    {
                        keyWord = c + LaTeX.Substring(posInExp + 1, LaTeX.Length - (posInExp + 1));
                    }
                    else
                    {
                        keyWord = c + LaTeX.Substring(posInExp + 1, theLength);
                    }
                    try
                    {
                        while (!latexKeyWordsDC.ContainsValue(keyWord))//意思是假如字典里面不包含比如这个\frac，说明逆向减字没有截出来，还得再截
                        {
                            keyWord = keyWord.Substring(0, keyWord.Length - 1);//这不就开始截取了吗，哈哈哈哈哈哈哈哈！！！！！！，这是在第一次循环里面找到第一个\frac,最外层下标一步步向右推进，意思是找更多的\frac
                            if (keyWord == "")
                            {
                                //删除节点信息 出错报告
                                //deleteExpInfoAndNodeInfo(expId);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            //找类似\frac这样的东西


            //========================================================括号匹配开始========================================================

            //==========存放插入二叉树前的序列，但目前不含============
            List<FinalNode1> finalList1 = new List<FinalNode1>();
            //==========存放插入二叉树前的序列============

            String tempStr = null;
            Stack<ZifuNode> stack1 = new Stack<ZifuNode>();
            //下面我得弄一个p和q的集合，因为有可能出现好多个<p,q>这样的对,但是一开始应该先把<p=1,q=0>放入集合里面
            PQPanDuan pqPanDuan = new PQPanDuan();
            List<PQ> PQList = new List<PQ>();
            PQ pANDq = new PQ();
            pANDq.P = 1;
            pANDq.Q = 0;
            PQList.Add(pANDq);// 一开始应该先把 < p = 1,q = 0 > 放入集合里面
            //int p = 1, q = 0;
            for (int j = 0; j < LaTeX.Length; j++)
            {
                //从第一个字符开始
                ZifuNode current = new ZifuNode();
                current.zifu = LaTeX[j];
                current.position = j;

                switch (current.zifu)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack1.Push(current);
                        break;
                    case ')':
                    case ']':
                    case '}':
                        if (stack1.Count <= 0)
                        {
                            Console.WriteLine("栈为空");
                        }
                        else
                        {
                            ZifuNode top = new ZifuNode();
                            top = stack1.Peek();//先获取栈顶元素，但是还没弹出来了啊，先获取它出来比较一下，其实这里“凡是栈里面的都是左括号”

                            //Console.WriteLine("草拟吗的这里top应该为15啊:" + top.position);

                            //Console.WriteLine("左括号位置:"+top.position + "配对右括号位置:" + current.position);

                            
                            if (peidui.IsCouple(top, current))//配对成功一对，就把栈顶那个左括号弹出，既然成功了一对，那就去掉这一对吧
                            {
                                //这里是开始截取那个特殊字符，如果截取到那个特殊字符的话，就把该字符放入集合当中
                                for (int m = 0; m < top.position + 1; m++)//从0到15开始截取
                                {
                                    tempStr = LaTeX.Substring(m, top.position - m);//==============================================================下面这个bug到这里了
                                    if (latexKeyWordsDC.ContainsValue(tempStr)/*&&tempStr.Equals("\\sqrt")*/)                                    //==============
                                    {                                                                                                            //==============
                                        
                                        if (tempStr.Equals("^"))
                                        {
                                            if (stack1.Count > 0)//括号内的，就break
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                //Console.WriteLine("草拟吗到底加进去了吗艹艹艹艹 艹艹艹 艹艹艹 艹艹艹" + tempStr);
                                                FinalNode1 no = new FinalNode1();                                                                        //==============
                                                no.yuanshiXuHao = top.position - tempStr.Length;                                                         //==============
                                                no.pailiexuhao = current.position;                                                                       //==============
                                                no.zifu = tempStr;
                                                //Console.WriteLine("艹艹艹艹艹艹艹艹艹艹艹艹艹"+no.zifu);
                                                //==============
                                                finalList1.Add(no);
                                                break;
                                            }

                                        }
                                        else if (tempStr.Equals("_"))
                                        {

                                            if (stack1.Count > 0)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                FinalNode1 no = new FinalNode1();                                                                        //==============
                                                no.yuanshiXuHao = top.position - tempStr.Length;                                                         //==============
                                                no.pailiexuhao = current.position;                                                                       //==============
                                                no.zifu = tempStr;
                                                //Console.WriteLine("艹艹艹艹艹艹艹艹艹艹艹艹艹"+no.zifu);
                                                //==============
                                                finalList1.Add(no);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            //这里这不就是添加\sqrt和\frac这样的特殊的tempStr的，
                                            FinalNode1 no = new FinalNode1();                                                                        //==============
                                            no.yuanshiXuHao = top.position - tempStr.Length;                                                         //==============
                                            no.pailiexuhao = current.position;                                                                       //==============
                                            no.zifu = tempStr;
                                            //Console.WriteLine("艹艹艹艹艹艹艹艹艹艹艹艹艹"+no.zifu);
                                            //==============
                                            if (tempStr.Equals("\\cdot")||tempStr.Equals("\\quad") || tempStr.Equals("\\gg") || tempStr.Equals("\\times"))//如果类似a\\cdot{a+b}，“{”左边截取出来的是\\cdot，就不添加了，要不然就添加了两次吧，应该是
                                            {

                                            }
                                            else
                                            {
                                                finalList1.Add(no);                                                                                      //==============
                                            }                                                                                                      //Console.WriteLine("第一次截出来特殊字符了吗？:"+tempStr);                                                //==============
                                                                                                                                                     //下面加个break就对了，逻辑错误哈哈哈，如果不加break，执行到我这一行，已经截取出来，然后他妈就不停，还要到继续“下一个循环”，不断循环，不断截取，一直他妈截取完
                                            break;//如果截出来的话，那就直接break吧，不过可能有的“数学公式”截出来可能好多，需要多判断下一个字符来确定，到时候再说
                                        }
                                    }
                                }

                                //Console.WriteLine("各种草拟吗了到底草拟吗了没:"+tempStr);
                                String specialStr = tempStr;//这里specialStr就是比如\frac或者\sqrt这样的
                            //Console.WriteLine("第一次出现：" + specialStr);
                                //Console.WriteLine("草拟吗的这里top应该为15啊:" + top.position);
                                //Console.WriteLine("草拟吗什么鬼:"+LaTeX);
                                tempStr = LaTeX.Substring(top.position + 1, current.position - top.position - 1);//这里相减再减一是两个括号里面的字符的所有长度

                                for (int k = 0; k < tempStr.Length; k++)
                                {
                                    if (pqPanDuan.pqPanDuan(LaTeX, k, top,PQList))//如果在这个区间内，就不执行下列代码
                                    {
                                        //Console.WriteLine("如果在这区间，就继续循环，不执行其它");
                                        continue;
                                    }
                                    else
                                    {
                                        //有的东西是以“\”开始的，比如\pi，\sin，\times，所以添加的时候，要从这里（源头）开始添加，
                                        //要不然一个一个的从开始就把字符给拆开了，后期没法弄了，所以这里开始是以一个整体的形式开始弄的
                                        //艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹//如果遇到以“\”开始的话，但是“\”开头的有好多类型，到时候这里得一个一个添加艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹
                                        //艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹//注意啊：不能写成“tempStr[k].Equals("\\")”，因为tempStr[k]是字符char类型的，而.Equals（）方法是字符串string类型的，两个本来不能用，所以需要强制转换一下
                                        if (Convert.ToString(tempStr[k]).Equals("\\"))
                                        {
                                            k = specialYunSuanShus.specialYunSuanShu(tempStr, k, finalList1, top);
                                        }
                                        else
                                        {
                                            //Console.WriteLine("第一次:" + Convert.ToString(tempStr[k]));
                                            FinalNode1 no = new FinalNode1();
                                            no.zifu = Convert.ToString(tempStr[k]);
                                            no.yuanshiXuHao = top.position + 1 + k;
                                            no.pailiexuhao = top.position + 1 + k;
                                            finalList1.Add(no);
                                        }

                                    }
                                }
                                //Console.WriteLine("草拟吗的这里top应该为15啊:" + top.position);
                                //因为啥了，因为遇到比如左括号，左括号前面的那个是\\sqrt或者\\frac，我就把它略过了就不执行了，但是遇到上标“^”，我就不能略过啊
                                //比如^{a} 和 \\frac{a}，左括号前面是\\frac就略过，左括号前面是^就不能略过
                                //艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹这里他妈也是个bug啊，千万得注意==============================================================
                                if (Convert.ToString(LaTeX[top.position - specialStr.Length]).Equals("^") || Convert.ToString(LaTeX[top.position - specialStr.Length]).Equals("_"))
                                {
                                    /*p = top.position;
                                    q = current.position;*/
                                    PQ ppqq = new PQ();
                                    ppqq.P = top.position;
                                    ppqq.Q = current.position;
                                    PQList.Add(ppqq);

                                }
                                else//一般情况是下面
                                {
                                    /*p = top.position - specialStr.Length;
                                    q = current.position;*/
                                    PQ ppqqs = new PQ();
                                    ppqqs.P = top.position - specialStr.Length;
                                    ppqqs.Q = current.position;
                                    PQList.Add(ppqqs);
                                }


                                //Console.WriteLine("边界p为:"+p+"\t"+"边界q为:"+q);

                                stack1.Pop();
                            }//如果配对成功
                            /*else
                            {
                                Console.WriteLine("错误");
                            }*/
                        }//如果栈不空
                        break;
                    //如果遇到不是括号的话，因为之前的思想就是每次把括号里面的东西以对象形式放入，如果遇到不是括号了，就是普通字符，那就应该是也是上面那样吧，试一试看
                    //因为没有括号，所以直接就把它放入即可
                    default:
                        //艹艹艹艹艹艹艹艹艹艹艹艹艹每次上面那写草字头需要改的时候，这里也得跟着改艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹艹（明白了，因为此时遇到这个\\pi，是先跳过，后续在括号内截取会再次截取，但是如果不是括号内的呢？）
                        //Console.WriteLine("草拟吗加了没:" + j);
                        j = defaults.defaults(stack1, LaTeX, j, finalList1, current);
                        break;
                }//switch的判断这个字符
            }//遍历这个LaTeX字符串
            if (stack1.Count <= 0)
                /*Console.WriteLine("栈为空啥正确了啊")*/;

            //========================================================括号匹配开始========================================================

            //====================每次都要打印一下集合===================================================================
            List<FinalNode1> finalList2 = new List<FinalNode1>();
            List<FinalNode1> finalList3 = new List<FinalNode1>();

            //第一个“InsertBTree”
            /*foreach (var it in finalList1)
            {
                Console.WriteLine("finalList1：还得继续草泥马了啊:" + it.zifu);

            }*/
            InsertBTree insert = new InsertBTree();
            finalList2 = insert.insertBTree(finalList1, LaTeX);



            //第二个“InsertBTree2”
            /*foreach (var it in finalList2)
            {
                Console.WriteLine("finalList2：还得继续草泥马了啊:" + it.zifu+"\t"+"Level:"+it.Level+"\t"+"Flag:"+it.Flag);
            }*/
            InsertBTree2 insert2 = new InsertBTree2();
            finalList3 = insert2.insertBTree2(finalList2, LaTeX, latexKeyWordsDC);

            //第三个“InsertBTree3”
            /*foreach (var it in finalList3)
            {
                Console.WriteLine("finalList3：还得继续草泥马了啊:" + it.zifu);
            }*/

            //==================================
            List<FinalNode1> finalList4 = new List<FinalNode1>();
            for (int a = 0; a < finalList3.Count; a++)
            {
                //下面这个简直多此一举，我都不知道我为啥要去掉\\sqrt
                /*if (finalList3[a].zifu.Equals("\\sqrt"))
                {
                    continue;
                }*/
                finalList4.Add(finalList3[a]);

            }
            //==================================

            //Console.WriteLine("这他妈是哪了啊打印finalList4");
            /*foreach (var it in finalList4)
            {
                Console.WriteLine("finalList4我真草泥马:" + it.zifu+"Level："+it.Level);

            }*/





            InsertBTree3 insert3 = new InsertBTree3();
            FinalNode1 node = new FinalNode1();
            BTreeLevel createBTreeLevel = new BTreeLevel();
            //Console.WriteLine("什么鬼啊");
            node = insert3.insertBTree3(finalList4);//现在获取到那棵二叉树了啊，以节点形式
            createBTreeLevel.getBTreeLevel(node);//已经为每一个节点赋值它的层次了

            //把中序遍历好的每一个节点存入集合当中
            List<FinalNode1> nodeList = new List<FinalNode1>();
            middleBianLi zhongxu = new middleBianLi(nodeList,node);
            //zhongxu.middlebianli(node);
            //把中序遍历好的每一个节点存入集合当中

            //Console.WriteLine("原版的是的==============================================================:"+nodeList.Count);
            //Console.WriteLine("看看我猜的准不准啊艹照这么说的话第一个字符:"+nodeList[0].zifu+"第一个字符的树的层次为:"+nodeList[0].BTreeLevel+"\t"/*+"第一个字符的左边字符:"+nodeList[0].left.zifu+"树的层次为:"+ nodeList[0].left.BTreeLevel + "\t" + "第一个字符的右边字符:" + nodeList[0].right.zifu + "树的层次为:" + nodeList[0].right.BTreeLevel*/);
            //Console.WriteLine("看看我猜的准不准啊艹照这么说的话第二个字符:" + nodeList[1].zifu + "第二个字符的树的层次为:" + nodeList[1].BTreeLevel + "\t" + "第二个字符的左边字符:" + nodeList[1].left.zifu + "树的层次为:" + nodeList[1].left.BTreeLevel + "\t" + "第二个字符的右边字符:" + nodeList[1].right.zifu + "树的层次为:" + nodeList[1].right.BTreeLevel);
            //Console.WriteLine("看看我猜的准不准啊艹照这么说的话第三个字符:" + nodeList[2].zifu + "第三个字符的树的层次为:" + nodeList[2].BTreeLevel + "\t" + "第三个字符的左边字符:" + nodeList[2].left.zifu + "树的层次为:" + nodeList[2].left.BTreeLevel + "\t" + "第三个字符的右边字符:" + nodeList[2].right.zifu + "树的层次为:" + nodeList[2].right.BTreeLevel);





            return nodeList;

        }

    }
}
