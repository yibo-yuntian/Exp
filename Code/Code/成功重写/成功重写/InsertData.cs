using DBhelper类封装起来;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功
{
    public class InsertData
    {
        int a = 1;
        //突然想到精确匹配第一次只要去查询邻接矩阵小框框中前驱为#的数学表达式集合即可，从一开始就大大降低索引数量，在数据库中试了一下，每次都是集合越来越小
        public void insert(List<FinalNode1> AdjacentNodeList, Dictionary<String, List<Number>>[][] DataBase, Dictionary<String, int> dictionary2,String LaTeXNumber)
        {

            for (int i = 0; i < AdjacentNodeList.Count; i++)
            {
                AdjacentNodeList[i].Length = AdjacentNodeList.Count;
                AdjacentNodeList[i].zifuXuHao = i + 1;
                //到时候试试，下面里面的LaTeXNumber最好改为AdjacentNodeList[i].LaTeXNumber，到时候试试
                AdjacentNodeList[i].LaTeXNumber = LaTeXNumber;
            }

            /*foreach (var it in AdjacentNodeList)
            {
                Console.WriteLine("草你妈了在哪了:"+it.zifu+"还有它的树的层次啊:"+it.BTreeLevel);
            }*/


            for (int k = 0; k < AdjacentNodeList.Count; k++)
            {
                if (k != AdjacentNodeList.Count-1)
                {
                    //如果字符序号等于1，说明它前面没有字符，所以前驱定为#号
                    if (AdjacentNodeList[k].zifuXuHao == 1)
                    {
                        //Console.WriteLine("开始字符:" + AdjacentNodeList[k].zifu + "结束字符:"+ AdjacentNodeList[k+1].zifu);
                        if (DataBase[dictionary2[AdjacentNodeList[k].zifu]][dictionary2[AdjacentNodeList[k + 1].zifu]] == null)
                        {
                            //如果为空的话，添加一个字典进去
                            Dictionary<String, List<Number>> fillObject = new Dictionary<string, List<Number>>();
                            //开始向二维数组里面添加数据
                            List<Number> listNumber = new List<Number>();
                            Number numbers = new Number();
                            numbers.number = LaTeXNumber;//这里上面到时候把数据集里面row（序号）传进来
                            numbers.finalFeature = Convert.ToString(AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k].Flag) + Convert.ToString(AdjacentNodeList[k].Length)  + Convert.ToString(AdjacentNodeList[k + 1].Level) + Convert.ToString(AdjacentNodeList[k + 1].Flag) + Convert.ToString(AdjacentNodeList[k + 1].Length);
                            numbers.baohanFeature = Convert.ToString(AdjacentNodeList[k + 1].Level - AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k + 1].BTreeLevel - AdjacentNodeList[k].BTreeLevel);
                            listNumber.Add(numbers);
                            fillObject.Add("#", listNumber);
                            DataBase[dictionary2[AdjacentNodeList[k].zifu]][dictionary2[AdjacentNodeList[k + 1].zifu]] = fillObject;
                            a = 0;
                        }
                        //如果字典不为空的话,说明里面有字典了实体了
                        else
                        {
                            if (DataBase[dictionary2[AdjacentNodeList[k].zifu]][dictionary2[AdjacentNodeList[k + 1].zifu]].ContainsKey("#"))
                            {
                                Number numbers = new Number();
                                numbers.number = LaTeXNumber;//这里上面到时候把数据集里面row（序号）传进来
                                numbers.finalFeature = Convert.ToString(AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k].Flag) + Convert.ToString(AdjacentNodeList[k].Length) + Convert.ToString(AdjacentNodeList[k + 1].Level) + Convert.ToString(AdjacentNodeList[k + 1].Flag) + Convert.ToString(AdjacentNodeList[k + 1].Length);
                                numbers.baohanFeature = Convert.ToString(AdjacentNodeList[k + 1].Level - AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k + 1].BTreeLevel - AdjacentNodeList[k].BTreeLevel);
                                DataBase[dictionary2[AdjacentNodeList[k].zifu]][dictionary2[AdjacentNodeList[k + 1].zifu]]["#"].Add(numbers);//在#字后面对应的集合里面继续添加LaTeX序号
                            }
                            else
                            {
                                List<Number> listNumber = new List<Number>();
                                Number numbers = new Number();
                                numbers.number = LaTeXNumber;//不对的话到时候改成AdjacentNodeList[i].LaTeXNumber
                                numbers.finalFeature = Convert.ToString(AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k].Flag) + Convert.ToString(AdjacentNodeList[k].Length) + Convert.ToString(AdjacentNodeList[k + 1].Level) + Convert.ToString(AdjacentNodeList[k + 1].Flag) + Convert.ToString(AdjacentNodeList[k + 1].Length);
                                numbers.baohanFeature = Convert.ToString(AdjacentNodeList[k + 1].Level - AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k + 1].BTreeLevel - AdjacentNodeList[k].BTreeLevel);
                                listNumber.Add(numbers);
                                DataBase[dictionary2[AdjacentNodeList[k].zifu]][dictionary2[AdjacentNodeList[k + 1].zifu]].Add("#",listNumber);
                            }
                        }
                    }
                    //下面这个如果遇到字符序号不是1的话，也就是开始有“新的前驱”
                    else //如果遇到某个字符序号不等于1，说明它前面有字符，也就是说有前驱，“但是前驱可能有好多种”
                    {
                        //其实和上面应该一样，就是如果此时的字符序号不为1，如果为空时
                        if (DataBase[dictionary2[AdjacentNodeList[k].zifu]][dictionary2[AdjacentNodeList[k + 1].zifu]] == null)
                        {
                            Dictionary<String, List<Number>> fillObject2 = new Dictionary<string, List<Number>>();
                            List<Number> listNumber = new List<Number>();
                            Number numbers = new Number();
                            numbers.number = LaTeXNumber;
                            numbers.finalFeature = Convert.ToString(AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k].Flag) + Convert.ToString(AdjacentNodeList[k].Length) + Convert.ToString(AdjacentNodeList[k + 1].Level) + Convert.ToString(AdjacentNodeList[k + 1].Flag) + Convert.ToString(AdjacentNodeList[k + 1].Length);
                            numbers.baohanFeature = Convert.ToString(AdjacentNodeList[k + 1].Level - AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k + 1].BTreeLevel - AdjacentNodeList[k].BTreeLevel);
                            listNumber.Add(numbers);
                            fillObject2.Add(AdjacentNodeList[k - 1].zifu, listNumber);
                            DataBase[dictionary2[AdjacentNodeList[k].zifu]][dictionary2[AdjacentNodeList[k + 1].zifu]] = fillObject2;
                        }
                        //如果不为空时
                        else
                        {
                            //如果不为空时，判断此时有没有该前驱，如果已经有该前驱了有的话，找到该前驱添加集合
                            if (DataBase[dictionary2[AdjacentNodeList[k].zifu]][dictionary2[AdjacentNodeList[k + 1].zifu]].ContainsKey(AdjacentNodeList[k-1].zifu))
                            {
                                Number numbers = new Number();
                                numbers.number = LaTeXNumber;
                                numbers.finalFeature = Convert.ToString(AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k].Flag) + Convert.ToString(AdjacentNodeList[k].Length) + Convert.ToString(AdjacentNodeList[k + 1].Level) + Convert.ToString(AdjacentNodeList[k + 1].Flag) + Convert.ToString(AdjacentNodeList[k + 1].Length);
                                numbers.baohanFeature = Convert.ToString(AdjacentNodeList[k + 1].Level - AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k + 1].BTreeLevel - AdjacentNodeList[k].BTreeLevel);
                                DataBase[dictionary2[AdjacentNodeList[k].zifu]][dictionary2[AdjacentNodeList[k + 1].zifu]][AdjacentNodeList[k - 1].zifu].Add(numbers);//在该前驱后面对应的集合里面继续添加LaTeX序号
                            }
                            //如果没有的话，添加该前驱及对应集合，既然是新前驱的话，那就需要弄一个新集合，然后添加进去
                            else
                            {
                                List<Number> listNumber = new List<Number>();
                                Number numbers = new Number();
                                numbers.number = LaTeXNumber;
                                numbers.finalFeature = Convert.ToString(AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k].Flag) + Convert.ToString(AdjacentNodeList[k].Length) + Convert.ToString(AdjacentNodeList[k + 1].Level) + Convert.ToString(AdjacentNodeList[k + 1].Flag) + Convert.ToString(AdjacentNodeList[k + 1].Length);
                                numbers.baohanFeature = Convert.ToString(AdjacentNodeList[k + 1].Level - AdjacentNodeList[k].Level) + Convert.ToString(AdjacentNodeList[k + 1].BTreeLevel - AdjacentNodeList[k].BTreeLevel);
                                listNumber.Add(numbers);//这是向邻接矩阵的每一个空里面的字典里面添加的LaTeX序号集合
                                DataBase[dictionary2[AdjacentNodeList[k].zifu]][dictionary2[AdjacentNodeList[k + 1].zifu]].Add(AdjacentNodeList[k - 1].zifu,listNumber);
                            }
                        }
                    }

                }
            }

        }
    }

}
