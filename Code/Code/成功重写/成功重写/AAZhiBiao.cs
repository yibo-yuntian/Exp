using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;
using 成功重写;

namespace 成功重写
{
    //
    public class AAZhiBiao {

        //也就是说我这个可以使包含匹配也可以是模糊匹配或者结构匹配，当没有包含匹配的时候
        //就是结构匹配，所以提高了之前所存在的局限性，也就是说，如果没有包含那就打分为0，么
        //到底怎么分类
        //一、树的高度属性

        //二、树型 匹配的子树和相似结点数量属性，两棵树匹配相同部分的属性

        //三、树型结构属性（结构匹配）
        //四、这也算结构属性吧，运算符相似的个数再弄个运算符类型，

        //我突然明白了，就是判断两个表达式，比如查询表达式，要找到和查询表达式相似的表达式，
        //首先是包含的话是，是最匹配的，并且树的层次越接近根的话，以最接近根的那个为标准，就越相似，这是第一点
        public double BTLevelScore(String queryLaTeX, String resultLaTeX)
        {
            AABTreeStructure acquireBtreeStructure = new AABTreeStructure();//调用这个类，获取树结构的类
            List<FinalNode1> queryLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“查询表达式”邻接节点有序对的集合
            List<FinalNode1> resultLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“结果表达式”邻接节点有序对的集合
            queryLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(queryLaTeX);//已经存放“查询表达式”邻接节点有序对的集合
            resultLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(resultLaTeX);//已经存放“结果表达式”邻接节点有序对的集合

            //=====这个方法一开始只是默认查询表达式是结果表达式的子式，但是如果查询表达式不是结果表达式的子式，那就不能用这个指标了=======================

            //如果查询表达式的长度“大于”结果表达式的长度，那说明一定没有包含，所以此时该指标得分为0
            if (queryLaTeXAdjacentNodeList.Count > resultLaTeXAdjacentNodeList.Count)
                return 0;

            //=====这个方法一开始只是默认查询表达式是结果表达式的子式，但是如果查询表达式不是结果表达式的子式，那就不能用这个指标了=======================


            //我先算一下查询表达式的树在结果表达式的树中的高度
            List<FinalNode1> tempList = new List<FinalNode1>();
            int panduan1 = queryLaTeXAdjacentNodeList.Count;//这个是查询表达式的节点的个数
            int panduan2 = 0;
            int i = 0;
            int p = 0;
            for (int j = 0; j < resultLaTeXAdjacentNodeList.Count; j ++)
            {     
                p = j;
                while (i != queryLaTeXAdjacentNodeList.Count)
                {
                    //Console.WriteLine("查询表达式集合：" + i);
                    //Console.WriteLine("查询表达式总共个数：" + queryLaTeXAdjacentNodeList.Count);
                    //Console.WriteLine("结果表达式集合：" + p);
                    //Console.WriteLine("结果表达式总共个数：" + resultLaTeXAdjacentNodeList.Count);
                    //Console.WriteLine("==============================");
                    if (queryLaTeXAdjacentNodeList[i].zifu.Equals(resultLaTeXAdjacentNodeList[p].zifu))
                    {
                        i++;
                        p++;
                        panduan2++;
                    }
                    else//一旦有不相等的，说明肯定不相等，那就直接终止循环
                    {
                        //这里得添加一个标志吧，直接结束
                        panduan2 = 0;
                        break;
                    }

                    if (p == resultLaTeXAdjacentNodeList.Count)
                        break;

                }//这个是循环比较完每一个查询表达式与结果表达式的j从0开始

                if (panduan2 == panduan1)//说明结果表达式里面至少有一个查询表达式，既然有的话，那就添加一下不就行了
                {
                    //Console.WriteLine("panduan2:"+panduan2+"panduan1:"+panduan1);
                    //Console.WriteLine("第一次出现的j是多少:"+j);
                    for (int k = j; k < j + queryLaTeXAdjacentNodeList.Count; k++)
                    {
                        //Console.WriteLine("哪里超界限了："+k);
                        tempList.Add(resultLaTeXAdjacentNodeList[k]);
                    }
                    i = 0;
                    panduan2 = 0;
                }
                else//如果不相等的话，说明目前没找到
                {
                    i = 0;
                    panduan2 = 0;
                    continue;
                }

                //也就是说“p”是从结果表达式一个一个字符开始，
                //开始找和查询表达式具有相同首字符的时候，所以有的是从结果表达式快最后的时候
                //才可能找到查询表达式的开始
                if (p == resultLaTeXAdjacentNodeList.Count)
                    break;
            }
            int BTreeLevel = 0;//这个是查询表达式在结果表达式中的最大高度,不对，应该找最小高度才行
            for (int m = 0; m < tempList.Count; m ++)
            {
                if (m == 0)
                {
                    BTreeLevel = tempList[m].BTreeLevel;
                    continue;
                }
                else
                {
                    if (tempList[m].BTreeLevel < BTreeLevel)
                    {
                        BTreeLevel = tempList[m].BTreeLevel;
                    }
                }
            }
            //现在求一下结果表达式的全部高度
            int ALLBTreeLevel = 0;//这个是结果表达式的全部高度
            for (int n = 0; n < resultLaTeXAdjacentNodeList.Count; n ++)
            {
                if (resultLaTeXAdjacentNodeList[n].BTreeLevel > ALLBTreeLevel)
                {
                    ALLBTreeLevel = resultLaTeXAdjacentNodeList[n].BTreeLevel;
                }
            }
            double finalBTLevelScore = 0;
            //Console.WriteLine("查询表达式在树中的高度："+BTreeLevel+"结果表达式高度:"+ALLBTreeLevel);

            //如果“查询表达式”在“结果表达式”里面的树的高度为0，说明“查询表达式”根本就没有在“结果表达式里面”，所以返回为“0”
            if ((Convert.ToDouble(BTreeLevel) / Convert.ToDouble(ALLBTreeLevel)) == 0)
            {
                finalBTLevelScore = 0;
            }
            else
            {
                finalBTLevelScore = Convert.ToDouble((1 - Convert.ToDouble(BTreeLevel) / Convert.ToDouble(ALLBTreeLevel)).ToString("0.00"));
            }
            return finalBTLevelScore;

        }//第一个指标：树的层次（高度）这个指标
        //其次是，所包含查询表达式的个数越多越相似
        public double childrenCountScore(String queryLaTeX, String resultLaTeX)
        {
            AABTreeStructure acquireBtreeStructure = new AABTreeStructure();//调用这个类，获取树结构的类
            List<FinalNode1> queryLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“查询表达式”邻接节点有序对的集合
            List<FinalNode1> resultLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“结果表达式”邻接节点有序对的集合
            queryLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(queryLaTeX);//已经存放“查询表达式”邻接节点有序对的集合
            resultLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(resultLaTeX);//已经存放“结果表达式”邻接节点有序对的集合

            //=====这个方法一开始只是默认查询表达式是结果表达式的子式，但是如果查询表达式不是结果表达式的子式，那就不能用这个指标了=======================
            //艹艹艹艹艹艹艹艹艹我一开始没想那么多，“默认查询表达式比结果表达式长度小，但是实际上不是这样的”都是从简单入手，然后慢慢用其它例子来测试，然后调BUG，不过一开始确实难受
            //如果查询表达式的长度“大于”结果表达式的长度，那说明一定没有包含，那就更别说是查询表达式在结果表达式中的个数了，所以此时该指标得分为0
            if (queryLaTeXAdjacentNodeList.Count > resultLaTeXAdjacentNodeList.Count)
                return 0;

            //=====这个方法一开始只是默认查询表达式是结果表达式的子式，但是如果查询表达式不是结果表达式的子式，那就不能用这个指标了=======================


            //我先算一下查询表达式的树在结果表达式的树中的高度
            List<FinalNode1> tempList = new List<FinalNode1>();
            int panduan1 = queryLaTeXAdjacentNodeList.Count;//这个是查询表达式的节点的个数
            int panduan2 = 0;
            int i = 0;
            int p = 0;

            int count1 = 0;//我想的是既然是包含匹配，查询表达式的个数，以及下面这个，这个占0.8，不一定非得仅仅包含比如a+b，有很多虽然包含a+b，但是其它部分可能就杂乱无章了，这就没考虑到
            int count2 = 0;//以及其它与查询表达式具有相同节点的个数，分成两个比重，这个占0.2，可以“起到扩充的效果”，或者更能接近用户想要的，去除一些无关的节点，比如虽然包含a+b，但是后面跟了一连串的没用的什么欧拉公式，这就不好了，可以起到更加接近用户需求
            //第一、下面这个是求查询表达式在结果表达式中的个数
            for (int j = 0; j < resultLaTeXAdjacentNodeList.Count; j++)
            {
                p = j;
                while (i != queryLaTeXAdjacentNodeList.Count)
                {
                    //Console.WriteLine("查询表达式集合：" + i);
                    //Console.WriteLine("查询表达式总共个数：" + queryLaTeXAdjacentNodeList.Count);
                    //Console.WriteLine("结果表达式集合：" + p);
                    //Console.WriteLine("结果表达式总共个数：" + resultLaTeXAdjacentNodeList.Count);
                    //Console.WriteLine("==============================");
                    if (queryLaTeXAdjacentNodeList[i].zifu.Equals(resultLaTeXAdjacentNodeList[p].zifu))
                    {
                        i++;
                        p++;
                        panduan2++;
                    }
                    else//一旦有不相等的，说明肯定不相等，那就直接终止循环
                    {
                        //这里得添加一个标志吧，直接结束
                        panduan2 = 0;
                        break;
                    }
                    //这里P的结果表达式可能会超界，因为我已开始定义的是“i”,一开始我的界限是i不超出就行了，还得考虑p不超出
                    //这里p标记的是在结果表达式里面，与查询表达式第一个字母相同的字母的位置，
                    //从结果表达式里面该位置开始找与查询表达式对应字母相同的，
                    //就是向后过滤，扫描一个一个去比较，我都不知道怎么就想到了，但是放在现在我不一定能想到2020-1-30-20点59分
                    if (p == resultLaTeXAdjacentNodeList.Count)
                        break;
                }//这个是循环比较完每一个查询表达式与结果表达式的j从0开始

                if (panduan2 == panduan1)//说明结果表达式里面至少有一个查询表达式，既然有的话，那就添加一下不就行了
                {
                    count1++;
                    i = 0;
                    panduan2 = 0;
                }
                else//如果不相等的话，说明目前没找到
                {
                    i = 0;
                    panduan2 = 0;
                    //continue;//这里其实没必要放个continue继续吧，这都到最后了
                }
                //这个和上面那个差不多吧
                //也就是说“p”是从结果表达式一个一个字符开始，
                //开始找和查询表达式具有相同首字符的时候，所以有的是从结果表达式快最后的时候
                //才可能找到查询表达式的开始
                if (p == resultLaTeXAdjacentNodeList.Count)
                    break;
            }
            //第二、找一下与查询表达式含有相同节点，但是又不属于包含的
            for (int j = 0; j < resultLaTeXAdjacentNodeList.Count; j++)//遍历最外层，也就是结果表达式的节点，对于每一个节点
            {
                for (int k = 0; k < queryLaTeXAdjacentNodeList.Count; k ++)//查询表达式
                {
                    if (resultLaTeXAdjacentNodeList[j].zifu.Equals(queryLaTeXAdjacentNodeList[k].zifu))
                    {
                        count2++;
                    }
                }
            }

            double finalChildrenCountScore = 0;

            //查询表达式的节点个数
            double queryCount = Convert.ToDouble((count1 * queryLaTeXAdjacentNodeList.Count));

            //与查询表达式具有相同节点但是不包含查询表达式的个数
            double temp = Convert.ToDouble(count2 - queryCount);

            //剩下的和查询表达式节点不相关的，也就是噪声节点
            double other = Convert.ToDouble((resultLaTeXAdjacentNodeList.Count - count2));

            finalChildrenCountScore =  queryCount / resultLaTeXAdjacentNodeList.Count * 0.7 + Convert.ToDouble(temp) / resultLaTeXAdjacentNodeList.Count * 0.2 + other / resultLaTeXAdjacentNodeList.Count * 0.1;
            /*Console.WriteLine("查询表达式节点个数:"+queryCount);
            Console.WriteLine("与查询表达式具有相同节点但是不包含查询表达式的个数:" + temp);
            Console.WriteLine("剩下的无关噪声节点个数:" + other);
            Console.WriteLine("结果表达式节点个数:" + resultLaTeXAdjacentNodeList.Count);
            Console.WriteLine("分数:"+ queryCount / resultLaTeXAdjacentNodeList.Count * 0.7);
            Console.WriteLine("分数:" + Convert.ToDouble(temp) / resultLaTeXAdjacentNodeList.Count * 0.2);
            Console.WriteLine("分数:" + other / resultLaTeXAdjacentNodeList.Count * 0.1);*/
            return finalChildrenCountScore;

        }//第二个指标：查询表达式在结果表达式中的个数*0.8  + 与查询表达式节点相同的个数*0.2 这个指标


