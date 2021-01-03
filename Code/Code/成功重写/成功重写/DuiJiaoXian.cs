using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功;

namespace 成功重写
{
    public class DuiJiaoXian
    {
        public bool PanDuanDuiJiaoXian(String LaTeX, Dictionary<String, int> dictionary2)
        {
            int a = 0;
            if (dictionary2.ContainsKey(LaTeX))
            {
                a = 1;
            }
            if (a == 1)
                return true;
            else
                return false;
        }

        public void insertDuiJiaoXian(String LaTeX, String LaTeXNumber,Dictionary<String, List<Number>>[][] DataBase, Dictionary<String, int> dictionary2)
        {
            if (DataBase[dictionary2[LaTeX]][dictionary2[LaTeX]] == null)
            {
                Dictionary<String, List<Number>> fillObject = new Dictionary<string, List<Number>>();
                //开始向二维数组里面添加数据
                List<Number> listNumber = new List<Number>();
                Number numbers = new Number();
                numbers.number = LaTeXNumber;//这里上面到时候把数据集里面row（序号）传进来
                listNumber.Add(numbers);
                fillObject.Add("#", listNumber);
                DataBase[dictionary2[LaTeX]][dictionary2[LaTeX]] = fillObject;
            }
            else
            {
                Number numbers = new Number();
                numbers.number = LaTeXNumber;//这里上面到时候把数据集里面row（序号）传进来
                DataBase[dictionary2[LaTeX]][dictionary2[LaTeX]]["#"].Add(numbers);//在#字后面对应的集合里面继续添加LaTeX序号
            }
        }

    }
}
