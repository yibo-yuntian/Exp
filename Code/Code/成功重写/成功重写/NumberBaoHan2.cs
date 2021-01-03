using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成功重写
{
   public class NumberBaoHan2
    {
        public String number;//age
        public String finalFeature;//最终特征//name
        public String baohanFeature;//包含特征

        /*public string finalFeature { get; set; }
        public int number { get; set; }*/

        /*public Number(string finalFeature, String number)
        {
            this.finalFeature = finalFeature;
            this.number = number;
        }*/
        public override string ToString()
        {
            return "baohanFeature: " + baohanFeature + " number: " + number;
        }
        //public override bool Equals(object obj)
        //{
        //    if(obj == null)
        //    {
        //        return false;
        //    }
        //    if(obj.GetType() == typeof(Student))
        //    {
        //        Student stu = (Student)obj;
        //        if(stu.Name.Equals(this.Name) && stu.Age == this.Age)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        抛出异常
        //        throw new ArgumentException("类型转换异常");
        //    }
        //}
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is NumberBaoHan2)
            {
                NumberBaoHan2 stu = obj as NumberBaoHan2;
                if (/*stu.baohanFeature.Equals(this.baohanFeature) &&*/ stu.number == this.number)
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
        //如何重写GetHashCode()方法
        //先放着
        public override int GetHashCode()
        {
            return number.GetHashCode();
        }


    }
}