        /*
         * 因为可能遇到查询表达式的长度比结果表达式的长度长，
         * 所以上面那两个指标得分为0，但是也不一定，比如你要搜索a+b+c，也可能有a+b出现
         * 所以我就突然想到这个指标，再添加一个，
         */
        public double similarChildrenCount(String queryLaTeX, String resultLaTeX)
        {
            Dictionary<int, List<FinalNode1>> queryLaTeXchildren = new Dictionary<int, List<FinalNode1>>();
            Dictionary<int, List<FinalNode1>> resultLaTeXchildren = new Dictionary<int, List<FinalNode1>>();

            ChildrenBTree childrenBTree = new ChildrenBTree();

            //字典类型,集合里面存的是每一个子式FinalNode节点类型的，中序遍历后的，比如
            //比如a+b+c,存的是a,+,b,这是一个个FinalNode节点类型的字符，所以我得把里面的字符提出来放在一个新集合中，才能好比较
            queryLaTeXchildren = childrenBTree.childrenBTree(queryLaTeX);
            resultLaTeXchildren = childrenBTree.childrenBTree(resultLaTeX);//字典类型

            List<String> queryChildren = new List<String>();//定义专门存放查询表达式的子式集合，因为这样好求相似个数
            List<String> resultChildren = new List<String>();//定义专门存放结果表达式的子式集合，因为这样好求相似个数

            //先把查询表达式字典里面的一个个节点的字符“串”成一个字符串
            foreach (var it in queryLaTeXchildren)
            {
                String temp = "";//对于每一个子式，都需要一个字符串来“串或者加起来”
                if (it.Value.Count > 1)
                {
                    foreach (var itt in it.Value)
                    {
                        temp = temp + itt.zifu;//加起来之后就是一个“子式”字符串
                    }
                }
                //Console.WriteLine("妈的："+temp);
                queryChildren.Add(temp);
            }

            //===================这个是不包含全部的数学表达式=================
            //int mostLength = queryChildren[0].Length;
            //int mostLengthNum = 0;
            //for (int i = 1; i < queryChildren.Count; i ++)
            //{
            //    if (queryChildren[i].Length > mostLength)
            //    {
            //        mostLength = queryChildren[i].Length;
            //        mostLengthNum = i;
            //    }
            //}
            //queryChildren.RemoveAt(mostLengthNum);
            
            //===================这个是不包含全部的数学表达式=================

            //然后把结果表达式字典里面的一个个节点的字符“串”成一个字符串
            foreach (var it in resultLaTeXchildren)
            {
                String temp = "";//对于每一个子式，都需要一个字符串来“串或者加起来”
                if (it.Value.Count > 1)
                {
                    foreach (var itt in it.Value)
                    {
                        temp = temp + itt.zifu;//加起来之后就是一个“子式”字符串
                    }
                }
                resultChildren.Add(temp);
            }

            //=========================这个是不包含全部的===============
            //int mostLengths = resultChildren[0].Length;
            //int mostLengthNums = 0;
            //for (int i = 1; i < resultChildren.Count; i++)
            //{
            //    if (resultChildren[i].Length > mostLengths)
            //    {
            //        mostLengths = resultChildren[i].Length;
            //        mostLengthNums = i;
            //    }
            //}
            //resultChildren.RemoveAt(mostLengthNums);
            //=========================这个是不包含全部的===============

            //现在就开始算查询表达式的子式和结果表达式的子式，然后求前者占后者的比重
            List<String> jiaoji = new List<String>();
            jiaoji = queryChildren.Intersect(resultChildren).ToList();

            //================这个是不包含全部的==============
            //if (resultChildren.Count == 0)
            //    return 0;
            //================这个是不包含全部的==============


            double score = 0;
            score = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(resultChildren.Count);

            //Console.WriteLine("查询表达式子式个数：" + queryChildren.Count);
            //Console.WriteLine("结果表达式子式个数：" + resultChildren.Count);
            //Console.WriteLine("查询表达式占结果表达式分数：" + score);

            return score;

        }//第三个：查询表达式的子式在结果表达式里面相同的个数占结果表达式总子式的比值，作为公式覆盖度
        public double similarChildrenCounts(String resultLaTeX, String queryLaTeX)
        {
            Dictionary<int, List<FinalNode1>> queryLaTeXchildren = new Dictionary<int, List<FinalNode1>>();
            Dictionary<int, List<FinalNode1>> resultLaTeXchildren = new Dictionary<int, List<FinalNode1>>();

            ChildrenBTree childrenBTree = new ChildrenBTree();

            //字典类型,集合里面存的是每一个子式FinalNode节点类型的，中序遍历后的，比如
            //比如a+b+c,存的是a,+,b,这是一个个FinalNode节点类型的字符，所以我得把里面的字符提出来放在一个新集合中，才能好比较
            queryLaTeXchildren = childrenBTree.childrenBTree(queryLaTeX);
            resultLaTeXchildren = childrenBTree.childrenBTree(resultLaTeX);//字典类型

            List<String> queryChildren = new List<String>();//定义专门存放查询表达式的子式集合，因为这样好求相似个数
            List<String> resultChildren = new List<String>();//定义专门存放结果表达式的子式集合，因为这样好求相似个数

            //先把查询表达式字典里面的一个个节点的字符“串”成一个字符串
            foreach (var it in queryLaTeXchildren)
            {
                

                String temp = "";//对于每一个子式，都需要一个字符串来“串或者加起来”
                if (it.Value.Count > 1)
                {
                    foreach (var itt in it.Value)
                    {
                        temp = temp + itt.zifu;//加起来之后就是一个“子式”字符串
                    }
                }
                queryChildren.Add(temp);
            }

            //================这个是不包含全部的==============
            //int mostLength = queryChildren[0].Length;
            //int mostLengthNum = 0;
            //for (int i = 1; i < queryChildren.Count; i++)
            //{
            //    if (queryChildren[i].Length > mostLength)
            //    {
            //        mostLength = queryChildren[i].Length;
            //        mostLengthNum = i;
            //    }
            //}
            //queryChildren.RemoveAt(mostLengthNum);
            //================这个是不包含全部的==============


            //然后把结果表达式字典里面的一个个节点的字符“串”成一个字符串
            foreach (var it in resultLaTeXchildren)
            {
                String temp = "";//对于每一个子式，都需要一个字符串来“串或者加起来”
                if (it.Value.Count > 1)
                {
                    foreach (var itt in it.Value)
                    {
                        temp = temp + itt.zifu;//加起来之后就是一个“子式”字符串
                        
                    }
                }
                resultChildren.Add(temp);
            }

            //================这个是不包含全部的==============
            //int mostLengths = resultChildren[0].Length;
            //int mostLengthNums = 0;
            //for (int i = 1; i < resultChildren.Count; i++)
            //{
            //    if (resultChildren[i].Length > mostLengths)
            //    {
            //        mostLengths = resultChildren[i].Length;
            //        mostLengthNums = i;
            //    }
            //}
            //resultChildren.RemoveAt(mostLengthNums);
            //================这个是不包含全部的==============


            //====================================
            //foreach (var it in queryChildren)
            //{
            //    Console.WriteLine("查询表达式子式："+it);
            //}
            //foreach (var it in resultChildren)
            //{
            //    Console.WriteLine("结果表达式子式：" + it);
            //}
            //===================================



            //现在就开始算查询表达式的子式和结果表达式的子式，然后求前者占后者的比重
            List<String> jiaoji = new List<String>();
            jiaoji = queryChildren.Intersect(resultChildren).ToList();


            //if (queryChildren.Count == 0)
            //    return 0;


            double score = 0;
            score = Convert.ToDouble(jiaoji.Count) / Convert.ToDouble(queryChildren.Count);

            //Console.WriteLine("2交集个数：" + jiaoji.Count);

            //Console.WriteLine("2结果表达式子式个数==============：" + resultChildren.Count);
            //Console.WriteLine("2查询表达式子式个数==============：" + queryChildren.Count);
            //Console.WriteLine("2结果表达式占查询表达式分数======：" + score);

            return score;

        }//第三个：结果表达式的子式在查询表达式里面相同的个数占查询表达式总子式的比值，作为公式覆盖度
        public double formulaCoverage(String queryLaTeX, String resultLaTeX)
        {
            double fenmu = this.similarChildrenCount(queryLaTeX, resultLaTeX) + this.similarChildrenCounts(resultLaTeX,queryLaTeX);
            double fenzi = 2 * this.similarChildrenCount(queryLaTeX, resultLaTeX) * this.similarChildrenCounts(resultLaTeX, queryLaTeX);

            /*Console.WriteLine("公示覆盖度分母："+fenmu);
            Console.WriteLine("公示覆盖度分子：" + fenzi);*/

            double a = 0;

            //Console.WriteLine(fenmu);
            if (Convert.ToInt64(fenmu) == 0)
                return a;
            
            double finalScore = fenzi / fenmu;

            return finalScore;

        }




