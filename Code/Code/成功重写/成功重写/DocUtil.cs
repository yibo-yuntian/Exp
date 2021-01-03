using ConsoleApplication7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathData.DocAnalyse
{
    public class DocUtil
    {
        
    }
    public class ExpUtil
    {
        private int expId;//当前公式id 有必要进行初始化
        private int theLength;//关键字最大长度 必须进行初始化
        private Dictionary<int, string> latexKeyWordsDC = new Dictionary<int, string>();//存储字典 必须进行初始化
        private Dictionary<int, string> latexKeyWordTypesDC = new Dictionary<int, string>();//存储字典 必须进行初始化
        public List<NodeInfo> nodelist;//需要返回的最终结果
        private int num = 0;
        public ExpUtil()
        {
            //在构造函数里面进行函数初始化 初始化包括上面所有需要初始化的变量
            init();
        }
        
        /// <summary>
        /// 获取公式分解后的所有的节点信息 没有经过初始化的类不能直接调用这个函数
        /// </summary>
        /// <param name="exp">公式信息</param>
        /// <param name="expid">公式对应的id</param>
        /// <returns></returns>
        public List<NodeInfo> GetNodeList(string exp,int expid)
        {
            //每次分析一个新的公式时候  初始化num = 0 ;nodelist = null;防止出现脏数据
            num = 0; nodelist = new List<NodeInfo>();
            expId = expid;
            nodeParser(exp, 0, 0, 0, 0);
            return nodelist;
        }
        #region 类内函数
        /// <summary>
        /// 类内函数进行初始化
        /// </summary>
        /// <returns></returns>
        private void init()
        {
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
        }
        /// <summary>
        /// 分解latex后的单个节点信息
        /// </summary>
        /// <param name="expid">节点对应的公式id</param>
        /// <param name="nodeExp">当前节点信息</param>
        /// <param name="level">当前节点层次</param>
        /// <param name="oprate">当前节点时候为操作符</param>
        /// <param name="flag">当前节点位置标记</param>
        private void insertIntoNodeInfo(int expid, string nodeExp, int level, int oprate, int flag)
        {
            num++;
            NodeInfo node = new NodeInfo
            {
                expid = expid,
                nodeexp = nodeExp,
                level = level,
                opetate = oprate,
                flag = flag,
                num = num,
            };
            nodelist.Add(node);
        }
        /// <summary>
        /// 递归遍历latex公式，分析公式的所有节点信息
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="l"></param>
        /// <param name="o"></param>
        /// <param name="f"></param>
        /// <param name="id"></param>
        private void nodeParser(string exp, int l, int o, int f, int id = 0)
        {
            if (exp == "" || exp == null)
            {
                return;
            }
            int posInExp = 0;
            int tempL = l;
            int tempO = o;
            int tempF = f;

            for (posInExp = 0; posInExp < exp.Length; posInExp++)
            {
                string keyWord = null;    //存储关键字
                char c = exp[posInExp];

                if (c == '\\')
                {
                    if (exp.Length - (posInExp + 1) < theLength)
                    {
                        keyWord = c + exp.Substring(posInExp + 1, exp.Length - (posInExp + 1));
                    }
                    else
                    {
                        keyWord = c + exp.Substring(posInExp + 1, theLength);
                    }

                    try
                    {
                        while (!latexKeyWordsDC.ContainsValue(keyWord))
                        {
                            keyWord = keyWord.Substring(0, keyWord.Length - 1);
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



                    int wordKey = latexKeyWordsDC.First(kv => kv.Value == keyWord).Key;
                    string type = latexKeyWordTypesDC[wordKey];

                    if (type != "fun")
                    {

                        tempL = l;
                        if (type == "syb0")
                        {
                            tempO = 0;
                        }
                        else
                        {
                            tempO = 1;
                        }
                        tempF = f;
                        insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);
                        posInExp = posInExp + keyWord.Length - 1;
                    }
                    else
                    {
                        //函数判别并分别处理
                        if (keyWord == "\\frac" || keyWord == "\\tfrac" || keyWord == "\\cfrac" || keyWord == "\\dfrac")                        //判定关键字为frac
                        {

                            tempL = l;                                      //level不变
                            tempO = 1;                                      //frac为操作符
                            tempF = f;                                      //flag不变
                            insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);

                            //处理frac的参数，其参数的lof将发生变化

                            string param = null;
                            int paramCount = 2;
                            Stack<char> bbraceStack = new Stack<char>();
                            int posInParam = posInExp + keyWord.Length;
                            if (exp[posInParam] == '{')
                            {
                                for (posInParam = posInExp + keyWord.Length; posInParam < exp.Length; posInParam++)
                                {

                                    if (exp[posInParam] == '{')
                                    {
                                        bbraceStack.Push(exp[posInParam]);
                                        if (bbraceStack.Count > 1)
                                        {
                                            param += exp[posInParam];
                                        }

                                    }
                                    else if (exp[posInParam] == '}')
                                    {
                                        bbraceStack.Pop();
                                        if (bbraceStack.Count == 0)
                                        {
                                            paramCount -= 1;
                                            //param = exp.Substring(posInExp + keyWord.Length + 1, posInParam - (posInExp + keyWord.Length + 1));

                                            //递归处理frac参数，修个lof并插入数据库

                                            if (paramCount == 1)
                                            {
                                                tempL = l + 1;
                                                tempO = 0;
                                                tempF = 1;
                                                nodeParser(param, tempL, tempO, tempF);
                                            }
                                            else
                                            {

                                                tempL = l + 1;
                                                tempO = 0;
                                                tempF = 5;
                                                nodeParser(param, tempL, tempO, tempF);

                                            }
                                            param = null;
                                        }
                                        else
                                        {
                                            param += exp[posInParam];
                                        }

                                        if (paramCount == 0)
                                        {
                                            posInExp = posInParam;
                                            break;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        param += exp[posInParam];
                                    }

                                }
                            }
                            else
                            {
                                tempL = l + 1;
                                tempO = 0;
                                tempF = 1;
                                //在这里索引超出数组边界 出现异常
                                string m = exp[posInParam].ToString();
                                string n = exp[posInParam + 1].ToString();
                                nodeParser(m, tempL, tempO, tempF);
                                tempL = l + 1;
                                tempO = 0;
                                tempF = 5;
                                nodeParser(n, tempL, tempO, tempF);
                                posInParam++;
                            }

                            posInExp = posInParam;

                        }

                        else if (keyWord == "\\sqrt")
                        {
                            tempL = l;                                      //level不变
                            tempO = 1;                                      //sqrt为操作符
                            tempF = f;                                      //flag不变
                            insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);

                            //处理参数，即，开方次数和被开方数
                            string param1 = null;                       //存储开方次数
                            string param2 = null;                       //存储被开方数
                            //string fullParam =null;                     //记录sqrt后面所有的字符
                            Stack<char> bbraceStack = new Stack<char>();
                            Stack<char> sbracketStack = new Stack<char>();
                            int posInParam = posInExp + keyWord.Length;
                            for (posInParam = posInExp + keyWord.Length; posInParam < exp.Length; posInParam++)
                            {
                                //测试
                                char a = exp[posInParam];
                                if (exp[posInParam] == '[')
                                {
                                    sbracketStack.Push(exp[posInParam]);
                                    int posInParam1 = posInParam + 1;
                                    for (posInParam1 = posInParam + 1; posInParam1 < exp.Length; posInParam1++)
                                    {
                                        if (exp[posInParam1] == ']' && sbracketStack.Count != 0)
                                        {
                                            //方括号不存在嵌套问题
                                            sbracketStack.Pop();
                                            if (sbracketStack.Count == 0)
                                            {
                                                tempL = l + 1;
                                                tempO = 0;
                                                tempF = 7;
                                                nodeParser(param1, tempL, tempO, tempF);
                                                //在这儿多加类一个1
                                                posInParam = posInParam1;
                                                break;
                                            }
                                        }
                                        param1 += exp[posInParam1];
                                    }
                                }
                                else if (exp[posInParam] == ']' && sbracketStack.Count != 0)
                                {
                                    //方括号不存在嵌套问题
                                    sbracketStack.Pop();
                                    if (sbracketStack.Count == 0)
                                    {
                                        tempL = l + 1;
                                        tempO = 0;
                                        tempF = 7;
                                        nodeParser(param1, tempL, tempO, tempF);
                                    }
                                }
                                else if (exp[posInParam] == '{')
                                {
                                    //开方数区域
                                    if (sbracketStack.Count != 0)
                                    {
                                        param1 += exp[posInParam];
                                        continue;
                                    }
                                    //到达被开方数区域
                                    else if (sbracketStack.Count == 0)
                                    {
                                        bbraceStack.Push(exp[posInParam]);       //被开方数区域头边界


                                        if (bbraceStack.Count > 1)
                                        {
                                            param2 += exp[posInParam];
                                        }
                                    }
                                }
                                else if (exp[posInParam] == '}')
                                {
                                    if (sbracketStack.Count != 0)
                                    {
                                        param1 += exp[posInParam];
                                    }
                                    else if (sbracketStack.Count == 0)
                                    {
                                        bbraceStack.Pop();
                                        if (bbraceStack.Count == 0)
                                        {
                                            tempL = l + 1;
                                            tempO = 0;
                                            tempF = 6;
                                            nodeParser(param2, tempL, tempO, tempF);
                                            posInExp = posInParam;
                                            break;

                                        }
                                        else
                                        {
                                            param2 += exp[posInParam];
                                        }
                                    }

                                }
                                else if (exp[posInParam] == '\\')
                                {
                                    int endPos = 0;
                                    if (exp.Length - posInParam > theLength)
                                    {
                                        endPos = posInParam + theLength;
                                    }
                                    else
                                    {
                                        endPos = exp.Length;
                                    }
                                    string param = exp.Substring(posInParam, endPos - posInParam);
                                    //parm中存放的是符号 直接将符号存进节点信息
                                    while (!latexKeyWordsDC.ContainsValue(param))
                                    {
                                        endPos--;
                                        param = exp.Substring(posInParam, endPos - posInParam);
                                        if (endPos - posInParam <= 2)
                                        {
                                            param = exp.Substring(posInParam, endPos - posInParam);
                                            break;
                                        }
                                    }

                                    param2 += param;

                                    posInExp = endPos - 1;
                                    posInParam = endPos - 1;
                                    if (bbraceStack.Count == 0)
                                    {
                                        param2 += exp[posInParam];
                                        tempL = l + 1;
                                        tempO = 0;
                                        tempF = 6;
                                        nodeParser(param2, tempL, tempO, tempF);
                                        posInExp = posInParam;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (sbracketStack.Count != 0)
                                    {
                                        param1 += exp[posInParam];
                                    }
                                    else if (bbraceStack.Count != 0)
                                    {
                                        param2 += exp[posInParam];
                                    }
                                    else if (bbraceStack.Count == 0)
                                    {
                                        param2 += exp[posInParam];
                                        tempL = l + 1;
                                        tempO = 0;
                                        tempF = 6;
                                        nodeParser(param2, tempL, tempO, tempF);
                                        posInExp = posInParam;
                                        break;
                                    }
                                }
                            }

                            posInExp = posInParam;

                        }
                        else if (keyWord == "\\overbrace")
                        {
                            tempL = l + 1;
                            tempO = 1;                                      //sqrt为操作符
                            tempF = 1;
                            insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);

                            string param = null;
                            string supParam = null;
                            int paramCount = 2;
                            int posInParam = posInExp + keyWord.Length;
                            Stack<char> bbraceStack = new Stack<char>();
                            for (posInParam = posInExp + keyWord.Length; posInParam < exp.Length; posInParam++)
                            {
                                if (exp[posInParam] == '{')
                                {
                                    bbraceStack.Push(exp[posInParam]);
                                    if (bbraceStack.Count > 1)
                                    {
                                        if (paramCount == 2)
                                        {
                                            param += exp[posInParam];
                                        }
                                        else
                                        {
                                            supParam += exp[posInParam];
                                        }
                                    }

                                }
                                else if (exp[posInParam] == '}')
                                {
                                    bbraceStack.Pop();
                                    if (bbraceStack.Count == 0)
                                    {

                                        if (paramCount == 2)
                                        {
                                            //num += 1;
                                            tempL = l;
                                            tempO = 0;
                                            tempF = f;
                                            nodeParser(param, tempL, tempO, tempF);
                                            paramCount -= 1;
                                        }
                                        else
                                        {
                                            tempL = l + 2;
                                            tempO = 0;
                                            tempF = 1;
                                            nodeParser(supParam, tempL, tempO, tempF);
                                        }
                                    }
                                    else
                                    {

                                        if (paramCount == 2)
                                        {
                                            param += exp[posInParam];
                                        }
                                        else
                                        {
                                            supParam += exp[posInParam];
                                        }
                                    }
                                }
                                else if (exp[posInParam] == '^')
                                {
                                    continue;
                                }
                                else
                                {
                                    if (bbraceStack.Count == 0)
                                    {
                                        if (paramCount == 2)
                                        {
                                            //num += 1;
                                            tempL = l;
                                            tempO = 0;
                                            tempF = f;
                                            param = exp[posInParam].ToString();
                                            nodeParser(param, tempL, tempO, tempF);
                                            paramCount -= 1;
                                            continue;
                                        }
                                        else
                                        {
                                            tempL = l + 2;
                                            tempO = 0;
                                            tempF = 1;
                                            supParam = exp[posInParam].ToString();
                                            nodeParser(supParam, tempL, tempO, tempF);
                                            posInExp = posInParam;
                                            break;
                                        }

                                    }
                                    if (paramCount == 2)
                                    {
                                        param += exp[posInParam];
                                    }
                                    else
                                    {
                                        supParam += exp[posInParam];
                                    }
                                }
                            }
                            posInExp = posInParam;

                        }

                        else if (keyWord == "\\underbrace")
                        {
                            tempL = l + 1;
                            tempO = 1;                                      //sqrt为操作符
                            tempF = 5;
                            insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);

                            string param = null;
                            string supParam = null;
                            int paramCount = 2;
                            int posInParam = posInExp + keyWord.Length;
                            Stack<char> bbraceStack = new Stack<char>();
                            for (posInParam = posInExp + keyWord.Length; posInParam < exp.Length; posInParam++)
                            {
                                if (exp[posInParam] == '{')
                                {
                                    bbraceStack.Push(exp[posInParam]);
                                    if (bbraceStack.Count > 1)
                                    {
                                        if (paramCount == 2)
                                        {
                                            param += exp[posInParam];
                                        }
                                        else
                                        {
                                            supParam += exp[posInParam];
                                        }
                                    }

                                }
                                else if (exp[posInParam] == '}')
                                {
                                    bbraceStack.Pop();
                                    if (bbraceStack.Count == 0)
                                    {

                                        if (paramCount == 2)
                                        {
                                            //num += 1;
                                            tempL = l;
                                            tempO = 0;
                                            tempF = f;
                                            nodeParser(param, tempL, tempO, tempF);
                                            paramCount -= 1;
                                        }
                                        else
                                        {
                                            tempL = l + 2;
                                            tempO = 0;
                                            tempF = 5;
                                            nodeParser(supParam, tempL, tempO, tempF);
                                        }
                                    }
                                    else
                                    {

                                        if (paramCount == 2)
                                        {
                                            param += exp[posInParam];
                                        }
                                        else
                                        {
                                            supParam += exp[posInParam];
                                        }
                                    }
                                }
                                else if (exp[posInParam] == '_')
                                {
                                    continue;
                                }
                                else
                                {
                                    if (bbraceStack.Count == 0)
                                    {
                                        if (paramCount == 2)
                                        {
                                            //num += 1;
                                            tempL = l;
                                            tempO = 0;
                                            tempF = f;
                                            param = exp[posInParam].ToString();
                                            nodeParser(param, tempL, tempO, tempF);
                                            paramCount -= 1;
                                            continue;
                                        }
                                        else
                                        {
                                            tempO = 0;
                                            tempF = 5;
                                            supParam = exp[posInParam].ToString();
                                            nodeParser(supParam, tempL, tempO, tempF);
                                            posInExp = posInParam;
                                            break;
                                        }

                                    }
                                    if (paramCount == 2)
                                    {
                                        param += exp[posInParam];
                                    }
                                    else
                                    {
                                        supParam += exp[posInParam];
                                    }
                                }
                            }
                            posInExp = posInParam;

                        }

                        else if (keyWord == "\\mkern" || keyWord == "\\cal" || keyWord == "\\emph" || keyWord == "\\bold" || keyWord == "\\Big" || keyWord == "\\big" || keyWord == "\\bigg" || keyWord == "\\Bbb" || keyWord == "\\mathtt" || keyWord == "\\mathit" || keyWord == "\\mathfrak" || keyWord == "\\boldsymbol" || keyWord == "\\operatorname" || keyWord == "\\mathsf" || keyWord == "\\mathrm" || keyWord == "\\hbox" || keyWord == "\\pmod" || keyWord == "\\scriptstyle" || keyWord == "\\mathcal" || keyWord == "\\mathbb" || keyWord == "\\textstyle" || keyWord == "\\rm" || keyWord == "\\text" || keyWord == "\\mathbf" || keyWord == "\\mathord" || keyWord == "\\operatorname" || keyWord == "\\bf" || keyWord == "\\mbox")
                        {
                            posInExp += keyWord.Length - 1;
                        }
                        else if (keyWord == "\\kern1pt" || keyWord == "\\n" || keyWord == "\\choose" || keyWord == "\\binom" || keyWord == "\\tbinom" || keyWord == "\\atop")
                        {
                            posInExp += keyWord.Length - 1;
                            continue;
                        }
                        else if (keyWord == "\\begin{array}{*{20}{c}}" || keyWord == "\\begin{array}{*{20}{l}}" || keyWord == "\\begin{gathered}" || keyWord == "\\begin{subarray}{l}"|| keyWord == "\\begin{bmatrix}")
                        {
                            Stack<string> areaStack = new Stack<string>();
                            int posInFun = posInExp + keyWord.Length;
                            string param = null;
                            string tempParam = null;
                            char charInParam;

                            string endKeyWord = null;
                            if (keyWord == "\\begin{array}{*{20}{c}}" || keyWord == "\\begin{array}{*{20}{l}}")
                            {
                                endKeyWord = "\\end{array}";
                            }
                            else if (keyWord == "\\begin{gathered}")
                            {
                                endKeyWord = "\\end{gathered}";
                            }
                            else if (keyWord == "\\begin{subarray}{l}")
                            {
                                endKeyWord = "\\end{subarray}";
                            }
                            else if(keyWord== "\\begin{bmatrix}")
                            {
                                endKeyWord = "\\end{bmatrix}";
                            }
                            areaStack.Push("brace");

                            int posInMatrix = 0;

                            for (posInFun = posInExp + keyWord.Length; posInFun <= exp.Length; posInFun++)
                            {
                                charInParam = exp[posInFun];
                                if (charInParam == '\\')
                                {
                                    if (exp.Substring(posInFun, endKeyWord.Length) == endKeyWord)
                                    {
                                        areaStack.Pop();
                                        if (areaStack.Count == 0)
                                        {
                                            tempParam = param;
                                            param = param.Replace(keyWord, string.Empty).Replace(endKeyWord, string.Empty);

                                            string[] blocks = System.Text.RegularExpressions.Regex.Split(param, @"\\\\");
                                            int r = 0;
                                            foreach (string row in blocks)
                                            {
                                                if (row == "")
                                                    continue;
                                                r++;
                                                int li = 0;
                                                string[] line = System.Text.RegularExpressions.Regex.Split(row, @"&");
                                                foreach (string keyWordInLine in line)
                                                {
                                                    posInMatrix++;
                                                    li++;
                                                    if (keyWordInLine == "")
                                                    {
                                                        continue;
                                                    }
                                                    else if (keyWordInLine == null)
                                                    {
                                                        continue;
                                                    }
                                                    tempL = l + 1;
                                                    tempO = 0;

                                                    if (posInMatrix == 1)
                                                    {
                                                        tempF = Convert.ToInt32("6" + posInMatrix.ToString());
                                                    }
                                                    else if (li == 1)
                                                    {
                                                        tempF = Convert.ToInt32("6" + li.ToString());
                                                    }
                                                    else
                                                    {
                                                        //tempF = Convert.ToInt32("6" + li.ToString());
                                                        tempF = 0;
                                                    }

                                                    nodeParser(keyWordInLine, tempL, tempO, tempF);

                                                }

                                            }
                                            posInExp = posInExp + keyWord.Length + tempParam.Length + endKeyWord.Length;
                                            break;
                                        }
                                        else
                                        {
                                            param += charInParam;
                                        }
                                    }
                                    else if (!(posInFun + "\\begin{array}{*{20}{c}}".Length >= exp.Length))
                                    {
                                        if (exp.Substring(posInFun, "\\begin{array}{*{20}{c}}".Length) == "\\begin{array}{*{20}{c}}" || exp.Substring(posInFun, "\\begin{array}{*{20}{l}}".Length) == "\\begin{array}{*{20}{l}}" || exp.Substring(posInFun, "\\begin{gathered}".Length) == "\\begin{gathered}" || exp.Substring(posInFun, "\\begin{subarray}{l}".Length) == "\\begin{subarray}{l}")

                                            areaStack.Push("brace");
                                        param += charInParam;

                                    }
                                    else
                                    {
                                        param += charInParam;
                                    }
                                }
                                else
                                {
                                    param += charInParam;

                                }
                            }

                        }

                        else if (keyWord == "\\overset" || keyWord == "\\stackrel" || keyWord == "\\not" || keyWord == "\\dot" || keyWord == "\\ddot" || keyWord == "\\bar" || keyWord == "\\\\bar" || keyWord == "\\tilde" || keyWord == "\\hat" || keyWord == "\\vec" || keyWord == "\\frown" || keyWord == "\\widetilde" || keyWord == "\\widehat" || keyWord == "\\overline" || keyWord == "\\overrightarrow" || keyWord == "\\overleftarrow")
                        {
                            tempL = l + 1;
                            tempO = 1;
                            tempF = 1;
                            insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);
                            posInExp = posInExp + keyWord.Length - 1;
                        }

                        else if (keyWord == "\\underline" || keyWord == "\\underset")
                        {
                            tempL = l + 1;
                            tempO = 1;
                            tempF = 5;
                            insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);
                            posInExp = posInExp + keyWord.Length - 1;
                        }
                        else if (keyWord == "\\mathop" || keyWord == "\\nolimits" || keyWord == "\\right." || keyWord == "\\hfill" || keyWord == "\\;" || keyWord == "\\left." || keyWord == "\\kern-\\nulldelimiterspace")
                        {
                            posInExp = posInExp + keyWord.Length - 1;
                            continue;
                        }
                        else if (keyWord == "\\color")
                        {
                            posInExp = posInExp + keyWord.Length - 1;
                            int posinparam;
                            Stack<char> bbraceStack = new Stack<char>();
                            for (posinparam = posInExp + 1; posinparam < exp.Length; posinparam++)
                            {
                                if (exp[posinparam] == '{')
                                { bbraceStack.Push(exp[posinparam]); }
                                else if (exp[posinparam] == '}')
                                {
                                    bbraceStack.Pop();
                                    break;
                                }
                            }
                            posInExp = posinparam;


                        }
                        else if (keyWord == "\\limits")
                        {
                            //处理参数
                            string subParam = null;
                            string supParam = null;
                            //string param = null;
                            int posInParam = posInExp + keyWord.Length;
                            for (posInParam = posInExp + keyWord.Length; posInParam < exp.Length; posInParam++)
                            {
                                if (exp[posInParam] == '_')
                                {
                                    Stack<char> bbraceStack = new Stack<char>();
                                    if (exp[posInParam + 1] == '{')
                                    {
                                        //说明该参数长度大于1
                                        bbraceStack.Push(exp[posInParam + 1]);
                                        int length = 1;
                                        while (exp[posInParam + 1 + length] != '}' || bbraceStack.Count != 0)
                                        {
                                            if (exp[posInParam + 1 + length] == '{')
                                            {
                                                bbraceStack.Push(exp[posInParam + 1 + length]);
                                                subParam += exp[posInParam + 1 + length];
                                            }
                                            else if (exp[posInParam + 1 + length] == '}')
                                            {
                                                bbraceStack.Pop();
                                                if (bbraceStack.Count == 0)
                                                {
                                                    tempL = l + 1;
                                                    tempO = 0;
                                                    tempF = 5;
                                                    nodeParser(subParam, tempL, tempO, tempF);
                                                    posInParam = posInParam + 1 + length;
                                                    break;
                                                }
                                                else
                                                {
                                                    subParam += exp[posInParam + 1 + length];
                                                }
                                            }
                                            else
                                            {
                                                subParam += exp[posInParam + 1 + length];
                                            }
                                            length += 1;
                                        }
                                    }
                                    else if (exp[posInParam + 1] == '\\')
                                    {
                                        string theSyb = exp[posInParam + 1].ToString();
                                        int length = 1;

                                        while (!latexKeyWordsDC.ContainsValue(theSyb))
                                        {
                                            theSyb += exp[posInParam + 1 + length];
                                            length += 1;
                                        }
                                        subParam = theSyb;
                                        tempL = l + 1;
                                        tempO = 0;
                                        tempF = 5;
                                        nodeParser(subParam, tempL, tempO, tempF);
                                        posInParam = posInParam + 1 + length;
                                        break;

                                    }
                                    else
                                    {
                                        tempL = l + 1;
                                        tempO = 0;
                                        tempF = 5;
                                        subParam = exp[posInParam + 1].ToString();
                                        nodeParser(subParam, tempL, tempO, tempF);
                                    }
                                    if (posInParam + 1 < exp.Length)
                                    {
                                        if (exp[posInParam + 1] != '^')
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else if (exp[posInParam] == '^')
                                {
                                    Stack<char> bbraceStack = new Stack<char>();
                                    if (exp[posInParam + 1] == '{')
                                    {
                                        //说明该参数长度大于1
                                        bbraceStack.Push(exp[posInParam + 1]);
                                        int length = 1;
                                        while (exp[posInParam + 1 + length] != '}' || bbraceStack.Count != 0)
                                        {
                                            if (exp[posInParam + 1 + length] == '{')
                                            {
                                                bbraceStack.Push(exp[posInParam + 1 + length]);
                                                subParam += exp[posInParam + 1 + length];
                                            }
                                            else if (exp[posInParam + 1 + length] == '}')
                                            {
                                                bbraceStack.Pop();
                                                if (bbraceStack.Count == 0)
                                                {
                                                    tempL = l + 1;
                                                    tempO = 0;
                                                    tempF = 1;
                                                    nodeParser(supParam, tempL, tempO, tempF);
                                                    posInParam = posInParam + 1 + length;
                                                    break;
                                                }
                                                else
                                                {
                                                    supParam += exp[posInParam + 1 + length];
                                                }
                                            }
                                            else
                                            {
                                                supParam += exp[posInParam + 1 + length];
                                            }
                                            length += 1;
                                        }
                                    }
                                    else if (exp[posInParam + 1] == '\\')
                                    {
                                        string theSyb = exp[posInParam + 1].ToString();
                                        int length = 1;

                                        while (!latexKeyWordsDC.ContainsValue(theSyb))
                                        {
                                            theSyb += exp[posInParam + 1 + length];
                                            length += 1;
                                        }
                                        supParam = theSyb;
                                        tempL = l + 1;
                                        tempO = 0;
                                        tempF = 1;
                                        nodeParser(supParam, tempL, tempO, tempF);
                                        posInParam = posInParam + 1 + length;
                                        break;

                                    }
                                    else
                                    {
                                        tempL = l + 1;
                                        tempO = 0;
                                        tempF = 1;
                                        supParam = exp[posInParam + 1].ToString();
                                        nodeParser(supParam, tempL, tempO, tempF);
                                        posInParam = posInParam + 1;
                                    }
                                }

                            }

                            posInExp = posInParam;
                        }

                        else if (keyWord == "\\sum\\limits" || keyWord == "\\int\\limits" || keyWord == "\\int//2\\limits" || keyWord == "\\int//3\\limits" || keyWord == "\\oint\\limits" || keyWord == "\\prod\\limits" || keyWord == "\\coprod\\limits" || keyWord == "\\bigcap\\limits" || keyWord == "\\bigcup\\limits" || keyWord == "\\iint\\limits" || keyWord == "\\iiint\\limits" || keyWord == "\\iint" || keyWord == "\\iiint")
                        {
                            tempL = l;                                      //level不变
                            tempO = 1;                                      //frac为操作符
                            tempF = f;                                      //flag不变        
                            if (keyWord == "\\iint" || keyWord == "\\iiint")
                            {
                                insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);
                            }
                            else
                            {
                                insertIntoNodeInfo(expId, keyWord.Substring(0, keyWord.Length - "\\limits".Length), tempL, tempO, tempF);
                            }
                            //处理参数
                            string subParam = null;
                            string supParam = null;
                            int posInParam = posInExp + keyWord.Length;
                            for (posInParam = posInExp + keyWord.Length; posInParam < exp.Length; posInParam++)
                            {
                                if (exp[posInParam] == '_')
                                {
                                    Stack<char> bbraceStack = new Stack<char>();
                                    if (exp[posInParam + 1] == '{')
                                    {
                                        //说明该参数长度大于1
                                        bbraceStack.Push(exp[posInParam + 1]);
                                        int length = 1;
                                        while (exp[posInParam + 1 + length] != '}' || bbraceStack.Count != 0)
                                        {
                                            if (exp[posInParam + 1 + length] == '{')
                                            {
                                                bbraceStack.Push(exp[posInParam + 1 + length]);
                                                subParam += exp[posInParam + 1 + length];
                                                length += 1;
                                                continue;
                                            }
                                            if (exp[posInParam + 1 + length] == '}')
                                            {
                                                bbraceStack.Pop();
                                                if (bbraceStack.Count == 0)
                                                {
                                                    tempL = l + 1;
                                                    tempO = 0;
                                                    tempF = 5;
                                                    nodeParser(subParam, tempL, tempO, tempF);
                                                    posInParam = posInParam + 1 + length;
                                                    break;
                                                }
                                                else
                                                {
                                                    subParam += exp[posInParam + 1 + length];
                                                }
                                            }
                                            else
                                            {
                                                subParam += exp[posInParam + 1 + length];
                                            }
                                            length += 1;
                                        }
                                    }
                                    else if (exp[posInParam + 1] == '\\')
                                    {
                                        string theSyb = exp[posInParam + 1].ToString();
                                        int length = 1;

                                        while (!latexKeyWordsDC.ContainsValue(theSyb))
                                        {
                                            theSyb += exp[posInParam + 1 + length];
                                            length += 1;
                                        }
                                        subParam = theSyb;
                                        tempL = l + 1;
                                        tempO = 0;
                                        tempF = 5;
                                        nodeParser(subParam, tempL, tempO, tempF);
                                        posInParam = posInParam + 1 + length;
                                        break;

                                    }
                                    else
                                    {
                                        tempL = l + 1;
                                        tempO = 0;
                                        tempF = 5;
                                        subParam = exp[posInParam + 1].ToString();
                                        nodeParser(subParam, tempL, tempO, tempF);
                                    }
                                }
                                else if (exp[posInParam] == '^')
                                {
                                    Stack<char> bbraceStack = new Stack<char>();
                                    if (exp[posInParam + 1] == '{')
                                    {
                                        //说明该参数长度大于1
                                        bbraceStack.Push(exp[posInParam + 1]);
                                        int length = 1;
                                        while (exp[posInParam + 1 + length] != '}' || bbraceStack.Count != 0)
                                        {
                                            if (exp[posInParam + 1 + length] == '{')
                                            {
                                                bbraceStack.Push(exp[posInParam + 1 + length]);
                                                supParam += exp[posInParam + 1 + length];
                                                length += 1;
                                                continue;
                                            }
                                            if (exp[posInParam + 1 + length] == '}')
                                            {
                                                bbraceStack.Pop();
                                                if (bbraceStack.Count == 0)
                                                {
                                                    tempL = l + 1;
                                                    tempO = 0;
                                                    tempF = 1;
                                                    nodeParser(supParam, tempL, tempO, tempF);
                                                    posInParam = posInParam + 1 + length;
                                                    break;
                                                }
                                                else
                                                {
                                                    supParam += exp[posInParam + 1 + length];
                                                }
                                            }
                                            else
                                            {
                                                supParam += exp[posInParam + 1 + length];
                                            }
                                            length += 1;
                                        }
                                    }
                                    else if (exp[posInParam + 1] == '\\')
                                    {
                                        string theSyb = exp[posInParam + 1].ToString();
                                        int length = 1;

                                        while (!latexKeyWordsDC.ContainsValue(theSyb))
                                        {
                                            theSyb += exp[posInParam + 1 + length];
                                            length += 1;
                                        }
                                        supParam = theSyb;
                                        tempL = l + 1;
                                        tempO = 0;
                                        tempF = 1;
                                        nodeParser(supParam, tempL, tempO, tempF);
                                        posInParam = posInParam + 1 + length;
                                        break;

                                    }
                                    else
                                    {
                                        tempL = l + 1;
                                        tempO = 0;
                                        tempF = 1;
                                        supParam = exp[posInParam + 1].ToString();
                                        nodeParser(supParam, tempL, tempO, tempF);
                                        posInParam = posInParam + 1;
                                    }

                                    break;
                                }
                            }

                            posInExp = posInParam;
                        }
                        else if (keyWord == "\\sum\\nolimits" || keyWord == "\\int\\nolimits" || keyWord == "\\int//2\\nolimits" || keyWord == "\\int//3\\nolimits" || keyWord == "\\oint\\nolimits" || keyWord == "\\prod\\nolimits" || keyWord == "\\coprod\\nolimits" || keyWord == "\\bigcap\\nolimits" || keyWord == "\\bigcup\\nolimits")
                        {
                            tempL = l;                                      //level不变
                            tempO = 1;                                      //frac为操作符
                            tempF = f;                                      //flag不变                           ;
                            insertIntoNodeInfo(expId, keyWord.Substring(0, keyWord.Length - "\\nolimits".Length), tempL, tempO, tempF);
                            posInExp = posInExp + keyWord.Length - 1;
                        }
                        else
                        {
                            //MessageBox.Show("关键字：" + keyWord + "未被处理！\r\n");
                        }

                    }


                }

                else if (char.IsLetterOrDigit(c))
                {
                    keyWord = c.ToString();
                    tempL = l;                          //level不变
                    tempO = 0;                          //数字和字母的各种形式一定是变量
                    tempF = f;                        //flag不变
                    insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);
                }
                else if (c == '^')
                {
                    string param = null;
                    if (exp[posInExp + 1] == '{')
                    {
                        Stack<char> bbraceStack = new Stack<char>();

                        int posInParam = posInExp + 1;
                        for (posInParam = posInExp + 1; posInParam < exp.Length; posInParam++)
                        {
                            if (exp[posInParam] == '{')
                            {
                                bbraceStack.Push(exp[posInParam]);
                                if (bbraceStack.Count > 1)
                                {
                                    param += exp[posInParam];
                                }
                            }
                            else if (exp[posInParam] == '}')
                            {
                                bbraceStack.Pop();
                                if (bbraceStack.Count == 0)
                                {
                                    tempL = l + 1;
                                    tempO = 0;
                                    tempF = 2;
                                    nodeParser(param, tempL, tempO, tempF);
                                    posInExp = posInParam;
                                    break;
                                }
                                else
                                {
                                    param += exp[posInParam];
                                }
                            }
                            else
                            {
                                param += exp[posInParam];

                            }


                        }


                    }
                    else if (exp[posInExp + 1] == '\\')                    //遇到一个变量型符号
                    {
                        int posInParam;
                        for (posInParam = posInExp + 1; posInParam < exp.Length; posInParam++)
                        {
                            param += exp[posInParam];
                            if (param == "\\frac" || param == "\\tfrac" || param == "\\cfrac" || param == "\\dfrac")
                            {
                                tempL = l + 1;
                                tempO = 1;
                                tempF = 2;
                                insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);

                                string param1 = null;
                                int paramCount = 2;
                                Stack<char> bbraceStack = new Stack<char>();
                                int posInParam1 = posInExp + 6;



                                for (posInParam1 = posInExp + 6; posInParam1 < exp.Length; posInParam1++)
                                {


                                    if (exp[posInParam1] == '{')
                                    {
                                        bbraceStack.Push(exp[posInParam1]);
                                        if (bbraceStack.Count > 1)
                                        {
                                            param1 += exp[posInParam1];
                                        }

                                    }
                                    else if (exp[posInParam1] == '}')
                                    {
                                        bbraceStack.Pop();
                                        if (bbraceStack.Count == 0)
                                        {
                                            paramCount -= 1;

                                            if (paramCount == 1)
                                            {
                                                tempL = l + 2;
                                                tempO = 0;
                                                tempF = 1;
                                                nodeParser(param1, tempL, tempO, tempF);
                                            }
                                            else
                                            {
                                                tempL = l + 2;
                                                tempO = 0;
                                                tempF = 5;
                                                nodeParser(param1, tempL, tempO, tempF);
                                                break;

                                            }
                                            param1 = null;
                                            posInExp = posInParam1;
                                        }
                                        else
                                        {
                                            param1 += exp[posInParam1];
                                        }

                                        if (paramCount == 0)
                                        {
                                            posInExp = posInParam1;
                                            break;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        param1 += exp[posInParam1];
                                    }

                                }
                                posInExp = posInParam1;

                            }
                            else
                            {
                                if (latexKeyWordsDC.ContainsValue(param))
                                {
                                    tempL = l + 1;
                                    tempO = 0;
                                    tempF = 2;
                                    nodeParser(param, tempL, tempO, tempF);
                                    posInExp = posInExp + param.Length;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        param += exp[posInExp + 1];
                        tempL = l + 1;
                        tempO = 0;
                        tempF = 2;
                        nodeParser(param, tempL, tempO, tempF);
                        posInExp = posInExp + 1;
                    }
                }
                else if (c == '_')
                {
                    string param = null;
                    if (exp[posInExp + 1] == '{')
                    {
                        Stack<char> bbraceStack = new Stack<char>();

                        for (int posInParam = posInExp + 1; posInParam < exp.Length; posInParam++)
                        {
                            if (exp[posInParam] == '{')
                            {
                                bbraceStack.Push(exp[posInParam]);
                                if (bbraceStack.Count > 1)
                                {
                                    param += exp[posInParam];
                                }
                            }
                            else if (exp[posInParam] == '}')
                            {
                                bbraceStack.Pop();
                                if (bbraceStack.Count == 0)
                                {
                                    tempL = l + 1;
                                    tempO = 0;
                                    tempF = 4;
                                    nodeParser(param, tempL, tempO, tempF);
                                    posInExp = posInParam;
                                    break;
                                }
                                else
                                {
                                    param += exp[posInParam];
                                }
                            }
                            else
                            {
                                param += exp[posInParam];

                            }
                        }
                    }
                    else if (exp[posInExp + 1] == '\\')                    //遇到一个变量型符号
                    {
                        int posInParam;
                        for (posInParam = posInExp + 1; posInParam < exp.Length; posInParam++)
                        {
                            param += exp[posInParam];
                            if (param == "\\mathrm")
                            {
                                Stack<char> bbraceStack = new Stack<char>();

                                for (int posInParam0 = posInExp + 8; posInParam0 < exp.Length; posInParam0++)
                                {
                                    if (exp[posInParam0] == '{')
                                    {
                                        bbraceStack.Push(exp[posInParam0]);
                                        if (bbraceStack.Count > 1)
                                        {
                                            param += exp[posInParam0];
                                        }
                                    }
                                    else if (exp[posInParam0] == '}')
                                    {
                                        bbraceStack.Pop();
                                        if (bbraceStack.Count == 0)
                                        {
                                            tempL = l + 1;
                                            tempO = 0;
                                            tempF = 4;
                                            nodeParser(param, tempL, tempO, tempF);
                                            posInExp = posInParam0;
                                            break;
                                        }
                                        else
                                        {
                                            param += exp[posInParam0];
                                        }
                                    }
                                    else
                                    {
                                        param += exp[posInParam0];

                                    }
                                }
                            }
                            else if (param == "\\frac" || param == "\\tfrac" || param == "\\cfrac" || param == "\\dfrac")
                            {
                                tempL = l + 1;
                                tempO = 1;
                                tempF = 4;
                                insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);

                                string param1 = null;
                                int paramCount = 2;
                                Stack<char> bbraceStack = new Stack<char>();
                                int posInParam1 = posInExp + 6;



                                for (posInParam1 = posInExp + 6; posInParam1 < exp.Length; posInParam1++)
                                {


                                    if (exp[posInParam1] == '{')
                                    {
                                        bbraceStack.Push(exp[posInParam1]);
                                        if (bbraceStack.Count > 1)
                                        {
                                            param1 += exp[posInParam1];
                                        }

                                    }
                                    else if (exp[posInParam1] == '}')
                                    {
                                        bbraceStack.Pop();
                                        if (bbraceStack.Count == 0)
                                        {
                                            paramCount -= 1;

                                            if (paramCount == 1)
                                            {
                                                tempL = l + 2;
                                                tempO = 0;
                                                tempF = 1;
                                                nodeParser(param1, tempL, tempO, tempF);
                                            }
                                            else
                                            {
                                                tempL = l + 2;
                                                tempO = 0;
                                                tempF = 5;
                                                nodeParser(param1, tempL, tempO, tempF);
                                                break;

                                            }
                                            param1 = null;
                                            posInExp = posInParam1;
                                        }
                                        else
                                        {
                                            param1 += exp[posInParam1];
                                        }

                                        if (paramCount == 0)
                                        {
                                            posInExp = posInParam1;
                                            break;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        param1 += exp[posInParam1];
                                    }

                                }
                                posInExp = posInParam1;

                            }
                            else if (latexKeyWordsDC.ContainsValue(param))
                            {
                                tempL = l + 1;
                                tempO = 0;
                                tempF = 4;
                                nodeParser(param, tempL, tempO, tempF);
                                posInExp = posInExp + 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        tempL = l + 1;
                        tempO = 0;
                        tempF = 4;
                        nodeParser(exp[posInExp + 1].ToString(), tempL, tempO, tempF);
                        posInExp = posInExp + 1;
                    }
                }
                else if (c == '{' || c == '}')
                {
                    continue;
                }
                else
                {
                    keyWord = c.ToString();
                    tempL = l;                          //level不变
                    tempO = 1;                          //一般符号：+、-
                    tempF = f;                          //flag不变
                    insertIntoNodeInfo(expId, keyWord, tempL, tempO, tempF);
                    //insertIntoNodeInfo(expId, keyWord, num, l, o, f);
                }

            }
        }
        #endregion
    }
}
