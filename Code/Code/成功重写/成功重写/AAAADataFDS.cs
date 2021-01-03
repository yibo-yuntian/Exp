using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 成功插入二叉树;

namespace 成功重写
{
    public class AAAADataFDS
    {
        public double BTLevel;//这个是子式在二叉树中的高度
        public String str;//这个是层次遍历二叉树序列，可以唯一标记子式
        public String queryStr;//这个记录查询表达式分数
        public String resultStr;//这个记录结果表达式分数


        //下面这个相当于把默认的函数库里面的方法就给重写了

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is AAAAData)
            {
                AAAAData stu = obj as AAAAData;
                if (stu.BTLevel == this.BTLevel && stu.str == this.str)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("类型转换异常");
            }

        }


    }




   }