        public double RootPath(String queryLaTeX, String resultLaTeX)
        {
            AAJaccard jaccard = new AAJaccard();
            List<String> queryList = new List<String>();
            List<String> resultList = new List<String>();
            //查询表达式jaccard系数集合
            queryList = jaccard.queryJaccardList(queryLaTeX);
            //结果表达式jaccard系数集合
            resultList = jaccard.resultJaccardList(resultLaTeX);

            /*//县遍历一下查询表达式jaccard系数试试
            foreach(var it in queryList)
            {
                Console.WriteLine("查询表达好似Jaccard系数:"+it);
            }
            Console.WriteLine("==============================================");
            //县遍历一下结果表达式jaccard系数试试
            foreach (var it in resultList)
            {
                Console.WriteLine("结果表达好似Jaccard系数:" + it);
            }*/

            //开始算最终评分了
            List<String> JiaoJi = new List<String>();
            List<String> BingJI = new List<String>();

            JiaoJi = queryList.Intersect(resultList).ToList();
            BingJI = queryList.Union(resultList).ToList();

            /*foreach (var it in JiaoJi)
            {
                Console.WriteLine("交集是:"+it);
            }

            Console.WriteLine("=================================");
            foreach (var itt in BingJI)
            {
                Console.WriteLine("并集是:"+itt);
            }*/

            double JiaoJiCount = Convert.ToDouble(JiaoJi.Count);
            double BingJiCount = Convert.ToDouble(BingJI.Count);

            double JaccardScore = JiaoJiCount / BingJiCount;
            //Console.WriteLine("Jaccard系数分数:"+JaccardScore);




            /*这是读字典list打印一下，没啥用，因为我不好操作节点
             * foreach (var it in list)
            {
                Console.WriteLine("路径序号:"+it.Key);
                foreach (var itt in it.Value)
                {
                    Console.WriteLine(itt.zifu);
                }
            }*/

            ////定义一个队列
            //Queue<FinalNode1> qNode = new Queue<FinalNode1>();
            //Queue<string> qStr = new Queue<string>();
            //if (queryBtree == null)
            //    return list;
            //qNode.Enqueue(queryBtree);
            //qStr.Enqueue("");
            //while (qNode.Count != 0)
            //{
            //    FinalNode1 curNode = qNode.Dequeue();
            //    String curStr = qStr.Dequeue();
            //    //如果该节点就是一个根节点并且是叶子节点的话
            //    if (curNode.left == null && curNode.right == null)
            //    {
            //        list.Add(curStr + curNode.zifu);
            //    }
            //    //如果左孩子不空的话，那就此时把左孩子放进去
            //    if (curNode.left != null)
            //    {
            //        qNode.Enqueue(curNode.left);
            //        qStr.Enqueue(curStr + curNode.zifu + "->");
            //    }
            //    if (curNode.right != null)
            //    {
            //        qNode.Enqueue(curNode.right);
            //        qStr.Enqueue(curStr + curNode.zifu + "->");
            //    }
            //}

            return JaccardScore;
        }//第四个指标：//这个是树的结构属性

