using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功
{
    public class ReadDictionary
    {
        public Dictionary<int, String> read(String Txt)
        {
            Dictionary<int, String> dictionary = new Dictionary<int, string>();

            //下面这个我是在我的第一个项目里面本来打算用文本里面一行一行的弄了
            FileStream fs = new FileStream(Txt, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(fs, Encoding.Default);
            string strReadline;
            string[] temp;
            while ((strReadline = read.ReadLine()) != null)
            {
                temp = strReadline.Split('#');
                dictionary.Add(Convert.ToInt32(temp[0]),temp[1]);
            }
            return dictionary;
        }

        public Dictionary<String,int> read2(String Txt)
        {
            Dictionary<String, int> dictionary = new Dictionary<String, int>();

            //下面这个我是在我的第一个项目里面本来打算用文本里面一行一行的弄了
            FileStream fs = new FileStream(Txt, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(fs, Encoding.Default);
            string strReadline;
            string[] temp;
            while ((strReadline = read.ReadLine()) != null)
            {
                temp = strReadline.Split('#');
                dictionary.Add(temp[0], Convert.ToInt32(temp[1]));
            }
            return dictionary;
        }



    }
}