        public double OperateBTLevelAndType(String queryLaTeX, String resultLaTeX)
        {
            AABTreeStructure acquireBtreeStructure = new AABTreeStructure();//调用这个类，获取树结构的类
            List<FinalNode1> queryLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“查询表达式”邻接节点有序对的集合
            List<FinalNode1> resultLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“结果表达式”邻接节点有序对的集合
            queryLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(queryLaTeX);//已经存放“查询表达式”邻接节点有序对的集合
            resultLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(resultLaTeX);//已经存放“结果表达式”邻接节点有序对的集合

            /*//第一步：我先统计一下查询表达式树的深度（先用遍历的方法，以后如果慢的话，我再用递归，我先做出来再说！！！）
            int queryLaTeXBTreeDepth = 0;
            for (int i = 0; i < queryLaTeXAdjacentNodeList.Count; i++)
            {
                if (queryLaTeXAdjacentNodeList[i].BTreeLevel > queryLaTeXBTreeDepth)
                {
                    queryLaTeXBTreeDepth = queryLaTeXAdjacentNodeList[i].BTreeLevel;
                }
            }*/

            //我应该算结果表达式的二叉树对应的高度吧
            int resultLaTeXBTreeDepth = 0;
            for (int i = 0; i < resultLaTeXAdjacentNodeList.Count; i++)
            {
                if (resultLaTeXAdjacentNodeList[i].BTreeLevel > resultLaTeXBTreeDepth)
                {
                    resultLaTeXBTreeDepth = resultLaTeXAdjacentNodeList[i].BTreeLevel;
                }
            }



            //===================先在这按照二叉树所有节点，按照树的高度进行排序==============================
            FinalNode1 tempdata = new FinalNode1();
            for (int i = 0; i < queryLaTeXAdjacentNodeList.Count - 1; i++)
            {
                for (int j = i + 1; j < queryLaTeXAdjacentNodeList.Count; j++)
                {
                    if (queryLaTeXAdjacentNodeList[j].BTreeLevel < queryLaTeXAdjacentNodeList[i].BTreeLevel)
                    {
                        tempdata = queryLaTeXAdjacentNodeList[j];
                        queryLaTeXAdjacentNodeList[j] = queryLaTeXAdjacentNodeList[i];
                        queryLaTeXAdjacentNodeList[i] = tempdata;
                    }
                }
            }
            for (int i = 0; i < resultLaTeXAdjacentNodeList.Count - 1; i++)
            {
                for (int j = i + 1; j < resultLaTeXAdjacentNodeList.Count; j++)
                {
                    if (resultLaTeXAdjacentNodeList[j].BTreeLevel < resultLaTeXAdjacentNodeList[i].BTreeLevel)
                    {
                        tempdata = resultLaTeXAdjacentNodeList[j];
                        resultLaTeXAdjacentNodeList[j] = resultLaTeXAdjacentNodeList[i];
                        resultLaTeXAdjacentNodeList[i] = tempdata;
                    }
                }
            }
            //===================先在这按照二叉树所有节点，按照树的高度进行排序==============================



            //第二步：开始统计查询表达式对应二叉树的树的层次（用字典存储）（其实可以层次遍历二叉树的，到时候再说，先做出来）
            Dictionary<int, List<FinalNode1>> queryDictionary = new Dictionary<int, List<FinalNode1>>();
            for (int j = 0; j < queryLaTeXAdjacentNodeList.Count; j++)
            {
                //遍历查询表达式邻接节点有序对，开始对每一个节点进行判断，如果某一个节点是运算符的话，
                if (isOperator(queryLaTeXAdjacentNodeList[j].zifu))
                {
                    if (queryDictionary.Count == 0)
                    {
                        //这个是添加的第一个元素
                        List<FinalNode1> lists = new List<FinalNode1>();
                        lists.Add(queryLaTeXAdjacentNodeList[j]);
                        queryDictionary.Add(queryLaTeXAdjacentNodeList[j].BTreeLevel, lists);
                        continue;
                    }

                    //如果下一个是运算符，并且树的层次之前有出现了，那就把它再添加到对应后面
                    if (queryDictionary.ContainsKey(queryLaTeXAdjacentNodeList[j].BTreeLevel))
                    {
                        queryDictionary[queryLaTeXAdjacentNodeList[j].BTreeLevel].Add(queryLaTeXAdjacentNodeList[j]);
                    }
                    //如果下一个树的层次没有，那么，就添加进去
                    else
                    {
                        List<FinalNode1> lists = new List<FinalNode1>();
                        lists.Add(queryLaTeXAdjacentNodeList[j]);
                        queryDictionary.Add(queryLaTeXAdjacentNodeList[j].BTreeLevel, lists);
                    }
                }
            }

            /*foreach (var it in queryDictionary)
            {
                Console.WriteLine("查询表达式的树的层次================"+it.Key);
            }*/


            //第三步：开始统计结果表达式对应二叉树的树的层次（用字典存储）
            Dictionary<int, List<FinalNode1>> resultDictionary = new Dictionary<int, List<FinalNode1>>();
            for (int j = 0; j < resultLaTeXAdjacentNodeList.Count; j++)
            {
                //遍历查询表达式邻接节点有序对，开始对每一个节点进行判断，如果某一个节点是运算符的话，
                if (isOperator(resultLaTeXAdjacentNodeList[j].zifu))
                {
                    if (resultDictionary.Count == 0)
                    {
                        //这个是添加的第一个元素
                        List<FinalNode1> lists = new List<FinalNode1>();
                        lists.Add(resultLaTeXAdjacentNodeList[j]);
                        resultDictionary.Add(resultLaTeXAdjacentNodeList[j].BTreeLevel, lists);
                        continue;
                    }

                    //如果下一个是运算符，并且树的层次之前有出现了，那就把它再添加到对应后面
                    if (resultDictionary.ContainsKey(resultLaTeXAdjacentNodeList[j].BTreeLevel))
                    {
                        resultDictionary[resultLaTeXAdjacentNodeList[j].BTreeLevel].Add(resultLaTeXAdjacentNodeList[j]);
                    }
                    //如果下一个树的层次没有，那么，就添加进去
                    else
                    {
                        List<FinalNode1> lists = new List<FinalNode1>();
                        lists.Add(resultLaTeXAdjacentNodeList[j]);
                        resultDictionary.Add(resultLaTeXAdjacentNodeList[j].BTreeLevel, lists);
                    }
                }
            }

            /*foreach (var it in resultDictionary)
            {
                Console.WriteLine("结果表达式树的高度："+it.Key);
            }*/

            //======================================排序啊，排序前=======================================
            ////我先查看一下字典里面的层次
            //foreach (var it in queryDictionary)
            //{
            //    Console.WriteLine("查询字典是啥:"+it.Key);
            //}
            //foreach (var it in resultDictionary)
            //{
            //    Console.WriteLine("结果字典是啥:"+it.Key);
            //}

            /*第四步:开始统计查询表达式从第一层到最后一层，
             * 查询表达式每一层运算符的节点个数，在结果表达式每一层找到的运算符相同的个数
             除以结果表达式对应该层的运算符的总个数的比值，再乘以1-层次除以结果表达式树的层次高度
             */

            //设置一个存放每一层分数的集合
            List<double> scoreList = new List<double>();

            //下面这个是开始遍历查询表达式的每一层，假如现在是第一层，也就是第一个元素
            for (int i = 0; i < queryDictionary.Count; i++)
            {
                //这里在每一层设置一个计算相同运算符或者相同类型运算符的个数的计数工具
                int SameBTLevelCount = 0;

                //注释一下，我怕那个了，此时这个i是查询表达式的高度（或者说元素序号）
                //如果查询表达式的高度大于结果表达式，比如查询表达式现在
                //比如查询表达式高度为5，此时i取0-4，结果表达式也应该是0-4，
                //结果表达式高度为3，但是此时结果表达式高度为0-2，所以当i取3也就是
                //i等于resultDictionary.count时，直接结束
                if (i == resultDictionary.Count)
                    break;
                //下面就是i不等于
                //下面这个是开始遍历查询表达式每一层的节点，
                //用集合存储，可能很多，以第一层为例，也就是说遍历第一层的每一个节点
                //去和结果表达式里面的每一层去比较“是否相同或者是否是同类运算符”
                for (int j = 0; j < queryDictionary[i + 1].Count; j++)
                {
                    //上面这个对于查询表达式每一层的每一个节点，要去结果表达式里面
                    //去和结果表达式里面的每一个节点进行比较，看看是否相同
                    //Console.WriteLine("草拟吗傻逼："+i);
                    for (int k = 0; k < resultDictionary[i + 1].Count; k++)
                    {
                        //这里是相同的运算符或者相似的运算符
                        if (queryDictionary[i + 1][j].zifu.Equals(resultDictionary[i + 1][k].zifu))
                        {
                            SameBTLevelCount++;
                        }
                    }
                }

                //第一层统计完相似的运算符的个数之后，开始计算该层的分数，就以第一层为例
                double BTLevelSum = Convert.ToDouble(resultDictionary[i + 1].Count);//结果表达式中第一层运算符的节点的总个数
                double b = Convert.ToDouble(SameBTLevelCount) / BTLevelSum;//结果表达式中，与查询表达式相似的运算符的个数除以结果表达式的总个数
                //该层相同的节点数不是唯一决定因素，还得乘以所在层次的高度这个权值，占的比重大
                double c = Convert.ToDouble(i + 1);//结果表达式的层次为 i + 1
                double d = Convert.ToDouble(resultLaTeXBTreeDepth);//结果表达式里面对应二叉树的总高度

                //double BTLevelQuanZhong = 1 - c/d;

                //树的每一层，所有层的总和
                int a = 0;

                for (int j = 1; j <= resultLaTeXBTreeDepth; j++)
                {
                    a = a + j;
                }

                double BTLevelZongHe = Convert.ToDouble(a);//树的每一层的总和

                //结果表达式树的高度不就是结果表达式那个字典里面的总个数么，还用遍历然后计算最大值啊！！！不用呢！(哎呀不对，我这个字典里面存的是树的运算符的层次，不是完整的二叉树啊)
                //double BTreeHeight = Convert.ToDouble(resultDictionary.Count);
                double BTreeHeight = resultLaTeXBTreeDepth;//这个才是结果表达式二叉树的最大高度，我在最上面遍历了一下所有节点，找到高度最大的那个

                double BTLevelQuanZhong = (BTreeHeight - (i + 1) + 1) / BTLevelZongHe;

                double BTLevelScore = b * BTLevelQuanZhong;//这个是该层的相似运算符的个数和所在层次的权重相乘的得分
                scoreList.Add(BTLevelScore);

                //Console.WriteLine("每层相似节点的个数:"+SameBTLevelCount);
                //Console.WriteLine("每层结果表达式节点总个数:"+BTLevelSum);
                //Console.WriteLine("树的高度，也就是最大层次为:"+BTreeHeight);
                //Console.WriteLine("树的每一层加起来比如1+2+...总和:"+BTLevelZongHe);
                //Console.WriteLine("结果表达式二叉树节点高度:"+d);
                //Console.WriteLine("每层权重:"+BTLevelQuanZhong);
                //Console.WriteLine("================================");             
            }

            double finalScore = 0;
            //把每一层高度的分数的和遍历打印一下，看看弄的对不对
            foreach (var it in scoreList)
            {
                finalScore = finalScore + it;
                //Console.WriteLine("看看每一层的分数算的对不对:"+it);
            }

            //Console.WriteLine("运算符层次和类型最终分数:"+finalScore);
            return finalScore;
        }//第五个


        //public double OperateBTLevelAndType(String queryLaTeX, String resultLaTeX)
        //{
        //    AABTreeStructure acquireBtreeStructure = new AABTreeStructure();//调用这个类，获取树结构的类
        //    List<FinalNode1> queryLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“查询表达式”邻接节点有序对的集合
        //    List<FinalNode1> resultLaTeXAdjacentNodeList = new List<FinalNode1>();//存放“结果表达式”邻接节点有序对的集合
        //    queryLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(queryLaTeX);//已经存放“查询表达式”邻接节点有序对的集合
        //    resultLaTeXAdjacentNodeList = acquireBtreeStructure.AdjacentNodeList(resultLaTeX);//已经存放“结果表达式”邻接节点有序对的集合

        //    //第一步：我先统计一下查询表达式树的深度（先用遍历的方法，以后如果慢的话，我再用递归，我先做出来再说！！！）
        //    int queryLaTeXBTreeDepth = 0;
        //    for (int i = 0; i < queryLaTeXAdjacentNodeList.Count; i ++)
        //    {
        //        if (queryLaTeXAdjacentNodeList[i].BTreeLevel > queryLaTeXBTreeDepth)
        //        {
        //            queryLaTeXBTreeDepth = queryLaTeXAdjacentNodeList[i].BTreeLevel;
        //        }
        //    }

        //    //第二步：开始统计查询表达式对应二叉树的树的层次（用字典存储）（其实可以层次遍历二叉树的，到时候再说，先做出来）
        //    Dictionary<int, List<FinalNode1>> queryDictionary = new Dictionary<int, List<FinalNode1>>();
        //    for (int j = 0; j < queryLaTeXAdjacentNodeList.Count; j ++)
        //    {
        //        //遍历查询表达式邻接节点有序对，开始对每一个节点进行判断，如果某一个节点是运算符的话，
        //        if (isOperator(queryLaTeXAdjacentNodeList[j].zifu))
        //        {
        //            if (queryDictionary.Count == 0)
        //            {
        //                //这个是添加的第一个元素
        //                List<FinalNode1> lists = new List<FinalNode1>();
        //                lists.Add(queryLaTeXAdjacentNodeList[j]);
        //                queryDictionary.Add(queryLaTeXAdjacentNodeList[j].BTreeLevel,lists);
        //                continue;
        //            }

        //            //如果下一个是运算符，并且树的层次之前有出现了，那就把它再添加到对应后面
        //            if (queryDictionary.ContainsKey(queryLaTeXAdjacentNodeList[j].BTreeLevel))
        //            {
        //                queryDictionary[queryLaTeXAdjacentNodeList[j].BTreeLevel].Add(queryLaTeXAdjacentNodeList[j]);
        //            }
        //            //如果下一个树的层次没有，那么，就添加进去
        //            else
        //            {
        //                List<FinalNode1> lists = new List<FinalNode1>();
        //                lists.Add(queryLaTeXAdjacentNodeList[j]);
        //                queryDictionary.Add(queryLaTeXAdjacentNodeList[j].BTreeLevel, lists);
        //            }
        //        }
        //    }


        //    //第三步：开始统计结果表达式对应二叉树的树的层次（用字典存储）
        //    Dictionary<int, List<FinalNode1>> resultDictionary = new Dictionary<int, List<FinalNode1>>();
        //    for (int j = 0; j < resultLaTeXAdjacentNodeList.Count; j++)
        //    {
        //        //遍历查询表达式邻接节点有序对，开始对每一个节点进行判断，如果某一个节点是运算符的话，
        //        if (isOperator(resultLaTeXAdjacentNodeList[j].zifu))
        //        {
        //            if (resultDictionary.Count == 0)
        //            {
        //                //这个是添加的第一个元素
        //                List<FinalNode1> lists = new List<FinalNode1>();
        //                lists.Add(resultLaTeXAdjacentNodeList[j]);
        //                resultDictionary.Add(resultLaTeXAdjacentNodeList[j].BTreeLevel, lists);
        //                continue;
        //            }

        //            //如果下一个是运算符，并且树的层次之前有出现了，那就把它再添加到对应后面
        //            if (resultDictionary.ContainsKey(resultLaTeXAdjacentNodeList[j].BTreeLevel))
        //            {
        //                resultDictionary[resultLaTeXAdjacentNodeList[j].BTreeLevel].Add(resultLaTeXAdjacentNodeList[j]);
        //            }
        //            //如果下一个树的层次没有，那么，就添加进去
        //            else
        //            {
        //                List<FinalNode1> lists = new List<FinalNode1>();
        //                lists.Add(resultLaTeXAdjacentNodeList[j]);
        //                resultDictionary.Add(resultLaTeXAdjacentNodeList[j].BTreeLevel, lists);
        //            }
        //        }
        //    }

        //    //第四步：开始遍历查询表达式字典，然后开始计算每一树的层次

        //}//第三个指标：查询表达式的二叉树与结果表达式的二叉树中，运算符层次越小，对相似的贡献度越大，并且我把同种类型的运算符放进去，同种类型相似度记为“0.9”


        //这个是树的结构属性




        //public double TFIDF(String queryLaTeX, String resultLaTeX)
        //{
        //    AATfIdf t = new AATfIdf();
        //    List<double> queryLaTeXtfIdfs = new List<double>();
        //    List<double> resultLaTeXtfIdfs = new List<double>();

        //    queryLaTeXtfIdfs = t.tfidf(queryLaTeX);//查询表达式的权值的集合
        //    resultLaTeXtfIdfs = t.tfidf(resultLaTeX);//结果表达式的权值的集合

        //    //Console.WriteLine("补之前查询表达式个数应该一样啊：" + queryLaTeXtfIdfs.Count);
        //    //Console.WriteLine("补之前结果表达式个数应该一样啊:" + resultLaTeXtfIdfs.Count);

        //    //现在该算余弦相似度了吧
        //    //第一步：先给向量少的补0，
        //    double queryCount = queryLaTeXtfIdfs.Count;
        //    double resultCount = resultLaTeXtfIdfs.Count;
        //    if (queryCount > resultCount)
        //    {
        //        for (int i = 0; i < (queryCount - resultCount); i++)
        //        {
        //            resultLaTeXtfIdfs.Add(Convert.ToDouble(0));
        //            //Console.WriteLine("这个打印了几次啊:");
        //        }
        //    }
        //    else if (queryCount < resultCount)
        //    {
        //        for (int j = 0; j < (resultCount - queryCount); j ++)
        //        {
        //            queryLaTeXtfIdfs.Add(Convert.ToDouble(0));
        //        }
        //    }

        //    //第二步开始算两个向量的余弦相似度了(既然此时两个向量的个数相同了，那么以哪一个向量的个数循环都可以)
        //    double temp = 0;//两个向量的向量积
        //    double absolute1 = 0;//查询表达式的模长
        //    double absolute2 = 0;//结果表达式的模长

        //    //Console.WriteLine("查询表达式个数应该一样啊："+queryLaTeXtfIdfs.Count);
        //    //Console.WriteLine("结果表达式个数应该一样啊:"+resultLaTeXtfIdfs.Count);


        //    //1、下面这个是计算向量积
        //    for (int i = 0; i < queryLaTeXtfIdfs.Count; i ++)
        //    {
        //        temp = temp + queryLaTeXtfIdfs[i] * resultLaTeXtfIdfs[i];
        //    }

        //    //2、下面这个是计算模长
        //    for (int i = 0; i < queryLaTeXtfIdfs.Count; i ++)
        //    {
        //        absolute1 = absolute1 + queryLaTeXtfIdfs[i] * queryLaTeXtfIdfs[i];
        //    }

        //    absolute1 = Math.Sqrt(absolute1);//模长你得求根号吧，这个求查询表达式的根号

        //    //3、计算模长
        //    for (int i =0; i < resultLaTeXtfIdfs.Count; i ++)
        //    {
        //        absolute2 = absolute2 + resultLaTeXtfIdfs[i] * resultLaTeXtfIdfs[i];
        //    }

        //    absolute2 = Math.Sqrt(absolute2);//这个求结果表达式的根号
        //    double cosScore;

        //    cosScore = temp / (absolute1 * absolute2);

        //    //Console.WriteLine("看看结果为:"+cosScore);
        //    return cosScore;
        //}//第六个







        //判断是运算符
        private Boolean isOperator(String zifu)
        {
            Boolean a = false;
            if (zifu.Equals("mgroup") || zifu.Equals("lgroup") || zifu.Equals("group") || zifu.Equals("+") || zifu.Equals("-") || zifu.Equals("*") || zifu.Equals("\\times") || zifu.Equals("/") || zifu.Equals("\\frac") || zifu.Equals("#") || zifu.Equals("^") || zifu.Equals("=") || zifu.Equals("\\sqrt") || zifu.Equals("_")
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






    }//指标这个类

}



/*//我先算一下查询表达式所对应二叉树中树的高度的最大值（不对啊，我算查询表达式的高度干啥，我应该算查询表达式在结果表达式中的高度啊）
int MaxqueryLaTeXBTLevel = 0;//设置一个变量存放查询表达式对应二叉树树的高度的最大值
for (int i = 0; i < queryLaTeXAdjacentNodeList.Count; i ++)
{
    if (queryLaTeXAdjacentNodeList[i].BTreeLevel > MaxqueryLaTeXBTLevel)
    {
        MaxqueryLaTeXBTLevel = queryLaTeXAdjacentNodeList[i].BTreeLevel;
    }
}*/
/*while (j != resultLaTeXAdjacentNodeList.Count - queryLaTeXAdjacentNodeList.Count + 1)//这个是以结果表达式作为外层循环，因为是包含匹配
{
//首先要在结果表达式中找到第一个与查询表达式首字母相同的那个字母,，此时i=0，j=某个数，假如是0吧
if (queryLaTeXAdjacentNodeList[i].zifu.Equals(resultLaTeXAdjacentNodeList[j].zifu))
{
finalList.Add(resultLaTeXAdjacentNodeList[j]);
while (i != queryLaTeXAdjacentNodeList.Count)//开始对查询表达式进行循环
{
i++;
j++;
if ()
{

}
}
}
//如果不等于的话,i不变，j++
else
{
j++;
}
}*/
